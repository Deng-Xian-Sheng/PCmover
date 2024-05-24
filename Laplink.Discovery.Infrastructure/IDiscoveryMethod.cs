using System;
using System.Threading.Tasks;

namespace Laplink.Discovery.Infrastructure
{
	// Token: 0x0200000C RID: 12
	public interface IDiscoveryMethod : IDisposable
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000040 RID: 64
		bool IsEnabled { get; }

		// Token: 0x06000041 RID: 65
		bool StartMonitoring();

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000042 RID: 66
		bool UseAsync { get; }

		// Token: 0x06000043 RID: 67
		void FindEndpoints();

		// Token: 0x06000044 RID: 68
		Task FindEndpointsAsync();
	}
}
