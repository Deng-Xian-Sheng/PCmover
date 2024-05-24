using System;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
	// Token: 0x020004CF RID: 1231
	[TypeDependency("System.SZArrayHelper")]
	[__DynamicallyInvokable]
	public interface ICollection<T> : IEnumerable<!0>, IEnumerable
	{
		// Token: 0x170008E6 RID: 2278
		// (get) Token: 0x06003ABE RID: 15038
		[__DynamicallyInvokable]
		int Count { [__DynamicallyInvokable] get; }

		// Token: 0x170008E7 RID: 2279
		// (get) Token: 0x06003ABF RID: 15039
		[__DynamicallyInvokable]
		bool IsReadOnly { [__DynamicallyInvokable] get; }

		// Token: 0x06003AC0 RID: 15040
		[__DynamicallyInvokable]
		void Add(T item);

		// Token: 0x06003AC1 RID: 15041
		[__DynamicallyInvokable]
		void Clear();

		// Token: 0x06003AC2 RID: 15042
		[__DynamicallyInvokable]
		bool Contains(T item);

		// Token: 0x06003AC3 RID: 15043
		[__DynamicallyInvokable]
		void CopyTo(T[] array, int arrayIndex);

		// Token: 0x06003AC4 RID: 15044
		[__DynamicallyInvokable]
		bool Remove(T item);
	}
}
