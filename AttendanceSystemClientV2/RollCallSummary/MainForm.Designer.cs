namespace RollCallSummary
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PoweredByButton = new RemObjects.DataAbstract.PoweredByButton();
            this.studentGridView = new Telerik.WinControls.UI.RadGridView();
            this.classGridView = new Telerik.WinControls.UI.RadGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.studentGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentGridView.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classGridView.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // PoweredByButton
            // 
            this.PoweredByButton.ApplicationType = RemObjects.SDK.ApplicationType.Client;
            this.PoweredByButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PoweredByButton.Location = new System.Drawing.Point(569, 571);
            this.PoweredByButton.Name = "PoweredByButton";
            this.PoweredByButton.Size = new System.Drawing.Size(212, 48);
            this.PoweredByButton.TabIndex = 0;
            this.PoweredByButton.Text = "PoweredByButton";
            // 
            // studentGridView
            // 
            this.studentGridView.Location = new System.Drawing.Point(839, 62);
            this.studentGridView.Name = "studentGridView";
            this.studentGridView.Size = new System.Drawing.Size(452, 523);
            this.studentGridView.TabIndex = 1;
            this.studentGridView.Text = "radGridView1";
            // 
            // classGridView
            // 
            this.classGridView.Location = new System.Drawing.Point(486, 79);
            this.classGridView.Name = "classGridView";
            this.classGridView.Size = new System.Drawing.Size(333, 523);
            this.classGridView.TabIndex = 2;
            this.classGridView.Text = "radGridView2";
            this.classGridView.SelectionChanged += new System.EventHandler(this.classGridView_SelectionChanged);
            this.classGridView.Click += new System.EventHandler(this.classGridView_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(43, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(385, 528);
            this.dataGridView1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 631);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.classGridView);
            this.Controls.Add(this.studentGridView);
            this.Controls.Add(this.PoweredByButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Relativity Client Application";
            ((System.ComponentModel.ISupportInitialize)(this.studentGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RemObjects.DataAbstract.PoweredByButton PoweredByButton;
        private Telerik.WinControls.UI.RadGridView studentGridView;
        private Telerik.WinControls.UI.RadGridView classGridView;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

