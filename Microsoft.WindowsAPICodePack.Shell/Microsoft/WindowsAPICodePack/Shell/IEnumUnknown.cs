using System;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000002 RID: 2
	[Guid("00000100-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IEnumUnknown
	{
		// Token: 0x06000001 RID: 1
		[PreserveSig]
		HResult Next(uint requestedNumber, ref IntPtr buffer, ref uint fetchedNumber);

		// Token: 0x06000002 RID: 2
		[PreserveSig]
		HResult Skip(uint number);

		// Token: 0x06000003 RID: 3
		[PreserveSig]
		HResult Reset();

		// Token: 0x06000004 RID: 4
		[PreserveSig]
		HResult Clone(out IEnumUnknown result);
	}
}
