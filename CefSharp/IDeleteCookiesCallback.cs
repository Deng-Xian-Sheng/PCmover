using System;

namespace CefSharp
{
	// Token: 0x02000008 RID: 8
	public interface IDeleteCookiesCallback : IDisposable
	{
		// Token: 0x06000019 RID: 25
		void OnComplete(int numDeleted);

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001A RID: 26
		bool IsDisposed { get; }
	}
}
