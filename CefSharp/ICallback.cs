using System;

namespace CefSharp
{
	// Token: 0x02000006 RID: 6
	public interface ICallback : IDisposable
	{
		// Token: 0x06000014 RID: 20
		void Continue();

		// Token: 0x06000015 RID: 21
		void Cancel();

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000016 RID: 22
		bool IsDisposed { get; }
	}
}
