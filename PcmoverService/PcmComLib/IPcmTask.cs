using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000082 RID: 130
	[CompilerGenerated]
	[Guid("B38A9590-04A4-45C2-8BC8-6A182BC5C46E")]
	[TypeIdentifier]
	[ComImport]
	public interface IPcmTask : IPCmoverObject
	{
		// Token: 0x0600040E RID: 1038
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void dispose();

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x0600040F RID: 1039
		[DispId(2)]
		ulong Id { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000410 RID: 1040
		void _VtblGap1_1();

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000411 RID: 1041
		[DispId(4)]
		AppSelMatch AppSelMatch { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000412 RID: 1042
		[DispId(5)]
		uint LstSig { [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000413 RID: 1043
		[DispId(6)]
		Machine srcMachine { [DispId(6)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000414 RID: 1044
		[DispId(7)]
		Machine destMachine { [DispId(7)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000415 RID: 1045
		[DispId(8)]
		double StartOADate { [DispId(8)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000416 RID: 1046
		[DispId(9)]
		double FinishOADate { [DispId(9)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000417 RID: 1047
		[DispId(10)]
		ENUM_TRANSFERMETHOD TransferMethod { [DispId(10)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000418 RID: 1048
		void _VtblGap2_3();

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000419 RID: 1049
		[DispId(14)]
		TaskItemRoot TaskItemRoot { [DispId(14)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x0600041A RID: 1050
		void _VtblGap3_1();

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x0600041B RID: 1051
		[DispId(16)]
		ENUM_TASK_TYPE taskType { [DispId(16)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x0600041C RID: 1052
		void _VtblGap4_2();

		// Token: 0x0600041D RID: 1053
		[DispId(19)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		uint nMigratedApps([In] bool bShowComponents);

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x0600041E RID: 1054
		[DispId(20)]
		UserMatchMgr UserMatchMgr { [DispId(20)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x0600041F RID: 1055
		void _VtblGap5_5();

		// Token: 0x06000420 RID: 1056
		[DispId(26)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool IsDiskNodeFiltered([MarshalAs(UnmanagedType.Interface)] [In] TreeNode pTreeNode);

		// Token: 0x06000421 RID: 1057
		[DispId(27)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool SetDirectoryFilter([MarshalAs(UnmanagedType.BStr)] [In] string strPath, [In] bool bSelected);

		// Token: 0x06000422 RID: 1058
		[DispId(28)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFileFilter([MarshalAs(UnmanagedType.BStr)] [In] string bstrParentPath, [MarshalAs(UnmanagedType.BStr)] [In] string bstrName, [In] bool bChangeSelected, [In] bool bSelected, [MarshalAs(UnmanagedType.BStr)] [In] string bstrTarget);

		// Token: 0x06000423 RID: 1059
		void _VtblGap6_1();

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000424 RID: 1060
		[DispId(30)]
		DriveMatch DriveMatch { [DispId(30)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x06000425 RID: 1061
		void _VtblGap7_2();

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000426 RID: 1062
		[DispId(33)]
		CHANGE_PROCESS_ERROR TransferResult { [DispId(33)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000427 RID: 1063
		[DispId(34)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool UploadXmlReport();

		// Token: 0x06000428 RID: 1064
		[DispId(35)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetIsIgnoredAndTarget([MarshalAs(UnmanagedType.Interface)] [In] TreeNode pTreeNode, out bool pbIgnored, [MarshalAs(UnmanagedType.BStr)] out string pbstrTarget);

		// Token: 0x06000429 RID: 1065
		[DispId(36)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool SetDirectoryTarget([MarshalAs(UnmanagedType.BStr)] [In] string bstrPath, [MarshalAs(UnmanagedType.BStr)] [In] string bstrTarget, [In] bool bAllAppsOnly);

		// Token: 0x0600042A RID: 1066
		[DispId(37)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void InvalidateChangeNode([MarshalAs(UnmanagedType.BStr)] [In] string bstrPath, [In] ENUM_TTID ttid);

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600042B RID: 1067
		[DispId(38)]
		LeafFilters FileFilters { [DispId(38)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x0600042C RID: 1068
		[DispId(39)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool GenerateReport([MarshalAs(UnmanagedType.Interface)] [In] ReportPolicy pReport);

		// Token: 0x1700012C RID: 300
		// (set) Token: 0x0600042D RID: 1069
		[DispId(40)]
		string VanPassword { [DispId(40)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x0600042E RID: 1070
		[DispId(41)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetVersionVariables(out ushort wMajor, out ushort wMinor, out ushort wBuild, out ushort wRev);

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x0600042F RID: 1071
		[DispId(42)]
		bool IsAuthorized { [DispId(42)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000430 RID: 1072
		[DispId(43)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		uint AuthorizeTransfer([MarshalAs(UnmanagedType.BStr)] [In] string Key, [MarshalAs(UnmanagedType.BStr)] [In] string UserName, [MarshalAs(UnmanagedType.BStr)] [In] string Email, [MarshalAs(UnmanagedType.BStr)] out string Msg, out uint pErrorCode);

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000431 RID: 1073
		[DispId(44)]
		bool IsReady { [DispId(44)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000432 RID: 1074
		void _VtblGap8_1();

		// Token: 0x06000433 RID: 1075
		[DispId(46)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool SaveDlMgrCmd([In] bool reboot, [MarshalAs(UnmanagedType.BStr)] out string pstrExe, [MarshalAs(UnmanagedType.BStr)] out string pstrParams);

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000434 RID: 1076
		[DispId(47)]
		bool IsPreValidated { [DispId(47)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000435 RID: 1077
		[DispId(48)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		uint AuthorizePreValidation([MarshalAs(UnmanagedType.BStr)] [In] string UserName, [MarshalAs(UnmanagedType.BStr)] [In] string Email, [MarshalAs(UnmanagedType.BStr)] out string Msg, out uint pErrorCode);
	}
}
