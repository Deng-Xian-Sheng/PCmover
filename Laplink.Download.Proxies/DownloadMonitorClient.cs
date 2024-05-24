using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Laplink.Download.Contracts;
using Laplink.Service.Contracts;

namespace Laplink.Download.Proxies
{
	// Token: 0x02000003 RID: 3
	public class DownloadMonitorClient<TChannel> : DuplexClientBase<TChannel>, IDownloadMonitor, IDownloadQuery where TChannel : class, IDownloadMonitor
	{
		// Token: 0x0600000C RID: 12 RVA: 0x000020E1 File Offset: 0x000002E1
		public DownloadMonitorClient(InstanceContext callbackInstance, Binding binding, EndpointAddress remoteAddress) : base(callbackInstance, binding, remoteAddress)
		{
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000020EC File Offset: 0x000002EC
		public DownloadMonitorClient(InstanceContext callbackInstance, string endpointConfigurationName) : base(callbackInstance, endpointConfigurationName)
		{
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000020F6 File Offset: 0x000002F6
		public void CloseOrAbort()
		{
			if (base.State == CommunicationState.Faulted)
			{
				base.Abort();
				return;
			}
			base.Close();
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000210E File Offset: 0x0000030E
		public void ConfigureMonitorCallbacks(CallbackState monitorCallbackState)
		{
			base.Channel.ConfigureMonitorCallbacks(monitorCallbackState);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002121 File Offset: 0x00000321
		public DownloadStatusInfo GetDownloadStatus()
		{
			return base.Channel.GetDownloadStatus();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002133 File Offset: 0x00000333
		public Version GetDownloadVersion()
		{
			return base.Channel.GetDownloadVersion();
		}
	}
}
