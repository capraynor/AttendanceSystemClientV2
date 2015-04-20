using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using AttendanceSystemClientV2.PC;
using AttendanceSystemClientV2.UserInterface;
using RemObjects.DataAbstract;

namespace AttendanceSystemClientV2.Controls {
    public static class BriefcaseControl {

        /// <summary>
        /// 用于下载数据时 briefcase的创建
        /// </summary>
        /// <param name="kkrecord">一条开课记录</param>
        /// <returns></returns>
        public static FileBriefcase CreateBriefcase(JSANDKKVIEWRO kkrecord) {

            DialogResult dialogresault;
            
            if (File.Exists(GlobalParams.BriefcasePath + kkrecord.KKNO + @".daBriefcase")) { // 判断briefcase是否存在

                dialogresault = new ConfirmBox("选定的课程 " + kkrecord.KKNAME + " 已经存在,\n还要下载该课程吗?").ShowDialog();

                if (dialogresault == DialogResult.Cancel) {
                    return null;
                }

                dialogresault = new ConfirmBox("真的要下载该课程吗? \n未保存的数据将会被删除.").ShowDialog();

                if (dialogresault == DialogResult.Cancel) {

                    return null;

                }

                File.Move (GlobalParams.BriefcasePath + kkrecord.KKNO + @".daBriefcase", 
                    GlobalParams.BriefcasePath + kkrecord.KKNO + @".daBriefcase"+DateTime.Now.ToString("yyyymmmmddhhmmss")); // 若存在 则重命名该briefcase.

            }

            dialogresault = new SetOfflinePasswdForm ().ShowDialog (); // 显示离线密码框 指定离线密码

            if (dialogresault == DialogResult.Cancel) { // 如果用户点击取消的话

                return null;//返回null
            }//离线密码存在 Properties.Settings.Default.OffliePassword 里面.

            
            var briefcaseToReturn = new FileBriefcase(GlobalParams.BriefcasePath + kkrecord.KKNO + @".daBriefcase");

            //指定Briefcase的属性
            briefcaseToReturn.Properties.Add(GlobalParams.BpkCourseName , kkrecord.KKNAME); // 开课课程名称
            
            briefcaseToReturn.Properties.Add(GlobalParams.BpkCourseNo , kkrecord.KKNO.ToString(CultureInfo.InvariantCulture));//课程编号

            briefcaseToReturn.Properties.Add(GlobalParams.BpkLastModifiedDate , "N/A");//最后一次签到时间

            briefcaseToReturn.Properties.Add(GlobalParams.BpkTeacherName , kkrecord.JSNAME);//教师姓名
            
            briefcaseToReturn.Properties.Add(GlobalParams.BpkTeacherNo , kkrecord.JSID.ToString(CultureInfo.InvariantCulture)); // 教师编号

            briefcaseToReturn.Properties.Add(GlobalParams.BpkPassword , Properties.Settings.Default.OffliePassword);//离线密码

            briefcaseToReturn.WriteBriefcase();

            return briefcaseToReturn;
            

        }
    }
}
