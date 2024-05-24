using System;
using System.Collections;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009DE RID: 2526
	internal sealed class ListToBindableVectorViewAdapter : IBindableVectorView, IBindableIterable
	{
		// Token: 0x06006464 RID: 25700 RVA: 0x0015646B File Offset: 0x0015466B
		internal ListToBindableVectorViewAdapter(IList list)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}
			this.list = list;
		}

		// Token: 0x06006465 RID: 25701 RVA: 0x00156488 File Offset: 0x00154688
		private static void EnsureIndexInt32(uint index, int listCapacity)
		{
			if (2147483647U <= index || index >= (uint)listCapacity)
			{
				Exception ex = new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_IndexLargerThanMaxValue"));
				ex.SetErrorCode(-2147483637);
				throw ex;
			}
		}

		// Token: 0x06006466 RID: 25702 RVA: 0x001564C4 File Offset: 0x001546C4
		public IBindableIterator First()
		{
			IEnumerator enumerator = this.list.GetEnumerator();
			return new EnumeratorToIteratorAdapter<object>(new EnumerableToBindableIterableAdapter.NonGenericToGenericEnumerator(enumerator));
		}

		// Token: 0x06006467 RID: 25703 RVA: 0x001564E8 File Offset: 0x001546E8
		public object GetAt(uint index)
		{
			ListToBindableVectorViewAdapter.EnsureIndexInt32(index, this.list.Count);
			object result;
			try
			{
				result = this.list[(int)index];
			}
			catch (ArgumentOutOfRangeException innerException)
			{
				throw WindowsRuntimeMarshal.GetExceptionForHR(-2147483637, innerException, "ArgumentOutOfRange_IndexOutOfRange");
			}
			return result;
		}

		// Token: 0x17001150 RID: 4432
		// (get) Token: 0x06006468 RID: 25704 RVA: 0x00156538 File Offset: 0x00154738
		public uint Size
		{
			get
			{
				return (uint)this.list.Count;
			}
		}

		// Token: 0x06006469 RID: 25705 RVA: 0x00156548 File Offset: 0x00154748
		public bool IndexOf(object value, out uint index)
		{
			int num = this.list.IndexOf(value);
			if (-1 == num)
			{
				index = 0U;
				return false;
			}
			index = (uint)num;
			return true;
		}

		// Token: 0x04002CE7 RID: 11495
		private readonly IList list;
	}
}
