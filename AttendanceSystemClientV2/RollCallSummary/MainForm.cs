using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq;
using RemObjects.DataAbstract.Linq;
using RollCallSummary.PC;

namespace RollCallSummary {
    public partial class MainForm : Form {
        #region Private fields
        private DataModule fDataModule;

        //private List<SKTABLE_07_VIEWRO> sktable ; // 保存这学期所有的上课信息 

        private List<XSTABLE_01_VIEW> xsTable;

        private List<DMTABLE_08_NOPIC_VIEW> dmTable;

        private List<JSANDKKVIEWRO> kktable; 
        #endregion

        public MainForm ( ) {

            //this.fDataModule = new DataModule ();

            //var bjTable = fDataModule.GetBjTable ();

            //Console.WriteLine("{0}获取班级表", DateTime.Now);

            //this.InitializeComponent ();

            //this.classGridView.DataSource = bjTable;

            //Console.WriteLine ( "{0}开始获取开课表", DateTime.Now );

            //kktable =fDataModule.GetKktable05Viewros ().ToList ();

            //Console.WriteLine ("{0}获取开课表", DateTime.Now);

            //Console.WriteLine ( "{0}开始获取学生表", DateTime.Now );

            //xsTable = fDataModule.GetXsTable().ToList();

            //Console.WriteLine ( "{0}获取学生表", DateTime.Now );

            //Console.WriteLine ( "{0}开始获取点名表", DateTime.Now );
            //dmTable = fDataModule.GetDmTable().ToList();
            //Console.WriteLine ( "{0}获取点名表", DateTime.Now );
            //var studentList = new List<Student>();

            //foreach (var xstableRecord in xsTable){

            //    var student = new Student();

            //    student.xsid = xstableRecord.XSID;

            //    student.xsname = xstableRecord.XSNAME;

            //    student.askForLeaveTotal = 0;

            //    student.absentTotal = 0;

            //    if (xstableRecord.BJID != null) student.classId = xstableRecord.BJID.Value;

            //    studentList.Add(student);

            //}

            //foreach (var kktablerecord in kktable){

            //    var dmRecords = from c in dmTable where c.KKNO == kktablerecord.KKNO select c;

            //    Console.WriteLine ( string.Format ( "正在统计{0}", kktablerecord.KKNAME ) );

            //    foreach (var student in studentList){

            //        var askForLeaveCounter = from c in dmRecords where c.DKZT == 3 && c.XSID == student.xsid select c;

            //        var absentCounter = from c in dmRecords where c.DKZT == 4 && c.XSID == student.xsid select c;

            //        long askForLeaveTotal = askForLeaveCounter.Count();

            //        long absentTotal = absentCounter.Count();

            //        student.askForLeaveTotal += askForLeaveTotal;

            //        student.absentTotal += absentTotal;

            //    }

            //    Console.WriteLine(string.Format("统计完毕:{0}" , kktablerecord.KKNAME));


            //}

            //this.classGridView.DataSource = studentList;
            //dataGridView1.DataSource = studentList;

            fDataModule = new DataModule();


        }

        private void classGridView_Click ( object sender, EventArgs e ) {

        }

        private void classGridView_SelectionChanged ( object sender, EventArgs e ) {

            //try {

            //    var classId = Convert.ToInt64 ( classGridView.CurrentRow.Cells[0].Value );


            //    var xsTable = from c in this.xsTable where c.BJID == classId select new {c.XSID , c.XSNAME};



            //    studentGridView.DataSource = xsTable;

            //    var studentList = new List<Student>();

            //    foreach (var xsTableRecord in xsTable){

            //        var student = new Student();

            //        student.xsid = xsTableRecord.XSID;

            //        student.xsname = xsTableRecord.XSNAME;



            //        var record = xsTableRecord; // 学生表的一条记录 局部变量




            //        student.askForLeaveTotal = 

            //    }




            //} catch (Exception ex) {

            //    MessageBox.Show ( ex.Message );

            //}


        }
    }

}
