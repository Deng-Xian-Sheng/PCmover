using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Net
{
	// Token: 0x0200001A RID: 26
	[TypeLibType(4160)]
	[Guid("DCB00000-570F-4A9B-8D69-199FDBA5723B")]
	[ComImport]
	internal interface INetworkListManager
	{
		// Token: 0x0600007F RID: 127
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumerable GetNetworks([In] NetworkConnectivityLevels Flags);

		// Token: 0x06000080 RID: 128
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		INetwork GetNetwork([In] Guid gdNetworkId);

		// Token: 0x06000081 RID: 129
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumerable GetNetworkConnections();

		// Token: 0x06000082 RID: 130
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		INetworkConnection GetNetworkConnection([In] Guid gdNetworkConnectionId);

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000083 RID: 131
		bool IsConnectedToInternet { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000084 RID: 132
		bool IsConnected { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000085 RID: 133
		[MethodImpl(MethodImplOptions.InternalCall)]
		ConnectivityStates GetConnectivity();
	}
}
