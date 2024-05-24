using System;
using System.Runtime.InteropServices;

namespace System.Threading
{
	// Token: 0x0200052B RID: 1323
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public static class Timeout
	{
		// Token: 0x04001A27 RID: 6695
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public static readonly TimeSpan InfiniteTimeSpan = new TimeSpan(0, 0, 0, 0, -1);

		// Token: 0x04001A28 RID: 6696
		[__DynamicallyInvokable]
		public const int Infinite = -1;

		// Token: 0x04001A29 RID: 6697
		internal const uint UnsignedInfinite = 4294967295U;
	}
}
