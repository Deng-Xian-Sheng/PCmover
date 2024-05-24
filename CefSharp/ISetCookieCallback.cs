using System;

namespace CefSharp
{
	// Token: 0x02000013 RID: 19
	public interface ISetCookieCallback : IDisposable
	{
		// Token: 0x06000039 RID: 57
		void OnComplete(bool success);

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600003A RID: 58
		bool IsDisposed { get; }
	}
}
