using System;

namespace CefSharp
{
	// Token: 0x0200004B RID: 75
	public class StatusMessageEventArgs : EventArgs
	{
		// Token: 0x0600011E RID: 286 RVA: 0x00003592 File Offset: 0x00001792
		public StatusMessageEventArgs(IBrowser browser, string value)
		{
			this.Browser = browser;
			this.Value = value;
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600011F RID: 287 RVA: 0x000035A8 File Offset: 0x000017A8
		// (set) Token: 0x06000120 RID: 288 RVA: 0x000035B0 File Offset: 0x000017B0
		public IBrowser Browser { get; private set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000121 RID: 289 RVA: 0x000035B9 File Offset: 0x000017B9
		// (set) Token: 0x06000122 RID: 290 RVA: 0x000035C1 File Offset: 0x000017C1
		public string Value { get; private set; }
	}
}
