using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200099C RID: 2460
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.DISPPARAMS instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DISPPARAMS
	{
		// Token: 0x04002C51 RID: 11345
		public IntPtr rgvarg;

		// Token: 0x04002C52 RID: 11346
		public IntPtr rgdispidNamedArgs;

		// Token: 0x04002C53 RID: 11347
		public int cArgs;

		// Token: 0x04002C54 RID: 11348
		public int cNamedArgs;
	}
}
