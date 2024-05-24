using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000095 RID: 149
	[Guid("8BE2D872-86AA-4d47-B776-32CCA40C7018")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IKnownFolderManager
	{
		// Token: 0x060004F1 RID: 1265
		[MethodImpl(MethodImplOptions.InternalCall)]
		void FolderIdFromCsidl(int csidl, out Guid knownFolderID);

		// Token: 0x060004F2 RID: 1266
		[MethodImpl(MethodImplOptions.InternalCall)]
		void FolderIdToCsidl([MarshalAs(UnmanagedType.LPStruct)] [In] Guid id, out int csidl);

		// Token: 0x060004F3 RID: 1267
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetFolderIds(out IntPtr folders, out uint count);

		// Token: 0x060004F4 RID: 1268
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetFolder([MarshalAs(UnmanagedType.LPStruct)] [In] Guid id, [MarshalAs(UnmanagedType.Interface)] out IKnownFolderNative knownFolder);

		// Token: 0x060004F5 RID: 1269
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetFolderByName(string canonicalName, [MarshalAs(UnmanagedType.Interface)] out IKnownFolderNative knownFolder);

		// Token: 0x060004F6 RID: 1270
		[MethodImpl(MethodImplOptions.InternalCall)]
		void RegisterFolder([MarshalAs(UnmanagedType.LPStruct)] [In] Guid knownFolderGuid, [In] ref KnownFoldersSafeNativeMethods.NativeFolderDefinition knownFolderDefinition);

		// Token: 0x060004F7 RID: 1271
		[MethodImpl(MethodImplOptions.InternalCall)]
		void UnregisterFolder([MarshalAs(UnmanagedType.LPStruct)] [In] Guid knownFolderGuid);

		// Token: 0x060004F8 RID: 1272
		[MethodImpl(MethodImplOptions.InternalCall)]
		void FindFolderFromPath([MarshalAs(UnmanagedType.LPWStr)] [In] string path, [In] int mode, [MarshalAs(UnmanagedType.Interface)] out IKnownFolderNative knownFolder);

		// Token: 0x060004F9 RID: 1273
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult FindFolderFromIDList(IntPtr pidl, [MarshalAs(UnmanagedType.Interface)] out IKnownFolderNative knownFolder);

		// Token: 0x060004FA RID: 1274
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Redirect();
	}
}
