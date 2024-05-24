using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x02000072 RID: 114
	[StructLayout(LayoutKind.Sequential)]
	internal class RefRECT
	{
		// Token: 0x060001B0 RID: 432 RVA: 0x00008D57 File Offset: 0x00006F57
		public RefRECT(int left, int top, int right, int bottom)
		{
			this._left = left;
			this._top = top;
			this._right = right;
			this._bottom = bottom;
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x00008D7C File Offset: 0x00006F7C
		public int Width
		{
			get
			{
				return this._right - this._left;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x00008D8B File Offset: 0x00006F8B
		public int Height
		{
			get
			{
				return this._bottom - this._top;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x00008D9A File Offset: 0x00006F9A
		// (set) Token: 0x060001B4 RID: 436 RVA: 0x00008DA2 File Offset: 0x00006FA2
		public int Left
		{
			get
			{
				return this._left;
			}
			set
			{
				this._left = value;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x00008DAB File Offset: 0x00006FAB
		// (set) Token: 0x060001B6 RID: 438 RVA: 0x00008DB3 File Offset: 0x00006FB3
		public int Right
		{
			get
			{
				return this._right;
			}
			set
			{
				this._right = value;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x00008DBC File Offset: 0x00006FBC
		// (set) Token: 0x060001B8 RID: 440 RVA: 0x00008DC4 File Offset: 0x00006FC4
		public int Top
		{
			get
			{
				return this._top;
			}
			set
			{
				this._top = value;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00008DCD File Offset: 0x00006FCD
		// (set) Token: 0x060001BA RID: 442 RVA: 0x00008DD5 File Offset: 0x00006FD5
		public int Bottom
		{
			get
			{
				return this._bottom;
			}
			set
			{
				this._bottom = value;
			}
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00008DDE File Offset: 0x00006FDE
		public void Offset(int dx, int dy)
		{
			this._left += dx;
			this._top += dy;
			this._right += dx;
			this._bottom += dy;
		}

		// Token: 0x04000589 RID: 1417
		private int _left;

		// Token: 0x0400058A RID: 1418
		private int _top;

		// Token: 0x0400058B RID: 1419
		private int _right;

		// Token: 0x0400058C RID: 1420
		private int _bottom;
	}
}
