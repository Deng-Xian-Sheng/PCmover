using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.Discovery.Infrastructure
{
	// Token: 0x02000007 RID: 7
	public class DirectEndpoint<T> where T : ServiceEndpoint, new()
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002AAB File Offset: 0x00000CAB
		// (set) Token: 0x06000031 RID: 49 RVA: 0x00002AB3 File Offset: 0x00000CB3
		public T Endpoint { get; private set; }

		// Token: 0x06000032 RID: 50 RVA: 0x00002ABC File Offset: 0x00000CBC
		public DirectEndpoint(string uriString) : this(string.IsNullOrWhiteSpace(uriString) ? null : new Uri(uriString))
		{
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002AD8 File Offset: 0x00000CD8
		public DirectEndpoint(Uri uri)
		{
			if (uri != null)
			{
				Binding binding = WcfHelper.GetBinding(uri);
				NetTcpBinding netTcpBinding = binding as NetTcpBinding;
				if (netTcpBinding != null)
				{
					netTcpBinding.Security.Mode = SecurityMode.None;
				}
				T t = Activator.CreateInstance<T>();
				t.Binding = binding;
				t.Address = new EndpointAddress(uri, Array.Empty<AddressHeader>());
				this.Endpoint = t;
			}
		}
	}
}
