using System;
using CefSharp.Structs;

namespace CefSharp.OffScreen
{
	// Token: 0x02000007 RID: 7
	public class OnPaintEventArgs : EventArgs
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x00003835 File Offset: 0x00001A35
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x0000383D File Offset: 0x00001A3D
		public bool Handled { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x00003846 File Offset: 0x00001A46
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x0000384E File Offset: 0x00001A4E
		public bool IsPopup { get; private set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x00003857 File Offset: 0x00001A57
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x0000385F File Offset: 0x00001A5F
		public int Width { get; private set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00003868 File Offset: 0x00001A68
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x00003870 File Offset: 0x00001A70
		public int Height { get; private set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00003879 File Offset: 0x00001A79
		// (set) Token: 0x060000CA RID: 202 RVA: 0x00003881 File Offset: 0x00001A81
		public IntPtr BufferHandle { get; private set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000CB RID: 203 RVA: 0x0000388A File Offset: 0x00001A8A
		// (set) Token: 0x060000CC RID: 204 RVA: 0x00003892 File Offset: 0x00001A92
		public Rect DirtyRect { get; private set; }

		// Token: 0x060000CD RID: 205 RVA: 0x0000389B File Offset: 0x00001A9B
		public OnPaintEventArgs(bool isPopup, Rect dirtyRect, IntPtr bufferHandle, int width, int height)
		{
			this.IsPopup = isPopup;
			this.DirtyRect = dirtyRect;
			this.BufferHandle = bufferHandle;
			this.Width = width;
			this.Height = height;
		}
	}
}
