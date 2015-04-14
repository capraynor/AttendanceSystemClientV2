using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AttendanceSystemClientV2.PC;
using RemObjects.SDK;
using RemObjects.DataAbstract;
using RemObjects.DataAbstract.Linq;

namespace AttendanceSystemClientV2 {
    public partial class DataModule : Component {
        #region Constants
        private const String RelativityConnectionString = @"User Id=""{0}"";Password=""{1}"";Domain=""{2}"";Schema=""{3}""";
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

        public void Getdata ( ) {
            //测试代码

            try {
                IQueryable<JSANDKKVIEWRO> ttt = remoteDataAdapter.GetTable<JSANDKKVIEWRO> ();

                ttt.Count ();
            } catch (RemObjects.SDK.Exceptions.SessionNotFoundException) {

                MessageBox.Show ("登录失败 请重新登录");
            }


        }

        #endregion

        private void clientChannel_OnTransferProgress ( object sender, TransferProgressEventArgs e ) {
            //正在传输数据的时候触发
            MessageBox.Show (e.Current.ToString ());
        }

        private void clientChannel_OnTransferEnd ( object sender, TransferEndEventArgs e ) {
            //结束数据传输时触发
            MessageBox.Show ("End:" + e.TransferDirection);
        }

        private void clientChannel_OnTransferStart ( object sender, TransferStartEventArgs e ) {
            //开始传输数据时触发
            MessageBox.Show ("Total:" + e.Total);
        }
    }
}