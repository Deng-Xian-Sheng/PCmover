using System;

namespace CefSharp.Event
{
	// Token: 0x0200010B RID: 267
	public class JavascriptBindingEventArgs : EventArgs
	{
		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06000803 RID: 2051 RVA: 0x0000C95F File Offset: 0x0000AB5F
		// (set) Token: 0x06000804 RID: 2052 RVA: 0x0000C967 File Offset: 0x0000AB67
		public IJavascriptObjectRepository ObjectRepository { get; private set; }

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06000805 RID: 2053 RVA: 0x0000C970 File Offset: 0x0000AB70
		// (set) Token: 0x06000806 RID: 2054 RVA: 0x0000C978 File Offset: 0x0000AB78
		public string ObjectName { get; private set; }

		// Token: 0x06000807 RID: 2055 RVA: 0x0000C981 File Offset: 0x0000AB81
		public JavascriptBindingEventArgs(IJavascriptObjectRepository objectRepository, string name)
		{
			this.ObjectRepository = objectRepository;
			this.ObjectName = name;
		}
	}
}
