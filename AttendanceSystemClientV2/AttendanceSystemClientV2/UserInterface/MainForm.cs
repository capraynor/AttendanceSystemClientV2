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

                new ShowServerClassesForm().Show();

            }
            catch (RemObjects.SDK.Exceptions.SessionNotFoundException) {

                MsgBox.ShowMsgBoxDialog("登录异常");

            } //todo:将下面的catch放出来
            catch (Exception expException) {

                MsgBox.ShowMsgBoxDialog(expException.Message + "\n" + expException.StackTrace);
            }
            finally {
                dp_BindDataSourceForFirstClassListBox(); 
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
            
            courseNameLbl1.Text = courseInfo.CourseName;

            teacherNameLbl1.Text = courseInfo.TeacherName;

            lastTimeSubmit1.Text = courseInfo.LastModified;


        }

        /// <summary>
        /// 为第一个标签页的左上角ListBox绑定数据源 该Listbox会显示存在于该平板中的所有课程
        /// 该函数会直接调用Controls中的函数,获取数据源.
        /// 这样可以直接用于刷新界面显示之类的操作.
        /// </summary>
        private void dp_BindDataSourceForFirstClassListBox() {

            var dpCourseInfoDictionary = OfflineDataControl.Dp_GetCourseInfoDictionary ();

            coursesListBox.DataSource = new BindingSource (dpCourseInfoDictionary, null);

            coursesListBox.DisplayMember = "Value"; //设置显示字段

            coursesListBox.ValueMember = "Key";//设置值字段

        }

        /// <summary>
        /// 刷新第一个标签页中Gridview的显示状态.  
        /// 该Gridview显示
        /// </summary>
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

            var dpCourseInfoDictionary = OfflineDataControl.Dp_GetCourseInfoDictionary ();

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

            var courseInfo = new CourseInfo (selectedproperty.Key);

            dp_RefreshThirdDetails (courseInfo);
        }

        private void showDataSubmissionDetailBtn_Click ( object sender, EventArgs e ) {

            dataManagementOperationButtonsPanel.Enabled = (!dataManagementOperationButtonsPanel.Enabled);

            showDataSubmissionDetailBtnPanel.Visible = (!showDataSubmissionDetailBtnPanel.Visible);

        }
    }
}
