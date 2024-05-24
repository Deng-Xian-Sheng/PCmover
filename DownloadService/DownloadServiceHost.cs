using System;
using Laplink.Discovery.Infrastructure;
using Laplink.PcmoverService.Infrastructure;
using Laplink.Tools.Helpers;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.Download.Service
{
	// Token: 0x02000004 RID: 4
	public class DownloadServiceHost : LlServiceHostWithDiscovery
	{
		// Token: 0x06000034 RID: 52 RVA: 0x00003A10 File Offset: 0x00001C10
		public DownloadServiceHost(object singletonInstance, LlTraceSource ts) : base(singletonInstance, ts)
		{
			base.ContractNamespace = "http://laplink.com/services/downloadcontracts/v2.0056";
			ServiceBindingFactories_Framework factories = new ServiceBindingFactories_Framework();
			base.Endpoints.Add(new DownloadQueryEndpoint(factories));
			base.Endpoints.Add(new DownloadMonitorEndpoint(factories));
			base.Endpoints.Add(new DownloadControlEndpoint(factories));
		}
	}
}
