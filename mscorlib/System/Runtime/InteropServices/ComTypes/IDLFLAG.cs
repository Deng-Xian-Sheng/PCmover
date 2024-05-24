using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A3E RID: 2622
	[Flags]
	[__DynamicallyInvokable]
	[Serializable]
	public enum IDLFLAG : short
	{
		// Token: 0x04002D9A RID: 11674
		[__DynamicallyInvokable]
		IDLFLAG_NONE = 0,
		// Token: 0x04002D9B RID: 11675
		[__DynamicallyInvokable]
		IDLFLAG_FIN = 1,
		// Token: 0x04002D9C RID: 11676
		[__DynamicallyInvokable]
		IDLFLAG_FOUT = 2,
		// Token: 0x04002D9D RID: 11677
		[__DynamicallyInvokable]
		IDLFLAG_FLCID = 4,
		// Token: 0x04002D9E RID: 11678
		[__DynamicallyInvokable]
		IDLFLAG_FRETVAL = 8
	}
}
