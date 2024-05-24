using System;

namespace Laplink.Download.Contracts
{
	// Token: 0x02000005 RID: 5
	public class DownloadStatusInfo
	{
		// Token: 0x06000003 RID: 3 RVA: 0x00002050 File Offset: 0x00000250
		public DownloadStatusInfo()
		{
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002064 File Offset: 0x00000264
		public DownloadStatusInfo(DownloadState state, bool hasController)
		{
			this.State = state;
			this.HasController = hasController;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x0000207A File Offset: 0x0000027A
		// (set) Token: 0x06000006 RID: 6 RVA: 0x00002082 File Offset: 0x00000282
		public DownloadState State { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000007 RID: 7 RVA: 0x0000208B File Offset: 0x0000028B
		// (set) Token: 0x06000008 RID: 8 RVA: 0x00002093 File Offset: 0x00000293
		public bool HasController { get; set; }

		// Token: 0x06000009 RID: 9 RVA: 0x0000209C File Offset: 0x0000029C
		public override string ToString()
		{
			return string.Format("State: {0}, HasController: {1}", this.State, this.HasController);
		}
	}
}
