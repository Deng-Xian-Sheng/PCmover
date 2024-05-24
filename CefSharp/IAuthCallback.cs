using System;

namespace CefSharp
{
	// Token: 0x02000004 RID: 4
	public interface IAuthCallback : IDisposable
	{
		// Token: 0x0600000F RID: 15
		void Continue(string username, string password);

		// Token: 0x06000010 RID: 16
		void Cancel();

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000011 RID: 17
		bool IsDisposed { get; }
	}
}
