using System;

namespace CefSharp.Structs
{
	// Token: 0x020000A6 RID: 166
	public struct Point
	{
		// Token: 0x1700019F RID: 415
		// (get) Token: 0x0600051D RID: 1309 RVA: 0x000081DA File Offset: 0x000063DA
		// (set) Token: 0x0600051E RID: 1310 RVA: 0x000081E2 File Offset: 0x000063E2
		public int X { get; private set; }

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x0600051F RID: 1311 RVA: 0x000081EB File Offset: 0x000063EB
		// (set) Token: 0x06000520 RID: 1312 RVA: 0x000081F3 File Offset: 0x000063F3
		public int Y { get; private set; }

		// Token: 0x06000521 RID: 1313 RVA: 0x000081FC File Offset: 0x000063FC
		public Point(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}
	}
}
