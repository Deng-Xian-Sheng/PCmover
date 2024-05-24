using System;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000173 RID: 371
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("4FDEF69C-DBC9-454e-9910-B34F3C64B510")]
	[ComImport]
	internal interface IRichChunk
	{
		// Token: 0x06000EA6 RID: 3750
		[PreserveSig]
		HResult GetData();
	}
}
