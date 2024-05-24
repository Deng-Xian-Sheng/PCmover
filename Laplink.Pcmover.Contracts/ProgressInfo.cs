using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000055 RID: 85
	public class ProgressInfo
	{
		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000255 RID: 597 RVA: 0x000034F9 File Offset: 0x000016F9
		// (set) Token: 0x06000256 RID: 598 RVA: 0x00003501 File Offset: 0x00001701
		public DateTime TimeStampUtc { get; set; }

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000257 RID: 599 RVA: 0x0000350A File Offset: 0x0000170A
		// (set) Token: 0x06000258 RID: 600 RVA: 0x00003512 File Offset: 0x00001712
		public string Task { get; set; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000259 RID: 601 RVA: 0x0000351B File Offset: 0x0000171B
		// (set) Token: 0x0600025A RID: 602 RVA: 0x00003523 File Offset: 0x00001723
		public UiCallbackCode TaskCode { get; set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x0600025B RID: 603 RVA: 0x0000352C File Offset: 0x0000172C
		// (set) Token: 0x0600025C RID: 604 RVA: 0x00003534 File Offset: 0x00001734
		public string Action { get; set; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x0600025D RID: 605 RVA: 0x0000353D File Offset: 0x0000173D
		// (set) Token: 0x0600025E RID: 606 RVA: 0x00003545 File Offset: 0x00001745
		public UiCallbackCode ActionCode { get; set; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600025F RID: 607 RVA: 0x0000354E File Offset: 0x0000174E
		// (set) Token: 0x06000260 RID: 608 RVA: 0x00003556 File Offset: 0x00001756
		public string Item { get; set; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000261 RID: 609 RVA: 0x0000355F File Offset: 0x0000175F
		// (set) Token: 0x06000262 RID: 610 RVA: 0x00003567 File Offset: 0x00001767
		public UiCallbackCode ItemCode { get; set; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000263 RID: 611 RVA: 0x00003570 File Offset: 0x00001770
		// (set) Token: 0x06000264 RID: 612 RVA: 0x00003578 File Offset: 0x00001778
		public ushort Percentage { get; set; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00003581 File Offset: 0x00001781
		// (set) Token: 0x06000266 RID: 614 RVA: 0x00003589 File Offset: 0x00001789
		public ulong BytesProcessed { get; set; }

		// Token: 0x06000267 RID: 615 RVA: 0x00003594 File Offset: 0x00001794
		public override string ToString()
		{
			return string.Format("Progress {0} {1} / {2} / {3} {4}% {5}", new object[]
			{
				this.TimeStampUtc.ToLocalTime(),
				this.Task,
				this.Action,
				this.Item,
				this.Percentage,
				this.BytesProcessed
			});
		}
	}
}
