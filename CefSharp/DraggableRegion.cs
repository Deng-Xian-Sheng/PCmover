using System;

namespace CefSharp
{
	// Token: 0x02000094 RID: 148
	public struct DraggableRegion
	{
		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000448 RID: 1096 RVA: 0x00006C42 File Offset: 0x00004E42
		// (set) Token: 0x06000449 RID: 1097 RVA: 0x00006C4A File Offset: 0x00004E4A
		public int Width { get; private set; }

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x0600044A RID: 1098 RVA: 0x00006C53 File Offset: 0x00004E53
		// (set) Token: 0x0600044B RID: 1099 RVA: 0x00006C5B File Offset: 0x00004E5B
		public int Height { get; private set; }

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x0600044C RID: 1100 RVA: 0x00006C64 File Offset: 0x00004E64
		// (set) Token: 0x0600044D RID: 1101 RVA: 0x00006C6C File Offset: 0x00004E6C
		public int X { get; private set; }

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x0600044E RID: 1102 RVA: 0x00006C75 File Offset: 0x00004E75
		// (set) Token: 0x0600044F RID: 1103 RVA: 0x00006C7D File Offset: 0x00004E7D
		public int Y { get; private set; }

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06000450 RID: 1104 RVA: 0x00006C86 File Offset: 0x00004E86
		// (set) Token: 0x06000451 RID: 1105 RVA: 0x00006C8E File Offset: 0x00004E8E
		public bool Draggable { get; private set; }

		// Token: 0x06000452 RID: 1106 RVA: 0x00006C97 File Offset: 0x00004E97
		public DraggableRegion(int width, int height, int x, int y, bool draggable)
		{
			this = default(DraggableRegion);
			this.Width = width;
			this.Height = height;
			this.X = x;
			this.Y = y;
			this.Draggable = draggable;
		}
	}
}
