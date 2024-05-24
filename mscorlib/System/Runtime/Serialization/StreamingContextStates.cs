using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	// Token: 0x02000744 RID: 1860
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum StreamingContextStates
	{
		// Token: 0x0400245D RID: 9309
		CrossProcess = 1,
		// Token: 0x0400245E RID: 9310
		CrossMachine = 2,
		// Token: 0x0400245F RID: 9311
		File = 4,
		// Token: 0x04002460 RID: 9312
		Persistence = 8,
		// Token: 0x04002461 RID: 9313
		Remoting = 16,
		// Token: 0x04002462 RID: 9314
		Other = 32,
		// Token: 0x04002463 RID: 9315
		Clone = 64,
		// Token: 0x04002464 RID: 9316
		CrossAppDomain = 128,
		// Token: 0x04002465 RID: 9317
		All = 255
	}
}
