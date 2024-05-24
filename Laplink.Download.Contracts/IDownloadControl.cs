using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using Laplink.Service.Contracts;

namespace Laplink.Download.Contracts
{
	// Token: 0x02000009 RID: 9
	[ServiceContract(Namespace = "http://laplink.com/services/downloadcontracts/v2.0056", SessionMode = SessionMode.Required, CallbackContract = typeof(IDownloadControlCallback))]
	public interface IDownloadControl : IDownloadMonitor, IDownloadQuery
	{
		// Token: 0x06000029 RID: 41
		[OperationContract(Name = "BecomeControllerDownload")]
		bool BecomeController(CallbackState controlCallbackState);

		// Token: 0x0600002A RID: 42
		[OperationContract(Name = "StopBeingControllerDownload")]
		void StopBeingController();

		// Token: 0x0600002B RID: 43
		[OperationContract(Name = "ConfigureControlCallbacksDownload")]
		void ConfigureControlCallbacks(CallbackState controlCallbackState);

		// Token: 0x0600002C RID: 44
		[OperationContract]
		void PerformPendingReboot();

		// Token: 0x0600002D RID: 45
		[OperationContract]
		ObservableCollection<DownloadPackage> GetDownloadPackages();

		// Token: 0x0600002E RID: 46
		[OperationContract]
		void CancelPackage(string Id);

		// Token: 0x0600002F RID: 47
		[OperationContract]
		void ProcessAll();

		// Token: 0x06000030 RID: 48
		[OperationContract]
		void SetDataFile(string DataFile);

		// Token: 0x06000031 RID: 49
		[OperationContract]
		void UpdateRunKey(string ValueName, string Value, bool Remove);
	}
}
