using System;

namespace ControlzEx.Standard
{
	// Token: 0x02000071 RID: 113
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	public struct RECT
	{
		// Token: 0x06000199 RID: 409 RVA: 0x000089DD File Offset: 0x00006BDD
		public RECT(int left, int top, int right, int bottom)
		{
			this._left = left;
			this._top = top;
			this._right = right;
			this._bottom = bottom;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000089FC File Offset: 0x00006BFC
		public RECT(RECT rcSrc)
		{
			this._left = rcSrc.Left;
			this._top = rcSrc.Top;
			this._right = rcSrc.Right;
			this._bottom = rcSrc.Bottom;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00008A32 File Offset: 0x00006C32
		public void Offset(int dx, int dy)
		{
			this._left += dx;
			this._top += dy;
			this._right += dx;
			this._bottom += dy;
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600019C RID: 412 RVA: 0x00008A6C File Offset: 0x00006C6C
		// (set) Token: 0x0600019D RID: 413 RVA: 0x00008A74 File Offset: 0x00006C74
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

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600019E RID: 414 RVA: 0x00008A7D File Offset: 0x00006C7D
		// (set) Token: 0x0600019F RID: 415 RVA: 0x00008A85 File Offset: 0x00006C85
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

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x00008A8E File Offset: 0x00006C8E
		// (set) Token: 0x060001A1 RID: 417 RVA: 0x00008A96 File Offset: 0x00006C96
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

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x00008A9F File Offset: 0x00006C9F
		// (set) Token: 0x060001A3 RID: 419 RVA: 0x00008AA7 File Offset: 0x00006CA7
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

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x00008AB0 File Offset: 0x00006CB0
		public int Width
		{
			get
			{
				return this._right - this._left;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x00008ABF File Offset: 0x00006CBF
		public int Height
		{
			get
			{
				return this._bottom - this._top;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x00008AD0 File Offset: 0x00006CD0
		public POINT Position
		{
			get
			{
				return new POINT
				{
					X = this._left,
					Y = this._top
				};
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x00008B00 File Offset: 0x00006D00
		public SIZE Size
		{
			get
			{
				return new SIZE
				{
					cx = this.Width,
					cy = this.Height
				};
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00008B30 File Offset: 0x00006D30
		public static RECT Union(RECT rect1, RECT rect2)
		{
			return new RECT
			{
				Left = Math.Min(rect1.Left, rect2.Left),
				Top = Math.Min(rect1.Top, rect2.Top),
				Right = Math.Max(rect1.Right, rect2.Right),
				Bottom = Math.Max(rect1.Bottom, rect2.Bottom)
			};
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00008BB0 File Offset: 0x00006DB0
		public override bool Equals(object obj)
		{
			bool result;
			try
			{
				RECT rect = (RECT)obj;
				result = (rect._bottom == this._bottom && rect._left == this._left && rect._right == this._right && rect._top == this._top);
			}
			catch (InvalidCastException)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060001AA RID: 426 RVA: 0x00008C18 File Offset: 0x00006E18
		public bool IsEmpty
		{
			get
			{
				return this.Left >= this.Right || this.Top >= this.Bottom;
			}
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00008C3C File Offset: 0x00006E3C
		public override string ToString()
		{
			if (this == RECT.Empty)
			{
				return "RECT {Empty}";
			}
			return string.Concat(new object[]
			{
				"RECT { left : ",
				this.Left,
				" / top : ",
				this.Top,
				" / right : ",
				this.Right,
				" / bottom : ",
				this.Bottom,
				" }"
			});
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00008CCD File Offset: 0x00006ECD
		public override int GetHashCode()
		{
			return (this._left << 16 | Utility.LOWORD(this._right)) ^ (this._top << 16 | Utility.LOWORD(this._bottom));
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00008CFC File Offset: 0x00006EFC
		public static bool operator ==(RECT rect1, RECT rect2)
		{
			return rect1.Left == rect2.Left && rect1.Top == rect2.Top && rect1.Right == rect2.Right && rect1.Bottom == rect2.Bottom;
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00008D4B File Offset: 0x00006F4B
		public static bool operator !=(RECT rect1, RECT rect2)
		{
			return !(rect1 == rect2);
		}

		// Token: 0x04000584 RID: 1412
		private int _left;

		// Token: 0x04000585 RID: 1413
		private int _top;

		// Token: 0x04000586 RID: 1414
		private int _right;

		// Token: 0x04000587 RID: 1415
		private int _bottom;

		// Token: 0x04000588 RID: 1416
		public static readonly RECT Empty;
	}
}
