using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CertificateServer
{
	// Token: 0x02000037 RID: 55
	[CompilerGenerated]
	[Guid("CA8A8103-3F0C-4DDA-8651-7C79636973D3")]
	[TypeIdentifier]
	[ComImport]
	public interface ICertificateService
	{
		// Token: 0x06000283 RID: 643
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Dispose();

		// Token: 0x06000284 RID: 644
		void _VtblGap1_7();

		// Token: 0x06000285 RID: 645
		[DispId(10)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		uint RequestCertificate([MarshalAs(UnmanagedType.BStr)] [In] string email, [MarshalAs(UnmanagedType.BStr)] [In] string productSN, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] out byte[] pCertificate);

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000286 RID: 646
		// (set) Token: 0x06000287 RID: 647
		[DispId(11)]
		string Application { [DispId(11)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(11)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x06000288 RID: 648
		void _VtblGap2_2();

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000289 RID: 649
		// (set) Token: 0x0600028A RID: 650
		[DispId(14)]
		bool Logging { [DispId(14)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(14)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600028B RID: 651
		// (set) Token: 0x0600028C RID: 652
		[DispId(15)]
		string CAServer { [DispId(15)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(15)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x0600028D RID: 653
		// (set) Token: 0x0600028E RID: 654
		[DispId(16)]
		string CASignPath { [DispId(16)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(16)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600028F RID: 655
		// (set) Token: 0x06000290 RID: 656
		[DispId(17)]
		string ProxyUser { [DispId(17)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(17)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000291 RID: 657
		// (set) Token: 0x06000292 RID: 658
		[DispId(18)]
		string ProxyPassword { [DispId(18)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(18)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000293 RID: 659
		// (set) Token: 0x06000294 RID: 660
		[DispId(19)]
		string ProxyUrl { [DispId(19)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(19)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x06000295 RID: 661
		void _VtblGap3_3();

		// Token: 0x06000296 RID: 662
		[DispId(22)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool DownloadCACertificate();

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000297 RID: 663
		[DispId(23)]
		byte[] Certificate { [DispId(23)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] get; }
	}
}
