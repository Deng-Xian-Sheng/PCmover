using System;
using System.ServiceModel;
using Laplink.Download.Contracts;

namespace ClientEngineModule.Wcf
{
	// Token: 0x02000005 RID: 5
	[CallbackBehavior(IncludeExceptionDetailInFaults = true, UseSynchronizationContext = false, ValidateMustUnderstand = true, ConcurrencyMode = ConcurrencyMode.Reentrant)]
	public class DownloadMonitorCallback : IDownloadMonitorCallback
	{
		// Token: 0x0600000D RID: 13 RVA: 0x000022E6 File Offset: 0x000004E6
		public void DownloadStatusChanged(DownloadStatusInfo statusInfo)
		{
		}
	}
}
