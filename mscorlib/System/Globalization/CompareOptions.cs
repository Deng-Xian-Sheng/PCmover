using System;
using System.Runtime.InteropServices;

namespace System.Globalization
{
	// Token: 0x020003A6 RID: 934
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum CompareOptions
	{
		// Token: 0x04001307 RID: 4871
		[__DynamicallyInvokable]
		None = 0,
		// Token: 0x04001308 RID: 4872
		[__DynamicallyInvokable]
		IgnoreCase = 1,
		// Token: 0x04001309 RID: 4873
		[__DynamicallyInvokable]
		IgnoreNonSpace = 2,
		// Token: 0x0400130A RID: 4874
		[__DynamicallyInvokable]
		IgnoreSymbols = 4,
		// Token: 0x0400130B RID: 4875
		[__DynamicallyInvokable]
		IgnoreKanaType = 8,
		// Token: 0x0400130C RID: 4876
		[__DynamicallyInvokable]
		IgnoreWidth = 16,
		// Token: 0x0400130D RID: 4877
		[__DynamicallyInvokable]
		OrdinalIgnoreCase = 268435456,
		// Token: 0x0400130E RID: 4878
		[__DynamicallyInvokable]
		StringSort = 536870912,
		// Token: 0x0400130F RID: 4879
		[__DynamicallyInvokable]
		Ordinal = 1073741824
	}
}
