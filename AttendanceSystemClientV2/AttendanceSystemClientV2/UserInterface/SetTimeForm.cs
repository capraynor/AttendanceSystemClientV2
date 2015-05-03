using System;
using System.Windows.Forms;

namespace AttendanceSystemClientV2.UserInterface {
    public partial class SetTimeForm : Form {

        private DateTime _actuallyRollCallTime ;
        public SetTimeForm ( ) {

            InitializeComponent ();

        }


        public DateTime GetActualRollCallTime() {

            return actualCourseTimePicker.Value;

        }

        private void OkButn_Click ( object sender, System.EventArgs e ){

            this.DialogResult = DialogResult.OK;

            _actuallyRollCallTime = actualCourseTimePicker.Value;

            Close();

        }

        private void CancelBtn_Click ( object sender, System.EventArgs e ){

            this.DialogResult = DialogResult.Cancel;

        }

        private void addYearBtn_Click ( object sender, System.EventArgs e ) {

            actualCourseTimePicker.Value = actualCourseTimePicker.Value.AddYears(1);

        }

        private void minusYearBtn_Click ( object sender, EventArgs e ) {

            actualCourseTimePicker.Value = actualCourseTimePicker.Value.AddYears (-1);

        }

        private void addMonthBtn_Click ( object sender, EventArgs e ) {

            actualCourseTimePicker.Value = actualCourseTimePicker.Value.AddMonths(1);

        }

        private void minusMonthBtn_Click ( object sender, EventArgs e ) {

            actualCourseTimePicker.Value = actualCourseTimePicker.Value.AddMonths (-1);

        }

        private void addDateBtn_Click ( object sender, EventArgs e ) {

            actualCourseTimePicker.Value = actualCourseTimePicker.Value.AddDays(1);

        }

        private void minusDateBtn_Click ( object sender, EventArgs e ) {

            actualCourseTimePicker.Value = actualCourseTimePicker.Value.AddDays (-1);

        }

        private void addHourBtn_Click ( object sender, EventArgs e ) {

            actualCourseTimePicker.Value = actualCourseTimePicker.Value.AddHours(1) ;

        }

        private void minusHourBtn_Click ( object sender, EventArgs e ) {

            actualCourseTimePicker.Value = actualCourseTimePicker.Value.AddHours(-1);
            
        }

        private void addMinuteBtn_Click ( object sender, EventArgs e ) {

            actualCourseTimePicker.Value = actualCourseTimePicker.Value.AddMinutes(1);

        }

        private void minusMinuteBtn_Click ( object sender, EventArgs e ) {

            actualCourseTimePicker.Value = actualCourseTimePicker.Value.AddMinutes(-1);

        }

        private void radButton1_Click ( object sender, EventArgs e ) {
            //设置为20分钟之后

            actualCourseTimePicker.Value = actualCourseTimePicker.Value.AddMinutes(20);

        }

        private void radDateTimePicker2_Click ( object sender, EventArgs e ) {
            //设置为预定上课时间

            actualCourseTimePicker.Value = radDateTimePicker2.Value;

        }


    }
}
