using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009D6 RID: 2518
	internal sealed class MapToDictionaryAdapter
	{
		// Token: 0x06006417 RID: 25623 RVA: 0x001554B0 File Offset: 0x001536B0
		private MapToDictionaryAdapter()
		{
		}

		// Token: 0x06006418 RID: 25624 RVA: 0x001554B8 File Offset: 0x001536B8
		[SecurityCritical]
		internal V Indexer_Get<K, V>(K key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			IMap<K, V> this2 = JitHelpers.UnsafeCast<IMap<K, V>>(this);
			return MapToDictionaryAdapter.Lookup<K, V>(this2, key);
		}

		// Token: 0x06006419 RID: 25625 RVA: 0x001554E8 File Offset: 0x001536E8
		[SecurityCritical]
		internal void Indexer_Set<K, V>(K key, V value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			IMap<K, V> this2 = JitHelpers.UnsafeCast<IMap<K, V>>(this);
			MapToDictionaryAdapter.Insert<K, V>(this2, key, value);
		}

		// Token: 0x0600641A RID: 25626 RVA: 0x00155518 File Offset: 0x00153718
		[SecurityCritical]
		internal ICollection<K> Keys<K, V>()
		{
			IMap<K, V> map = JitHelpers.UnsafeCast<IMap<K, V>>(this);
			IDictionary<K, V> dictionary = (IDictionary<K, V>)map;
			return new DictionaryKeyCollection<K, V>(dictionary);
		}

		// Token: 0x0600641B RID: 25627 RVA: 0x0015553C File Offset: 0x0015373C
		[SecurityCritical]
		internal ICollection<V> Values<K, V>()
		{
			IMap<K, V> map = JitHelpers.UnsafeCast<IMap<K, V>>(this);
			IDictionary<K, V> dictionary = (IDictionary<K, V>)map;
			return new DictionaryValueCollection<K, V>(dictionary);
		}

		// Token: 0x0600641C RID: 25628 RVA: 0x00155560 File Offset: 0x00153760
		[SecurityCritical]
		internal bool ContainsKey<K, V>(K key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			IMap<K, V> map = JitHelpers.UnsafeCast<IMap<K, V>>(this);
			return map.HasKey(key);
		}

		// Token: 0x0600641D RID: 25629 RVA: 0x00155590 File Offset: 0x00153790
		[SecurityCritical]
		internal void Add<K, V>(K key, V value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (this.ContainsKey<K, V>(key))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_AddingDuplicate"));
			}
			IMap<K, V> this2 = JitHelpers.UnsafeCast<IMap<K, V>>(this);
			MapToDictionaryAdapter.Insert<K, V>(this2, key, value);
		}

		// Token: 0x0600641E RID: 25630 RVA: 0x001555DC File Offset: 0x001537DC
		[SecurityCritical]
		internal bool Remove<K, V>(K key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			IMap<K, V> map = JitHelpers.UnsafeCast<IMap<K, V>>(this);
			if (!map.HasKey(key))
			{
				return false;
			}
			bool result;
			try
			{
				map.Remove(key);
				result = true;
			}
			catch (Exception ex)
			{
				if (-2147483637 != ex._HResult)
				{
					throw;
				}
				result = false;
			}
			return result;
		}

		// Token: 0x0600641F RID: 25631 RVA: 0x00155640 File Offset: 0x00153840
		[SecurityCritical]
		internal bool TryGetValue<K, V>(K key, out V value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			IMap<K, V> map = JitHelpers.UnsafeCast<IMap<K, V>>(this);
			if (!map.HasKey(key))
			{
				value = default(V);
				return false;
			}
			bool result;
			try
			{
				value = MapToDictionaryAdapter.Lookup<K, V>(map, key);
				result = true;
			}
			catch (KeyNotFoundException)
			{
				value = default(V);
				result = false;
			}
			return result;
		}

		// Token: 0x06006420 RID: 25632 RVA: 0x001556A8 File Offset: 0x001538A8
		private static V Lookup<K, V>(IMap<K, V> _this, K key)
		{
			V result;
			try
			{
				result = _this.Lookup(key);
			}
			catch (Exception ex)
			{
				if (-2147483637 == ex._HResult)
				{
					throw new KeyNotFoundException(Environment.GetResourceString("Arg_KeyNotFound"));
				}
				throw;
			}
			return result;
		}

		// Token: 0x06006421 RID: 25633 RVA: 0x001556F0 File Offset: 0x001538F0
		private static bool Insert<K, V>(IMap<K, V> _this, K key, V value)
		{
			return _this.Insert(key, value);
		}
	}
}
