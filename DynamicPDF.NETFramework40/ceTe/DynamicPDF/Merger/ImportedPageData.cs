using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Merger
{
	// Token: 0x020006F5 RID: 1781
	public class ImportedPageData : PageElement
	{
		// Token: 0x060044C3 RID: 17603 RVA: 0x00235D5F File Offset: 0x00234D5F
		public ImportedPageData(string filePath, int pageNumber) : this(new ImportedPageContents(new PdfDocument(filePath).GetPage(pageNumber)), 0f, 0f, 1f)
		{
		}

		// Token: 0x060044C4 RID: 17604 RVA: 0x00235D8A File Offset: 0x00234D8A
		public ImportedPageData(string filePath, int pageNumber, float xOffset, float yOffset) : this(new ImportedPageContents(new PdfDocument(filePath).GetPage(pageNumber)), xOffset, yOffset, 1f)
		{
		}

		// Token: 0x060044C5 RID: 17605 RVA: 0x00235DAE File Offset: 0x00234DAE
		public ImportedPageData(string filePath, int pageNumber, float xOffset, float yOffset, float scale) : this(new ImportedPageContents(new PdfDocument(filePath).GetPage(pageNumber)), xOffset, yOffset, scale)
		{
		}

		// Token: 0x060044C6 RID: 17606 RVA: 0x00235DCF File Offset: 0x00234DCF
		public ImportedPageData(PdfPage pdfPage) : this(new ImportedPageContents(pdfPage), 0f, 0f, 1f)
		{
		}

		// Token: 0x060044C7 RID: 17607 RVA: 0x00235DEF File Offset: 0x00234DEF
		public ImportedPageData(PdfPage pdfPage, float xOffset, float yOffset) : this(new ImportedPageContents(pdfPage), xOffset, yOffset, 1f)
		{
		}

		// Token: 0x060044C8 RID: 17608 RVA: 0x00235E07 File Offset: 0x00234E07
		public ImportedPageData(PdfPage pdfPage, float xOffset, float yOffset, float scale) : this(new ImportedPageContents(pdfPage), xOffset, yOffset, scale)
		{
		}

		// Token: 0x060044C9 RID: 17609 RVA: 0x00235E1C File Offset: 0x00234E1C
		public ImportedPageData(ImportedPageContents contents) : this(contents, 0f, 0f, 1f)
		{
		}

		// Token: 0x060044CA RID: 17610 RVA: 0x00235E37 File Offset: 0x00234E37
		public ImportedPageData(ImportedPageContents contents, float xOffset, float yOffset) : this(contents, xOffset, yOffset, 1f)
		{
		}

		// Token: 0x060044CB RID: 17611 RVA: 0x00235E4C File Offset: 0x00234E4C
		public ImportedPageData(ImportedPageContents contents, float xOffset, float yOffset, float scale)
		{
			this.a = xOffset;
			this.b = yOffset;
			this.c = scale;
			this.d = scale;
			this.f = contents;
			base.d(contents.j().b());
		}

		// Token: 0x060044CC RID: 17612 RVA: 0x00235EBC File Offset: 0x00234EBC
		public override void Draw(PageWriter writer)
		{
			base.d(13);
			writer.Write_q_(true);
			writer.SetCharacterSpacing(0f);
			writer.SetWordSpacing(0f);
			writer.SetHorizontalScaling(100f);
			writer.SetLeading(0f);
			writer.SetTextRenderingMode(TextRenderingMode.Fill);
			writer.SetTextRise(0f);
			writer.SetLineWidth(1f);
			writer.SetLineCap(LineCap.Butt);
			writer.SetLineJoin(LineJoin.Miter);
			writer.SetMiterLimit(10f);
			writer.SetLineStyle(LineStyle.Solid);
			writer.SetStrokeColor(Grayscale.Black);
			writer.SetFillColor(Grayscale.Black);
			this.a(writer);
			writer.Write_Do(this.f);
			writer.Write_Q(true);
		}

		// Token: 0x060044CD RID: 17613 RVA: 0x00235F88 File Offset: 0x00234F88
		private void a(PageWriter A_0)
		{
			double num = (double)(-(double)this.e) * 0.017453292519943295;
			float num2 = (float)Math.Cos(num);
			float num3 = (float)Math.Sin(num);
			float num4 = -num3;
			float num5 = num2;
			float xOffset = (A_0.Dimensions.Width - this.f.i().Width * this.c * num2 + this.f.i().Height * this.d * num3) / 2f + A_0.Dimensions.Edge.Left - (this.f.i().Left * num2 * this.c + this.f.i().Top * num4 * this.d) + (this.a + this.g);
			float yOffset = (A_0.Dimensions.Edge.Height - this.f.i().Height * num5 * this.d + this.f.i().Width * num4 * this.c) / 2f + A_0.Dimensions.Edge.Top - (this.f.i().Left * num3 * this.c + this.f.i().Top * num5 * this.d) - (this.b + this.h);
			A_0.Write_cm(xOffset, yOffset);
			if (num2 != 1f || num3 != 0f)
			{
				A_0.Write_cm(num2, num3, num4, num5);
			}
			if (this.c != 1f || this.d != 1f)
			{
				A_0.Write_cm(this.c, 0f, 0f, this.d);
			}
		}

		// Token: 0x060044CE RID: 17614 RVA: 0x0023616C File Offset: 0x0023516C
		internal override x5 b7()
		{
			return x5.a();
		}

		// Token: 0x060044CF RID: 17615 RVA: 0x00236184 File Offset: 0x00235184
		internal override x5 b8()
		{
			return x5.a();
		}

		// Token: 0x060044D0 RID: 17616 RVA: 0x0023619C File Offset: 0x0023519C
		internal float a()
		{
			return this.g;
		}

		// Token: 0x060044D1 RID: 17617 RVA: 0x002361B4 File Offset: 0x002351B4
		internal void a(float A_0)
		{
			this.g = A_0;
		}

		// Token: 0x060044D2 RID: 17618 RVA: 0x002361C0 File Offset: 0x002351C0
		internal float b()
		{
			return this.h;
		}

		// Token: 0x060044D3 RID: 17619 RVA: 0x002361D8 File Offset: 0x002351D8
		internal void b(float A_0)
		{
			this.h = A_0;
		}

		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x060044D4 RID: 17620 RVA: 0x002361E4 File Offset: 0x002351E4
		// (set) Token: 0x060044D5 RID: 17621 RVA: 0x002361FC File Offset: 0x002351FC
		public float XOffset
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

		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x060044D6 RID: 17622 RVA: 0x00236208 File Offset: 0x00235208
		// (set) Token: 0x060044D7 RID: 17623 RVA: 0x00236220 File Offset: 0x00235220
		public float YOffset
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

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x060044D8 RID: 17624 RVA: 0x0023622C File Offset: 0x0023522C
		// (set) Token: 0x060044D9 RID: 17625 RVA: 0x00236244 File Offset: 0x00235244
		public float ScaleX
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

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x060044DA RID: 17626 RVA: 0x00236250 File Offset: 0x00235250
		// (set) Token: 0x060044DB RID: 17627 RVA: 0x00236268 File Offset: 0x00235268
		public float ScaleY
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

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x060044DC RID: 17628 RVA: 0x00236274 File Offset: 0x00235274
		// (set) Token: 0x060044DD RID: 17629 RVA: 0x0023629D File Offset: 0x0023529D
		public float Width
		{
			get
			{
				return this.c * this.f.i().Width;
			}
			set
			{
				this.c = value / this.f.i().Width;
			}
		}

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x060044DE RID: 17630 RVA: 0x002362B8 File Offset: 0x002352B8
		// (set) Token: 0x060044DF RID: 17631 RVA: 0x002362E1 File Offset: 0x002352E1
		public float Height
		{
			get
			{
				return this.d * this.f.i().Height;
			}
			set
			{
				this.d = value / this.f.i().Height;
			}
		}

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x060044E0 RID: 17632 RVA: 0x002362FC File Offset: 0x002352FC
		// (set) Token: 0x060044E1 RID: 17633 RVA: 0x00236314 File Offset: 0x00235314
		public float Angle
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

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x060044E2 RID: 17634 RVA: 0x00236320 File Offset: 0x00235320
		public ImportedPageContents Contents
		{
			get
			{
				return this.f;
			}
		}

		// Token: 0x0400264E RID: 9806
		private new float a;

		// Token: 0x0400264F RID: 9807
		private float b;

		// Token: 0x04002650 RID: 9808
		private float c;

		// Token: 0x04002651 RID: 9809
		private new float d;

		// Token: 0x04002652 RID: 9810
		private float e = 0f;

		// Token: 0x04002653 RID: 9811
		private ImportedPageContents f;

		// Token: 0x04002654 RID: 9812
		private float g = 0f;

		// Token: 0x04002655 RID: 9813
		private float h = 0f;
	}
}
