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
    public partial class ConfirmBox : Form {
        public ConfirmBox (string information) {

            InitializeComponent ();

            radPanel2.Text = information;

        }

        private void btnOk_Click ( object sender, EventArgs e ) {
            this.Close();
        }

        private void btnCancel_Click ( object sender, EventArgs e ) {
            this.Close();
        }

        public static DialogResult ShowConfirmBoxDialog ( string message ) {

            return new ConfirmBox(message).ShowDialog ();

        }
    }
}
