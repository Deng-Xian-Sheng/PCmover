using System;

namespace ControlzEx.Standard
{
	// Token: 0x0200006F RID: 111
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[Serializable]
	public struct POINT
	{
		// Token: 0x0600018F RID: 399 RVA: 0x0000891A File Offset: 0x00006B1A
		public POINT(int x, int y)
		{
			this._x = x;
			this._y = y;
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000190 RID: 400 RVA: 0x0000892A File Offset: 0x00006B2A
		// (set) Token: 0x06000191 RID: 401 RVA: 0x00008932 File Offset: 0x00006B32
		public int X
		{
			get
			{
				return this._x;
			}
			set
			{
				this._x = value;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000192 RID: 402 RVA: 0x0000893B File Offset: 0x00006B3B
		// (set) Token: 0x06000193 RID: 403 RVA: 0x00008943 File Offset: 0x00006B43
		public int Y
		{
			get
			{
				return this._y;
			}
			set
			{
				this._y = value;
			}
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0000894C File Offset: 0x00006B4C
		public override bool Equals(object obj)
		{
			if (obj is POINT)
			{
				POINT point = (POINT)obj;
				return point._x == this._x && point._y == this._y;
			}
			return base.Equals(obj);
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00008998 File Offset: 0x00006B98
		public override int GetHashCode()
		{
			return this._x.GetHashCode() ^ this._y.GetHashCode();
		}

		// Token: 0x06000196 RID: 406 RVA: 0x000089B1 File Offset: 0x00006BB1
		public static bool operator ==(POINT a, POINT b)
		{
			return a._x == b._x && a._y == b._y;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x000089D1 File Offset: 0x00006BD1
		public static bool operator !=(POINT a, POINT b)
		{
			return !(a == b);
		}

		// Token: 0x04000580 RID: 1408
		private int _x;

		// Token: 0x04000581 RID: 1409
		private int _y;
	}
}
