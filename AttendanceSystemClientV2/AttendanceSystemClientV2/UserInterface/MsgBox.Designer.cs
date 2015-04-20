namespace AttendanceSystemClientV2.UserInterface {
    partial class MsgBox {
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
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.normalBtn = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.normalBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.LightBlue;
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(705, 85);
            this.radPanel1.TabIndex = 7;
            this.radPanel1.Text = "信息";
            this.radPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radPanel2
            // 
            this.radPanel2.BackColor = System.Drawing.Color.Azure;
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radPanel2.Location = new System.Drawing.Point(0, 85);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(705, 190);
            this.radPanel2.TabIndex = 8;
            this.radPanel2.Text = "信息";
            this.radPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // normalBtn
            // 
            this.normalBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.normalBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.normalBtn.Location = new System.Drawing.Point(243, 308);
            this.normalBtn.Name = "normalBtn";
            this.normalBtn.Size = new System.Drawing.Size(221, 66);
            this.normalBtn.TabIndex = 16;
            this.normalBtn.Text = "确    定";
            this.normalBtn.Click += new System.EventHandler(this.normalBtn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.normalBtn.GetChildAt(0))).Text = "确    定";
            ((Telerik.WinControls.UI.RadButtonElement)(this.normalBtn.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            // 
            // MsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 397);
            this.Controls.Add(this.normalBtn);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MsgBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提示";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.normalBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadButton normalBtn;
    }
}