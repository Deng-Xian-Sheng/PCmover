using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200005B RID: 91
	public class ReportData
	{
		// Token: 0x170000CA RID: 202
		// (get) Token: 0x0600026B RID: 619 RVA: 0x0000365B File Offset: 0x0000185B
		// (set) Token: 0x0600026C RID: 620 RVA: 0x00003663 File Offset: 0x00001863
		public string FileName { get; set; }

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x0600026D RID: 621 RVA: 0x0000366C File Offset: 0x0000186C
		// (set) Token: 0x0600026E RID: 622 RVA: 0x00003674 File Offset: 0x00001874
		public ReportFormat Format { get; set; }

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x0600026F RID: 623 RVA: 0x0000367D File Offset: 0x0000187D
		// (set) Token: 0x06000270 RID: 624 RVA: 0x00003685 File Offset: 0x00001885
		public ReportType Type { get; set; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000271 RID: 625 RVA: 0x0000368E File Offset: 0x0000188E
		// (set) Token: 0x06000272 RID: 626 RVA: 0x00003696 File Offset: 0x00001896
		public bool IncludeExceptionsOnly { get; set; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000273 RID: 627 RVA: 0x0000369F File Offset: 0x0000189F
		// (set) Token: 0x06000274 RID: 628 RVA: 0x000036A7 File Offset: 0x000018A7
		public bool Append { get; set; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000275 RID: 629 RVA: 0x000036B0 File Offset: 0x000018B0
		// (set) Token: 0x06000276 RID: 630 RVA: 0x000036B8 File Offset: 0x000018B8
		public bool IncludeTimestamp { get; set; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000277 RID: 631 RVA: 0x000036C1 File Offset: 0x000018C1
		// (set) Token: 0x06000278 RID: 632 RVA: 0x000036C9 File Offset: 0x000018C9
		public string Mask { get; set; }

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000279 RID: 633 RVA: 0x000036D2 File Offset: 0x000018D2
		// (set) Token: 0x0600027A RID: 634 RVA: 0x000036DA File Offset: 0x000018DA
		public ReportItems Items { get; set; }

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600027B RID: 635 RVA: 0x000036E3 File Offset: 0x000018E3
		// (set) Token: 0x0600027C RID: 636 RVA: 0x000036EB File Offset: 0x000018EB
		public bool Migrated { get; set; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600027D RID: 637 RVA: 0x000036F4 File Offset: 0x000018F4
		// (set) Token: 0x0600027E RID: 638 RVA: 0x000036FC File Offset: 0x000018FC
		public bool ShowComponents { get; set; }

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600027F RID: 639 RVA: 0x00003705 File Offset: 0x00001905
		// (set) Token: 0x06000280 RID: 640 RVA: 0x0000370D File Offset: 0x0000190D
		public ReportGenerator Generator { get; set; }
	}
}
