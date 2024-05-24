using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x02000067 RID: 103
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public class SHARDAPPIDINFO
	{
		// Token: 0x04000550 RID: 1360
		[MarshalAs(UnmanagedType.Interface)]
		private object psi;

		// Token: 0x04000551 RID: 1361
		[MarshalAs(UnmanagedType.LPWStr)]
		private string pszAppID;
	}
}
