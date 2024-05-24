using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;

namespace System.StubHelpers
{
	// Token: 0x020005A7 RID: 1447
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static class KeyValuePairMarshaler
	{
		// Token: 0x06004325 RID: 17189 RVA: 0x000FA208 File Offset: 0x000F8408
		[SecurityCritical]
		internal static IntPtr ConvertToNative<K, V>([In] ref KeyValuePair<K, V> pair)
		{
			IKeyValuePair<K, V> o = new CLRIKeyValuePairImpl<K, V>(ref pair);
			return Marshal.GetComInterfaceForObject(o, typeof(IKeyValuePair<K, V>));
		}

		// Token: 0x06004326 RID: 17190 RVA: 0x000FA22C File Offset: 0x000F842C
		[SecurityCritical]
		internal static KeyValuePair<K, V> ConvertToManaged<K, V>(IntPtr pInsp)
		{
			object obj = InterfaceMarshaler.ConvertToManagedWithoutUnboxing(pInsp);
			IKeyValuePair<K, V> keyValuePair = (IKeyValuePair<K, V>)obj;
			return new KeyValuePair<K, V>(keyValuePair.Key, keyValuePair.Value);
		}

		// Token: 0x06004327 RID: 17191 RVA: 0x000FA258 File Offset: 0x000F8458
		[SecurityCritical]
		internal static object ConvertToManagedBox<K, V>(IntPtr pInsp)
		{
			return KeyValuePairMarshaler.ConvertToManaged<K, V>(pInsp);
		}
	}
}
