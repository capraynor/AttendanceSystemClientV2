using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceSystemClientV2.UserInterface {
    public partial class SetOfflinePasswdForm : Form {
        public SetOfflinePasswdForm ( ) {
            InitializeComponent ();
        }

        private void UserIdTextBox_TextChanged ( object sender, EventArgs e ) {

            btnOk.Enabled = ((passwordTbox.Text == confirmPasswordTbox.Text) && (!string.IsNullOrEmpty (passwordTbox.Text))); // 两个密码框相等且不为空的时候,确定按钮才可用

        }

        private void confirmPasswordTbox_TextChanged ( object sender, EventArgs e ) {

            btnOk.Enabled = ((passwordTbox.Text == confirmPasswordTbox.Text) && (!string.IsNullOrEmpty (passwordTbox.Text))); // 两个密码框相等且不为空的时候,确定按钮才可用

        }

        private void btnOk_Click ( object sender, EventArgs e ) {

            Properties.Settings.Default.OffliePassword = passwordTbox.Text;
            
            Close();
        }

        private void btnCancel_Click ( object sender, EventArgs e ) {

            Close();

        }
        
    }
}
