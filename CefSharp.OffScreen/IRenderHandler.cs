using System;
using CefSharp.Enums;
using CefSharp.Structs;

namespace CefSharp.OffScreen
{
	// Token: 0x02000006 RID: 6
	public interface IRenderHandler : IDisposable
	{
		// Token: 0x060000B5 RID: 181
		ScreenInfo? GetScreenInfo();

		// Token: 0x060000B6 RID: 182
		Rect GetViewRect();

		// Token: 0x060000B7 RID: 183
		bool GetScreenPoint(int viewX, int viewY, out int screenX, out int screenY);

		// Token: 0x060000B8 RID: 184
		void OnAcceleratedPaint(PaintElementType type, Rect dirtyRect, IntPtr sharedHandle);

		// Token: 0x060000B9 RID: 185
		void OnPaint(PaintElementType type, Rect dirtyRect, IntPtr buffer, int width, int height);

		// Token: 0x060000BA RID: 186
		void OnCursorChange(IntPtr cursor, CursorType type, CursorInfo customCursorInfo);

		// Token: 0x060000BB RID: 187
		bool StartDragging(IDragData dragData, DragOperationsMask mask, int x, int y);

		// Token: 0x060000BC RID: 188
		void UpdateDragCursor(DragOperationsMask operation);

		// Token: 0x060000BD RID: 189
		void OnPopupShow(bool show);

		// Token: 0x060000BE RID: 190
		void OnPopupSize(Rect rect);

		// Token: 0x060000BF RID: 191
		void OnImeCompositionRangeChanged(Range selectedRange, Rect[] characterBounds);

		// Token: 0x060000C0 RID: 192
		void OnVirtualKeyboardRequested(IBrowser browser, TextInputMode inputMode);
	}
}
