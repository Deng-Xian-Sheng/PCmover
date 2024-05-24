using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009D7 RID: 2519
	internal sealed class MapToCollectionAdapter
	{
		// Token: 0x06006422 RID: 25634 RVA: 0x00155707 File Offset: 0x00153907
		private MapToCollectionAdapter()
		{
		}

		// Token: 0x06006423 RID: 25635 RVA: 0x00155710 File Offset: 0x00153910
		[SecurityCritical]
		internal int Count<K, V>()
		{
			object obj = JitHelpers.UnsafeCast<object>(this);
			IMap<K, V> map = obj as IMap<K, V>;
			if (map != null)
			{
				uint size = map.Size;
				if (2147483647U < size)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CollectionBackingDictionaryTooLarge"));
				}
				return (int)size;
			}
			else
			{
				IVector<KeyValuePair<K, V>> vector = JitHelpers.UnsafeCast<IVector<KeyValuePair<K, V>>>(this);
				uint size2 = vector.Size;
				if (2147483647U < size2)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CollectionBackingListTooLarge"));
				}
				return (int)size2;
			}
		}

		// Token: 0x06006424 RID: 25636 RVA: 0x00155779 File Offset: 0x00153979
		[SecurityCritical]
		internal bool IsReadOnly<K, V>()
		{
			return false;
		}

		// Token: 0x06006425 RID: 25637 RVA: 0x0015577C File Offset: 0x0015397C
		[SecurityCritical]
		internal void Add<K, V>(KeyValuePair<K, V> item)
		{
			object obj = JitHelpers.UnsafeCast<object>(this);
			IDictionary<K, V> dictionary = obj as IDictionary<K, V>;
			if (dictionary != null)
			{
				dictionary.Add(item.Key, item.Value);
				return;
			}
			IVector<KeyValuePair<K, V>> vector = JitHelpers.UnsafeCast<IVector<KeyValuePair<K, V>>>(this);
			vector.Append(item);
		}

		// Token: 0x06006426 RID: 25638 RVA: 0x001557C0 File Offset: 0x001539C0
		[SecurityCritical]
		internal void Clear<K, V>()
		{
			object obj = JitHelpers.UnsafeCast<object>(this);
			IMap<K, V> map = obj as IMap<K, V>;
			if (map != null)
			{
				map.Clear();
				return;
			}
			IVector<KeyValuePair<K, V>> vector = JitHelpers.UnsafeCast<IVector<KeyValuePair<K, V>>>(this);
			vector.Clear();
		}

		// Token: 0x06006427 RID: 25639 RVA: 0x001557F4 File Offset: 0x001539F4
		[SecurityCritical]
		internal bool Contains<K, V>(KeyValuePair<K, V> item)
		{
			object obj = JitHelpers.UnsafeCast<object>(this);
			IDictionary<K, V> dictionary = obj as IDictionary<K, V>;
			if (dictionary != null)
			{
				V x;
				return dictionary.TryGetValue(item.Key, out x) && EqualityComparer<V>.Default.Equals(x, item.Value);
			}
			IVector<KeyValuePair<K, V>> vector = JitHelpers.UnsafeCast<IVector<KeyValuePair<K, V>>>(this);
			uint num;
			return vector.IndexOf(item, out num);
		}

		// Token: 0x06006428 RID: 25640 RVA: 0x0015584C File Offset: 0x00153A4C
		[SecurityCritical]
		internal void CopyTo<K, V>(KeyValuePair<K, V>[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (arrayIndex < 0)
			{
				throw new ArgumentOutOfRangeException("arrayIndex");
			}
			if (array.Length <= arrayIndex && this.Count<K, V>() > 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_IndexOutOfArrayBounds"));
			}
			if (array.Length - arrayIndex < this.Count<K, V>())
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InsufficientSpaceToCopyCollection"));
			}
			IIterable<KeyValuePair<K, V>> iterable = JitHelpers.UnsafeCast<IIterable<KeyValuePair<K, V>>>(this);
			foreach (KeyValuePair<K, V> keyValuePair in iterable)
			{
				array[arrayIndex++] = keyValuePair;
			}
		}

		// Token: 0x06006429 RID: 25641 RVA: 0x001558FC File Offset: 0x00153AFC
		[SecurityCritical]
		internal bool Remove<K, V>(KeyValuePair<K, V> item)
		{
			object obj = JitHelpers.UnsafeCast<object>(this);
			IDictionary<K, V> dictionary = obj as IDictionary<K, V>;
			if (dictionary != null)
			{
				return dictionary.Remove(item.Key);
			}
			IVector<KeyValuePair<K, V>> vector = JitHelpers.UnsafeCast<IVector<KeyValuePair<K, V>>>(this);
			uint num;
			if (!vector.IndexOf(item, out num))
			{
				return false;
			}
			if (2147483647U < num)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CollectionBackingListTooLarge"));
			}
			VectorToListAdapter.RemoveAtHelper<KeyValuePair<K, V>>(vector, num);
			return true;
		}
	}
}
