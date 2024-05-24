using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200007D RID: 125
	[CompilerGenerated]
	[Guid("1984FA7D-D9EC-483F-A45C-BC2EF78C26AC")]
	[TypeIdentifier]
	[ComImport]
	public interface IPCmoverApp : IPCmoverObject
	{
		// Token: 0x060003C5 RID: 965
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void dispose();

		// Token: 0x060003C6 RID: 966
		void _VtblGap1_1();

		// Token: 0x060003C7 RID: 967
		[DispId(3)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Init([MarshalAs(UnmanagedType.BStr)] [In] string pEnvironment, [MarshalAs(UnmanagedType.BStr)] [In] string pPolicyId, [MarshalAs(UnmanagedType.BStr)] [In] string pPolicyFile, [In] bool bDeferred, [In] bool bRules, [MarshalAs(UnmanagedType.BStr)] [In] string strCurrentUserSid, [MarshalAs(UnmanagedType.BStr)] [In] string strCurrentUserDomain, [MarshalAs(UnmanagedType.BStr)] [In] string strCurrentUserName);

		// Token: 0x060003C8 RID: 968
		[DispId(6)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		TransferMethod CreateTransferMethod([In] ENUM_TRANSFERMETHOD method);

		// Token: 0x060003C9 RID: 969
		[DispId(7)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		FillVanTask CreateFillVanTask();

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060003CA RID: 970
		[DispId(1610809347)]
		Machine ThisMachine { [DispId(1610809347)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060003CB RID: 971
		void _VtblGap2_13();

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060003CC RID: 972
		[DispId(13)]
		MigrationStatus CurMigrationStatus { [DispId(13)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060003CD RID: 973
		void _VtblGap3_2();

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060003CE RID: 974
		[DispId(17)]
		Policy Policy { [DispId(17)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060003CF RID: 975
		[DispId(25)]
		string strWindowsOldDir { [DispId(25)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x060003D0 RID: 976
		[DispId(29)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetVersionVariables(out ushort wMajor, out ushort wMinor, out ushort wBuild, out ushort wRev);

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060003D1 RID: 977
		[DispId(31)]
		double UndoOADate { [DispId(31)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x060003D2 RID: 978
		[DispId(33)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		PcmTask LoadMovingJournal([MarshalAs(UnmanagedType.Interface)] [In] TransferMethod pTransferMethod);

		// Token: 0x060003D3 RID: 979
		void _VtblGap4_6();

		// Token: 0x060003D4 RID: 980
		[DispId(37)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		FillVanTask CreateClientFillVanTask([MarshalAs(UnmanagedType.Interface)] [In] Machine pOldMachine, [MarshalAs(UnmanagedType.Interface)] [In] Machine pNewMachine, [In] ENUM_TRANSFERMETHOD etm, [MarshalAs(UnmanagedType.BStr)] [In] string selectionRoots);

		// Token: 0x060003D5 RID: 981
		[DispId(38)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ProgressBase CreateProgressBase();

		// Token: 0x060003D6 RID: 982
		[DispId(39)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		UnloadVanTask CreateUnloadVanTask();

		// Token: 0x060003D7 RID: 983
		void _VtblGap5_2();

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060003D8 RID: 984
		[DispId(42)]
		RegistrationServer RegistrationServer { [DispId(42)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060003D9 RID: 985
		[DispId(43)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool ProcessDataUpdates([MarshalAs(UnmanagedType.Interface)] [In] AppUpdateInfo Update, [MarshalAs(UnmanagedType.BStr)] out string ErrorMessage);

		// Token: 0x060003DA RID: 986
		[DispId(44)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		Machine CreateMachine();

		// Token: 0x060003DB RID: 987
		[DispId(45)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		VirtualPhysicalMapping CreateVirtualPhysicalMapping();

		// Token: 0x060003DC RID: 988
		[DispId(46)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		VirtualPhysicalMapping CreateWinUpgradeVirtualPhysicalMapping([MarshalAs(UnmanagedType.BStr)] [In] string WindowsOld);

		// Token: 0x060003DD RID: 989
		[DispId(47)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetAppCallbacks([MarshalAs(UnmanagedType.Interface)] [In] AppCallbacks pCallbacks);

		// Token: 0x060003DE RID: 990
		[DispId(48)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void reboot();

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060003DF RID: 991
		[DispId(49)]
		string AntivirusProduct { [DispId(49)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060003E0 RID: 992
		[DispId(50)]
		string FirewallProduct { [DispId(50)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x060003E1 RID: 993
		[DispId(51)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetNetworkStats(out NetworkStats Stats);

		// Token: 0x060003E2 RID: 994
		[DispId(52)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ReportPolicy CreateReportPolicy();

		// Token: 0x060003E3 RID: 995
		[DispId(53)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetProductIdCulture([MarshalAs(UnmanagedType.BStr)] [In] string language, [MarshalAs(UnmanagedType.BStr)] [In] string country);

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060003E4 RID: 996
		[DispId(54)]
		string CertificateName { [DispId(54)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x060003E5 RID: 997
		void _VtblGap6_1();

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060003E6 RID: 998
		[DispId(56)]
		EnginePolicy EnginePolicy { [DispId(56)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060003E7 RID: 999
		[DispId(57)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void RefreshNetworkAdapters();

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060003E8 RID: 1000
		[DispId(58)]
		uint ValidNetworkAdapterCount { [DispId(58)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x060003E9 RID: 1001
		[DispId(59)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetProxyAuth([MarshalAs(UnmanagedType.BStr)] [In] string UserName, [MarshalAs(UnmanagedType.BStr)] [In] string password);

		// Token: 0x17000117 RID: 279
		// (set) Token: 0x060003EA RID: 1002
		[DispId(61)]
		byte[] PolicyFileBuffer { [DispId(61)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] [param: In] set; }

		// Token: 0x060003EB RID: 1003
		[DispId(62)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void LaunchStartupAutoRun();
	}
}
