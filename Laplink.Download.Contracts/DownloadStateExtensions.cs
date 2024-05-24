using System;

namespace Laplink.Download.Contracts
{
	// Token: 0x02000004 RID: 4
	public static class DownloadStateExtensions
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public static bool IsActive(this DownloadState state)
		{
			return state == DownloadState.Active || state == DownloadState.WaitingForReboot;
		}
	}
}
