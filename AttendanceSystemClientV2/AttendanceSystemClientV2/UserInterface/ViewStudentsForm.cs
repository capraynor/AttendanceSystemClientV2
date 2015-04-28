using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceSystemClientV2.Controls;
using AttendanceSystemClientV2.Helpers;
using AttendanceSystemClientV2.Models;
using AttendanceSystemClientV2.PC;
using RemObjects.DataAbstract;

namespace AttendanceSystemClientV2.UserInterface {

    /// <summary>
    ///用OfflineDataControl中的DmtableToDisplayTable 将点名表转换成可以用作绑定数据源的显示的表.
    ///用OFflineDataControl中的GetDmDatatable获取点名表
    ///用OfflineDataControl中的ChangeDmRecord更改Dmtable中的一条记录
    ///用OfflineDataControl中的SaveDmDatatable保存点名表.
    /// </summary>
    public partial class ViewStudentsForm : Form {

        private long skno;
        private long kkno;

        public ViewStudentsForm ( long kkno ,long skno) {

            InitializeComponent ();

            this.skno = skno;

            this.kkno = kkno;

            var dmTable = OfflineDataControl.GetDmDatatable(kkno , skno);

            if (dmTable == null) { 
                // 判断获取到的点名表是否为空
                //如果为空 则显示出上课编号和开课编号

                MsgBox.ShowMsgBoxDialog (string.Format ("数据有误 请将以下信息提供给维护人员:\n" +
                                                        "上课编号:{0}\n" +
                                                        "开课编号:{1}" , skno , kkno));

                Close();

                return;

            }

            var dmDisplayTable = OfflineDataControl.DmtableToDisplayTable(dmTable);

            studentsGridView.DataSource = dmDisplayTable;





            //调用一个或者几个函数函数 该函数应该:
            //1.传入 kkno  和 skno 返回该堂课的点名表
            //2.传入kkno和datatable 可以正常写入briefcase.
            //指纹点名的时候也应该这样.
            //这些函数应该在OfflineDataControl中.
        }

        private void returnBtn_Click ( object sender, EventArgs e ) {
            this.Close();
        }

        private void upBtn_Click ( object sender, EventArgs e ) {

            //调用dp_MoveUp来向上移动.

            dp_MoveUp();
            
        }


        private void downBtn_Click ( object sender, EventArgs e ) {

            dp_MoveDown();

        }

        /// <summary>
        /// 向上移动Gridview的光标 显示处理函数
        /// </summary>
        private void dp_MoveUp() {

            //获取已经选择的行
            var selectedRowIndex = studentsGridView.SelectedRows.First ().Index;

            //取消选中已经选择的行
            studentsGridView.Rows[selectedRowIndex].IsSelected = false;

            //获取当前Gridview的最大值
            var studentsGridViewMax = studentsGridView.Rows.Count;

            //如果向上移动不会越界的话
            if (0 <= (selectedRowIndex - 1)) {

                //那就移动
                studentsGridView.CurrentRow = studentsGridView.Rows[selectedRowIndex - 1];

            }
            else {

                //否则就滚到下面去
                studentsGridView.CurrentRow = studentsGridView.Rows[studentsGridViewMax - 1];
                //多么机智的注释啊哈哈
            }
        }



        /// <summary>
        /// 向下移动
        /// </summary>
        private void dp_MoveDown() {

            //获取已经选择的行
            var selectedRowIndex = studentsGridView.SelectedRows.First ().Index;

            //取消选中已经选择的行
            studentsGridView.Rows[selectedRowIndex].IsSelected = false;

            //获取当前Gridview的最大值
            var studentsGridViewMax = studentsGridView.Rows.Count;

            //如果向下移动不会越界的话
            if ((studentsGridViewMax-1) >= selectedRowIndex + 1) {

                //那就移动
                studentsGridView.CurrentRow = studentsGridView.Rows[selectedRowIndex + 1];

            }
            else {

                //否则就移动到最上方
                studentsGridView.CurrentRow = studentsGridView.Rows[0];

            }

        }

        private void changeToNormalBtn_Click ( object sender, EventArgs e ) {

            //先把Briefcase找出来
            var classBriefcase = BriefcaseControl.GetBriefcase(kkno);

            //然后把当前的学号找出来
            var studentId = Convert.ToString(studentsGridView.SelectedRows.First().Cells["学号"].Value);

            //然后更改当前的上课状态 显示的上课状态哦
            dp_ChangeDisplayStatus(sender);

            //然后获取点名表
            var dmTable = OfflineDataControl.GetDmDatatable(kkno, skno);

            //改点名表里的记录 这里改的就是数据了.
            OfflineDataControl.ChangeDmRecord(ref dmTable , studentId ,0 , DateTime.Now , 1);

            //存点名表.
            BriefcaseControl.SaveDmTable(classBriefcase, dmTable);
        }

