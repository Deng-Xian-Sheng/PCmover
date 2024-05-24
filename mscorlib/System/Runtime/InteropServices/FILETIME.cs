using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000986 RID: 2438
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.FILETIME instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	public struct FILETIME
	{
		// Token: 0x04002BE0 RID: 11232
		public int dwLowDateTime;

		// Token: 0x04002BE1 RID: 11233
		public int dwHighDateTime;
	}
}
