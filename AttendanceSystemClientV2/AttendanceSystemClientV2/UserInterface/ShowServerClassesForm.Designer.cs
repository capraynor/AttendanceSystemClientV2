﻿namespace AttendanceSystemClientV2.UserInterface
{
    partial class ShowServerClassesForm
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
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.undoDownloading = new Telerik.WinControls.UI.RadButton();
            this.downloadCourseBtn = new Telerik.WinControls.UI.RadButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rollCallGridView = new Telerik.WinControls.UI.RadGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.studentTotalLbl = new System.Windows.Forms.Label();
            this.teacherNameLbl = new System.Windows.Forms.Label();
            this.courseNameLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.radPanel4 = new Telerik.WinControls.UI.RadPanel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.curriculumListLbox = new System.Windows.Forms.ListBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.undoDownloading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadCourseBtn)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rollCallGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rollCallGridView.MasterTemplate)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.LightBlue;
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Font = new System.Drawing.Font("Microsoft YaHei", 30F);
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1070, 106);
            this.radPanel1.TabIndex = 6;
            this.radPanel1.Text = "请选择要下载的课程";
            this.radPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.radPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1072, 108);
            this.panel2.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1072, 624);
            this.panel1.TabIndex = 9;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.radButton1);
            this.panel7.Controls.Add(this.undoDownloading);
            this.panel7.Controls.Add(this.downloadCourseBtn);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(482, 523);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(588, 99);
            this.panel7.TabIndex = 2;
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.radButton1.Location = new System.Drawing.Point(383, 25);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(161, 61);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "返     回";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // undoDownloading
            // 
            this.undoDownloading.Enabled = false;
            this.undoDownloading.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.undoDownloading.Location = new System.Drawing.Point(216, 25);
            this.undoDownloading.Name = "undoDownloading";
            this.undoDownloading.Size = new System.Drawing.Size(161, 61);
            this.undoDownloading.TabIndex = 1;
            this.undoDownloading.Text = "撤销下载";
            // 
            // downloadCourseBtn
            // 
            this.downloadCourseBtn.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold);
            this.downloadCourseBtn.Location = new System.Drawing.Point(5, 25);
            this.downloadCourseBtn.Name = "downloadCourseBtn";
            this.downloadCourseBtn.Size = new System.Drawing.Size(205, 61);
            this.downloadCourseBtn.TabIndex = 0;
            this.downloadCourseBtn.Text = "下载选定课程";
            this.downloadCourseBtn.Click += new System.EventHandler(this.downloadCourseBtn_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.rollCallGridView);
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(482, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(588, 523);
            this.panel4.TabIndex = 1;
            // 
            // rollCallGridView
            // 
            this.rollCallGridView.AutoSizeRows = true;
            this.rollCallGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rollCallGridView.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rollCallGridView.Location = new System.Drawing.Point(0, 55);
            // 
            // rollCallGridView
            // 
            this.rollCallGridView.MasterTemplate.AllowAddNewRow = false;
            this.rollCallGridView.MasterTemplate.AllowColumnReorder = false;
            this.rollCallGridView.MasterTemplate.AllowDragToGroup = false;
            this.rollCallGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rollCallGridView.Name = "rollCallGridView";
            this.rollCallGridView.ReadOnly = true;
            this.rollCallGridView.Size = new System.Drawing.Size(586, 466);
            this.rollCallGridView.TabIndex = 0;
            this.rollCallGridView.Text = "radGridView1";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.radPanel3);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(586, 55);
            this.panel8.TabIndex = 2;
            // 
            // radPanel3
            // 
            this.radPanel3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.radPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel3.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F);
            this.radPanel3.Location = new System.Drawing.Point(0, 0);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(586, 55);
            this.radPanel3.TabIndex = 1;
            this.radPanel3.Text = "考勤情况（已经提交的数据，仅供浏览）";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(482, 622);
            this.panel3.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel11);
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 55);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(482, 567);
            this.panel6.TabIndex = 2;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Controls.Add(this.panel13);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(0, 257);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(482, 310);
            this.panel11.TabIndex = 2;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel9);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 66);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(482, 244);
            this.panel12.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.studentTotalLbl);
            this.panel9.Controls.Add(this.teacherNameLbl);
            this.panel9.Controls.Add(this.courseNameLbl);
            this.panel9.Controls.Add(this.label4);
            this.panel9.Controls.Add(this.label2);
            this.panel9.Controls.Add(this.label1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(482, 244);
            this.panel9.TabIndex = 3;
            // 
            // studentTotalLbl
            // 
            this.studentTotalLbl.AutoSize = true;
            this.studentTotalLbl.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.studentTotalLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.studentTotalLbl.Location = new System.Drawing.Point(135, 176);
            this.studentTotalLbl.Name = "studentTotalLbl";
            this.studentTotalLbl.Size = new System.Drawing.Size(53, 28);
            this.studentTotalLbl.TabIndex = 6;
            this.studentTotalLbl.Text = "N/A";
            // 
            // teacherNameLbl
            // 
            this.teacherNameLbl.AutoSize = true;
            this.teacherNameLbl.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.teacherNameLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.teacherNameLbl.Location = new System.Drawing.Point(135, 103);
            this.teacherNameLbl.Name = "teacherNameLbl";
            this.teacherNameLbl.Size = new System.Drawing.Size(53, 28);
            this.teacherNameLbl.TabIndex = 5;
            this.teacherNameLbl.Text = "N/A";
            // 
            // courseNameLbl
            // 
            this.courseNameLbl.AutoSize = true;
            this.courseNameLbl.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.courseNameLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.courseNameLbl.Location = new System.Drawing.Point(135, 35);
            this.courseNameLbl.Name = "courseNameLbl";
            this.courseNameLbl.Size = new System.Drawing.Size(53, 28);
            this.courseNameLbl.TabIndex = 4;
            this.courseNameLbl.Text = "N/A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(14, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "授课教师：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(14, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "选学人数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "课程名称：";
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.radPanel4);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(482, 66);
            this.panel13.TabIndex = 2;
            // 
            // radPanel4
            // 
            this.radPanel4.BackColor = System.Drawing.Color.PaleTurquoise;
            this.radPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel4.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F);
            this.radPanel4.Location = new System.Drawing.Point(0, 0);
            this.radPanel4.Name = "radPanel4";
            this.radPanel4.Size = new System.Drawing.Size(482, 66);
            this.radPanel4.TabIndex = 1;
            this.radPanel4.Text = "课程详情";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.curriculumListLbox);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(482, 257);
            this.panel10.TabIndex = 1;
            // 
            // curriculumListLbox
            // 
            this.curriculumListLbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.curriculumListLbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.curriculumListLbox.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F);
            this.curriculumListLbox.FormattingEnabled = true;
            this.curriculumListLbox.ItemHeight = 38;
            this.curriculumListLbox.Items.AddRange(new object[] {
            "2012级软件1班操作系统原理"});
            this.curriculumListLbox.Location = new System.Drawing.Point(0, 0);
            this.curriculumListLbox.Name = "curriculumListLbox";
            this.curriculumListLbox.Size = new System.Drawing.Size(482, 257);
            this.curriculumListLbox.TabIndex = 0;
            this.curriculumListLbox.SelectedIndexChanged += new System.EventHandler(this.curriculumListLbox_SelectedIndexChanged);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.radPanel2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(482, 55);
            this.panel5.TabIndex = 1;
            // 
            // radPanel2
            // 
            this.radPanel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F);
            this.radPanel2.Location = new System.Drawing.Point(0, 0);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(480, 53);
            this.radPanel2.TabIndex = 0;
            this.radPanel2.Text = "课程列表";
            // 
            // ShowServerClassesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 732);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowServerClassesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowServerClassesForm";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.undoDownloading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadCourseBtn)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rollCallGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rollCallGridView)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox curriculumListLbox;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private Telerik.WinControls.UI.RadPanel radPanel4;
        private System.Windows.Forms.Panel panel10;
        private Telerik.WinControls.UI.RadGridView rollCallGridView;
        private Telerik.WinControls.UI.RadButton undoDownloading;
        private Telerik.WinControls.UI.RadButton downloadCourseBtn;
        private System.Windows.Forms.Label studentTotalLbl;
        private System.Windows.Forms.Label teacherNameLbl;
        private System.Windows.Forms.Label courseNameLbl;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}