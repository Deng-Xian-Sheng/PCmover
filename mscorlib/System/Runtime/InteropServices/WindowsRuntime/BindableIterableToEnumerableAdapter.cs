using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009EE RID: 2542
	internal sealed class BindableIterableToEnumerableAdapter
	{
		// Token: 0x060064B0 RID: 25776 RVA: 0x0015704D File Offset: 0x0015524D
		private BindableIterableToEnumerableAdapter()
		{
		}

		// Token: 0x060064B1 RID: 25777 RVA: 0x00157058 File Offset: 0x00155258
		[SecurityCritical]
		internal IEnumerator GetEnumerator_Stub()
		{
			IBindableIterable bindableIterable = JitHelpers.UnsafeCast<IBindableIterable>(this);
			return new IteratorToEnumeratorAdapter<object>(new BindableIterableToEnumerableAdapter.NonGenericToGenericIterator(bindableIterable.First()));
		}

		// Token: 0x02000CA2 RID: 3234
		private sealed class NonGenericToGenericIterator : IIterator<object>
		{
			// Token: 0x06007130 RID: 28976 RVA: 0x0018576D File Offset: 0x0018396D
			public NonGenericToGenericIterator(IBindableIterator iterator)
			{
				this.iterator = iterator;
			}

			// Token: 0x1700136A RID: 4970
			// (get) Token: 0x06007131 RID: 28977 RVA: 0x0018577C File Offset: 0x0018397C
			public object Current
			{
				get
				{
					return this.iterator.Current;
				}
			}

			// Token: 0x1700136B RID: 4971
			// (get) Token: 0x06007132 RID: 28978 RVA: 0x00185789 File Offset: 0x00183989
			public bool HasCurrent
			{
				get
				{
					return this.iterator.HasCurrent;
				}
			}

			// Token: 0x06007133 RID: 28979 RVA: 0x00185796 File Offset: 0x00183996
			public bool MoveNext()
			{
				return this.iterator.MoveNext();
			}

			// Token: 0x06007134 RID: 28980 RVA: 0x001857A3 File Offset: 0x001839A3
			public int GetMany(object[] items)
			{
				throw new NotSupportedException();
			}

			// Token: 0x0400387D RID: 14461
			private IBindableIterator iterator;
		}
	}
}
