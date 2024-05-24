using System;
using System.ServiceModel.Channels;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.Pcmover.ScriptApi
{
	// Token: 0x0200000E RID: 14
	public class WmiBindingFactory : BindingFactory
	{
		// Token: 0x06000069 RID: 105 RVA: 0x000030D5 File Offset: 0x000012D5
		public WmiBindingFactory()
		{
			base.Scheme = LlEndpoint.UriSchemeWmi;
			base.Type = typeof(WmiBinding);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000030F8 File Offset: 0x000012F8
		protected override Binding Create(string parameters)
		{
			return new WmiBinding();
		}
	}
}
