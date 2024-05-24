using System;
using System.Runtime.InteropServices;

namespace Laplink.Tools.NativeMethods
{
	// Token: 0x02000002 RID: 2
	public static class AdvApi32
	{
		// Token: 0x06000001 RID: 1
		[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool CreateProcessAsUser(IntPtr hToken, string lpApplicationName, string lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes, bool bInheritHandles, int dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, ref AdvApi32.STARTUPINFO lpStartupInfo, out AdvApi32.PROCESS_INFORMATION lpProcessInformation);

		// Token: 0x02000008 RID: 8
		public struct STARTUPINFO
		{
			// Token: 0x0400000C RID: 12
			public int cb;

			// Token: 0x0400000D RID: 13
			public string lpReserved;

			// Token: 0x0400000E RID: 14
			public string lpDesktop;

			// Token: 0x0400000F RID: 15
			public string lpTitle;

			// Token: 0x04000010 RID: 16
			public int dwX;

			// Token: 0x04000011 RID: 17
			public int dwY;

			// Token: 0x04000012 RID: 18
			public int dwXSize;

			// Token: 0x04000013 RID: 19
			public int dwYSize;

			// Token: 0x04000014 RID: 20
			public int dwXCountChars;

			// Token: 0x04000015 RID: 21
			public int dwYCountChars;

			// Token: 0x04000016 RID: 22
			public int dwFillAttribute;

			// Token: 0x04000017 RID: 23
			public int dwFlags;

			// Token: 0x04000018 RID: 24
			public short wShowWindow;

			// Token: 0x04000019 RID: 25
			public short cbReserved2;

			// Token: 0x0400001A RID: 26
			public IntPtr lpReserved2;

			// Token: 0x0400001B RID: 27
			public IntPtr hStdInput;

			// Token: 0x0400001C RID: 28
			public IntPtr hStdOutput;

			// Token: 0x0400001D RID: 29
			public IntPtr hStdError;
		}

		// Token: 0x02000009 RID: 9
		public struct PROCESS_INFORMATION
		{
			// Token: 0x0400001E RID: 30
			public IntPtr hProcess;

			// Token: 0x0400001F RID: 31
			public IntPtr hThread;

			// Token: 0x04000020 RID: 32
			public int dwProcessId;

			// Token: 0x04000021 RID: 33
			public int dwThreadId;
		}
	}
}
