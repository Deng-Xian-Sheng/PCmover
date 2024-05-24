using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000076 RID: 118
	public class TransferStatus
	{
		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000325 RID: 805 RVA: 0x00003ED8 File Offset: 0x000020D8
		// (set) Token: 0x06000326 RID: 806 RVA: 0x00003EE0 File Offset: 0x000020E0
		public string TargetPath { get; set; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000327 RID: 807 RVA: 0x00003EE9 File Offset: 0x000020E9
		// (set) Token: 0x06000328 RID: 808 RVA: 0x00003EF1 File Offset: 0x000020F1
		public string TargetName { get; set; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000329 RID: 809 RVA: 0x00003EFA File Offset: 0x000020FA
		// (set) Token: 0x0600032A RID: 810 RVA: 0x00003F02 File Offset: 0x00002102
		public TransferAction IfExistsAction { get; set; }

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600032B RID: 811 RVA: 0x00003F0B File Offset: 0x0000210B
		// (set) Token: 0x0600032C RID: 812 RVA: 0x00003F13 File Offset: 0x00002113
		public TransferAction IfNotExistsAction { get; set; }

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x0600032D RID: 813 RVA: 0x00003F1C File Offset: 0x0000211C
		// (set) Token: 0x0600032E RID: 814 RVA: 0x00003F24 File Offset: 0x00002124
		public bool Exists { get; set; }

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x0600032F RID: 815 RVA: 0x00003F2D File Offset: 0x0000212D
		// (set) Token: 0x06000330 RID: 816 RVA: 0x00003F35 File Offset: 0x00002135
		public TransferItemResult Result { get; set; }

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000331 RID: 817 RVA: 0x00003F3E File Offset: 0x0000213E
		// (set) Token: 0x06000332 RID: 818 RVA: 0x00003F46 File Offset: 0x00002146
		public int FailureReason { get; set; }
	}
}
