using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200098B RID: 2443
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.STATSTG instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct STATSTG
	{
		// Token: 0x04002BE2 RID: 11234
		public string pwcsName;

		// Token: 0x04002BE3 RID: 11235
		public int type;

		// Token: 0x04002BE4 RID: 11236
		public long cbSize;

		// Token: 0x04002BE5 RID: 11237
		public FILETIME mtime;

		// Token: 0x04002BE6 RID: 11238
		public FILETIME ctime;

		// Token: 0x04002BE7 RID: 11239
		public FILETIME atime;

		// Token: 0x04002BE8 RID: 11240
		public int grfMode;

		// Token: 0x04002BE9 RID: 11241
		public int grfLocksSupported;

		// Token: 0x04002BEA RID: 11242
		public Guid clsid;

		// Token: 0x04002BEB RID: 11243
		public int grfStateBits;

		// Token: 0x04002BEC RID: 11244
		public int reserved;
	}
}
