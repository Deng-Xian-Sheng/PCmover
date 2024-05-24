using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Laplink.Tools.Helpers.Wcf
{
	// Token: 0x02000006 RID: 6
	public class WSDualHttpBindingFactory : BindingFactory
	{
		// Token: 0x06000023 RID: 35 RVA: 0x000025E4 File Offset: 0x000007E4
		public WSDualHttpBindingFactory()
		{
			base.Scheme = Uri.UriSchemeHttp;
			base.Type = typeof(WSDualHttpBinding);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002607 File Offset: 0x00000807
		protected override Binding Create(string parameters)
		{
			return new WSDualHttpBinding
			{
				MaxReceivedMessageSize = base.MaxReceivedMessageSize
			};
		}
	}
}
