using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using AttendanceSystemClientV2.PC;

namespace AttendanceSystemClientV2.UserInterface {
    public partial class ShowServerClassesForm : Form {
        private DataModule _fDataModule; // datamodule 

        private List<JSANDKKVIEWRO> _jsandkkviewro; // 开课表

        private Dictionary<long, string> _courseListDictionary;//用于显示课程列表的数据字典

        public ShowServerClassesForm () {

            InitializeComponent ();

            _courseListDictionary = new Dictionary<long, string>();//实例化 课程列表 字典
            
            _fDataModule = new DataModule(); // 实例化 datamodule

            var jsandkkviewros = from c in _fDataModule.GetJsandkkviewro ()
                                      where c.JSID == Convert.ToInt64 (Properties.Settings.Default.UserId)
                                      select c; // 建立教师ID Linq表达式

            _jsandkkviewro = jsandkkviewros.ToList();//将拉取到的数据转换成list 里面包含该教师本学期拥有的课程

            foreach (var jsandkkviewro in _jsandkkviewro) {//遍历以上结果集,将信息添加至课程列表字典中

                _courseListDictionary.Add(jsandkkviewro.KKNO , jsandkkviewro.KKNAME);
            
            }

            curriculumListLbox.DataSource = new BindingSource(_courseListDictionary, null);//新建一个数据源 并将其绑定在datasource中

            curriculumListLbox.DisplayMember = "Value"; //设置显示字段

            curriculumListLbox.ValueMember = "Key";//设置值字段


        }

        private void downloadCourseBtn_Click ( object sender, EventArgs e ) {

            //MessageBox.Show(_fDataModule.GetsSktable07Viewro().Count().ToString());

            MsgBox.ShowMsgBoxDialog (_fDataModule.GetsSktable07Viewro ().Count ().ToString ());

        }

        private void radButton1_Click ( object sender, EventArgs e ) {

            Close();

        }

        private void curriculumListLbox_SelectedIndexChanged ( object sender, EventArgs e ) {
            //(long)curriculumListLbox.SelectedValue
        }

        
    }
}
