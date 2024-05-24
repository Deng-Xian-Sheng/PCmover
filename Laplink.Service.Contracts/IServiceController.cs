using System;
using System.ServiceModel;

namespace Laplink.Service.Contracts
{
	// Token: 0x02000003 RID: 3
	[ServiceContract]
	public interface IServiceController
	{
		// Token: 0x06000001 RID: 1
		[OperationContract]
		bool BecomeController(CallbackState controlCallbackState);

		// Token: 0x06000002 RID: 2
		[OperationContract]
		void StopBeingController();

		// Token: 0x06000003 RID: 3
		[OperationContract]
		void ConfigureControlCallbacks(CallbackState controlCallbackState);
	}
}
