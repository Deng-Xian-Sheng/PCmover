using System;

namespace CefSharp
{
	// Token: 0x02000096 RID: 150
	public struct MouseEvent
	{
		// Token: 0x1700017F RID: 383
		// (get) Token: 0x0600045F RID: 1119 RVA: 0x00006D2B File Offset: 0x00004F2B
		// (set) Token: 0x06000460 RID: 1120 RVA: 0x00006D33 File Offset: 0x00004F33
		public int X { get; private set; }

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000461 RID: 1121 RVA: 0x00006D3C File Offset: 0x00004F3C
		// (set) Token: 0x06000462 RID: 1122 RVA: 0x00006D44 File Offset: 0x00004F44
		public int Y { get; private set; }

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000463 RID: 1123 RVA: 0x00006D4D File Offset: 0x00004F4D
		// (set) Token: 0x06000464 RID: 1124 RVA: 0x00006D55 File Offset: 0x00004F55
		public CefEventFlags Modifiers { get; private set; }

		// Token: 0x06000465 RID: 1125 RVA: 0x00006D5E File Offset: 0x00004F5E
		public MouseEvent(int x, int y, CefEventFlags modifiers)
		{
			this = default(MouseEvent);
			this.X = x;
			this.Y = y;
			this.Modifiers = modifiers;
		}
	}
}
