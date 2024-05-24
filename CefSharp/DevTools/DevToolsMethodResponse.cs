using System;

namespace CefSharp.DevTools
{
	// Token: 0x02000123 RID: 291
	public class DevToolsMethodResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000262 RID: 610
		// (get) Token: 0x0600087E RID: 2174 RVA: 0x0000DB30 File Offset: 0x0000BD30
		// (set) Token: 0x0600087F RID: 2175 RVA: 0x0000DB38 File Offset: 0x0000BD38
		public int MessageId { get; set; }

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000880 RID: 2176 RVA: 0x0000DB41 File Offset: 0x0000BD41
		// (set) Token: 0x06000881 RID: 2177 RVA: 0x0000DB49 File Offset: 0x0000BD49
		public bool Success { get; set; }

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000882 RID: 2178 RVA: 0x0000DB52 File Offset: 0x0000BD52
		// (set) Token: 0x06000883 RID: 2179 RVA: 0x0000DB5A File Offset: 0x0000BD5A
		public string ResponseAsJsonString { get; set; }
	}
}
