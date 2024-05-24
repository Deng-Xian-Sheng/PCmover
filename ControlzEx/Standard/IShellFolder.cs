using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ControlzEx.Standard
{
	// Token: 0x020000A7 RID: 167
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("000214E6-0000-0000-C000-000000000046")]
	[ComImport]
	internal interface IShellFolder
	{
		// Token: 0x060002A7 RID: 679
		void ParseDisplayName([In] IntPtr hwnd, [In] IBindCtx pbc, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszDisplayName, [In] [Out] ref int pchEaten, out IntPtr ppidl, [In] [Out] ref uint pdwAttributes);

		// Token: 0x060002A8 RID: 680
		IEnumIDList EnumObjects([In] IntPtr hwnd, [In] SHCONTF grfFlags);

		// Token: 0x060002A9 RID: 681
		[return: MarshalAs(UnmanagedType.Interface)]
		object BindToObject([In] IntPtr pidl, [In] IBindCtx pbc, [In] ref Guid riid);

		// Token: 0x060002AA RID: 682
		[return: MarshalAs(UnmanagedType.Interface)]
		object BindToStorage([In] IntPtr pidl, [In] IBindCtx pbc, [In] ref Guid riid);

		// Token: 0x060002AB RID: 683
		[PreserveSig]
		HRESULT CompareIDs([In] IntPtr lParam, [In] IntPtr pidl1, [In] IntPtr pidl2);

		// Token: 0x060002AC RID: 684
		[return: MarshalAs(UnmanagedType.Interface)]
		object CreateViewObject([In] IntPtr hwndOwner, [In] ref Guid riid);

		// Token: 0x060002AD RID: 685
		void GetAttributesOf([In] uint cidl, [In] IntPtr apidl, [In] [Out] ref SFGAO rgfInOut);

		// Token: 0x060002AE RID: 686
		[return: MarshalAs(UnmanagedType.Interface)]
		object GetUIObjectOf([In] IntPtr hwndOwner, [In] uint cidl, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 2)] [In] IntPtr apidl, [In] ref Guid riid, [In] [Out] ref uint rgfReserved);

		// Token: 0x060002AF RID: 687
		void GetDisplayNameOf([In] IntPtr pidl, [In] SHGDN uFlags, out IntPtr pName);

		// Token: 0x060002B0 RID: 688
		void SetNameOf([In] IntPtr hwnd, [In] IntPtr pidl, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszName, [In] SHGDN uFlags, out IntPtr ppidlOut);
	}
}
