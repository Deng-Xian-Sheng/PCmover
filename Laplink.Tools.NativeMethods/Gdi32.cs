using System;
using System.Runtime.InteropServices;

namespace Laplink.Tools.NativeMethods
{
	// Token: 0x02000003 RID: 3
	public static class Gdi32
	{
		// Token: 0x06000002 RID: 2
		[DllImport("gdi32.dll")]
		public static extern bool DeleteObject(IntPtr hObject);
	}
}
