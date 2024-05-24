using System;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using Laplink.Tools.Helpers;

namespace Laplink.Discovery.Infrastructure
{
	// Token: 0x0200000E RID: 14
	public interface IDiscoveryOutput
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000045 RID: 69
		LlTraceSource Ts { get; }

		// Token: 0x06000046 RID: 70
		void FireEndpointChange(EndpointDiscoveryMetadata edm, DiscoveryEndpointChange change);

		// Token: 0x06000047 RID: 71
		void FireEndpointChange(EndpointAddress address, DiscoveryEndpointChange change);
	}
}
