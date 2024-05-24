using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009D1 RID: 2513
	internal sealed class EnumerableToBindableIterableAdapter
	{
		// Token: 0x060063FB RID: 25595 RVA: 0x00154FA3 File Offset: 0x001531A3
		private EnumerableToBindableIterableAdapter()
		{
		}

		// Token: 0x060063FC RID: 25596 RVA: 0x00154FAC File Offset: 0x001531AC
		[SecurityCritical]
		internal IBindableIterator First_Stub()
		{
			IEnumerable enumerable = JitHelpers.UnsafeCast<IEnumerable>(this);
			return new EnumeratorToIteratorAdapter<object>(new EnumerableToBindableIterableAdapter.NonGenericToGenericEnumerator(enumerable.GetEnumerator()));
		}

		// Token: 0x02000CA1 RID: 3233
		internal sealed class NonGenericToGenericEnumerator : IEnumerator<object>, IDisposable, IEnumerator
		{
			// Token: 0x0600712B RID: 28971 RVA: 0x00185735 File Offset: 0x00183935
			public NonGenericToGenericEnumerator(IEnumerator enumerator)
			{
				this.enumerator = enumerator;
			}

			// Token: 0x17001369 RID: 4969
			// (get) Token: 0x0600712C RID: 28972 RVA: 0x00185744 File Offset: 0x00183944
			public object Current
			{
				get
				{
					return this.enumerator.Current;
				}
			}

			// Token: 0x0600712D RID: 28973 RVA: 0x00185751 File Offset: 0x00183951
			public bool MoveNext()
			{
				return this.enumerator.MoveNext();
			}

			// Token: 0x0600712E RID: 28974 RVA: 0x0018575E File Offset: 0x0018395E
			public void Reset()
			{
				this.enumerator.Reset();
			}

			// Token: 0x0600712F RID: 28975 RVA: 0x0018576B File Offset: 0x0018396B
			public void Dispose()
			{
			}

			// Token: 0x0400387C RID: 14460
			private IEnumerator enumerator;
		}
	}
}
