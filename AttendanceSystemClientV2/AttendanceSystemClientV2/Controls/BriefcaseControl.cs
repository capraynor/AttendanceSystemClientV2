using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using AttendanceSystemClientV2.Helpers;
using AttendanceSystemClientV2.PC;
using AttendanceSystemClientV2.UserInterface;
using RemObjects.DataAbstract;

namespace AttendanceSystemClientV2.Controls {
    public static class BriefcaseControl {

        /// <summary>
        /// 用于下载数据时 briefcase的创建
        /// 在确认下载数据后, 该函数会自动在properties briefcase中创建一条记录.
        /// </summary>
        /// <param name="kkrecord">一条开课记录</param>
        /// <returns></returns>
        public static FileBriefcase CreateBriefcase(JSANDKKVIEWRO kkrecord) {

            DialogResult dialogresault;
            
            if (File.Exists(GlobalParams.BriefcasePath + kkrecord.KKNO + @".daBriefcase")) { // 判断briefcase是否存在

                dialogresault = new ConfirmBox("选定的课程 " + kkrecord.KKNAME + " 已经存在,\n还要下载该课程吗?").ShowDialog();

                if (dialogresault == DialogResult.Cancel) {
                    return null;
                }

                dialogresault = new ConfirmBox("真的要下载该课程吗? \n未保存的数据将会被删除.").ShowDialog();

                if (dialogresault == DialogResult.Cancel) {

                    return null;

                }

                File.Move (GlobalParams.BriefcasePath + kkrecord.KKNO + @".daBriefcase", 
                    GlobalParams.BriefcasePath + kkrecord.KKNO + @".daBriefcase"+DateTime.Now.ToString("yyyymmmmddhhmmss")); // 若存在 则重命名该briefcase.

            }

            dialogresault = new SetOfflinePasswdForm ().ShowDialog (); // 显示离线密码框 指定离线密码

            if (dialogresault == DialogResult.Cancel) { // 如果用户点击取消的话

                return null;//返回null 在调用的位置需要进行判定.如果为null 则不下载课程
            }//离线密码存在 Properties.Settings.Default.OffliePassword 里面.

            
            var briefcaseToReturn = new FileBriefcase(GlobalParams.BriefcasePath + kkrecord.KKNO + @".daBriefcase");
            //返回的briefcase内为该门课程所有的数据 包括点名表 上课表 学生信息(选课表) 还有一个每节课信息(ClassStatus)

            //指定Briefcase的属性
            briefcaseToReturn.Properties.Add(GlobalParams.BpkCourseName , kkrecord.KKNAME); // 开课课程名称
            
            briefcaseToReturn.Properties.Add(GlobalParams.BpkCourseNo , kkrecord.KKNO.ToString(CultureInfo.InvariantCulture));//课程编号

            briefcaseToReturn.Properties.Add(GlobalParams.BpkLastModifiedDate , "N/A");//最后一次签到时间

            briefcaseToReturn.Properties.Add(GlobalParams.BpkTeacherName , kkrecord.JSNAME);//教师姓名
            
            briefcaseToReturn.Properties.Add(GlobalParams.BpkTeacherNo , kkrecord.JSID.ToString(CultureInfo.InvariantCulture)); // 教师编号

            briefcaseToReturn.Properties.Add(GlobalParams.BpkPassword , Properties.Settings.Default.OffliePassword);//离线密码

            var classInfoTable = new DataTable ("ClassInfo"); 
            // 里面应该存放每节课的信息. 该datatable应该放在对应课程的briefcase中 这个表是空的.将会在DataDownloadControl中对此表进行填充.

            classInfoTable.Columns.Add ("上课编号", typeof (string));

            classInfoTable.Columns.Add ("上课日期", typeof (string));

            classInfoTable.Columns.Add ("上课状态", typeof (string));

            briefcaseToReturn.AddTable(classInfoTable);//添加上面创建的datatable

            briefcaseToReturn.WriteBriefcase();//写入硬盘

            long xyid = Convert.ToInt64(kkrecord.XYID);

            var propertiesBriefcase = InitPropertiesBriefcase (xyid);
            //找出 properties briefcase 若properties不存在 该函数会自动创建一个propertiesbriefcase
            //xyid用于下载班级定义表用的.因此

            var courseInfoDataTable = propertiesBriefcase.FindTable("CourseInfo"); // 找到course info 表

            if (!courseInfoDataTable.Select("课程编号='" + kkrecord.KKNO.ToString() + "'").Any()) {//如果之前没下载过该课程的话

                var courseInfoTableRow = courseInfoDataTable.NewRow ();//新建一行记录

                courseInfoTableRow["课程名称"] = kkrecord.KKNAME;//添加课程名称 

                courseInfoTableRow["课程编号"] = kkrecord.KKNO.ToString (CultureInfo.InvariantCulture);//添加课程编号

                courseInfoDataTable.Rows.Add (courseInfoTableRow);//将新创建的一行加入课程信息表中

                propertiesBriefcase.AddTable (courseInfoDataTable);//将课程信息存到Properties Briefcase中

                propertiesBriefcase.WriteBriefcase ();//写入更改
            }



            return briefcaseToReturn;
        }

