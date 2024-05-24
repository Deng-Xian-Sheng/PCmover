using System;
using System.Collections.Generic;

namespace CefSharp
{
	// Token: 0x02000052 RID: 82
	public interface IDialogHandler
	{
		// Token: 0x06000137 RID: 311
		bool OnFileDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, CefFileDialogMode mode, CefFileDialogFlags flags, string title, string defaultFilePath, List<string> acceptFilters, int selectedAcceptFilter, IFileDialogCallback callback);
	}
}
