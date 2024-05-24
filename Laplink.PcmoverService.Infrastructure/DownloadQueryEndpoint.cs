using System;
using System.Collections.Generic;
using Laplink.Download.Contracts;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.PcmoverService.Infrastructure
{
	// Token: 0x02000003 RID: 3
	public class DownloadQueryEndpoint : DownloadEndpoint
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002086 File Offset: 0x00000286
		public DownloadQueryEndpoint(IEnumerable<BindingFactory> factories) : base(factories, typeof(IDownloadQuery), "query")
		{
			base.Contract = new ContractInfo(typeof(IDownloadQuery), "query", "v2.0056");
		}
	}
}
