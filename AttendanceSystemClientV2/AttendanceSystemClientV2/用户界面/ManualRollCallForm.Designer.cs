namespace AttendanceSystemClientV2
{
    partial class ManualRollCallForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel5 = new System.Windows.Forms.Panel();
            this.notSignBtn = new Telerik.WinControls.UI.RadButton();
            this.absentBtn = new Telerik.WinControls.UI.RadButton();
            this.leaveEarlyBtn = new Telerik.WinControls.UI.RadButton();
            this.lateBtn = new Telerik.WinControls.UI.RadButton();
            this.absenceBtn = new Telerik.WinControls.UI.RadButton();
            this.downBtn = new Telerik.WinControls.UI.RadButton();
            this.normalBtn = new Telerik.WinControls.UI.RadButton();
            this.irregularBtn = new Telerik.WinControls.UI.RadButton();
            this.upBtn = new Telerik.WinControls.UI.RadButton();
            this.quitBtn = new Telerik.WinControls.UI.RadButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.studentGridView = new Telerik.WinControls.UI.RadGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbStudentClass = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbStudentId = new System.Windows.Forms.Label();
            this.lbStudentName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbDczt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notSignBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.absentBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leaveEarlyBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lateBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.absenceBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.normalBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.irregularBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quitBtn)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentGridView.MasterTemplate)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.LightBlue;
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1088, 85);
            this.radPanel1.TabIndex = 5;
            this.radPanel1.Text = "手动考勤";
            this.radPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1088, 665);
            this.panel1.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.chart1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(611, 389);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(475, 274);
            this.panel6.TabIndex = 2;
            // 
            // chart1
            // 
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(475, 274);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.notSignBtn);
            this.panel5.Controls.Add(this.absentBtn);
            this.panel5.Controls.Add(this.leaveEarlyBtn);
            this.panel5.Controls.Add(this.lateBtn);
            this.panel5.Controls.Add(this.absenceBtn);
            this.panel5.Controls.Add(this.downBtn);
            this.panel5.Controls.Add(this.normalBtn);
            this.panel5.Controls.Add(this.irregularBtn);
            this.panel5.Controls.Add(this.upBtn);
            this.panel5.Controls.Add(this.quitBtn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(611, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(475, 389);
            this.panel5.TabIndex = 1;
            // 
            // notSignBtn
            // 
            this.notSignBtn.Enabled = false;
            this.notSignBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.notSignBtn.Location = new System.Drawing.Point(239, 155);
            this.notSignBtn.Name = "notSignBtn";
            this.notSignBtn.Size = new System.Drawing.Size(221, 66);
            this.notSignBtn.TabIndex = 22;
            this.notSignBtn.Text = "未签到";
            // 
            // absentBtn
            // 
            this.absentBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.absentBtn.Location = new System.Drawing.Point(10, 83);
            this.absentBtn.Name = "absentBtn";
            this.absentBtn.Size = new System.Drawing.Size(221, 66);
            this.absentBtn.TabIndex = 21;
            this.absentBtn.Text = "旷课";
            // 
            // leaveEarlyBtn
            // 
            this.leaveEarlyBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.leaveEarlyBtn.Location = new System.Drawing.Point(10, 155);
            this.leaveEarlyBtn.Name = "leaveEarlyBtn";
            this.leaveEarlyBtn.Size = new System.Drawing.Size(221, 66);
            this.leaveEarlyBtn.TabIndex = 20;
            this.leaveEarlyBtn.Text = "早退";
            // 
            // lateBtn
            // 
            this.lateBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.lateBtn.Location = new System.Drawing.Point(239, 83);
            this.lateBtn.Name = "lateBtn";
            this.lateBtn.Size = new System.Drawing.Size(221, 66);
            this.lateBtn.TabIndex = 19;
            this.lateBtn.Text = "迟到";
            // 
            // absenceBtn
            // 
            this.absenceBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.absenceBtn.Location = new System.Drawing.Point(239, 11);
            this.absenceBtn.Name = "absenceBtn";
            this.absenceBtn.Size = new System.Drawing.Size(221, 66);
            this.absenceBtn.TabIndex = 18;
            this.absenceBtn.Text = "请假";
            // 
            // downBtn
            // 
            this.downBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.downBtn.Location = new System.Drawing.Point(239, 240);
            this.downBtn.Name = "downBtn";
            this.downBtn.Size = new System.Drawing.Size(221, 66);
            this.downBtn.TabIndex = 13;
            this.downBtn.Text = "下一个学生";
            // 
            // normalBtn
            // 
            this.normalBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.normalBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.normalBtn.Location = new System.Drawing.Point(10, 11);
            this.normalBtn.Name = "normalBtn";
            this.normalBtn.Size = new System.Drawing.Size(221, 66);
            this.normalBtn.TabIndex = 15;
            this.normalBtn.Text = "正常到课";
            ((Telerik.WinControls.UI.RadButtonElement)(this.normalBtn.GetChildAt(0))).Text = "正常到课";
            ((Telerik.WinControls.UI.RadButtonElement)(this.normalBtn.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            // 
            // irregularBtn
            // 
            this.irregularBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.irregularBtn.Location = new System.Drawing.Point(10, 312);
            this.irregularBtn.Name = "irregularBtn";
            this.irregularBtn.Size = new System.Drawing.Size(332, 66);
            this.irregularBtn.TabIndex = 17;
            this.irregularBtn.Text = "查看非正常到课学生";
            // 
            // upBtn
            // 
            this.upBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.upBtn.Location = new System.Drawing.Point(10, 240);
            this.upBtn.Name = "upBtn";
            this.upBtn.Size = new System.Drawing.Size(221, 66);
            this.upBtn.TabIndex = 14;
            this.upBtn.Text = "上一个学生";
            // 
            // quitBtn
            // 
            this.quitBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.quitBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.quitBtn.Location = new System.Drawing.Point(348, 312);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(112, 66);
            this.quitBtn.TabIndex = 16;
            this.quitBtn.Text = "退出";
            this.quitBtn.Click += new System.EventHandler(this.radButton5_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(611, 663);
            this.panel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.studentGridView);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 292);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(611, 371);
            this.panel4.TabIndex = 1;
            // 
            // studentGridView
            // 
            this.studentGridView.AutoSizeRows = true;
            this.studentGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentGridView.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.studentGridView.ForeColor = System.Drawing.Color.Black;
            this.studentGridView.Location = new System.Drawing.Point(0, 0);
            // 
            // studentGridView
            // 
            this.studentGridView.MasterTemplate.AllowAddNewRow = false;
            this.studentGridView.MasterTemplate.AllowColumnChooser = false;
            this.studentGridView.MasterTemplate.AllowDeleteRow = false;
            this.studentGridView.MasterTemplate.AllowDragToGroup = false;
            this.studentGridView.MasterTemplate.AllowEditRow = false;
            this.studentGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.studentGridView.Name = "studentGridView";
            this.studentGridView.ReadOnly = true;
            this.studentGridView.Size = new System.Drawing.Size(611, 371);
            this.studentGridView.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.lbStudentId);
            this.panel3.Controls.Add(this.lbStudentName);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.lbDczt);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(611, 292);
            this.panel3.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbStudentClass, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(346, 90);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(153, 70);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // lbStudentClass
            // 
            this.lbStudentClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStudentClass.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.lbStudentClass.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbStudentClass.Location = new System.Drawing.Point(3, 0);
            this.lbStudentClass.Name = "lbStudentClass";
            this.lbStudentClass.Size = new System.Drawing.Size(147, 70);
            this.lbStudentClass.TabIndex = 14;
            this.lbStudentClass.Tag = "";
            this.lbStudentClass.Text = "所在班级";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label6.Location = new System.Drawing.Point(190, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 35);
            this.label6.TabIndex = 27;
            this.label6.Text = "所在班级：";
            // 
            // lbStudentId
            // 
            this.lbStudentId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbStudentId.AutoSize = true;
            this.lbStudentId.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.lbStudentId.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbStudentId.Location = new System.Drawing.Point(346, 185);
            this.lbStudentId.Name = "lbStudentId";
            this.lbStudentId.Size = new System.Drawing.Size(123, 35);
            this.lbStudentId.TabIndex = 29;
            this.lbStudentId.Text = "测试测试";
            // 
            // lbStudentName
            // 
            this.lbStudentName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbStudentName.AutoSize = true;
            this.lbStudentName.Font = new System.Drawing.Font("微软雅黑", 39.75F, System.Drawing.FontStyle.Bold);
            this.lbStudentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lbStudentName.Location = new System.Drawing.Point(184, 11);
            this.lbStudentName.Name = "lbStudentName";
            this.lbStudentName.Size = new System.Drawing.Size(136, 70);
            this.lbStudentName.TabIndex = 26;
            this.lbStudentName.Text = "姓名";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label10.Location = new System.Drawing.Point(190, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 35);
            this.label10.TabIndex = 31;
            this.label10.Text = "到课状态：";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label7.Location = new System.Drawing.Point(190, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 35);
            this.label7.TabIndex = 28;
            this.label7.Text = "学生学号：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(18, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 203);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // lbDczt
            // 
            this.lbDczt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDczt.AutoSize = true;
            this.lbDczt.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.lbDczt.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbDczt.Location = new System.Drawing.Point(346, 228);
            this.lbDczt.Name = "lbDczt";
            this.lbDczt.Size = new System.Drawing.Size(177, 35);
            this.lbDczt.TabIndex = 32;
            this.lbDczt.Text = "测试测试测试";
            // 
            // ManualRollCallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 750);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManualRollCallForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "手动签到";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.notSignBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.absentBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leaveEarlyBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lateBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.absenceBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.normalBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.irregularBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quitBtn)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.studentGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentGridView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbStudentClass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbStudentId;
        private System.Windows.Forms.Label lbStudentName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbDczt;
        private Telerik.WinControls.UI.RadButton notSignBtn;
        private Telerik.WinControls.UI.RadButton absentBtn;
        private Telerik.WinControls.UI.RadButton leaveEarlyBtn;
        private Telerik.WinControls.UI.RadButton lateBtn;
        private Telerik.WinControls.UI.RadButton absenceBtn;
        private Telerik.WinControls.UI.RadButton downBtn;
        private Telerik.WinControls.UI.RadButton normalBtn;
        private Telerik.WinControls.UI.RadButton irregularBtn;
        private Telerik.WinControls.UI.RadButton upBtn;
        private Telerik.WinControls.UI.RadButton quitBtn;
        private Telerik.WinControls.UI.RadGridView studentGridView;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;

    }
}