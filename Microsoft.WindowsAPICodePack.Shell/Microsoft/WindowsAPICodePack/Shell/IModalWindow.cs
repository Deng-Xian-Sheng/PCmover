using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000142 RID: 322
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("B4DB1657-70D7-485E-8E3E-6FCB5A5C1802")]
	[ComImport]
	internal interface IModalWindow
	{
		// Token: 0x06000DDF RID: 3551
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		int Show([In] IntPtr parent);
	}
}
