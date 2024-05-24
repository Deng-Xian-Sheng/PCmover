using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200007A RID: 122
	[CompilerGenerated]
	[Guid("A8C03E51-FE1F-463A-BAF0-6154DFC993B9")]
	[TypeIdentifier]
	[ComImport]
	public interface INetUser : IPCmoverObject
	{
		// Token: 0x0600039B RID: 923
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void dispose();

		// Token: 0x0600039C RID: 924
		void _VtblGap1_1();

		// Token: 0x0600039D RID: 925
		[DispId(3)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool SetPassword([MarshalAs(UnmanagedType.BStr)] [In] string password);

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x0600039E RID: 926
		[DispId(4)]
		string DisplayableName { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x0600039F RID: 927
		void _VtblGap2_4();

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060003A0 RID: 928
		// (set) Token: 0x060003A1 RID: 929
		[DispId(7)]
		string FullName { [DispId(7)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(7)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060003A2 RID: 930
		// (set) Token: 0x060003A3 RID: 931
		[DispId(8)]
		string KeyGroups { [DispId(8)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(8)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060003A4 RID: 932
		[DispId(9)]
		bool bCreated { [DispId(9)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060003A5 RID: 933
		[DispId(10)]
		string IdentifyingName { [DispId(10)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060003A6 RID: 934
		[DispId(11)]
		bool IsRegularUser { [DispId(11)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060003A7 RID: 935
		[DispId(12)]
		bool IsCurrentUser { [DispId(12)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060003A8 RID: 936
		[DispId(13)]
		bool IsAzureAdUser { [DispId(13)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060003A9 RID: 937
		[DispId(14)]
		string Sid { [DispId(14)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x060003AA RID: 938
		[DispId(15)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetMapiProfile([In] uint index, [MarshalAs(UnmanagedType.BStr)] out string pbstrProfileName, [MarshalAs(UnmanagedType.BStr)] out string pbstrSourceMachineName, [MarshalAs(UnmanagedType.BStr)] out string pbstrSourceUserName, [MarshalAs(UnmanagedType.BStr)] out string pbstrSourceProfileName);
	}
}
