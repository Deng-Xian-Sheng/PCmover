using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009E3 RID: 2531
	[DebuggerDisplay("Count = {Count}")]
	internal sealed class IMapViewToIReadOnlyDictionaryAdapter
	{
		// Token: 0x0600647E RID: 25726 RVA: 0x001569DE File Offset: 0x00154BDE
		private IMapViewToIReadOnlyDictionaryAdapter()
		{
		}

		// Token: 0x0600647F RID: 25727 RVA: 0x001569E8 File Offset: 0x00154BE8
		[SecurityCritical]
		internal V Indexer_Get<K, V>(K key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			IMapView<K, V> this2 = JitHelpers.UnsafeCast<IMapView<K, V>>(this);
			return IMapViewToIReadOnlyDictionaryAdapter.Lookup<K, V>(this2, key);
		}

		// Token: 0x06006480 RID: 25728 RVA: 0x00156A18 File Offset: 0x00154C18
		[SecurityCritical]
		internal IEnumerable<K> Keys<K, V>()
		{
			IMapView<K, V> mapView = JitHelpers.UnsafeCast<IMapView<K, V>>(this);
			IReadOnlyDictionary<K, V> dictionary = (IReadOnlyDictionary<K, V>)mapView;
			return new ReadOnlyDictionaryKeyCollection<K, V>(dictionary);
		}

		// Token: 0x06006481 RID: 25729 RVA: 0x00156A3C File Offset: 0x00154C3C
		[SecurityCritical]
		internal IEnumerable<V> Values<K, V>()
		{
			IMapView<K, V> mapView = JitHelpers.UnsafeCast<IMapView<K, V>>(this);
			IReadOnlyDictionary<K, V> dictionary = (IReadOnlyDictionary<K, V>)mapView;
			return new ReadOnlyDictionaryValueCollection<K, V>(dictionary);
		}

		// Token: 0x06006482 RID: 25730 RVA: 0x00156A60 File Offset: 0x00154C60
		[SecurityCritical]
		internal bool ContainsKey<K, V>(K key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			IMapView<K, V> mapView = JitHelpers.UnsafeCast<IMapView<K, V>>(this);
			return mapView.HasKey(key);
		}

		// Token: 0x06006483 RID: 25731 RVA: 0x00156A90 File Offset: 0x00154C90
		[SecurityCritical]
		internal bool TryGetValue<K, V>(K key, out V value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			IMapView<K, V> mapView = JitHelpers.UnsafeCast<IMapView<K, V>>(this);
			if (!mapView.HasKey(key))
			{
				value = default(V);
				return false;
			}
			bool result;
			try
			{
				value = mapView.Lookup(key);
				result = true;
			}
			catch (Exception ex)
			{
				if (-2147483637 != ex._HResult)
				{
					throw;
				}
				value = default(V);
				result = false;
			}
			return result;
		}

		// Token: 0x06006484 RID: 25732 RVA: 0x00156B08 File Offset: 0x00154D08
		private static V Lookup<K, V>(IMapView<K, V> _this, K key)
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
	}
}
