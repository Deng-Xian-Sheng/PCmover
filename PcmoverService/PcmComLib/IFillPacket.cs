using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200006D RID: 109
	[CompilerGenerated]
	[Guid("B913AC5D-4FD1-4405-BCA9-66AECA8F0D3E")]
	[TypeIdentifier]
	[ComImport]
	public interface IFillPacket : ICommandPacket
	{
		// Token: 0x0600032B RID: 811
		void _VtblGap1_4();

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x0600032C RID: 812
		[DispId(11)]
		MACHINE_DETAIL detail { [DispId(11)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x0600032D RID: 813
		[DispId(12)]
		bool endWhenDone { [DispId(12)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
