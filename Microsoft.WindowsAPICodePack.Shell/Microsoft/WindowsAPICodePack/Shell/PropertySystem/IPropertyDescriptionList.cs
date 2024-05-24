using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x0200009C RID: 156
	[Guid("1F9FC1D0-C39B-4B26-817F-011967D3440E")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IPropertyDescriptionList
	{
		// Token: 0x06000510 RID: 1296
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetCount(out uint pcElem);

		// Token: 0x06000511 RID: 1297
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetAt([In] uint iElem, [In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IPropertyDescription ppv);
	}
}
