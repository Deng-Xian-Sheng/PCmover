using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009D5 RID: 2517
	internal sealed class VectorViewToReadOnlyCollectionAdapter
	{
		// Token: 0x06006415 RID: 25621 RVA: 0x00155473 File Offset: 0x00153673
		private VectorViewToReadOnlyCollectionAdapter()
		{
		}

		// Token: 0x06006416 RID: 25622 RVA: 0x0015547C File Offset: 0x0015367C
		[SecurityCritical]
		internal int Count<T>()
		{
			IVectorView<T> vectorView = JitHelpers.UnsafeCast<IVectorView<T>>(this);
			uint size = vectorView.Size;
			if (2147483647U < size)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CollectionBackingListTooLarge"));
			}
			return (int)size;
		}
	}
}
