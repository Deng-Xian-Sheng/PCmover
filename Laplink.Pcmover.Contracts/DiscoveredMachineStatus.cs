using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000012 RID: 18
	public enum DiscoveredMachineStatus
	{
		// Token: 0x04000073 RID: 115
		MachineFound,
		// Token: 0x04000074 RID: 116
		MachineLost,
		// Token: 0x04000075 RID: 117
		AddressSpecified,
		// Token: 0x04000076 RID: 118
		Connecting,
		// Token: 0x04000077 RID: 119
		GetUserData,
		// Token: 0x04000078 RID: 120
		DataReceived,
		// Token: 0x04000079 RID: 121
		SettingDirection,
		// Token: 0x0400007A RID: 122
		DirectionSet,
		// Token: 0x0400007B RID: 123
		ManualConnection,
		// Token: 0x0400007C RID: 124
		RemoteManualConnection,
		// Token: 0x0400007D RID: 125
		ConnectFailed,
		// Token: 0x0400007E RID: 126
		CommunicationError,
		// Token: 0x0400007F RID: 127
		Exception,
		// Token: 0x04000080 RID: 128
		FindingRemoteComputer,
		// Token: 0x04000081 RID: 129
		MachineNotFound,
		// Token: 0x04000082 RID: 130
		UpdateTransferMethodHandle,
		// Token: 0x04000083 RID: 131
		DirectionNotification
	}
}
