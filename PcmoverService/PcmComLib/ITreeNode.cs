using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000094 RID: 148
	[CompilerGenerated]
	[Guid("1FC906A3-3CC1-4B81-B877-0BEA18F5B723")]
	[TypeIdentifier]
	[ComImport]
	public interface ITreeNode : IPCmoverObject
	{
		// Token: 0x060004B6 RID: 1206
		void _VtblGap1_2();

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060004B7 RID: 1207
		[DispId(3)]
		string Name { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x060004B8 RID: 1208
		void _VtblGap2_1();

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060004B9 RID: 1209
		[DispId(5)]
		bool IsTree { [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x060004BA RID: 1210
		void _VtblGap3_3();

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060004BB RID: 1211
		[DispId(9)]
		ulong NumBytes { [DispId(9)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x060004BC RID: 1212
		void _VtblGap4_3();

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060004BD RID: 1213
		[DispId(13)]
		TreeBranch Branch { [DispId(13)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060004BE RID: 1214
		[DispId(14)]
		bool BelongsToAllApps { [DispId(14)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
