using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x020009A0 RID: 2464
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.CALLCONV instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Serializable]
	public enum CALLCONV
	{
		// Token: 0x04002C69 RID: 11369
		CC_CDECL = 1,
		// Token: 0x04002C6A RID: 11370
		CC_MSCPASCAL,
		// Token: 0x04002C6B RID: 11371
		CC_PASCAL = 2,
		// Token: 0x04002C6C RID: 11372
		CC_MACPASCAL,
		// Token: 0x04002C6D RID: 11373
		CC_STDCALL,
		// Token: 0x04002C6E RID: 11374
		CC_RESERVED,
		// Token: 0x04002C6F RID: 11375
		CC_SYSCALL,
		// Token: 0x04002C70 RID: 11376
		CC_MPWCDECL,
		// Token: 0x04002C71 RID: 11377
		CC_MPWPASCAL,
		// Token: 0x04002C72 RID: 11378
		CC_MAX
	}
}
