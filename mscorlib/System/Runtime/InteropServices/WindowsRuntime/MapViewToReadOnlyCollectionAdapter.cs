using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009D8 RID: 2520
	internal sealed class MapViewToReadOnlyCollectionAdapter
	{
		// Token: 0x0600642A RID: 25642 RVA: 0x00155960 File Offset: 0x00153B60
		private MapViewToReadOnlyCollectionAdapter()
		{
		}

		// Token: 0x0600642B RID: 25643 RVA: 0x00155968 File Offset: 0x00153B68
		[SecurityCritical]
		internal int Count<K, V>()
		{
			object obj = JitHelpers.UnsafeCast<object>(this);
			IMapView<K, V> mapView = obj as IMapView<K, V>;
			if (mapView != null)
			{
				uint size = mapView.Size;
				if (2147483647U < size)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CollectionBackingDictionaryTooLarge"));
				}
				return (int)size;
			}
			else
			{
				IVectorView<KeyValuePair<K, V>> vectorView = JitHelpers.UnsafeCast<IVectorView<KeyValuePair<K, V>>>(this);
				uint size2 = vectorView.Size;
				if (2147483647U < size2)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CollectionBackingListTooLarge"));
				}
				return (int)size2;
			}
		}
	}
}
