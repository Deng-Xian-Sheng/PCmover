using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000B6 RID: 182
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("b4db1657-70d7-485e-8e3e-6fcb5a5c1802")]
	[ComImport]
	internal interface IModalWindow
	{
		// Token: 0x0600032A RID: 810
		[PreserveSig]
		HRESULT Show(IntPtr parent);
	}
}
