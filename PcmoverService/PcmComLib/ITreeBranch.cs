using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000091 RID: 145
	[CompilerGenerated]
	[Guid("0B323D30-E409-41AC-985F-B3FD14385BBB")]
	[TypeIdentifier]
	[ComImport]
	public interface ITreeBranch : IPCmoverObject
	{
		// Token: 0x060004A4 RID: 1188
		void _VtblGap1_1();

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060004A5 RID: 1189
		[DispId(2)]
		ulong Id { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060004A6 RID: 1190
		[DispId(3)]
		string strId { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060004A7 RID: 1191
		[DispId(4)]
		string strRootPath { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060004A8 RID: 1192
		[DispId(5)]
		NetUser User { [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060004A9 RID: 1193
		[DispId(6)]
		TreeImpl Tree { [DispId(6)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060004AA RID: 1194
		void _VtblGap2_1();

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060004AB RID: 1195
		[DispId(8)]
		string GroupId { [DispId(8)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }
	}
}
