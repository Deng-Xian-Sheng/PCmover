using System;

namespace CefSharp.Structs
{
	// Token: 0x020000A5 RID: 165
	public struct CursorInfo
	{
		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000514 RID: 1300 RVA: 0x00008177 File Offset: 0x00006377
		// (set) Token: 0x06000515 RID: 1301 RVA: 0x0000817F File Offset: 0x0000637F
		public IntPtr Buffer { get; set; }

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000516 RID: 1302 RVA: 0x00008188 File Offset: 0x00006388
		// (set) Token: 0x06000517 RID: 1303 RVA: 0x00008190 File Offset: 0x00006390
		public Point Hotspot { get; private set; }

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000518 RID: 1304 RVA: 0x00008199 File Offset: 0x00006399
		// (set) Token: 0x06000519 RID: 1305 RVA: 0x000081A1 File Offset: 0x000063A1
		public float ImageScaleFactor { get; private set; }

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x0600051A RID: 1306 RVA: 0x000081AA File Offset: 0x000063AA
		// (set) Token: 0x0600051B RID: 1307 RVA: 0x000081B2 File Offset: 0x000063B2
		public Size Size { get; private set; }

		// Token: 0x0600051C RID: 1308 RVA: 0x000081BB File Offset: 0x000063BB
		public CursorInfo(IntPtr buffer, Point hotspot, float imageScaleFactor, Size size)
		{
			this.Buffer = buffer;
			this.Hotspot = hotspot;
			this.ImageScaleFactor = imageScaleFactor;
			this.Size = size;
		}
	}
}
