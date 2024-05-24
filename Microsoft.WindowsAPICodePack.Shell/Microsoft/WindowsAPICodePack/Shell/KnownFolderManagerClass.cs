using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000096 RID: 150
	[Guid("4df0c730-df9d-4ae3-9153-aa6b82e9795a")]
	[ComImport]
	internal class KnownFolderManagerClass : IKnownFolderManager
	{
		// Token: 0x060004FB RID: 1275
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void FolderIdFromCsidl(int csidl, out Guid knownFolderID);

		// Token: 0x060004FC RID: 1276
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void FolderIdToCsidl([MarshalAs(UnmanagedType.LPStruct)] [In] Guid id, out int csidl);

		// Token: 0x060004FD RID: 1277
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void GetFolderIds(out IntPtr folders, out uint count);

		// Token: 0x060004FE RID: 1278
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		public virtual extern HResult GetFolder([MarshalAs(UnmanagedType.LPStruct)] [In] Guid id, [MarshalAs(UnmanagedType.Interface)] out IKnownFolderNative knownFolder);

		// Token: 0x060004FF RID: 1279
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void GetFolderByName(string canonicalName, [MarshalAs(UnmanagedType.Interface)] out IKnownFolderNative knownFolder);

		// Token: 0x06000500 RID: 1280
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void RegisterFolder([MarshalAs(UnmanagedType.LPStruct)] [In] Guid knownFolderGuid, [In] ref KnownFoldersSafeNativeMethods.NativeFolderDefinition knownFolderDefinition);

		// Token: 0x06000501 RID: 1281
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void UnregisterFolder([MarshalAs(UnmanagedType.LPStruct)] [In] Guid knownFolderGuid);

		// Token: 0x06000502 RID: 1282
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void FindFolderFromPath([MarshalAs(UnmanagedType.LPWStr)] [In] string path, [In] int mode, [MarshalAs(UnmanagedType.Interface)] out IKnownFolderNative knownFolder);

		// Token: 0x06000503 RID: 1283
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		public virtual extern HResult FindFolderFromIDList(IntPtr pidl, [MarshalAs(UnmanagedType.Interface)] out IKnownFolderNative knownFolder);

		// Token: 0x06000504 RID: 1284
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void Redirect();

		// Token: 0x06000505 RID: 1285
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern KnownFolderManagerClass();
	}
}
