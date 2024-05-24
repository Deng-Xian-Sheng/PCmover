using System;
using System.Runtime.CompilerServices;

namespace System.Threading.Tasks
{
	// Token: 0x0200057C RID: 1404
	[FriendAccessAllowed]
	internal enum AsyncCausalityStatus
	{
		// Token: 0x04001B77 RID: 7031
		Canceled = 2,
		// Token: 0x04001B78 RID: 7032
		Completed = 1,
		// Token: 0x04001B79 RID: 7033
		Error = 3,
		// Token: 0x04001B7A RID: 7034
		Started = 0
	}
}
