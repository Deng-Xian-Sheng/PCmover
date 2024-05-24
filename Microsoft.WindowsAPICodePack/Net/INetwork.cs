using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Net
{
	// Token: 0x02000018 RID: 24
	[Guid("DCB00002-570F-4A9B-8D69-199FDBA5723B")]
	[TypeLibType(4160)]
	[ComImport]
	internal interface INetwork
	{
		// Token: 0x0600006B RID: 107
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetName();

		// Token: 0x0600006C RID: 108
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetName([MarshalAs(UnmanagedType.BStr)] [In] string szNetworkNewName);

		// Token: 0x0600006D RID: 109
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetDescription();

		// Token: 0x0600006E RID: 110
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetDescription([MarshalAs(UnmanagedType.BStr)] [In] string szDescription);

		// Token: 0x0600006F RID: 111
		[MethodImpl(MethodImplOptions.InternalCall)]
		Guid GetNetworkId();

		// Token: 0x06000070 RID: 112
		[MethodImpl(MethodImplOptions.InternalCall)]
		DomainType GetDomainType();

		// Token: 0x06000071 RID: 113
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumerable GetNetworkConnections();

		// Token: 0x06000072 RID: 114
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetTimeCreatedAndConnected(out uint pdwLowDateTimeCreated, out uint pdwHighDateTimeCreated, out uint pdwLowDateTimeConnected, out uint pdwHighDateTimeConnected);

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000073 RID: 115
		bool IsConnectedToInternet { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000074 RID: 116
		bool IsConnected { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000075 RID: 117
		[MethodImpl(MethodImplOptions.InternalCall)]
		ConnectivityStates GetConnectivity();

		// Token: 0x06000076 RID: 118
		[MethodImpl(MethodImplOptions.InternalCall)]
		NetworkCategory GetCategory();

		// Token: 0x06000077 RID: 119
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetCategory([In] NetworkCategory NewCategory);
	}
}
