using System;

namespace System.Collections.Generic
{
	// Token: 0x020004D4 RID: 1236
	[__DynamicallyInvokable]
	public interface IEqualityComparer<in T>
	{
		// Token: 0x06003AD0 RID: 15056
		[__DynamicallyInvokable]
		bool Equals(T x, T y);

		// Token: 0x06003AD1 RID: 15057
		[__DynamicallyInvokable]
		int GetHashCode(T obj);
	}
}
