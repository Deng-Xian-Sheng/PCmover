using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A42 RID: 2626
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct TYPEDESC
	{
		// Token: 0x04002DAC RID: 11692
		public IntPtr lpValue;

		// Token: 0x04002DAD RID: 11693
		[__DynamicallyInvokable]
		public short vt;
	}
}
