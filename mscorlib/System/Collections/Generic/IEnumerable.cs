using System;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
	// Token: 0x020004D2 RID: 1234
	[TypeDependency("System.SZArrayHelper")]
	[__DynamicallyInvokable]
	public interface IEnumerable<out T> : IEnumerable
	{
		// Token: 0x06003ACE RID: 15054
		[__DynamicallyInvokable]
		IEnumerator<T> GetEnumerator();
	}
}
