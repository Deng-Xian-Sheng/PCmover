using System;

namespace CefSharp
{
	// Token: 0x02000005 RID: 5
	public interface IBeforeDownloadCallback : IDisposable
	{
		// Token: 0x06000012 RID: 18
		void Continue(string downloadPath, bool showDialog);

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000013 RID: 19
		bool IsDisposed { get; }
	}
}
