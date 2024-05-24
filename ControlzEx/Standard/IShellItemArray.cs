using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ControlzEx.Standard
{
	// Token: 0x020000A9 RID: 169
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("B63EA76D-1F85-456F-A19C-48159EFA858B")]
	[ComImport]
	internal interface IShellItemArray
	{
		// Token: 0x060002B6 RID: 694
		[return: MarshalAs(UnmanagedType.Interface)]
		object BindToHandler(IBindCtx pbc, [In] ref Guid rbhid, [In] ref Guid riid);

		// Token: 0x060002B7 RID: 695
		[return: MarshalAs(UnmanagedType.Interface)]
		object GetPropertyStore(int flags, [In] ref Guid riid);

		// Token: 0x060002B8 RID: 696
		[return: MarshalAs(UnmanagedType.Interface)]
		object GetPropertyDescriptionList([In] ref PKEY keyType, [In] ref Guid riid);

		// Token: 0x060002B9 RID: 697
		uint GetAttributes(SIATTRIBFLAGS dwAttribFlags, uint sfgaoMask);

		// Token: 0x060002BA RID: 698
		uint GetCount();

		// Token: 0x060002BB RID: 699
		IShellItem GetItemAt(uint dwIndex);

		// Token: 0x060002BC RID: 700
		[return: MarshalAs(UnmanagedType.Interface)]
		object EnumItems();
	}
}
