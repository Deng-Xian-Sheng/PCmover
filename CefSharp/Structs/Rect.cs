using System;
using System.Diagnostics;

namespace CefSharp.Structs
{
	// Token: 0x020000A8 RID: 168
	[DebuggerDisplay("X = {X}, Y = {Y}, Width = {Width}, Height = {Height}")]
	public struct Rect
	{
		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06000527 RID: 1319 RVA: 0x00008245 File Offset: 0x00006445
		// (set) Token: 0x06000528 RID: 1320 RVA: 0x0000824D File Offset: 0x0000644D
		public int X { get; private set; }

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000529 RID: 1321 RVA: 0x00008256 File Offset: 0x00006456
		// (set) Token: 0x0600052A RID: 1322 RVA: 0x0000825E File Offset: 0x0000645E
		public int Y { get; private set; }

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x0600052B RID: 1323 RVA: 0x00008267 File Offset: 0x00006467
		// (set) Token: 0x0600052C RID: 1324 RVA: 0x0000826F File Offset: 0x0000646F
		public int Width { get; private set; }

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x0600052D RID: 1325 RVA: 0x00008278 File Offset: 0x00006478
		// (set) Token: 0x0600052E RID: 1326 RVA: 0x00008280 File Offset: 0x00006480
		public int Height { get; private set; }

		// Token: 0x0600052F RID: 1327 RVA: 0x00008289 File Offset: 0x00006489
		public Rect(int x, int y, int width, int height)
		{
			this = default(Rect);
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x000082B0 File Offset: 0x000064B0
		public Rect ScaleByDpi(float dpi)
		{
			int x = (int)Math.Ceiling((double)((float)this.X / dpi));
			int y = (int)Math.Ceiling((double)((float)this.Y / dpi));
			int width = (int)Math.Ceiling((double)((float)this.Width / dpi));
			int height = (int)Math.Ceiling((double)((float)this.Height / dpi));
			return new Rect(x, y, width, height);
		}
	}
}
