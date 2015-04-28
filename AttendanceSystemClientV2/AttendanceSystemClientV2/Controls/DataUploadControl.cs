using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AttendanceSystemClientV2.Helpers;
using AttendanceSystemClientV2.Models;
using AttendanceSystemClientV2.PC;

namespace AttendanceSystemClientV2.Controls {
    /// <summary>
    /// 用于提供上传数据时操作的类。
    /// </summary>
    public static class DataUploadControl {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kkno">开课编号</param>
        /// <param name="kkName">开课名称</param>
        /// <param name="skno">上课编号</param>
        /// <param name="dateTime">上课时间</param>
        /// <returns></returns>
        public static string GenerateConfirmString(long kkno ,string kkName , long skno , string dateTime) {

            const string basestring = "开课编号:{0}\n开课名称:{1}\n上课时间:{2}\n";

            return string.Format (basestring, kkno, kkName, dateTime);

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
            var dmList = OfflineDataControl.GetDmtable(kkno, skno); // 这已经是List了... 我干了什么...

            var fDataModule = new DataModule();

            foreach (var dmlistRecord in dmList) {

                dmlistRecord.POSTDATE = DateTime.Now;

                dmlistRecord.POSTMANNO = Convert.ToInt64(Properties.Settings.Default.UserId);

                if (dmlistRecord.DKZT == 5)//如果是未签到 将其改成旷课
                    dmlistRecord.DKZT = 3;
                
                fDataModule.UpdateDmRow(dmlistRecord);

            }

            fDataModule.ApplyChanges();

            var skrecord = fDataModule.GSktable07Record(skno);// 将来需要把这个拿来更新上课表

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

            fDataModule.UpdateSkTableRow(skrecord); // 上传上课信息.

            fDataModule.ApplyChanges();

        }



    }
}
