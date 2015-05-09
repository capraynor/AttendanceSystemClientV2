using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceSystemClientV2.UserInterface {
    public partial class SplashForm : Form{

        private static SplashForm splashForm;

        private static Semaphore CloseSem =new Semaphore(0,1); // 每当

        private static Semaphore CreateSem = new Semaphore(0,1);

        public SplashForm ( ) {
            InitializeComponent ();

            this.radWaitingBar1.StartWaiting();

        }

        public static void ShowSplashForm(){

            var showDialogThread = new Thread(() =>{

                splashForm = new SplashForm();

                splashForm.ShowDialog();
            });

            var waitDialogToCloseThread = new Thread(() =>{

                CreateSem.WaitOne();

                CloseSem.WaitOne();

                splashForm.Invoke(new MethodInvoker(() => splashForm.Close()));

            });

            showDialogThread.Start(); // 开始显示splashForm

            //showDialogThread.Join(); // 等待创建splashForm完成

            waitDialogToCloseThread.Start(); // 开始监控信号量 等待splashForm关闭.

        }

        public static void CloseSplashForm(){

            CloseSem.Release();

        }

        private void SplashForm_Load ( object sender, EventArgs e ){

            CreateSem.Release();

        }

        
    }
}
