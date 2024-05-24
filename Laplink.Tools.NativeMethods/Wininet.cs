using System;
using System.Runtime.InteropServices;

namespace Laplink.Tools.NativeMethods
{
	// Token: 0x02000007 RID: 7
	public static class Wininet
	{
		// Token: 0x06000015 RID: 21
		[DllImport("wininet.dll")]
		public static extern bool InternetGetConnectedState(out int Description, int ReservedValue);
	}
}
