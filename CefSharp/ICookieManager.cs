using System;

namespace CefSharp
{
	// Token: 0x02000069 RID: 105
	public interface ICookieManager : IDisposable
	{
		// Token: 0x06000239 RID: 569
		bool DeleteCookies(string url = null, string name = null, IDeleteCookiesCallback callback = null);

		// Token: 0x0600023A RID: 570
		bool SetCookie(string url, Cookie cookie, ISetCookieCallback callback = null);

		// Token: 0x0600023B RID: 571
		bool VisitAllCookies(ICookieVisitor visitor);

		// Token: 0x0600023C RID: 572
		bool VisitUrlCookies(string url, bool includeHttpOnly, ICookieVisitor visitor);

		// Token: 0x0600023D RID: 573
		bool FlushStore(ICompletionCallback callback);

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600023E RID: 574
		bool IsDisposed { get; }
	}
}
