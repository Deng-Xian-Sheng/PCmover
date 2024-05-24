using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000146 RID: 326
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("84BCCD23-5FDE-4CDB-AEA4-AF64B83D78AB")]
	[ComImport]
	internal interface IFileSaveDialog : IFileDialog, IModalWindow
	{
		// Token: 0x06000E12 RID: 3602
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		int Show([In] IntPtr parent);

		// Token: 0x06000E13 RID: 3603
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFileTypes([In] uint cFileTypes, [In] ref ShellNativeMethods.FilterSpec rgFilterSpec);

		// Token: 0x06000E14 RID: 3604
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFileTypeIndex([In] uint iFileType);

		// Token: 0x06000E15 RID: 3605
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetFileTypeIndex(out uint piFileType);

		// Token: 0x06000E16 RID: 3606
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Advise([MarshalAs(UnmanagedType.Interface)] [In] IFileDialogEvents pfde, out uint pdwCookie);

		// Token: 0x06000E17 RID: 3607
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Unadvise([In] uint dwCookie);

		// Token: 0x06000E18 RID: 3608
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetOptions([In] ShellNativeMethods.FileOpenOptions fos);

		// Token: 0x06000E19 RID: 3609
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetOptions(out ShellNativeMethods.FileOpenOptions pfos);

		// Token: 0x06000E1A RID: 3610
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetDefaultFolder([MarshalAs(UnmanagedType.Interface)] [In] IShellItem psi);

		// Token: 0x06000E1B RID: 3611
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFolder([MarshalAs(UnmanagedType.Interface)] [In] IShellItem psi);

		// Token: 0x06000E1C RID: 3612
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetFolder([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

		// Token: 0x06000E1D RID: 3613
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetCurrentSelection([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

		// Token: 0x06000E1E RID: 3614
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFileName([MarshalAs(UnmanagedType.LPWStr)] [In] string pszName);

		// Token: 0x06000E1F RID: 3615
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetFileName([MarshalAs(UnmanagedType.LPWStr)] out string pszName);

		// Token: 0x06000E20 RID: 3616
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetTitle([MarshalAs(UnmanagedType.LPWStr)] [In] string pszTitle);

		// Token: 0x06000E21 RID: 3617
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] [In] string pszText);

		// Token: 0x06000E22 RID: 3618
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] [In] string pszLabel);

		// Token: 0x06000E23 RID: 3619
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetResult([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

		// Token: 0x06000E24 RID: 3620
		[MethodImpl(MethodImplOptions.InternalCall)]
		void AddPlace([MarshalAs(UnmanagedType.Interface)] [In] IShellItem psi, ShellNativeMethods.FileDialogAddPlacement fdap);

		// Token: 0x06000E25 RID: 3621
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] [In] string pszDefaultExtension);

		// Token: 0x06000E26 RID: 3622
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Close([MarshalAs(UnmanagedType.Error)] int hr);

		// Token: 0x06000E27 RID: 3623
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetClientGuid([In] ref Guid guid);

		// Token: 0x06000E28 RID: 3624
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ClearClientData();

		// Token: 0x06000E29 RID: 3625
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFilter([MarshalAs(UnmanagedType.Interface)] IntPtr pFilter);

		// Token: 0x06000E2A RID: 3626
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetSaveAsItem([MarshalAs(UnmanagedType.Interface)] [In] IShellItem psi);

		// Token: 0x06000E2B RID: 3627
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetProperties([MarshalAs(UnmanagedType.Interface)] [In] IntPtr pStore);

		// Token: 0x06000E2C RID: 3628
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		int SetCollectedProperties([In] IPropertyDescriptionList pList, [In] bool fAppendDefault);

		// Token: 0x06000E2D RID: 3629
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetProperties(out IPropertyStore ppStore);

		// Token: 0x06000E2E RID: 3630
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ApplyProperties([MarshalAs(UnmanagedType.Interface)] [In] IShellItem psi, [MarshalAs(UnmanagedType.Interface)] [In] IntPtr pStore, [ComAliasName("ShellObjects.wireHWND")] [In] ref IntPtr hwnd, [MarshalAs(UnmanagedType.Interface)] [In] IntPtr pSink);
	}
}
