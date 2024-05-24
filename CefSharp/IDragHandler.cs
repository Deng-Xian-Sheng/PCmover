using System;
using System.Collections.Generic;
using CefSharp.Enums;

namespace CefSharp
{
	// Token: 0x02000055 RID: 85
	public interface IDragHandler
	{
		// Token: 0x06000144 RID: 324
		bool OnDragEnter(IWebBrowser chromiumWebBrowser, IBrowser browser, IDragData dragData, DragOperationsMask mask);

		// Token: 0x06000145 RID: 325
		void OnDraggableRegionsChanged(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IList<DraggableRegion> regions);
	}
}
