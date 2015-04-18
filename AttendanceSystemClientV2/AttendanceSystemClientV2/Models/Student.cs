using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

        public Image Photo;//学生照片

        public string CollageName;

        private Student ( XKTABLE_VIEWRO xktableViewro ) {

            ClassId = Convert.ToInt64 (xktableViewro.BJID);//解析班级ID

            Id = xktableViewro.XSID;//解析学生ID

            ClassId = Convert.ToInt64 (xktableViewro.BJID);//解析学生班级编号

            if (!string.IsNullOrEmpty(xktableViewro.XSNAME)) {

                Name = xktableViewro.XSNAME;
            }
            else {

                Name = "N/A";
            }

            if (xktableViewro.XSZP != null) {
                using (var ms = new MemoryStream (xktableViewro.XSZP)) {
                    Photo = Image.FromStream (ms);//若数据库中有照片,则将照片提取出来
                }


            } else if (xktableViewro.XSSEX == "男") {//若数据库中没有照片 则提取出默认照片

                Photo = Properties.Resources.male;

            } else if (xktableViewro.XSSEX == "女") {

                Photo = Properties.Resources.female;

            }

            if (GlobalParams.ClassTable != null) {//解析学生的班级名称

                var dr = GlobalParams.ClassTable.Select (@"BJID = " + ClassId); // 取出班级的那一列

                if (dr.Any ()&&(!dr.First().IsNull("XYNAME")) 
                    &&(!dr.First().IsNull("BJNAME"))) {

                    ClassName = (string)dr.First ()["BJNAME"];

                    CollageName = (string) dr.First()["XYNAME"];
                }else {

                    ClassName = @"N/A";

                    CollageName = @"N/A";
                }
            }else {

                ClassName = @"N/A";

                CollageName = @"N/A";

            }

        }


    }
}
