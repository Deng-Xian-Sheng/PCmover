using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200007E RID: 126
	[CompilerGenerated]
	[Guid("8A28B79E-C8BE-456A-9FE8-F37C13B19B1D")]
	[TypeIdentifier]
	[ComImport]
	public interface IPCmoverObject
	{
		// Token: 0x060003EC RID: 1004
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void dispose();

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060003ED RID: 1005
		[DispId(2)]
		ulong Id { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
