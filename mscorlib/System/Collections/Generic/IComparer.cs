using System;

namespace System.Collections.Generic
{
	// Token: 0x020004D0 RID: 1232
	[__DynamicallyInvokable]
	public interface IComparer<in T>
	{
		// Token: 0x06003AC5 RID: 15045
		[__DynamicallyInvokable]
		int Compare(T x, T y);
	}
}
