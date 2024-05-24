using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000094 RID: 148
	[Guid("3AA7AF7E-9B36-420c-A8E3-F77D4674A488")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IKnownFolderNative
	{
		// Token: 0x060004E8 RID: 1256
		[MethodImpl(MethodImplOptions.InternalCall)]
		Guid GetId();

		// Token: 0x060004E9 RID: 1257
		[MethodImpl(MethodImplOptions.InternalCall)]
		FolderCategory GetCategory();

		// Token: 0x060004EA RID: 1258
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetShellItem([In] int i, ref Guid interfaceGuid, [MarshalAs(UnmanagedType.Interface)] out IShellItem2 shellItem);

		// Token: 0x060004EB RID: 1259
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetPath([In] int option);

		// Token: 0x060004EC RID: 1260
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetPath([In] int i, [In] string path);

		// Token: 0x060004ED RID: 1261
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetIDList([In] int i, out IntPtr itemIdentifierListPointer);

		// Token: 0x060004EE RID: 1262
		[MethodImpl(MethodImplOptions.InternalCall)]
		Guid GetFolderType();

		// Token: 0x060004EF RID: 1263
		[MethodImpl(MethodImplOptions.InternalCall)]
		RedirectionCapability GetRedirectionCapabilities();

		// Token: 0x060004F0 RID: 1264
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetFolderDefinition([MarshalAs(UnmanagedType.Struct)] out KnownFoldersSafeNativeMethods.NativeFolderDefinition definition);
	}
}
