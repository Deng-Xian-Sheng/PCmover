using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000720 RID: 1824
	public class Circle : TaggablePageElement
	{
		// Token: 0x060048C0 RID: 18624 RVA: 0x002585D0 File Offset: 0x002575D0
		public Circle(float x, float y, float radius) : this(x, y, radius, radius, Circle.l, Circle.k, 1f, Circle.m)
		{
		}

		// Token: 0x060048C1 RID: 18625 RVA: 0x00258600 File Offset: 0x00257600
		public Circle(float x, float y, float radiusX, float radiusY) : this(x, y, radiusX, radiusY, Circle.l, Circle.k, 1f, Circle.m)
		{
		}

		// Token: 0x060048C2 RID: 18626 RVA: 0x00258630 File Offset: 0x00257630
		public Circle(float x, float y, float radius, Color borderColor) : this(x, y, radius, radius, borderColor, Circle.k, 1f, Circle.m)
		{
		}

		// Token: 0x060048C3 RID: 18627 RVA: 0x0025865C File Offset: 0x0025765C
		public Circle(float x, float y, float radius, float borderWidth, LineStyle borderStyle) : this(x, y, radius, radius, Circle.l, Circle.k, borderWidth, borderStyle)
		{
		}

		// Token: 0x060048C4 RID: 18628 RVA: 0x00258684 File Offset: 0x00257684
		public Circle(float x, float y, float radius, Color borderColor, float borderWidth, LineStyle borderStyle) : this(x, y, radius, radius, borderColor, Circle.k, borderWidth, borderStyle)
		{
		}

		// Token: 0x060048C5 RID: 18629 RVA: 0x002586AC File Offset: 0x002576AC
		public Circle(float x, float y, float radius, Color borderColor, Color fillColor) : this(x, y, radius, radius, borderColor, fillColor, 1f, Circle.m)
		{
		}

		// Token: 0x060048C6 RID: 18630 RVA: 0x002586D4 File Offset: 0x002576D4
		public Circle(float x, float y, float radius, Color borderColor, Color fillColor, float borderWidth) : this(x, y, radius, radius, borderColor, fillColor, borderWidth, Circle.m)
		{
		}

		// Token: 0x060048C7 RID: 18631 RVA: 0x002586FC File Offset: 0x002576FC
		public Circle(float x, float y, float radius, Color borderColor, Color fillColor, float borderWidth, LineStyle borderStyle) : this(x, y, radius, radius, borderColor, fillColor, borderWidth, borderStyle)
		{
		}

		// Token: 0x060048C8 RID: 18632 RVA: 0x00258720 File Offset: 0x00257720
		public Circle(float x, float y, float radiusX, float radiusY, Color borderColor, Color fillColor, float borderWidth, LineStyle borderStyle)
		{
			this.c = x;
			this.d = y;
			this.e = radiusX;
			this.f = radiusY;
			this.h = fillColor;
			this.i = borderColor;
			if (borderWidth <= 0f)
			{
				borderWidth = 0f;
			}
			this.g = borderWidth;
			this.j = borderStyle;
		}

		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x060048C9 RID: 18633 RVA: 0x00258788 File Offset: 0x00257788
		// (set) Token: 0x060048CA RID: 18634 RVA: 0x002587A0 File Offset: 0x002577A0
		public LineStyle BorderStyle
		{
			get
			{
				return this.j;
			}
			set
			{
				this.j = value;
			}
		}

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x060048CB RID: 18635 RVA: 0x002587AC File Offset: 0x002577AC
		// (set) Token: 0x060048CC RID: 18636 RVA: 0x002587C4 File Offset: 0x002577C4
		public float BorderWidth
		{
			get
			{
				return this.g;
			}
			set
			{
				if (value <= 0f)
				{
					this.g = 0f;
				}
				else
				{
					this.g = value;
				}
			}
		}

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x060048CD RID: 18637 RVA: 0x002587F4 File Offset: 0x002577F4
		// (set) Token: 0x060048CE RID: 18638 RVA: 0x0025880C File Offset: 0x0025780C
		public Color BorderColor
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

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x060048CF RID: 18639 RVA: 0x00258818 File Offset: 0x00257818
		// (set) Token: 0x060048D0 RID: 18640 RVA: 0x00258830 File Offset: 0x00257830
		public Color FillColor
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

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x060048D1 RID: 18641 RVA: 0x0025883C File Offset: 0x0025783C
		// (set) Token: 0x060048D2 RID: 18642 RVA: 0x00258854 File Offset: 0x00257854
		public float X
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x060048D3 RID: 18643 RVA: 0x00258860 File Offset: 0x00257860
		// (set) Token: 0x060048D4 RID: 18644 RVA: 0x00258878 File Offset: 0x00257878
		public float Y
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

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x060048D5 RID: 18645 RVA: 0x00258884 File Offset: 0x00257884
		// (set) Token: 0x060048D6 RID: 18646 RVA: 0x0025889C File Offset: 0x0025789C
		public float RadiusX
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

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x060048D7 RID: 18647 RVA: 0x002588A8 File Offset: 0x002578A8
		// (set) Token: 0x060048D8 RID: 18648 RVA: 0x002588C0 File Offset: 0x002578C0
		public float RadiusY
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

		// Token: 0x060048D9 RID: 18649 RVA: 0x002588CC File Offset: 0x002578CC
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
			bool flag = true;
			bool flag3;
			bool flag2;
			if (this.g > 0f && this.h != null)
			{
				writer.SetLineWidth(this.g);
				writer.SetStrokeColor(this.i);
				writer.SetLineStyle(this.j);
				writer.SetFillColor(this.h);
				flag2 = (flag3 = true);
			}
			else if (this.g > 0f)
			{
				writer.SetLineWidth(this.g);
				writer.SetStrokeColor(this.i);
				writer.SetLineStyle(this.j);
				flag2 = true;
				flag3 = false;
			}
			else if (this.h != null)
			{
				writer.SetFillColor(this.h);
				flag2 = false;
				flag3 = true;
			}
			else
			{
				flag2 = false;
				flag3 = false;
				flag = false;
			}
			if (this.j == LineStyle.None)
			{
				flag2 = false;
			}
			if (flag)
			{
				writer.Write_m_(this.c, this.d - this.f);
				writer.Write_c(this.c + this.e * 0.5522848f, this.d - this.f, this.c + this.e, this.d - this.f * 0.5522848f, this.c + this.e, this.d);
				writer.Write_c(this.c + this.e, this.d + this.f * 0.5522848f, this.c + this.e * 0.5522848f, this.d + this.f, this.c, this.d + this.f);
				writer.Write_c(this.c - this.e * 0.5522848f, this.d + this.f, this.c - this.e, this.d + this.f * 0.5522848f, this.c - this.e, this.d);
				writer.Write_c(this.c - this.e, this.d - this.f * 0.5522848f, this.c - this.e * 0.5522848f, this.d - this.f, this.c, this.d - this.f);
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
			if (writer.Document.Tag != null)
			{
				Tag.a(writer);
			}
		}

		// Token: 0x060048DA RID: 18650 RVA: 0x00258BFC File Offset: 0x00257BFC
		internal override x5 b7()
		{
			return new x5(this.d - this.f);
		}

		// Token: 0x060048DB RID: 18651 RVA: 0x00258C20 File Offset: 0x00257C20
		internal override x5 b8()
		{
			return new x5(this.d + this.f);
		}

		// Token: 0x060048DC RID: 18652 RVA: 0x00258C44 File Offset: 0x00257C44
		internal override byte cb()
		{
			return 56;
		}

		// Token: 0x040027BB RID: 10171
		private new const float a = 0.5522848f;

		// Token: 0x040027BC RID: 10172
		private const float b = 1f;

		// Token: 0x040027BD RID: 10173
		private float c;

		// Token: 0x040027BE RID: 10174
		private new float d;

		// Token: 0x040027BF RID: 10175
		private float e;

		// Token: 0x040027C0 RID: 10176
		private float f;

		// Token: 0x040027C1 RID: 10177
		private float g;

		// Token: 0x040027C2 RID: 10178
		private Color h;

		// Token: 0x040027C3 RID: 10179
		private Color i;

		// Token: 0x040027C4 RID: 10180
		private LineStyle j;

		// Token: 0x040027C5 RID: 10181
		private static Color k = null;

		// Token: 0x040027C6 RID: 10182
		private static Color l = Grayscale.Black;

		// Token: 0x040027C7 RID: 10183
		private static LineStyle m = LineStyle.Solid;
	}
}
