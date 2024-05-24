using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	// Token: 0x02000817 RID: 2071
	[ComVisible(true)]
	public interface IDynamicMessageSink
	{
		// Token: 0x060058DB RID: 22747
		[SecurityCritical]
		void ProcessMessageStart(IMessage reqMsg, bool bCliSide, bool bAsync);

		// Token: 0x060058DC RID: 22748
		[SecurityCritical]
		void ProcessMessageFinish(IMessage replyMsg, bool bCliSide, bool bAsync);
	}
}
