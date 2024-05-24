using System;

namespace CefSharp
{
	// Token: 0x02000007 RID: 7
	public interface ICompletionCallback : IDisposable
	{
		// Token: 0x06000017 RID: 23
		void OnComplete();

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000018 RID: 24
		bool IsDisposed { get; }
	}
}
