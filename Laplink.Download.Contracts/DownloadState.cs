using System;

namespace Laplink.Download.Contracts
{
	// Token: 0x02000003 RID: 3
	public enum DownloadState
	{
		// Token: 0x04000008 RID: 8
		Idle,
		// Token: 0x04000009 RID: 9
		Active,
		// Token: 0x0400000A RID: 10
		WaitingForReboot,
		// Token: 0x0400000B RID: 11
		Complete
	}
}
