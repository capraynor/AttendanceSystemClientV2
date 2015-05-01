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
        public string StudentId;

        public int FingerprintId;

        public byte[] StudentPhoto;

        public int ClassId;

        public string ClassName;

        public string FingerprintString;

        public byte[] Fingerprint {
            get { }
        }

        public short RollCallStatus = 5;

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
        public DateTime ArriveTime; 
        
        /// <summary>
        /// 应到时间
        /// </summary>
        public DateTime RollCallTime = DateTime.Now;

        /// <summary>
        /// 标记了第几次点名
        /// </summary>
        public short RollCallTimes = 1; 

        
    }
}
