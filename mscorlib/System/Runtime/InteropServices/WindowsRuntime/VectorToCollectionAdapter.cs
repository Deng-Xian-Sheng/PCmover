using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009D4 RID: 2516
	internal sealed class VectorToCollectionAdapter
	{
		// Token: 0x0600640D RID: 25613 RVA: 0x00155308 File Offset: 0x00153508
		private VectorToCollectionAdapter()
		{
		}

		// Token: 0x0600640E RID: 25614 RVA: 0x00155310 File Offset: 0x00153510
		[SecurityCritical]
		internal int Count<T>()
		{
			IVector<T> vector = JitHelpers.UnsafeCast<IVector<T>>(this);
			uint size = vector.Size;
			if (2147483647U < size)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CollectionBackingListTooLarge"));
			}
			return (int)size;
		}

		// Token: 0x0600640F RID: 25615 RVA: 0x00155344 File Offset: 0x00153544
		[SecurityCritical]
		internal bool IsReadOnly<T>()
		{
			return false;
		}

		// Token: 0x06006410 RID: 25616 RVA: 0x00155348 File Offset: 0x00153548
		[SecurityCritical]
		internal void Add<T>(T item)
		{
			IVector<T> vector = JitHelpers.UnsafeCast<IVector<T>>(this);
			vector.Append(item);
		}

		// Token: 0x06006411 RID: 25617 RVA: 0x00155364 File Offset: 0x00153564
		[SecurityCritical]
		internal void Clear<T>()
		{
			IVector<T> vector = JitHelpers.UnsafeCast<IVector<T>>(this);
			vector.Clear();
		}

		// Token: 0x06006412 RID: 25618 RVA: 0x00155380 File Offset: 0x00153580
		[SecurityCritical]
		internal bool Contains<T>(T item)
		{
			IVector<T> vector = JitHelpers.UnsafeCast<IVector<T>>(this);
			uint num;
			return vector.IndexOf(item, out num);
		}

		// Token: 0x06006413 RID: 25619 RVA: 0x001553A0 File Offset: 0x001535A0
		[SecurityCritical]
		internal void CopyTo<T>(T[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (arrayIndex < 0)
			{
				throw new ArgumentOutOfRangeException("arrayIndex");
			}
			if (array.Length <= arrayIndex && this.Count<T>() > 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_IndexOutOfArrayBounds"));
			}
			if (array.Length - arrayIndex < this.Count<T>())
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InsufficientSpaceToCopyCollection"));
			}
			IVector<T> this2 = JitHelpers.UnsafeCast<IVector<T>>(this);
			int num = this.Count<T>();
			for (int i = 0; i < num; i++)
			{
				array[i + arrayIndex] = VectorToListAdapter.GetAt<T>(this2, (uint)i);
			}
		}

		// Token: 0x06006414 RID: 25620 RVA: 0x00155430 File Offset: 0x00153630
		[SecurityCritical]
		internal bool Remove<T>(T item)
		{
			IVector<T> vector = JitHelpers.UnsafeCast<IVector<T>>(this);
			uint num;
			if (!vector.IndexOf(item, out num))
			{
				return false;
			}
			if (2147483647U < num)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CollectionBackingListTooLarge"));
			}
			VectorToListAdapter.RemoveAtHelper<T>(vector, num);
			return true;
		}
	}
}
