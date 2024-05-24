using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.ShellExtensions.Interop
{
	// Token: 0x0200000A RID: 10
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("7f73be3f-fb79-493c-a6c7-7ee14e245841")]
	[ComImport]
	internal interface IInitializeWithItem
	{
		// Token: 0x06000013 RID: 19
		void Initialize(IShellItem shellItem, AccessModes accessMode);
	}
}
