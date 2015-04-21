using System;
using System.Linq;
using System.Windows.Forms;
using AttendanceSystemClientV2.Controls;
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

            var dpCourseInfoDictionary = OfflineDataControl.Dp_GetCourseInfoDictionary();

            coursesListBox.DataSource = new BindingSource(dpCourseInfoDictionary,null);

            coursesListBox.DisplayMember = "Value"; //设置显示字段

            coursesListBox.ValueMember = "Key";//设置值字段
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

            }catch (RemObjects.SDK.Exceptions.SessionNotFoundException) {

                MsgBox.ShowMsgBoxDialog("登录异常");

            }//todo:将下面的catch放出来
            catch (Exception expException) {

                MsgBox.ShowMsgBoxDialog(expException.Message+"\n" +expException.StackTrace);
            }
        }
    }
}
