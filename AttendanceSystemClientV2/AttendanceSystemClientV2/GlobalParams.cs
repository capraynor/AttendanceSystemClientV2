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
            get { return Environment.CurrentDirectory; }
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


    }
}
