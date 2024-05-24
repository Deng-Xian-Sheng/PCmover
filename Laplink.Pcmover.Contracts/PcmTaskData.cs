using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000068 RID: 104
	public class PcmTaskData
	{
		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060002D0 RID: 720 RVA: 0x00003BD7 File Offset: 0x00001DD7
		// (set) Token: 0x060002D1 RID: 721 RVA: 0x00003BDF File Offset: 0x00001DDF
		public int Handle { get; set; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x00003BE8 File Offset: 0x00001DE8
		// (set) Token: 0x060002D3 RID: 723 RVA: 0x00003BF0 File Offset: 0x00001DF0
		public PcmTaskType TaskType { get; set; }

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x00003BF9 File Offset: 0x00001DF9
		// (set) Token: 0x060002D5 RID: 725 RVA: 0x00003C01 File Offset: 0x00001E01
		public int SourceMachineHandle { get; set; }

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x00003C0A File Offset: 0x00001E0A
		// (set) Token: 0x060002D7 RID: 727 RVA: 0x00003C12 File Offset: 0x00001E12
		public int DestMachineHandle { get; set; }

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x00003C1B File Offset: 0x00001E1B
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x00003C23 File Offset: 0x00001E23
		public bool IsReady { get; set; }
	}
}
