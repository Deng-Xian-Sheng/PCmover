using System;

namespace Laplink.Service.Contracts
{
	// Token: 0x02000006 RID: 6
	[Flags]
	public enum RebootPendingReasons
	{
		// Token: 0x04000008 RID: 8
		None = 0,
		// Token: 0x04000009 RID: 9
		ComponentBasedServicing = 1,
		// Token: 0x0400000A RID: 10
		WindowsUpdateAutoUpdate = 2,
		// Token: 0x0400000B RID: 11
		PendingFileRename = 4,
		// Token: 0x0400000C RID: 12
		PendingFileDelete = 8,
		// Token: 0x0400000D RID: 13
		PendingDomainJoin = 16,
		// Token: 0x0400000E RID: 14
		PendingComputerRename = 32,
		// Token: 0x0400000F RID: 15
		SCCM = 64,
		// Token: 0x04000010 RID: 16
		UpdateInProgress = 128,
		// Token: 0x04000011 RID: 17
		UpdateRebootRequired = 256,
		// Token: 0x04000012 RID: 18
		RebootAfterRedistInstall = 7,
		// Token: 0x04000013 RID: 19
		RebootBeforeTransfer = 50
	}
}
