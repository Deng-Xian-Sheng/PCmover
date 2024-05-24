using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A4F RID: 2639
	[Flags]
	[__DynamicallyInvokable]
	[Serializable]
	public enum LIBFLAGS : short
	{
		// Token: 0x04002E00 RID: 11776
		[__DynamicallyInvokable]
		LIBFLAG_FRESTRICTED = 1,
		// Token: 0x04002E01 RID: 11777
		[__DynamicallyInvokable]
		LIBFLAG_FCONTROL = 2,
		// Token: 0x04002E02 RID: 11778
		[__DynamicallyInvokable]
		LIBFLAG_FHIDDEN = 4,
		// Token: 0x04002E03 RID: 11779
		[__DynamicallyInvokable]
		LIBFLAG_FHASDISKIMAGE = 8
	}
}
