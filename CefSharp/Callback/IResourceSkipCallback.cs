using System;

namespace CefSharp.Callback
{
	// Token: 0x02000453 RID: 1107
	public interface IResourceSkipCallback : IDisposable
	{
		// Token: 0x0600200E RID: 8206
		void Continue(long bytesSkipped);

		// Token: 0x17000BBE RID: 3006
		// (get) Token: 0x0600200F RID: 8207
		bool IsDisposed { get; }
	}
}
