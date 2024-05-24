using System;
using CefSharp.Core;
using CefSharp.Internals;

namespace CefSharp
{
	// Token: 0x02000006 RID: 6
	public static class ManagedCefBrowserAdapter
	{
		// Token: 0x060000A4 RID: 164 RVA: 0x00002A6B File Offset: 0x00000C6B
		public static IBrowserAdapter Create(IWebBrowserInternal webBrowserInternal, bool offScreenRendering)
		{
			return new ManagedCefBrowserAdapter(webBrowserInternal, offScreenRendering);
		}
	}
}
