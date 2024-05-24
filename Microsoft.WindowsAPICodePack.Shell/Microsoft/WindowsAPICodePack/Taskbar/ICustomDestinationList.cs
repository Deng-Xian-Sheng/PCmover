using System;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x020000A5 RID: 165
	[Guid("6332DEBF-87B5-4670-90C0-5E57B408A49E")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface ICustomDestinationList
	{
		// Token: 0x06000561 RID: 1377
		void SetAppID([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

		// Token: 0x06000562 RID: 1378
		[PreserveSig]
		HResult BeginList(out uint cMaxSlots, ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppvObject);

		// Token: 0x06000563 RID: 1379
		[PreserveSig]
		HResult AppendCategory([MarshalAs(UnmanagedType.LPWStr)] string pszCategory, [MarshalAs(UnmanagedType.Interface)] IObjectArray poa);

		// Token: 0x06000564 RID: 1380
		void AppendKnownCategory([MarshalAs(UnmanagedType.I4)] KnownDestinationCategory category);

		// Token: 0x06000565 RID: 1381
		[PreserveSig]
		HResult AddUserTasks([MarshalAs(UnmanagedType.Interface)] IObjectArray poa);

		// Token: 0x06000566 RID: 1382
		void CommitList();

		// Token: 0x06000567 RID: 1383
		void GetRemovedDestinations(ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppvObject);

		// Token: 0x06000568 RID: 1384
		void DeleteList([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

		// Token: 0x06000569 RID: 1385
		void AbortList();
	}
}
