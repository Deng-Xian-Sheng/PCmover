using System;
using System.ServiceModel;
using Laplink.Service.Contracts;

namespace Laplink.Download.Contracts
{
	// Token: 0x0200000B RID: 11
	[ServiceContract(Namespace = "http://laplink.com/services/downloadcontracts/v2.0056", SessionMode = SessionMode.Required, CallbackContract = typeof(IDownloadMonitorCallback))]
	public interface IDownloadMonitor : IDownloadQuery
	{
		// Token: 0x06000036 RID: 54
		[OperationContract(Name = "ConfigureMonitorCallbacksDownload")]
		void ConfigureMonitorCallbacks(CallbackState monitorCallbackState);
	}
}
