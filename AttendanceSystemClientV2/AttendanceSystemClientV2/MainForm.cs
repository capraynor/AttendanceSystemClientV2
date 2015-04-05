﻿using System;
using System.Windows.Forms;
using System.Linq;
using RemObjects.DataAbstract.Linq;
using Telerik.WinControls.UI;

namespace AttendanceSystemClientV2
{
    public partial class MainForm : RadForm
    {
        #region Private fields
        private readonly DataModule _fDataModule;
        #endregion

        public MainForm()
        {
            InitializeComponent();

            _fDataModule = new DataModule();
        }

        private void panel1_default_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_fDataModule.IsLoggedOn.ToString());
            _fDataModule.getdata();
        }
    }
}
