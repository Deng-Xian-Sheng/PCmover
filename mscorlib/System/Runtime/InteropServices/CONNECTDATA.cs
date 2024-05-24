using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000980 RID: 2432
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.CONNECTDATA instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CONNECTDATA
	{
		// Token: 0x04002BDE RID: 11230
		[MarshalAs(UnmanagedType.Interface)]
		public object pUnk;

		// Token: 0x04002BDF RID: 11231
		public int dwCookie;
	}
}
