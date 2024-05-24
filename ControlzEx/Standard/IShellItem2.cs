using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ControlzEx.Standard
{
	// Token: 0x020000AA RID: 170
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("7e9fb0d3-919f-4307-ab2e-9b1860310c93")]
	[ComImport]
	internal interface IShellItem2 : IShellItem
	{
		// Token: 0x060002BD RID: 701
		[return: MarshalAs(UnmanagedType.Interface)]
		object BindToHandler([In] IBindCtx pbc, [In] ref Guid bhid, [In] ref Guid riid);

		// Token: 0x060002BE RID: 702
		IShellItem GetParent();

		// Token: 0x060002BF RID: 703
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetDisplayName(SIGDN sigdnName);

		// Token: 0x060002C0 RID: 704
		SFGAO GetAttributes(SFGAO sfgaoMask);

		// Token: 0x060002C1 RID: 705
		int Compare(IShellItem psi, SICHINT hint);

		// Token: 0x060002C2 RID: 706
		[return: MarshalAs(UnmanagedType.Interface)]
		object GetPropertyStore(GPS flags, [In] ref Guid riid);

		// Token: 0x060002C3 RID: 707
		[return: MarshalAs(UnmanagedType.Interface)]
		object GetPropertyStoreWithCreateObject(GPS flags, [MarshalAs(UnmanagedType.IUnknown)] object punkCreateObject, [In] ref Guid riid);

		// Token: 0x060002C4 RID: 708
		[return: MarshalAs(UnmanagedType.Interface)]
		object GetPropertyStoreForKeys(IntPtr rgKeys, uint cKeys, GPS flags, [In] ref Guid riid);

		// Token: 0x060002C5 RID: 709
		[return: MarshalAs(UnmanagedType.Interface)]
		object GetPropertyDescriptionList(IntPtr keyType, [In] ref Guid riid);

		// Token: 0x060002C6 RID: 710
		void Update(IBindCtx pbc);

		// Token: 0x060002C7 RID: 711
		PROPVARIANT GetProperty(IntPtr key);

		// Token: 0x060002C8 RID: 712
		Guid GetCLSID(IntPtr key);

		// Token: 0x060002C9 RID: 713
		System.Runtime.InteropServices.ComTypes.FILETIME GetFileTime(IntPtr key);

		// Token: 0x060002CA RID: 714
		int GetInt32(IntPtr key);

		// Token: 0x060002CB RID: 715
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetString(IntPtr key);

		// Token: 0x060002CC RID: 716
		uint GetUInt32(IntPtr key);

		// Token: 0x060002CD RID: 717
		ulong GetUInt64(IntPtr key);

		// Token: 0x060002CE RID: 718
		[return: MarshalAs(UnmanagedType.Bool)]
		void GetBool(IntPtr key);
	}
}
