using System;

namespace CefSharp.Event
{
	// Token: 0x0200010A RID: 266
	public class JavascriptBindingCompleteEventArgs : EventArgs
	{
		// Token: 0x17000223 RID: 547
		// (get) Token: 0x060007FA RID: 2042 RVA: 0x0000C8F6 File Offset: 0x0000AAF6
		// (set) Token: 0x060007FB RID: 2043 RVA: 0x0000C8FE File Offset: 0x0000AAFE
		public IJavascriptObjectRepository ObjectRepository { get; private set; }

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x060007FC RID: 2044 RVA: 0x0000C907 File Offset: 0x0000AB07
		// (set) Token: 0x060007FD RID: 2045 RVA: 0x0000C90F File Offset: 0x0000AB0F
		public string ObjectName { get; private set; }

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x060007FE RID: 2046 RVA: 0x0000C918 File Offset: 0x0000AB18
		// (set) Token: 0x060007FF RID: 2047 RVA: 0x0000C920 File Offset: 0x0000AB20
		public bool AlreadyBound { get; private set; }

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06000800 RID: 2048 RVA: 0x0000C929 File Offset: 0x0000AB29
		// (set) Token: 0x06000801 RID: 2049 RVA: 0x0000C931 File Offset: 0x0000AB31
		public bool IsCached { get; private set; }

		// Token: 0x06000802 RID: 2050 RVA: 0x0000C93A File Offset: 0x0000AB3A
		public JavascriptBindingCompleteEventArgs(IJavascriptObjectRepository objectRepository, string name, bool alreadyBound, bool isCached)
		{
			this.ObjectRepository = objectRepository;
			this.ObjectName = name;
			this.AlreadyBound = alreadyBound;
			this.IsCached = isCached;
		}
	}
}
