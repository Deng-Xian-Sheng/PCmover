using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x02000069 RID: 105
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal class SHARDAPPIDINFOLINK
	{
		// Token: 0x04000554 RID: 1364
		private IntPtr psl;

		// Token: 0x04000555 RID: 1365
		[MarshalAs(UnmanagedType.LPWStr)]
		private string pszAppID;
	}
}