        /// <summary>
        /// 获取propertiesBriefcase,其中包含该 1.该平板中所有的课程 2.班级表
        /// 第一次在哪下载的课程 就得在哪里用.学院之间不能混用.
        /// 若briefcase不存在 则创建一个briefcase
        /// </summary>
        /// <returns></returns>
        public static FileBriefcase InitPropertiesBriefcase( long collageNo ) {

            if (File.Exists(GlobalParams.BriefcasePath + @"Properties.daBriefcase")) { //does properties briefcase exists?

                return new FileBriefcase (GlobalParams.BriefcasePath + @"Properties.daBriefcase" , true);//if yes ,return that briefcase(侯晨琛非要让我用英语注释)

            }else {

                var propertiesBriefcase = new FileBriefcase(GlobalParams.BriefcasePath + @"Properties.daBriefcase");//如果没有的话 那就新建一个briefcase

                var courseInfoTable = new DataTable("CourseInfo");//

                courseInfoTable.Columns.Add("课程名称" , typeof(string));

                courseInfoTable.Columns.Add("课程编号", typeof (string));

                propertiesBriefcase.AddTable(courseInfoTable); //新建一张表 表中存的是该平板中所有课程的信息 但表是空的.

                var fDataModule = new DataModule();//新建briefcase的时候要下载班级表咯

                var bjTable = from c in fDataModule.GetBjTable() //获取数据
                              where c.XYID == collageNo 
                              select c;

                var bjDataTable = EnumerableExtension.ListToDataTable(bjTable.ToList(), "BJTABLE");//将班级表转换成datatable

                propertiesBriefcase.AddTable(bjDataTable);//将班级表添加到briefcase中

                return propertiesBriefcase;//返回该briefcase

            }
        }

        /// <summary>
        /// 获取PropertiesBriefcase , 里面包含了班级信息和每门课的信息
        /// </summary>
        /// <returns></returns>
        private static FileBriefcase GetPropertiesBriefcase() { //判断properties briefcase是否存在
            if (!File.Exists(GlobalParams.BriefcasePath + @"Properties.daBriefcase")) {
                return null;//不存在 则返回null
            }

            return new FileBriefcase (GlobalParams.BriefcasePath + @"Properties.daBriefcase" , true);
            //若存在 则返回对应的briefcase对象

        }


        /// <summary>
        /// 根据 开课编号获取对应的Briefcase
        /// </summary>
        /// <param name="kkno">开课编号</param>
        /// <returns></returns>
        public static FileBriefcase GetBriefcase(long kkno) {

            if (!File.Exists(GlobalParams.BriefcasePath + kkno + @".daBriefcase")) {
                return null;
            } 
            
            return new FileBriefcase (GlobalParams.BriefcasePath + kkno + @".daBriefcase" , true);

        }

        /// <summary>
        /// 把点名表转成list 再转换成Datatable 然后再存.
        /// </summary>
        /// <param name="classBriefcase">要存的那门课对应的briefcase</param>
        /// <param name="dmTable">要保存的点名表</param>
        public static void SaveDmTable(FileBriefcase classBriefcase , DataTable dmTable) {

            var listToSave = dmTable.ToList<DMTABLE_08_NOPIC_VIEW>(); // 将Dmtable转成list

            var datatableToSave = EnumerableExtension.ListToDataTable(listToSave, dmTable.TableName); // 从list再转回来

            classBriefcase.AddTable(datatableToSave);//把转完的Datatable放到Briefcase中.

            classBriefcase.WriteBriefcase();//保存

        }

        /// <summary>
        /// 获取CourseInfo表,这张表将会绑定在第一个页面的左侧部分.
        /// TODO:写一个转换函数.将datatable转换成Dictionary
        /// </summary>
        /// <returns>可供转换的datatable</returns>
        public static DataTable GetCourseInfoDataTable() {
            
            var propertiesBriefcase = GetPropertiesBriefcase();

            if (propertiesBriefcase != null) {

                return propertiesBriefcase.FindTable("CourseInfo");

            }
            else {

                var courseInfoTable = new DataTable ("CourseInfo");
                //如果找不到properties briefcase , 那就新建一个空的courseinfo表. 并返回

                courseInfoTable.Columns.Add ("课程名称", typeof (string));

                courseInfoTable.Columns.Add ("课程编号", typeof (string));

                return courseInfoTable;
            }
        }

        /// <summary>
        /// 验证Briefcase的密码
        /// </summary>
        /// <param name="skno">需要验证的那节课</param>
        /// <returns></returns>
        public static bool VerifyOfflinePasswd(long skno) {

            var briefcaseToVerify = GetBriefcase(skno);

            if (briefcaseToVerify == null) return false;

            var passwd = briefcaseToVerify.Properties["Password"]; // 取密码

            var verifyResault = new VerifyOfflinePasswordForm(passwd).ShowDialog(); //获取弹出对话框的结果

            return (verifyResault == DialogResult.Yes);//比对结果并返回验证结果....
            //此结果非彼结果..

        }

        /// <summary>
        /// 获取班级表(字典)
        ///  
        /// </summary>
        /// <returns></returns>
        public static Dictionary<long , string> GetBjTable(){

            var dictionaryToReturn = new Dictionary<long, string>();

            var classInfoBriefcase = GetPropertiesBriefcase();

            var bjTable = classInfoBriefcase.FindTable("BJTABLE");

            foreach (DataRow bjRow in bjTable.Rows){

                var bjId = Convert.ToInt64(bjRow["BJID"]);

                var bjName = Convert.ToString(bjRow["BJNAME"]);

                dictionaryToReturn.Add(bjId , bjName);
                
            }

            return dictionaryToReturn;

        }

        

    }
}
