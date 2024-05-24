using System;

namespace CefSharp
{
	// Token: 0x02000011 RID: 17
	public interface IRunContextMenuCallback : IDisposable
	{
		// Token: 0x06000034 RID: 52
		void Continue(CefMenuCommand commandId, CefEventFlags eventFlags);

		// Token: 0x06000035 RID: 53
		void Cancel();

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000036 RID: 54
		bool IsDisposed { get; }
	}
}
