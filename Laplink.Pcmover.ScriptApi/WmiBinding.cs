using System;
using System.ServiceModel.Channels;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.Pcmover.ScriptApi
{
	// Token: 0x0200000D RID: 13
	public class WmiBinding : Binding
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000066 RID: 102 RVA: 0x000030BF File Offset: 0x000012BF
		public override string Scheme
		{
			get
			{
				return LlEndpoint.UriSchemeWmi;
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000030C6 File Offset: 0x000012C6
		public override BindingElementCollection CreateBindingElements()
		{
			return new BindingElementCollection();
		}
	}
}
