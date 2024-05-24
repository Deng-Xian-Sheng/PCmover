using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000077 RID: 119
	[Guid("973510DB-7D7F-452B-8975-74A85828D354")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IFileDialogEvents
	{
		// Token: 0x06000422 RID: 1058
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult OnFileOk([MarshalAs(UnmanagedType.Interface)] [In] IFileDialog pfd);

		// Token: 0x06000423 RID: 1059
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult OnFolderChanging([MarshalAs(UnmanagedType.Interface)] [In] IFileDialog pfd, [MarshalAs(UnmanagedType.Interface)] [In] IShellItem psiFolder);

		// Token: 0x06000424 RID: 1060
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OnFolderChange([MarshalAs(UnmanagedType.Interface)] [In] IFileDialog pfd);

		// Token: 0x06000425 RID: 1061
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OnSelectionChange([MarshalAs(UnmanagedType.Interface)] [In] IFileDialog pfd);

		// Token: 0x06000426 RID: 1062
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OnShareViolation([MarshalAs(UnmanagedType.Interface)] [In] IFileDialog pfd, [MarshalAs(UnmanagedType.Interface)] [In] IShellItem psi, out ShellNativeMethods.FileDialogEventShareViolationResponse pResponse);

		// Token: 0x06000427 RID: 1063
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OnTypeChange([MarshalAs(UnmanagedType.Interface)] [In] IFileDialog pfd);

		// Token: 0x06000428 RID: 1064
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OnOverwrite([MarshalAs(UnmanagedType.Interface)] [In] IFileDialog pfd, [MarshalAs(UnmanagedType.Interface)] [In] IShellItem psi, out ShellNativeMethods.FileDialogEventOverwriteResponse pResponse);
	}
}
