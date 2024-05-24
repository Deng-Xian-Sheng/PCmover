using System;

namespace Laplink.Tools.Helpers.Wcf
{
	// Token: 0x02000004 RID: 4
	public class ServiceBindingFactories_Framework : ServiceBindingFactories_S20
	{
		// Token: 0x0600001F RID: 31 RVA: 0x000024F8 File Offset: 0x000006F8
		public ServiceBindingFactories_Framework()
		{
			base.Add(new NetNamedPipeBindingFactory());
		}
	}
}
