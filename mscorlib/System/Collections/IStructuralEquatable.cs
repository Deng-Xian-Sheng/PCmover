using System;

namespace System.Collections
{
	// Token: 0x020004A4 RID: 1188
	[__DynamicallyInvokable]
	public interface IStructuralEquatable
	{
		// Token: 0x060038F4 RID: 14580
		[__DynamicallyInvokable]
		bool Equals(object other, IEqualityComparer comparer);

		// Token: 0x060038F5 RID: 14581
		[__DynamicallyInvokable]
		int GetHashCode(IEqualityComparer comparer);
	}
}
