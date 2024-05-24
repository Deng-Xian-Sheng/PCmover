using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A1F RID: 2591
	[Guid("02b51929-c1c4-4a7e-8940-0312b5c18500")]
	[ComImport]
	internal interface IKeyValuePair<K, V>
	{
		// Token: 0x17001186 RID: 4486
		// (get) Token: 0x060065F8 RID: 26104
		K Key { get; }

		// Token: 0x17001187 RID: 4487
		// (get) Token: 0x060065F9 RID: 26105
		V Value { get; }
	}
}
