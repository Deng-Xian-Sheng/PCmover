using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200007C RID: 124
	[CompilerGenerated]
	[Guid("B36B7A36-7BEC-40D6-A8F6-D7C9C942E6CE")]
	[TypeIdentifier]
	[ComImport]
	public interface INetworkTransferMethod : IConnectionMethod
	{
		// Token: 0x060003B1 RID: 945
		void _VtblGap1_13();

		// Token: 0x060003B2 RID: 946
		[DispId(14)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetUserData([In] ref byte UserData, [In] int userDataLen);

		// Token: 0x060003B3 RID: 947
		void _VtblGap2_1();

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060003B4 RID: 948
		// (set) Token: 0x060003B5 RID: 949
		[DispId(16)]
		bool bOutgoing { [DispId(16)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(16)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x060003B6 RID: 950
		[DispId(21)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool StartDiscovery([MarshalAs(UnmanagedType.Interface)] [In] DiscoveryCallbacks pCallback, uint nTimeout, uint nResendTime);

		// Token: 0x060003B7 RID: 951
		[DispId(22)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void EndDiscovery();

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060003B8 RID: 952
		// (set) Token: 0x060003B9 RID: 953
		[DispId(23)]
		string RemoteMachine { [DispId(23)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(23)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x060003BA RID: 954
		void _VtblGap3_9();

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060003BB RID: 955
		// (set) Token: 0x060003BC RID: 956
		[DispId(29)]
		bool bSecure { [DispId(29)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(29)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x060003BD RID: 957
		void _VtblGap4_4();

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060003BE RID: 958
		[DispId(32)]
		bool bValidCertificate { [DispId(32)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060003BF RID: 959
		[DispId(33)]
		byte[] PeerCertificate { [DispId(33)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] get; }

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060003C0 RID: 960
		[DispId(34)]
		byte[] LocalCertificate { [DispId(34)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] get; }

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060003C1 RID: 961
		[DispId(35)]
		SSL_STATE SSLState { [DispId(35)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700010A RID: 266
		// (set) Token: 0x060003C2 RID: 962
		[DispId(36)]
		string RemoteCertificateName { [DispId(36)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x060003C3 RID: 963
		[DispId(37)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void UpdateRemoteMachineName([MarshalAs(UnmanagedType.BStr)] [In] string remoteNAME);

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060003C4 RID: 964
		[DispId(38)]
		bool bSSLClient { [DispId(38)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
