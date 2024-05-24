using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Laplink.Download.Contracts;

namespace Laplink.Download.Proxies
{
	// Token: 0x02000004 RID: 4
	public class DownloadQueryClient : ClientBase<IDownloadQuery>, IDownloadQuery
	{
		// Token: 0x06000012 RID: 18 RVA: 0x00002145 File Offset: 0x00000345
		public DownloadQueryClient()
		{
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000214D File Offset: 0x0000034D
		public void CloseOrAbort()
		{
			if (base.State == CommunicationState.Faulted)
			{
				base.Abort();
				return;
			}
			base.Close();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002165 File Offset: 0x00000365
		public DownloadQueryClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000216F File Offset: 0x0000036F
		public DownloadStatusInfo GetDownloadStatus()
		{
			return base.Channel.GetDownloadStatus();
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000217C File Offset: 0x0000037C
		public Version GetDownloadVersion()
		{
			return base.Channel.GetDownloadVersion();
		}
	}
}
