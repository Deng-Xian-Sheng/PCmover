using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x02000029 RID: 41
	[Guid("c8ad25a1-3294-41ee-8165-71174bd01c57")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface ICommDlgBrowser3
	{
		// Token: 0x06000140 RID: 320
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult OnDefaultCommand(IntPtr ppshv);

		// Token: 0x06000141 RID: 321
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult OnStateChange(IntPtr ppshv, CommDlgBrowserStateChange uChange);

		// Token: 0x06000142 RID: 322
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult IncludeObject(IntPtr ppshv, IntPtr pidl);

		// Token: 0x06000143 RID: 323
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetDefaultMenuText(IShellView shellView, IntPtr buffer, int bufferMaxLength);

		// Token: 0x06000144 RID: 324
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetViewFlags(out uint pdwFlags);

		// Token: 0x06000145 RID: 325
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult Notify(IntPtr pshv, CommDlgBrowserNotifyType notifyType);

		// Token: 0x06000146 RID: 326
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetCurrentFilter(StringBuilder pszFileSpec, int cchFileSpec);

		// Token: 0x06000147 RID: 327
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult OnColumnClicked(IShellView ppshv, int iColumn);

		// Token: 0x06000148 RID: 328
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult OnPreViewCreated(IShellView ppshv);
	}
}
