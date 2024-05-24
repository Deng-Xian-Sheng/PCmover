using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A47 RID: 2631
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct EXCEPINFO
	{
		// Token: 0x04002DBF RID: 11711
		[__DynamicallyInvokable]
		public short wCode;

		// Token: 0x04002DC0 RID: 11712
		[__DynamicallyInvokable]
		public short wReserved;

		// Token: 0x04002DC1 RID: 11713
		[__DynamicallyInvokable]
		[MarshalAs(UnmanagedType.BStr)]
		public string bstrSource;

		// Token: 0x04002DC2 RID: 11714
		[__DynamicallyInvokable]
		[MarshalAs(UnmanagedType.BStr)]
		public string bstrDescription;

		// Token: 0x04002DC3 RID: 11715
		[__DynamicallyInvokable]
		[MarshalAs(UnmanagedType.BStr)]
		public string bstrHelpFile;

		// Token: 0x04002DC4 RID: 11716
		[__DynamicallyInvokable]
		public int dwHelpContext;

		// Token: 0x04002DC5 RID: 11717
		public IntPtr pvReserved;

		// Token: 0x04002DC6 RID: 11718
		public IntPtr pfnDeferredFillIn;

		// Token: 0x04002DC7 RID: 11719
		[__DynamicallyInvokable]
		public int scode;
	}
}
