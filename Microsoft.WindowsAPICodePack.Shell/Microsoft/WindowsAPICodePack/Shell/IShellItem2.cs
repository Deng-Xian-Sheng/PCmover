using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000168 RID: 360
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("7E9FB0D3-919F-4307-AB2E-9B1860310C93")]
	[ComImport]
	internal interface IShellItem2 : IShellItem
	{
		// Token: 0x06000E49 RID: 3657
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult BindToHandler([In] IntPtr pbc, [In] ref Guid bhid, [In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IShellFolder ppv);

		// Token: 0x06000E4A RID: 3658
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetParent([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

		// Token: 0x06000E4B RID: 3659
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetDisplayName([In] ShellNativeMethods.ShellItemDesignNameOptions sigdnName, [MarshalAs(UnmanagedType.LPWStr)] out string ppszName);

		// Token: 0x06000E4C RID: 3660
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetAttributes([In] ShellNativeMethods.ShellFileGetAttributesOptions sfgaoMask, out ShellNativeMethods.ShellFileGetAttributesOptions psfgaoAttribs);

		// Token: 0x06000E4D RID: 3661
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Compare([MarshalAs(UnmanagedType.Interface)] [In] IShellItem psi, [In] uint hint, out int piOrder);

		// Token: 0x06000E4E RID: 3662
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		int GetPropertyStore([In] ShellNativeMethods.GetPropertyStoreOptions Flags, [In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IPropertyStore ppv);

		// Token: 0x06000E4F RID: 3663
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetPropertyStoreWithCreateObject([In] ShellNativeMethods.GetPropertyStoreOptions Flags, [MarshalAs(UnmanagedType.IUnknown)] [In] object punkCreateObject, [In] ref Guid riid, out IntPtr ppv);

		// Token: 0x06000E50 RID: 3664
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetPropertyStoreForKeys([In] ref PropertyKey rgKeys, [In] uint cKeys, [In] ShellNativeMethods.GetPropertyStoreOptions Flags, [In] ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out IPropertyStore ppv);

		// Token: 0x06000E51 RID: 3665
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetPropertyDescriptionList([In] ref PropertyKey keyType, [In] ref Guid riid, out IntPtr ppv);

		// Token: 0x06000E52 RID: 3666
		[MethodImpl(MethodImplOptions.InternalCall)]
		HResult Update([MarshalAs(UnmanagedType.Interface)] [In] IBindCtx pbc);

		// Token: 0x06000E53 RID: 3667
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetProperty([In] ref PropertyKey key, [Out] PropVariant ppropvar);

		// Token: 0x06000E54 RID: 3668
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetCLSID([In] ref PropertyKey key, out Guid pclsid);

		// Token: 0x06000E55 RID: 3669
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetFileTime([In] ref PropertyKey key, out System.Runtime.InteropServices.ComTypes.FILETIME pft);

		// Token: 0x06000E56 RID: 3670
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetInt32([In] ref PropertyKey key, out int pi);

		// Token: 0x06000E57 RID: 3671
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetString([In] ref PropertyKey key, [MarshalAs(UnmanagedType.LPWStr)] out string ppsz);

		// Token: 0x06000E58 RID: 3672
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetUInt32([In] ref PropertyKey key, out uint pui);

		// Token: 0x06000E59 RID: 3673
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetUInt64([In] ref PropertyKey key, out ulong pull);

		// Token: 0x06000E5A RID: 3674
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetBool([In] ref PropertyKey key, out int pf);
	}
}
