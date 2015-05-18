using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using AttendanceSystemClientV2.Controls;
using AttendanceSystemClientV2.Models;
using AttendanceSystemClientV2.PC;
using AttendanceSystemClientV2.Properties;
using AttendanceSystemClientV2.UserInterface;
using Telerik.WinControls.UI;

namespace AttendanceSystemClientV2.UserInterface {
    public partial class MainForm : RadForm {
        #region Private fields
        private readonly DataModule _fDataModule;

        private bool _rollCalling = false;

        #endregion
        //显示隐藏的学生列表
        //选择标签页的时候弹出toast提示
        //标签页侧边栏需要背景
        public MainForm ( ){

            SplashForm.ShowSplashForm();

            var d = DateTime.Now;

            InitializeComponent ();

            _rollCalling = false;//标记是否正在进行考勤工作

            _fDataModule = new DataModule ();//datamodule 用于查看数据(好像没什么用耶)。

            dp_ResetMainForm (); // 重置窗口的显示

            dp_BindDataSourceForFirstClassListBox (); // 为第一个标签页中的左上角ListBox绑定数据源

            dp_BindDataSourceForThirdClassListBox ();//为第三个标签页中的左上角Listbox绑定数据源

            Settings.Default.UserId = ""; // 清空密码用户名信息

            Settings.Default.Password = "";

            Settings.Default.Save (); // 保存

            dp_DisableRollCallButtons ();

            mainPageView.SelectedPage = downloadDataPage;

            SplashForm.CloseSplashForm();

            radLabelElement1.Text = System.Reflection.Assembly.GetExecutingAssembly ().ToString ();
        }


        private void manualBtn_Click ( object sender, EventArgs e ) {

            /***********得到kkno和skno 然后验证离线密码***********/

            var selectedproperty = (KeyValuePair<long, string>)coursesListBox1.SelectedItem; // 获取已经选择的项目

            if (selectedproperty.Key == -1) { //判断是否有数据
                MsgBox.ShowMsgBoxDialog ( "没有数据" );
            }

            var rollCallingDetailRow = classInfoGview1.SelectedRows[0];

            var kkno = selectedproperty.Key;

            var skno = Convert.ToInt64 ( rollCallingDetailRow.Cells["上课编号"].Value );

            var ydSkdate = Convert.ToString ( (rollCallingDetailRow.Cells["上课日期"].Value) );

            var kkname = Convert.ToString ( selectedproperty.Value );

            //验证离线密码
            var offlineVerifyResault = BriefcaseControl.VerifyOfflinePasswd ( kkno );

            if (!offlineVerifyResault) {

                MsgBox.ShowMsgBoxDialog ( "验证口令失败" );

                return;
            }

            /***********得到kkno和skno 然后验证离线密码***********/

            RollCallControl.StopFingerprint(); // 初始化完了之后再停指纹仪

            new ViewStudentsForm(kkno , skno , true).ShowDialog() ; // 手动点名完了之后 copyofstudentlist里面已经存着新的数据了.



            var showStudentInformationDelegate = new RollCallControl.UpdateUserInterfaceDelegate(ShowStudentInformation);

            RollCallControl.StartRollCall ( RollCallControl.CopyOfStudentList, showStudentInformationDelegate );



        }



        private void radButton1_Click ( object sender, EventArgs e ) {

            var resault = new LogOnForm ().ShowDialog ();//显示下载课程窗口

            if (resault == DialogResult.Cancel)
                return;

            try {

                new ShowServerClassesForm ().ShowDialog ();

            } catch (RemObjects.SDK.Exceptions.SessionNotFoundException) {

                MsgBox.ShowMsgBoxDialog ( "登录异常" );

            } //todo:将下面的catch放出来
            catch (Exception expException) {

                MsgBox.ShowMsgBoxDialog ( expException.Message + "\n" + expException.StackTrace );
            } finally {
                //dp_RefreshMainForm ();
                dp_BindDataSourceForFirstClassListBox (); // 为第一个标签页中的左上角ListBox绑定数据源
                // 不管怎样 点击完下载课程之后一定要刷新一下显示
            }
        }

