using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000065 RID: 101
	[CompilerGenerated]
	[Guid("1CAF2975-A437-42AE-90D7-7BC287BA84E7")]
	[TypeIdentifier]
	[ComImport]
	public interface IDonePolicy
	{
		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060002FC RID: 764
		[DispId(1)]
		bool bReboot { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x060002FD RID: 765
		void _VtblGap1_1();

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060002FE RID: 766
		[DispId(3)]
		bool bUploadReport { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x060002FF RID: 767
		void _VtblGap2_1();

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000300 RID: 768
		[DispId(5)]
		bool bInteractive { [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
