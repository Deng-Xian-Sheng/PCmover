using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000997 RID: 2455
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.PARAMFLAG instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Flags]
	[Serializable]
	public enum PARAMFLAG : short
	{
		// Token: 0x04002C3E RID: 11326
		PARAMFLAG_NONE = 0,
		// Token: 0x04002C3F RID: 11327
		PARAMFLAG_FIN = 1,
		// Token: 0x04002C40 RID: 11328
		PARAMFLAG_FOUT = 2,
		// Token: 0x04002C41 RID: 11329
		PARAMFLAG_FLCID = 4,
		// Token: 0x04002C42 RID: 11330
		PARAMFLAG_FRETVAL = 8,
		// Token: 0x04002C43 RID: 11331
		PARAMFLAG_FOPT = 16,
		// Token: 0x04002C44 RID: 11332
		PARAMFLAG_FHASDEFAULT = 32,
		// Token: 0x04002C45 RID: 11333
		PARAMFLAG_FHASCUSTDATA = 64
	}
}
