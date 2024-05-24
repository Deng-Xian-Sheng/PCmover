using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000048 RID: 72
	[Guid("11A66EFA-382E-451A-9234-1E0E12EF3085")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IShellLibrary
	{
		// Token: 0x0600028A RID: 650
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult LoadLibraryFromItem([MarshalAs(UnmanagedType.Interface)] [In] IShellItem library, [In] AccessModes grfMode);

		// Token: 0x0600028B RID: 651
		[MethodImpl(MethodImplOptions.InternalCall)]
		void LoadLibraryFromKnownFolder([In] ref Guid knownfidLibrary, [In] AccessModes grfMode);

		// Token: 0x0600028C RID: 652
		[MethodImpl(MethodImplOptions.InternalCall)]
		void AddFolder([MarshalAs(UnmanagedType.Interface)] [In] IShellItem location);

		// Token: 0x0600028D RID: 653
		[MethodImpl(MethodImplOptions.InternalCall)]
		void RemoveFolder([MarshalAs(UnmanagedType.Interface)] [In] IShellItem location);

		// Token: 0x0600028E RID: 654
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetFolders([In] ShellNativeMethods.LibraryFolderFilter lff, [In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IShellItemArray ppv);

		// Token: 0x0600028F RID: 655
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ResolveFolder([MarshalAs(UnmanagedType.Interface)] [In] IShellItem folderToResolve, [In] uint timeout, [In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IShellItem ppv);

		// Token: 0x06000290 RID: 656
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetDefaultSaveFolder([In] ShellNativeMethods.DefaultSaveFolderType dsft, [In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IShellItem ppv);

		// Token: 0x06000291 RID: 657
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetDefaultSaveFolder([In] ShellNativeMethods.DefaultSaveFolderType dsft, [MarshalAs(UnmanagedType.Interface)] [In] IShellItem si);

		// Token: 0x06000292 RID: 658
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetOptions(out ShellNativeMethods.LibraryOptions lofOptions);

		// Token: 0x06000293 RID: 659
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetOptions([In] ShellNativeMethods.LibraryOptions lofMask, [In] ShellNativeMethods.LibraryOptions lofOptions);

		// Token: 0x06000294 RID: 660
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetFolderType(out Guid ftid);

		// Token: 0x06000295 RID: 661
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFolderType([In] ref Guid ftid);

		// Token: 0x06000296 RID: 662
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetIcon([MarshalAs(UnmanagedType.LPWStr)] out string icon);

		// Token: 0x06000297 RID: 663
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetIcon([MarshalAs(UnmanagedType.LPWStr)] [In] string icon);

		// Token: 0x06000298 RID: 664
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Commit();

		// Token: 0x06000299 RID: 665
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Save([MarshalAs(UnmanagedType.Interface)] [In] IShellItem folderToSaveIn, [MarshalAs(UnmanagedType.LPWStr)] [In] string libraryName, [In] ShellNativeMethods.LibrarySaveOptions lsf, [MarshalAs(UnmanagedType.Interface)] out IShellItem2 savedTo);

		// Token: 0x0600029A RID: 666
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SaveInKnownFolder([In] ref Guid kfidToSaveIn, [MarshalAs(UnmanagedType.LPWStr)] [In] string libraryName, [In] ShellNativeMethods.LibrarySaveOptions lsf, [MarshalAs(UnmanagedType.Interface)] out IShellItem2 savedTo);
	}
}
