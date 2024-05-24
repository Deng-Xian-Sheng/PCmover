using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200016D RID: 365
	[Guid("93F2F68C-1D1B-11D3-A30E-00C04F79ABD1")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComConversionLoss]
	[ComImport]
	internal interface IShellFolder2 : IShellFolder
	{
		// Token: 0x06000E6D RID: 3693
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ParseDisplayName([In] IntPtr hwnd, [MarshalAs(UnmanagedType.Interface)] [In] IBindCtx pbc, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszDisplayName, [In] [Out] ref uint pchEaten, [Out] IntPtr ppidl, [In] [Out] ref uint pdwAttributes);

		// Token: 0x06000E6E RID: 3694
		[MethodImpl(MethodImplOptions.InternalCall)]
		void EnumObjects([In] IntPtr hwnd, [In] ShellNativeMethods.ShellFolderEnumerationOptions grfFlags, [MarshalAs(UnmanagedType.Interface)] out IEnumIDList ppenumIDList);

		// Token: 0x06000E6F RID: 3695
		[MethodImpl(MethodImplOptions.InternalCall)]
		void BindToObject([In] IntPtr pidl, IntPtr pbc, [In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IShellFolder ppv);

		// Token: 0x06000E70 RID: 3696
		[MethodImpl(MethodImplOptions.InternalCall)]
		void BindToStorage([In] ref IntPtr pidl, [MarshalAs(UnmanagedType.Interface)] [In] IBindCtx pbc, [In] ref Guid riid, out IntPtr ppv);

		// Token: 0x06000E71 RID: 3697
		[MethodImpl(MethodImplOptions.InternalCall)]
		void CompareIDs([In] IntPtr lParam, [In] ref IntPtr pidl1, [In] ref IntPtr pidl2);

		// Token: 0x06000E72 RID: 3698
		[MethodImpl(MethodImplOptions.InternalCall)]
		void CreateViewObject([In] IntPtr hwndOwner, [In] ref Guid riid, out IntPtr ppv);

		// Token: 0x06000E73 RID: 3699
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetAttributesOf([In] uint cidl, [In] IntPtr apidl, [In] [Out] ref uint rgfInOut);

		// Token: 0x06000E74 RID: 3700
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetUIObjectOf([In] IntPtr hwndOwner, [In] uint cidl, [In] IntPtr apidl, [In] ref Guid riid, [In] [Out] ref uint rgfReserved, out IntPtr ppv);

		// Token: 0x06000E75 RID: 3701
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetDisplayNameOf([In] ref IntPtr pidl, [In] uint uFlags, out IntPtr pName);

		// Token: 0x06000E76 RID: 3702
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetNameOf([In] IntPtr hwnd, [In] ref IntPtr pidl, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszName, [In] uint uFlags, [Out] IntPtr ppidlOut);

		// Token: 0x06000E77 RID: 3703
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetDefaultSearchGUID(out Guid pguid);

		// Token: 0x06000E78 RID: 3704
		[MethodImpl(MethodImplOptions.InternalCall)]
		void EnumSearches(out IntPtr ppenum);

		// Token: 0x06000E79 RID: 3705
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetDefaultColumn([In] uint dwRes, out uint pSort, out uint pDisplay);

		// Token: 0x06000E7A RID: 3706
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetDefaultColumnState([In] uint iColumn, out uint pcsFlags);

		// Token: 0x06000E7B RID: 3707
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetDetailsEx([In] ref IntPtr pidl, [In] ref PropertyKey pscid, [MarshalAs(UnmanagedType.Struct)] out object pv);

		// Token: 0x06000E7C RID: 3708
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetDetailsOf([In] ref IntPtr pidl, [In] uint iColumn, out IntPtr psd);

		// Token: 0x06000E7D RID: 3709
		[MethodImpl(MethodImplOptions.InternalCall)]
		void MapColumnToSCID([In] uint iColumn, out PropertyKey pscid);
	}
}
