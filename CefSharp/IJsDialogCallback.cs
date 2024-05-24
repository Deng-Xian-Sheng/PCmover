using System;

namespace CefSharp
{
	// Token: 0x0200000D RID: 13
	public interface IJsDialogCallback : IDisposable
	{
		// Token: 0x0600002A RID: 42
		void Continue(bool success, string userInput);

		// Token: 0x0600002B RID: 43
		void Continue(bool success);

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600002C RID: 44
		bool IsDisposed { get; }
	}
}
