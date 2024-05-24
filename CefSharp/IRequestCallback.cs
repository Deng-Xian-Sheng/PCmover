using System;

namespace CefSharp
{
	// Token: 0x0200000F RID: 15
	public interface IRequestCallback : IDisposable
	{
		// Token: 0x0600002F RID: 47
		void Continue(bool allow);

		// Token: 0x06000030 RID: 48
		void Cancel();

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000031 RID: 49
		bool IsDisposed { get; }
	}
}
