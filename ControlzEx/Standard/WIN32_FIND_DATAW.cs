using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ControlzEx.Standard
{
	// Token: 0x02000076 RID: 118
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[BestFitMapping(false)]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class WIN32_FIND_DATAW
	{
		// Token: 0x04000595 RID: 1429
		public FileAttributes dwFileAttributes;

		// Token: 0x04000596 RID: 1430
		public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;

		// Token: 0x04000597 RID: 1431
		public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;

		// Token: 0x04000598 RID: 1432
		public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;

		// Token: 0x04000599 RID: 1433
		public int nFileSizeHigh;

		// Token: 0x0400059A RID: 1434
		public int nFileSizeLow;

		// Token: 0x0400059B RID: 1435
		public int dwReserved0;

		// Token: 0x0400059C RID: 1436
		public int dwReserved1;

		// Token: 0x0400059D RID: 1437
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string cFileName;

		// Token: 0x0400059E RID: 1438
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
		public string cAlternateFileName;
	}
}
