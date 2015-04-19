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
    public partial class MsgBox : Form {
        private MsgBox ( string message ) {
            
            InitializeComponent ();

            radPanel2.Text = message;

        }

        /// <summary>
        /// 显示窗口
        /// </summary>
        /// <param name="message">要显示的信息</param>
        public static void ShowMsgBoxDialog(string message) {

            new MsgBox(message).ShowDialog();

        }

        private void normalBtn_Click ( object sender, EventArgs e ) {
            Close();
        }
    }
}
