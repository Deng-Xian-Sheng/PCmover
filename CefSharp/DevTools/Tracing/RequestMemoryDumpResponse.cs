using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Tracing
{
	// Token: 0x020001D7 RID: 471
	[DataContract]
	public class RequestMemoryDumpResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x06000D99 RID: 3481 RVA: 0x00012A42 File Offset: 0x00010C42
		// (set) Token: 0x06000D9A RID: 3482 RVA: 0x00012A4A File Offset: 0x00010C4A
		[DataMember]
		internal string dumpGuid { get; set; }

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x06000D9B RID: 3483 RVA: 0x00012A53 File Offset: 0x00010C53
		public string DumpGuid
		{
			get
			{
				return this.dumpGuid;
			}
		}

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x06000D9C RID: 3484 RVA: 0x00012A5B File Offset: 0x00010C5B
		// (set) Token: 0x06000D9D RID: 3485 RVA: 0x00012A63 File Offset: 0x00010C63
		[DataMember]
		internal bool success { get; set; }

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x06000D9E RID: 3486 RVA: 0x00012A6C File Offset: 0x00010C6C
		public bool Success
		{
			get
			{
				return this.success;
			}
		}
	}
}
