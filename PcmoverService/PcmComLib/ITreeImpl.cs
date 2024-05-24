using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000093 RID: 147
	[CompilerGenerated]
	[Guid("3104CDD9-1220-47DA-B092-DC29798EE420")]
	[TypeIdentifier]
	[ComImport]
	public interface ITreeImpl : ITreeNode
	{
		// Token: 0x060004AF RID: 1199
		void _VtblGap1_12();

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060004B0 RID: 1200
		[DispId(13)]
		TreeBranch Branch { [DispId(13)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060004B1 RID: 1201
		void _VtblGap2_1();

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060004B2 RID: 1202
		[DispId(50)]
		TreeNode Child { [DispId(50)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060004B3 RID: 1203
		[DispId(51)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		TreeImpl FindTreeFromPath([MarshalAs(UnmanagedType.BStr)] [In] string strPath);

		// Token: 0x060004B4 RID: 1204
		void _VtblGap3_1();

		// Token: 0x060004B5 RID: 1205
		[DispId(53)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		TreeStats GetStats([In] bool bWithinBranch, [In] bool bAllAppsOnly);
	}
}
