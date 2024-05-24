using System;
using System.Collections.Generic;

namespace CefSharp.Handler
{
	// Token: 0x020000FB RID: 251
	public class DialogHandler : IDialogHandler
	{
		// Token: 0x0600075F RID: 1887 RVA: 0x0000C230 File Offset: 0x0000A430
		bool IDialogHandler.OnFileDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, CefFileDialogMode mode, CefFileDialogFlags flags, string title, string defaultFilePath, List<string> acceptFilters, int selectedAcceptFilter, IFileDialogCallback callback)
		{
			return this.OnFileDialog(chromiumWebBrowser, browser, mode, flags, title, defaultFilePath, acceptFilters, selectedAcceptFilter, callback);
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x0000C252 File Offset: 0x0000A452
		protected virtual bool OnFileDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, CefFileDialogMode mode, CefFileDialogFlags flags, string title, string defaultFilePath, List<string> acceptFilters, int selectedAcceptFilter, IFileDialogCallback callback)
		{
			return false;
		}
	}
}
