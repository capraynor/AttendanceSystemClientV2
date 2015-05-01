using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystemClientV2.Controls {

    /// <summary>
    /// 签到用的控制类
    /// </summary>
    public static class RollCallControl {

        /// <summary>
        /// 传入开课编号 上课编号 实际上课时间 初始化考勤信息
        /// 这里需要对指纹进行初始化 
        /// </summary>
        /// <param name="kkno"></param>
        /// <param name="skno"></param>
        /// <param name="actualRollCallTime"></param>
        public static void Init(long kkno , long skno , DateTime actualRollCallTime) {

            var classBriefcase = BriefcaseControl.GetBriefcase(kkno); // 拿课程对应的Briefcase 

            var dmTable = OfflineDataControl.GetDmDatatable(kkno, skno); // 拿本节课对应的点名表

            var xkTable = OfflineDataControl.GetXktable(kkno); // 拿课程对应的学生信息
            

        }

        public static void CreateFingerprintList() {
            


        }

    }
}
