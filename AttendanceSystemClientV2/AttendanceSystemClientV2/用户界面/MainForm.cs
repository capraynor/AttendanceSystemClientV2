using System;
using System.Windows.Forms;
using System.Linq;
using RemObjects.DataAbstract.Linq;
using Telerik.WinControls.UI;

namespace AttendanceSystemClientV2
{
    public partial class MainForm : RadForm
    {
        #region Private fields
        private readonly DataModule _fDataModule;
        #endregion
        //显示隐藏的学生列表
        //选择标签页的时候弹出toast提示
        //标签页侧边栏需要背景
        public MainForm()
        {
            InitializeComponent();

            _fDataModule = new DataModule();
        }

        private void panel1_default_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _fDataModule.getdata();
        }

        private void manualBtn_Click(object sender, EventArgs e)
        {
            new ManualRollCallForm().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ShowServerClassesForm().ShowDialog();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            new ShowServerClassesForm().ShowDialog();
        }
    }
}
