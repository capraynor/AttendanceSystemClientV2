using System.Windows.Forms;

namespace AttendanceSystemClientV2.UserInterface {
    public partial class WaitForm : Form {

        public WaitForm (string operation) {//构造函数 传入操作名称
            InitializeComponent ();

            operationNameLbl.Text = operation;

            var a = 1;
        }
        
        private int ProgressValue {

            get { return progressBar1.Value; }

            set {
                progressBar1.Value = value;
                BringToFront();
            }

        }

        /// <summary>
        /// 增加数值
        /// </summary>
        /// <param name="nValue">要增加的数值</param>
        /// <returns></returns>
        public bool Increase ( int nValue ) {

            if (nValue <= 0) return false;

            if (ProgressValue + nValue < progressBar1.Maximum) {

                ProgressValue += nValue;

                return true;
            }

            ProgressValue = progressBar1.Maximum;

            return false;
        }


        public bool SetValue(int value) {
            if (value <= 0) return false;

            if ( value < progressBar1.Maximum) {

                ProgressValue = value;

                return true;
            }

            ProgressValue = progressBar1.Maximum;

            return false;
        }


    }
}
