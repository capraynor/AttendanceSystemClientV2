using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceSystemClientV2.Helpers;
using AttendanceSystemClientV2.PC;
using RemObjects.DataAbstract;

namespace AttendanceSystemClientV2.Controls {
    /// <summary>
    /// 用于提供离线数据控制操作的类
    /// </summary>
    public static class OfflineDataControl {
        /// <summary>
        /// 根据开课编号和上课编号找到点名表
        /// </summary>
        /// <param name="kkno">开课编号</param>
        /// <param name="skno">上课编号</param>
        /// <returns>DMTABLE的一个List</returns>
        public static List<DMTABLE_08_NOPIC_VIEW> GetDmtable(long kkno  , long skno) {
            //todo:完成此方法.
            return null;
        }


        /// <summary>
        /// 获取选课表 里面包含学生信息
        /// </summary>
        /// <param name="kkno">开课编号</param>
        /// <returns>开课编号对应的选课表(学生信息 一个学生一条记录)</returns>
        public static List<XKTABLE_VIEWRO> GetXktable(long kkno) {
            //todo:完成此方法.
            return null;
        }

        /// <summary>
        /// 获取上课表 其中包含该门课程每节课的信息.
        /// </summary>
        /// <param name="skno">上课编号</param>
        /// <returns>开课编号对应的上课表(上课信息 一堂课一条记录)</returns>
        public static List<SKTABLE_07_VIEWRO> GetSktable(long skno) {
            //todo:完成此方法.
            return null;
        }

        /// <summary>
        /// 开始点名时 保存点名表
        /// </summary>
        /// <param name="dmtable08NopicViews">传进来的点名表</param>
        /// <param name="skno">上课编号</param>
        public static void SaveDmtable(List<DMTABLE_08_NOPIC_VIEW> dmtable08NopicViews, long skno) {
            
        }

        /// <summary>
        /// 将传进来的courseInfo 转换成Dictionary 作为Listbox的数据源
        /// </summary>
        /// <param name="courseInfoDataTable">所有的课程信息 里面的字段有: 课程编号 和 课程名称</param>
        /// <returns>ListBox的数据源</returns>
        private static Dictionary<long, string> CourseInfoToDictionary
            (DataTable courseInfoDataTable) {

            var courseInfoDictionary = new Dictionary<long, string>();//新建一个Dictionary

            if (courseInfoDataTable.Rows.Count == 0) { // 判断传进来的datatable是否有数据
                
                courseInfoDictionary.Add(-1 , "找不到数据");
                //如果没数据 返回一个只包含一条数据的Dictionary

                return courseInfoDictionary;

            }

            foreach (DataRow courseInfo in courseInfoDataTable.Rows) {
                //如果传进来的datatable中包含数据,则遍历它,逐条向Dictionary中添加数据

                courseInfoDictionary.Add (Convert.ToInt64 (courseInfo["课程编号"]),
                    Convert.ToString (courseInfo["课程名称"]));

            }

            return courseInfoDictionary;
            
        }

        /// <summary>
        /// 通过上课编号获取每节课的签到情况信息.该信息保存在每节课对应的Briefcase中的ClassInfo中
        /// </summary>
        /// <param name="skno">上课编号</param>
        /// <returns>ClassInfo表 里面包含着每节课的签到信息.</returns>
        public static DataTable GetClassInfoTable(long skno) {

            if (!File.Exists(GlobalParams.BriefcasePath + skno + @".daBriefcase")) {
                var emptyClassInfoTable = new DataTable ("ClassInfo");
                // 里面应该存放每节课的信息. 该datatable应该放在对应课程的briefcase中 这个表是空的.将会在DataDownloadControl中对此表进行填充.

                emptyClassInfoTable.Columns.Add ("上课编号", typeof (string));

                emptyClassInfoTable.Columns.Add ("上课日期", typeof (string));

                emptyClassInfoTable.Columns.Add ("上课状态", typeof (string));

                return emptyClassInfoTable;
            }

            var courseBriefcase = new FileBriefcase(GlobalParams.BriefcasePath + skno + @".daBriefcase" , true);

            var classInfoTable = courseBriefcase.FindTable("ClassInfo");

            return classInfoTable;

        }


        /// <summary>
        /// 显示辅助函数 获取第一个页面的Listbox的数据源(Dictionary)
        /// Dp开头的为显示辅助函数.
        /// </summary>
        /// <returns>可直接绑定在listbox的Dictionary</returns>
        public static Dictionary<long, string> Dp_GetCourseInfoDictionary() {

            var courseInfoDatatable = BriefcaseControl.GetCourseInfoDataTable();

            var courseInfoDictionary = CourseInfoToDictionary(courseInfoDatatable);

            return courseInfoDictionary;

        }
    }
}
