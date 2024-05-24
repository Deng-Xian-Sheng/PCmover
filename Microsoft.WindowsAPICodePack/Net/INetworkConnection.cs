using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Net
{
	// Token: 0x02000019 RID: 25
	[TypeLibType(4160)]
	[Guid("DCB00005-570F-4A9B-8D69-199FDBA5723B")]
	[ComImport]
	internal interface INetworkConnection
	{
		// Token: 0x06000078 RID: 120
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		INetwork GetNetwork();

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000079 RID: 121
		bool IsConnectedToInternet { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600007A RID: 122
		bool IsConnected { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x0600007B RID: 123
		[MethodImpl(MethodImplOptions.InternalCall)]
		ConnectivityStates GetConnectivity();

		// Token: 0x0600007C RID: 124
		[MethodImpl(MethodImplOptions.InternalCall)]
		Guid GetConnectionId();

		// Token: 0x0600007D RID: 125
		[MethodImpl(MethodImplOptions.InternalCall)]
		Guid GetAdapterId();

		// Token: 0x0600007E RID: 126
		[MethodImpl(MethodImplOptions.InternalCall)]
		DomainType GetDomainType();
	}
}
