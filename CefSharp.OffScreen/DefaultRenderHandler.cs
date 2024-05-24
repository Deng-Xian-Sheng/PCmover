using System;
using System.Drawing;
using CefSharp.Enums;
using CefSharp.Structs;

namespace CefSharp.OffScreen
{
	// Token: 0x02000005 RID: 5
	public class DefaultRenderHandler : IRenderHandler, IDisposable
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600009F RID: 159 RVA: 0x0000366E File Offset: 0x0000186E
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x00003676 File Offset: 0x00001876
		public bool PopupOpen { get; protected set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x0000367F File Offset: 0x0000187F
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x00003687 File Offset: 0x00001887
		public BitmapBuffer BitmapBuffer { get; private set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x00003690 File Offset: 0x00001890
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x00003698 File Offset: 0x00001898
		public BitmapBuffer PopupBuffer { get; private set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x000036A1 File Offset: 0x000018A1
		public System.Drawing.Size PopupSize
		{
			get
			{
				return this.popupSize;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x000036A9 File Offset: 0x000018A9
		public System.Drawing.Point PopupPosition
		{
			get
			{
				return this.popupPosition;
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000036B4 File Offset: 0x000018B4
		public DefaultRenderHandler(ChromiumWebBrowser browser)
		{
			this.browser = browser;
			this.popupPosition = default(System.Drawing.Point);
			this.popupSize = default(System.Drawing.Size);
			this.BitmapBuffer = new BitmapBuffer(this.BitmapLock);
			this.PopupBuffer = new BitmapBuffer(this.BitmapLock);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003713 File Offset: 0x00001913
		public void Dispose()
		{
			this.browser = null;
			this.BitmapBuffer = null;
			this.PopupBuffer = null;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000372C File Offset: 0x0000192C
		public virtual ScreenInfo? GetScreenInfo()
		{
			ScreenInfo value = new ScreenInfo
			{
				DeviceScaleFactor = this.browser.DeviceScaleFactor
			};
			return new ScreenInfo?(value);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000375C File Offset: 0x0000195C
		public virtual Rect GetViewRect()
		{
			System.Drawing.Size size = this.browser.Size;
			Rect result = new Rect(0, 0, size.Width, size.Height);
			return result;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000378D File Offset: 0x0000198D
		public virtual bool GetScreenPoint(int viewX, int viewY, out int screenX, out int screenY)
		{
			screenX = viewX;
			screenY = viewY;
			return false;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00003797 File Offset: 0x00001997
		public virtual void OnAcceleratedPaint(PaintElementType type, Rect dirtyRect, IntPtr sharedHandle)
		{
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000379C File Offset: 0x0000199C
		public virtual void OnPaint(PaintElementType type, Rect dirtyRect, IntPtr buffer, int width, int height)
		{
			BitmapBuffer bitmapBuffer = (type == PaintElementType.Popup) ? this.PopupBuffer : this.BitmapBuffer;
			bitmapBuffer.UpdateBuffer(width, height, buffer, dirtyRect);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000037CC File Offset: 0x000019CC
		public virtual void OnCursorChange(IntPtr cursor, CursorType type, CursorInfo customCursorInfo)
		{
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000037CE File Offset: 0x000019CE
		public virtual bool StartDragging(IDragData dragData, DragOperationsMask mask, int x, int y)
		{
			return false;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000037D1 File Offset: 0x000019D1
		public virtual void UpdateDragCursor(DragOperationsMask operation)
		{
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000037D3 File Offset: 0x000019D3
		public virtual void OnPopupShow(bool show)
		{
			this.PopupOpen = show;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000037DC File Offset: 0x000019DC
		public virtual void OnPopupSize(Rect rect)
		{
			this.popupPosition.X = rect.X;
			this.popupPosition.Y = rect.Y;
			this.popupSize.Width = rect.Width;
			this.popupSize.Height = rect.Height;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00003831 File Offset: 0x00001A31
		public virtual void OnImeCompositionRangeChanged(Range selectedRange, Rect[] characterBounds)
		{
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00003833 File Offset: 0x00001A33
		public virtual void OnVirtualKeyboardRequested(IBrowser browser, TextInputMode inputMode)
		{
		}

		// Token: 0x0400003D RID: 61
		private ChromiumWebBrowser browser;

		// Token: 0x0400003E RID: 62
		private System.Drawing.Size popupSize;

		// Token: 0x0400003F RID: 63
		private System.Drawing.Point popupPosition;

		// Token: 0x04000040 RID: 64
		public readonly object BitmapLock = new object();
	}
}