        private void coursesListBox_SelectedIndexChanged ( object sender, EventArgs e ) {

            var selectedproperty = (KeyValuePair<long, string>)coursesListBox1.SelectedItem; // 获取已经选择的项目

            if (selectedproperty.Key == -1) {
                return;
            }

            var courseInfo = new CourseInfo ( selectedproperty.Key );

            dp_RefreshFirstDetails ( courseInfo );

            dp_BindDataSourceForFirstClassStatusGridView ( selectedproperty.Key );

            courseNoLbl1.Text = selectedproperty.Key.ToString();
        }

        /// <summary>
        /// 刷新第一个页面的课程详情
        /// </summary>
        /// <param name="courseInfo">描述一门课程的类</param>
        private void dp_RefreshFirstDetails ( CourseInfo courseInfo ) {

            courseNameLbl1.Text = courseInfo.CourseName; // 课程名称

            teacherNameLbl1.Text = courseInfo.TeacherName; // 教师姓名

            lastTimeSubmit1.Text = courseInfo.LastModified; // 最后一次更改时间


        }

        /// <summary>
        /// 为第一个标签页的左上角ListBox绑定数据源 该Listbox会显示存在于该平板中的所有课程
        /// 该函数会直接调用Controls中的函数,获取数据源.
        /// 这样可以直接用于刷新界面显示之类的操作.
        /// </summary>
        private void dp_BindDataSourceForFirstClassListBox ( ) {

            var dpCourseInfoDictionary = OfflineDataControl.GetCourseInfoDictionary ();

            coursesListBox1.DataSource = new BindingSource ( dpCourseInfoDictionary, null );

            coursesListBox1.DisplayMember = "Value"; //设置显示字段

            coursesListBox1.ValueMember = "Key";//设置值字段

        }


        /// <summary>
        /// 刷新第一个标签页中Gridview的显示状态.  
        /// </summary>
        /// <param name="kkno">上课编号</param>
        private void dp_BindDataSourceForFirstClassStatusGridView ( long kkno ) {

            var classInfoDatatable = OfflineDataControl.GetClassInfoTable ( kkno );

            classInfoDatatable.DefaultView.Sort = "上课日期 DESC";

            classInfoGview1.DataSource = classInfoDatatable;

        }

        /// <summary>
        /// 绑定第三个标签页左上角的Listbox的数据源.
        /// 该函数可以用于刷新第三个标签页的显示.
        /// </summary>
        private void dp_BindDataSourceForThirdClassListBox ( ) {

            var dpCourseInfoDictionary = OfflineDataControl.GetCourseInfoDictionary ();

            courseListLbox3.DataSource = new BindingSource ( dpCourseInfoDictionary, null );

            courseListLbox3.DisplayMember = "Value"; //设置显示字段

            courseListLbox3.ValueMember = "Key";//设置值字段

        }

        private void dp_RefreshThirdDetails ( CourseInfo courseInfo ) {

            courseNameLbl3.Text = courseInfo.CourseName;

            teacherNameLbl3.Text = courseInfo.TeacherName;

            lastTimeSubmit3.Text = courseInfo.LastModified;

        }

        private void courseListLbox3_SelectedIndexChanged ( object sender, EventArgs e ) {

            var selectedproperty = (KeyValuePair<long, string>)courseListLbox3.SelectedItem; // 获取已经选择的项目

            if (selectedproperty.Key == -1) { //判断是否有数据
                return;
            }

            var courseInfo = new CourseInfo ( selectedproperty.Key ); // 

            dp_RefreshThirdDetails ( courseInfo ); // 刷新左下方的显示

            dp_BindDataSourceForThirdClassStatusGridView ( selectedproperty.Key ); // 设置第三个标签页右侧的gridview数据源

            courseNoLbl3.Text = selectedproperty.Key.ToString();
        }

        private void showRollCallingDetailBtn_Click ( object sender, EventArgs e ) {
            //显示课程提交状态按钮 点击之后 后面的签到状态表会显示出来.
            dataManagementOperationButtonsPanel.Enabled = (!dataManagementOperationButtonsPanel.Enabled);

            showRollCallingDetailBtnPanel.Visible = (!showRollCallingDetailBtnPanel.Visible);

        }


