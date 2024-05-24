using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000387 RID: 903
	public class Rectangle : RotatingPageElement, IArea, ICoordinate
	{
		// Token: 0x0600268C RID: 9868 RVA: 0x00164530 File Offset: 0x00163530
		public Rectangle(float x, float y, float width, float height) : this(x, y, width, height, Rectangle.i, Rectangle.h, 1f, Rectangle.j)
		{
		}

		// Token: 0x0600268D RID: 9869 RVA: 0x00164560 File Offset: 0x00163560
		public Rectangle(float x, float y, float width, float height, Color borderColor) : this(x, y, width, height, borderColor, Rectangle.h, 1f, Rectangle.j)
		{
		}

		// Token: 0x0600268E RID: 9870 RVA: 0x0016458C File Offset: 0x0016358C
		public Rectangle(float x, float y, float width, float height, float borderWidth) : this(x, y, width, height, Rectangle.i, Rectangle.h, borderWidth, Rectangle.j)
		{
		}

		// Token: 0x0600268F RID: 9871 RVA: 0x001645B8 File Offset: 0x001635B8
		public Rectangle(float x, float y, float width, float height, float borderWidth, Color fillColor) : this(x, y, width, height, Rectangle.i, fillColor, borderWidth, Rectangle.j)
		{
		}

		// Token: 0x06002690 RID: 9872 RVA: 0x001645E4 File Offset: 0x001635E4
		public Rectangle(float x, float y, float width, float height, Color borderColor, float borderWidth) : this(x, y, width, height, borderColor, Rectangle.h, borderWidth, Rectangle.j)
		{
		}

		// Token: 0x06002691 RID: 9873 RVA: 0x00164610 File Offset: 0x00163610
		public Rectangle(float x, float y, float width, float height, float borderWidth, LineStyle borderStyle) : this(x, y, width, height, Rectangle.i, Rectangle.h, borderWidth, borderStyle)
		{
		}

		// Token: 0x06002692 RID: 9874 RVA: 0x0016463C File Offset: 0x0016363C
		public Rectangle(float x, float y, float width, float height, Color borderColor, float borderWidth, LineStyle borderStyle) : this(x, y, width, height, borderColor, Rectangle.h, borderWidth, borderStyle)
		{
		}

		// Token: 0x06002693 RID: 9875 RVA: 0x00164664 File Offset: 0x00163664
		public Rectangle(float x, float y, float width, float height, Color borderColor, Color fillColor, float borderWidth) : this(x, y, width, height, borderColor, fillColor, borderWidth, Rectangle.j)
		{
		}

		// Token: 0x06002694 RID: 9876 RVA: 0x0016468C File Offset: 0x0016368C
		public Rectangle(float x, float y, float width, float height, Color borderColor, Color fillColor) : this(x, y, width, height, borderColor, fillColor, 1f, Rectangle.j)
		{
		}

		// Token: 0x06002695 RID: 9877 RVA: 0x001646B8 File Offset: 0x001636B8
		public Rectangle(float x, float y, float width, float height, Color borderColor, Color fillColor, float borderWidth, LineStyle borderStyle)
		{
			this.d = 0f;
			base..ctor(x, y, height);
			this.b = width;
			this.e = fillColor;
			this.f = borderColor;
			if (borderWidth <= 0f)
			{
				this.c = 0f;
			}
			this.c = borderWidth;
			this.g = borderStyle;
			base.o();
		}

		// Token: 0x06002696 RID: 9878 RVA: 0x00164724 File Offset: 0x00163724
		internal Rectangle(Rectangle A_0, x5 A_1, x5 A_2)
		{
			this.d = 0f;
			base..ctor(A_0.X, A_1, A_2, A_0.Angle);
			this.b = A_0.b;
			this.e = A_0.e;
			this.f = A_0.f;
			this.c = A_0.c;
			this.c = A_0.c;
			this.g = A_0.g;
			base.o();
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06002697 RID: 9879 RVA: 0x001647A4 File Offset: 0x001637A4
		// (set) Token: 0x06002698 RID: 9880 RVA: 0x001647BC File Offset: 0x001637BC
		public LineStyle BorderStyle
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

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06002699 RID: 9881 RVA: 0x001647C8 File Offset: 0x001637C8
		// (set) Token: 0x0600269A RID: 9882 RVA: 0x001647E0 File Offset: 0x001637E0
		public float CornerRadius
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

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600269B RID: 9883 RVA: 0x001647EC File Offset: 0x001637EC
		// (set) Token: 0x0600269C RID: 9884 RVA: 0x00164804 File Offset: 0x00163804
		public float BorderWidth
		{
			get
			{
				return this.c;
			}
			set
			{
				if (value <= 0f)
				{
					this.c = 0f;
				}
				else
				{
					this.c = value;
				}
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600269D RID: 9885 RVA: 0x00164834 File Offset: 0x00163834
		// (set) Token: 0x0600269E RID: 9886 RVA: 0x0016484C File Offset: 0x0016384C
		public Color BorderColor
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600269F RID: 9887 RVA: 0x00164858 File Offset: 0x00163858
		// (set) Token: 0x060026A0 RID: 9888 RVA: 0x00164870 File Offset: 0x00163870
		public Color FillColor
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060026A1 RID: 9889 RVA: 0x0016487C File Offset: 0x0016387C
		// (set) Token: 0x060026A2 RID: 9890 RVA: 0x00164894 File Offset: 0x00163894
		public float Width
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

		// Token: 0x060026A3 RID: 9891 RVA: 0x001648A0 File Offset: 0x001638A0
		protected override void DrawRotated(PageWriter writer)
		{
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
			bool flag = true;
			bool flag2;
			bool flag3;
			if (this.c > 0f && this.e != null)
			{
				writer.SetLineWidth(this.c);
				writer.SetStrokeColor(this.f);
				writer.SetLineStyle(this.g);
				writer.SetLineCap(LineCap.Butt);
				writer.SetFillColor(this.e);
				flag2 = true;
				flag3 = true;
			}
			else if (this.c > 0f)
			{
				writer.SetLineWidth(this.c);
				writer.SetStrokeColor(this.f);
				writer.SetLineStyle(this.g);
				writer.SetLineCap(LineCap.Butt);
				flag2 = true;
				flag3 = false;
			}
			else if (this.e != null)
			{
				writer.SetFillColor(this.e);
				flag3 = true;
				flag2 = false;
			}
			else
			{
				flag2 = false;
				flag3 = false;
				flag = false;
			}
			if (this.g == LineStyle.None)
			{
				flag2 = false;
			}
			if (flag)
			{
				if (this.d <= 0f)
				{
					writer.Write_re(this.X, this.Y, this.b, this.Height);
					if (flag3)
					{
						if (flag2)
						{
							writer.Write_B();
						}
						else
						{
							writer.Write_f();
						}
					}
					else
					{
						writer.Write_S();
					}
				}
				else
				{
					writer.Write_m_(this.X + this.b - this.d, this.Y);
					writer.Write_c(this.X + this.b - this.d * 0.447715f, this.Y, this.X + this.b, this.Y + this.d * 0.447715f, this.X + this.b, this.Y + this.d);
					writer.Write_l_(this.X + this.b, this.Y + this.Height - this.d);
					writer.Write_c(this.X + this.b, this.Y + this.Height - this.d * 0.447715f, this.X + this.b - this.d * 0.447715f, this.Y + this.Height, this.X + this.b - this.d, this.Y + this.Height);
					writer.Write_l_(this.X + this.d, this.Y + this.Height);
					writer.Write_c(this.X + this.d * 0.447715f, this.Y + this.Height, this.X, this.Y + this.Height - this.d * 0.447715f, this.X, this.Y + this.Height - this.d);
					writer.Write_l_(this.X, this.Y + this.d);
					writer.Write_c(this.X, this.Y + this.d * 0.447715f, this.X + this.d * 0.447715f, this.Y, this.X + this.d, this.Y);
					if (flag3)
					{
						if (flag2)
						{
							writer.Write_b_();
						}
						else
						{
							writer.Write_f();
						}
					}
					else
					{
						writer.Write_s_();
					}
				}
			}
			if (writer.Document.Tag != null)
			{
				Tag.a(writer);
			}
		}

		// Token: 0x060026A4 RID: 9892 RVA: 0x00164CC0 File Offset: 0x00163CC0
		internal override byte cb()
		{
			return 49;
		}

		// Token: 0x040010C3 RID: 4291
		private new const float a = 1f;

		// Token: 0x040010C4 RID: 4292
		private float b;

		// Token: 0x040010C5 RID: 4293
		private float c;

		// Token: 0x040010C6 RID: 4294
		private new float d;

		// Token: 0x040010C7 RID: 4295
		private Color e;

		// Token: 0x040010C8 RID: 4296
		private Color f;

		// Token: 0x040010C9 RID: 4297
		private LineStyle g;

		// Token: 0x040010CA RID: 4298
		private static Color h = null;

		// Token: 0x040010CB RID: 4299
		private static Color i = Grayscale.Black;

		// Token: 0x040010CC RID: 4300
		private static LineStyle j = LineStyle.Solid;
	}
}
