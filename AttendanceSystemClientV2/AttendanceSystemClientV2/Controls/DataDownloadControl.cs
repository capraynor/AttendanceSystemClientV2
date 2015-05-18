using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceSystemClientV2.Helpers;
using AttendanceSystemClientV2.PC;
using AttendanceSystemClientV2.UserInterface;
using RemObjects.DataAbstract;

namespace AttendanceSystemClientV2.Controls {
    /// <summary>
    /// 用于提供下载数据时操作的类
    /// </summary>
    public static class DataDownloadControl {

        private static WaitForm _waitform;

        /// <summary>
        /// 获取用于显示的课程状态.返回的是一个datatable,该datatable可以直接绑定至gridview.
        /// </summary>
        /// <param name="kktable"></param>
        /// <returns></returns>
        public static DataTable GetDisplayClassStatusTable(IEnumerable<SKTABLE_07_VIEW> kktable) {
            var kkdatatable = new DataTable("kktable");

            kkdatatable.Columns.Add ("上课时间", typeof (string));

            kkdatatable.Columns.Add ("签到状态", typeof (string));
            
            foreach (var kktable05Viewro in kktable) {
                var _row = kkdatatable.NewRow();

                if (kktable05Viewro.YDSKDATE != null) {
                    _row["上课时间"] = kktable05Viewro.YDSKDATE.Value.ToString("yyyy-MM-dd dddd" ,new CultureInfo("zh-cn"));
                }
                else {
                    _row["上课时间"] = "N/A";
                }

                switch (kktable05Viewro.SKZT){
                    case null:
                        _row["签到状态"] = "未知";
                        break;
                    case 0:
                        _row["签到状态"] = "未签到";
                        break;
                    default:
                        _row["签到状态"] = "已签到";
                        break;
                }

                kkdatatable.Rows.Add(_row);
            }

            kkdatatable.DefaultView.Sort = "上课时间 DESC";

            return kkdatatable;
        }

        /// <summary>
        /// 下载一门课程 包括显示进度条等界面操作
        /// </summary>
        /// <param name="kkno"></param>
        /// 
        public static void DownloadOneCourse(long kkno) {
            var fDataModule = new DataModule(); //新建一个datamodule

            var jsandkkview = from c in fDataModule.GetJsandkkviewro()//传进来kkno 将对应课程的信息拉出来 
                              where c.KKNO == kkno 
                              select c;

            var kkrecord = jsandkkview.First();//取第一条记录
            
            var courseBriefcase = BriefcaseControl.CreateBriefcase(kkrecord);//根据开课表的一行记录建立briefcase

            if (courseBriefcase == null) {

                return;
            }

            _waitform = new WaitForm("初始化下载进程");

            new Thread (( ) => DownloadData (kkno, courseBriefcase)).Start ();//将费时的操作放在一个线程中



            _waitform.ShowDialog();

            MsgBox.ShowMsgBoxDialog("选定的课程下载完毕.");

            
        }

