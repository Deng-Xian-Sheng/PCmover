using System;
using System.Collections.Generic;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.Pcmover.ScriptApi
{
	// Token: 0x0200000C RID: 12
	public class ServiceBindingFactories_Script : List<BindingFactory>
	{
		// Token: 0x06000065 RID: 101 RVA: 0x000030A1 File Offset: 0x000012A1
		public ServiceBindingFactories_Script()
		{
			base.Add(new EmaBindingFactory());
			base.Add(new WmiBindingFactory());
		}
	}
}
