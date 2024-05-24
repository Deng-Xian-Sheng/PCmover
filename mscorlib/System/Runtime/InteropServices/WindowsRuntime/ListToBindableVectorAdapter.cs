using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009DD RID: 2525
	internal sealed class ListToBindableVectorAdapter
	{
		// Token: 0x06006458 RID: 25688 RVA: 0x0015620D File Offset: 0x0015440D
		private ListToBindableVectorAdapter()
		{
		}

		// Token: 0x06006459 RID: 25689 RVA: 0x00156218 File Offset: 0x00154418
		[SecurityCritical]
		internal object GetAt(uint index)
		{
			IList list = JitHelpers.UnsafeCast<IList>(this);
			ListToBindableVectorAdapter.EnsureIndexInt32(index, list.Count);
			object result;
			try
			{
				result = list[(int)index];
			}
			catch (ArgumentOutOfRangeException innerException)
			{
				throw WindowsRuntimeMarshal.GetExceptionForHR(-2147483637, innerException, "ArgumentOutOfRange_IndexOutOfRange");
			}
			return result;
		}

		// Token: 0x0600645A RID: 25690 RVA: 0x00156268 File Offset: 0x00154468
		[SecurityCritical]
		internal uint Size()
		{
			IList list = JitHelpers.UnsafeCast<IList>(this);
			return (uint)list.Count;
		}

		// Token: 0x0600645B RID: 25691 RVA: 0x00156284 File Offset: 0x00154484
		[SecurityCritical]
		internal IBindableVectorView GetView()
		{
			IList list = JitHelpers.UnsafeCast<IList>(this);
			return new ListToBindableVectorViewAdapter(list);
		}

		// Token: 0x0600645C RID: 25692 RVA: 0x001562A0 File Offset: 0x001544A0
		[SecurityCritical]
		internal bool IndexOf(object value, out uint index)
		{
			IList list = JitHelpers.UnsafeCast<IList>(this);
			int num = list.IndexOf(value);
			if (-1 == num)
			{
				index = 0U;
				return false;
			}
			index = (uint)num;
			return true;
		}

		// Token: 0x0600645D RID: 25693 RVA: 0x001562CC File Offset: 0x001544CC
		[SecurityCritical]
		internal void SetAt(uint index, object value)
		{
			IList list = JitHelpers.UnsafeCast<IList>(this);
			ListToBindableVectorAdapter.EnsureIndexInt32(index, list.Count);
			try
			{
				list[(int)index] = value;
			}
			catch (ArgumentOutOfRangeException innerException)
			{
				throw WindowsRuntimeMarshal.GetExceptionForHR(-2147483637, innerException, "ArgumentOutOfRange_IndexOutOfRange");
			}
		}

		// Token: 0x0600645E RID: 25694 RVA: 0x00156318 File Offset: 0x00154518
		[SecurityCritical]
		internal void InsertAt(uint index, object value)
		{
			IList list = JitHelpers.UnsafeCast<IList>(this);
			ListToBindableVectorAdapter.EnsureIndexInt32(index, list.Count + 1);
			try
			{
				list.Insert((int)index, value);
			}
			catch (ArgumentOutOfRangeException ex)
			{
				ex.SetErrorCode(-2147483637);
				throw;
			}
		}

		// Token: 0x0600645F RID: 25695 RVA: 0x00156364 File Offset: 0x00154564
		[SecurityCritical]
		internal void RemoveAt(uint index)
		{
			IList list = JitHelpers.UnsafeCast<IList>(this);
			ListToBindableVectorAdapter.EnsureIndexInt32(index, list.Count);
			try
			{
				list.RemoveAt((int)index);
			}
			catch (ArgumentOutOfRangeException ex)
			{
				ex.SetErrorCode(-2147483637);
				throw;
			}
		}

		// Token: 0x06006460 RID: 25696 RVA: 0x001563AC File Offset: 0x001545AC
		[SecurityCritical]
		internal void Append(object value)
		{
			IList list = JitHelpers.UnsafeCast<IList>(this);
			list.Add(value);
		}

		// Token: 0x06006461 RID: 25697 RVA: 0x001563C8 File Offset: 0x001545C8
		[SecurityCritical]
		internal void RemoveAtEnd()
		{
			IList list = JitHelpers.UnsafeCast<IList>(this);
			if (list.Count == 0)
			{
				Exception ex = new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CannotRemoveLastFromEmptyCollection"));
				ex.SetErrorCode(-2147483637);
				throw ex;
			}
			uint count = (uint)list.Count;
			this.RemoveAt(count - 1U);
		}

		// Token: 0x06006462 RID: 25698 RVA: 0x00156414 File Offset: 0x00154614
		[SecurityCritical]
		internal void Clear()
		{
			IList list = JitHelpers.UnsafeCast<IList>(this);
			list.Clear();
		}

		// Token: 0x06006463 RID: 25699 RVA: 0x00156430 File Offset: 0x00154630
		private static void EnsureIndexInt32(uint index, int listCapacity)
		{
			if (2147483647U <= index || index >= (uint)listCapacity)
			{
				Exception ex = new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_IndexLargerThanMaxValue"));
				ex.SetErrorCode(-2147483637);
				throw ex;
			}
		}
	}
}
