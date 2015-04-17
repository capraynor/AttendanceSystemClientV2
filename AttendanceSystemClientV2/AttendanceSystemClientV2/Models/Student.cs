using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceSystemClientV2.PC;

namespace AttendanceSystemClientV2.Models {
    
    /// <summary>
    /// 学生类。用于描述一个学生。
    /// </summary>
    public class Student {
        public string Name;//学生姓名

        public string Id;//学生学号

        public string ClassName;//学生所在班级名称

        public long ClassId;//学生所在班级编号

        public byte[] Photo;//学生照片

        public short RollCallStatus;//签到状态

        private Student(XKTABLE_VIEWRO xktableViewro) {

            ClassId = Convert.ToInt64 (xktableViewro.BJID);//解析班级ID
            
            Id = xktableViewro.XSID;//解析学生ID

            ClassId = Convert.ToInt64 (xktableViewro.BJID);//解析学生班级编号

            //TODO:2015年4月17日 photo rollcall status要写完

            if (GlobalParams.ClassTable != null) {

                var dr = GlobalParams.ClassTable.Select(@"BJID = " + ClassId);

                if (dr.Any()) {

                    ClassName = (string) dr.First()["BJNAME"];
                }

                ClassName = @"N/A";
            }
        }


    }
}
