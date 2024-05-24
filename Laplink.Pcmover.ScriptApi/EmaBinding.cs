using System;
using System.ServiceModel.Channels;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.Pcmover.ScriptApi
{
	// Token: 0x02000002 RID: 2
	public class EmaBinding : Binding
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public override string Scheme
		{
			get
			{
				return LlEndpoint.UriSchemeEma;
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002057 File Offset: 0x00000257
		public override BindingElementCollection CreateBindingElements()
		{
			return new BindingElementCollection();
		}
	}
}
