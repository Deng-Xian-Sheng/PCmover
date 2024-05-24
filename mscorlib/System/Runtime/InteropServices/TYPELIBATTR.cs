using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x020009A6 RID: 2470
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.TYPELIBATTR instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Serializable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct TYPELIBATTR
	{
		// Token: 0x04002C98 RID: 11416
		public Guid guid;

		// Token: 0x04002C99 RID: 11417
		public int lcid;

		// Token: 0x04002C9A RID: 11418
		public SYSKIND syskind;

		// Token: 0x04002C9B RID: 11419
		public short wMajorVerNum;

		// Token: 0x04002C9C RID: 11420
		public short wMinorVerNum;

		// Token: 0x04002C9D RID: 11421
		public LIBFLAGS wLibFlags;
	}
}
