using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000A4 RID: 164
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("92CA9DCD-5622-4bba-A805-5E9F541BD8C9")]
	[ComImport]
	internal interface IObjectArray
	{
		// Token: 0x0600029A RID: 666
		uint GetCount();

		// Token: 0x0600029B RID: 667
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object GetAt([In] uint uiIndex, [In] ref Guid riid);
	}
}
