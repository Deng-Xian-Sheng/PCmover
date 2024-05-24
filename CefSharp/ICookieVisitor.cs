using System;

namespace CefSharp
{
	// Token: 0x0200009A RID: 154
	public interface ICookieVisitor : IDisposable
	{
		// Token: 0x0600048B RID: 1163
		bool Visit(Cookie cookie, int count, int total, ref bool deleteCookie);
	}
}
