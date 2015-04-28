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

    /// <summary>
    ///dialogresault 如果为yes 则密码已经被验证
    ///如果为no,则说明输入的密码错误
    ///构造函数需要传入待验证密码.
    /// </summary>
    public partial class VerifyOfflinePasswordForm : Form {

        private readonly string _passwd;

        private string PasswdInput {
            
            get { return passwdTbox.Text; }

        }

        public VerifyOfflinePasswordForm ( string passwd ) {
            InitializeComponent ();

            _passwd = passwd;
        }

        private void btnCancel_Click ( object sender, EventArgs e ) {

        }

        private void btnOk_Click ( object sender, EventArgs e ) {

            if (PasswdInput == _passwd) {

                DialogResult = DialogResult.Yes; // 设置Dialogresault为yes

                return; // 这里应该要加入一个return  没有试验过是否必须这样写.

            }

            DialogResult = DialogResult.No;//设置Dialogresault为No
            //如果点击取消, dialogresault就为Cancel
        }
    }
}
