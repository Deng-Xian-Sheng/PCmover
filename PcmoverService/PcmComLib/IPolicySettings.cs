using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000085 RID: 133
	[CompilerGenerated]
	[Guid("862A63B4-ED58-4CC2-81C7-2C958378C8E4")]
	[TypeIdentifier]
	[ComImport]
	public interface IPolicySettings
	{
		// Token: 0x06000451 RID: 1105
		void _VtblGap1_3();

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000452 RID: 1106
		[DispId(8)]
		bool bDisplayUI { [DispId(8)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000453 RID: 1107
		void _VtblGap2_2();

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000454 RID: 1108
		[DispId(11)]
		bool bDisplayWarningPage { [DispId(11)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000455 RID: 1109
		void _VtblGap3_7();

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000456 RID: 1110
		[DispId(19)]
		bool OnlySameDomain { [DispId(19)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
