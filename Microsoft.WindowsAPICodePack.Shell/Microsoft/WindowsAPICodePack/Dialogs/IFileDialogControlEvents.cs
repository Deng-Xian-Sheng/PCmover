using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000078 RID: 120
	[Guid("36116642-D713-4B97-9B83-7484A9D00433")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IFileDialogControlEvents
	{
		// Token: 0x06000429 RID: 1065
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OnItemSelected([MarshalAs(UnmanagedType.Interface)] [In] IFileDialogCustomize pfdc, [In] int dwIDCtl, [In] int dwIDItem);

		// Token: 0x0600042A RID: 1066
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OnButtonClicked([MarshalAs(UnmanagedType.Interface)] [In] IFileDialogCustomize pfdc, [In] int dwIDCtl);

		// Token: 0x0600042B RID: 1067
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OnCheckButtonToggled([MarshalAs(UnmanagedType.Interface)] [In] IFileDialogCustomize pfdc, [In] int dwIDCtl, [In] bool bChecked);

		// Token: 0x0600042C RID: 1068
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OnControlActivating([MarshalAs(UnmanagedType.Interface)] [In] IFileDialogCustomize pfdc, [In] int dwIDCtl);
	}
}
