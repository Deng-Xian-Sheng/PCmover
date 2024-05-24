using System;

namespace System.Runtime.Versioning
{
	// Token: 0x02000720 RID: 1824
	[Flags]
	public enum ResourceScope
	{
		// Token: 0x0400240C RID: 9228
		None = 0,
		// Token: 0x0400240D RID: 9229
		Machine = 1,
		// Token: 0x0400240E RID: 9230
		Process = 2,
		// Token: 0x0400240F RID: 9231
		AppDomain = 4,
		// Token: 0x04002410 RID: 9232
		Library = 8,
		// Token: 0x04002411 RID: 9233
		Private = 16,
		// Token: 0x04002412 RID: 9234
		Assembly = 32
	}
}
