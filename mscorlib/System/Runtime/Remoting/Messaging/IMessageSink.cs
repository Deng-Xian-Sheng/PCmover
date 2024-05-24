using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000858 RID: 2136
	[ComVisible(true)]
	public interface IMessageSink
	{
		// Token: 0x06005A79 RID: 23161
		[SecurityCritical]
		IMessage SyncProcessMessage(IMessage msg);

		// Token: 0x06005A7A RID: 23162
		[SecurityCritical]
		IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink);

		// Token: 0x17000F25 RID: 3877
		// (get) Token: 0x06005A7B RID: 23163
		IMessageSink NextSink { [SecurityCritical] get; }
	}
}
