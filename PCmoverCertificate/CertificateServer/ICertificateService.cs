using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CertificateServer
{
	// Token: 0x02000009 RID: 9
	[CompilerGenerated]
	[Guid("CA8A8103-3F0C-4DDA-8651-7C79636973D3")]
	[TypeIdentifier]
	[ComImport]
	public interface ICertificateService
	{
		// Token: 0x06000017 RID: 23
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Dispose();

		// Token: 0x06000018 RID: 24
		[DispId(2)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool TestSSL([MarshalAs(UnmanagedType.BStr)] [In] string clientCertificateSent, [MarshalAs(UnmanagedType.BStr)] [In] string clientCertificateRequired, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] out byte[] pCertificate);

		// Token: 0x06000019 RID: 25
		void _VtblGap1_1();

		// Token: 0x0600001A RID: 26
		[DispId(5)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		CertificateContext ContextFromFile([MarshalAs(UnmanagedType.BStr)] [In] string path);

		// Token: 0x0600001B RID: 27
		void _VtblGap2_4();

		// Token: 0x0600001C RID: 28
		[DispId(10)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		uint RequestCertificate([MarshalAs(UnmanagedType.BStr)] [In] string email, [MarshalAs(UnmanagedType.BStr)] [In] string productSN, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] out byte[] pCertificate);

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600001D RID: 29
		// (set) Token: 0x0600001E RID: 30
		[DispId(11)]
		string Application { [DispId(11)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(11)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001F RID: 31
		[DispId(12)]
		string CANames { [DispId(12)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000020 RID: 32
		[DispId(13)]
		string RootCAName { [DispId(13)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000021 RID: 33
		// (set) Token: 0x06000022 RID: 34
		[DispId(14)]
		bool Logging { [DispId(14)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(14)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000023 RID: 35
		// (set) Token: 0x06000024 RID: 36
		[DispId(15)]
		string CAServer { [DispId(15)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(15)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000025 RID: 37
		// (set) Token: 0x06000026 RID: 38
		[DispId(16)]
		string CASignPath { [DispId(16)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(16)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000027 RID: 39
		// (set) Token: 0x06000028 RID: 40
		[DispId(17)]
		string ProxyUser { [DispId(17)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(17)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000029 RID: 41
		// (set) Token: 0x0600002A RID: 42
		[DispId(18)]
		string ProxyPassword { [DispId(18)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(18)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600002B RID: 43
		// (set) Token: 0x0600002C RID: 44
		[DispId(19)]
		string ProxyUrl { [DispId(19)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(19)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600002D RID: 45
		// (set) Token: 0x0600002E RID: 46
		[DispId(20)]
		ushort HttpsPort { [DispId(20)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(20)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x0600002F RID: 47
		[DispId(21)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Uninstall();

		// Token: 0x06000030 RID: 48
		[DispId(22)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool DownloadCACertificate();

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000031 RID: 49
		[DispId(23)]
		byte[] Certificate { [DispId(23)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] get; }

		// Token: 0x06000032 RID: 50
		[DispId(24)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void CreateSelfSignedCertificate([MarshalAs(UnmanagedType.BStr)] [In] string email, [MarshalAs(UnmanagedType.BStr)] [In] string productSN, [MarshalAs(UnmanagedType.BStr)] [In] string Issuer);

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000033 RID: 51
		[DispId(25)]
		string CertificateNameFromRegistry { [DispId(25)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x1700000E RID: 14
		// (set) Token: 0x06000034 RID: 52
		[DispId(26)]
		byte[] CustomerCA { [DispId(26)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] [param: In] set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000035 RID: 53
		// (set) Token: 0x06000036 RID: 54
		[DispId(27)]
		SSL_FLAGS SSLFlags { [DispId(27)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(27)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000037 RID: 55
		[DispId(28)]
		string DefaultCertificateName { [DispId(28)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x06000038 RID: 56
		[DispId(29)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool VerifyEx([MarshalAs(UnmanagedType.Interface)] [In] CertificateContext pContext, out bool LaplinkCA);
	}
}
