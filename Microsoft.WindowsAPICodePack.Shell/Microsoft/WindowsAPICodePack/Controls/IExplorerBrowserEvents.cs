using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x02000028 RID: 40
	[Guid("361bbdc7-e6ee-4e13-be58-58e2240c810f")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IExplorerBrowserEvents
	{
		// Token: 0x0600013C RID: 316
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult OnNavigationPending(IntPtr pidlFolder);

		// Token: 0x0600013D RID: 317
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult OnViewCreated([MarshalAs(UnmanagedType.IUnknown)] object psv);

		// Token: 0x0600013E RID: 318
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult OnNavigationComplete(IntPtr pidlFolder);

		// Token: 0x0600013F RID: 319
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult OnNavigationFailed(IntPtr pidlFolder);
	}
}
