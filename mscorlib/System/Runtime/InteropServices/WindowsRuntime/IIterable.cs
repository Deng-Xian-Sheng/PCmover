using System;
using System.Collections;
using System.Collections.Generic;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A14 RID: 2580
	[Guid("faa585ea-6214-4217-afda-7f46de5869b3")]
	[ComImport]
	internal interface IIterable<T> : IEnumerable<!0>, IEnumerable
	{
		// Token: 0x060065BB RID: 26043
		IIterator<T> First();
	}
}
