using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009EA RID: 2538
	[DebuggerDisplay("Size = {Size}")]
	internal sealed class IReadOnlyDictionaryToIMapViewAdapter
	{
		// Token: 0x0600649E RID: 25758 RVA: 0x00156D78 File Offset: 0x00154F78
		private IReadOnlyDictionaryToIMapViewAdapter()
		{
		}

		// Token: 0x0600649F RID: 25759 RVA: 0x00156D80 File Offset: 0x00154F80
		[SecurityCritical]
		internal V Lookup<K, V>(K key)
		{
			IReadOnlyDictionary<K, V> readOnlyDictionary = JitHelpers.UnsafeCast<IReadOnlyDictionary<K, V>>(this);
			V result;
			if (!readOnlyDictionary.TryGetValue(key, out result))
			{
				Exception ex = new KeyNotFoundException(Environment.GetResourceString("Arg_KeyNotFound"));
				ex.SetErrorCode(-2147483637);
				throw ex;
			}
			return result;
		}

		// Token: 0x060064A0 RID: 25760 RVA: 0x00156DC0 File Offset: 0x00154FC0
		[SecurityCritical]
		internal uint Size<K, V>()
		{
			IReadOnlyDictionary<K, V> readOnlyDictionary = JitHelpers.UnsafeCast<IReadOnlyDictionary<K, V>>(this);
			return (uint)readOnlyDictionary.Count;
		}

		// Token: 0x060064A1 RID: 25761 RVA: 0x00156DDC File Offset: 0x00154FDC
		[SecurityCritical]
		internal bool HasKey<K, V>(K key)
		{
			IReadOnlyDictionary<K, V> readOnlyDictionary = JitHelpers.UnsafeCast<IReadOnlyDictionary<K, V>>(this);
			return readOnlyDictionary.ContainsKey(key);
		}

		// Token: 0x060064A2 RID: 25762 RVA: 0x00156DF8 File Offset: 0x00154FF8
		[SecurityCritical]
		internal void Split<K, V>(out IMapView<K, V> first, out IMapView<K, V> second)
		{
			IReadOnlyDictionary<K, V> readOnlyDictionary = JitHelpers.UnsafeCast<IReadOnlyDictionary<K, V>>(this);
			if (readOnlyDictionary.Count < 2)
			{
				first = null;
				second = null;
				return;
			}
			ConstantSplittableMap<K, V> constantSplittableMap = readOnlyDictionary as ConstantSplittableMap<K, V>;
			if (constantSplittableMap == null)
			{
				constantSplittableMap = new ConstantSplittableMap<K, V>(readOnlyDictionary);
			}
			constantSplittableMap.Split(out first, out second);
		}
	}
}
