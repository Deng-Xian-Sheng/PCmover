using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A41 RID: 2625
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct PARAMDESC
	{
		// Token: 0x04002DAA RID: 11690
		public IntPtr lpVarValue;

		// Token: 0x04002DAB RID: 11691
		[__DynamicallyInvokable]
		public PARAMFLAG wParamFlags;
	}
}
