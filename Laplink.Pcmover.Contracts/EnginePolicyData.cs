using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000014 RID: 20
	public class EnginePolicyData
	{
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600006E RID: 110 RVA: 0x0000282B File Offset: 0x00000A2B
		// (set) Token: 0x0600006F RID: 111 RVA: 0x00002833 File Offset: 0x00000A33
		public uint OemId { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000070 RID: 112 RVA: 0x0000283C File Offset: 0x00000A3C
		// (set) Token: 0x06000071 RID: 113 RVA: 0x00002844 File Offset: 0x00000A44
		public bool VerifyOemOnOld { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000072 RID: 114 RVA: 0x0000284D File Offset: 0x00000A4D
		// (set) Token: 0x06000073 RID: 115 RVA: 0x00002855 File Offset: 0x00000A55
		public bool VerifyOemOnNew { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000074 RID: 116 RVA: 0x0000285E File Offset: 0x00000A5E
		// (set) Token: 0x06000075 RID: 117 RVA: 0x00002866 File Offset: 0x00000A66
		public bool GetSerialNumberFromServer { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000076 RID: 118 RVA: 0x0000286F File Offset: 0x00000A6F
		// (set) Token: 0x06000077 RID: 119 RVA: 0x00002877 File Offset: 0x00000A77
		public bool RequireSerialNumber { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00002880 File Offset: 0x00000A80
		// (set) Token: 0x06000079 RID: 121 RVA: 0x00002888 File Offset: 0x00000A88
		public bool ValidateSerialNumber { get; set; }
	}
}
