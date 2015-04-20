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


        /// <summary>
        /// 为进度条设置进度
        /// </summary>
        /// <param name="value">进度值</param>
        /// <returns>设置成功或者失败</returns>
        public bool SetValue(int value) { // 为进度条设置进度

            if (value <= 0) return false;//如果传进的参数小于0 , 则返回失败

            if ( value < progressBar1.Maximum) { // 如果传进的数值大于0 , 则对进度条进行更改

                ProgressValue = value; 

                return true;
            }

            ProgressValue = progressBar1.Maximum;

            return false;
        }

        public void SetInfo(string information) {

            operationNameLbl.Text = information;

        }


    }
}
