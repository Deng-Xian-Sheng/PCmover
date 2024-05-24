using System;
using Laplink.Download.Contracts;
using Laplink.Service.Infrastructure;

namespace Laplink.Download.Service
{
	// Token: 0x02000002 RID: 2
	public class DownloadControlCallbackStateData : ControlCallbackStateData<IDownloadControlCallback>
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public DownloadControlCallbackStateData(DownloadManager manager) : base(manager)
		{
			this._manager = manager;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002060 File Offset: 0x00000260
		protected override void OnControlCallbackChanged(IDownloadControlCallback oldVal, IDownloadControlCallback newVal)
		{
			this._manager.NotifyStatusInfoChanged();
		}

		// Token: 0x04000001 RID: 1
		private DownloadManager _manager;
	}
}
