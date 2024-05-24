using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000089 RID: 137
	[CompilerGenerated]
	[Guid("58250590-53B6-4F95-BF32-189461927ED0")]
	[TypeIdentifier]
	[ComImport]
	public interface IRegistrationServer
	{
		// Token: 0x06000465 RID: 1125
		void _VtblGap1_1();

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000466 RID: 1126
		// (set) Token: 0x06000467 RID: 1127
		[DispId(4)]
		string SerialNumber { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x06000468 RID: 1128
		void _VtblGap2_1();

		// Token: 0x06000469 RID: 1129
		[DispId(6)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		AppUpdateInfo CheckForUpdate();

		// Token: 0x0600046A RID: 1130
		void _VtblGap3_1();

		// Token: 0x0600046B RID: 1131
		[DispId(8)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool EmailAlert([MarshalAs(UnmanagedType.BStr)] [In] string state, [MarshalAs(UnmanagedType.BStr)] [In] string User, [MarshalAs(UnmanagedType.BStr)] [In] string Email, [MarshalAs(UnmanagedType.BStr)] [In] string Status, [MarshalAs(UnmanagedType.BStr)] [In] string CustomMsg);

		// Token: 0x0600046C RID: 1132
		void _VtblGap4_2();

		// Token: 0x0600046D RID: 1133
		[DispId(11)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool GetSerialNumberInfo([MarshalAs(UnmanagedType.BStr)] [In] string Key, out bool pbValid, [MarshalAs(UnmanagedType.BStr)] out string pNormalizedKey, out int pnumLicenses, out int pnumUsed, out int pType, out int pMatchedType, [MarshalAs(UnmanagedType.BStr)] out string pEndDate, out bool pbExpired);

		// Token: 0x0600046E RID: 1134
		void _VtblGap5_1();

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x0600046F RID: 1135
		// (set) Token: 0x06000470 RID: 1136
		[DispId(13)]
		string ValidationCode { [DispId(13)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(13)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000471 RID: 1137
		// (set) Token: 0x06000472 RID: 1138
		[DispId(14)]
		string MachineName { [DispId(14)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(14)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000473 RID: 1139
		// (set) Token: 0x06000474 RID: 1140
		[DispId(15)]
		string UserName { [DispId(15)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(15)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000475 RID: 1141
		// (set) Token: 0x06000476 RID: 1142
		[DispId(16)]
		string UserEmail { [DispId(16)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(16)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000477 RID: 1143
		[DispId(17)]
		uint LastHttpStatus { [DispId(17)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000478 RID: 1144
		[DispId(18)]
		string ProxyUrl { [DispId(18)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000479 RID: 1145
		// (set) Token: 0x0600047A RID: 1146
		[DispId(19)]
		string OldMachineName { [DispId(19)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(19)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }
	}
}
