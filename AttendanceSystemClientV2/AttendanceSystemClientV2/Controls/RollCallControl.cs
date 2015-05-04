using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceSystemClientV2.Helpers;
using AttendanceSystemClientV2.Models;
using AttendanceSystemClientV2.PC;
using AttendanceSystemClientV2.Properties;
using AttendanceSystemClientV2.UserInterface;

namespace AttendanceSystemClientV2.Controls {

    /// <summary>
    /// 签到用的控制类
    /// </summary>
    public static class RollCallControl {

        private static WaitForm waitForm = null;

        public delegate void UpdateUserInterfaceDelegate ( Image fingerprintImage, CourseInfo courseInfo, Student student = null );

        public delegate void StopRollCallDelegate();

        public delegate StopRollCallDelegate StartRollCallDelegate(
            UpdateUserInterfaceDelegate updateUserInterfaceDelegate);

        /// <summary>
        /// 这里存着Student列表的一份拷贝.  如果需要指纹点名,就用这里的List吧.
        /// </summary>
        public static List<Student> CopyOfStudentList; 

        public static IntPtr FingerPrintHandle;

        public static Boolean IsRollCalling;


        /// <summary>
        /// 传入开课编号 上课编号 实际上课时间 初始化考勤信息
        /// 这里需要对指纹进行初始化 
        /// </summary>
        /// <param name="kkno">开课编号</param>
        /// <param name="skno">上课编号</param>
        /// <param name="expectedArriveTime">实际考勤时间</param>
        public static List<Student> Init ( long kkno, long skno, DateTime expectedArriveTime ) {

            var classBriefcase = BriefcaseControl.GetBriefcase ( kkno ); // 拿课程对应的Briefcase 

            var dmTable = OfflineDataControl.GetDmDatatable ( kkno, skno ); // 拿本节课对应的点名表

            var xkTable = OfflineDataControl.GetXktable ( kkno ); // 拿课程对应的学生信息

            var dmTableList = dmTable.ToList<DMTABLE_08_NOPIC_VIEW> ();

            var studentList = InitStudentList ( xkTable, dmTableList, expectedArriveTime , skno , kkno );

            studentList = StartInitFingerprint(studentList);

            CopyOfStudentList = studentList;

            return studentList;


        }

        public static List<Student> InitStudentList ( DataTable xkTableList, List<DMTABLE_08_NOPIC_VIEW> dmTableList, DateTime expectedArriveTime , long skno , long kkno ) {

            var studentList = new List<Student> ();

            var bjTable = BriefcaseControl.GetBjTableDictionary ();

            foreach (DataRow xkRecord in xkTableList.Rows) {



                var index = dmTableList.FindIndex ( s => s.XSID == (string)xkRecord["XSID"] );

                if (-1 == index) continue; // 如果点名表里没这个学生的话 就跳过该学生

                var dmRecord = dmTableList[index];

                var student = new Student ( xkRecord, dmRecord, expectedArriveTime );

                var classId = student.ClassId;

                var bjName = bjTable[classId];

                student.ClassName = bjName;

                student.skno = skno;

                student.kkno = kkno;

                if (dmRecord.DMSJ1 != null) student.ArriveTime = dmRecord.DMSJ1.Value;

                studentList.Add ( student );
            }

            return studentList;

        }


        public static List<Student> StartInitFingerprint ( List<Student> studentList ) {

            //建立委托

            var updateProgressBarDelegate = new FingerPrintControl.UpdateProgressBarDelegate(UpdateProgressBar);

            var closeProgressBarDelegate = new FingerPrintControl.CloseProgressBarDelegate(CloseProgressBar);

            var showConfirmBoxDelegate = new FingerPrintControl.ShowConfirmBoxDelegate(ShowConfirmBox);

            waitForm = new WaitForm ( "正在初始化指纹仪" );

            var initFingerprintThread = new Thread(() => FingerPrintControl.InitFingerprint(ref studentList, updateProgressBarDelegate, showConfirmBoxDelegate,
                closeProgressBarDelegate));

            initFingerprintThread.Start();

            waitForm.ShowDialog();

            return studentList;


        }

        public static void StartRollCall( List<Student> studentList ,  UpdateUserInterfaceDelegate updateUserInterfaceDelegate){

            waitForm = new WaitForm("正在初始化指纹仪");

            IsRollCalling = true;

            var fingerprintEnrollThread = new Thread ( ( ) => Enroll ( studentList,updateUserInterfaceDelegate ) );

            fingerprintEnrollThread.Start();

        }

