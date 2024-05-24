using System;
using Laplink.Discovery.Infrastructure;
using Laplink.PcmoverService.Infrastructure;
using Laplink.Tools.Helpers;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000019 RID: 25
	public class PcmoverServiceHost : LlServiceHostWithDiscovery
	{
		// Token: 0x06000083 RID: 131 RVA: 0x000041F4 File Offset: 0x000023F4
		public PcmoverServiceHost(object singletonInstance, LlTraceSource ts) : base(singletonInstance, ts)
		{
			base.ContractNamespace = "http://laplink.com/services/contracts/v2.0056";
			ServiceBindingFactories_Framework factories = new ServiceBindingFactories_Framework();
			base.Endpoints.Add(new PcmoverQueryEndpoint(factories));
			base.Endpoints.Add(new PcmoverMonitorEndpoint(factories));
			base.Endpoints.Add(new PcmoverControlEndpoint(factories));
		}
	}
}
