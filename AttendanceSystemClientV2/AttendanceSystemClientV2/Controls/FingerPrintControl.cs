using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceSystemClientV2.Helpers;
using AttendanceSystemClientV2.Models;
using AttendanceSystemClientV2.UserInterface;

namespace AttendanceSystemClientV2.Controls {
    /// <summary>
    /// 用于提供指纹仪控制操作的类
    /// </summary>
    public static class FingerPrintControl {

        /// <summary>
        /// 更新进度条委托
        /// </summary>
        /// <param name="progress">要增加的数值</param>
        /// <param name="text">要更改的文字</param>
        public delegate void UpdateProgressBarDelegate ( int progress, string text );

        public delegate DialogResult ShowConfirmBoxDelegate ( string text );

        public delegate void CloseProgressBarDelegate ( );

        /// <summary>
        /// 初始化指纹仪 向指纹仪中下载指纹数据
        /// </summary>
        /// <param name="studentList"></param>
        /// <param name="updateProgress"></param>
        /// <param name="showConfirmBox"></param>
        /// <param name="closeProgressBar"></param>
        public static void InitFingerprint ( ref List<Student> studentList, UpdateProgressBarDelegate updateProgress,
            ShowConfirmBoxDelegate showConfirmBox, CloseProgressBarDelegate closeProgressBar ) {

            Thread.Sleep ( 1000 ); // 等待进度条窗口创建完毕

            var fingerprintPtr = HdFingerprintHelper.FpOpenUsb ( 0xFFFFFFFF, 1000 ); // 打开指纹仪驱动

            while (fingerprintPtr == IntPtr.Zero) {

                var confirmResault = showConfirmBox ( "指纹仪初始化失败 \n是否重新初始化指纹仪?" );

                if (confirmResault == DialogResult.OK) {

                    fingerprintPtr = HdFingerprintHelper.FpOpenUsb ( 0xFFFFFFFF, 1000 );

                } else {

                    closeProgressBar ();

                    return;
                }
            }

            HdFingerprintHelper.FpEmpty ( fingerprintPtr, 5000 ); //清空指纹仪

            ushort fingerprintId = 0; // 指纹Id

            var total = studentList.Count; // 获取学生总数

            foreach (var student in studentList) {

                if (string.IsNullOrEmpty ( student.FingerprintString )) continue;

                fingerprintId++;


                var operationResault = HdFingerprintHelper.Download1Fingerprint ( fingerprintPtr, student.FingerprintString, fingerprintId, 1000 ); // 初始化一个指纹.

                updateProgress ( 1, string.Format ( "正在初始化 第{0}个指纹,\n共{1}个\n该学生的姓名为:{2}", fingerprintId, total, student.StudentName ) );

                if (operationResault != 0) {

                    var confirmResault = showConfirmBox ( string.Format ( "有一条指纹初始化失败 错误代码:{0}\n该指纹对应的学生学号为:{1}\n学生姓名为:{2}\n是否继续初始化指纹仪?"
                        , operationResault, student.StudentId, student.StudentName ) );

                    if (confirmResault == DialogResult.Cancel) {
                        closeProgressBar ();

                        return;
                    }

                    //和上面初始化指纹仪的过程是一样的

                    fingerprintPtr = HdFingerprintHelper.FpOpenUsb ( 0xFFFFFFFF, 1000 ); // 打开指纹仪驱动

                    while (fingerprintPtr == IntPtr.Zero) {

                        confirmResault = showConfirmBox ( "指纹仪初始化失败 \n是否重新初始化指纹仪?" );

                        if (confirmResault == DialogResult.OK) {

                            fingerprintPtr = HdFingerprintHelper.FpOpenUsb ( 0xFFFFFFFF, 1000 );

                        } else {

                            closeProgressBar ();

                            return;
                        }
                    }

                    //结束. 这块操作可以封装成一个函数
                }

                student.FingerprintId = fingerprintId; // 将指纹编号放到StudentList中.

            }

            closeProgressBar ();

            HdFingerprintHelper.FpCloseUsb ( fingerprintPtr ); // 初始化完毕之后关闭指纹仪 等需要签到的时候再打开指纹仪..

        }

    }
}
