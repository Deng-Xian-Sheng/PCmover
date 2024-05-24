using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000385 RID: 901
	public class Line : TaggablePageElement
	{
		// Token: 0x0600265C RID: 9820 RVA: 0x00163C22 File Offset: 0x00162C22
		public Line(float x1, float y1, float x2, float y2) : this(x1, y1, x2, y2, 1f, Line.j, Line.k)
		{
		}

		// Token: 0x0600265D RID: 9821 RVA: 0x00163C41 File Offset: 0x00162C41
		public Line(float x1, float y1, float x2, float y2, float width) : this(x1, y1, x2, y2, width, Line.j, Line.k)
		{
		}

		// Token: 0x0600265E RID: 9822 RVA: 0x00163C5D File Offset: 0x00162C5D
		public Line(float x1, float y1, float x2, float y2, Color color) : this(x1, y1, x2, y2, 1f, color, Line.k)
		{
		}

		// Token: 0x0600265F RID: 9823 RVA: 0x00163C79 File Offset: 0x00162C79
		public Line(float x1, float y1, float x2, float y2, float width, Color color) : this(x1, y1, x2, y2, width, color, Line.k)
		{
		}

		// Token: 0x06002660 RID: 9824 RVA: 0x00163C94 File Offset: 0x00162C94
		public Line(float x1, float y1, float x2, float y2, float width, Color color, LineStyle style)
		{
			this.b = x1;
			this.c = x5.a(y1);
			this.d = x2;
			this.e = x5.a(y2);
			if (width <= 0f)
			{
				throw new GeneratorException("Line width must be set to a value greater than zero.");
			}
			this.f = width;
			this.g = color;
			this.h = style;
			this.i = LineCap.Butt;
			base.o();
		}

		// Token: 0x06002661 RID: 9825 RVA: 0x00163D14 File Offset: 0x00162D14
		internal Line(Line A_0, x5 A_1, x5 A_2)
		{
			this.b = A_0.b;
			this.c = A_1;
			this.d = A_0.d;
			this.e = A_2;
			this.f = A_0.f;
			this.g = A_0.g;
			this.h = A_0.h;
			this.i = A_0.i;
			base.o();
		}

		// Token: 0x06002662 RID: 9826 RVA: 0x00163D88 File Offset: 0x00162D88
		internal Line(Line A_0)
		{
			this.b = A_0.b;
			this.c = A_0.c;
			this.d = A_0.d;
			this.e = A_0.e;
			this.f = A_0.f;
			this.g = A_0.g;
			this.h = A_0.h;
			this.i = A_0.i;
			base.o();
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06002663 RID: 9827 RVA: 0x00163E08 File Offset: 0x00162E08
		// (set) Token: 0x06002664 RID: 9828 RVA: 0x00163E20 File Offset: 0x00162E20
		public LineStyle Style
		{
			get
			{
				return this.h;
			}
			set
			{
				this.h = value;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06002665 RID: 9829 RVA: 0x00163E2C File Offset: 0x00162E2C
		// (set) Token: 0x06002666 RID: 9830 RVA: 0x00163E44 File Offset: 0x00162E44
		public LineCap Cap
		{
			get
			{
				return this.i;
			}
			set
			{
				this.i = value;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06002667 RID: 9831 RVA: 0x00163E50 File Offset: 0x00162E50
		// (set) Token: 0x06002668 RID: 9832 RVA: 0x00163E68 File Offset: 0x00162E68
		public float Width
		{
			get
			{
				return this.f;
			}
			set
			{
				if (value <= 0f)
				{
					throw new GeneratorException("Line width must be set to a value greater than zero.");
				}
				this.f = value;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06002669 RID: 9833 RVA: 0x00163E94 File Offset: 0x00162E94
		// (set) Token: 0x0600266A RID: 9834 RVA: 0x00163EAC File Offset: 0x00162EAC
		public Color Color
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600266B RID: 9835 RVA: 0x00163EB8 File Offset: 0x00162EB8
		// (set) Token: 0x0600266C RID: 9836 RVA: 0x00163ED0 File Offset: 0x00162ED0
		public float X1
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600266D RID: 9837 RVA: 0x00163EDC File Offset: 0x00162EDC
		// (set) Token: 0x0600266E RID: 9838 RVA: 0x00163EFA File Offset: 0x00162EFA
		public float Y1
		{
			get
			{
				return x5.b(this.c);
			}
			set
			{
				this.c = x5.a(value);
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600266F RID: 9839 RVA: 0x00163F0C File Offset: 0x00162F0C
		// (set) Token: 0x06002670 RID: 9840 RVA: 0x00163F24 File Offset: 0x00162F24
		public float X2
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06002671 RID: 9841 RVA: 0x00163F30 File Offset: 0x00162F30
		// (set) Token: 0x06002672 RID: 9842 RVA: 0x00163F4E File Offset: 0x00162F4E
		public float Y2
		{
			get
			{
				return x5.b(this.e);
			}
			set
			{
				this.e = x5.a(value);
			}
		}

		// Token: 0x06002673 RID: 9843 RVA: 0x00163F60 File Offset: 0x00162F60
		internal x5 a()
		{
			return this.c;
		}

		// Token: 0x06002674 RID: 9844 RVA: 0x00163F78 File Offset: 0x00162F78
		internal void a(x5 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06002675 RID: 9845 RVA: 0x00163F84 File Offset: 0x00162F84
		internal x5 b()
		{
			return this.e;
		}

		// Token: 0x06002676 RID: 9846 RVA: 0x00163F9C File Offset: 0x00162F9C
		internal void b(x5 A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06002677 RID: 9847 RVA: 0x00163FA8 File Offset: 0x00162FA8
		public override void Draw(PageWriter writer)
		{
			base.Draw(writer);
			writer.SetGraphicsMode();
			if (writer.Document.Tag != null)
			{
				if (this.Tag == null)
				{
					this.Tag = new StructureElement(TagType.Figure, true);
					((StructureElement)this.Tag).Order = this.TagOrder;
				}
				this.Tag.e(writer, this);
			}
			writer.SetLineWidth(this.f);
			writer.SetStrokeColor(this.g);
			writer.SetLineStyle(this.h);
			writer.SetLineCap(this.i);
			if (this.h != LineStyle.None)
			{
				writer.Write_m_(this.b, x5.b(this.c));
				writer.Write_l_(this.d, x5.b(this.e));
				writer.Write_S();
			}
			if (writer.Document.Tag != null)
			{
				Tag.a(writer);
			}
		}

		// Token: 0x06002678 RID: 9848 RVA: 0x001640C0 File Offset: 0x001630C0
		internal override x5 b7()
		{
			x5 result;
			if (x5.d(this.c, this.e))
			{
				result = this.c;
			}
			else
			{
				result = this.e;
			}
			return result;
		}

		// Token: 0x06002679 RID: 9849 RVA: 0x001640FC File Offset: 0x001630FC
		internal override x5 b8()
		{
			x5 result;
			if (x5.c(this.c, this.e))
			{
				result = this.c;
			}
			else
			{
				result = this.e;
			}
			return result;
		}

		// Token: 0x0600267A RID: 9850 RVA: 0x00164138 File Offset: 0x00163138
		internal override byte cb()
		{
			return 54;
		}

		// Token: 0x040010B6 RID: 4278
		private new const float a = 1f;

		// Token: 0x040010B7 RID: 4279
		private float b;

		// Token: 0x040010B8 RID: 4280
		private x5 c;

		// Token: 0x040010B9 RID: 4281
		private new float d;

		// Token: 0x040010BA RID: 4282
		private x5 e;

		// Token: 0x040010BB RID: 4283
		private float f;

		// Token: 0x040010BC RID: 4284
		private Color g;

		// Token: 0x040010BD RID: 4285
		private LineStyle h;

		// Token: 0x040010BE RID: 4286
		private LineCap i;

		// Token: 0x040010BF RID: 4287
		private static Color j = Grayscale.Black;

		// Token: 0x040010C0 RID: 4288
		private static LineStyle k = LineStyle.Solid;
	}
}
