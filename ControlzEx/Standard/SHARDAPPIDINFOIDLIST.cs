using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x02000068 RID: 104
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public class SHARDAPPIDINFOIDLIST
	{
		// Token: 0x04000552 RID: 1362
		private IntPtr pidl;

		// Token: 0x04000553 RID: 1363
		[MarshalAs(UnmanagedType.LPWStr)]
		private string pszAppID;
	}
}
