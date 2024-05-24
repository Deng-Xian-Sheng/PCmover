using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Laplink.Tools.Helpers.Wcf
{
	// Token: 0x02000006 RID: 6
	public class NetTcpBindingFactory : BindingFactory
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00002BC0 File Offset: 0x00000DC0
		// (set) Token: 0x06000049 RID: 73 RVA: 0x00002BC8 File Offset: 0x00000DC8
		public SecurityMode DefaultSecurityMode { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00002BD1 File Offset: 0x00000DD1
		// (set) Token: 0x0600004B RID: 75 RVA: 0x00002BD9 File Offset: 0x00000DD9
		public TcpClientCredentialType DefaultCredentialType { get; set; }

		// Token: 0x0600004C RID: 76 RVA: 0x00002BE2 File Offset: 0x00000DE2
		public NetTcpBindingFactory()
		{
			base.Scheme = Uri.UriSchemeNetTcp;
			base.Type = typeof(NetTcpBinding);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002C08 File Offset: 0x00000E08
		protected override Binding Create(string parameters)
		{
			SecurityMode defaultSecurityMode = this.DefaultSecurityMode;
			TcpClientCredentialType defaultCredentialType = this.DefaultCredentialType;
			if (!string.IsNullOrWhiteSpace(parameters))
			{
				string[] array = parameters.Split(new char[]
				{
					LlEndpoint.UriSegmentDelimiterChar
				});
				if (array.Length == 2)
				{
					if (!Enum.TryParse<SecurityMode>(array[0], true, out defaultSecurityMode))
					{
						return null;
					}
					if (!Enum.TryParse<TcpClientCredentialType>(array[1], true, out defaultCredentialType))
					{
						return null;
					}
				}
			}
			NetTcpBinding netTcpBinding = new NetTcpBinding
			{
				MaxReceivedMessageSize = base.MaxReceivedMessageSize
			};
			netTcpBinding.Security.Mode = defaultSecurityMode;
			if (defaultSecurityMode == SecurityMode.Transport)
			{
				netTcpBinding.Security.Transport.ClientCredentialType = defaultCredentialType;
			}
			return netTcpBinding;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002C98 File Offset: 0x00000E98
		public override string GetParameters(Binding binding)
		{
			NetTcpBinding netTcpBinding = binding as NetTcpBinding;
			if (netTcpBinding == null)
			{
				return null;
			}
			string str = netTcpBinding.Security.Mode.ToString().ToLower();
			string str2 = (netTcpBinding.Security.Mode == SecurityMode.Transport) ? netTcpBinding.Security.Transport.ClientCredentialType.ToString().ToLower() : "none";
			return str + LlEndpoint.UriSegmentDelimiter + str2;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002D14 File Offset: 0x00000F14
		public override EndpointAddress CreateEndpoint(Uri uri, Binding binding)
		{
			NetTcpBinding netTcpBinding = binding as NetTcpBinding;
			if (netTcpBinding != null && netTcpBinding.Security.Mode == SecurityMode.Transport)
			{
				SpnEndpointIdentity identity = new SpnEndpointIdentity("");
				return new EndpointAddress(uri, identity, Array.Empty<AddressHeader>());
			}
			return base.CreateEndpoint(uri, binding);
		}
	}
}
