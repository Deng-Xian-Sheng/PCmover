using System;
using System.Collections.Generic;
using System.ServiceModel;
using Laplink.Download.Contracts;
using PCmover.Infrastructure;

namespace ClientEngineModule.Wcf
{
	// Token: 0x02000004 RID: 4
	[CallbackBehavior(IncludeExceptionDetailInFaults = true, UseSynchronizationContext = false, ValidateMustUnderstand = true, ConcurrencyMode = ConcurrencyMode.Reentrant)]
	public class DownloadControlCallback : DownloadMonitorCallback, IDownloadControlCallback, IDownloadMonitorCallback
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002278 File Offset: 0x00000478
		public DownloadControlCallback(PCmoverEngineLive engine)
		{
			this._engine = engine;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002287 File Offset: 0x00000487
		public void TimeToReboot()
		{
			this._engine.EventAggregator.GetEvent<DownloadManagerEvents.DownloadManagerRebootRequiredEvent>().Publish();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000229E File Offset: 0x0000049E
		public void PackageUpdated(DownloadPackage package)
		{
			this._engine.EventAggregator.GetEvent<DownloadManagerEvents.PackageUpdatedEvent>().Publish(package);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000022B6 File Offset: 0x000004B6
		public void DownloadCompleted(bool restart)
		{
			this._engine.EventAggregator.GetEvent<DownloadManagerEvents.DownloadManagerCompletedEvent>().Publish(restart);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000022CE File Offset: 0x000004CE
		public void DisplayDownloadError(IEnumerable<string> FailedPackages)
		{
			this._engine.EventAggregator.GetEvent<DownloadManagerEvents.DownloadManagerDisplayErrorEvent>().Publish(FailedPackages);
		}

		// Token: 0x04000002 RID: 2
		protected PCmoverEngineLive _engine;
	}
}
