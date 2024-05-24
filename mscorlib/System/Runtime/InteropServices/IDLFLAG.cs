using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000995 RID: 2453
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IDLFLAG instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Flags]
	[Serializable]
	public enum IDLFLAG : short
	{
		// Token: 0x04002C36 RID: 11318
		IDLFLAG_NONE = 0,
		// Token: 0x04002C37 RID: 11319
		IDLFLAG_FIN = 1,
		// Token: 0x04002C38 RID: 11320
		IDLFLAG_FOUT = 2,
		// Token: 0x04002C39 RID: 11321
		IDLFLAG_FLCID = 4,
		// Token: 0x04002C3A RID: 11322
		IDLFLAG_FRETVAL = 8
	}
}
