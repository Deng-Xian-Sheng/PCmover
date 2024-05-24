using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000092 RID: 146
	[CompilerGenerated]
	[Guid("8820B037-03AA-4012-A01E-F9CB82E4DCF2")]
	[TypeIdentifier]
	[ComImport]
	public interface ITreeBranches : IPCmoverObject, IEnumerable
	{
		// Token: 0x060004AC RID: 1196
		void _VtblGap1_2();

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060004AD RID: 1197
		[DispId(1610809344)]
		int Count { [DispId(1610809344)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700016B RID: 363
		[DispId(0)]
		TreeBranch this[[In] int n]
		{
			[DispId(0)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}
}
