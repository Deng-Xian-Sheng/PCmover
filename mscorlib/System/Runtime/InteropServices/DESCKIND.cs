using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200098D RID: 2445
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.DESCKIND instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Serializable]
	public enum DESCKIND
	{
		// Token: 0x04002BEE RID: 11246
		DESCKIND_NONE,
		// Token: 0x04002BEF RID: 11247
		DESCKIND_FUNCDESC,
		// Token: 0x04002BF0 RID: 11248
		DESCKIND_VARDESC,
		// Token: 0x04002BF1 RID: 11249
		DESCKIND_TYPECOMP,
		// Token: 0x04002BF2 RID: 11250
		DESCKIND_IMPLICITAPPOBJ,
		// Token: 0x04002BF3 RID: 11251
		DESCKIND_MAX
	}
}
