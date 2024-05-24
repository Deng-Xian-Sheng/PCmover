using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200008C RID: 140
	[CompilerGenerated]
	[Guid("E544B8CD-2AE5-4247-9B20-A47A32D0B7A3")]
	[TypeIdentifier]
	[ComImport]
	public interface IReportsPolicy
	{
		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000498 RID: 1176
		[DispId(1)]
		ReportPolicy ReportPolicies { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000499 RID: 1177
		[DispId(2)]
		string strBaseDir { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x0600049A RID: 1178
		void _VtblGap1_1();

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x0600049B RID: 1179
		[DispId(4)]
		bool bDefaultClientReports { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
