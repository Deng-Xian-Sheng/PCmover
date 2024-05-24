using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000016 RID: 22
	public class FileConnectionPolicyData
	{
		// Token: 0x0600007E RID: 126 RVA: 0x000028B1 File Offset: 0x00000AB1
		public FileConnectionPolicyData()
		{
			this.VanPassword = new VanPasswordPolicyData();
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600007F RID: 127 RVA: 0x000028C4 File Offset: 0x00000AC4
		// (set) Token: 0x06000080 RID: 128 RVA: 0x000028CC File Offset: 0x00000ACC
		public string Van { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000081 RID: 129 RVA: 0x000028D5 File Offset: 0x00000AD5
		// (set) Token: 0x06000082 RID: 130 RVA: 0x000028DD File Offset: 0x00000ADD
		public VanPasswordPolicyData VanPassword { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000083 RID: 131 RVA: 0x000028E6 File Offset: 0x00000AE6
		// (set) Token: 0x06000084 RID: 132 RVA: 0x000028EE File Offset: 0x00000AEE
		public bool? IsMachineOld { get; set; }
	}
}
