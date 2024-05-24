using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Laplink.Tools.Helpers.Wcf
{
	// Token: 0x02000003 RID: 3
	public class NetNamedPipeBindingFactory : BindingFactory
	{
		// Token: 0x0600001D RID: 29 RVA: 0x000024C2 File Offset: 0x000006C2
		public NetNamedPipeBindingFactory()
		{
			base.Scheme = Uri.UriSchemeNetPipe;
			base.Type = typeof(NetNamedPipeBinding);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000024E5 File Offset: 0x000006E5
		protected override Binding Create(string parameters)
		{
			return new NetNamedPipeBinding
			{
				MaxReceivedMessageSize = base.MaxReceivedMessageSize
			};
		}
	}
}
