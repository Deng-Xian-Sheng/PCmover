using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000998 RID: 2456
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.PARAMDESC instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct PARAMDESC
	{
		// Token: 0x04002C46 RID: 11334
		public IntPtr lpVarValue;

		// Token: 0x04002C47 RID: 11335
		public PARAMFLAG wParamFlags;
	}
}
