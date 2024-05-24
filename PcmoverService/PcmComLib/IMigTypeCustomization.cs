using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000074 RID: 116
	[CompilerGenerated]
	[Guid("BC1DD1FD-515A-4E69-933A-774D3C4EBCF9")]
	[TypeIdentifier]
	[ComImport]
	public interface IMigTypeCustomization
	{
		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000380 RID: 896
		[DispId(1)]
		MIGTYPE_OPTION DefaultOption { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000381 RID: 897
		void _VtblGap1_4();

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000382 RID: 898
		[DispId(6)]
		ImagePolicy ImagePolicy { [DispId(6)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }
	}
}
