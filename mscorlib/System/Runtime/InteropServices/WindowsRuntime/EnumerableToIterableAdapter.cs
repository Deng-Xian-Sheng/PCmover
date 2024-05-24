using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009D0 RID: 2512
	internal sealed class EnumerableToIterableAdapter
	{
		// Token: 0x060063F9 RID: 25593 RVA: 0x00154F7B File Offset: 0x0015317B
		private EnumerableToIterableAdapter()
		{
		}

		// Token: 0x060063FA RID: 25594 RVA: 0x00154F84 File Offset: 0x00153184
		[SecurityCritical]
		internal IIterator<T> First_Stub<T>()
		{
			IEnumerable<T> enumerable = JitHelpers.UnsafeCast<IEnumerable<T>>(this);
			return new EnumeratorToIteratorAdapter<T>(enumerable.GetEnumerator());
		}
	}
}
