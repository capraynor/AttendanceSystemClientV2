namespace AttendanceSystemClientV2.UserInterface {
    partial class SetOfflinePasswdForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing ) {
            if (disposing && (components != null)) {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( ) {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbPasswd = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.confirmPasswordTbox = new System.Windows.Forms.TextBox();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.passwordTbox = new System.Windows.Forms.TextBox();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.radPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 318);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbPasswd);
            this.panel2.Controls.Add(this.lbUsername);
            this.panel2.Controls.Add(this.confirmPasswordTbox);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.passwordTbox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(546, 231);
            this.panel2.TabIndex = 11;
            // 
            // lbPasswd
            // 
            this.lbPasswd.AutoSize = true;
            this.lbPasswd.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPasswd.Location = new System.Drawing.Point(47, 97);
            this.lbPasswd.Name = "lbPasswd";
            this.lbPasswd.Size = new System.Drawing.Size(140, 31);
            this.lbPasswd.TabIndex = 15;
            this.lbPasswd.Text = "再输入一次:";
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUsername.Location = new System.Drawing.Point(62, 30);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(116, 31);
            this.lbUsername.TabIndex = 14;
            this.lbUsername.Text = "输入密码:";
            // 
            // confirmPasswordTbox
            // 
            this.confirmPasswordTbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.confirmPasswordTbox.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.confirmPasswordTbox.Location = new System.Drawing.Point(215, 94);
            this.confirmPasswordTbox.Name = "confirmPasswordTbox";
            this.confirmPasswordTbox.PasswordChar = '*';
            this.confirmPasswordTbox.Size = new System.Drawing.Size(288, 39);
            this.confirmPasswordTbox.TabIndex = 11;
            this.confirmPasswordTbox.TextChanged += new System.EventHandler(this.confirmPasswordTbox_TextChanged);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Enabled = false;
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.btnOk.Location = new System.Drawing.Point(68, 166);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(155, 54);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "确  定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(348, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(155, 54);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取  消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // passwordTbox
            // 
            this.passwordTbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordTbox.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.passwordTbox.Location = new System.Drawing.Point(215, 27);
            this.passwordTbox.Name = "passwordTbox";
            this.passwordTbox.PasswordChar = '*';
            this.passwordTbox.Size = new System.Drawing.Size(288, 39);
            this.passwordTbox.TabIndex = 10;
            this.passwordTbox.TextChanged += new System.EventHandler(this.UserIdTextBox_TextChanged);
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.LightBlue;
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(546, 85);
            this.radPanel1.TabIndex = 10;
            this.radPanel1.Text = "请设置离线密码";
            this.radPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetOfflinePasswdForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(548, 318);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SetOfflinePasswdForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetOfflinePasswdForm";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbPasswd;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.TextBox confirmPasswordTbox;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private System.Windows.Forms.TextBox passwordTbox;

    }
}