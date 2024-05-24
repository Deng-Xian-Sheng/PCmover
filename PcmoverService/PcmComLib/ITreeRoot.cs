using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000095 RID: 149
	[CompilerGenerated]
	[Guid("5E241EA1-057D-4626-B2BF-2BB7A6D2A826")]
	[TypeIdentifier]
	[ComImport]
	public interface ITreeRoot : IPCmoverObject
	{
		// Token: 0x060004BF RID: 1215
		void _VtblGap1_3();

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060004C0 RID: 1216
		[DispId(4)]
		TreeImpl Tree { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060004C1 RID: 1217
		[DispId(5)]
		TreeBranches Branches { [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060004C2 RID: 1218
		[DispId(6)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ExpandBranches([In] bool regularUsersOnly, [In] bool expandGlobalBranches);
	}
}
