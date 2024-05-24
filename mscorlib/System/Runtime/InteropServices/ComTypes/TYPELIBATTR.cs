using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A50 RID: 2640
	[__DynamicallyInvokable]
	[Serializable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct TYPELIBATTR
	{
		// Token: 0x04002E04 RID: 11780
		[__DynamicallyInvokable]
		public Guid guid;

		// Token: 0x04002E05 RID: 11781
		[__DynamicallyInvokable]
		public int lcid;

		// Token: 0x04002E06 RID: 11782
		[__DynamicallyInvokable]
		public SYSKIND syskind;

		// Token: 0x04002E07 RID: 11783
		[__DynamicallyInvokable]
		public short wMajorVerNum;

		// Token: 0x04002E08 RID: 11784
		[__DynamicallyInvokable]
		public short wMinorVerNum;

		// Token: 0x04002E09 RID: 11785
		[__DynamicallyInvokable]
		public LIBFLAGS wLibFlags;
	}
}
