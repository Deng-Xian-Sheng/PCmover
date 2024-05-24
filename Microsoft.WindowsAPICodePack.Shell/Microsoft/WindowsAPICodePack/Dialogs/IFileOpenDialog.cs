using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000144 RID: 324
	[Guid("D57C7288-D4AD-4768-BE02-9D969532D960")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IFileOpenDialog : IFileDialog, IModalWindow
	{
		// Token: 0x06000DF8 RID: 3576
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		int Show([In] IntPtr parent);

		// Token: 0x06000DF9 RID: 3577
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFileTypes([In] uint cFileTypes, [In] ref ShellNativeMethods.FilterSpec rgFilterSpec);

		// Token: 0x06000DFA RID: 3578
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFileTypeIndex([In] uint iFileType);

		// Token: 0x06000DFB RID: 3579
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetFileTypeIndex(out uint piFileType);

		// Token: 0x06000DFC RID: 3580
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Advise([MarshalAs(UnmanagedType.Interface)] [In] IFileDialogEvents pfde, out uint pdwCookie);

		// Token: 0x06000DFD RID: 3581
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Unadvise([In] uint dwCookie);

		// Token: 0x06000DFE RID: 3582
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetOptions([In] ShellNativeMethods.FileOpenOptions fos);

		// Token: 0x06000DFF RID: 3583
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetOptions(out ShellNativeMethods.FileOpenOptions pfos);

		// Token: 0x06000E00 RID: 3584
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetDefaultFolder([MarshalAs(UnmanagedType.Interface)] [In] IShellItem psi);

		// Token: 0x06000E01 RID: 3585
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFolder([MarshalAs(UnmanagedType.Interface)] [In] IShellItem psi);

		// Token: 0x06000E02 RID: 3586
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetFolder([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

		// Token: 0x06000E03 RID: 3587
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetCurrentSelection([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

		// Token: 0x06000E04 RID: 3588
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFileName([MarshalAs(UnmanagedType.LPWStr)] [In] string pszName);

		// Token: 0x06000E05 RID: 3589
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetFileName([MarshalAs(UnmanagedType.LPWStr)] out string pszName);

		// Token: 0x06000E06 RID: 3590
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetTitle([MarshalAs(UnmanagedType.LPWStr)] [In] string pszTitle);

		// Token: 0x06000E07 RID: 3591
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] [In] string pszText);

		// Token: 0x06000E08 RID: 3592
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] [In] string pszLabel);

		// Token: 0x06000E09 RID: 3593
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetResult([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

		// Token: 0x06000E0A RID: 3594
		[MethodImpl(MethodImplOptions.InternalCall)]
		void AddPlace([MarshalAs(UnmanagedType.Interface)] [In] IShellItem psi, ShellNativeMethods.FileDialogAddPlacement fdap);

		// Token: 0x06000E0B RID: 3595
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] [In] string pszDefaultExtension);

		// Token: 0x06000E0C RID: 3596
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Close([MarshalAs(UnmanagedType.Error)] int hr);

		// Token: 0x06000E0D RID: 3597
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetClientGuid([In] ref Guid guid);

		// Token: 0x06000E0E RID: 3598
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ClearClientData();

		// Token: 0x06000E0F RID: 3599
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFilter([MarshalAs(UnmanagedType.Interface)] IntPtr pFilter);

		// Token: 0x06000E10 RID: 3600
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetResults([MarshalAs(UnmanagedType.Interface)] out IShellItemArray ppenum);

		// Token: 0x06000E11 RID: 3601
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetSelectedItems([MarshalAs(UnmanagedType.Interface)] out IShellItemArray ppsai);
	}
}