        /// <summary>
        /// 刷新第三个标签页中Gridview的显示状态.(进行绑定操作)  
        /// 需要操作界面中的控件 所以讲函数放在了这里.
        /// </summary>
        /// <param name="skno">上课编号</param>
        private void dp_BindDataSourceForThirdClassStatusGridView ( long skno ) {

            var classInfoDatatable = OfflineDataControl.GetClassInfoTable ( skno ); // 获取ClassInfo表

            classInfoDatatable.DefaultView.Sort = "上课日期 DESC"; // 按照日期 降序排序

            rollCallingDetailGview3.DataSource = classInfoDatatable; // 绑定刚才得到的datatable

        }

        private void viewRollCallDetailsBtn_Click ( object sender, EventArgs e ) {



            var selectedproperty = (KeyValuePair<long, string>)courseListLbox3.SelectedItem; // 获取已经选择的项目

            if (selectedproperty.Key == -1) { //判断是否有数据
                return;
            }

            var rollCallingDetailRow = this.rollCallingDetailGview3.SelectedRows[0];

            var kkno = selectedproperty.Key;

            var skno = Convert.ToInt64 ( rollCallingDetailRow.Cells["上课编号"].Value );

            //验证离线密码
            var offlineVerifyResault = BriefcaseControl.VerifyOfflinePasswd ( kkno );

            if (!offlineVerifyResault) {

                MsgBox.ShowMsgBoxDialog ( "验证口令失败" );

                return;
            }
            // 如果验证不通过 则提示密码错误 并返回 什么都不做.

            //显示 View StudentsForm 窗口.
            var viewStudentForm = new ViewStudentsForm ( kkno, skno  , false);

            if (!viewStudentForm.IsDisposed) { // 判断该窗口是否已经被释放

                viewStudentForm.ShowDialog ();

            }
        }

        /// <summary>
        /// 刷新界面课程列表的显示
        /// </summary>
        private void dp_RefreshMainForm ( ) {

            dp_BindDataSourceForFirstClassListBox (); // 为第一个标签页中的左上角ListBox绑定数据源

            dp_BindDataSourceForThirdClassListBox ();//为第三个标签页中的左上角Listbox绑定数据源

        }

        /// <summary>
        /// 重置界面的显示(主要是点名界面)
        /// </summary>
        private void dp_ResetMainForm ( ) {

            
            photoPbox.Image = Resources.male;

            mainPageView.SelectedPage = startRollCallPage;

            studentClassLbl2.Text = @"班级名称"; // 班级名称


            studentNameLbl2.Text = @"姓名";

            studentIdLbl2.Text = @"学号";

            rollCallStatus2.Text = @"状态";

            label7.Text = @"这里显示姓名";

            //更新右侧的统计信息 包括饼图
            expectedStudentNumLbl.Text = @"应到人数";

            didNotSubmitStudentNumLbl.Text = @"未到";

            actualStudentNumLbl.Text = @"迟到";

            askForLeaveStudentNumLbl.Text = @"请假";

            var didNotSubmitStudentNumText = label19.Text + didNotSubmitStudentNumLbl.Text;

            var actualStudentNumLblText = label14.Text + actualStudentNumLbl.Text;

            var askForLeaveStudentNumLblText = label18.Text + askForLeaveStudentNumLbl.Text;

            var xData = new List<string> () { didNotSubmitStudentNumText, actualStudentNumLblText, askForLeaveStudentNumLblText };

            var yData = new List<int> () { 2, 10, 3, };

            chart1.Series[0].Points.DataBindXY ( xData, yData );
            //统计信息操作结束

        }

