using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000062 RID: 98
	[CompilerGenerated]
	[Guid("48027ABB-CAAC-46D0-BB47-30021C17F669")]
	[TypeIdentifier]
	[ComImport]
	public interface IConnectionMethod : ITransferMethod
	{
		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060002E0 RID: 736
		[DispId(3)]
		ENUM_TRANSFERMETHOD TransferMethod { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x060002E1 RID: 737
		void _VtblGap1_3();

		// Token: 0x060002E2 RID: 738
		[DispId(6)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool CloseConnection();

		// Token: 0x060002E3 RID: 739
		void _VtblGap2_1();

		// Token: 0x060002E4 RID: 740
		[DispId(8)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool IsOpen();

		// Token: 0x060002E5 RID: 741
		[DispId(9)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Cancel();

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060002E6 RID: 742
		[DispId(10)]
		ulong TransmitLinkSpeed { [DispId(10)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060002E7 RID: 743
		[DispId(11)]
		ulong ReceiveLinkSpeed { [DispId(11)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x060002E8 RID: 744
		[DispId(12)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		PcmProtocol GetPcmProtocol();

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060002E9 RID: 745
		// (set) Token: 0x060002EA RID: 746
		[DispId(13)]
		bool PasswordRequired { [DispId(13)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(13)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x060002EB RID: 747
		void _VtblGap3_1();

		// Token: 0x060002EC RID: 748
		[DispId(15)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool MakeConnection();

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060002ED RID: 749
		// (set) Token: 0x060002EE RID: 750
		[DispId(16)]
		bool bOutgoing { [DispId(16)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(16)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }
	}
}
