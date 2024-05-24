using System;
using System.Collections.Generic;
using Laplink.Download.Contracts;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.PcmoverService.Infrastructure
{
	// Token: 0x02000005 RID: 5
	public class DownloadControlEndpoint : DownloadEndpoint
	{
		// Token: 0x06000004 RID: 4 RVA: 0x000020D5 File Offset: 0x000002D5
		public DownloadControlEndpoint(IEnumerable<BindingFactory> factories) : base(factories, typeof(IDownloadControl), "control")
		{
		}
	}
}
