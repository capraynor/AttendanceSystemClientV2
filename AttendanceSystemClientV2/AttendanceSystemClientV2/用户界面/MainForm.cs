using System;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace AttendanceSystemClientV2.用户界面 {
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
            _fDataModule = new DataModule ();//datamodule 用于下载数据。
        }


        private void manualBtn_Click ( object sender, EventArgs e ) {
            new ManualRollCallForm ().ShowDialog ();
        }



        private void radButton1_Click ( object sender, EventArgs e ) {
            new ShowServerClassesForm ().ShowDialog ();
        }
    }
}
