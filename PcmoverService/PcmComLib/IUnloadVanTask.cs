using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000099 RID: 153
	[CompilerGenerated]
	[Guid("99EEB3F6-6FCA-4F03-9F3F-B3A5A4E880CF")]
	[TypeIdentifier]
	[ComImport]
	public interface IUnloadVanTask : IPcmTask
	{
		// Token: 0x060004D2 RID: 1234
		void _VtblGap1_5();

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x060004D3 RID: 1235
		[DispId(6)]
		Machine srcMachine { [DispId(6)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060004D4 RID: 1236
		[DispId(7)]
		Machine destMachine { [DispId(7)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060004D5 RID: 1237
		void _VtblGap2_23();

		// Token: 0x060004D6 RID: 1238
		[DispId(31)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void CreateTaskFiles([In] TASK_FILES TaskFiles);

		// Token: 0x060004D7 RID: 1239
		void _VtblGap3_1();

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x060004D8 RID: 1240
		[DispId(33)]
		CHANGE_PROCESS_ERROR TransferResult { [DispId(33)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x060004D9 RID: 1241
		void _VtblGap4_15();

		// Token: 0x060004DA RID: 1242
		[DispId(50)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool LoadMovingVanHeader([MarshalAs(UnmanagedType.Interface)] [In] TransferMethod TransferMethod);

		// Token: 0x060004DB RID: 1243
		void _VtblGap5_10();

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x060004DC RID: 1244
		[DispId(65)]
		uint nUsersWithoutPasswords { [DispId(65)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x060004DD RID: 1245
		[DispId(66)]
		NetUser UsersWithoutPasswords { [DispId(66)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060004DE RID: 1246
		void _VtblGap6_1();

		// Token: 0x060004DF RID: 1247
		[DispId(69)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool ProcessMovingVanHeader([MarshalAs(UnmanagedType.Interface)] [In] PcmUICallbacks pCallbacks);

		// Token: 0x060004E0 RID: 1248
		[DispId(70)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool FinishMovingVanUnload();

		// Token: 0x060004E1 RID: 1249
		[DispId(71)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool FinishUndo();

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x060004E2 RID: 1250
		// (set) Token: 0x060004E3 RID: 1251
		[DispId(73)]
		bool bUsePolicy { [DispId(73)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(73)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x060004E4 RID: 1252
		[DispId(74)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool LoadUndoHeader();

		// Token: 0x060004E5 RID: 1253
		[DispId(75)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetSrcMachine([MarshalAs(UnmanagedType.Interface)] [In] Machine pSrcMachine);

		// Token: 0x060004E6 RID: 1254
		[DispId(76)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool PrepareLiveToLive([MarshalAs(UnmanagedType.Interface)] [In] FillVanTask pFillVanTask);

		// Token: 0x060004E7 RID: 1255
		[DispId(77)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool ProcessLiveToLivePrep([MarshalAs(UnmanagedType.Interface)] [In] PcmUICallbacks pCallbacks);

		// Token: 0x060004E8 RID: 1256
		[DispId(78)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool FinishLiveToLiveUnload();

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x060004E9 RID: 1257
		[DispId(80)]
		PcmStringList RedistPackages { [DispId(80)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060004EA RID: 1258
		[DispId(82)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void LaunchApplicationAutoRun([In] bool currentOnly);

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x060004EB RID: 1259
		// (set) Token: 0x060004EC RID: 1260
		[DispId(83)]
		bool ShouldCreateUndoFile { [DispId(83)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(83)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }
	}
}
