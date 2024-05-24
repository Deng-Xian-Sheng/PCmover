using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200003A RID: 58
	public class EngineLogData
	{
		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000134 RID: 308 RVA: 0x00002F68 File Offset: 0x00001168
		// (set) Token: 0x06000135 RID: 309 RVA: 0x00002F70 File Offset: 0x00001170
		public SpInfoBox_Type Type { get; set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000136 RID: 310 RVA: 0x00002F79 File Offset: 0x00001179
		// (set) Token: 0x06000137 RID: 311 RVA: 0x00002F81 File Offset: 0x00001181
		public SpInfoBox_Method Method { get; set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000138 RID: 312 RVA: 0x00002F8A File Offset: 0x0000118A
		// (set) Token: 0x06000139 RID: 313 RVA: 0x00002F92 File Offset: 0x00001192
		public string FileName { get; set; }
	}
}
