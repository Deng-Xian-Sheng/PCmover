using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200099E RID: 2462
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.FUNCKIND instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Serializable]
	public enum FUNCKIND
	{
		// Token: 0x04002C5E RID: 11358
		FUNC_VIRTUAL,
		// Token: 0x04002C5F RID: 11359
		FUNC_PUREVIRTUAL,
		// Token: 0x04002C60 RID: 11360
		FUNC_NONVIRTUAL,
		// Token: 0x04002C61 RID: 11361
		FUNC_STATIC,
		// Token: 0x04002C62 RID: 11362
		FUNC_DISPATCH
	}
}
