using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x0200005D RID: 93
	[Guid("000214E3-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IShellView
	{
		// Token: 0x060002F4 RID: 756
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetWindow(out IntPtr phwnd);

		// Token: 0x060002F5 RID: 757
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult ContextSensitiveHelp(bool fEnterMode);

		// Token: 0x060002F6 RID: 758
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult TranslateAccelerator(IntPtr pmsg);

		// Token: 0x060002F7 RID: 759
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult EnableModeless(bool fEnable);

		// Token: 0x060002F8 RID: 760
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult UIActivate(uint uState);

		// Token: 0x060002F9 RID: 761
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult Refresh();

		// Token: 0x060002FA RID: 762
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult CreateViewWindow([MarshalAs(UnmanagedType.IUnknown)] object psvPrevious, IntPtr pfs, [MarshalAs(UnmanagedType.IUnknown)] object psb, IntPtr prcView, out IntPtr phWnd);

		// Token: 0x060002FB RID: 763
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult DestroyViewWindow();

		// Token: 0x060002FC RID: 764
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetCurrentInfo(out IntPtr pfs);

		// Token: 0x060002FD RID: 765
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult AddPropertySheetPages(uint dwReserved, IntPtr pfn, uint lparam);

		// Token: 0x060002FE RID: 766
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult SaveViewState();

		// Token: 0x060002FF RID: 767
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult SelectItem(IntPtr pidlItem, uint uFlags);

		// Token: 0x06000300 RID: 768
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetItemObject(ShellViewGetItemObject uItem, ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);
	}
}
