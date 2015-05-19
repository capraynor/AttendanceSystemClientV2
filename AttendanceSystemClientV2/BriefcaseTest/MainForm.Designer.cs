namespace BriefcaseTest
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
            this.SuspendLayout();
            // 
            // PoweredByButton
            // 
            this.PoweredByButton.ApplicationType = RemObjects.SDK.ApplicationType.Client;
            this.PoweredByButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PoweredByButton.Location = new System.Drawing.Point(41, 18);
            this.PoweredByButton.Name = "PoweredByButton";
            this.PoweredByButton.Size = new System.Drawing.Size(212, 48);
            this.PoweredByButton.TabIndex = 0;
            this.PoweredByButton.Text = "PoweredByButton";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 536);
            this.Controls.Add(this.PoweredByButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Relativity Client Application";
            this.ResumeLayout(false);

        }

        #endregion

        private RemObjects.DataAbstract.PoweredByButton PoweredByButton;
    }
}