        /// <summary>
        /// 更改一名上课学生的信息 这个函数应该在按钮的触发函数中使用. 将sender传进来
        /// </summary>
        /// <param name="sender">把按钮函数里的sender放进来 </param>
        private void dp_ChangeDisplayStatus(object sender) {

            if (sender == changeToNormalBtn) {
                //正常到课
                //todo 上传数据时 如果没有发现点名时间 则点名时间和上课时间相同.

                studentsGridView.SelectedRows.First ().Cells["签到状态"].Value = "正常到课";

            } else if (sender == changeToLateBtn) {

                //迟到
                studentsGridView.SelectedRows.First ().Cells["签到状态"].Value = "迟到";

            } else if (sender == changeToLeaveEarly) {

                //早退
                studentsGridView.SelectedRows.First ().Cells["签到状态"].Value = "早退";

            } else if (sender == changeToAbsentBtn) {

                //旷课
                studentsGridView.SelectedRows.First ().Cells["签到状态"].Value = "旷课";
            } else if (sender == changeToAskForLeaveBtn) {

                //请假
                studentsGridView.SelectedRows.First ().Cells["签到状态"].Value = "请假";

            }
            
            

        }

        private void changeToLateBtn_Click ( object sender, EventArgs e ) {

            //先把Briefcase找出来
            var classBriefcase = BriefcaseControl.GetBriefcase (kkno);

            //然后把当前的学号找出来
            var studentId = Convert.ToString (studentsGridView.SelectedRows.First ().Cells["学号"].Value);

            //然后更改当前的上课状态 显示的上课状态哦
            dp_ChangeDisplayStatus (sender);

            //然后获取点名表
            var dmTable = OfflineDataControl.GetDmDatatable (kkno, skno);

            //改点名表里的记录 这里改的就是数据了.
            OfflineDataControl.ChangeDmRecord (ref dmTable, studentId, 1, DateTime.Now, 1);

            //存点名表.
            BriefcaseControl.SaveDmTable (classBriefcase, dmTable);
        }

        private void changeToAskForLeaveBtn_Click ( object sender, EventArgs e ) {

            //先把Briefcase找出来
            var classBriefcase = BriefcaseControl.GetBriefcase (kkno);

            //然后把当前的学号找出来
            var studentId = Convert.ToString (studentsGridView.SelectedRows.First ().Cells["学号"].Value);

            //然后更改当前的上课状态 显示的上课状态哦
            dp_ChangeDisplayStatus (sender);

            //然后获取点名表
            var dmTable = OfflineDataControl.GetDmDatatable (kkno, skno);

            //改点名表里的记录 这里改的就是数据了.
            OfflineDataControl.ChangeDmRecord (ref dmTable, studentId, 4, DateTime.Now, 1);

            //存点名表.
            BriefcaseControl.SaveDmTable (classBriefcase, dmTable);

        }

        private void changeToAbsentBtn_Click ( object sender, EventArgs e ) {

            //先把Briefcase找出来
            var classBriefcase = BriefcaseControl.GetBriefcase (kkno);

            //然后把当前的学号找出来
            var studentId = Convert.ToString (studentsGridView.SelectedRows.First ().Cells["学号"].Value);

            //然后更改当前的上课状态 显示的上课状态哦
            dp_ChangeDisplayStatus (sender);

            //然后获取点名表
            var dmTable = OfflineDataControl.GetDmDatatable (kkno, skno);

            //改点名表里的记录 这里改的就是数据了.
            OfflineDataControl.ChangeDmRecord (ref dmTable, studentId, 3, DateTime.Now, 1);

            //存点名表.
            BriefcaseControl.SaveDmTable (classBriefcase, dmTable);

        }

        private void changeToLeaveEarly_Click ( object sender, EventArgs e ) {

            //先把Briefcase找出来
            var classBriefcase = BriefcaseControl.GetBriefcase (kkno);

            //然后把当前的学号找出来
            var studentId = Convert.ToString (studentsGridView.SelectedRows.First ().Cells["学号"].Value);

            //然后更改当前的上课状态 显示的上课状态哦
            dp_ChangeDisplayStatus (sender);

            //然后获取点名表
            var dmTable = OfflineDataControl.GetDmDatatable (kkno, skno);

            //改点名表里的记录 这里改的就是数据了.
            OfflineDataControl.ChangeDmRecord (ref dmTable, studentId, 2, DateTime.Now, 1);

            //存点名表.
            BriefcaseControl.SaveDmTable (classBriefcase, dmTable);

        }
        
    }
}
