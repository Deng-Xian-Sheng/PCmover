using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x0200005A RID: 90
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("cde725b0-ccc9-4519-917e-325d72fab4ce")]
	[ComImport]
	internal interface IFolderView
	{
		// Token: 0x060002BC RID: 700
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetCurrentViewMode(out uint pViewMode);

		// Token: 0x060002BD RID: 701
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetCurrentViewMode(uint ViewMode);

		// Token: 0x060002BE RID: 702
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetFolder(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

		// Token: 0x060002BF RID: 703
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Item(int iItemIndex, out IntPtr ppidl);

		// Token: 0x060002C0 RID: 704
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ItemCount(uint uFlags, out int pcItems);

		// Token: 0x060002C1 RID: 705
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Items(uint uFlags, ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

		// Token: 0x060002C2 RID: 706
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetSelectionMarkedItem(out int piItem);

		// Token: 0x060002C3 RID: 707
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetFocusedItem(out int piItem);

		// Token: 0x060002C4 RID: 708
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetItemPosition(IntPtr pidl, out NativePoint ppt);

		// Token: 0x060002C5 RID: 709
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetSpacing(out NativePoint ppt);

		// Token: 0x060002C6 RID: 710
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetDefaultSpacing(out NativePoint ppt);

		// Token: 0x060002C7 RID: 711
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetAutoArrange();

		// Token: 0x060002C8 RID: 712
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SelectItem(int iItem, uint dwFlags);

		// Token: 0x060002C9 RID: 713
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SelectAndPositionItems(uint cidl, IntPtr apidl, ref NativePoint apt, uint dwFlags);
	}
}
