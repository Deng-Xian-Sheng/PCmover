using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A46 RID: 2630
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DISPPARAMS
	{
		// Token: 0x04002DBB RID: 11707
		[__DynamicallyInvokable]
		public IntPtr rgvarg;

		// Token: 0x04002DBC RID: 11708
		[__DynamicallyInvokable]
		public IntPtr rgdispidNamedArgs;

		// Token: 0x04002DBD RID: 11709
		[__DynamicallyInvokable]
		public int cArgs;

		// Token: 0x04002DBE RID: 11710
		[__DynamicallyInvokable]
		public int cNamedArgs;
	}
}
