using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceSystemClientV2.Helpers;
using AttendanceSystemClientV2.Models;
using AttendanceSystemClientV2.PC;
using AttendanceSystemClientV2.UserInterface;
using Telerik.WinControls.UI;

namespace AttendanceSystemClientV2.Controls {
    /// <summary>
    /// 用于提供上传数据时操作的类。
    /// </summary>
    public static class DataUploadControl {

        private static WaitForm _waitForm;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="kkno">开课编号</param>
        /// <param name="kkName">开课名称</param>
        /// <param name="skno">上课编号</param>
        /// <param name="dateTime">上课时间</param>
        /// <returns></returns>
        public static string GenerateConfirmString(long kkno ,string kkName , long skno , string dateTime) {

            const string basestring = "开课编号:{0}\n开课名称:{1}\n上课时间:{2}\n正常到课:{3} 迟到:{4} 旷课:{5} 早退:{6} ";

            var dmList = OfflineDataControl.GetDmtable (kkno, skno); // 这已经是List了... 我干了什么...

            var ztrs = OfflineDataControl.CountLeaveEarlyStudent (dmList);

            var zcrs = OfflineDataControl.CountNormalStudent (dmList);

            var cdrs = OfflineDataControl.CountLateStudent (dmList);

            var kkrs = OfflineDataControl.CountAbsentStudent (dmList);

            return string.Format (basestring, kkno, kkName, dateTime , zcrs , cdrs , kkrs, ztrs);

        }

        /// <summary>
        /// 上传一节课.
        /// </summary>
        /// <param name="kkno">开课编号</param>
        /// <param name="skno">上课编号</param>
        public static void UploadOneClass(long kkno, long skno) {
            
            //1.根据KKNo找到本地的Briefcase. 因为之前都查过了 所以这里就不用做Briefcase的检查了.  直接拉Briefcase过来饥渴.
            //2.根据skno在Briefcase中获取点名表和上课表.
            //3.对于上课表的更改, 直接在服务器上找到那节课对应的记录 然后改 然后上传即可.
            //4.todo:如果需要更新指纹信息,则需要再开启一个函数,用来更新指纹信息.
            
            //下面这个东西直接往数据库里塞就行

            var fDataModule = new DataModule ();



            try {

                var verifyList =  from c in fDataModule.GetJsandkkviewro() where c.KKNO == kkno select c;

                verifyList.Count(); // 败笔.  数一下就知道登录是否正确了.
            } catch (RemObjects.SDK.Exceptions.SessionNotFoundException) {

                MsgBox.ShowMsgBoxDialog("登录异常");

            }

            var dmList = OfflineDataControl.GetDmtable(kkno, skno); // 这已经是List了... 我干了什么...

            MsgBox.ShowMsgBoxDialog(fDataModule.IsLoggedOn.ToString());

            foreach (var dmlistRecord in dmList) {

                dmlistRecord.POSTDATE = DateTime.Now;

                dmlistRecord.POSTMANNO = Convert.ToInt64(Properties.Settings.Default.UserId);

                if (dmlistRecord.DKZT == 5)//如果是未签到 将其改成旷课
                    dmlistRecord.DKZT = 3;
                
                fDataModule.UpdateDmRow(dmlistRecord);

            }

            _waitForm = new WaitForm ("准备上传点名信息");

            new Thread(() => {

                Thread.Sleep(1000);

                _waitForm.BeginInvoke(new MethodInvoker(() => {

                    _waitForm.SetInfo("正在上传点名信息");

                    _waitForm.SetValue(30);

                }));

                fDataModule.ApplyChanges (); //需要将该操作放到线程中.

                _waitForm.BeginInvoke(new MethodInvoker(() => {
                    
                    _waitForm.SetInfo("点名信息上传完成");

                    _waitForm.SetValue (45);

                    _waitForm.Close(); // 关闭进度条框

                }));

            }).Start();

            _waitForm.ShowDialog();

            var skrecordList = OfflineDataControl.GetSktable(kkno);// 将来需要把这个拿来更新上课表

            var skrecord = (from c in skrecordList where c.SKNO == skno select c).First(); // linq  完了以后把第一条记录取出来(一共就有一条记录.)

            var ztrs = OfflineDataControl.CountLeaveEarlyStudent(dmList);
            
            var zcrs = OfflineDataControl.CountNormalStudent(dmList);

            var cdrs = OfflineDataControl.CountLateStudent(dmList);

            var kkrs = OfflineDataControl.CountAbsentStudent(dmList);

            skrecord.ZTRS = Convert.ToInt16(ztrs); // 设置早退人数

            skrecord.ZCRS = Convert.ToInt16(zcrs); // 设置正常出勤人数

            skrecord.KKRS = Convert.ToInt16(kkrs); // 设置旷课人数

            skrecord.CDRS = Convert.ToInt16(cdrs);//设置迟到人数

            skrecord.EDITDATE = DateTime.Now; // 设置编辑时间

            skrecord.EDITMANNO = Convert.ToInt64(Properties.Settings.Default.UserId); // 设置编辑人员ID
            
            skrecord.SKZT = 1;//已经点名

            skrecord.DMFS = 1;

            fDataModule.UpdateSkTableRow(skrecord); // 上传上课信息.

            fDataModule.ApplyChanges (); //需要将该操作放到线程中.

            //再下载一遍上课表 该操作将会刷新PropertiesBriefcase中的ClassInfo表.
            
            _waitForm = new WaitForm("正在同步课程信息");

            new Thread(() => {

                Thread.Sleep (1000);

                _waitForm.BeginInvoke (new MethodInvoker (( ) => _waitForm.SetValue (70)));

                DataDownloadControl.SaveSkTable (kkno , skno , skrecord);

                _waitForm.BeginInvoke (new MethodInvoker (( ) => _waitForm.Close()));
            }).Start();

            _waitForm.ShowDialog();

        }

    }
}
