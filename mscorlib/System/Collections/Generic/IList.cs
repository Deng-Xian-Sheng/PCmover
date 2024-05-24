using System;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
	// Token: 0x020004D5 RID: 1237
	[TypeDependency("System.SZArrayHelper")]
	[__DynamicallyInvokable]
	public interface IList<T> : ICollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x170008EC RID: 2284
		[__DynamicallyInvokable]
		T this[int index]
		{
			[__DynamicallyInvokable]
			get;
			[__DynamicallyInvokable]
			set;
		}

		// Token: 0x06003AD4 RID: 15060
		[__DynamicallyInvokable]
		int IndexOf(T item);

		// Token: 0x06003AD5 RID: 15061
		[__DynamicallyInvokable]
		void Insert(int index, T item);

		// Token: 0x06003AD6 RID: 15062
		[__DynamicallyInvokable]
		void RemoveAt(int index);
	}
}
