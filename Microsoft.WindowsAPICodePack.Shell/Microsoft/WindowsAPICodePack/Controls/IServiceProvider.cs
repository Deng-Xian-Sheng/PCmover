using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x02000026 RID: 38
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("6d5140c1-7436-11ce-8034-00aa006009fa")]
	[ComImport]
	internal interface IServiceProvider
	{
		// Token: 0x0600013A RID: 314
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult QueryService(ref Guid guidService, ref Guid riid, out IntPtr ppvObject);
	}
}
