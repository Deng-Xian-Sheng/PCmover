using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000080 RID: 128
	[CompilerGenerated]
	[Guid("DAB8AFD2-CF1C-49FE-9EA4-F12428348EED")]
	[TypeIdentifier]
	[ComImport]
	public interface IPcmProtocol
	{
		// Token: 0x060003F1 RID: 1009
		[DispId(3)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool SendCommandPacket([MarshalAs(UnmanagedType.Interface)] [In] CommandPacket Command);

		// Token: 0x060003F2 RID: 1010
		[DispId(4)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool SendAck();

		// Token: 0x060003F3 RID: 1011
		[DispId(5)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool GetAck();

		// Token: 0x060003F4 RID: 1012
		[DispId(6)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		CommandPacket ReceiveCommand();

		// Token: 0x060003F5 RID: 1013
		[DispId(7)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void detach();

		// Token: 0x060003F6 RID: 1014
		[DispId(8)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		CommandPacket CreateCommandPacket([In] CommandType Type);

		// Token: 0x060003F7 RID: 1015
		[DispId(9)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		ENUM_INFOVALIDATION ExchangeInfoPackets();

		// Token: 0x060003F8 RID: 1016
		[DispId(10)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		ENUM_INFOVALIDATION HandleGetInfoPacket([MarshalAs(UnmanagedType.Interface)] [In] CommandPacket pCommandPacket);

		// Token: 0x060003F9 RID: 1017
		[DispId(14)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void HandleEndCommand();

		// Token: 0x060003FA RID: 1018
		[DispId(15)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void InvalidCommand([MarshalAs(UnmanagedType.Interface)] [In] CommandPacket pCommandPacket);

		// Token: 0x060003FB RID: 1019
		void _VtblGap1_1();

		// Token: 0x060003FC RID: 1020
		[DispId(18)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool SendNack();

		// Token: 0x060003FD RID: 1021
		void _VtblGap2_2();

		// Token: 0x060003FE RID: 1022
		[DispId(24)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Cleanup();

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060003FF RID: 1023
		// (set) Token: 0x06000400 RID: 1024
		[DispId(26)]
		bool IsNewComputer { [DispId(26)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(26)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000401 RID: 1025
		// (set) Token: 0x06000402 RID: 1026
		[DispId(28)]
		bool bCancel { [DispId(28)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(28)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x06000403 RID: 1027
		[DispId(29)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool SendFillCommand();

		// Token: 0x06000404 RID: 1028
		[DispId(31)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool HandleSendPasswordCommand([MarshalAs(UnmanagedType.Interface)] [In] CommandPacket pCommandPacket, [MarshalAs(UnmanagedType.BStr)] [In] string password);

		// Token: 0x06000405 RID: 1029
		[DispId(32)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool SendPassword([MarshalAs(UnmanagedType.BStr)] [In] string password);

		// Token: 0x06000406 RID: 1030
		[DispId(33)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool DoTest();

		// Token: 0x06000407 RID: 1031
		void _VtblGap3_1();

		// Token: 0x06000408 RID: 1032
		[DispId(35)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool SendCommandWithData([In] CommandType Type, [In] ref byte data, [In] uint dataLen);

		// Token: 0x06000409 RID: 1033
		[DispId(36)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		uint SendAuthorizeTransferCommand([MarshalAs(UnmanagedType.Interface)] [In] PcmTask task, [MarshalAs(UnmanagedType.BStr)] [In] string Key, [MarshalAs(UnmanagedType.BStr)] [In] string UserName, [MarshalAs(UnmanagedType.BStr)] [In] string Email, [MarshalAs(UnmanagedType.BStr)] out string Msg, out uint pErrorCode);

		// Token: 0x0600040A RID: 1034
		[DispId(37)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool HandleAuthorizeTransferPacket([MarshalAs(UnmanagedType.Interface)] [In] CommandPacket pCommandPacket);

		// Token: 0x0600040B RID: 1035
		[DispId(38)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetNetSpeeds(out ulong remoteSpeed, out ulong localSpeed);
	}
}
