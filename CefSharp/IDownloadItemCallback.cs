using System;

namespace CefSharp
{
	// Token: 0x02000009 RID: 9
	public interface IDownloadItemCallback : IDisposable
	{
		// Token: 0x0600001B RID: 27
		void Cancel();

		// Token: 0x0600001C RID: 28
		void Pause();

		// Token: 0x0600001D RID: 29
		void Resume();

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001E RID: 30
		bool IsDisposed { get; }
	}
}
