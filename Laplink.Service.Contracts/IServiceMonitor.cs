using System;
using System.ServiceModel;

namespace Laplink.Service.Contracts
{
	// Token: 0x02000004 RID: 4
	[ServiceContract]
	public interface IServiceMonitor
	{
		// Token: 0x06000004 RID: 4
		[OperationContract]
		void ConfigureMonitorCallbacks(CallbackState monitorCallbackState);
	}
}
