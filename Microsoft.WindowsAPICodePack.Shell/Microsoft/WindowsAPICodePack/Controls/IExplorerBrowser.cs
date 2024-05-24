using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x02000058 RID: 88
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("DFD3B6B5-C10C-4BE9-85F6-A66969F402F6")]
	[ComImport]
	internal interface IExplorerBrowser
	{
		// Token: 0x0600029D RID: 669
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Initialize(IntPtr hwndParent, [In] ref NativeRect prc, [In] FolderSettings pfs);

		// Token: 0x0600029E RID: 670
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Destroy();

		// Token: 0x0600029F RID: 671
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetRect([In] [Out] ref IntPtr phdwp, NativeRect rcBrowser);

		// Token: 0x060002A0 RID: 672
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetPropertyBag([MarshalAs(UnmanagedType.LPWStr)] string pszPropertyBag);

		// Token: 0x060002A1 RID: 673
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetEmptyText([MarshalAs(UnmanagedType.LPWStr)] string pszEmptyText);

		// Token: 0x060002A2 RID: 674
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult SetFolderSettings(FolderSettings pfs);

		// Token: 0x060002A3 RID: 675
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult Advise(IntPtr psbe, out uint pdwCookie);

		// Token: 0x060002A4 RID: 676
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult Unadvise([In] uint dwCookie);

		// Token: 0x060002A5 RID: 677
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetOptions([In] ExplorerBrowserOptions dwFlag);

		// Token: 0x060002A6 RID: 678
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetOptions(out ExplorerBrowserOptions pdwFlag);

		// Token: 0x060002A7 RID: 679
		[MethodImpl(MethodImplOptions.InternalCall)]
		void BrowseToIDList(IntPtr pidl, uint uFlags);

		// Token: 0x060002A8 RID: 680
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult BrowseToObject([MarshalAs(UnmanagedType.IUnknown)] object punk, uint uFlags);

		// Token: 0x060002A9 RID: 681
		[MethodImpl(MethodImplOptions.InternalCall)]
		void FillFromObject([MarshalAs(UnmanagedType.IUnknown)] object punk, int dwFlags);

		// Token: 0x060002AA RID: 682
		[MethodImpl(MethodImplOptions.InternalCall)]
		void RemoveAll();

		// Token: 0x060002AB RID: 683
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetCurrentView(ref Guid riid, out IntPtr ppv);
	}
}
