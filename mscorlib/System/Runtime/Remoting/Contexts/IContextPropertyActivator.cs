using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	// Token: 0x0200080D RID: 2061
	[ComVisible(true)]
	public interface IContextPropertyActivator
	{
		// Token: 0x060058BE RID: 22718
		[SecurityCritical]
		bool IsOKToActivate(IConstructionCallMessage msg);

		// Token: 0x060058BF RID: 22719
		[SecurityCritical]
		void CollectFromClientContext(IConstructionCallMessage msg);

		// Token: 0x060058C0 RID: 22720
		[SecurityCritical]
		bool DeliverClientContextToServerContext(IConstructionCallMessage msg);

		// Token: 0x060058C1 RID: 22721
		[SecurityCritical]
		void CollectFromServerContext(IConstructionReturnMessage msg);

		// Token: 0x060058C2 RID: 22722
		[SecurityCritical]
		bool DeliverServerContextToClientContext(IConstructionReturnMessage msg);
	}
}
