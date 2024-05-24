using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000075 RID: 117
	[CompilerGenerated]
	[Guid("D5A92A32-96DF-4B18-BF3F-A1855A01C41E")]
	[TypeIdentifier]
	[ComImport]
	public interface IMigrationStatus
	{
		// Token: 0x06000383 RID: 899
		void _VtblGap1_2();

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000384 RID: 900
		// (set) Token: 0x06000385 RID: 901
		[DispId(2)]
		MS_STATE state { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000386 RID: 902
		// (set) Token: 0x06000387 RID: 903
		[DispId(3)]
		MS_ACTIVE_STATE activeState { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }
	}
}
