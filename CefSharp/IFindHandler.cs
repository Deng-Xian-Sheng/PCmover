using System;
using CefSharp.Structs;

namespace CefSharp
{
	// Token: 0x02000057 RID: 87
	public interface IFindHandler
	{
		// Token: 0x0600014E RID: 334
		void OnFindResult(IWebBrowser chromiumWebBrowser, IBrowser browser, int identifier, int count, Rect selectionRect, int activeMatchOrdinal, bool finalUpdate);
	}
}
