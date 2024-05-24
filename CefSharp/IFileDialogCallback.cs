using System;
using System.Collections.Generic;

namespace CefSharp
{
	// Token: 0x0200000A RID: 10
	public interface IFileDialogCallback : IDisposable
	{
		// Token: 0x0600001F RID: 31
		void Continue(int selectedAcceptFilter, List<string> filePaths);

		// Token: 0x06000020 RID: 32
		void Cancel();

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000021 RID: 33
		bool IsDisposed { get; }
	}
}
