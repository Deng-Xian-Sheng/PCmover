using System;
using System.Collections.Generic;

namespace CefSharp.Event
{
	// Token: 0x0200010C RID: 268
	public class JavascriptBindingMultipleCompleteEventArgs : EventArgs
	{
		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06000808 RID: 2056 RVA: 0x0000C997 File Offset: 0x0000AB97
		// (set) Token: 0x06000809 RID: 2057 RVA: 0x0000C99F File Offset: 0x0000AB9F
		public IJavascriptObjectRepository ObjectRepository { get; private set; }

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x0600080A RID: 2058 RVA: 0x0000C9A8 File Offset: 0x0000ABA8
		// (set) Token: 0x0600080B RID: 2059 RVA: 0x0000C9B0 File Offset: 0x0000ABB0
		public IList<string> ObjectNames { get; private set; }

		// Token: 0x0600080C RID: 2060 RVA: 0x0000C9B9 File Offset: 0x0000ABB9
		public JavascriptBindingMultipleCompleteEventArgs(IJavascriptObjectRepository objectRepository, IList<string> names)
		{
			this.ObjectRepository = objectRepository;
			this.ObjectNames = names;
		}
	}
}
