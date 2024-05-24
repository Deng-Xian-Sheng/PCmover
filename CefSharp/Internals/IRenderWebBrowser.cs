using System;
using CefSharp.Enums;
using CefSharp.Structs;

namespace CefSharp.Internals
{
	// Token: 0x020000D5 RID: 213
	public interface IRenderWebBrowser : IWebBrowserInternal, IWebBrowser, IChromiumWebBrowserBase, IDisposable
	{
		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000629 RID: 1577
		// (set) Token: 0x0600062A RID: 1578
		IAccessibilityHandler AccessibilityHandler { get; set; }

		// Token: 0x0600062B RID: 1579
		ScreenInfo? GetScreenInfo();

		// Token: 0x0600062C RID: 1580
		Rect GetViewRect();

		// Token: 0x0600062D RID: 1581
		bool GetScreenPoint(int viewX, int viewY, out int screenX, out int screenY);

		// Token: 0x0600062E RID: 1582
		void OnAcceleratedPaint(PaintElementType type, Rect dirtyRect, IntPtr sharedHandle);

		// Token: 0x0600062F RID: 1583
		void OnPaint(PaintElementType type, Rect dirtyRect, IntPtr buffer, int width, int height);

		// Token: 0x06000630 RID: 1584
		void OnCursorChange(IntPtr cursor, CursorType type, CursorInfo customCursorInfo);

		// Token: 0x06000631 RID: 1585
		bool StartDragging(IDragData dragData, DragOperationsMask mask, int x, int y);

		// Token: 0x06000632 RID: 1586
		void UpdateDragCursor(DragOperationsMask operation);

		// Token: 0x06000633 RID: 1587
		void OnPopupShow(bool show);

		// Token: 0x06000634 RID: 1588
		void OnPopupSize(Rect rect);

		// Token: 0x06000635 RID: 1589
		void OnImeCompositionRangeChanged(Range selectedRange, Rect[] characterBounds);

		// Token: 0x06000636 RID: 1590
		void OnVirtualKeyboardRequested(IBrowser browser, TextInputMode inputMode);
	}
}
