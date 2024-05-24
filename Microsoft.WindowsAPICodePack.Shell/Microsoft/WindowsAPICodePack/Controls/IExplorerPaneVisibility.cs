using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x02000027 RID: 39
	[Guid("e07010ec-bc17-44c0-97b0-46c7c95b9edc")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IExplorerPaneVisibility
	{
		// Token: 0x0600013B RID: 315
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetPaneState(ref Guid explorerPane, out ExplorerPaneState peps);
	}
}
