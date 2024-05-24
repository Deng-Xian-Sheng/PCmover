using System;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000705 RID: 1797
	public class Border
	{
		// Token: 0x06004649 RID: 17993 RVA: 0x0023EB08 File Offset: 0x0023DB08
		internal Border(qy A_0)
		{
			this.h = A_0;
			this.d = new CellBorderStyle(this);
			this.e = new CellBorderStyle(this);
			this.f = new CellBorderStyle(this);
			this.g = new CellBorderStyle(this);
		}

		// Token: 0x0600464A RID: 17994 RVA: 0x0023EB70 File Offset: 0x0023DB70
		internal Border(Border A_0, Border A_1)
		{
			if (A_0.a == null)
			{
				this.a = A_1.a;
			}
			else
			{
				this.a = A_0.a;
			}
			if (A_0.b == null)
			{
				this.b = A_1.b;
			}
			else
			{
				this.b = A_0.b;
			}
			if (A_0.c == null)
			{
				this.c = A_1.c;
			}
			else
			{
				this.c = A_0.c;
			}
			if (A_0.d == null)
			{
				this.d = A_1.d;
			}
			else
			{
				this.d = new CellBorderStyle(A_0.d, A_1.d, this);
			}
			if (A_0.e == null)
			{
				this.e = A_1.e;
			}
			else
			{
				this.e = new CellBorderStyle(A_0.e, A_1.e, this);
			}
			if (A_0.f == null)
			{
				this.f = A_1.f;
			}
			else
			{
				this.f = new CellBorderStyle(A_0.f, A_1.f, this);
			}
			if (A_0.g == null)
			{
				this.g = A_1.g;
			}
			else
			{
				this.g = new CellBorderStyle(A_0.g, A_1.g, this);
			}
		}

		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x0600464B RID: 17995 RVA: 0x0023ED08 File Offset: 0x0023DD08
		// (set) Token: 0x0600464C RID: 17996 RVA: 0x0023ED20 File Offset: 0x0023DD20
		public float? Width
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
				this.d.Width = null;
				this.e.Width = null;
				this.f.Width = null;
				this.g.Width = null;
				this.h.a(true);
				this.h.c(true);
				this.h.a(null);
			}
		}

		// Token: 0x1700044B RID: 1099
		// (get) Token: 0x0600464D RID: 17997 RVA: 0x0023EDB0 File Offset: 0x0023DDB0
		// (set) Token: 0x0600464E RID: 17998 RVA: 0x0023EDC8 File Offset: 0x0023DDC8
		public Color Color
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
				this.d.Color = null;
				this.e.Color = null;
				this.f.Color = null;
				this.g.Color = null;
				this.h.a(null);
			}
		}

		// Token: 0x1700044C RID: 1100
		// (get) Token: 0x0600464F RID: 17999 RVA: 0x0023EE20 File Offset: 0x0023DE20
		// (set) Token: 0x06004650 RID: 18000 RVA: 0x0023EE38 File Offset: 0x0023DE38
		public LineStyle LineStyle
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
				this.d.LineStyle = null;
				this.e.LineStyle = null;
				this.f.LineStyle = null;
				this.g.LineStyle = null;
				this.h.a(null);
			}
		}

		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x06004651 RID: 18001 RVA: 0x0023EE90 File Offset: 0x0023DE90
		public CellBorderStyle Top
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06004652 RID: 18002 RVA: 0x0023EEA8 File Offset: 0x0023DEA8
		public CellBorderStyle Bottom
		{
			get
			{
				return this.e;
			}
		}

		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06004653 RID: 18003 RVA: 0x0023EEC0 File Offset: 0x0023DEC0
		public CellBorderStyle Left
		{
			get
			{
				return this.f;
			}
		}

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06004654 RID: 18004 RVA: 0x0023EED8 File Offset: 0x0023DED8
		public CellBorderStyle Right
		{
			get
			{
				return this.g;
			}
		}

		// Token: 0x06004655 RID: 18005 RVA: 0x0023EEF0 File Offset: 0x0023DEF0
		internal qy a()
		{
			return this.h;
		}

		// Token: 0x06004656 RID: 18006 RVA: 0x0023EF08 File Offset: 0x0023DF08
		internal bool b()
		{
			return (this.Top.Color == this.Bottom.Color && this.Bottom.Color == this.Left.Color && this.Left.Color == this.Right.Color) || (this.Top.Color != null && this.Top.Color.Equals(this.Bottom.Color) && this.Bottom.Color != null && this.Bottom.Color.Equals(this.Left.Color) && this.Left.Color != null && this.Left.Color.Equals(this.Right.Color));
		}

		// Token: 0x06004657 RID: 18007 RVA: 0x0023EFF8 File Offset: 0x0023DFF8
		internal bool c()
		{
			return this.Top.LineStyle == this.Bottom.LineStyle && this.Bottom.LineStyle == this.Left.LineStyle && this.Left.LineStyle == this.Right.LineStyle;
		}

		// Token: 0x06004658 RID: 18008 RVA: 0x0023F058 File Offset: 0x0023E058
		internal bool d()
		{
			float? width = this.Top.Width;
			float? width2 = this.Bottom.Width;
			if (width.GetValueOrDefault() == width2.GetValueOrDefault() && width != null == (width2 != null))
			{
				width = this.Bottom.Width;
				width2 = this.Left.Width;
				if (width.GetValueOrDefault() == width2.GetValueOrDefault() && width != null == (width2 != null))
				{
					width = this.Left.Width;
					width2 = this.Right.Width;
					if (width.GetValueOrDefault() == width2.GetValueOrDefault() && width != null == (width2 != null))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06004659 RID: 18009 RVA: 0x0023F134 File Offset: 0x0023E134
		internal Border a(bool A_0)
		{
			Border border = new Border(this.h);
			if (this.a == null && A_0)
			{
				border.a = new float?(1f);
			}
			else
			{
				border.a = this.a;
			}
			if (this.b == null && A_0)
			{
				border.b = Grayscale.Black;
			}
			else
			{
				border.b = this.b;
			}
			if (this.c == null && A_0)
			{
				border.c = LineStyle.Solid;
			}
			else
			{
				border.c = this.c;
			}
			border.d = this.d.a(border);
			border.e = this.e.a(border);
			border.f = this.f.a(border);
			border.g = this.g.a(border);
			return border;
		}

		// Token: 0x0600465A RID: 18010 RVA: 0x0023F22C File Offset: 0x0023E22C
		internal void a(Border A_0)
		{
			if (this.a == null)
			{
				this.a = A_0.a;
			}
			if (this.b == null)
			{
				this.b = A_0.b;
			}
			if (this.c == null)
			{
				this.c = A_0.c;
			}
			this.d.a(A_0.d);
			this.e.a(A_0.e);
			this.f.a(A_0.f);
			this.g.a(A_0.g);
		}

		// Token: 0x0600465B RID: 18011 RVA: 0x0023F2DC File Offset: 0x0023E2DC
		internal Border a(qy A_0)
		{
			Border border = new Border(A_0);
			border.a = this.a;
			border.b = this.b;
			border.c = this.c;
			border.d = this.d.a(border);
			border.e = this.e.a(border);
			border.f = this.f.a(border);
			border.g = this.g.a(border);
			return border;
		}

		// Token: 0x040026E0 RID: 9952
		private float? a = null;

		// Token: 0x040026E1 RID: 9953
		private Color b = null;

		// Token: 0x040026E2 RID: 9954
		private LineStyle c = null;

		// Token: 0x040026E3 RID: 9955
		private CellBorderStyle d;

		// Token: 0x040026E4 RID: 9956
		private CellBorderStyle e;

		// Token: 0x040026E5 RID: 9957
		private CellBorderStyle f;

		// Token: 0x040026E6 RID: 9958
		private CellBorderStyle g;

		// Token: 0x040026E7 RID: 9959
		private qy h;
	}
}
