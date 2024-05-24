using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200005C RID: 92
	[CompilerGenerated]
	[Guid("72BBEBCA-2FBE-4DB7-8BB7-2217D284F183")]
	[TypeIdentifier]
	[ComImport]
	public interface IAppProfile : IPCmoverObject
	{
		// Token: 0x060002B5 RID: 693
		void _VtblGap1_1();

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060002B6 RID: 694
		[DispId(2)]
		ulong Id { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060002B7 RID: 695
		[DispId(3)]
		string DisplayName { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060002B8 RID: 696
		[DispId(4)]
		string AppId { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x060002B9 RID: 697
		void _VtblGap2_4();

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060002BA RID: 698
		[DispId(9)]
		string Publisher { [DispId(9)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x060002BB RID: 699
		void _VtblGap3_1();

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060002BC RID: 700
		[DispId(11)]
		string UserName { [DispId(11)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060002BD RID: 701
		[DispId(12)]
		bool IsDisplayed { [DispId(12)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060002BE RID: 702
		[DispId(13)]
		bool IsComponent { [DispId(13)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060002BF RID: 703
		[DispId(14)]
		bool IsSelectionLocked { [DispId(14)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x060002C0 RID: 704
		void _VtblGap4_1();

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060002C1 RID: 705
		[DispId(16)]
		IntPtr SmallIcon { [DispId(16)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060002C2 RID: 706
		[DispId(17)]
		IntPtr LargeIcon { [DispId(17)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060002C3 RID: 707
		[DispId(18)]
		bool IsTrialVersion { [DispId(18)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060002C4 RID: 708
		[DispId(19)]
		ulong AppDiskSpace { [DispId(19)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x060002C5 RID: 709
		void _VtblGap5_1();

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060002C6 RID: 710
		[DispId(21)]
		bool IsMicrosoftOffice { [DispId(21)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060002C7 RID: 711
		[DispId(22)]
		bool IsSelected { [DispId(22)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
