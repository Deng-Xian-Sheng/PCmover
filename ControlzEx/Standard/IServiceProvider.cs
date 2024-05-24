using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x02000082 RID: 130
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("6d5140c1-7436-11ce-8034-00aa006009fa")]
	[ComImport]
	internal interface IServiceProvider
	{
		// Token: 0x060001C0 RID: 448
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object QueryService(ref Guid guidService, ref Guid riid);
	}
}
