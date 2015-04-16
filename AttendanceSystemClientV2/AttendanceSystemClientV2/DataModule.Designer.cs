namespace AttendanceSystemClientV2
{
    partial class DataModule
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.clientChannel = new RemObjects.SDK.IpHttpClientChannel();
            this.message = new RemObjects.SDK.BinMessage();
            this.remoteService = new RemObjects.SDK.RemoteService(this.components);
            this.dataStreamer = new RemObjects.DataAbstract.Bin2DataStreamer(this.components);
            this.remoteDataAdapter = new RemObjects.DataAbstract.Linq.LinqRemoteDataAdapter(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.remoteDataAdapter)).BeginInit();
            // 
            // clientChannel
            // 
            this.clientChannel.Password = "";
            this.clientChannel.TargetUrl = "http://172.16.120.3:7099/bin";
            this.clientChannel.TimeoutEnabled = false;
            this.clientChannel.UserName = "";
            this.clientChannel.OnTransferStart += new RemObjects.SDK.TransferStartEventHandler(this.clientChannel_OnTransferStart);
            this.clientChannel.OnTransferEnd += new RemObjects.SDK.TransferEndEventHandler(this.clientChannel_OnTransferEnd);
            this.clientChannel.OnTransferProgress += new RemObjects.SDK.TransferProgressEventHandler(this.clientChannel_OnTransferProgress);
            this.clientChannel.OnLoginNeeded += new RemObjects.SDK.LoginNeededEventHandler(this.ClientChannel_OnLoginNeeded);
            // 
            // message
            // 
            this.message.ContentType = "application/octet-stream";
            this.message.SerializerInstance = null;
            // 
            // remoteService
            // 
            this.remoteService.Channel = this.clientChannel;
            this.remoteService.CloneMessage = true;
            this.remoteService.Message = this.message;
            this.remoteService.ServiceName = "DataService";
            // 
            // dataStreamer
            // 
            this.dataStreamer.SendReducedDelta = false;
            // 
            // remoteDataAdapter
            // 
            this.remoteDataAdapter.DataRequestCall.MethodName = "GetData";
            this.remoteDataAdapter.DataRequestCall.Parameters.Clear();
            this.remoteDataAdapter.DataRequestCall.Parameters.Add("aTableNameArray", "StringArray", RemObjects.SDK.ParameterDirection.In);
            this.remoteDataAdapter.DataRequestCall.Parameters.Add("aTableRequestInfoArray", "TableRequestInfoArray", RemObjects.SDK.ParameterDirection.In);
            this.remoteDataAdapter.DataRequestCall.Parameters.Add("Result", "Binary", RemObjects.SDK.ParameterDirection.Result);
            this.remoteDataAdapter.DataRequestCall.OutgoingTableNamesParameter = "aTableNameArray";
            this.remoteDataAdapter.DataRequestCall.IncomingDataParameter = "Result";
            this.remoteDataAdapter.DataStreamer = this.dataStreamer;
            this.remoteDataAdapter.DataUpdateCall.MethodName = "UpdateData";
            this.remoteDataAdapter.DataUpdateCall.Parameters.Clear();
            this.remoteDataAdapter.DataUpdateCall.Parameters.Add("aDelta", "Binary", RemObjects.SDK.ParameterDirection.In);
            this.remoteDataAdapter.DataUpdateCall.Parameters.Add("Result", "Binary", RemObjects.SDK.ParameterDirection.Result);
            this.remoteDataAdapter.DataUpdateCall.OutgoingDeltaParameter = "aDelta";
            this.remoteDataAdapter.DataUpdateCall.IncomingDeltaParameter = "Result";
            this.remoteDataAdapter.LoginString = null;
            this.remoteDataAdapter.Password = null;
            this.remoteDataAdapter.RemoteService = this.remoteService;
            this.remoteDataAdapter.SchemaCall.MethodName = "GetSchema";
            this.remoteDataAdapter.SchemaCall.Parameters.Clear();
            this.remoteDataAdapter.SchemaCall.Parameters.Add("aFilter", "String", RemObjects.SDK.ParameterDirection.In);
            this.remoteDataAdapter.SchemaCall.Parameters.Add("Result", "String", RemObjects.SDK.ParameterDirection.Result);
            this.remoteDataAdapter.SchemaCall.IncomingSchemaParameter = "Result";
            this.remoteDataAdapter.ScriptProvider = null;
            this.remoteDataAdapter.TargetUrl = null;
            this.remoteDataAdapter.UseDynamicWhere = false;
            this.remoteDataAdapter.UserName = null;
            ((System.ComponentModel.ISupportInitialize)(this.remoteDataAdapter)).EndInit();

        }

        #endregion

        private RemObjects.SDK.IpHttpClientChannel clientChannel;
        private RemObjects.SDK.BinMessage message;
        private RemObjects.SDK.RemoteService remoteService;
        private RemObjects.DataAbstract.Bin2DataStreamer dataStreamer;
        private RemObjects.DataAbstract.Linq.LinqRemoteDataAdapter remoteDataAdapter;
    }
}
