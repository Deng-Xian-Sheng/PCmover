using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x02000283 RID: 643
	internal class qx : TaggablePageElement
	{
		// Token: 0x06001C86 RID: 7302 RVA: 0x00125130 File Offset: 0x00124130
		public qx(float[] A_0, float[] A_1) : this(A_0, A_1, qx.i, qx.h, 1f, qx.j)
		{
		}

		// Token: 0x06001C87 RID: 7303 RVA: 0x00125151 File Offset: 0x00124151
		public qx(float[] A_0, float[] A_1, Color A_2) : this(A_0, A_1, A_2, qx.h, 1f, qx.j)
		{
		}

		// Token: 0x06001C88 RID: 7304 RVA: 0x0012516E File Offset: 0x0012416E
		public qx(float[] A_0, float[] A_1, float A_2) : this(A_0, A_1, qx.i, qx.h, A_2, qx.j)
		{
		}

		// Token: 0x06001C89 RID: 7305 RVA: 0x0012518B File Offset: 0x0012418B
		public qx(float[] A_0, float[] A_1, float A_2, Color A_3) : this(A_0, A_1, A_3, qx.h, A_2, qx.j)
		{
		}

		// Token: 0x06001C8A RID: 7306 RVA: 0x001251A5 File Offset: 0x001241A5
		public qx(float[] A_0, float[] A_1, float A_2, LineStyle A_3) : this(A_0, A_1, qx.i, qx.h, A_2, A_3)
		{
		}

		// Token: 0x06001C8B RID: 7307 RVA: 0x001251BF File Offset: 0x001241BF
		public qx(float[] A_0, float[] A_1, float A_2, Color A_3, LineStyle A_4) : this(A_0, A_1, A_3, qx.h, A_2, A_4)
		{
		}

		// Token: 0x06001C8C RID: 7308 RVA: 0x001251D6 File Offset: 0x001241D6
		public qx(float[] A_0, float[] A_1, float A_2, Color A_3, Color A_4) : this(A_0, A_1, A_3, A_4, A_2, qx.j)
		{
		}

		// Token: 0x06001C8D RID: 7309 RVA: 0x001251ED File Offset: 0x001241ED
		public qx(float[] A_0, float[] A_1, Color A_2, Color A_3) : this(A_0, A_1, A_2, A_3, 1f, qx.j)
		{
		}

		// Token: 0x06001C8E RID: 7310 RVA: 0x00125208 File Offset: 0x00124208
		public qx(float[] A_0, float[] A_1, Color A_2, Color A_3, float A_4, LineStyle A_5)
		{
			this.b = A_0;
			this.c = A_1;
			this.e = A_3;
			this.f = A_2;
			if (A_4 <= 0f)
			{
				this.d = 0f;
			}
			this.d = A_4;
			this.g = A_5;
			base.d(1);
		}

		// Token: 0x06001C8F RID: 7311 RVA: 0x0012526C File Offset: 0x0012426C
		public LineStyle a()
		{
			return this.g;
		}

		// Token: 0x06001C90 RID: 7312 RVA: 0x00125284 File Offset: 0x00124284
		public void a(LineStyle A_0)
		{
			this.g = A_0;
		}

		// Token: 0x06001C91 RID: 7313 RVA: 0x00125290 File Offset: 0x00124290
		public float[] b()
		{
			return this.b;
		}

		// Token: 0x06001C92 RID: 7314 RVA: 0x001252A8 File Offset: 0x001242A8
		public void a(float[] A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001C93 RID: 7315 RVA: 0x001252B4 File Offset: 0x001242B4
		public float[] c()
		{
			return this.c;
		}

		// Token: 0x06001C94 RID: 7316 RVA: 0x001252CC File Offset: 0x001242CC
		public void b(float[] A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001C95 RID: 7317 RVA: 0x001252D8 File Offset: 0x001242D8
		public float d()
		{
			return this.d;
		}

		// Token: 0x06001C96 RID: 7318 RVA: 0x001252F0 File Offset: 0x001242F0
		public void a(float A_0)
		{
			if (A_0 <= 0f)
			{
				this.d = 0f;
			}
			else
			{
				this.d = A_0;
			}
		}

		// Token: 0x06001C97 RID: 7319 RVA: 0x00125320 File Offset: 0x00124320
		public Color e()
		{
			return this.f;
		}

		// Token: 0x06001C98 RID: 7320 RVA: 0x00125338 File Offset: 0x00124338
		public void a(Color A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06001C99 RID: 7321 RVA: 0x00125344 File Offset: 0x00124344
		public Color f()
		{
			return this.e;
		}

		// Token: 0x06001C9A RID: 7322 RVA: 0x0012535C File Offset: 0x0012435C
		public void b(Color A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06001C9B RID: 7323 RVA: 0x00125368 File Offset: 0x00124368
		public override void Draw(PageWriter writer)
		{
			bool flag = true;
			bool flag2;
			bool flag3;
			if (this.d > 0f && this.e != null)
			{
				flag2 = true;
				flag3 = true;
			}
			else if (this.d > 0f)
			{
				flag2 = true;
				flag3 = false;
			}
			else if (this.e != null)
			{
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
				if (this.b.Length != this.c.Length || this.b.Length <= 2)
				{
					throw new GeneratorException("Coordinates are wrong");
				}
				writer.SetGraphicsMode();
				if (flag2 && flag3)
				{
					writer.SetLineWidth(this.d);
					writer.SetStrokeColor(this.f);
					writer.SetLineStyle(this.g);
					writer.SetLineCap(LineCap.Butt);
					writer.SetFillColor(this.e);
				}
				else if (flag2)
				{
					writer.SetLineWidth(this.d);
					writer.SetStrokeColor(this.f);
					writer.SetLineStyle(this.g);
					writer.SetLineCap(LineCap.Butt);
				}
				else if (flag3)
				{
					writer.SetFillColor(this.e);
				}
				if (writer.Document.Tag != null)
				{
					if (this.Tag == null)
					{
						this.Tag = new StructureElement(TagType.Figure, true);
						((StructureElement)this.Tag).Order = this.TagOrder;
					}
					this.Tag.e(writer, this);
				}
				writer.Write_m_(this.b[0], this.c[0]);
				for (int i = 1; i < this.b.Length; i++)
				{
					writer.Write_l_(this.b[i], this.c[i]);
				}
				writer.Write_l_(this.b[0], this.c[0]);
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
				if (writer.Document.Tag != null)
				{
					Tag.a(writer);
				}
			}
		}

		// Token: 0x04000CE7 RID: 3303
		private new const float a = 1f;

		// Token: 0x04000CE8 RID: 3304
		private float[] b;

		// Token: 0x04000CE9 RID: 3305
		private float[] c;

		// Token: 0x04000CEA RID: 3306
		private new float d;

		// Token: 0x04000CEB RID: 3307
		private Color e;

		// Token: 0x04000CEC RID: 3308
		private Color f;

		// Token: 0x04000CED RID: 3309
		private LineStyle g;

		// Token: 0x04000CEE RID: 3310
		private static Color h = null;

		// Token: 0x04000CEF RID: 3311
		private static Color i = Grayscale.Black;

		// Token: 0x04000CF0 RID: 3312
		private static LineStyle j = LineStyle.Solid;
	}
}
