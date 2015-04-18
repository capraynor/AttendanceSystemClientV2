using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceSystemClientV2.PC;

namespace AttendanceSystemClientV2.Models {
    /// <summary>
    /// 用于描述一门已经开设的课程
    /// </summary>
    class CourseInfo {
        public string BriefcaseFileName;//开设课程对应的Briefcase文件名

        public string CourseName;//开设课程的课程名称

        public long CourseNo;//开课编号 对应字段: KKNO 

        //public CourseInfo(KKTABLE_05_VIEWRO) {
            
        //}

    }
}