        /// <summary>
        /// ///上传数据按钮函数 需要做以下几件事
        /// 1.验证密码(已经做完)
        /// 2.传入kkno 显示窗口提示本节课信息
        /// 3.传入kkno和skno 显示上课时间 点击确定之后 上传数据.
        /// 4.提示是否刷新指纹信息
        /// 5.传入kkno 刷新指纹信息.
        /// 其中 上传数据 和 刷新指纹信息需要显示进度条
        /// 刷新指纹信息要时间长一些. 建议单独放在线程中去做.
        /// 所有的事情应该全部在DataUploadControl中.
        /// 不要传Briefcase要不然打死你
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uploadDataBtn_Click ( object sender, EventArgs e ) {

            var selectedproperty = (KeyValuePair<long, string>)courseListLbox3.SelectedItem; // 获取已经选择的项目


            if (selectedproperty.Key == -1) { //判断是否有数据
                MsgBox.ShowMsgBoxDialog ( "没有数据" );
            }

            var courseInfo = new CourseInfo ( selectedproperty.Key );

            Settings.Default.UserId = courseInfo.TeacherNo; // 设置登录时的教师编号

            var rollCallingDetailRow = this.rollCallingDetailGview3.SelectedRows[0];

            var kkno = selectedproperty.Key;

            var skno = Convert.ToInt64 ( rollCallingDetailRow.Cells["上课编号"].Value );

            var skdate = Convert.ToString ( (rollCallingDetailRow.Cells["上课日期"].Value) );

            var kkname = Convert.ToString ( selectedproperty.Value );
            //验证离线密码
            var offlineVerifyResault = BriefcaseControl.VerifyOfflinePasswd ( kkno );

            if (!offlineVerifyResault) {

                MsgBox.ShowMsgBoxDialog ( "验证口令失败" );

                return;
            }
            // 如果验证不通过 则提示密码错误 并返回 什么都不做.
            //todo:上传数据的业务逻辑在这里编写即可 需要从界面里带出去的东西:1.上课编号2.课程编号 3.预计上课时间

            var logonForm = new LogOnForm ();//登录窗口

            logonForm.ShowDialog (); // 显示登录窗口

            var displayString = DataUploadControl.GenerateConfirmString ( kkno, kkname, skno, skdate );

            var confirmResault = ConfirmBox.ShowConfirmBoxDialog ( "请确认要上传的课程信息:\n" + displayString );

            if (confirmResault == DialogResult.Cancel) return;//如果点击了取消 就取消上传课程.

            //todo:在这里写上传数据的业务逻辑

            DataUploadControl.UploadOneClass ( kkno, skno );

            MsgBox.ShowMsgBoxDialog ( displayString + "\n\n上传完成" );

            //dp_RefreshMainForm ();

            dp_BindDataSourceForThirdClassListBox ();//为第三个标签页中的左上角Listbox绑定数据源
        }

        

