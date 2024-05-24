using System;

namespace Laplink.Download.Contracts
{
	// Token: 0x02000007 RID: 7
	public enum PackageState
	{
		// Token: 0x0400001E RID: 30
		Ready,
		// Token: 0x0400001F RID: 31
		Downloading,
		// Token: 0x04000020 RID: 32
		DownloadComplete,
		// Token: 0x04000021 RID: 33
		Installing,
		// Token: 0x04000022 RID: 34
		Complete,
		// Token: 0x04000023 RID: 35
		Error,
		// Token: 0x04000024 RID: 36
		Cancelled,
		// Token: 0x04000025 RID: 37
		WaitingToInstall,
		// Token: 0x04000026 RID: 38
		Fail
	}
}
