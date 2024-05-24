using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000177 RID: 375
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("a0ffbc28-5482-4366-be27-3e81e78e06c2")]
	[ComImport]
	internal interface ISearchFolderItemFactory
	{
		// Token: 0x06000EAC RID: 3756
		[PreserveSig]
		HResult SetDisplayName([MarshalAs(UnmanagedType.LPWStr)] [In] string pszDisplayName);

		// Token: 0x06000EAD RID: 3757
		[PreserveSig]
		HResult SetFolderTypeID([In] Guid ftid);

		// Token: 0x06000EAE RID: 3758
		[PreserveSig]
		HResult SetFolderLogicalViewMode([In] FolderLogicalViewMode flvm);

		// Token: 0x06000EAF RID: 3759
		[PreserveSig]
		HResult SetIconSize([In] int iIconSize);

		// Token: 0x06000EB0 RID: 3760
		[PreserveSig]
		HResult SetVisibleColumns([In] uint cVisibleColumns, [MarshalAs(UnmanagedType.LPArray)] [In] PropertyKey[] rgKey);

		// Token: 0x06000EB1 RID: 3761
		[PreserveSig]
		HResult SetSortColumns([In] uint cSortColumns, [MarshalAs(UnmanagedType.LPArray)] [In] SortColumn[] rgSortColumns);

		// Token: 0x06000EB2 RID: 3762
		[PreserveSig]
		HResult SetGroupColumn([In] ref PropertyKey keyGroup);

		// Token: 0x06000EB3 RID: 3763
		[PreserveSig]
		HResult SetStacks([In] uint cStackKeys, [MarshalAs(UnmanagedType.LPArray)] [In] PropertyKey[] rgStackKeys);

		// Token: 0x06000EB4 RID: 3764
		[PreserveSig]
		HResult SetScope([MarshalAs(UnmanagedType.Interface)] [In] IShellItemArray ppv);

		// Token: 0x06000EB5 RID: 3765
		[PreserveSig]
		HResult SetCondition([In] ICondition pCondition);

		// Token: 0x06000EB6 RID: 3766
		[PreserveSig]
		int GetShellItem(ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IShellItem ppv);

		// Token: 0x06000EB7 RID: 3767
		[PreserveSig]
		HResult GetIDList([Out] IntPtr ppidl);
	}
}
