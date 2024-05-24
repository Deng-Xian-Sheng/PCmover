using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.ShellExtensions.Interop
{
	// Token: 0x02000009 RID: 9
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("b824b49d-22ac-4161-ac8a-9916e8fa3f7f")]
	[ComImport]
	internal interface IInitializeWithStream
	{
		// Token: 0x06000012 RID: 18
		void Initialize(IStream stream, AccessModes fileMode);
	}
}
