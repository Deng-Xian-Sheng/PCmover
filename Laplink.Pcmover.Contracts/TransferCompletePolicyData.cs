using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000020 RID: 32
	public class TransferCompletePolicyData
	{
		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x00002A2C File Offset: 0x00000C2C
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x00002A34 File Offset: 0x00000C34
		public bool Reboot { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00002A3D File Offset: 0x00000C3D
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x00002A45 File Offset: 0x00000C45
		public bool UploadReport { get; set; }
	}
}