        private void radButton1_Click_1 ( object sender, EventArgs e ) {

            var selectedproperty = (KeyValuePair<long, string>)coursesListBox1.SelectedItem; // 获取已经选择的项目

            if (selectedproperty.Key == -1) { //判断是否有数据
                MsgBox.ShowMsgBoxDialog ( "没有数据" );
            }

            var rollCallingDetailRow = classInfoGview1.SelectedRows[0];

            var kkno = selectedproperty.Key;

            var skno = Convert.ToInt64 ( rollCallingDetailRow.Cells["上课编号"].Value );

            var ydSkdate = Convert.ToString ( (rollCallingDetailRow.Cells["上课日期"].Value) );

            var kkname = Convert.ToString ( selectedproperty.Value );

            //验证离线密码
            var offlineVerifyResault = BriefcaseControl.VerifyOfflinePasswd ( kkno );

            if (!offlineVerifyResault) {

                MsgBox.ShowMsgBoxDialog ( "验证口令失败" );

                return;
            }
            // 如果验证不通过 则提示密码错误 并返回 什么都不做.
            //todo:指纹点名的业务逻辑在这里编写即可 需要从界面里带出去的东西:1.上课编号2.课程编号 3.实际上课时间

            //把预定上课时间传出去
            var getRollCallTimeForm = new SetTimeForm ( Convert.ToDateTime ( ydSkdate ) );

            var getRollCallTimeResault = getRollCallTimeForm.ShowDialog (); // 显示设置时间窗口

            if (getRollCallTimeResault == DialogResult.Cancel) { // 如果点击了返回 那么就不要再往下走了.
                return;
            }

            var actualRollCallTime = getRollCallTimeForm.GetActualRollCallTime ();

            var skrecordList = OfflineDataControl.GetSktable ( kkno );// 将来需要把这个拿来更新上课表

            //var skrecord = (from c in skrecordList where c.SKNO == skno select c).First (); // linq  完了以后把第一条记录取出来(一共就有一条记录.)

            //FindIndex(a => a.SKNO == (long) sktableRow["SKNO"])

            var skrecordIndex = skrecordList.FindIndex(a => a.SKNO == skno);

            var skrecord = skrecordList[skrecordIndex];

            skrecord.SKZT = 3;

            skrecord.DMFS = 1;

            skrecord.SKDATE = actualRollCallTime;

            OfflineDataControl.SaveSkTable(skrecordList , kkno); // 存上课表


            courseNameLbl2.Text = kkname; // 课程名称 label内容

            expectedTeachingTimeLbl.Text = ydSkdate; // 预定上课时间 label内容

            teacherNameLbl2.Text = teacherNameLbl1.Text; // 教师姓名 label内容

            actualTeachingTimeLbl.Text = actualRollCallTime.ToString("f"); //实际上课时间内容

            var studentList = RollCallControl.Init ( kkno, skno, actualRollCallTime );

            //对于RollCallControl来说 这个委托是用来更新界面的.具体怎么更新界面他不用管 所以不用改名
            var showStudentInformationDelegate =
                new RollCallControl.UpdateUserInterfaceDelegate ( ShowStudentInformation );

            RollCallControl.StartRollCall(studentList ,showStudentInformationDelegate);

            mainPageView.SelectedPage = startRollCallPage;
            
            dp_ResetMainForm();

            dp_EnableRollcallButtons();

            rollCallStudentListGv.DataSource = RollCallControl.CopyOfStudentList;


            //todo:接下来要做的事情:
            //1.打开指纹仪
            //2.识别出来的号码拿出来 放到Student List里查 查完了把Student对象扔到界面委托里显示.
            //3.用while(bool变量)控制结束签到
            //4.结束签到的时候直接closeUsb即可
            //写一个函数 传入更新界面的Delegate 该函数需要在一个新的线程里编写.

        }

        /// <summary>
        /// 显示辅助函数. 
        /// 拿到学生信息之后 要通过这个函数来更新界面 
        /// </summary>
        /// <param name="fingerprintImage">指纹图像</param>
        /// <param name="courseInfo">里面应该有应到人数和实到人数.</param>
        /// <param name="student">学生.  如果为空则显示指纹图像</param>
        private void Dp_ShowStudentInformation ( Image fingerprintImage, CourseInfo courseInfo, Student student = null ) {

            if (student == null) {

                if (fingerprintImage == null) // 如果没图片的话就返回 图片可能会不存在于硬盘上
                    return;

                photoPbox.Image = fingerprintImage;

                studentNameLbl2.Text = @"请重按手指";

                mainPageView.SelectedPage = startRollCallPage;

                studentClassLbl2.Text = ""; // 班级名称

                studentNameLbl2.Text = "";

                studentIdLbl2.Text = "";

                rollCallStatus2.Text = "";

                label7.Text = @"请重按手指";

                return;

            }

            mainPageView.SelectedPage = startRollCallPage;

            studentClassLbl2.Text = student.ClassName; // 班级名称

            photoPbox.Image = student.StudentPhoto; // 学生照片

            studentNameLbl2.Text = student.StudentName;

            studentIdLbl2.Text = student.StudentId;

            rollCallStatus2.Text = student.RollCallStatusString;

            label7.Text = student.StudentName;

            //更新右侧的统计信息 包括饼图
            expectedStudentNumLbl.Text = courseInfo.expectedStudentNum.ToString ();

            didNotSubmitStudentNumLbl.Text = courseInfo.didNotSubmitStudentNum.ToString ();

            actualStudentNumLbl.Text = courseInfo.actualStudentNum.ToString ();

            askForLeaveStudentNumLbl.Text = courseInfo.askForLeaveStudentNum.ToString ();

            var expectedStudentNumLblText = label13.Text + expectedStudentNumLbl.Text;

            var didNotSubmitStudentNumText = label19.Text + didNotSubmitStudentNumLbl.Text;

            var actualStudentNumLblText = label14.Text + actualStudentNumLbl.Text;

            var askForLeaveStudentNumLblText = label18.Text + askForLeaveStudentNumLbl.Text;

            var xData = new List<string> () { didNotSubmitStudentNumText, actualStudentNumLblText, askForLeaveStudentNumLblText };

            var yData = new List<int> () {  courseInfo.didNotSubmitStudentNum, courseInfo.actualStudentNum, courseInfo.askForLeaveStudentNum, };

            chart1.Series[0].Points.DataBindXY(xData, yData);
            //统计信息操作结束

        }

