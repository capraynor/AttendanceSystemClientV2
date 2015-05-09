using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemObjects.DataAbstract;

namespace AttendanceSystemClientV2 {
    /// <summary>
    /// 全局变量，里面有设置什么的。比如briefcase路径之类的东西
    /// </summary>
    public static class GlobalParams {
        /// <summary>
        /// Briefcase目录
        /// </summary>
        public static string BriefcasePath {
            get {
                if (!Directory.Exists (RootDir + @"\Briefcase\")) {
                    Directory.CreateDirectory (RootDir + @"\Briefcase\");
                }
                return (RootDir + @"\Briefcase\");
            }

            
        }

        /// <summary>
        /// 获取软件的根目录
        /// </summary>
        public static string RootDir {
            //get { return Environment.CurrentDirectory; }
            get { return Environment.GetFolderPath ( Environment.SpecialFolder.MyDocuments ); }

        }

        /// <summary>
        /// 获取班级表(datatable);
        /// 注意:读取Briefcase的时候构造函数调用要加上TRUE
        /// </summary>
        public static DataTable ClassTable {
            get {
                return !File.Exists(BriefcasePath + @"\Properties.daBriefcase") ? null : 
                    (new FileBriefcase (BriefcasePath + @"\Properties.daBriefcase" ,true).FindTable (@"ClassNameTable")); 
                //判断班级Briefcase是否存在 若存在,则读取班级表.若不存在 则返回Null 
            }
        }

        #region briefcase属性字符串
        //briefcase属性字符串 BPK: briefcase properties key
        
        /// <summary>
        /// 离线密码
        /// </summary>
        public static string BpkPassword = "Password";
        
        /// <summary>
        /// 课程名称
        /// </summary>
        public static string BpkCourseName = "CourseName";

        /// <summary>
        /// 教师名称
        /// </summary>
        public static string BpkTeacherName = "TeacherName";

        /// <summary>
        /// 教师编号
        /// </summary>
        public static string BpkTeacherNo = "TeacherNo";

        /// <summary>
        /// 课程编号
        /// </summary>
        public static string BpkCourseNo = "CourseNo";

        /// <summary>
        /// 最后一次签到时间 里面存的应该是预计上课时间
        /// </summary>
        public static string BpkLastModifiedDate = "LastModified";

        #endregion


    }
}
