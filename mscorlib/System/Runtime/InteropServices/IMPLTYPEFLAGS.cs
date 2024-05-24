using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000992 RID: 2450
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IMPLTYPEFLAGS instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Flags]
	[Serializable]
	public enum IMPLTYPEFLAGS
	{
		// Token: 0x04002C12 RID: 11282
		IMPLTYPEFLAG_FDEFAULT = 1,
		// Token: 0x04002C13 RID: 11283
		IMPLTYPEFLAG_FSOURCE = 2,
		// Token: 0x04002C14 RID: 11284
		IMPLTYPEFLAG_FRESTRICTED = 4,
		// Token: 0x04002C15 RID: 11285
		IMPLTYPEFLAG_FDEFAULTVTABLE = 8
	}
}
