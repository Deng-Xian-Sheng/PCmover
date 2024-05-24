using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Services
{
	// Token: 0x02000805 RID: 2053
	[ComVisible(true)]
	public interface ITrackingHandler
	{
		// Token: 0x0600586D RID: 22637
		[SecurityCritical]
		void MarshaledObject(object obj, ObjRef or);

		// Token: 0x0600586E RID: 22638
		[SecurityCritical]
		void UnmarshaledObject(object obj, ObjRef or);

		// Token: 0x0600586F RID: 22639
		[SecurityCritical]
		void DisconnectedObject(object obj);
	}
}
