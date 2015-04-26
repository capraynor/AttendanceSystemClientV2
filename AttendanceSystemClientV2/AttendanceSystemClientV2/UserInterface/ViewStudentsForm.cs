using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceSystemClientV2.UserInterface {
    public partial class ViewStudentsForm : Form {
        public ViewStudentsForm ( ) {

            InitializeComponent ();


            //调用一个或者几个函数函数 该函数应该:
            //1.传入 kkno  和 skno 返回该堂课的点名表
            //2.传入kkno和datatable 可以正常写入briefcase.
            //指纹点名的时候也应该这样.
            //这些函数应该在OfflineDataControl中.
        }
    }
}
