using System;
using System.ComponentModel;

namespace Laplink.Pcmover.CloudAuthentication
{
	// Token: 0x0200000B RID: 11
	public class WebBrowserNavigateErrorEventArgs : CancelEventArgs
	{
		// Token: 0x0600004E RID: 78 RVA: 0x00002B01 File Offset: 0x00000D01
		public WebBrowserNavigateErrorEventArgs(string url, string targetFrameName, int statusCode, object webBrowserActiveXInstance)
		{
			this.Url = url;
			this.TargetFrameName = targetFrameName;
			this.StatusCode = statusCode;
			this.WebBrowserActiveXInstance = webBrowserActiveXInstance;
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00002B26 File Offset: 0x00000D26
		public string TargetFrameName { get; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00002B2E File Offset: 0x00000D2E
		public string Url { get; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002B36 File Offset: 0x00000D36
		public object WebBrowserActiveXInstance { get; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00002B3E File Offset: 0x00000D3E
		public int StatusCode { get; }
	}
}
