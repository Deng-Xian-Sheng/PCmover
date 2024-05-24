using System;

namespace CefSharp
{
	// Token: 0x0200004C RID: 76
	public class TitleChangedEventArgs : EventArgs
	{
		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000123 RID: 291 RVA: 0x000035CA File Offset: 0x000017CA
		// (set) Token: 0x06000124 RID: 292 RVA: 0x000035D2 File Offset: 0x000017D2
		public IBrowser Browser { get; private set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000125 RID: 293 RVA: 0x000035DB File Offset: 0x000017DB
		// (set) Token: 0x06000126 RID: 294 RVA: 0x000035E3 File Offset: 0x000017E3
		public string Title { get; private set; }

		// Token: 0x06000127 RID: 295 RVA: 0x000035EC File Offset: 0x000017EC
		public TitleChangedEventArgs(IBrowser browser, string title)
		{
			this.Browser = browser;
			this.Title = title;
		}
	}
}
