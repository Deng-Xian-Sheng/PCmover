using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200007B RID: 123
	[CompilerGenerated]
	[Guid("DDC76BCF-D0D0-46F8-97ED-5B4DC199213E")]
	[TypeIdentifier]
	[ComImport]
	public interface INetUserMgr
	{
		// Token: 0x060003AB RID: 939
		void _VtblGap1_1();

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060003AC RID: 940
		[DispId(2)]
		NetUser CurrentUser { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060003AD RID: 941
		void _VtblGap2_1();

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060003AE RID: 942
		[DispId(4)]
		NetUser Accts { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060003AF RID: 943
		[DispId(5)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		NetUser FindUser([MarshalAs(UnmanagedType.BStr)] [In] string IdentifyingName);

		// Token: 0x060003B0 RID: 944
		[DispId(6)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		NetUser FindUserBySid([MarshalAs(UnmanagedType.BStr)] [In] string Sid);
	}
}
