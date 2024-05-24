using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200006A RID: 106
	[CompilerGenerated]
	[Guid("FEC1A257-136C-40F2-8666-D334475EBF30")]
	[TypeIdentifier]
	[ComImport]
	public interface IFileConnectionPolicy
	{
		// Token: 0x0600031B RID: 795
		void _VtblGap1_10();

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600031C RID: 796
		[DispId(11)]
		FileNamePolicy VanNamePolicy { [DispId(11)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x0600031D RID: 797
		[DispId(12)]
		PasswordPolicy VanPasswordPolicy { [DispId(12)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600031E RID: 798
		[DispId(13)]
		TRIBOOL_VALUE IsMachineOld { [DispId(13)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
