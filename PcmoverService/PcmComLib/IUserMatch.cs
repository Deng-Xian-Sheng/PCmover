using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200009B RID: 155
	[CompilerGenerated]
	[Guid("4161C4F0-1D6C-4868-83EC-3B678242F7AA")]
	[TypeIdentifier]
	[ComImport]
	public interface IUserMatch
	{
		// Token: 0x060004EE RID: 1262
		void _VtblGap1_1();

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x060004EF RID: 1263
		// (set) Token: 0x060004F0 RID: 1264
		[DispId(2)]
		NetUser DstUser { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.Interface)] [param: In] set; }

		// Token: 0x060004F1 RID: 1265
		void _VtblGap2_1();

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x060004F2 RID: 1266
		[DispId(4)]
		string AvailableProfiles { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x060004F3 RID: 1267
		[DispId(5)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ClearProfileMappings();

		// Token: 0x060004F4 RID: 1268
		[DispId(6)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetProfileMapping([In] uint index, [MarshalAs(UnmanagedType.BStr)] out string pbstrSrcProfile, [MarshalAs(UnmanagedType.BStr)] out string pbstrDstProfile);

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x060004F5 RID: 1269
		// (set) Token: 0x060004F6 RID: 1270
		[DispId(7)]
		string ProfileMappings { [DispId(7)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(7)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }
	}
}
