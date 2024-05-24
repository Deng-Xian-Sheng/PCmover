using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009D3 RID: 2515
	internal sealed class VectorToListAdapter
	{
		// Token: 0x06006403 RID: 25603 RVA: 0x00155101 File Offset: 0x00153301
		private VectorToListAdapter()
		{
		}

		// Token: 0x06006404 RID: 25604 RVA: 0x0015510C File Offset: 0x0015330C
		[SecurityCritical]
		internal T Indexer_Get<T>(int index)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			IVector<T> this2 = JitHelpers.UnsafeCast<IVector<T>>(this);
			return VectorToListAdapter.GetAt<T>(this2, (uint)index);
		}

		// Token: 0x06006405 RID: 25605 RVA: 0x00155138 File Offset: 0x00153338
		[SecurityCritical]
		internal void Indexer_Set<T>(int index, T value)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			IVector<T> this2 = JitHelpers.UnsafeCast<IVector<T>>(this);
			VectorToListAdapter.SetAt<T>(this2, (uint)index, value);
		}

		// Token: 0x06006406 RID: 25606 RVA: 0x00155164 File Offset: 0x00153364
		[SecurityCritical]
		internal int IndexOf<T>(T item)
		{
			IVector<T> vector = JitHelpers.UnsafeCast<IVector<T>>(this);
			uint num;
			if (!vector.IndexOf(item, out num))
			{
				return -1;
			}
			if (2147483647U < num)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CollectionBackingListTooLarge"));
			}
			return (int)num;
		}

		// Token: 0x06006407 RID: 25607 RVA: 0x001551A0 File Offset: 0x001533A0
		[SecurityCritical]
		internal void Insert<T>(int index, T item)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			IVector<T> this2 = JitHelpers.UnsafeCast<IVector<T>>(this);
			VectorToListAdapter.InsertAtHelper<T>(this2, (uint)index, item);
		}

		// Token: 0x06006408 RID: 25608 RVA: 0x001551CC File Offset: 0x001533CC
		[SecurityCritical]
		internal void RemoveAt<T>(int index)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			IVector<T> this2 = JitHelpers.UnsafeCast<IVector<T>>(this);
			VectorToListAdapter.RemoveAtHelper<T>(this2, (uint)index);
		}

		// Token: 0x06006409 RID: 25609 RVA: 0x001551F8 File Offset: 0x001533F8
		internal static T GetAt<T>(IVector<T> _this, uint index)
		{
			T at;
			try
			{
				at = _this.GetAt(index);
			}
			catch (Exception ex)
			{
				if (-2147483637 == ex._HResult)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				throw;
			}
			return at;
		}

		// Token: 0x0600640A RID: 25610 RVA: 0x0015523C File Offset: 0x0015343C
		private static void SetAt<T>(IVector<T> _this, uint index, T value)
		{
			try
			{
				_this.SetAt(index, value);
			}
			catch (Exception ex)
			{
				if (-2147483637 == ex._HResult)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				throw;
			}
		}

		// Token: 0x0600640B RID: 25611 RVA: 0x00155280 File Offset: 0x00153480
		private static void InsertAtHelper<T>(IVector<T> _this, uint index, T item)
		{
			try
			{
				_this.InsertAt(index, item);
			}
			catch (Exception ex)
			{
				if (-2147483637 == ex._HResult)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				throw;
			}
		}

		// Token: 0x0600640C RID: 25612 RVA: 0x001552C4 File Offset: 0x001534C4
		internal static void RemoveAtHelper<T>(IVector<T> _this, uint index)
		{
			try
			{
				_this.RemoveAt(index);
			}
			catch (Exception ex)
			{
				if (-2147483637 == ex._HResult)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				throw;
			}
		}
	}
}
