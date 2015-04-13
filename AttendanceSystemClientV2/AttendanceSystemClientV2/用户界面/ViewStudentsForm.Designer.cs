namespace AttendanceSystemClientV2.用户界面 {
    partial class ViewStudentsForm {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.studentsGridView = new Telerik.WinControls.UI.RadGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.upBtn = new Telerik.WinControls.UI.RadButton();
            this.downBtn = new Telerik.WinControls.UI.RadButton();
            this.changeToLateBtn = new Telerik.WinControls.UI.RadButton();
            this.changeToNormalBtn = new Telerik.WinControls.UI.RadButton();
            this.changeToAskForLeaveBtn = new Telerik.WinControls.UI.RadButton();
            this.changeToLeaveEarly = new Telerik.WinControls.UI.RadButton();
            this.changeToAbsentBtn = new Telerik.WinControls.UI.RadButton();
            this.returnBtn = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsGridView.MasterTemplate)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeToLateBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeToNormalBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeToAskForLeaveBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeToLeaveEarly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeToAbsentBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.LightBlue;
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(743, 85);
            this.radPanel1.TabIndex = 6;
            this.radPanel1.Text = "考勤情况";
            this.radPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.studentsGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 489);
            this.panel1.TabIndex = 7;
            // 
            // studentsGridView
            // 
            this.studentsGridView.AutoSizeRows = true;
            this.studentsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentsGridView.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.studentsGridView.ForeColor = System.Drawing.Color.Black;
            this.studentsGridView.Location = new System.Drawing.Point(0, 0);
            // 
            // studentsGridView
            // 
            this.studentsGridView.MasterTemplate.AllowAddNewRow = false;
            this.studentsGridView.MasterTemplate.AllowColumnChooser = false;
            this.studentsGridView.MasterTemplate.AllowDeleteRow = false;
            this.studentsGridView.MasterTemplate.AllowDragToGroup = false;
            this.studentsGridView.MasterTemplate.AllowEditRow = false;
            this.studentsGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.studentsGridView.Name = "studentsGridView";
            this.studentsGridView.ReadOnly = true;
            this.studentsGridView.Size = new System.Drawing.Size(743, 489);
            this.studentsGridView.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.returnBtn);
            this.panel2.Controls.Add(this.changeToAbsentBtn);
            this.panel2.Controls.Add(this.changeToLeaveEarly);
            this.panel2.Controls.Add(this.changeToAskForLeaveBtn);
            this.panel2.Controls.Add(this.changeToNormalBtn);
            this.panel2.Controls.Add(this.changeToLateBtn);
            this.panel2.Controls.Add(this.downBtn);
            this.panel2.Controls.Add(this.upBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 574);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(743, 126);
            this.panel2.TabIndex = 8;
            // 
            // upBtn
            // 
            this.upBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.upBtn.Location = new System.Drawing.Point(37, 6);
            this.upBtn.Name = "upBtn";
            this.upBtn.Size = new System.Drawing.Size(161, 56);
            this.upBtn.TabIndex = 7;
            this.upBtn.Text = "上一个";
            // 
            // downBtn
            // 
            this.downBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.downBtn.Location = new System.Drawing.Point(37, 67);
            this.downBtn.Name = "downBtn";
            this.downBtn.Size = new System.Drawing.Size(161, 56);
            this.downBtn.TabIndex = 8;
            this.downBtn.Text = "下一个";
            // 
            // changeToLateBtn
            // 
            this.changeToLateBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.changeToLateBtn.Location = new System.Drawing.Point(204, 6);
            this.changeToLateBtn.Name = "changeToLateBtn";
            this.changeToLateBtn.Size = new System.Drawing.Size(161, 56);
            this.changeToLateBtn.TabIndex = 9;
            this.changeToLateBtn.Text = "更改为迟到";
            // 
            // changeToNormalBtn
            // 
            this.changeToNormalBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.changeToNormalBtn.Location = new System.Drawing.Point(204, 67);
            this.changeToNormalBtn.Name = "changeToNormalBtn";
            this.changeToNormalBtn.Size = new System.Drawing.Size(161, 56);
            this.changeToNormalBtn.TabIndex = 10;
            this.changeToNormalBtn.Text = "更改为正常";
            // 
            // changeToAskForLeaveBtn
            // 
            this.changeToAskForLeaveBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.changeToAskForLeaveBtn.Location = new System.Drawing.Point(371, 6);
            this.changeToAskForLeaveBtn.Name = "changeToAskForLeaveBtn";
            this.changeToAskForLeaveBtn.Size = new System.Drawing.Size(161, 56);
            this.changeToAskForLeaveBtn.TabIndex = 11;
            this.changeToAskForLeaveBtn.Text = "更改为请假";
            // 
            // changeToLeaveEarly
            // 
            this.changeToLeaveEarly.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.changeToLeaveEarly.Location = new System.Drawing.Point(371, 67);
            this.changeToLeaveEarly.Name = "changeToLeaveEarly";
            this.changeToLeaveEarly.Size = new System.Drawing.Size(161, 56);
            this.changeToLeaveEarly.TabIndex = 12;
            this.changeToLeaveEarly.Text = "更改为早退";
            // 
            // changeToAbsentBtn
            // 
            this.changeToAbsentBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.changeToAbsentBtn.Location = new System.Drawing.Point(538, 6);
            this.changeToAbsentBtn.Name = "changeToAbsentBtn";
            this.changeToAbsentBtn.Size = new System.Drawing.Size(161, 56);
            this.changeToAbsentBtn.TabIndex = 13;
            this.changeToAbsentBtn.Text = "更改为旷课";
            // 
            // returnBtn
            // 
            this.returnBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.returnBtn.Location = new System.Drawing.Point(538, 67);
            this.returnBtn.Name = "returnBtn";
            this.returnBtn.Size = new System.Drawing.Size(161, 56);
            this.returnBtn.TabIndex = 14;
            this.returnBtn.Text = "返回";
            // 
            // ViewStudentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 700);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewStudentsForm";
            this.Text = "ViewStudentsForm";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.studentsGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.upBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeToLateBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeToNormalBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeToAskForLeaveBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeToLeaveEarly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeToAbsentBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadGridView studentsGridView;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadButton upBtn;
        private Telerik.WinControls.UI.RadButton downBtn;
        private Telerik.WinControls.UI.RadButton changeToNormalBtn;
        private Telerik.WinControls.UI.RadButton changeToLateBtn;
        private Telerik.WinControls.UI.RadButton changeToAskForLeaveBtn;
        private Telerik.WinControls.UI.RadButton returnBtn;
        private Telerik.WinControls.UI.RadButton changeToAbsentBtn;
        private Telerik.WinControls.UI.RadButton changeToLeaveEarly;
    }
}