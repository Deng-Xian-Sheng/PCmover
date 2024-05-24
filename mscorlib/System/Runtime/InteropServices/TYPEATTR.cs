using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000993 RID: 2451
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.TYPEATTR instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct TYPEATTR
	{
		// Token: 0x04002C16 RID: 11286
		public const int MEMBER_ID_NIL = -1;

		// Token: 0x04002C17 RID: 11287
		public Guid guid;

		// Token: 0x04002C18 RID: 11288
		public int lcid;

		// Token: 0x04002C19 RID: 11289
		public int dwReserved;

		// Token: 0x04002C1A RID: 11290
		public int memidConstructor;

		// Token: 0x04002C1B RID: 11291
		public int memidDestructor;

		// Token: 0x04002C1C RID: 11292
		public IntPtr lpstrSchema;

		// Token: 0x04002C1D RID: 11293
		public int cbSizeInstance;

		// Token: 0x04002C1E RID: 11294
		public TYPEKIND typekind;

		// Token: 0x04002C1F RID: 11295
		public short cFuncs;

		// Token: 0x04002C20 RID: 11296
		public short cVars;

		// Token: 0x04002C21 RID: 11297
		public short cImplTypes;

		// Token: 0x04002C22 RID: 11298
		public short cbSizeVft;

		// Token: 0x04002C23 RID: 11299
		public short cbAlignment;

		// Token: 0x04002C24 RID: 11300
		public TYPEFLAGS wTypeFlags;

		// Token: 0x04002C25 RID: 11301
		public short wMajorVerNum;

		// Token: 0x04002C26 RID: 11302
		public short wMinorVerNum;

		// Token: 0x04002C27 RID: 11303
		public TYPEDESC tdescAlias;

		// Token: 0x04002C28 RID: 11304
		public IDLDESC idldescType;
	}
}
