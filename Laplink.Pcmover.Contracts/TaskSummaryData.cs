using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200006C RID: 108
	public class TaskSummaryData
	{
		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060002E4 RID: 740 RVA: 0x00003C8B File Offset: 0x00001E8B
		// (set) Token: 0x060002E5 RID: 741 RVA: 0x00003C93 File Offset: 0x00001E93
		public Version Version { get; set; }

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060002E6 RID: 742 RVA: 0x00003C9C File Offset: 0x00001E9C
		// (set) Token: 0x060002E7 RID: 743 RVA: 0x00003CA4 File Offset: 0x00001EA4
		public DateTime StartTime { get; set; }

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060002E8 RID: 744 RVA: 0x00003CAD File Offset: 0x00001EAD
		// (set) Token: 0x060002E9 RID: 745 RVA: 0x00003CB5 File Offset: 0x00001EB5
		public DateTime FinishTime { get; set; }

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00003CBE File Offset: 0x00001EBE
		// (set) Token: 0x060002EB RID: 747 RVA: 0x00003CC6 File Offset: 0x00001EC6
		public TransferProcessResult Status { get; set; }

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060002EC RID: 748 RVA: 0x00003CCF File Offset: 0x00001ECF
		// (set) Token: 0x060002ED RID: 749 RVA: 0x00003CD7 File Offset: 0x00001ED7
		public MachineData SrcMachine { get; set; }

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060002EE RID: 750 RVA: 0x00003CE0 File Offset: 0x00001EE0
		// (set) Token: 0x060002EF RID: 751 RVA: 0x00003CE8 File Offset: 0x00001EE8
		public UserDetail SrcUser { get; set; }

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x00003CF1 File Offset: 0x00001EF1
		// (set) Token: 0x060002F1 RID: 753 RVA: 0x00003CF9 File Offset: 0x00001EF9
		public MachineData DestMachine { get; set; }

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x00003D02 File Offset: 0x00001F02
		// (set) Token: 0x060002F3 RID: 755 RVA: 0x00003D0A File Offset: 0x00001F0A
		public UserDetail DestUser { get; set; }

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x00003D13 File Offset: 0x00001F13
		// (set) Token: 0x060002F5 RID: 757 RVA: 0x00003D1B File Offset: 0x00001F1B
		public TaskAction Action { get; set; }

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x00003D24 File Offset: 0x00001F24
		// (set) Token: 0x060002F7 RID: 759 RVA: 0x00003D2C File Offset: 0x00001F2C
		public TransferMethodType TransferMethodType { get; set; }

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x00003D35 File Offset: 0x00001F35
		// (set) Token: 0x060002F9 RID: 761 RVA: 0x00003D3D File Offset: 0x00001F3D
		public uint UsersTransferred { get; set; }

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060002FA RID: 762 RVA: 0x00003D46 File Offset: 0x00001F46
		// (set) Token: 0x060002FB RID: 763 RVA: 0x00003D4E File Offset: 0x00001F4E
		public uint UsersCreated { get; set; }

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060002FC RID: 764 RVA: 0x00003D57 File Offset: 0x00001F57
		// (set) Token: 0x060002FD RID: 765 RVA: 0x00003D5F File Offset: 0x00001F5F
		public uint GroupsTransferred { get; set; }

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060002FE RID: 766 RVA: 0x00003D68 File Offset: 0x00001F68
		// (set) Token: 0x060002FF RID: 767 RVA: 0x00003D70 File Offset: 0x00001F70
		public uint GroupsCreated { get; set; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000300 RID: 768 RVA: 0x00003D79 File Offset: 0x00001F79
		// (set) Token: 0x06000301 RID: 769 RVA: 0x00003D81 File Offset: 0x00001F81
		public uint Applications { get; set; }
	}
}
