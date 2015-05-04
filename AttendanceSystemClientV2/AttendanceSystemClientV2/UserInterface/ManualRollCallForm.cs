using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AttendanceSystemClientV2.Controls;
using AttendanceSystemClientV2.Models;

namespace AttendanceSystemClientV2.UserInterface
{
    public partial class ManualRollCallForm : Form{
        private List<Student> _studentList; 

        public ManualRollCallForm(List<Student> studentList )
        {
            InitializeComponent();

            _studentList = studentList;
        }

        private void radButton5_Click(object sender, EventArgs e){

            RollCallControl.CopyOfStudentList = _studentList; // 将学生表放回去

            Close();
        }

        private void normalBtn_Click ( object sender, EventArgs e ) {



        }
    }
}