        public void ShowStudentInformation ( Image fingerprintImage, CourseInfo courseInfo, Student student = null ){

            Invoke(new MethodInvoker(() => Dp_ShowStudentInformation(fingerprintImage, courseInfo, student)));

        }

        /// <summary>
        /// 结束点名按钮函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopRollCallBtn_Click ( object sender, EventArgs e ){

            /***********得到kkno和skno 然后验证离线密码***********/

            var selectedproperty = (KeyValuePair<long, string>)coursesListBox1.SelectedItem; // 获取已经选择的项目

            if (selectedproperty.Key == -1) { //判断是否有数据
                MsgBox.ShowMsgBoxDialog ( "没有数据" );
            }

            var rollCallingDetailRow = classInfoGview1.SelectedRows[0];

            var kkno = selectedproperty.Key;

            var skno = Convert.ToInt64 ( rollCallingDetailRow.Cells["上课编号"].Value );

            var ydSkdate = Convert.ToString ( (rollCallingDetailRow.Cells["上课日期"].Value) );

            var kkname = Convert.ToString ( selectedproperty.Value );

            //验证离线密码
            var offlineVerifyResault = BriefcaseControl.VerifyOfflinePasswd ( kkno );

            if (!offlineVerifyResault) {

                MsgBox.ShowMsgBoxDialog ( "验证口令失败" );

                return;
            }

            /***********得到kkno和skno 然后验证离线密码***********/

            RollCallControl.SetOneCourseDidNotSubmit(kkno, skno);

            stopRollCallBtn.Enabled = false;

            RollCallControl.StopFingerprint(); // 先停指纹仪

            dp_ResetMainForm(); // 再重置窗口

            dp_DisableRollCallButtons ();//然后把按钮关掉.

        }



        /// <summary>
        /// 让签到控制按钮变为可用
        /// </summary>
        private void dp_EnableRollcallButtons(){

            showBriefStudentListBtn.Enabled = true;

            manualRollCallBtn.Enabled = true;

            stopRollCallBtn.Enabled = true;

            radButton1.Enabled = false;

            coursesListBox1.Enabled = false;

            classInfoGview1.Enabled = false;
        }

        /// <summary>
        /// 让签到按钮变为不可用
        /// </summary>
        private void dp_DisableRollCallButtons(){

            showBriefStudentListBtn.Enabled = false;

            manualRollCallBtn.Enabled = false;

            stopRollCallBtn.Enabled = false;

            radButton1.Enabled = true;

            coursesListBox1.Enabled = true;

            classInfoGview1.Enabled = true;
        }

        private void showBriefStudentListBtn_Click ( object sender, EventArgs e ) {

            rollCallStudentListPn.BringToFront(); // 将学生列表放在前端

        }

        private void chooseClassBtn_Click ( object sender, EventArgs e ) {

            currentStudentDetailPn.BringToFront (); //将当前学生信息放在前端

        }

        private void pictureBox1_Click ( object sender, EventArgs e ){

            var dialogResault = ConfirmBox.ShowConfirmBoxDialog("确定要退出吗?");

            if (dialogResault == DialogResult.OK){


                Close ();

            }


        }

        private void pictureBox1_MouseDown ( object sender, MouseEventArgs e ) {

            pictureBox1.BorderStyle = BorderStyle.Fixed3D;

        }

        private void refreshThirdDisplay_Click ( object sender, EventArgs e ) {

            dp_BindDataSourceForThirdClassListBox ();//为第三个标签页中的左上角Listbox绑定数据源

        }

        private void radButton2_Click ( object sender, EventArgs e ) {

            dp_BindDataSourceForFirstClassListBox (); // 为第一个标签页中的左上角ListBox绑定数据源

        }
    }
}
