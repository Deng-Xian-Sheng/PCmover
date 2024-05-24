using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200099D RID: 2461
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.EXCEPINFO instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct EXCEPINFO
	{
		// Token: 0x04002C55 RID: 11349
		public short wCode;

		// Token: 0x04002C56 RID: 11350
		public short wReserved;

		// Token: 0x04002C57 RID: 11351
		[MarshalAs(UnmanagedType.BStr)]
		public string bstrSource;

		// Token: 0x04002C58 RID: 11352
		[MarshalAs(UnmanagedType.BStr)]
		public string bstrDescription;

		// Token: 0x04002C59 RID: 11353
		[MarshalAs(UnmanagedType.BStr)]
		public string bstrHelpFile;

		// Token: 0x04002C5A RID: 11354
		public int dwHelpContext;

		// Token: 0x04002C5B RID: 11355
		public IntPtr pvReserved;

		// Token: 0x04002C5C RID: 11356
		public IntPtr pfnDeferredFillIn;
	}
}
