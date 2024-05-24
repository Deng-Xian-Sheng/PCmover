using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200006E RID: 110
	[CompilerGenerated]
	[Guid("A64007FE-E18D-41BA-B25E-B55900FC5908")]
	[TypeIdentifier]
	[ComImport]
	public interface IFillVanTask : IPcmTask
	{
		// Token: 0x0600032E RID: 814
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void dispose();

		// Token: 0x0600032F RID: 815
		void _VtblGap1_27();

		// Token: 0x06000330 RID: 816
		[DispId(29)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool BuildChangeLists();

		// Token: 0x06000331 RID: 817
		void _VtblGap2_1();

		// Token: 0x06000332 RID: 818
		[DispId(31)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void CreateTaskFiles([In] TASK_FILES TaskFiles);

		// Token: 0x06000333 RID: 819
		[DispId(32)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool IsTransferSuccessful();

		// Token: 0x06000334 RID: 820
		void _VtblGap3_7();

		// Token: 0x170000C4 RID: 196
		// (set) Token: 0x06000335 RID: 821
		[DispId(40)]
		string VanPassword { [DispId(40)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x06000336 RID: 822
		void _VtblGap4_8();

		// Token: 0x06000337 RID: 823
		[DispId(51)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool Configure();

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000338 RID: 824
		// (set) Token: 0x06000339 RID: 825
		[DispId(52)]
		MIGITEMS_OPTIONS MigItemsOptions { [DispId(52)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(52)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x0600033A RID: 826
		void _VtblGap5_1();

		// Token: 0x0600033B RID: 827
		[DispId(54)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool FillMovingVan([MarshalAs(UnmanagedType.Interface)] [In] TransferMethod pTransferMethod, [In] MACHINE_DETAIL detail);

		// Token: 0x0600033C RID: 828
		[DispId(55)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool Load([MarshalAs(UnmanagedType.Interface)] [In] TransferMethod pTransferMethod);

		// Token: 0x0600033D RID: 829
		[DispId(56)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool RecreateChangeLists();

		// Token: 0x0600033E RID: 830
		[DispId(57)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool RematchApps();

		// Token: 0x0600033F RID: 831
		[DispId(58)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool UpdateRules();

		// Token: 0x06000340 RID: 832
		void _VtblGap6_1();

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000341 RID: 833
		[DispId(60)]
		MiscSettingsGroups MiscSettings { [DispId(60)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x06000342 RID: 834
		[DispId(61)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool Save([MarshalAs(UnmanagedType.Interface)] [In] TransferMethod pTransferMethod, [In] MACHINE_DETAIL mdSrc, [In] MACHINE_DETAIL mdDst);

		// Token: 0x06000343 RID: 835
		[DispId(62)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool SaveBuildJournal();
	}
}
