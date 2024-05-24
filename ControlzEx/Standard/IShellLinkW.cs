using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ControlzEx.Standard
{
	// Token: 0x020000AB RID: 171
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("000214F9-0000-0000-C000-000000000046")]
	[ComImport]
	public interface IShellLinkW
	{
		// Token: 0x060002CF RID: 719
		void GetPath([MarshalAs(UnmanagedType.LPWStr)] [Out] StringBuilder pszFile, int cchMaxPath, [In] [Out] WIN32_FIND_DATAW pfd, SLGP fFlags);

		// Token: 0x060002D0 RID: 720
		void GetIDList(out IntPtr ppidl);

		// Token: 0x060002D1 RID: 721
		void SetIDList(IntPtr pidl);

		// Token: 0x060002D2 RID: 722
		void GetDescription([MarshalAs(UnmanagedType.LPWStr)] [Out] StringBuilder pszFile, int cchMaxName);

		// Token: 0x060002D3 RID: 723
		void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);

		// Token: 0x060002D4 RID: 724
		void GetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] [Out] StringBuilder pszDir, int cchMaxPath);

		// Token: 0x060002D5 RID: 725
		void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);

		// Token: 0x060002D6 RID: 726
		void GetArguments([MarshalAs(UnmanagedType.LPWStr)] [Out] StringBuilder pszArgs, int cchMaxPath);

		// Token: 0x060002D7 RID: 727
		void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);

		// Token: 0x060002D8 RID: 728
		short GetHotKey();

		// Token: 0x060002D9 RID: 729
		void SetHotKey(short wHotKey);

		// Token: 0x060002DA RID: 730
		uint GetShowCmd();

		// Token: 0x060002DB RID: 731
		void SetShowCmd(uint iShowCmd);

		// Token: 0x060002DC RID: 732
		void GetIconLocation([MarshalAs(UnmanagedType.LPWStr)] [Out] StringBuilder pszIconPath, int cchIconPath, out int piIcon);

		// Token: 0x060002DD RID: 733
		void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);

		// Token: 0x060002DE RID: 734
		void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, uint dwReserved);

		// Token: 0x060002DF RID: 735
		void Resolve(IntPtr hwnd, uint fFlags);

		// Token: 0x060002E0 RID: 736
		void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
	}
}
