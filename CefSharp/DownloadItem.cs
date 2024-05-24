using System;

namespace CefSharp
{
	// Token: 0x02000022 RID: 34
	public sealed class DownloadItem
	{
		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00003120 File Offset: 0x00001320
		// (set) Token: 0x060000BB RID: 187 RVA: 0x00003128 File Offset: 0x00001328
		public bool IsValid { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00003131 File Offset: 0x00001331
		// (set) Token: 0x060000BD RID: 189 RVA: 0x00003139 File Offset: 0x00001339
		public bool IsInProgress { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00003142 File Offset: 0x00001342
		// (set) Token: 0x060000BF RID: 191 RVA: 0x0000314A File Offset: 0x0000134A
		public bool IsComplete { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00003153 File Offset: 0x00001353
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x0000315B File Offset: 0x0000135B
		public bool IsCancelled { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00003164 File Offset: 0x00001364
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x0000316C File Offset: 0x0000136C
		public long CurrentSpeed { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00003175 File Offset: 0x00001375
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x0000317D File Offset: 0x0000137D
		public int PercentComplete { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00003186 File Offset: 0x00001386
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x0000318E File Offset: 0x0000138E
		public long TotalBytes { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x00003197 File Offset: 0x00001397
		// (set) Token: 0x060000C9 RID: 201 RVA: 0x0000319F File Offset: 0x0000139F
		public long ReceivedBytes { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000CA RID: 202 RVA: 0x000031A8 File Offset: 0x000013A8
		// (set) Token: 0x060000CB RID: 203 RVA: 0x000031B0 File Offset: 0x000013B0
		public DateTime? StartTime { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000CC RID: 204 RVA: 0x000031B9 File Offset: 0x000013B9
		// (set) Token: 0x060000CD RID: 205 RVA: 0x000031C1 File Offset: 0x000013C1
		public DateTime? EndTime { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000CE RID: 206 RVA: 0x000031CA File Offset: 0x000013CA
		// (set) Token: 0x060000CF RID: 207 RVA: 0x000031D2 File Offset: 0x000013D2
		public string FullPath { get; set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x000031DB File Offset: 0x000013DB
		// (set) Token: 0x060000D1 RID: 209 RVA: 0x000031E3 File Offset: 0x000013E3
		public int Id { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x000031EC File Offset: 0x000013EC
		// (set) Token: 0x060000D3 RID: 211 RVA: 0x000031F4 File Offset: 0x000013F4
		public string Url { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x000031FD File Offset: 0x000013FD
		// (set) Token: 0x060000D5 RID: 213 RVA: 0x00003205 File Offset: 0x00001405
		public string OriginalUrl { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x0000320E File Offset: 0x0000140E
		// (set) Token: 0x060000D7 RID: 215 RVA: 0x00003216 File Offset: 0x00001416
		public string SuggestedFileName { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x0000321F File Offset: 0x0000141F
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x00003227 File Offset: 0x00001427
		public string ContentDisposition { get; set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00003230 File Offset: 0x00001430
		// (set) Token: 0x060000DB RID: 219 RVA: 0x00003238 File Offset: 0x00001438
		public string MimeType { get; set; }
	}
}
