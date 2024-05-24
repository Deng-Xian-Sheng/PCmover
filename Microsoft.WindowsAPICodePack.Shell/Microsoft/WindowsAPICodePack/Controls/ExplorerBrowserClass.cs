using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x02000059 RID: 89
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("71F96385-DDD6-48D3-A0C1-AE06E8B055FB")]
	[TypeLibType(TypeLibTypeFlags.FCanCreate)]
	[ComImport]
	internal class ExplorerBrowserClass : IExplorerBrowser
	{
		// Token: 0x060002AC RID: 684
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void Initialize(IntPtr hwndParent, [In] ref NativeRect prc, [In] FolderSettings pfs);

		// Token: 0x060002AD RID: 685
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void Destroy();

		// Token: 0x060002AE RID: 686
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void SetRect([In] [Out] ref IntPtr phdwp, NativeRect rcBrowser);

		// Token: 0x060002AF RID: 687
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void SetPropertyBag([MarshalAs(UnmanagedType.LPWStr)] string pszPropertyBag);

		// Token: 0x060002B0 RID: 688
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void SetEmptyText([MarshalAs(UnmanagedType.LPWStr)] string pszEmptyText);

		// Token: 0x060002B1 RID: 689
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		public virtual extern HResult SetFolderSettings(FolderSettings pfs);

		// Token: 0x060002B2 RID: 690
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		public virtual extern HResult Advise(IntPtr psbe, out uint pdwCookie);

		// Token: 0x060002B3 RID: 691
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		public virtual extern HResult Unadvise(uint dwCookie);

		// Token: 0x060002B4 RID: 692
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void SetOptions([In] ExplorerBrowserOptions dwFlag);

		// Token: 0x060002B5 RID: 693
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void GetOptions(out ExplorerBrowserOptions pdwFlag);

		// Token: 0x060002B6 RID: 694
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void BrowseToIDList(IntPtr pidl, uint uFlags);

		// Token: 0x060002B7 RID: 695
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		public virtual extern HResult BrowseToObject([MarshalAs(UnmanagedType.IUnknown)] object punk, uint uFlags);

		// Token: 0x060002B8 RID: 696
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void FillFromObject([MarshalAs(UnmanagedType.IUnknown)] object punk, int dwFlags);

		// Token: 0x060002B9 RID: 697
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void RemoveAll();

		// Token: 0x060002BA RID: 698
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		public virtual extern HResult GetCurrentView(ref Guid riid, out IntPtr ppv);

		// Token: 0x060002BB RID: 699
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern ExplorerBrowserClass();
	}
}
