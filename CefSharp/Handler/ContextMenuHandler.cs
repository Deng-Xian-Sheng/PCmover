using System;

namespace CefSharp.Handler
{
	// Token: 0x020000F9 RID: 249
	public class ContextMenuHandler : IContextMenuHandler
	{
		// Token: 0x06000751 RID: 1873 RVA: 0x0000C1B3 File Offset: 0x0000A3B3
		void IContextMenuHandler.OnBeforeContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
		{
			this.OnBeforeContextMenu(chromiumWebBrowser, browser, frame, parameters, model);
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x0000C1C2 File Offset: 0x0000A3C2
		protected virtual void OnBeforeContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
		{
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x0000C1C4 File Offset: 0x0000A3C4
		bool IContextMenuHandler.OnContextMenuCommand(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
		{
			return this.OnContextMenuCommand(chromiumWebBrowser, browser, frame, parameters, commandId, eventFlags);
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x0000C1D5 File Offset: 0x0000A3D5
		protected virtual bool OnContextMenuCommand(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
		{
			return false;
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x0000C1D8 File Offset: 0x0000A3D8
		void IContextMenuHandler.OnContextMenuDismissed(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame)
		{
			this.OnContextMenuDismissed(chromiumWebBrowser, browser, frame);
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x0000C1E3 File Offset: 0x0000A3E3
		protected virtual void OnContextMenuDismissed(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame)
		{
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x0000C1E5 File Offset: 0x0000A3E5
		bool IContextMenuHandler.RunContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
		{
			return this.RunContextMenu(chromiumWebBrowser, browser, frame, parameters, model, callback);
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x0000C1F6 File Offset: 0x0000A3F6
		protected virtual bool RunContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
		{
			return false;
		}
	}
}
