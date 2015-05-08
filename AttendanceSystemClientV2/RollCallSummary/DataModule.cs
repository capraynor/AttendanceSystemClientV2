using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using RemObjects.SDK;
using RemObjects.DataAbstract;
using RemObjects.DataAbstract.Linq;
using RollCallSummary.PC;

namespace RollCallSummary
{
    public partial class DataModule : Component
    {
        #region Constants
        private const String RelativityConnectionString = @"User Id=""{0}"";Password=""{1}"";Domain=""{2}"";Schema=""{3}""";
        #endregion

        #region Constructors
        public DataModule()
        {
            this.InitializeComponent();
            this.message.ClientID = Guid.NewGuid();

            // Loading Relativity Domain and DomainSchema names from the
            // application settings
            this.DomainName = Properties.Settings.Default.Domain;
            this.SchemaName = Properties.Settings.Default.Schema;

            this.IsLoggedOn = false;
        }

        public DataModule(IContainer container)
            : this()
        {
            if (container != null)
                container.Add(this);
        }
        #endregion

        #region Properties
        public RemObjects.DataAbstract.Linq.LinqRemoteDataAdapter DataAdapter
        {
            get
            {
                return this.remoteDataAdapter;
            }
        }

        public String DomainName { get; protected set; }
        
        public String SchemaName { get; protected set; }

        public Boolean IsLoggedOn { get; protected set; }

        public String UserId { get; protected set; }
        #endregion

        #region DataModule Events
        private void ClientChannel_OnLoginNeeded(object sender, LoginNeededEventArgs e)
        {
            // Performing login
            if (this.LogOn(Properties.Settings.Default.UserId, Properties.Settings.Default.Password))
            {
                e.Retry = true;
                e.LoginSuccessful = true;
                return;
            }

            String lUserId;
            String lPassword;

            using (LogOnForm lLoginForm = new LogOnForm())
            {
                if (lLoginForm.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Login cancelled");
                    return;
                }
                lUserId = lLoginForm.UserId;
                lPassword = lLoginForm.Password;
            }

            if (this.LogOn(lUserId, lPassword))
            {
                e.Retry = true;
                e.LoginSuccessful = true;
            }
            else
                MessageBox.Show("Login failed");
        }
        #endregion

        #region LogOn/LogOff Handling
        public Boolean LogOn(String userId, String password)
        {
            // Note that if your application will use more than 1 Schema in this Domain you should
            // make this Schema active before retrieving data (see the SetActiveSchema method)

            if (String.IsNullOrEmpty(userId))
                return false;

            this.IsLoggedOn = (new RemObjects.DataAbstract.Server.BaseLoginService_Proxy(this.message, this.clientChannel, "LoginService"))
                                                            .LoginEx(String.Format(DataModule.RelativityConnectionString, userId, password, this.DomainName, this.SchemaName));
            if (this.IsLoggedOn)
                this.UserId = userId;

            return this.IsLoggedOn;
        }

        public void LogOff()
        {
            if (this.IsLoggedOn)
            {
                (new RemObjects.DataAbstract.Server.BaseLoginService_Proxy(message, clientChannel, "LoginService")).Logout();
                this.IsLoggedOn = false;
            }
        }
        #endregion

        #region Selecting Schema
        public void SetActiveSchema(String schemaName)
        {
            this.remoteService.ServiceName = "DataService." + schemaName;
            this.SchemaName = schemaName;
        }
        #endregion

        public IEnumerable<BJTABLE_09_VIEWRO> GetBjTable(){

            return remoteDataAdapter.GetTable<BJTABLE_09_VIEWRO>();

        }

        public IEnumerable<XSTABLE_01_VIEW> GetXsTable(){

            return remoteDataAdapter.GetTable<XSTABLE_01_VIEW> ();

        }

        public IEnumerable<DMTABLE_08_NOPIC_VIEW> GetDmTable(){
            return remoteDataAdapter.GetTable<DMTABLE_08_NOPIC_VIEW>();
        }

        public IEnumerable<SKTABLE_07_VIEWRO> GetSkTable(){

            return remoteDataAdapter.GetTable<SKTABLE_07_VIEWRO>();

        }

        public IEnumerable<JSANDKKVIEWRO> GetKktable05Viewros(){

            return remoteDataAdapter.GetTable<JSANDKKVIEWRO> ();

        } 
    }
}