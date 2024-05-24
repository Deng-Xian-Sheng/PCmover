using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200016E RID: 366
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("000214F2-0000-0000-C000-000000000046")]
	[ComImport]
	internal interface IEnumIDList
	{
		// Token: 0x06000E7E RID: 3710
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult Next(uint celt, out IntPtr rgelt, out uint pceltFetched);

		// Token: 0x06000E7F RID: 3711
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult Skip([In] uint celt);

		// Token: 0x06000E80 RID: 3712
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult Reset();

		// Token: 0x06000E81 RID: 3713
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult Clone([MarshalAs(UnmanagedType.Interface)] out IEnumIDList ppenum);
	}
}
