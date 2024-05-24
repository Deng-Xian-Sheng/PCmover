using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000098 RID: 152
	[CompilerGenerated]
	[Guid("6D275634-74CF-47AA-85E3-814C80F6A5F6")]
	[TypeIdentifier]
	[ComImport]
	public interface IUSBTransferMethod : IConnectionMethod
	{
		// Token: 0x060004C8 RID: 1224
		void _VtblGap1_13();

		// Token: 0x060004C9 RID: 1225
		[DispId(14)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetUserData([In] ref byte UserData, [In] int userDataLen);

		// Token: 0x060004CA RID: 1226
		void _VtblGap2_6();

		// Token: 0x060004CB RID: 1227
		[DispId(24)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool StartDiscovery([MarshalAs(UnmanagedType.Interface)] [In] DiscoveryCallbacks pCallback);

		// Token: 0x060004CC RID: 1228
		[DispId(25)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void EndDiscovery();

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060004CD RID: 1229
		[DispId(32)]
		bool bValidCertificate { [DispId(32)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060004CE RID: 1230
		[DispId(33)]
		byte[] PeerCertificate { [DispId(33)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] get; }

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060004CF RID: 1231
		[DispId(34)]
		byte[] LocalCertificate { [DispId(34)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] get; }

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x060004D0 RID: 1232
		[DispId(35)]
		SSL_STATE SSLState { [DispId(35)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060004D1 RID: 1233
		[DispId(38)]
		bool bSSLClient { [DispId(38)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
