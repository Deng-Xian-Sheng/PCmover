using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000061 RID: 97
	[CompilerGenerated]
	[Guid("767D52C9-FD40-406E-9081-D0D47AB25582")]
	[TypeIdentifier]
	[ComImport]
	public interface ICommandPacket
	{
		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060002DC RID: 732
		[DispId(1)]
		CommandType Type { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x060002DD RID: 733
		[DispId(2)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void dispose();

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060002DE RID: 734
		[DispId(3)]
		uint extraDataLength { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x060002DF RID: 735
		[DispId(4)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetExtraData([In] [Out] ref uint length, [In] [Out] ref byte extraData);
	}
}
