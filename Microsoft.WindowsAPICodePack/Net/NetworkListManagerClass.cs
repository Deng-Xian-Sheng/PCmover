using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Net
{
	// Token: 0x0200001B RID: 27
	[ComSourceInterfaces("Microsoft.Windows.NetworkList.Internal.INetworkEvents\0Microsoft.Windows.NetworkList.Internal.INetworkConnectionEvents\0Microsoft.Windows.NetworkList.Internal.INetworkListManagerEvents\0")]
	[Guid("DCB00C01-570F-4A9B-8D69-199FDBA5723B")]
	[TypeLibType(2)]
	[ClassInterface(0)]
	[ComImport]
	internal class NetworkListManagerClass : INetworkListManager
	{
		// Token: 0x06000086 RID: 134
		[DispId(7)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern ConnectivityStates GetConnectivity();

		// Token: 0x06000087 RID: 135
		[DispId(2)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		public virtual extern INetwork GetNetwork([In] Guid gdNetworkId);

		// Token: 0x06000088 RID: 136
		[DispId(4)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		public virtual extern INetworkConnection GetNetworkConnection([In] Guid gdNetworkConnectionId);

		// Token: 0x06000089 RID: 137
		[DispId(3)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		public virtual extern IEnumerable GetNetworkConnections();

		// Token: 0x0600008A RID: 138
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		public virtual extern IEnumerable GetNetworks([In] NetworkConnectivityLevels Flags);

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600008B RID: 139
		[DispId(6)]
		public virtual extern bool IsConnected { [DispId(6)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600008C RID: 140
		[DispId(5)]
		public virtual extern bool IsConnectedToInternet { [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x0600008D RID: 141
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern NetworkListManagerClass();
	}
}
