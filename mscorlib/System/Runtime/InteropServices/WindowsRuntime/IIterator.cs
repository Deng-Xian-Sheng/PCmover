using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A16 RID: 2582
	[Guid("6a79e863-4300-459a-9966-cbb660963ee1")]
	[ComImport]
	internal interface IIterator<T>
	{
		// Token: 0x1700117B RID: 4475
		// (get) Token: 0x060065BD RID: 26045
		T Current { get; }

		// Token: 0x1700117C RID: 4476
		// (get) Token: 0x060065BE RID: 26046
		bool HasCurrent { get; }

		// Token: 0x060065BF RID: 26047
		bool MoveNext();

		// Token: 0x060065C0 RID: 26048
		int GetMany([Out] T[] items);
	}
}
