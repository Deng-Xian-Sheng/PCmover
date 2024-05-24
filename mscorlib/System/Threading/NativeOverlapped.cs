using System;
using System.Runtime.InteropServices;

namespace System.Threading
{
	// Token: 0x02000502 RID: 1282
	[ComVisible(true)]
	public struct NativeOverlapped
	{
		// Token: 0x0400199D RID: 6557
		public IntPtr InternalLow;

		// Token: 0x0400199E RID: 6558
		public IntPtr InternalHigh;

		// Token: 0x0400199F RID: 6559
		public int OffsetLow;

		// Token: 0x040019A0 RID: 6560
		public int OffsetHigh;

		// Token: 0x040019A1 RID: 6561
		public IntPtr EventHandle;
	}
}
