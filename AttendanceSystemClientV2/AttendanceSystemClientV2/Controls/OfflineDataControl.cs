using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceSystemClientV2.PC;

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

        public static void SaveDmtable(List<DMTABLE_08_NOPIC_VIEW> dmtable08NopicViews, long skno) {
            
        } 
    }
}