        /// <summary>
        /// 一个大循环 用来操作指纹仪.
        /// 这个函数要放到一个线程里来执行
        /// </summary>
        /// <param name="studentList"></param>
        /// <param name="updateUserInterfaceDelegate">用来操作UI的委托</param>
        public static void Enroll(List<Student> studentList, UpdateUserInterfaceDelegate updateUserInterfaceDelegate){

            FingerPrintHandle = HdFingerprintHelper.FpOpenUsb ( 0xFFFFFFFF, 1000 ); // 打开指纹仪驱动

            //while (FingerPrintHandle == IntPtr.Zero) {

            //    var confirmResault = ShowConfirmBox ( "指纹仪初始化失败 \n是否重新初始化指纹仪?" );

            //    if (confirmResault == DialogResult.OK) {

            //        FingerPrintHandle = HdFingerprintHelper.FpOpenUsb ( 0xFFFFFFFF, 1000 );

            //    } else {

            //        ShowMsgBox ( "当前指纹仪无法工作,请使用手动考勤." );

            //        return;
            //    }
            //}

            //如果打不开 就只能手动签到了
            //上面的这些已经注释了.  因为在switch那边有对错误的处理.


            var acceptPlayer = new SoundPlayer(Resources.Accept);

            var rejectPlayer = new SoundPlayer(Resources.Reject);

            var fingerprintImagePath = GlobalParams.RootDir + "/fingerprint.bmp";

            while (IsRollCalling){

                UInt16 fingerprintid = 1000;

                UInt16 similarity = 0;


                var fingerPrintStat = HdFingerprintHelper.StartVerify ( FingerPrintHandle, fingerprintImagePath, ref  fingerprintid, ref  similarity,
                   3000 );

                if (!IsRollCalling) return; // 如果结束点名了 这个函数直接返回即可

                switch (fingerPrintStat) {

                    case 0:{

                        acceptPlayer.Play();

                        var index = studentList.FindIndex ( s => s.FingerprintId == fingerprintid );

                        if (index == -1)
                            continue;

                        var student = studentList[index];
                        
                        student.SignIn(DateTime.Now);

                        //var fingerprintImage = new File(GlobalParams.RootDir+@"/fingerprint.bmp")

                        var fileInfo = new FileInfo(fingerprintImagePath);

                        Image fingerprintImage;

                        if (fileInfo.Length != 0){

                            var stream = File.Open(fingerprintImagePath, FileMode.Open);

                            fingerprintImage = Image.FromStream(stream);

                            stream.Close();
                        }
                        else{
                            fingerprintImage = null;
                        }

                        var normalStudentNum = CountNormalStudent(studentList);

                        var absentStudentNum = CountAbsentStudent(studentList);

                        var lateStudentNum = CountLateStudent(studentList);

                        var askForLeaveStudentNum = CountAskForLeaveStudent(studentList);

                        var leaveEarlyStudentNum = CountLeaveEarlyStudent(studentList);

                        var expectedStudentNum = studentList.Count;

                        var course = new CourseInfo(expectedStudentNum: expectedStudentNum, didNotSubmitStudentNum:
                            absentStudentNum, actualStudentNum: normalStudentNum,
                            askForLeaveStudentNum: askForLeaveStudentNum);

                        updateUserInterfaceDelegate(fingerprintImage , course , student);

                        CopyOfStudentList = studentList;

                        break;

                    }
                    case 9:{
                        //这里会出现文件占用的问题. 文件->流->图片
                        var fileInfo = new FileInfo(fingerprintImagePath);

                        Image fingerprintImage;

                        if (fileInfo.Length != 0){

                            var stream = File.Open(fingerprintImagePath, FileMode.Open);

                            fingerprintImage = Image.FromStream(stream);

                            stream.Close();
                        }
                        else{
                            fingerprintImage = null;
                        }

                        updateUserInterfaceDelegate(fingerprintImage, null);

                        rejectPlayer.Play();

                        break;

                    }
                    default:{

                        var confirmResault = ConfirmBox.ShowConfirmBoxDialog(string.Format("指纹仪故障 故障代码:{0}\n 是否重新打开指纹仪", fingerPrintStat));

                        if (confirmResault == DialogResult.Cancel){
                            
                            IsRollCalling = false;

                            return;
                            // 如果点了否 就结束指纹仪点名.  点是 重新初始化.  手动签到那里要判断一下(不用判断了 在switch的入口那边加了一个对IsrollCalling的一个判断.)
                        }else{
                            
                            FingerPrintHandle = HdFingerprintHelper.FpOpenUsb ( 0xFFFFFFFF, 1000 ); // 重新初始化指纹仪

                        }

                        break;
                            
                    }

                }

            }

        }


