using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Threading
{
	// Token: 0x020004EC RID: 1260
	[FriendAccessAllowed]
	[SecurityCritical]
	internal class WinRTSynchronizationContextFactoryBase
	{
		// Token: 0x06003B8A RID: 15242 RVA: 0x000E24B0 File Offset: 0x000E06B0
		[SecurityCritical]
		public virtual SynchronizationContext Create(object coreDispatcher)
		{
			return null;
		}
	}
}
