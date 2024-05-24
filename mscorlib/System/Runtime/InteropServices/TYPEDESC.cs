using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000999 RID: 2457
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.TYPEDESC instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct TYPEDESC
	{
		// Token: 0x04002C48 RID: 11336
		public IntPtr lpValue;

		// Token: 0x04002C49 RID: 11337
		public short vt;
	}
}
