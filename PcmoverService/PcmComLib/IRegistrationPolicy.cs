using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000088 RID: 136
	[CompilerGenerated]
	[Guid("3AE35C61-9A2C-4B63-9B7A-AA9D86893371")]
	[TypeIdentifier]
	[ComImport]
	public interface IRegistrationPolicy
	{
		// Token: 0x06000461 RID: 1121
		void _VtblGap1_3();

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000462 RID: 1122
		[DispId(4)]
		string strSerialNumber { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000463 RID: 1123
		[DispId(5)]
		string strName { [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000464 RID: 1124
		[DispId(6)]
		string strEmail { [DispId(6)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }
	}
}
