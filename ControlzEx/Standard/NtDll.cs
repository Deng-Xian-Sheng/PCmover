using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x02000089 RID: 137
	public static class NtDll
	{
		// Token: 0x06000289 RID: 649 RVA: 0x000097D4 File Offset: 0x000079D4
		public static Version RtlGetVersion()
		{
			NtDll.OSVERSIONINFOEX osversioninfoex = default(NtDll.OSVERSIONINFOEX);
			osversioninfoex.dwOSVersionInfoSize = (uint)Marshal.SizeOf(typeof(NtDll.OSVERSIONINFOEX));
			if (NtDll.NativeMethods.RtlGetVersion(ref osversioninfoex) == 0)
			{
				return new Version((int)osversioninfoex.dwMajorVersion, (int)osversioninfoex.dwMinorVersion, (int)osversioninfoex.dwBuildNumber, 0);
			}
			return null;
		}

		// Token: 0x020000D6 RID: 214
		public struct OSVERSIONINFOEX
		{
			// Token: 0x04000719 RID: 1817
			public uint dwOSVersionInfoSize;

			// Token: 0x0400071A RID: 1818
			public uint dwMajorVersion;

			// Token: 0x0400071B RID: 1819
			public uint dwMinorVersion;

			// Token: 0x0400071C RID: 1820
			public uint dwBuildNumber;

			// Token: 0x0400071D RID: 1821
			public uint dwPlatformId;

			// Token: 0x0400071E RID: 1822
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string szCSDVersion;

			// Token: 0x0400071F RID: 1823
			public ushort wServicePackMajor;

			// Token: 0x04000720 RID: 1824
			public ushort wServicePackMinor;

			// Token: 0x04000721 RID: 1825
			public ushort wSuiteMask;

			// Token: 0x04000722 RID: 1826
			public byte wProductType;

			// Token: 0x04000723 RID: 1827
			public byte wReserved;
		}

		// Token: 0x020000D7 RID: 215
		public static class NativeMethods
		{
			// Token: 0x0600044F RID: 1103
			[DllImport("ntdll.dll", CharSet = CharSet.Unicode)]
			public static extern int RtlGetVersion([In] [Out] ref NtDll.OSVERSIONINFOEX version);
		}
	}
}
