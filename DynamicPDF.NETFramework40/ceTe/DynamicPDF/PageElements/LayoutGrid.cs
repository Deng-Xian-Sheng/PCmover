using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200072E RID: 1838
	public class LayoutGrid : PageElement
	{
		// Token: 0x0600496B RID: 18795 RVA: 0x00259FEF File Offset: 0x00258FEF
		public LayoutGrid() : this(LayoutGrid.GridType.Decimal, true)
		{
		}

		// Token: 0x0600496C RID: 18796 RVA: 0x00259FFC File Offset: 0x00258FFC
		public LayoutGrid(bool showTitle) : this(LayoutGrid.GridType.Decimal, showTitle)
		{
		}

		// Token: 0x0600496D RID: 18797 RVA: 0x0025A009 File Offset: 0x00259009
		public LayoutGrid(LayoutGrid.GridType type) : this(type, true)
		{
		}

		// Token: 0x0600496E RID: 18798 RVA: 0x0025A016 File Offset: 0x00259016
		public LayoutGrid(LayoutGrid.GridType type, bool showTitle)
		{
			base.o();
			this.b = showTitle;
			this.a = type;
		}

		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x0600496F RID: 18799 RVA: 0x0025A040 File Offset: 0x00259040
		// (set) Token: 0x06004970 RID: 18800 RVA: 0x0025A058 File Offset: 0x00259058
		public LayoutGrid.GridType Type
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x06004971 RID: 18801 RVA: 0x0025A064 File Offset: 0x00259064
		// (set) Token: 0x06004972 RID: 18802 RVA: 0x0025A07C File Offset: 0x0025907C
		public bool ShowTitle
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

		// Token: 0x06004973 RID: 18803 RVA: 0x0025A088 File Offset: 0x00259088
		public override void Draw(PageWriter writer)
		{
			float width = writer.Dimensions.Body.Width;
			float height = writer.Dimensions.Body.Height;
			switch (this.a)
			{
			case LayoutGrid.GridType.Decimal:
				this.d(writer, width, height);
				break;
			case LayoutGrid.GridType.Standard:
				this.c(writer, width, height);
				break;
			case LayoutGrid.GridType.Metric:
				this.b(writer, width, height);
				break;
			case LayoutGrid.GridType.Print:
				this.a(writer, width, height);
				break;
			}
			writer.SetGraphicsMode();
			writer.SetLineWidth(1f);
			writer.SetStrokeColor(Grayscale.Black);
			writer.SetFillColor(Grayscale.Black);
			writer.SetLineStyle(LineStyle.Solid);
			writer.Write_re(0f, 0f, width, height);
			writer.Write_S();
		}

		// Token: 0x06004974 RID: 18804 RVA: 0x0025A158 File Offset: 0x00259158
		private void d(PageWriter A_0, float A_1, float A_2)
		{
			if (this.b)
			{
				string text = "Decimal Grid View: 1 square = 10 points = 10/72 inch = 0.139 inches = 0.353 cm";
				Label label = new Label(text, 2f - A_0.Dimensions.LeftMargin, 0f - A_0.Dimensions.TopMargin, 400f, 10f, Font.Helvetica, 10f);
				label.Draw(A_0);
			}
			A_0.SetTextMode();
			A_0.SetFont(Font.Helvetica, 6f);
			this.b(A_0, A_1, A_2, 10);
			this.a(A_0, A_1, A_2, 10);
			A_0.SetGraphicsMode();
			A_0.SetLineStyle(new LineStyle(new float[]
			{
				1f,
				2f
			}));
			A_0.SetLineWidth(0.5f);
			A_0.SetStrokeColor(new Grayscale(127));
			this.b(A_0, A_1, A_2, 100f, 10f);
			this.b(A_0, A_1, A_2, 100f, 20f);
			this.b(A_0, A_1, A_2, 100f, 30f);
			this.b(A_0, A_1, A_2, 100f, 40f);
			this.b(A_0, A_1, A_2, 100f, 60f);
			this.b(A_0, A_1, A_2, 100f, 70f);
			this.b(A_0, A_1, A_2, 100f, 80f);
			this.b(A_0, A_1, A_2, 100f, 90f);
			this.a(A_0, A_1, A_2, 100f, 10f);
			this.a(A_0, A_1, A_2, 100f, 20f);
			this.a(A_0, A_1, A_2, 100f, 30f);
			this.a(A_0, A_1, A_2, 100f, 40f);
			this.a(A_0, A_1, A_2, 100f, 60f);
			this.a(A_0, A_1, A_2, 100f, 70f);
			this.a(A_0, A_1, A_2, 100f, 80f);
			this.a(A_0, A_1, A_2, 100f, 90f);
			A_0.SetStrokeColor(new Grayscale(63));
			A_0.SetLineWidth(1f);
			this.b(A_0, A_1, A_2, 100f, 50f);
			this.a(A_0, A_1, A_2, 100f, 50f);
			A_0.SetStrokeColor(Grayscale.Black);
			this.b(A_0, A_1, A_2, 100f, 0f);
			this.a(A_0, A_1, A_2, 100f, 0f);
		}

		// Token: 0x06004975 RID: 18805 RVA: 0x0025A3EC File Offset: 0x002593EC
		private void c(PageWriter A_0, float A_1, float A_2)
		{
			if (this.b)
			{
				string text = "Standard Grid View: 1 square = 9 points = 1/8 inch = 0.125 inches = 0.317 cm";
				Label label = new Label(text, 2f - A_0.Dimensions.LeftMargin, 0f - A_0.Dimensions.TopMargin, 400f, 10f, Font.Helvetica, 10f);
				label.Draw(A_0);
			}
			A_0.SetTextMode();
			A_0.SetFont(Font.Helvetica, 6f);
			this.b(A_0, A_1, A_2, 18);
			this.a(A_0, A_1, A_2, 18);
			A_0.SetGraphicsMode();
			A_0.SetLineStyle(new LineStyle(new float[]
			{
				1f,
				2f
			}));
			A_0.SetLineWidth(0.5f);
			A_0.SetStrokeColor(new Grayscale(127));
			this.b(A_0, A_1, A_2, 72f, 9f);
			this.b(A_0, A_1, A_2, 72f, 18f);
			this.b(A_0, A_1, A_2, 72f, 27f);
			this.b(A_0, A_1, A_2, 72f, 45f);
			this.b(A_0, A_1, A_2, 72f, 52f);
			this.b(A_0, A_1, A_2, 72f, 63f);
			this.a(A_0, A_1, A_2, 72f, 9f);
			this.a(A_0, A_1, A_2, 72f, 18f);
			this.a(A_0, A_1, A_2, 72f, 27f);
			this.a(A_0, A_1, A_2, 72f, 45f);
			this.a(A_0, A_1, A_2, 72f, 52f);
			this.a(A_0, A_1, A_2, 72f, 63f);
			A_0.SetStrokeColor(new Grayscale(63));
			A_0.SetLineWidth(1f);
			this.b(A_0, A_1, A_2, 72f, 36f);
			this.a(A_0, A_1, A_2, 72f, 36f);
			A_0.SetStrokeColor(Grayscale.Black);
			this.b(A_0, A_1, A_2, 72f, 0f);
			this.a(A_0, A_1, A_2, 72f, 0f);
		}

		// Token: 0x06004976 RID: 18806 RVA: 0x0025A630 File Offset: 0x00259630
		private void b(PageWriter A_0, float A_1, float A_2)
		{
			if (this.b)
			{
				string text = "Metric Grid View: 1 square = 10 points = 0.353 cm,";
				Label label = new Label(text, 2f - A_0.Dimensions.LeftMargin, 0f - A_0.Dimensions.TopMargin, 400f, 10f, Font.Helvetica, 10f);
				label.Draw(A_0);
				text = "Blue Grid: 1 square = 1 cm = 28.35 points";
				label = new Label(text, 230f - A_0.Dimensions.LeftMargin, 0f - A_0.Dimensions.TopMargin, 400f, 10f, Font.Helvetica, 10f, RgbColor.Blue);
				label.Draw(A_0);
			}
			A_0.SetTextMode();
			A_0.SetFont(Font.Helvetica, 6f);
			A_0.SetFillColor(Grayscale.Black);
			this.b(A_0, A_1, A_2, 10);
			this.a(A_0, A_1, A_2, 10);
			A_0.SetGraphicsMode();
			A_0.SetLineStyle(new LineStyle(new float[]
			{
				2f,
				1f
			}));
			A_0.SetLineWidth(0.5f);
			A_0.SetStrokeColor(RgbColor.Blue);
			this.b(A_0, A_1, A_2, 28.346f, 0f);
			this.a(A_0, A_1, A_2, 28.346f, 0f);
			A_0.SetLineStyle(new LineStyle(new float[]
			{
				1f,
				2f
			}));
			A_0.SetStrokeColor(new Grayscale(127));
			this.b(A_0, A_1, A_2, 100f, 10f);
			this.b(A_0, A_1, A_2, 100f, 20f);
			this.b(A_0, A_1, A_2, 100f, 30f);
			this.b(A_0, A_1, A_2, 100f, 40f);
			this.b(A_0, A_1, A_2, 100f, 60f);
			this.b(A_0, A_1, A_2, 100f, 70f);
			this.b(A_0, A_1, A_2, 100f, 80f);
			this.b(A_0, A_1, A_2, 100f, 90f);
			this.a(A_0, A_1, A_2, 100f, 10f);
			this.a(A_0, A_1, A_2, 100f, 20f);
			this.a(A_0, A_1, A_2, 100f, 30f);
			this.a(A_0, A_1, A_2, 100f, 40f);
			this.a(A_0, A_1, A_2, 100f, 60f);
			this.a(A_0, A_1, A_2, 100f, 70f);
			this.a(A_0, A_1, A_2, 100f, 80f);
			this.a(A_0, A_1, A_2, 100f, 90f);
			A_0.SetStrokeColor(new Grayscale(63));
			A_0.SetLineWidth(1f);
			this.b(A_0, A_1, A_2, 100f, 50f);
			this.a(A_0, A_1, A_2, 100f, 50f);
			A_0.SetStrokeColor(Grayscale.Black);
			this.b(A_0, A_1, A_2, 100f, 0f);
			this.a(A_0, A_1, A_2, 100f, 0f);
		}

		// Token: 0x06004977 RID: 18807 RVA: 0x0025A97C File Offset: 0x0025997C
		private void a(PageWriter A_0, float A_1, float A_2)
		{
			if (this.b)
			{
				string text = "Print Grid View: 1 square = 1/2 pica = 6 points = 1/12 inch = 0.833 inches = 0.212 cm";
				Label label = new Label(text, 2f - A_0.Dimensions.LeftMargin, 0f - A_0.Dimensions.TopMargin, 400f, 10f, Font.Helvetica, 10f);
				label.Draw(A_0);
			}
			A_0.SetTextMode();
			A_0.SetFont(Font.Helvetica, 6f);
			this.b(A_0, A_1, A_2, 12);
			this.a(A_0, A_1, A_2, 12);
			A_0.SetGraphicsMode();
			A_0.SetLineStyle(new LineStyle(new float[]
			{
				1f,
				2f
			}));
			A_0.SetLineWidth(0.5f);
			A_0.SetStrokeColor(new Grayscale(127));
			this.b(A_0, A_1, A_2, 72f, 6f);
			this.b(A_0, A_1, A_2, 72f, 12f);
			this.b(A_0, A_1, A_2, 72f, 18f);
			this.b(A_0, A_1, A_2, 72f, 24f);
			this.b(A_0, A_1, A_2, 72f, 30f);
			this.b(A_0, A_1, A_2, 72f, 42f);
			this.b(A_0, A_1, A_2, 72f, 48f);
			this.b(A_0, A_1, A_2, 72f, 54f);
			this.b(A_0, A_1, A_2, 72f, 60f);
			this.b(A_0, A_1, A_2, 72f, 66f);
			this.a(A_0, A_1, A_2, 72f, 6f);
			this.a(A_0, A_1, A_2, 72f, 12f);
			this.a(A_0, A_1, A_2, 72f, 18f);
			this.a(A_0, A_1, A_2, 72f, 24f);
			this.a(A_0, A_1, A_2, 72f, 30f);
			this.a(A_0, A_1, A_2, 72f, 42f);
			this.a(A_0, A_1, A_2, 72f, 48f);
			this.a(A_0, A_1, A_2, 72f, 54f);
			this.a(A_0, A_1, A_2, 72f, 60f);
			this.a(A_0, A_1, A_2, 72f, 66f);
			A_0.SetStrokeColor(new Grayscale(63));
			A_0.SetLineWidth(1f);
			this.b(A_0, A_1, A_2, 72f, 36f);
			this.a(A_0, A_1, A_2, 72f, 36f);
			A_0.SetStrokeColor(Grayscale.Black);
			this.b(A_0, A_1, A_2, 72f, 0f);
			this.a(A_0, A_1, A_2, 72f, 0f);
		}

		// Token: 0x06004978 RID: 18808 RVA: 0x0025AC60 File Offset: 0x00259C60
		private void b(PageWriter A_0, float A_1, float A_2, int A_3)
		{
			int num = 0;
			char[] text;
			while ((float)num < A_1 - 6f)
			{
				text = num.ToString().ToCharArray();
				A_0.Write_Tm(0f, 1f, -1f, 0f, (float)(num + 2), -2f);
				A_0.Write_Tj_(text, false);
				A_0.Write_Tm(0f, 1f, -1f, 0f, (float)(num + 2), A_2 + Font.Helvetica.GetTextWidth(text, 6f) + 2f);
				A_0.Write_Tj_(text, false);
				num += A_3;
			}
			text = A_1.ToString().ToCharArray();
			A_0.Write_Tm(0f, 1f, -1f, 0f, A_1 + 2f, -2f);
			A_0.Write_Tj_(text, false);
			A_0.Write_Tm(0f, 1f, -1f, 0f, A_1 + 2f, A_2 + Font.Helvetica.GetTextWidth(text, 6f) + 2f);
			A_0.Write_Tj_(text, false);
		}

		// Token: 0x06004979 RID: 18809 RVA: 0x0025AD88 File Offset: 0x00259D88
		private void a(PageWriter A_0, float A_1, float A_2, int A_3)
		{
			int num = 0;
			char[] text;
			while ((float)num < A_2 - 6f)
			{
				text = num.ToString().ToCharArray();
				A_0.Write_Tm(-2.5f - Font.Helvetica.GetTextWidth(num.ToString(), 6f), (float)(num + 2));
				A_0.Write_Tj_(text, false);
				A_0.Write_Tm(A_1 + 2.5f, (float)(num + 2));
				A_0.Write_Tj_(text, false);
				num += A_3;
			}
			text = A_2.ToString().ToCharArray();
			A_0.Write_Tm(-2.5f - Font.Helvetica.GetTextWidth(A_2.ToString(), 6f), A_2 + 2f);
			A_0.Write_Tj_(text, false);
			A_0.Write_Tm(A_1 + 2.5f, A_2 + 2f);
			A_0.Write_Tj_(text, false);
		}

		// Token: 0x0600497A RID: 18810 RVA: 0x0025AE68 File Offset: 0x00259E68
		private void b(PageWriter A_0, float A_1, float A_2, float A_3, float A_4)
		{
			for (float num = A_4; num < A_1; num += A_3)
			{
				A_0.Write_m_(num, 0f);
				A_0.Write_l_(num, A_2);
				A_0.Write_S();
			}
		}

		// Token: 0x0600497B RID: 18811 RVA: 0x0025AEA8 File Offset: 0x00259EA8
		private void a(PageWriter A_0, float A_1, float A_2, float A_3, float A_4)
		{
			for (float num = A_4; num < A_2; num += A_3)
			{
				A_0.Write_m_(0f, num);
				A_0.Write_l_(A_1, num);
				A_0.Write_S();
			}
		}

		// Token: 0x0600497C RID: 18812 RVA: 0x0025AEE7 File Offset: 0x00259EE7
		internal override x5 b7()
		{
			throw new GeneratorException("LayoutGrid does not support the Top property.");
		}

		// Token: 0x0600497D RID: 18813 RVA: 0x0025AEF4 File Offset: 0x00259EF4
		internal override x5 b8()
		{
			throw new GeneratorException("LayoutGrid does not support the Bottom property.");
		}

		// Token: 0x040027FA RID: 10234
		private new LayoutGrid.GridType a;

		// Token: 0x040027FB RID: 10235
		private bool b = true;

		// Token: 0x0200072F RID: 1839
		public enum GridType
		{
			// Token: 0x040027FD RID: 10237
			Decimal,
			// Token: 0x040027FE RID: 10238
			Standard,
			// Token: 0x040027FF RID: 10239
			Metric,
			// Token: 0x04002800 RID: 10240
			Print
		}
	}
}
