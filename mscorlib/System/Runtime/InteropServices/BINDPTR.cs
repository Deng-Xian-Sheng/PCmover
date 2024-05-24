using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200098E RID: 2446
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.BINDPTR instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct BINDPTR
	{
		// Token: 0x04002BF4 RID: 11252
		[FieldOffset(0)]
		public IntPtr lpfuncdesc;

		// Token: 0x04002BF5 RID: 11253
		[FieldOffset(0)]
		public IntPtr lpvardesc;

		// Token: 0x04002BF6 RID: 11254
		[FieldOffset(0)]
		public IntPtr lptcomp;
	}
}
