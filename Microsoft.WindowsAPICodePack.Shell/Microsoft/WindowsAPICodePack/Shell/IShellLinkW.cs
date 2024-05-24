using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200016F RID: 367
	[Guid("000214F9-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IShellLinkW
	{
		// Token: 0x06000E82 RID: 3714
		void GetPath([MarshalAs(UnmanagedType.LPWStr)] [Out] StringBuilder pszFile, int cchMaxPath, IntPtr pfd, uint fFlags);

		// Token: 0x06000E83 RID: 3715
		void GetIDList(out IntPtr ppidl);

		// Token: 0x06000E84 RID: 3716
		void SetIDList(IntPtr pidl);

		// Token: 0x06000E85 RID: 3717
		void GetDescription([MarshalAs(UnmanagedType.LPWStr)] [Out] StringBuilder pszFile, int cchMaxName);

		// Token: 0x06000E86 RID: 3718
		void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);

		// Token: 0x06000E87 RID: 3719
		void GetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] [Out] StringBuilder pszDir, int cchMaxPath);

		// Token: 0x06000E88 RID: 3720
		void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);

		// Token: 0x06000E89 RID: 3721
		void GetArguments([MarshalAs(UnmanagedType.LPWStr)] [Out] StringBuilder pszArgs, int cchMaxPath);

		// Token: 0x06000E8A RID: 3722
		void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);

		// Token: 0x06000E8B RID: 3723
		void GetHotKey(out short wHotKey);

		// Token: 0x06000E8C RID: 3724
		void SetHotKey(short wHotKey);

		// Token: 0x06000E8D RID: 3725
		void GetShowCmd(out uint iShowCmd);

		// Token: 0x06000E8E RID: 3726
		void SetShowCmd(uint iShowCmd);

		// Token: 0x06000E8F RID: 3727
		void GetIconLocation([MarshalAs(UnmanagedType.LPWStr)] out StringBuilder pszIconPath, int cchIconPath, out int iIcon);

		// Token: 0x06000E90 RID: 3728
		void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);

		// Token: 0x06000E91 RID: 3729
		void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, uint dwReserved);

		// Token: 0x06000E92 RID: 3730
		void Resolve(IntPtr hwnd, uint fFlags);

		// Token: 0x06000E93 RID: 3731
		void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
	}
}
