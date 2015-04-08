using System;
using System.Windows.Forms;

namespace AttendanceSystemClientV2
{
    public partial class LogOnForm : Form
    {
        #region Constructor
        public LogOnForm()
        {
            this.InitializeComponent();

            this.UserId = Properties.Settings.Default.UserId;
            this.Password = Properties.Settings.Default.Password;

            this.DoStorePassword = Properties.Settings.Default.StorePassword;
        }
        #endregion

        #region Properties
        public String UserId
        {
            get
            {
                return this.UserIdTextBox.Text;
            }
            set
            {
                this.UserIdTextBox.Text = value;
            }
        }

        public String Password
        {
            get
            {
                return this.PasswordTextBox.Text;
            }
            set
            {
                this.PasswordTextBox.Text = value;
            }
        }

        public Boolean DoStorePassword
        {
            get
            {
                return this.StorePasswordCheckBox.Checked;
            }
            set
            {
                this.StorePasswordCheckBox.Checked = value;
            }
        }
        #endregion

        #region Control events
        private void ValidateInput(object sender, EventArgs e)
        {
            this.btnOk.Enabled = !String.IsNullOrEmpty(this.UserId);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.ValidateInput(sender, e);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {//ok按钮做的工作
            Properties.Settings.Default.UserId = this.UserId;
            Properties.Settings.Default.Password = this.DoStorePassword ? this.Password : String.Empty;
            Properties.Settings.Default.StorePassword = this.DoStorePassword;
            Properties.Settings.Default.Save();
            
        }
        #endregion





    }
}