        /// <summary>
        /// 下载课程的过程中比较费时的操作都在这个函数里面
        /// </summary>
        /// <param name="kkno">开课编号</param>
        /// <param name="courseBriefcase">该堂课要存的briefcase</param>
        private static void DownloadData ( long kkno, Briefcase courseBriefcase ) {

            Thread.Sleep(1000);//等待进度条窗口建立完毕

            _waitform.Invoke (new MethodInvoker (( ) => _waitform.SetInfo ("下载学生信息 \n 该过程可能会比较耗时")));

            var fDataModule = new DataModule(); // 再新建一个datamodule..  好浪费资源的说 反正C#会自己做内存回收...

            var xktable = from c in fDataModule.GetxktableViewros()  // 将选课表(学生信息)拿出来
                          where c.KKNO == kkno 
                          select c;

            _waitform.Invoke(new MethodInvoker(() => _waitform.SetInfo("下载学生信息 \n 该过程会耗时30秒左右"))); // 更改等待窗口的文字

            var xkDatatable = EnumerableExtension.ListToDataTable (xktable.ToList (), "XKTABLE"); // 下载选课表

            _waitform.Invoke (new MethodInvoker (( ) => _waitform.SetValue(20) )); // 设置进度条 20

            courseBriefcase.AddTable(xkDatatable); // 将选课表加到briefcase中

            courseBriefcase.WriteBriefcase (); // 写入硬盘

            var sktable = from c in fDataModule.GetSktable07Viewro() where c.KKNO == kkno select c; // 拉取上课表

            var dmtable = from c in fDataModule.GetdmTable() where c.KKNO == kkno select c;//拉取选课表

            _waitform.Invoke (new MethodInvoker (( ) => _waitform.SetInfo ("下载课程信息 \n 该过程不会消耗太长时间")));

            _waitform.Invoke (new MethodInvoker (( ) => _waitform.SetValue (50)));

            var sktableList = sktable.ToList(); // 下载上课表

            var skdatatable = EnumerableExtension.ListToDataTable(sktableList, "SKTABLE"); //将上课表转换成datatable

            courseBriefcase.AddTable(skdatatable); // 将datatable写入briefcase中

            courseBriefcase.WriteBriefcase(); // 写入硬盘

            _waitform.Invoke (new MethodInvoker (( ) => _waitform.SetInfo ("下载考勤信息 \n 该过程不会消耗太长时间")));

            var dmtableList = dmtable.ToList(); // 下载点名表

            foreach (var sktable07Viewro in sktable) {

                var viewro = sktable07Viewro; // resharper说一定要这么写

                var dmtablesinglelist = from c in dmtableList where c.SKNO == viewro.SKNO select c;

                var dmtableSingleDatatable = EnumerableExtension.ListToDataTable (dmtablesinglelist.ToList(), 
                    sktable07Viewro.SKNO.ToString(CultureInfo.InvariantCulture)); // 将list转换成datatable
 
                courseBriefcase.AddTable(dmtableSingleDatatable);

                _waitform.Invoke (new MethodInvoker (( ) => _waitform.Increase(1))); // 每次下载都在进度条上加1
            }

            courseBriefcase.WriteBriefcase(); // 保存将对briefcase的更改写入硬盘

            var classInfoTable = courseBriefcase.FindTable("ClassInfo");

            //以下注释的代码作为参考用.
            //courseInfoTable.Columns.Add ("上课编号", typeof (string));

            //courseInfoTable.Columns.Add ("上课日期", typeof (string));

            //courseInfoTable.Columns.Add ("上课状态", typeof (string));

            foreach (var sktable07Viewro in sktableList) {

                var viewro = sktable07Viewro;//resharper说要这么写

                var classInfoRow = classInfoTable.NewRow();//新建一行

                classInfoRow["上课编号"] = viewro.SKNO.ToString(CultureInfo.InvariantCulture);//指定这一行的上课编号

                classInfoRow["上课日期"] = viewro.YDSKDATE.ToString();//指定这一行的上课日期
                
                if (viewro.SKZT == 0) {//将上课状态转换成文字

                    classInfoRow["上课状态"] = "未签到";
                }
                else {

                    classInfoRow["上课状态"] = "已签到";
                }

                classInfoTable.Rows.Add(classInfoRow);//将这一行加到datatable里
            }

            courseBriefcase.AddTable(classInfoTable);//将datatable加到briefcase里

            courseBriefcase.WriteBriefcase();

            _waitform.Invoke (new MethodInvoker (( ) => _waitform.Close()));//关闭进度窗口
        }

