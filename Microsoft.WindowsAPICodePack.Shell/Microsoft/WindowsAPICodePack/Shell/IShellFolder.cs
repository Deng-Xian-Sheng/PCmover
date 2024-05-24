using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200016C RID: 364
	[Guid("000214E6-0000-0000-C000-000000000046")]
	[ComConversionLoss]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IShellFolder
	{
		// Token: 0x06000E63 RID: 3683
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ParseDisplayName(IntPtr hwnd, [MarshalAs(UnmanagedType.Interface)] [In] IBindCtx pbc, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszDisplayName, [In] [Out] ref uint pchEaten, [Out] IntPtr ppidl, [In] [Out] ref uint pdwAttributes);

		// Token: 0x06000E64 RID: 3684
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult EnumObjects([In] IntPtr hwnd, [In] ShellNativeMethods.ShellFolderEnumerationOptions grfFlags, [MarshalAs(UnmanagedType.Interface)] out IEnumIDList ppenumIDList);

		// Token: 0x06000E65 RID: 3685
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult BindToObject([In] IntPtr pidl, IntPtr pbc, [In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IShellFolder ppv);

		// Token: 0x06000E66 RID: 3686
		[MethodImpl(MethodImplOptions.InternalCall)]
		void BindToStorage([In] ref IntPtr pidl, [MarshalAs(UnmanagedType.Interface)] [In] IBindCtx pbc, [In] ref Guid riid, out IntPtr ppv);

		// Token: 0x06000E67 RID: 3687
		[MethodImpl(MethodImplOptions.InternalCall)]
		void CompareIDs([In] IntPtr lParam, [In] ref IntPtr pidl1, [In] ref IntPtr pidl2);

		// Token: 0x06000E68 RID: 3688
		[MethodImpl(MethodImplOptions.InternalCall)]
		void CreateViewObject([In] IntPtr hwndOwner, [In] ref Guid riid, out IntPtr ppv);

		// Token: 0x06000E69 RID: 3689
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetAttributesOf([In] uint cidl, [In] IntPtr apidl, [In] [Out] ref uint rgfInOut);

		// Token: 0x06000E6A RID: 3690
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetUIObjectOf([In] IntPtr hwndOwner, [In] uint cidl, [In] IntPtr apidl, [In] ref Guid riid, [In] [Out] ref uint rgfReserved, out IntPtr ppv);

		// Token: 0x06000E6B RID: 3691
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetDisplayNameOf([In] ref IntPtr pidl, [In] uint uFlags, out IntPtr pName);

		// Token: 0x06000E6C RID: 3692
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetNameOf([In] IntPtr hwnd, [In] ref IntPtr pidl, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszName, [In] uint uFlags, [Out] IntPtr ppidlOut);
	}
}
