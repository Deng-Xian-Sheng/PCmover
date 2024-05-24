using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200008F RID: 143
	[CompilerGenerated]
	[Guid("9AC8D38B-E1C2-4D8C-A78F-1D20098BF36D")]
	[TypeIdentifier]
	[ComImport]
	public interface ITaskItemRoot
	{
		// Token: 0x060004A0 RID: 1184
		[DispId(3)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ResetChangeLists();

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060004A1 RID: 1185
		[DispId(4)]
		TreeStats TreeStats { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x060004A2 RID: 1186
		[DispId(5)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void CopyStats([MarshalAs(UnmanagedType.Interface)] out TreeStats ppTreeStats, [MarshalAs(UnmanagedType.Interface)] out DriveSpaceRequiredMap ppDriveSpaceRequiredMap);

		// Token: 0x060004A3 RID: 1187
		[DispId(6)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool IsExcluded([MarshalAs(UnmanagedType.Interface)] [In] TreeBranch pBranch);
	}
}
