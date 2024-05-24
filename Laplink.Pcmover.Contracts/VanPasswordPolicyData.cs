using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000017 RID: 23
	public class VanPasswordPolicyData
	{
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000085 RID: 133 RVA: 0x000028F7 File Offset: 0x00000AF7
		// (set) Token: 0x06000086 RID: 134 RVA: 0x000028FF File Offset: 0x00000AFF
		public bool CanModify { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00002908 File Offset: 0x00000B08
		// (set) Token: 0x06000088 RID: 136 RVA: 0x00002910 File Offset: 0x00000B10
		public bool IsRequired { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00002919 File Offset: 0x00000B19
		// (set) Token: 0x0600008A RID: 138 RVA: 0x00002921 File Offset: 0x00000B21
		public bool HasPassword { get; set; }
	}
}
