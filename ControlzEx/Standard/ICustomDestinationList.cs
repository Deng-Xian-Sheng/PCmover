using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000B0 RID: 176
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("6332debf-87b5-4670-90c0-5e57b408a49e")]
	[ComImport]
	internal interface ICustomDestinationList
	{
		// Token: 0x060002F1 RID: 753
		void SetAppID([MarshalAs(UnmanagedType.LPWStr)] [In] string pszAppID);

		// Token: 0x060002F2 RID: 754
		[return: MarshalAs(UnmanagedType.Interface)]
		object BeginList(out uint pcMaxSlots, [In] ref Guid riid);

		// Token: 0x060002F3 RID: 755
		[PreserveSig]
		HRESULT AppendCategory([MarshalAs(UnmanagedType.LPWStr)] string pszCategory, IObjectArray poa);

		// Token: 0x060002F4 RID: 756
		void AppendKnownCategory(KDC category);

		// Token: 0x060002F5 RID: 757
		[PreserveSig]
		HRESULT AddUserTasks(IObjectArray poa);

		// Token: 0x060002F6 RID: 758
		void CommitList();

		// Token: 0x060002F7 RID: 759
		[return: MarshalAs(UnmanagedType.Interface)]
		object GetRemovedDestinations([In] ref Guid riid);

		// Token: 0x060002F8 RID: 760
		void DeleteList([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

		// Token: 0x060002F9 RID: 761
		void AbortList();
	}
}
