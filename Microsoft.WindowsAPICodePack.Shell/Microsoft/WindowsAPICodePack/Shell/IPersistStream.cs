using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000171 RID: 369
	[Guid("00000109-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IPersistStream
	{
		// Token: 0x06000E95 RID: 3733
		[PreserveSig]
		void GetClassID(out Guid pClassID);

		// Token: 0x06000E96 RID: 3734
		[PreserveSig]
		HResult IsDirty();

		// Token: 0x06000E97 RID: 3735
		[PreserveSig]
		HResult Load([MarshalAs(UnmanagedType.Interface)] [In] IStream stm);

		// Token: 0x06000E98 RID: 3736
		[PreserveSig]
		HResult Save([MarshalAs(UnmanagedType.Interface)] [In] IStream stm, bool fRemember);

		// Token: 0x06000E99 RID: 3737
		[PreserveSig]
		HResult GetSizeMax(out ulong cbSize);
	}
}
