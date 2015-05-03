using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceSystemClientV2.Helpers;
using AttendanceSystemClientV2.Models;
using AttendanceSystemClientV2.PC;
using AttendanceSystemClientV2.UserInterface;

namespace AttendanceSystemClientV2.Controls {

    /// <summary>
    /// 签到用的控制类
    /// </summary>
    public static class RollCallControl {

        private static WaitForm waitForm = null;

        public delegate void UpdateUserInterfaceDelegate(Student student);

        /// <summary>
        /// 传入开课编号 上课编号 实际上课时间 初始化考勤信息
        /// 这里需要对指纹进行初始化 
        /// </summary>
        /// <param name="kkno">开课编号</param>
        /// <param name="skno">上课编号</param>
        /// <param name="expectedArriveTime">实际考勤时间</param>
        public static void Init ( long kkno, long skno, DateTime expectedArriveTime ) {

            var classBriefcase = BriefcaseControl.GetBriefcase ( kkno ); // 拿课程对应的Briefcase 

            var dmTable = OfflineDataControl.GetDmDatatable ( kkno, skno ); // 拿本节课对应的点名表

            var xkTable = OfflineDataControl.GetXktable ( kkno ); // 拿课程对应的学生信息

            var dmTableList = dmTable.ToList<DMTABLE_08_NOPIC_VIEW> ();

            var studentList = InitStudentList ( xkTable, dmTableList, expectedArriveTime );

            var studentDatatable = EnumerableExtension.ListToDataTable ( studentList, "学生列表" );

            //todo:接下来要做的事情:
            //1.打开指纹仪
            //2.识别出来的号码拿出来 放到Student List里查 查完了把Student对象扔到界面委托里显示.
            //3.用while(bool变量)控制结束签到
            //4.结束签到的时候直接closeUsb即可
        }

        public static List<Student> InitStudentList ( DataTable xkTableList, List<DMTABLE_08_NOPIC_VIEW> dmTableList, DateTime expectedArriveTime ) {

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

                studentList.Add ( student );
            }

            studentList = StartInitFingerprint(studentList);

            return studentList;

        }


        public static List<Student> StartInitFingerprint ( List<Student> studentList ) {

            //建立委托

            var updateProgressBarDelegate = new FingerPrintControl.UpdateProgressBarDelegate(UpdateProgressBar);

            var closeProgressBarDelegate = new FingerPrintControl.CloseProgressBarDelegate(CloseProgressBar);

            var showConfirmBoxDelegate = new FingerPrintControl.ShowConfirmBoxDelegate(ShowConfirmBoxDelegate);

            waitForm = new WaitForm ( "正在初始化指纹仪" );

            var initFingerprintThread = new Thread(() => FingerPrintControl.InitFingerprint(ref studentList, updateProgressBarDelegate, showConfirmBoxDelegate,
                closeProgressBarDelegate));

            initFingerprintThread.Start();

            waitForm.ShowDialog();

            return studentList;


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
        public static DialogResult ShowConfirmBoxDelegate ( string text ) {

            var dialogResault = DialogResult.OK;

            waitForm.Invoke ( new MethodInvoker ( ( ) => {
                dialogResault = ConfirmBox.ShowConfirmBoxDialog ( text );
            } ) );

            return dialogResault;

        }



    }
}
