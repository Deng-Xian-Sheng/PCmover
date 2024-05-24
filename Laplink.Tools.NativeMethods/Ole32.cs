using System;
using System.Runtime.InteropServices;

namespace Laplink.Tools.NativeMethods
{
	// Token: 0x02000005 RID: 5
	public static class Ole32
	{
		// Token: 0x0600000B RID: 11
		[DllImport("ole32.dll")]
		public static extern void CoFreeUnusedLibrariesEx(uint dwUnloadDelay, uint dwReserved);
	}
}
