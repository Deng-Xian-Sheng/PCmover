using System;
using System.Collections.Generic;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.PcmoverService.Infrastructure
{
	// Token: 0x02000008 RID: 8
	public class PcmoverMonitorEndpoint : PcmoverEndpoint
	{
		// Token: 0x06000008 RID: 8 RVA: 0x000021AD File Offset: 0x000003AD
		public PcmoverMonitorEndpoint(IEnumerable<BindingFactory> factories) : base(factories, typeof(IPcmoverMonitor), "monitor")
		{
		}
	}
}
