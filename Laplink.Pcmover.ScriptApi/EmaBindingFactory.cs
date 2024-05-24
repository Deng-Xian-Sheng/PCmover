using System;
using System.ServiceModel.Channels;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.Pcmover.ScriptApi
{
	// Token: 0x02000003 RID: 3
	public class EmaBindingFactory : BindingFactory
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002066 File Offset: 0x00000266
		public EmaBindingFactory()
		{
			base.Scheme = LlEndpoint.UriSchemeEma;
			base.Type = typeof(EmaBinding);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002089 File Offset: 0x00000289
		protected override Binding Create(string parameters)
		{
			return new EmaBinding();
		}
	}
}
