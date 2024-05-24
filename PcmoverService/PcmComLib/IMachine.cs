using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000072 RID: 114
	[CompilerGenerated]
	[Guid("3646F88A-B22B-4646-BF20-1859CE1341D5")]
	[TypeIdentifier]
	[ComImport]
	public interface IMachine : IPCmoverObject
	{
		// Token: 0x06000356 RID: 854
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void dispose();

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000357 RID: 855
		[DispId(2)]
		ulong Id { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000358 RID: 856
		[DispId(3)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool DoApplicationInventory([In] ENUM_APPSEL_STAGE Stage);

		// Token: 0x06000359 RID: 857
		[DispId(4)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool SaveSnapshot([MarshalAs(UnmanagedType.Interface)] [In] TransferMethod pTransferMethod, [In] EXPAND_CONDITIONS expandSnapshot);

		// Token: 0x0600035A RID: 858
		[DispId(5)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool InitImageMachine([MarshalAs(UnmanagedType.Interface)] [In] VirtualPhysicalMapping pMapping, [MarshalAs(UnmanagedType.BStr)] [In] string strSystemRoot, [MarshalAs(UnmanagedType.BStr)] [In] string strImageName);

		// Token: 0x0600035B RID: 859
		[DispId(6)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool InitNoSnapshotMachine([MarshalAs(UnmanagedType.BStr)] [In] string strMachineName);

		// Token: 0x0600035C RID: 860
		[DispId(7)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool Load([MarshalAs(UnmanagedType.Interface)] [In] TransferMethod pTransferMethod);

		// Token: 0x0600035D RID: 861
		[DispId(8)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool Save([MarshalAs(UnmanagedType.Interface)] [In] TransferMethod pTransferMethod);

		// Token: 0x0600035E RID: 862
		void _VtblGap1_1();

		// Token: 0x0600035F RID: 863
		[DispId(10)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetOsVersionVariables(out int major, out int minor, out int build, out int platformId, out int productType, out int svcPackMajor, out int svcPackMinor, out uint enablePreviewBuilds, out bool Is64Bit, [MarshalAs(UnmanagedType.BStr)] out string versionText);

		// Token: 0x06000360 RID: 864
		[DispId(11)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void DetermineApplicationDiskSpace(bool regularUsersOnly);

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000361 RID: 865
		[DispId(102)]
		string NetName { [DispId(102)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000362 RID: 866
		// (set) Token: 0x06000363 RID: 867
		[DispId(103)]
		string FriendlyName { [DispId(103)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(103)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000364 RID: 868
		[DispId(104)]
		string MachineId { [DispId(104)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000365 RID: 869
		[DispId(105)]
		string Manufacturer { [DispId(105)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000366 RID: 870
		[DispId(106)]
		string WindowsVersionText { [DispId(106)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000367 RID: 871
		[DispId(107)]
		TreeRoots TreeRoots { [DispId(107)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000368 RID: 872
		[DispId(108)]
		AppInventory AppInventory { [DispId(108)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000369 RID: 873
		[DispId(109)]
		uint OemId { [DispId(109)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x0600036A RID: 874
		void _VtblGap2_1();

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x0600036B RID: 875
		[DispId(111)]
		bool EngineRunningAsAdmin { [DispId(111)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x0600036C RID: 876
		[DispId(112)]
		APPINVENTORY_STATE AppInvState { [DispId(112)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x0600036D RID: 877
		[DispId(114)]
		NetUserMgr NetUserMgr { [DispId(114)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x0600036E RID: 878
		void _VtblGap3_5();

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x0600036F RID: 879
		[DispId(120)]
		TREE_STATUS TreeStatus { [DispId(120)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000370 RID: 880
		[DispId(121)]
		DriveSizeMap DriveSizeMap { [DispId(121)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000371 RID: 881
		[DispId(122)]
		bool HasValidSerialNumber { [DispId(122)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000372 RID: 882
		[DispId(123)]
		string JoinedDomain { [DispId(123)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000373 RID: 883
		[DispId(124)]
		uint ValidationId { [DispId(124)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000374 RID: 884
		[DispId(125)]
		bool IsThisMachine { [DispId(125)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000375 RID: 885
		[DispId(126)]
		bool IsJoinedToAzureAd { [DispId(126)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000376 RID: 886
		[DispId(127)]
		uint WindowsEdition { [DispId(127)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000377 RID: 887
		[DispId(128)]
		string HardDrives { [DispId(128)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000378 RID: 888
		[DispId(129)]
		string UsbDrives { [DispId(129)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000379 RID: 889
		[DispId(130)]
		string VirtualDrives { [DispId(130)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x0600037A RID: 890
		[DispId(131)]
		bool IsLive { [DispId(131)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x0600037B RID: 891
		[DispId(132)]
		ENUM_APPSEL_STAGE CompletedAppSelStage { [DispId(132)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
