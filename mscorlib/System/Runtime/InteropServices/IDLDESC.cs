using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000996 RID: 2454
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IDLDESC instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct IDLDESC
	{
		// Token: 0x04002C3B RID: 11323
		public int dwReserved;

		// Token: 0x04002C3C RID: 11324
		public IDLFLAG wIDLFlags;
	}
}
