using System;

namespace IntelEMA
{
	// Token: 0x02000010 RID: 16
	public class AuthResult
	{
		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00002652 File Offset: 0x00000852
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x0000265A File Offset: 0x0000085A
		public string access_token { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x00002663 File Offset: 0x00000863
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x0000266B File Offset: 0x0000086B
		public string token_type { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00002674 File Offset: 0x00000874
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x0000267C File Offset: 0x0000087C
		public int expires_in { get; set; }
	}
}
