using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000AF RID: 175
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("3c594f9f-9f30-47a1-979a-c9e83d3d0a06")]
	[ComImport]
	internal interface IApplicationDocumentLists
	{
		// Token: 0x060002EF RID: 751
		void SetAppID([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

		// Token: 0x060002F0 RID: 752
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object GetList([In] APPDOCLISTTYPE listtype, [In] uint cItemsDesired, [In] ref Guid riid);
	}
}
