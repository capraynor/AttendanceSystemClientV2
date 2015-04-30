namespace AttendanceSystemClientV2.UserInterface {
    partial class SetTimeForm {
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
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.actualCourseTimePicker = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radDateTimePicker2 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.addMonthBtn = new Telerik.WinControls.UI.RadButton();
            this.minusMonthBtn = new Telerik.WinControls.UI.RadButton();
            this.addDateBtn = new Telerik.WinControls.UI.RadButton();
            this.minusDateBtn = new Telerik.WinControls.UI.RadButton();
            this.minusMinuteBtn = new Telerik.WinControls.UI.RadButton();
            this.minusHourBtn = new Telerik.WinControls.UI.RadButton();
            this.addMinuteBtn = new Telerik.WinControls.UI.RadButton();
            this.addHourBtn = new Telerik.WinControls.UI.RadButton();
            this.addYearBtn = new Telerik.WinControls.UI.RadButton();
            this.minusYearBtn = new Telerik.WinControls.UI.RadButton();
            this.OkBtn = new Telerik.WinControls.UI.RadButton();
            this.CancelBtn = new Telerik.WinControls.UI.RadButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actualCourseTimePicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDateTimePicker2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addMonthBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minusMonthBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addDateBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minusDateBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minusMinuteBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minusHourBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addMinuteBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addHourBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addYearBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minusYearBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancelBtn)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.LightBlue;
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(836, 85);
            this.radPanel1.TabIndex = 8;
            this.radPanel1.Text = "请指定上课时间";
            this.radPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.label3.Location = new System.Drawing.Point(11, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 52);
            this.label3.TabIndex = 28;
            this.label3.Text = "实际授课时间";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.label1.Location = new System.Drawing.Point(17, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 52);
            this.label1.TabIndex = 27;
            this.label1.Text = "计划授课时间";
            // 
            // actualCourseTimePicker
            // 
            this.actualCourseTimePicker.CalendarSize = new System.Drawing.Size(300, 300);
            this.actualCourseTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            this.actualCourseTimePicker.Font = new System.Drawing.Font("宋体", 15F);
            this.actualCourseTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.actualCourseTimePicker.Location = new System.Drawing.Point(287, 212);
            this.actualCourseTimePicker.Name = "actualCourseTimePicker";
            this.actualCourseTimePicker.ShowUpDown = true;
            this.actualCourseTimePicker.Size = new System.Drawing.Size(477, 72);
            this.actualCourseTimePicker.TabIndex = 25;
            this.actualCourseTimePicker.TabStop = false;
            this.actualCourseTimePicker.Text = "2014-09-07 13:53";
            this.actualCourseTimePicker.ThemeName = "TelerikMetroTouch";
            this.actualCourseTimePicker.Value = new System.DateTime(2014, 9, 7, 13, 53, 30, 7);
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.actualCourseTimePicker.GetChildAt(0))).CalendarSize = new System.Drawing.Size(300, 300);
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.actualCourseTimePicker.GetChildAt(0))).Font = new System.Drawing.Font("微软雅黑", 35F);
            // 
            // radDateTimePicker2
            // 
            this.radDateTimePicker2.CalendarSize = new System.Drawing.Size(300, 300);
            this.radDateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm";
            this.radDateTimePicker2.Enabled = false;
            this.radDateTimePicker2.Font = new System.Drawing.Font("宋体", 15F);
            this.radDateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.radDateTimePicker2.Location = new System.Drawing.Point(287, 41);
            this.radDateTimePicker2.Name = "radDateTimePicker2";
            this.radDateTimePicker2.ShowUpDown = true;
            this.radDateTimePicker2.Size = new System.Drawing.Size(477, 72);
            this.radDateTimePicker2.TabIndex = 26;
            this.radDateTimePicker2.TabStop = false;
            this.radDateTimePicker2.Text = "2014-09-07 13:53";
            this.radDateTimePicker2.ThemeName = "TelerikMetroTouch";
            this.radDateTimePicker2.Value = new System.DateTime(2014, 9, 7, 13, 53, 30, 7);
            this.radDateTimePicker2.Click += new System.EventHandler(this.radDateTimePicker2_Click);
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.radDateTimePicker2.GetChildAt(0))).CalendarSize = new System.Drawing.Size(300, 300);
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.radDateTimePicker2.GetChildAt(0))).Font = new System.Drawing.Font("微软雅黑", 35F);
            // 
            // addMonthBtn
            // 
            this.addMonthBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addMonthBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.addMonthBtn.Location = new System.Drawing.Point(418, 140);
            this.addMonthBtn.Name = "addMonthBtn";
            this.addMonthBtn.Size = new System.Drawing.Size(61, 66);
            this.addMonthBtn.TabIndex = 29;
            this.addMonthBtn.Text = "+";
            this.addMonthBtn.Click += new System.EventHandler(this.addMonthBtn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.addMonthBtn.GetChildAt(0))).Text = "+";
            ((Telerik.WinControls.UI.RadButtonElement)(this.addMonthBtn.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            // 
            // minusMonthBtn
            // 
            this.minusMonthBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.minusMonthBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.minusMonthBtn.Location = new System.Drawing.Point(418, 290);
            this.minusMonthBtn.Name = "minusMonthBtn";
            this.minusMonthBtn.Size = new System.Drawing.Size(61, 66);
            this.minusMonthBtn.TabIndex = 30;
            this.minusMonthBtn.Text = "-";
            this.minusMonthBtn.Click += new System.EventHandler(this.minusMonthBtn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.minusMonthBtn.GetChildAt(0))).Text = "-";
            ((Telerik.WinControls.UI.RadButtonElement)(this.minusMonthBtn.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            // 
            // addDateBtn
            // 
            this.addDateBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addDateBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.addDateBtn.Location = new System.Drawing.Point(485, 140);
            this.addDateBtn.Name = "addDateBtn";
            this.addDateBtn.Size = new System.Drawing.Size(61, 66);
            this.addDateBtn.TabIndex = 31;
            this.addDateBtn.Text = "+";
            this.addDateBtn.Click += new System.EventHandler(this.addDateBtn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.addDateBtn.GetChildAt(0))).Text = "+";
            ((Telerik.WinControls.UI.RadButtonElement)(this.addDateBtn.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            // 
            // minusDateBtn
            // 
            this.minusDateBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.minusDateBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.minusDateBtn.Location = new System.Drawing.Point(485, 290);
            this.minusDateBtn.Name = "minusDateBtn";
            this.minusDateBtn.Size = new System.Drawing.Size(61, 66);
            this.minusDateBtn.TabIndex = 32;
            this.minusDateBtn.Text = "-";
            this.minusDateBtn.Click += new System.EventHandler(this.minusDateBtn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.minusDateBtn.GetChildAt(0))).Text = "-";
            ((Telerik.WinControls.UI.RadButtonElement)(this.minusDateBtn.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            // 
            // minusMinuteBtn
            // 
            this.minusMinuteBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.minusMinuteBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.minusMinuteBtn.Location = new System.Drawing.Point(636, 290);
            this.minusMinuteBtn.Name = "minusMinuteBtn";
            this.minusMinuteBtn.Size = new System.Drawing.Size(61, 66);
            this.minusMinuteBtn.TabIndex = 34;
            this.minusMinuteBtn.Text = "-";
            this.minusMinuteBtn.Click += new System.EventHandler(this.minusMinuteBtn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.minusMinuteBtn.GetChildAt(0))).Text = "-";
            ((Telerik.WinControls.UI.RadButtonElement)(this.minusMinuteBtn.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            // 
            // minusHourBtn
            // 
            this.minusHourBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.minusHourBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.minusHourBtn.Location = new System.Drawing.Point(569, 290);
            this.minusHourBtn.Name = "minusHourBtn";
            this.minusHourBtn.Size = new System.Drawing.Size(61, 66);
            this.minusHourBtn.TabIndex = 33;
            this.minusHourBtn.Text = "-";
            this.minusHourBtn.Click += new System.EventHandler(this.minusHourBtn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.minusHourBtn.GetChildAt(0))).Text = "-";
            ((Telerik.WinControls.UI.RadButtonElement)(this.minusHourBtn.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            // 
            // addMinuteBtn
            // 
            this.addMinuteBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addMinuteBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.addMinuteBtn.Location = new System.Drawing.Point(636, 140);
            this.addMinuteBtn.Name = "addMinuteBtn";
            this.addMinuteBtn.Size = new System.Drawing.Size(61, 66);
            this.addMinuteBtn.TabIndex = 36;
            this.addMinuteBtn.Text = "+";
            this.addMinuteBtn.Click += new System.EventHandler(this.addMinuteBtn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.addMinuteBtn.GetChildAt(0))).Text = "+";
            ((Telerik.WinControls.UI.RadButtonElement)(this.addMinuteBtn.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            // 
            // addHourBtn
            // 
            this.addHourBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addHourBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.addHourBtn.Location = new System.Drawing.Point(569, 140);
            this.addHourBtn.Name = "addHourBtn";
            this.addHourBtn.Size = new System.Drawing.Size(61, 66);
            this.addHourBtn.TabIndex = 35;
            this.addHourBtn.Text = "+";
            this.addHourBtn.Click += new System.EventHandler(this.addHourBtn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.addHourBtn.GetChildAt(0))).Text = "+";
            ((Telerik.WinControls.UI.RadButtonElement)(this.addHourBtn.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            // 
            // addYearBtn
            // 
            this.addYearBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addYearBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.addYearBtn.Location = new System.Drawing.Point(322, 140);
            this.addYearBtn.Name = "addYearBtn";
            this.addYearBtn.Size = new System.Drawing.Size(61, 66);
            this.addYearBtn.TabIndex = 38;
            this.addYearBtn.Text = "+";
            this.addYearBtn.Click += new System.EventHandler(this.addYearBtn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.addYearBtn.GetChildAt(0))).Text = "+";
            ((Telerik.WinControls.UI.RadButtonElement)(this.addYearBtn.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            // 
            // minusYearBtn
            // 
            this.minusYearBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.minusYearBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.minusYearBtn.Location = new System.Drawing.Point(322, 290);
            this.minusYearBtn.Name = "minusYearBtn";
            this.minusYearBtn.Size = new System.Drawing.Size(61, 66);
            this.minusYearBtn.TabIndex = 39;
            this.minusYearBtn.Text = "-";
            this.minusYearBtn.Click += new System.EventHandler(this.minusYearBtn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.minusYearBtn.GetChildAt(0))).Text = "-";
            ((Telerik.WinControls.UI.RadButtonElement)(this.minusYearBtn.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            // 
            // OkBtn
            // 
            this.OkBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.OkBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.OkBtn.Location = new System.Drawing.Point(11, 5);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(221, 66);
            this.OkBtn.TabIndex = 40;
            this.OkBtn.Text = "确    定";
            this.OkBtn.Click += new System.EventHandler(this.OkButn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.OkBtn.GetChildAt(0))).Text = "确    定";
            ((Telerik.WinControls.UI.RadButtonElement)(this.OkBtn.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.CancelBtn.Location = new System.Drawing.Point(602, 5);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(221, 66);
            this.CancelBtn.TabIndex = 41;
            this.CancelBtn.Text = "返    回";
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.CancelBtn.GetChildAt(0))).Text = "返    回";
            ((Telerik.WinControls.UI.RadButtonElement)(this.CancelBtn.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.addMonthBtn);
            this.panel1.Controls.Add(this.radDateTimePicker2);
            this.panel1.Controls.Add(this.actualCourseTimePicker);
            this.panel1.Controls.Add(this.minusYearBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.addYearBtn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.addMinuteBtn);
            this.panel1.Controls.Add(this.minusMonthBtn);
            this.panel1.Controls.Add(this.addHourBtn);
            this.panel1.Controls.Add(this.addDateBtn);
            this.panel1.Controls.Add(this.minusMinuteBtn);
            this.panel1.Controls.Add(this.minusDateBtn);
            this.panel1.Controls.Add(this.minusHourBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(836, 371);
            this.panel1.TabIndex = 42;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.radButton1);
            this.panel2.Controls.Add(this.CancelBtn);
            this.panel2.Controls.Add(this.OkBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 456);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(836, 84);
            this.panel2.TabIndex = 43;
            // 
            // radButton1
            // 
            this.radButton1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.radButton1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.radButton1.Location = new System.Drawing.Point(307, 8);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(267, 66);
            this.radButton1.TabIndex = 42;
            this.radButton1.Text = "设置为20分钟之后";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Text = "设置为20分钟之后";
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            // 
            // SetTimeForm
            // 
            this.AcceptButton = this.OkBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(836, 540);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SetTimeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetTimeForm";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actualCourseTimePicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDateTimePicker2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addMonthBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minusMonthBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addDateBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minusDateBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minusMinuteBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minusHourBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addMinuteBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addHourBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addYearBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minusYearBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancelBtn)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadDateTimePicker actualCourseTimePicker;
        private Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker2;
        private Telerik.WinControls.UI.RadButton addMonthBtn;
        private Telerik.WinControls.UI.RadButton minusMonthBtn;
        private Telerik.WinControls.UI.RadButton addDateBtn;
        private Telerik.WinControls.UI.RadButton minusDateBtn;
        private Telerik.WinControls.UI.RadButton minusMinuteBtn;
        private Telerik.WinControls.UI.RadButton minusHourBtn;
        private Telerik.WinControls.UI.RadButton addMinuteBtn;
        private Telerik.WinControls.UI.RadButton addHourBtn;
        private Telerik.WinControls.UI.RadButton addYearBtn;
        private Telerik.WinControls.UI.RadButton minusYearBtn;
        private Telerik.WinControls.UI.RadButton OkBtn;
        private Telerik.WinControls.UI.RadButton CancelBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}