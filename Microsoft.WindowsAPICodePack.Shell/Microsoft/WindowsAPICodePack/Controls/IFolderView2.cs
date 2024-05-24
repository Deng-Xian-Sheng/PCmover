using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x0200005B RID: 91
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("1af3a467-214f-4298-908e-06b03e0b39f9")]
	[ComImport]
	internal interface IFolderView2 : IFolderView
	{
		// Token: 0x060002CA RID: 714
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetCurrentViewMode(out uint pViewMode);

		// Token: 0x060002CB RID: 715
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetCurrentViewMode(uint ViewMode);

		// Token: 0x060002CC RID: 716
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetFolder(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

		// Token: 0x060002CD RID: 717
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Item(int iItemIndex, out IntPtr ppidl);

		// Token: 0x060002CE RID: 718
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult ItemCount(uint uFlags, out int pcItems);

		// Token: 0x060002CF RID: 719
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult Items(uint uFlags, ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

		// Token: 0x060002D0 RID: 720
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetSelectionMarkedItem(out int piItem);

		// Token: 0x060002D1 RID: 721
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetFocusedItem(out int piItem);

		// Token: 0x060002D2 RID: 722
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetItemPosition(IntPtr pidl, out NativePoint ppt);

		// Token: 0x060002D3 RID: 723
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetSpacing(out NativePoint ppt);

		// Token: 0x060002D4 RID: 724
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetDefaultSpacing(out NativePoint ppt);

		// Token: 0x060002D5 RID: 725
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetAutoArrange();

		// Token: 0x060002D6 RID: 726
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SelectItem(int iItem, uint dwFlags);

		// Token: 0x060002D7 RID: 727
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SelectAndPositionItems(uint cidl, IntPtr apidl, ref NativePoint apt, uint dwFlags);

		// Token: 0x060002D8 RID: 728
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetGroupBy(IntPtr key, bool fAscending);

		// Token: 0x060002D9 RID: 729
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetGroupBy(ref IntPtr pkey, ref bool pfAscending);

		// Token: 0x060002DA RID: 730
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetViewProperty(IntPtr pidl, IntPtr propkey, object propvar);

		// Token: 0x060002DB RID: 731
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetViewProperty(IntPtr pidl, IntPtr propkey, out object ppropvar);

		// Token: 0x060002DC RID: 732
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetTileViewProperties(IntPtr pidl, [MarshalAs(UnmanagedType.LPWStr)] string pszPropList);

		// Token: 0x060002DD RID: 733
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetExtendedTileViewProperties(IntPtr pidl, [MarshalAs(UnmanagedType.LPWStr)] string pszPropList);

		// Token: 0x060002DE RID: 734
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetText(int iType, [MarshalAs(UnmanagedType.LPWStr)] string pwszText);

		// Token: 0x060002DF RID: 735
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetCurrentFolderFlags(uint dwMask, uint dwFlags);

		// Token: 0x060002E0 RID: 736
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetCurrentFolderFlags(out uint pdwFlags);

		// Token: 0x060002E1 RID: 737
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetSortColumnCount(out int pcColumns);

		// Token: 0x060002E2 RID: 738
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetSortColumns(IntPtr rgSortColumns, int cColumns);

		// Token: 0x060002E3 RID: 739
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetSortColumns(out IntPtr rgSortColumns, int cColumns);

		// Token: 0x060002E4 RID: 740
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetItem(int iItem, ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

		// Token: 0x060002E5 RID: 741
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetVisibleItem(int iStart, bool fPrevious, out int piItem);

		// Token: 0x060002E6 RID: 742
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetSelectedItem(int iStart, out int piItem);

		// Token: 0x060002E7 RID: 743
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetSelection(bool fNoneImpliesFolder, out IShellItemArray ppsia);

		// Token: 0x060002E8 RID: 744
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetSelectionState(IntPtr pidl, out uint pdwFlags);

		// Token: 0x060002E9 RID: 745
		[MethodImpl(MethodImplOptions.InternalCall)]
		void InvokeVerbOnSelection([MarshalAs(UnmanagedType.LPWStr)] [In] string pszVerb);

		// Token: 0x060002EA RID: 746
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult SetViewModeAndIconSize(int uViewMode, int iImageSize);

		// Token: 0x060002EB RID: 747
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetViewModeAndIconSize(out int puViewMode, out int piImageSize);

		// Token: 0x060002EC RID: 748
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetGroupSubsetCount(uint cVisibleRows);

		// Token: 0x060002ED RID: 749
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetGroupSubsetCount(out uint pcVisibleRows);

		// Token: 0x060002EE RID: 750
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetRedraw(bool fRedrawOn);

		// Token: 0x060002EF RID: 751
		[MethodImpl(MethodImplOptions.InternalCall)]
		void IsMoveInSameFolder();

		// Token: 0x060002F0 RID: 752
		[MethodImpl(MethodImplOptions.InternalCall)]
		void DoRename();
	}
}
