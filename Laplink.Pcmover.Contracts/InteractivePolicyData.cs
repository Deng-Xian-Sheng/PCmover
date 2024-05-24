using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000021 RID: 33
	public class InteractivePolicyData
	{
		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x00002A4E File Offset: 0x00000C4E
		// (set) Token: 0x060000A8 RID: 168 RVA: 0x00002A56 File Offset: 0x00000C56
		public bool WarningPage { get; set; } = true;

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x00002A5F File Offset: 0x00000C5F
		// (set) Token: 0x060000AA RID: 170 RVA: 0x00002A67 File Offset: 0x00000C67
		public bool ImageTransfer { get; set; } = true;

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000AB RID: 171 RVA: 0x00002A70 File Offset: 0x00000C70
		// (set) Token: 0x060000AC RID: 172 RVA: 0x00002A78 File Offset: 0x00000C78
		public bool TransferFile { get; set; } = true;

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000AD RID: 173 RVA: 0x00002A81 File Offset: 0x00000C81
		// (set) Token: 0x060000AE RID: 174 RVA: 0x00002A89 File Offset: 0x00000C89
		public bool MigItems { get; set; } = true;

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000AF RID: 175 RVA: 0x00002A92 File Offset: 0x00000C92
		// (set) Token: 0x060000B0 RID: 176 RVA: 0x00002A9A File Offset: 0x00000C9A
		public bool TransferComplete { get; set; } = true;

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x00002AA3 File Offset: 0x00000CA3
		// (set) Token: 0x060000B2 RID: 178 RVA: 0x00002AAB File Offset: 0x00000CAB
		public InteractiveCustomizationPolicyData Customization { get; set; } = new InteractiveCustomizationPolicyData();
	}
}
