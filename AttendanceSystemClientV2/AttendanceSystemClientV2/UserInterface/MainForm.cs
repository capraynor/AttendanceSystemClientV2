using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using AttendanceSystemClientV2.Controls;
using AttendanceSystemClientV2.Models;
using AttendanceSystemClientV2.PC;
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
        public MainForm ( ) {
            InitializeComponent ();
            _rollCalling = false;//标记是否正在进行考勤工作

            _fDataModule = new DataModule ();//datamodule 用于查看数据(好像没什么用耶)。

            dp_BindDataSourceForFirstClassListBox(); // 为第一个标签页中的左上角ListBox绑定数据源

            dp_BindDataSourceForThirdClassListBox();//为第三个标签页中的左上角Listbox绑定数据源
        }


        private void manualBtn_Click ( object sender, EventArgs e ) {
            new ManualRollCallForm ().ShowDialog ();
        }



        private void radButton1_Click ( object sender, EventArgs e ) {

            var resault = new LogOnForm().ShowDialog();//显示下载课程窗口

            if (resault == DialogResult.Cancel)
                return;

            try {

                new ShowServerClassesForm().ShowDialog();

            }
            catch (RemObjects.SDK.Exceptions.SessionNotFoundException) {

                MsgBox.ShowMsgBoxDialog("登录异常");

            } //todo:将下面的catch放出来
            catch (Exception expException) {

                MsgBox.ShowMsgBoxDialog(expException.Message + "\n" + expException.StackTrace);
            }
            finally {
                dp_RefreshMainForm();

                // 不管怎样 点击完下载课程之后一定要刷新一下显示
            }
        }

        private void coursesListBox_SelectedIndexChanged ( object sender, EventArgs e ) {

            var selectedproperty = (KeyValuePair<long, string>)coursesListBox.SelectedItem; // 获取已经选择的项目

            if (selectedproperty.Key == -1) {
                return;
            }

            var courseInfo = new CourseInfo(selectedproperty.Key);

            dp_RefreshFirstDetails(courseInfo);

            dp_BindDataSourceForFirstClassStatusGridView(selectedproperty.Key);

        }

        /// <summary>
        /// 刷新第一个页面的课程详情
        /// </summary>
        /// <param name="courseInfo">描述一门课程的类</param>
        private void dp_RefreshFirstDetails(CourseInfo courseInfo) {
            
            courseNameLbl1.Text = courseInfo.CourseName; // 课程名称

            teacherNameLbl1.Text = courseInfo.TeacherName; // 教师姓名

            lastTimeSubmit1.Text = courseInfo.LastModified; // 最后一次更改时间


        }

        /// <summary>
        /// 为第一个标签页的左上角ListBox绑定数据源 该Listbox会显示存在于该平板中的所有课程
        /// 该函数会直接调用Controls中的函数,获取数据源.
        /// 这样可以直接用于刷新界面显示之类的操作.
        /// </summary>
        private void dp_BindDataSourceForFirstClassListBox() {

            var dpCourseInfoDictionary = OfflineDataControl.GetCourseInfoDictionary ();

            coursesListBox.DataSource = new BindingSource (dpCourseInfoDictionary, null);

            coursesListBox.DisplayMember = "Value"; //设置显示字段

            coursesListBox.ValueMember = "Key";//设置值字段

        }

        
        /// <summary>
        /// 刷新第一个标签页中Gridview的显示状态.  
        /// </summary>
        /// <param name="skno">上课编号</param>
        private void dp_BindDataSourceForFirstClassStatusGridView(long skno) {

            var classInfoDatatable = OfflineDataControl.GetClassInfoTable(skno);

            classInfoDatatable.DefaultView.Sort = "上课日期 DESC";

            classInfoGview1.DataSource = classInfoDatatable;

        }

        /// <summary>
        /// 绑定第三个标签页左上角的Listbox的数据源.
        /// 该函数可以用于刷新第三个标签页的显示.
        /// </summary>
        private void dp_BindDataSourceForThirdClassListBox() {

            var dpCourseInfoDictionary = OfflineDataControl.GetCourseInfoDictionary ();

            courseListLbox3.DataSource = new BindingSource (dpCourseInfoDictionary, null);

            courseListLbox3.DisplayMember = "Value"; //设置显示字段

            courseListLbox3.ValueMember = "Key";//设置值字段

        }

        private void dp_RefreshThirdDetails(CourseInfo courseInfo) {

            courseNameLbl3.Text = courseInfo.CourseName;

            teacherNameLbl3.Text = courseInfo.TeacherName;

            lastTimeSubmit3.Text = courseInfo.LastModified;

        }

        private void courseListLbox3_SelectedIndexChanged ( object sender, EventArgs e ) {

            var selectedproperty = (KeyValuePair<long, string>)courseListLbox3.SelectedItem; // 获取已经选择的项目

            if (selectedproperty.Key == -1) { //判断是否有数据
                return;
            }

            var courseInfo = new CourseInfo (selectedproperty.Key); // 

            dp_RefreshThirdDetails (courseInfo); // 刷新左下方的显示
            
            dp_BindDataSourceForThirdClassStatusGridView(selectedproperty.Key); // 设置第三个标签页右侧的gridview数据源
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

            var classInfoDatatable = OfflineDataControl.GetClassInfoTable (skno); // 获取ClassInfo表

            classInfoDatatable.DefaultView.Sort = "上课日期 DESC"; // 按照日期 降序排序

            rollCallingDetailGview.DataSource = classInfoDatatable; // 绑定刚才得到的datatable

        }

        private void viewRollCallDetailsBtn_Click ( object sender, EventArgs e ) {
            
            
            
            var selectedproperty = (KeyValuePair<long, string>)courseListLbox3.SelectedItem; // 获取已经选择的项目

            if (selectedproperty.Key == -1) { //判断是否有数据
                return;
            }

            var rollCallingDetailRow = this.rollCallingDetailGview.SelectedRows[0];

            var kkno = selectedproperty.Key;

            var skno = Convert.ToInt64(rollCallingDetailRow.Cells["上课编号"].Value);

            //验证离线密码
            var offlineVerifyResault = BriefcaseControl.VerifyOfflinePasswd(kkno);

            if (!offlineVerifyResault) {
                
                MsgBox.ShowMsgBoxDialog("验证口令失败");

                return;
            } 
            // 如果验证不通过 则提示密码错误 并返回 什么都不做.

            //显示 View StudentsForm 窗口.
            var viewStudentForm = new ViewStudentsForm(kkno, skno);

            if (!viewStudentForm.IsDisposed) { // 判断该窗口是否已经被释放

                viewStudentForm.ShowDialog();

            }
        }

        /// <summary>
        /// 刷新界面课程列表的显示
        /// </summary>
        private void dp_RefreshMainForm() {

            dp_BindDataSourceForFirstClassListBox (); // 为第一个标签页中的左上角ListBox绑定数据源

            dp_BindDataSourceForThirdClassListBox ();//为第三个标签页中的左上角Listbox绑定数据源

        }

        /// <summary>
        /// 重置界面的显示(主要是点名界面)
        /// </summary>
        private void dp_ResetMainForm() {
            


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
                MsgBox.ShowMsgBoxDialog("没有数据");
            }

            var rollCallingDetailRow = this.rollCallingDetailGview.SelectedRows[0];

            var kkno = selectedproperty.Key;

            var skno = Convert.ToInt64 (rollCallingDetailRow.Cells["上课编号"].Value);

            var skdate = Convert.ToString( (rollCallingDetailRow.Cells["上课日期"].Value));

            var kkname = Convert.ToString(selectedproperty.Value);
            //验证离线密码
            var offlineVerifyResault = BriefcaseControl.VerifyOfflinePasswd (kkno);

            if (!offlineVerifyResault) {

                MsgBox.ShowMsgBoxDialog ("验证口令失败");

                return;
            }
            // 如果验证不通过 则提示密码错误 并返回 什么都不做.
            //todo:上传数据的业务逻辑在这里编写即可 需要从界面里带出去的东西:1.上课编号2.课程编号 3.预计上课时间

            var displayString = DataUploadControl.GenerateConfirmString(kkno, kkname, skno, skdate);

            var confirmResault = ConfirmBox.ShowConfirmBoxDialog("请确认要上传的课程信息:\n"+displayString);

            if (confirmResault == DialogResult.Cancel) return;//如果点击了取消 就取消上传课程.

            //todo:在这里写上传数据的业务逻辑

           DataUploadControl.UploadOneClass(kkno , skno);

           MsgBox.ShowMsgBoxDialog(displayString+"\n\n上传完成");
        }
    }
}
