using System;
using System.Collections.Generic;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.PcmoverService.Infrastructure
{
	// Token: 0x02000007 RID: 7
	public class PcmoverQueryEndpoint : PcmoverEndpoint
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002195 File Offset: 0x00000395
		public PcmoverQueryEndpoint(IEnumerable<BindingFactory> factories) : base(factories, typeof(IPcmoverQuery), "query")
		{
		}
	}
}
