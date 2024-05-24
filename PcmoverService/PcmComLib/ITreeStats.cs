using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000097 RID: 151
	[CompilerGenerated]
	[Guid("8B79CB81-B31E-4560-AAC8-14C7A458FC17")]
	[TypeIdentifier]
	[ComImport]
	public interface ITreeStats
	{
		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060004C5 RID: 1221
		[DispId(1)]
		ulong nBytes { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060004C6 RID: 1222
		[DispId(2)]
		ulong nLeaves { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060004C7 RID: 1223
		[DispId(3)]
		ulong nTrees { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
