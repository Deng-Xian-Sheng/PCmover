using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200005E RID: 94
	[CompilerGenerated]
	[Guid("7D2F4BA6-7949-4BD4-AB56-043AAA0525CA")]
	[TypeIdentifier]
	[ComImport]
	public interface IAppSelMatch
	{
		// Token: 0x060002CA RID: 714
		void _VtblGap1_1();

		// Token: 0x060002CB RID: 715
		[DispId(2)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool MatchSameVersionAppExists([MarshalAs(UnmanagedType.Interface)] [In] AppProfile pProfile);

		// Token: 0x060002CC RID: 716
		[DispId(3)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool CanModify([MarshalAs(UnmanagedType.Interface)] [In] AppProfile pProfile, [In] bool bUsePolicy);

		// Token: 0x060002CD RID: 717
		[DispId(4)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool IsSelected([MarshalAs(UnmanagedType.Interface)] [In] AppProfile pProfile);

		// Token: 0x060002CE RID: 718
		void _VtblGap2_1();

		// Token: 0x060002CF RID: 719
		[DispId(6)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void UserSelect([MarshalAs(UnmanagedType.Interface)] [In] AppProfile pProfile, bool bSelect);

		// Token: 0x060002D0 RID: 720
		void _VtblGap3_3();

		// Token: 0x060002D1 RID: 721
		[DispId(10)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetSelectionInfo([MarshalAs(UnmanagedType.Interface)] [In] AppProfile pProfile, out bool pbSelected, out SELECTED_REASON pReason, [MarshalAs(UnmanagedType.BStr)] out string pbstrReasonMsg, out bool pbDefault, out MIGRATION_SAFETY pSafety);

		// Token: 0x060002D2 RID: 722
		[DispId(11)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool SelectionChangesRuleSets([MarshalAs(UnmanagedType.Interface)] [In] AppProfile pProfile);
	}
}
