using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceSystemClientV2.Controls;
using AttendanceSystemClientV2.PC;
using RemObjects.DataAbstract;

namespace AttendanceSystemClientV2.Models {
    /// <summary>
    /// 用于描述一门已经开设的课程
    /// </summary>
    public class CourseInfo {
        public string BriefcaseFileName;//开设课程对应的Briefcase文件名

        public string CourseName;//开设课程的课程名称

        public string CourseNo;//开课编号 对应字段: KKNO 

        public string LastModified;

        public string TeacherNo;

        public string TeacherName;

        public int expectedStudentNum;

        public int didNotSubmitStudentNum;

        public int actualStudentNum;

        public int askForLeaveStudentNum;

        /// <summary>
        /// 根据kkno 从对应的briefcase中得到课程信息.
        /// </summary>
        public CourseInfo(long kkno) {

            var courseBriefcase = new FileBriefcase(GlobalParams.BriefcasePath + kkno + @".daBriefcase", true);

            CourseNo = courseBriefcase.Properties["CourseNo"];//开课编号

            CourseName = courseBriefcase.Properties["CourseName"]; // 开课名称

            LastModified = courseBriefcase.Properties["LastModified"]; //最后一次更改

            TeacherNo = courseBriefcase.Properties["TeacherNo"]; // 教师编号

            TeacherName = courseBriefcase.Properties["TeacherName"];//教师姓名

            BriefcaseFileName = kkno + @".daBriefcase";
        }

        /// <summary>
        /// 用于提供界面的显示. 迟到人数等.
        /// </summary>
        /// <param name="expectedStudentNum">应到人数</param>
        /// <param name="didNotSubmitStudentNum">未签到人数</param>
        /// <param name="actualStudentNum">实到人数</param>
        /// <param name="askForLeaveStudentNum">请假人数</param>
        public CourseInfo(int expectedStudentNum, int didNotSubmitStudentNum, int actualStudentNum,
            int askForLeaveStudentNum){

            this.expectedStudentNum = expectedStudentNum;

            this.didNotSubmitStudentNum = didNotSubmitStudentNum;

            this.actualStudentNum = actualStudentNum;

            this.askForLeaveStudentNum = askForLeaveStudentNum;

        }
        
    }
}
