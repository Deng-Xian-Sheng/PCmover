using System;
using System.Collections;
using System.Collections.Generic;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A1A RID: 2586
	[Guid("bbe1fa4c-b0e3-4583-baef-1f1b2e483e56")]
	[ComImport]
	internal interface IVectorView<T> : IIterable<T>, IEnumerable<!0>, IEnumerable
	{
		// Token: 0x060065DC RID: 26076
		T GetAt(uint index);

		// Token: 0x17001181 RID: 4481
		// (get) Token: 0x060065DD RID: 26077
		uint Size { get; }

		// Token: 0x060065DE RID: 26078
		bool IndexOf(T value, out uint index);

		// Token: 0x060065DF RID: 26079
		uint GetMany(uint startIndex, [Out] T[] items);
	}
}
