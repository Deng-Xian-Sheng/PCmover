using System;
using System.Collections.Generic;

namespace Laplink.Tools.Helpers.Wcf
{
	// Token: 0x02000009 RID: 9
	public class ServiceBindingFactories_S20 : List<BindingFactory>
	{
		// Token: 0x06000067 RID: 103 RVA: 0x00003013 File Offset: 0x00001213
		public ServiceBindingFactories_S20()
		{
			base.Add(new NetTcpBindingFactory());
		}
	}
}
