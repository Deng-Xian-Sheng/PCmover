using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009DA RID: 2522
	internal sealed class DictionaryToMapAdapter
	{
		// Token: 0x0600643B RID: 25659 RVA: 0x00155D27 File Offset: 0x00153F27
		private DictionaryToMapAdapter()
		{
		}

		// Token: 0x0600643C RID: 25660 RVA: 0x00155D30 File Offset: 0x00153F30
		[SecurityCritical]
		internal V Lookup<K, V>(K key)
		{
			IDictionary<K, V> dictionary = JitHelpers.UnsafeCast<IDictionary<K, V>>(this);
			V result;
			if (!dictionary.TryGetValue(key, out result))
			{
				Exception ex = new KeyNotFoundException(Environment.GetResourceString("Arg_KeyNotFound"));
				ex.SetErrorCode(-2147483637);
				throw ex;
			}
			return result;
		}

		// Token: 0x0600643D RID: 25661 RVA: 0x00155D70 File Offset: 0x00153F70
		[SecurityCritical]
		internal uint Size<K, V>()
		{
			IDictionary<K, V> dictionary = JitHelpers.UnsafeCast<IDictionary<K, V>>(this);
			return (uint)dictionary.Count;
		}

		// Token: 0x0600643E RID: 25662 RVA: 0x00155D8C File Offset: 0x00153F8C
		[SecurityCritical]
		internal bool HasKey<K, V>(K key)
		{
			IDictionary<K, V> dictionary = JitHelpers.UnsafeCast<IDictionary<K, V>>(this);
			return dictionary.ContainsKey(key);
		}

		// Token: 0x0600643F RID: 25663 RVA: 0x00155DA8 File Offset: 0x00153FA8
		[SecurityCritical]
		internal IReadOnlyDictionary<K, V> GetView<K, V>()
		{
			IDictionary<K, V> dictionary = JitHelpers.UnsafeCast<IDictionary<K, V>>(this);
			IReadOnlyDictionary<K, V> readOnlyDictionary = dictionary as IReadOnlyDictionary<K, V>;
			if (readOnlyDictionary == null)
			{
				readOnlyDictionary = new ReadOnlyDictionary<K, V>(dictionary);
			}
			return readOnlyDictionary;
		}

		// Token: 0x06006440 RID: 25664 RVA: 0x00155DD0 File Offset: 0x00153FD0
		[SecurityCritical]
		internal bool Insert<K, V>(K key, V value)
		{
			IDictionary<K, V> dictionary = JitHelpers.UnsafeCast<IDictionary<K, V>>(this);
			bool result = dictionary.ContainsKey(key);
			dictionary[key] = value;
			return result;
		}

		// Token: 0x06006441 RID: 25665 RVA: 0x00155DF8 File Offset: 0x00153FF8
		[SecurityCritical]
		internal void Remove<K, V>(K key)
		{
			IDictionary<K, V> dictionary = JitHelpers.UnsafeCast<IDictionary<K, V>>(this);
			if (!dictionary.Remove(key))
			{
				Exception ex = new KeyNotFoundException(Environment.GetResourceString("Arg_KeyNotFound"));
				ex.SetErrorCode(-2147483637);
				throw ex;
			}
		}

		// Token: 0x06006442 RID: 25666 RVA: 0x00155E34 File Offset: 0x00154034
		[SecurityCritical]
		internal void Clear<K, V>()
		{
			IDictionary<K, V> dictionary = JitHelpers.UnsafeCast<IDictionary<K, V>>(this);
			dictionary.Clear();
		}
	}
}
