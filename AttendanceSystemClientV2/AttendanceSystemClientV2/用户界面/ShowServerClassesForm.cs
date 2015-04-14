using System;
using System.Windows.Forms;

namespace AttendanceSystemClientV2.用户界面 {
    public partial class ShowServerClassesForm : Form {
        private DataModule _fDataModule;
        public ShowServerClassesForm ( ) {
            InitializeComponent ();
            _fDataModule = new DataModule();
        }

        private void downloadCourseBtn_Click ( object sender, EventArgs e ) {

            var lonOnForm = new LogOnForm();

            lonOnForm.ShowDialog ();

            if (lonOnForm.DialogResult == DialogResult.Cancel)
                return;

            _fDataModule.Getdata();

            MessageBox.Show(_fDataModule.IsLoggedOn.ToString());

            _fDataModule.LogOff();

            MessageBox.Show(_fDataModule.IsLoggedOn.ToString());

            new LogOnForm ().ShowDialog ();

            _fDataModule.Getdata ();

        }
    }
}
