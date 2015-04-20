using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using AttendanceSystemClientV2.Controls;
using AttendanceSystemClientV2.Models;
using AttendanceSystemClientV2.PC;

namespace AttendanceSystemClientV2.UserInterface {
    public partial class ShowServerClassesForm : Form {

        private readonly DataModule _fDataModule; // datamodule 

        private readonly List<JSANDKKVIEWRO> _jsandkkviewro; // 已经登录的教师对应的开课表

        private List<SKTABLE_07_VIEWRO> _sktable;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ShowServerClassesForm ( ) {
            InitializeComponent ();

            _fDataModule = new DataModule (); // 实例化 datamodule

            var jsandkkviewros = from c in _fDataModule.GetJsandkkviewro ()
                                 where c.JSID == Convert.ToInt64 (Properties.Settings.Default.UserId)
                                 select c; // 建立教师ID Linq表达式

            _jsandkkviewro = jsandkkviewros.ToList ();//将拉取到的数据转换成list 里面包含该教师本学期拥有的课程

            var courseListDictionary = _jsandkkviewro.ToDictionary(jsandkkviewro => jsandkkviewro.KKNO, jsandkkviewro => jsandkkviewro.KKNAME);

            curriculumListLbox.DataSource = new BindingSource (courseListDictionary, null);//新建一个数据源 并将其绑定在datasource中

            curriculumListLbox.DisplayMember = "Value"; //设置显示字段

            curriculumListLbox.ValueMember = "Key";//设置值字段


        }

        private void downloadCourseBtn_Click ( object sender, EventArgs e ) {
            //下载课程.调用一个函数 将kkno和datamodule传进去. 剩下的由它负责就好啦

            var selectedproperty = (KeyValuePair<long, string>)curriculumListLbox.SelectedItem;

            DataDownloadControl.DownloadOneCourse (selectedproperty.Key);

        }

        private void radButton1_Click ( object sender, EventArgs e ) {

            Close ();

        }

        private void curriculumListLbox_SelectedIndexChanged ( object sender, EventArgs e ) {
            //(long)curriculumListLbox.SelectedValue

            //更新右侧gridview

            var selectedproperty = (KeyValuePair<long, string>)curriculumListLbox.SelectedItem; // 获取已经选择的项目

            var sktableiqueryable = from c in _fDataModule.GetSktable07Viewro() // 获取上课编号
                                    where c.KKNO == selectedproperty.Key//选啊选啊选....
                                    select c;

            //更新下方的label
            _sktable = sktableiqueryable.ToList ();//转成list选完以后转成list

            var dt = DataDownloadControl.GetDisplayClassStatusTable(_sktable);//将list转换成可以直接显示的datatable

            rollCallGridView.DataSource = dt;//给右侧的gridview绑定数据源

            var currentkkrecord = _jsandkkviewro.Find(x => x.KKNO == selectedproperty.Key);//linq表达式,得到这堂课的其他信息.

            //给label们赋值
            teacherNameLbl.Text = currentkkrecord.JSNAME;

            studentTotalLbl.Text = currentkkrecord.XXRS.ToString();

            courseNameLbl.Text = currentkkrecord.KKNAME;
        }


    }
}
