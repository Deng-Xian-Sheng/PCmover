using System;
using System.Collections.Generic;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.PcmoverService.Infrastructure
{
	// Token: 0x02000009 RID: 9
	public class PcmoverControlEndpoint : PcmoverEndpoint
	{
		// Token: 0x06000009 RID: 9 RVA: 0x000021C5 File Offset: 0x000003C5
		public PcmoverControlEndpoint(IEnumerable<BindingFactory> factories) : base(factories, typeof(IPcmoverControl), "control")
		{
		}
	}
}
