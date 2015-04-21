using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using AttendanceSystemClientV2.PC;
using AttendanceSystemClientV2.UserInterface;
using RemObjects.SDK;
using RemObjects.DataAbstract;
using RemObjects.DataAbstract.Linq;

namespace AttendanceSystemClientV2 {
    public partial class DataModule : Component {
        #region Constants
        private const String RelativityConnectionString = @"User Id=""{0}"";Password=""{1}"";Domain=""{2}"";Schema=""{3}""";
        #endregion

        #region PrivateFields

        private WaitForm _waitForm; // 进度显示窗口

        private delegate bool IncreaseHandle ( int value ); //进度窗口  委托 增加数值 

        private delegate bool SetHandle ( int value );//进度窗口 委托 设置数值

        private IncreaseHandle _increaseHandle; //声明 增加数值 委托 （进度窗口）

        private SetHandle _setHandle;//声明 设置数值 委托（进度窗口）

        private string operation = "";//操作名称

        private long current;//当前数据大小

        private long total;//已经传输的大小

        #endregion

        #region Constructors
        public DataModule ( ) {
            this.InitializeComponent ();
            this.message.ClientID = Guid.NewGuid ();

            // Loading Relativity Domain and DomainSchema names from the
            // application settings
            this.DomainName = Properties.Settings.Default.Domain;
            this.SchemaName = Properties.Settings.Default.Schema;

            this.IsLoggedOn = false;

        }

        public DataModule ( IContainer container )
            : this () {
            if (container != null)
                container.Add (this);
        }
        #endregion

        #region Properties
        public RemObjects.DataAbstract.Linq.LinqRemoteDataAdapter DataAdapter {
            get {
                return this.remoteDataAdapter;
            }
        }

        public String DomainName { get; protected set; }

        public String SchemaName { get; protected set; }

        public Boolean IsLoggedOn { get; protected set; }

        public String UserId { get; protected set; }
        #endregion



        #region DataModule Events
        private void ClientChannel_OnLoginNeeded ( object sender, LoginNeededEventArgs e )//如果 fdatamodule需要登录，将会调用此函数。
        {
            // 登录操作

            if ((!string.IsNullOrEmpty (Properties.Settings.Default.Password)) &&
                this.LogOn (Properties.Settings.Default.UserId, Properties.Settings.Default.Password))//密码不为空 并且登录成功
            {
                e.Retry = true;
                e.LoginSuccessful = true;
                return;
            }

            //下面为一次登录失败时的情况。
            //String lUserId;
            //String lPassword;

            ////登录失败时的情况
            //MessageBox.Show("登录失败 请重试");
            //using (var lLoginForm = new LogOnForm())
            //{
            //    if (lLoginForm.ShowDialog() != DialogResult.OK)//若用户点击了取消
            //    {
            //        return;
            //    }
            //    lUserId = lLoginForm.UserId;
            //    lPassword = lLoginForm.Password;
            //}

            //if (this.LogOn(lUserId, lPassword))
            //{
            //    e.Retry = true;
            //    e.LoginSuccessful = true;
            //}
            //else
            //    MessageBox.Show("登录失败");

            //Properties.Settings.Default.UserId = "";//拉取数据时需要获取ID 所以这个字段不能被删除。

            Properties.Settings.Default.Password = "";//清楚保存的密码

            Properties.Settings.Default.Save ();//清空用户名和密码并保存

        }
        #endregion

        #region LogOn/LogOff Handling
        public Boolean LogOn ( String userId, String password ) {

            // Note that if your application will use more than 1 Schema in this Domain you should
            // make this Schema active before retrieving data (see the SetActiveSchema method)

            if (String.IsNullOrEmpty (userId))
                return false;

            this.IsLoggedOn = (new RemObjects.DataAbstract.Server.BaseLoginService_Proxy (this.message, this.clientChannel, "LoginService"))
                                                            .LoginEx (String.Format (DataModule.RelativityConnectionString, userId, password, this.DomainName, this.SchemaName));
            if (IsLoggedOn)
                UserId = userId;

            return IsLoggedOn;
        }

        public void LogOff ( ) {
            if (!IsLoggedOn) return;

            (new RemObjects.DataAbstract.Server.BaseLoginService_Proxy (message, clientChannel, "LoginService")).Logout ();

            IsLoggedOn = false;
        }
        #endregion

        #region Selecting Schema
        public void SetActiveSchema ( String schemaName ) {
            this.remoteService.ServiceName = "DataService." + schemaName;

            this.SchemaName = schemaName;
        }

        #endregion

        #region PublicMethods

        /// <summary>
        /// 获取jsnadkkviewro视图 该函数不会立即拉取数据(延迟加载).
        /// </summary>
        /// <returns>jsnadkkviewro视图(延迟加载)</returns>
        public RemoteTable<JSANDKKVIEWRO> GetJsandkkviewro() {

            return remoteDataAdapter.GetTable<JSANDKKVIEWRO>();

        }

        /// <summary>
        /// 获取XKTABLE_VIEWRO视图 该函数不会立即拉取数据(延迟加载).
        /// </summary>
        /// <returns>XKTABLE_VIEWRO视图(延迟加载)</returns>
        public RemoteTable<XKTABLE_VIEWRO> GetxktableViewros() {
            return remoteDataAdapter.GetTable<XKTABLE_VIEWRO>();
        }
        

        /// <summary>
        /// 获取GetsSktable07Viewro视图 该函数不会立即拉取数据(延迟加载).
        /// </summary>
        /// <returns>GetsSktable07Viewro视图(延迟加载)</returns>
        public RemoteTable<SKTABLE_07_VIEWRO> GetSktable07Viewro  ( ) {
            return remoteDataAdapter.GetTable<SKTABLE_07_VIEWRO> ();
        }

        /// <summary>
        /// 获取点名表
        /// </summary>
        /// <returns></returns>
        public RemoteTable<DMTABLE_08_NOPIC_VIEW> GetdmTable() {
            return remoteDataAdapter.GetTable<DMTABLE_08_NOPIC_VIEW>();
        }

        public RemoteTable<BJTABLE_09_VIEWRO> GetBjTable() {

            return remoteDataAdapter.GetTable<BJTABLE_09_VIEWRO>();

        } 

        public int Getdata ( ) {
            //测试代码
            new Thread (( ) => {
                try {
                    IQueryable<DMTABLE_08_NOPIC_VIEW> ttt = from c in remoteDataAdapter.GetTable<DMTABLE_08_NOPIC_VIEW> ()
                                                            where c.KKNO == 20131232
                                                            select c;

                    foreach (var dmtable08NopicView in ttt) {
                        MessageBox.Show (dmtable08NopicView.KKNAME);
                    }


                } catch (RemObjects.SDK.Exceptions.SessionNotFoundException) {

                    MessageBox.Show ("登录失败 请重新登录");
                }
            }).Start ();

            return -1;
            
        }
        #endregion

        #region PrivateMethods

        

        private void CloseWaitForm ( ) {
            _waitForm.BeginInvoke(new MethodInvoker(() => { _waitForm.Close(); }));
        }

        #endregion

        private void clientChannel_OnTransferProgress ( object sender, TransferProgressEventArgs e ) {


        }

        private void clientChannel_OnTransferEnd ( object sender, TransferEndEventArgs e ) {
            

        }

        private void clientChannel_OnTransferStart ( object sender, TransferStartEventArgs e ) {

            
        }
        
    }
}