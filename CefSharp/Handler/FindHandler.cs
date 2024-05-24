using System;
using CefSharp.Structs;

namespace CefSharp.Handler
{
	// Token: 0x02000100 RID: 256
	public class FindHandler : IFindHandler
	{
		// Token: 0x06000795 RID: 1941 RVA: 0x0000C3D9 File Offset: 0x0000A5D9
		void IFindHandler.OnFindResult(IWebBrowser chromiumWebBrowser, IBrowser browser, int identifier, int count, Rect selectionRect, int activeMatchOrdinal, bool finalUpdate)
		{
			this.OnFindResult(chromiumWebBrowser, browser, identifier, count, selectionRect, activeMatchOrdinal, finalUpdate);
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x0000C3EC File Offset: 0x0000A5EC
		protected virtual void OnFindResult(IWebBrowser chromiumWebBrowser, IBrowser browser, int identifier, int count, Rect selectionRect, int activeMatchOrdinal, bool finalUpdate)
		{
		}
	}
}
