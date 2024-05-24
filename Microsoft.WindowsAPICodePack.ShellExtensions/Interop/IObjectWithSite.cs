using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.ShellExtensions.Interop
{
	// Token: 0x02000008 RID: 8
	[Guid("fc4801a3-2ba9-11cf-a229-00aa003d7352")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IObjectWithSite
	{
		// Token: 0x06000010 RID: 16
		void SetSite([MarshalAs(UnmanagedType.IUnknown)] [In] object pUnkSite);

		// Token: 0x06000011 RID: 17
		void GetSite(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppvSite);
	}
}
