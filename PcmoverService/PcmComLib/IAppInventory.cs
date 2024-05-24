using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200005B RID: 91
	[CompilerGenerated]
	[Guid("D056C5A4-7CAD-4187-9303-2AC90869EE1F")]
	[TypeIdentifier]
	[ComImport]
	public interface IAppInventory : IPCmoverObject, IEnumerable
	{
		// Token: 0x060002B0 RID: 688
		void _VtblGap1_2();

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060002B1 RID: 689
		[DispId(1610809344)]
		int Count { [DispId(1610809344)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700007F RID: 127
		[DispId(0)]
		AppProfile this[[In] int n]
		{
			[DispId(0)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		// Token: 0x060002B3 RID: 691
		void _VtblGap2_2();

		// Token: 0x060002B4 RID: 692
		[DispId(4)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		AppProfile FindAppById([In] ulong Id);
	}
}
