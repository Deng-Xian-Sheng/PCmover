using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000857 RID: 2135
	[ComVisible(true)]
	public interface IMessageCtrl
	{
		// Token: 0x06005A78 RID: 23160
		[SecurityCritical]
		void Cancel(int msToCancel);
	}
}
