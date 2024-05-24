using System;
using System.Collections.Generic;
using Laplink.Download.Contracts;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.PcmoverService.Infrastructure
{
	// Token: 0x02000004 RID: 4
	public class DownloadMonitorEndpoint : DownloadEndpoint
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000020BD File Offset: 0x000002BD
		public DownloadMonitorEndpoint(IEnumerable<BindingFactory> factories) : base(factories, typeof(IDownloadMonitor), "monitor")
		{
		}
	}
}
