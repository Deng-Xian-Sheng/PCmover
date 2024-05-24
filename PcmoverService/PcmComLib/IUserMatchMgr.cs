using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200009C RID: 156
	[CompilerGenerated]
	[Guid("1FB46F87-A070-46CA-B4D6-A1FE4CC4E9E2")]
	[TypeIdentifier]
	[ComImport]
	public interface IUserMatchMgr
	{
		// Token: 0x060004F7 RID: 1271
		void _VtblGap1_1();

		// Token: 0x060004F8 RID: 1272
		[DispId(5)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		UserMatch GetMatchByName([MarshalAs(UnmanagedType.BStr)] [In] string bstrIdentifyingName);

		// Token: 0x060004F9 RID: 1273
		[DispId(6)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		NetUser CreateNewUser([MarshalAs(UnmanagedType.Interface)] [In] NetUser oldUser, [MarshalAs(UnmanagedType.BStr)] [In] string bstrDomain, [MarshalAs(UnmanagedType.BStr)] [In] string bstrName);

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x060004FA RID: 1274
		// (set) Token: 0x060004FB RID: 1275
		[DispId(7)]
		bool MoveFiles { [DispId(7)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(7)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060004FC RID: 1276
		[DispId(8)]
		bool RequireJoinedDomain { [DispId(8)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
