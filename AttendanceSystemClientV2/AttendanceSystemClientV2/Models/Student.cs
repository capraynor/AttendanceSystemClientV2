using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AttendanceSystemClientV2.Controls;
using AttendanceSystemClientV2.PC;

namespace AttendanceSystemClientV2.Models {

    /// <summary>
    /// 学生类。用于描述一个学生。
    /// </summary>
    public class Student {
        /// <summary>
        /// 学号
        /// </summary>
        [System.ComponentModel.DisplayName(@"学号")]
        public string StudentId { get; set; }



        /// <summary>
        /// 指纹编号
        /// </summary>
        public int FingerprintId;

    

        /// <summary>
        /// 学生皂片
        /// </summary>
        public byte[] StudentPhoto;

        /// <summary>
        /// 班级编号
        /// </summary>
        public long ClassId;

        /// <summary>
        /// 班级名称
        /// </summary>
        [System.ComponentModel.DisplayName(@"班级")]
        public string ClassName { get; set; }


        /// <summary>
        /// 指纹字符串
        /// </summary>
        public string FingerprintString;

        /// <summary>
        /// 签到状态
        /// </summary>
        public short RollCallStatus;

        /// <summary>
        /// 开课编号
        /// </summary>
        public long kkno;

        /// <summary>
        /// 上课编号
        /// </summary>
        public long skno;

        /// <summary>
        /// 考勤状态
        /// </summary>
        [System.ComponentModel.DisplayName(@"状态")]
        public string RollCallStatusString {
            get {
                switch (RollCallStatus) {

                    case 0: {

                        return "正常";

                        
                    }
                    case 1: {

                        return "迟到";
                        
                    }

                    case 2: {

                        return "早退";

                    }
                    case 3: {

                        return "旷课";

                    }
                    case 4: {

                        return "请假";

                    }

                    case 5: {

                        return "未签到";
                    }
                }

                return "N/A"; // 如果数据异常就翻脸
            }
        }

        /// <summary>
        /// 该学生的到课时间
        /// </summary>
        [System.ComponentModel.DisplayName(@"到课时间")]
        public DateTime ArriveTime { get; set; }

        /// <summary>
        /// 应到时间
        /// </summary>
        public DateTime RollCallTime = DateTime.Now;

        /// <summary>
        /// 标记了第几次点名
        /// </summary>
        public short RollCallTimes = 1;

        /// <summary>
        /// 当指纹仪找到这个人的时候,程序需要调用List中的对象的该函数来进行签到操作.
        /// </summary>
        /// <param name="arriveTime"></param>
        /// <param name="rollCallStatus"></param>
        public void SignIn(DateTime arriveTime , short rollCallStatus){

            //将到课状态更改成指定的状态
            RollCallStatus = rollCallStatus;

            //把标记该门课的表取出来
            var classBriefcase = BriefcaseControl.GetBriefcase(kkno);

            //然后获取点名表
            var dmTable = OfflineDataControl.GetDmDatatable ( kkno, skno );

            //改点名表里的记录 这里改的就是数据了.
            OfflineDataControl.ChangeDmRecord ( ref dmTable, StudentId, 0, arriveTime, RollCallTimes );

            //存点名表.
            BriefcaseControl.SaveDmTable ( classBriefcase, dmTable );

        }

        public Student(XKTABLE_VIEWRO xkRecord){
            
            StudentId = xkRecord.XSID;

            if (xkRecord.XSZP != null){

                StudentPhoto = xkRecord.XSZP;

            }

            if (!String.IsNullOrEmpty(xkRecord.ZW2)){

                FingerprintString = xkRecord.ZW2;
                
            }

            ClassId = Convert.ToInt64 ( xkRecord.BJID );

            RollCallStatus = 5;

        }
        
    }
}
