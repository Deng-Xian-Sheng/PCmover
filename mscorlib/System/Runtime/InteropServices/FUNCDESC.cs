using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000994 RID: 2452
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.FUNCDESC instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	public struct FUNCDESC
	{
		// Token: 0x04002C29 RID: 11305
		public int memid;

		// Token: 0x04002C2A RID: 11306
		public IntPtr lprgscode;

		// Token: 0x04002C2B RID: 11307
		public IntPtr lprgelemdescParam;

		// Token: 0x04002C2C RID: 11308
		public FUNCKIND funckind;

		// Token: 0x04002C2D RID: 11309
		public INVOKEKIND invkind;

		// Token: 0x04002C2E RID: 11310
		public CALLCONV callconv;

		// Token: 0x04002C2F RID: 11311
		public short cParams;

		// Token: 0x04002C30 RID: 11312
		public short cParamsOpt;

		// Token: 0x04002C31 RID: 11313
		public short oVft;

		// Token: 0x04002C32 RID: 11314
		public short cScodes;

		// Token: 0x04002C33 RID: 11315
		public ELEMDESC elemdescFunc;

		// Token: 0x04002C34 RID: 11316
		public short wFuncFlags;
	}
}
