using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000066 RID: 102
	[CompilerGenerated]
	[Guid("E16ED777-07D5-4967-9076-2F7D261C27F3")]
	[TypeIdentifier]
	[ComImport]
	public interface IDriveMatch
	{
		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000301 RID: 769
		[DispId(3)]
		PcmStringList OldDrives { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000302 RID: 770
		[DispId(4)]
		PcmStringList NewDrives { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000303 RID: 771
		// (set) Token: 0x06000304 RID: 772
		[DispId(5)]
		string Match { [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }
	}
}
