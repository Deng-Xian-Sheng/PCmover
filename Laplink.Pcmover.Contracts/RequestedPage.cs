using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200005C RID: 92
	public class RequestedPage
	{
		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000282 RID: 642 RVA: 0x00003716 File Offset: 0x00001916
		// (set) Token: 0x06000283 RID: 643 RVA: 0x0000371E File Offset: 0x0000191E
		public int StartIndex { get; set; }

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000284 RID: 644 RVA: 0x00003727 File Offset: 0x00001927
		// (set) Token: 0x06000285 RID: 645 RVA: 0x0000372F File Offset: 0x0000192F
		public int MaxCount { get; set; }

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000286 RID: 646 RVA: 0x00003738 File Offset: 0x00001938
		public int ExpectedEnd
		{
			get
			{
				return this.StartIndex + this.MaxCount;
			}
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00002050 File Offset: 0x00000250
		public RequestedPage()
		{
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00003747 File Offset: 0x00001947
		public RequestedPage(int maxCount)
		{
			this.MaxCount = maxCount;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00003756 File Offset: 0x00001956
		public void NextPage()
		{
			this.StartIndex += this.MaxCount;
		}
	}
}
