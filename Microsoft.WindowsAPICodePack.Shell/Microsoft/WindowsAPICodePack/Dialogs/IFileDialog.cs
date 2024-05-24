using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000143 RID: 323
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("42F85136-DB7E-439C-85F1-E4075D135FC8")]
	[ComImport]
	internal interface IFileDialog : IModalWindow
	{
		// Token: 0x06000DE0 RID: 3552
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		int Show([In] IntPtr parent);

		// Token: 0x06000DE1 RID: 3553
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFileTypes([In] uint cFileTypes, [MarshalAs(UnmanagedType.LPArray)] [In] ShellNativeMethods.FilterSpec[] rgFilterSpec);

		// Token: 0x06000DE2 RID: 3554
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFileTypeIndex([In] uint iFileType);

		// Token: 0x06000DE3 RID: 3555
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetFileTypeIndex(out uint piFileType);

		// Token: 0x06000DE4 RID: 3556
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Advise([MarshalAs(UnmanagedType.Interface)] [In] IFileDialogEvents pfde, out uint pdwCookie);

		// Token: 0x06000DE5 RID: 3557
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Unadvise([In] uint dwCookie);

		// Token: 0x06000DE6 RID: 3558
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetOptions([In] ShellNativeMethods.FileOpenOptions fos);

		// Token: 0x06000DE7 RID: 3559
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetOptions(out ShellNativeMethods.FileOpenOptions pfos);

		// Token: 0x06000DE8 RID: 3560
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetDefaultFolder([MarshalAs(UnmanagedType.Interface)] [In] IShellItem psi);

		// Token: 0x06000DE9 RID: 3561
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFolder([MarshalAs(UnmanagedType.Interface)] [In] IShellItem psi);

		// Token: 0x06000DEA RID: 3562
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetFolder([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

		// Token: 0x06000DEB RID: 3563
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetCurrentSelection([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

		// Token: 0x06000DEC RID: 3564
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFileName([MarshalAs(UnmanagedType.LPWStr)] [In] string pszName);

		// Token: 0x06000DED RID: 3565
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetFileName([MarshalAs(UnmanagedType.LPWStr)] out string pszName);

		// Token: 0x06000DEE RID: 3566
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetTitle([MarshalAs(UnmanagedType.LPWStr)] [In] string pszTitle);

		// Token: 0x06000DEF RID: 3567
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] [In] string pszText);

		// Token: 0x06000DF0 RID: 3568
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] [In] string pszLabel);

		// Token: 0x06000DF1 RID: 3569
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetResult([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

		// Token: 0x06000DF2 RID: 3570
		[MethodImpl(MethodImplOptions.InternalCall)]
		void AddPlace([MarshalAs(UnmanagedType.Interface)] [In] IShellItem psi, ShellNativeMethods.FileDialogAddPlacement fdap);

		// Token: 0x06000DF3 RID: 3571
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] [In] string pszDefaultExtension);

		// Token: 0x06000DF4 RID: 3572
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Close([MarshalAs(UnmanagedType.Error)] int hr);

		// Token: 0x06000DF5 RID: 3573
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetClientGuid([In] ref Guid guid);

		// Token: 0x06000DF6 RID: 3574
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ClearClientData();

		// Token: 0x06000DF7 RID: 3575
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFilter([MarshalAs(UnmanagedType.Interface)] IntPtr pFilter);
	}
}
