using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000068 RID: 104
	[CompilerGenerated]
	[Guid("11E4ABFE-FD98-4528-AA67-307D7D5B52EE")]
	[TypeIdentifier]
	[ComImport]
	public interface IDriveSpaceRequiredMap
	{
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000308 RID: 776
		[DispId(3)]
		int FirstDrive { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000309 RID: 777
		[DispId(4)]
		int LastDrive { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600030A RID: 778
		[DispId(5)]
		ulong Bytes { [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
