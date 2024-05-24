using System;
using System.Collections.Generic;
using CefSharp.Enums;

namespace CefSharp.Handler
{
	// Token: 0x020000FE RID: 254
	public class DragHandler : IDragHandler
	{
		// Token: 0x0600077C RID: 1916 RVA: 0x0000C308 File Offset: 0x0000A508
		bool IDragHandler.OnDragEnter(IWebBrowser chromiumWebBrowser, IBrowser browser, IDragData dragData, DragOperationsMask mask)
		{
			return this.OnDragEnter(chromiumWebBrowser, browser, dragData, mask);
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x0000C315 File Offset: 0x0000A515
		protected virtual bool OnDragEnter(IWebBrowser chromiumWebBrowser, IBrowser browser, IDragData dragData, DragOperationsMask mask)
		{
			return false;
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x0000C318 File Offset: 0x0000A518
		void IDragHandler.OnDraggableRegionsChanged(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IList<DraggableRegion> regions)
		{
			this.OnDraggableRegionsChanged(chromiumWebBrowser, browser, frame, regions);
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x0000C325 File Offset: 0x0000A525
		protected virtual void OnDraggableRegionsChanged(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IList<DraggableRegion> regions)
		{
		}
	}
}
