using System;
using System.ServiceModel;
using Laplink.Service.Contracts;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000042 RID: 66
	[ServiceContract(Namespace = "http://laplink.com/services/contracts/v2.0056", SessionMode = SessionMode.Required, CallbackContract = typeof(IPcmoverMonitorCallback))]
	public interface IPcmoverMonitor : IPcmoverQuery
	{
		// Token: 0x060001E9 RID: 489
		[OperationContract(Name = "ConfigureMonitorCallbacksPcmover")]
		void ConfigureMonitorCallbacks(CallbackState monitorCallbackState);
	}
}
