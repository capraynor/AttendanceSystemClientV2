using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RollCallSummary {
    class Student{

        [System.ComponentModel.DisplayName(@"学号")]
        public string xsid { get; set; }

        [System.ComponentModel.DisplayName ( @"姓名" )]
        public string xsname { get; set; }

        [System.ComponentModel.DisplayName ( @"请假次数" )]
        public long askForLeaveTotal { get; set; }

        [System.ComponentModel.DisplayName ( @"缺勤次数" )]
        public long absentTotal { get; set; }

        [System.ComponentModel.DisplayName ( @"班级编号" )]
        public long classId { get; set; }
    }
}
