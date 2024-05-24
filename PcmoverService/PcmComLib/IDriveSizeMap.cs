using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000067 RID: 103
	[CompilerGenerated]
	[Guid("0F490B4F-123A-468C-BF2D-AE51D1B4016F")]
	[TypeIdentifier]
	[ComImport]
	public interface IDriveSizeMap
	{
		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000305 RID: 773
		[DispId(3)]
		int FirstDrive { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000306 RID: 774
		[DispId(4)]
		int LastDrive { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000307 RID: 775
		[DispId(5)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetSize([In] int nDrive, out ulong totalBytes, out ulong freeBytes);
	}
}
