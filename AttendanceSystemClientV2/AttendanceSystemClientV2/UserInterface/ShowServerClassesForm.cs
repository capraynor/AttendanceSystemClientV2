using System;
using System.Windows.Forms;
using System.Threading;
namespace AttendanceSystemClientV2.UserInterface {
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

            new Thread(() => {
                MessageBox.Show(_fDataModule.Getdata().ToString());

            }).Start();

            

            _fDataModule.LogOff();

        }

        
    }
}
