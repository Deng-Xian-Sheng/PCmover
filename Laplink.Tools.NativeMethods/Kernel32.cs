using System;
using System.Runtime.InteropServices;

namespace Laplink.Tools.NativeMethods
{
	// Token: 0x02000004 RID: 4
	public static class Kernel32
	{
		// Token: 0x06000003 RID: 3
		[DllImport("kernel32", SetLastError = true)]
		public static extern bool CloseHandle(IntPtr handle);

		// Token: 0x06000004 RID: 4
		[DllImport("kernel32.dll")]
		public static extern uint SetThreadExecutionState(uint esFlags);

		// Token: 0x06000005 RID: 5
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DuplicateHandle(IntPtr hSourceProcessHandle, IntPtr hSourceHandle, IntPtr hTargetProcessHandle, out IntPtr lpTargetHandle, uint dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwOptions);

		// Token: 0x06000006 RID: 6
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetDllDirectory(string lpPathName);

		// Token: 0x06000007 RID: 7
		[DllImport("Kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern IntPtr CreateActCtx(ref Kernel32.ACTCTX actctx);

		// Token: 0x06000008 RID: 8
		[DllImport("Kernel32.dll")]
		public static extern bool ActivateActCtx(IntPtr hActCtx, out IntPtr lpCookie);

		// Token: 0x06000009 RID: 9
		[DllImport("Kernel32.dll")]
		public static extern bool DeactivateActCtx(uint dwFlags, IntPtr lpCookie);

		// Token: 0x0600000A RID: 10
		[DllImport("Kernel32.dll")]
		public static extern bool ReleaseActCtx(IntPtr hActCtx);

		// Token: 0x04000001 RID: 1
		public const uint ES_AWAYMODE_REQUIRED = 64U;

		// Token: 0x04000002 RID: 2
		public const uint ES_DISPLAY_REQUIRED = 2U;

		// Token: 0x04000003 RID: 3
		public const uint ES_CONTINUOUS = 2147483648U;

		// Token: 0x04000004 RID: 4
		public const uint ES_SYSTEM_REQUIRED = 1U;

		// Token: 0x0200000A RID: 10
		[Flags]
		public enum DuplicateOptions : uint
		{
			// Token: 0x04000023 RID: 35
			DUPLICATE_CLOSE_SOURCE = 1U,
			// Token: 0x04000024 RID: 36
			DUPLICATE_SAME_ACCESS = 2U
		}

		// Token: 0x0200000B RID: 11
		[Flags]
		public enum ACTCTX_FLAGS : uint
		{
			// Token: 0x04000026 RID: 38
			ACTCTX_FLAG_ASSEMBLY_DIRECTORY_VALID = 4U,
			// Token: 0x04000027 RID: 39
			ACTCTX_FLAG_RESOURCE_NAME_VALID = 8U
		}

		// Token: 0x0200000C RID: 12
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct ACTCTX
		{
			// Token: 0x04000028 RID: 40
			public uint cbSize;

			// Token: 0x04000029 RID: 41
			public Kernel32.ACTCTX_FLAGS dwFlags;

			// Token: 0x0400002A RID: 42
			public string lpSource;

			// Token: 0x0400002B RID: 43
			public ushort wProcessorArchitecture;

			// Token: 0x0400002C RID: 44
			public ushort wLangId;

			// Token: 0x0400002D RID: 45
			public string lpAssemblyDirectory;

			// Token: 0x0400002E RID: 46
			public IntPtr lpResourceName;

			// Token: 0x0400002F RID: 47
			public string lpApplicationName;

			// Token: 0x04000030 RID: 48
			public IntPtr hModule;
		}
	}
}
