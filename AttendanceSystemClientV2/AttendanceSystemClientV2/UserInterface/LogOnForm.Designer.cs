namespace AttendanceSystemClientV2.UserInterface
{
    partial class LogOnForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UserIdTextBox = new System.Windows.Forms.TextBox();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.StorePasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbPasswd = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbMsg = new System.Windows.Forms.Label();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            this.SuspendLayout();
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordTextBox.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.PasswordTextBox.Location = new System.Drawing.Point(174, 171);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(288, 39);
            this.PasswordTextBox.TabIndex = 3;
            this.PasswordTextBox.Click += new System.EventHandler(this.PasswordTextBox_Click);
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.ValidateInput);
            // 
            // UserIdTextBox
            // 
            this.UserIdTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserIdTextBox.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.UserIdTextBox.Location = new System.Drawing.Point(174, 107);
            this.UserIdTextBox.Name = "UserIdTextBox";
            this.UserIdTextBox.Size = new System.Drawing.Size(288, 39);
            this.UserIdTextBox.TabIndex = 1;
            this.UserIdTextBox.Click += new System.EventHandler(this.UserIdTextBox_Click);
            this.UserIdTextBox.TextChanged += new System.EventHandler(this.ValidateInput);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(306, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(155, 54);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取  消";
            // 
            // StorePasswordCheckBox
            // 
            this.StorePasswordCheckBox.AutoSize = true;
            this.StorePasswordCheckBox.Location = new System.Drawing.Point(9, 280);
            this.StorePasswordCheckBox.Name = "StorePasswordCheckBox";
            this.StorePasswordCheckBox.Size = new System.Drawing.Size(102, 16);
            this.StorePasswordCheckBox.TabIndex = 4;
            this.StorePasswordCheckBox.Text = "Save password";
            this.StorePasswordCheckBox.UseVisualStyleBackColor = true;
            this.StorePasswordCheckBox.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbPasswd);
            this.panel1.Controls.Add(this.lbUsername);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.PasswordTextBox);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.StorePasswordCheckBox);
            this.panel1.Controls.Add(this.UserIdTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 309);
            this.panel1.TabIndex = 7;
            // 
            // lbPasswd
            // 
            this.lbPasswd.AutoSize = true;
            this.lbPasswd.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPasswd.Location = new System.Drawing.Point(50, 172);
            this.lbPasswd.Name = "lbPasswd";
            this.lbPasswd.Size = new System.Drawing.Size(93, 31);
            this.lbPasswd.TabIndex = 9;
            this.lbPasswd.Text = "密 码：";
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUsername.Location = new System.Drawing.Point(50, 108);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(110, 31);
            this.lbUsername.TabIndex = 8;
            this.lbUsername.Text = "用户名：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbMsg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(486, 86);
            this.panel2.TabIndex = 7;
            // 
            // lbMsg
            // 
            this.lbMsg.BackColor = System.Drawing.Color.LightBlue;
            this.lbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMsg.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.lbMsg.Location = new System.Drawing.Point(0, 0);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(486, 86);
            this.lbMsg.TabIndex = 1;
            this.lbMsg.Text = "登录服务器";
            this.lbMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.btnOk.Location = new System.Drawing.Point(131, 230);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(155, 54);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "确  定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // LogOnForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(488, 309);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LogOnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录服务器";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox UserIdTextBox;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private System.Windows.Forms.CheckBox StorePasswordCheckBox;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton btnOk;
        private System.Windows.Forms.Label lbPasswd;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbMsg;
    }
}