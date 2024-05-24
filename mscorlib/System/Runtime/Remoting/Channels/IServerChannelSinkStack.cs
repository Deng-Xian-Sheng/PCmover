using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x0200082F RID: 2095
	[ComVisible(true)]
	public interface IServerChannelSinkStack : IServerResponseChannelSinkStack
	{
		// Token: 0x060059A6 RID: 22950
		[SecurityCritical]
		void Push(IServerChannelSink sink, object state);

		// Token: 0x060059A7 RID: 22951
		[SecurityCritical]
		object Pop(IServerChannelSink sink);

		// Token: 0x060059A8 RID: 22952
		[SecurityCritical]
		void Store(IServerChannelSink sink, object state);

		// Token: 0x060059A9 RID: 22953
		[SecurityCritical]
		void StoreAndDispatch(IServerChannelSink sink, object state);

		// Token: 0x060059AA RID: 22954
		[SecurityCritical]
		void ServerCallback(IAsyncResult ar);
	}
}
