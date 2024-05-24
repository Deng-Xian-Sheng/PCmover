using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x020009A5 RID: 2469
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.LIBFLAGS instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Flags]
	[Serializable]
	public enum LIBFLAGS : short
	{
		// Token: 0x04002C94 RID: 11412
		LIBFLAG_FRESTRICTED = 1,
		// Token: 0x04002C95 RID: 11413
		LIBFLAG_FCONTROL = 2,
		// Token: 0x04002C96 RID: 11414
		LIBFLAG_FHIDDEN = 4,
		// Token: 0x04002C97 RID: 11415
		LIBFLAG_FHASDISKIMAGE = 8
	}
}
