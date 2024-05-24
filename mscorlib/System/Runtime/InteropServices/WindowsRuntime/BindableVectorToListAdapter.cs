using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009DB RID: 2523
	internal sealed class BindableVectorToListAdapter
	{
		// Token: 0x06006443 RID: 25667 RVA: 0x00155E4E File Offset: 0x0015404E
		private BindableVectorToListAdapter()
		{
		}

		// Token: 0x06006444 RID: 25668 RVA: 0x00155E58 File Offset: 0x00154058
		[SecurityCritical]
		internal object Indexer_Get(int index)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			IBindableVector this2 = JitHelpers.UnsafeCast<IBindableVector>(this);
			return BindableVectorToListAdapter.GetAt(this2, (uint)index);
		}

		// Token: 0x06006445 RID: 25669 RVA: 0x00155E84 File Offset: 0x00154084
		[SecurityCritical]
		internal void Indexer_Set(int index, object value)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			IBindableVector this2 = JitHelpers.UnsafeCast<IBindableVector>(this);
			BindableVectorToListAdapter.SetAt(this2, (uint)index, value);
		}

		// Token: 0x06006446 RID: 25670 RVA: 0x00155EB0 File Offset: 0x001540B0
		[SecurityCritical]
		internal int Add(object value)
		{
			IBindableVector bindableVector = JitHelpers.UnsafeCast<IBindableVector>(this);
			bindableVector.Append(value);
			uint size = bindableVector.Size;
			if (2147483647U < size)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CollectionBackingListTooLarge"));
			}
			return (int)(size - 1U);
		}

		// Token: 0x06006447 RID: 25671 RVA: 0x00155EF0 File Offset: 0x001540F0
		[SecurityCritical]
		internal bool Contains(object item)
		{
			IBindableVector bindableVector = JitHelpers.UnsafeCast<IBindableVector>(this);
			uint num;
			return bindableVector.IndexOf(item, out num);
		}

		// Token: 0x06006448 RID: 25672 RVA: 0x00155F10 File Offset: 0x00154110
		[SecurityCritical]
		internal void Clear()
		{
			IBindableVector bindableVector = JitHelpers.UnsafeCast<IBindableVector>(this);
			bindableVector.Clear();
		}

		// Token: 0x06006449 RID: 25673 RVA: 0x00155F2A File Offset: 0x0015412A
		[SecurityCritical]
		internal bool IsFixedSize()
		{
			return false;
		}

		// Token: 0x0600644A RID: 25674 RVA: 0x00155F2D File Offset: 0x0015412D
		[SecurityCritical]
		internal bool IsReadOnly()
		{
			return false;
		}

		// Token: 0x0600644B RID: 25675 RVA: 0x00155F30 File Offset: 0x00154130
		[SecurityCritical]
		internal int IndexOf(object item)
		{
			IBindableVector bindableVector = JitHelpers.UnsafeCast<IBindableVector>(this);
			uint num;
			if (!bindableVector.IndexOf(item, out num))
			{
				return -1;
			}
			if (2147483647U < num)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CollectionBackingListTooLarge"));
			}
			return (int)num;
		}

		// Token: 0x0600644C RID: 25676 RVA: 0x00155F6C File Offset: 0x0015416C
		[SecurityCritical]
		internal void Insert(int index, object item)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			IBindableVector this2 = JitHelpers.UnsafeCast<IBindableVector>(this);
			BindableVectorToListAdapter.InsertAtHelper(this2, (uint)index, item);
		}

		// Token: 0x0600644D RID: 25677 RVA: 0x00155F98 File Offset: 0x00154198
		[SecurityCritical]
		internal void Remove(object item)
		{
			IBindableVector bindableVector = JitHelpers.UnsafeCast<IBindableVector>(this);
			uint num;
			bool flag = bindableVector.IndexOf(item, out num);
			if (flag)
			{
				if (2147483647U < num)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CollectionBackingListTooLarge"));
				}
				BindableVectorToListAdapter.RemoveAtHelper(bindableVector, num);
			}
		}

		// Token: 0x0600644E RID: 25678 RVA: 0x00155FD8 File Offset: 0x001541D8
		[SecurityCritical]
		internal void RemoveAt(int index)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			IBindableVector this2 = JitHelpers.UnsafeCast<IBindableVector>(this);
			BindableVectorToListAdapter.RemoveAtHelper(this2, (uint)index);
		}

		// Token: 0x0600644F RID: 25679 RVA: 0x00156004 File Offset: 0x00154204
		private static object GetAt(IBindableVector _this, uint index)
		{
			object at;
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

		// Token: 0x06006450 RID: 25680 RVA: 0x00156048 File Offset: 0x00154248
		private static void SetAt(IBindableVector _this, uint index, object value)
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

		// Token: 0x06006451 RID: 25681 RVA: 0x0015608C File Offset: 0x0015428C
		private static void InsertAtHelper(IBindableVector _this, uint index, object item)
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

		// Token: 0x06006452 RID: 25682 RVA: 0x001560D0 File Offset: 0x001542D0
		private static void RemoveAtHelper(IBindableVector _this, uint index)
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