        /// <summary>
        /// 保存上课表 并更新PropertiesBriefcase中的上课状态.
        /// </summary>
        /// <param name="kkno"></param>
        public static void SaveSkTable(long kkno , long skno , SKTABLE_07_VIEW skRecord) {

            var fDataModule = new DataModule();

            var sktable = from c in fDataModule.GetSktable07Viewro () where c.KKNO == kkno select c; // 拉取上课表

            var sktableList = sktable.ToList ();

            var courseBriefcase = BriefcaseControl.GetBriefcase ( kkno );

            var skdatatable = courseBriefcase.FindTable ( "SKTABLE" ); //将上课表转换成datatable

            var skDatarow = skdatatable.Select ( string.Format ( "SKNO = {0}", skno ) );

            skDatarow.First().BeginEdit();

            skDatarow.First()["EDITMANNO"] = skRecord.EDITMANNO;

            skDatarow.First ()["EDITDATE"] = skRecord.EDITDATE;

            skDatarow.First ()["DMFS"] = skRecord.DMFS;

            skDatarow.First ()["CDRS"] = skRecord.CDRS;

            skDatarow.First ()["ZCRS"] = skRecord.ZCRS;

            skDatarow.First ()["ZTRS"] = skRecord.ZTRS;

            skDatarow.First ()["KKRS"] = skRecord.KKRS;

            skDatarow.First ()["SKDATE"] = skRecord.SKDATE;

            skDatarow.First ()["XKDATE"] = skRecord.XKDATE;

            skDatarow.First().EndEdit();

            skdatatable = EnumerableExtension.ListToDataTable ( skdatatable.ToList<SKTABLE_07_VIEW> ()  , "SKTABLE");
            
            courseBriefcase.AddTable ( skdatatable );

            courseBriefcase.WriteBriefcase();

            var classInfoTable = OfflineDataControl.GetClassInfoTable(kkno);

            //var classInfoTable = courseBriefcase.FindTable("ClassInfo");

            var classInfoRow = classInfoTable.Select(string.Format("上课编号='{0}'", skno));

            classInfoRow.First().BeginEdit();
            classInfoRow.First()["上课状态"] = "已签到";

            classInfoRow.First().EndEdit();

            courseBriefcase.AddTable ( classInfoTable );

            courseBriefcase.WriteBriefcase();

            //todo:改PropertiesBriefcase!!!!
            //foreach (DataRow sktableRow in skdatatable.Rows) {

            //    if ((Int16)sktableRow["SKZT"] == 3)
            //        continue;

            //    var index = sktableList.FindIndex(a => a.SKNO == (long) sktableRow["SKNO"]);

            //    sktableRow.BeginEdit();
            //    sktableRow[["ZTRS"]]

            //}

            //courseBriefcase.AddTable (skdatatable); // 将datatable写入briefcase中

            //var ttttt = courseBriefcase.FindTable("SKTABLE");

            //courseBriefcase.WriteBriefcase (); // 写入硬盘


            ////刷新PropertiesBriefcase

            //RefreshClassInfoTable(courseBriefcase , sktableList);

        }


        /// <summary>
        /// 刷新上课表 可用于下载数据时的操作.
        /// </summary>
        /// <param name="courseBriefcase">skno对应的Briefcase</param>
        /// <param name="sktableList">上课表对应的List</param>
        public static void RefreshClassInfoTable ( FileBriefcase courseBriefcase, IEnumerable<SKTABLE_07_VIEW> sktableList ) {

            var classInfoTable = courseBriefcase.FindTable ("ClassInfo");

            classInfoTable.Rows.Clear();

            //以下注释的代码作为参考用.
            //courseInfoTable.Columns.Add ("上课编号", typeof (string));

            //courseInfoTable.Columns.Add ("上课日期", typeof (string));

            //courseInfoTable.Columns.Add ("上课状态", typeof (string));

            foreach (var sktable07Viewro in sktableList) {

                var viewro = sktable07Viewro;//resharper说要这么写

                var classInfoRow = classInfoTable.NewRow ();//新建一行

                classInfoRow["上课编号"] = viewro.SKNO.ToString (CultureInfo.InvariantCulture);//指定这一行的上课编号

                classInfoRow["上课日期"] = viewro.YDSKDATE.ToString ();//指定这一行的上课日期

                if (viewro.SKZT == 0) {//将上课状态转换成文字

                    classInfoRow["上课状态"] = "未签到";
                } else {

                    classInfoRow["上课状态"] = "已签到";
                }

                classInfoTable.Rows.Add (classInfoRow);//将这一行加到datatable里
            }

            courseBriefcase.AddTable (classInfoTable);//将datatable加到briefcase里

            courseBriefcase.WriteBriefcase ();

        }

        /// <summary>
        /// 刷新学生信息
        /// </summary>
        /// <param name="skno"></param>
        public static void RefreshStudentInformation(long skno) {
            
            //todo:完成 刷新学生信息 方法

        }

    }
}
