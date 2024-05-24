using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A37 RID: 2615
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct BINDPTR
	{
		// Token: 0x04002D58 RID: 11608
		[FieldOffset(0)]
		public IntPtr lpfuncdesc;

		// Token: 0x04002D59 RID: 11609
		[FieldOffset(0)]
		public IntPtr lpvardesc;

		// Token: 0x04002D5A RID: 11610
		[FieldOffset(0)]
		public IntPtr lptcomp;
	}
}
