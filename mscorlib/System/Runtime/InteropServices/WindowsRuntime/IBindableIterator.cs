using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A17 RID: 2583
	[Guid("6a1d6c07-076d-49f2-8314-f52c9c9a8331")]
	[ComImport]
	internal interface IBindableIterator
	{
		// Token: 0x1700117D RID: 4477
		// (get) Token: 0x060065C1 RID: 26049
		object Current { get; }

		// Token: 0x1700117E RID: 4478
		// (get) Token: 0x060065C2 RID: 26050
		bool HasCurrent { get; }

		// Token: 0x060065C3 RID: 26051
		bool MoveNext();
	}
}
