using System;
using System.Runtime.InteropServices;
using System.Security;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x0200005E RID: 94
	[SuppressUnmanagedCodeSecurity]
	internal static class ExplorerBrowserNativeMethods
	{
		// Token: 0x06000301 RID: 769
		[DllImport("SHLWAPI.DLL", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern HResult IUnknown_SetSite([MarshalAs(UnmanagedType.IUnknown)] [In] object punk, [MarshalAs(UnmanagedType.IUnknown)] [In] object punkSite);

		// Token: 0x06000302 RID: 770
		[DllImport("SHLWAPI.DLL", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern HResult ConnectToConnectionPoint([MarshalAs(UnmanagedType.IUnknown)] [In] object punk, ref Guid riidEvent, [MarshalAs(UnmanagedType.Bool)] bool fConnect, [MarshalAs(UnmanagedType.IUnknown)] [In] object punkTarget, ref uint pdwCookie, ref IntPtr ppcpOut);
	}
}