        //0 正常 1 迟到 2 早退 3 旷课 4 请假 5 未签到

        /// <summary>
        /// 计算正常出勤学生
        /// </summary>
        /// <param name="dmList"></param>
        /// <returns></returns>
        private static int CountNormalStudent ( IEnumerable<Student> dmList ) {

            var counter = from c in dmList where c.RollCallStatus == 0 || c.RollCallStatus == 1 select c;

            return counter.Count ();


        }

        /// <summary>
        /// 计算缺勤学生
        /// </summary>
        /// <param name="dmList"></param>
        /// <returns></returns>
        private static int CountAbsentStudent ( IEnumerable<Student> dmList ) {

            var counter = from c in dmList where c.RollCallStatus == 3 || c.RollCallStatus == 5 select c;

            return counter.Count ();

        }

        /// <summary>
        /// 计算迟到学生
        /// </summary>
        /// <param name="dmList"></param>
        /// <returns></returns>
        private static int CountLateStudent ( IEnumerable<Student> dmList ) {

            var counter = from c in dmList where c.RollCallStatus == 1 select c;

            return counter.Count ();

        }

        /// <summary>
        /// 计算请假学生
        /// </summary>
        /// <param name="dmList"></param>
        /// <returns></returns>
        private static int CountAskForLeaveStudent ( IEnumerable<Student> dmList ) {

            var counter = from c in dmList where c.RollCallStatus == 4 select c;

            return counter.Count ();

        }

        /// <summary>
        /// 计算早退学生
        /// </summary>
        /// <param name="dmList"></param>
        /// <returns></returns>
        private static int CountLeaveEarlyStudent ( IEnumerable<Student> dmList ) {

            var counter = from c in dmList where c.RollCallStatus == 2 select c;

            return counter.Count ();

        }

        /// <summary>
        /// 让指纹仪停下来
        /// </summary>
        public static void StopFingerprint(){

            IsRollCalling = false;

            HdFingerprintHelper.FpCloseUsb(FingerPrintHandle);

        }

        //指纹仪委托参考:
        // public delegate void UpdateProgressBarDelegate ( int progress, string text ); 更新进度条

        //public delegate DialogResult ShowConfirmBoxDelegate(string text); // 显示确认窗口

        //public delegate void CloseProgressBarDelegate(); // 关闭进度条窗口

        /// <summary>
        /// 这个函数将来要绑在UpdateProgressBarDelegate上.
        /// </summary>
        /// <param name="progress">要增加的进度数值</param>
        /// <param name="text">要更新的界面文字</param>
        public static void UpdateProgressBar ( int progress, string text ) {

            waitForm.Invoke ( new MethodInvoker ( ( ) => {
                waitForm.Increase ( progress );
                waitForm.SetInfo ( text );
            } ) );

        }

        /// <summary>
        /// 关闭进度条窗口 这个函数将来要加到CloseProgressBarDelegate上
        /// </summary>
        public static void CloseProgressBar ( ){

            waitForm.Invoke(new MethodInvoker(() => waitForm.Close()));

        }

        /// <summary>
        /// 显示确认窗口 这个函数将来要加到ShowConfirmBoxDelegate上
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DialogResult ShowConfirmBox ( string text ) {

            var dialogResault = DialogResult.OK;

            waitForm.Invoke ( new MethodInvoker ( ( ) => {
                dialogResault = ConfirmBox.ShowConfirmBoxDialog ( text );
            } ) );

            return dialogResault;

        }

        public static void ShowMsgBox(string information){

            waitForm.Invoke(new MethodInvoker(() => MsgBox.ShowMsgBoxDialog(information)));

        }

        public static void SetOneCourseDidNotSubmit(long kkno , long skno){

            var courseBriefcase = BriefcaseControl.GetBriefcase(kkno);

            var classInfoTable =  OfflineDataControl.GetClassInfoTable(kkno);

            var classInfoRows = classInfoTable.Select(string.Format("上课编号 = '{0}'", skno));

            classInfoRows.First().BeginEdit();

            classInfoRows.First()["上课状态"] = "未提交";


        }

    }
}
