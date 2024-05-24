using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;
using zz93;

namespace ceTe.DynamicPDF.Merger
{
	// Token: 0x020006F1 RID: 1777
	public class ImportedPageArea : PageElement, IArea, ICoordinate
	{
		// Token: 0x06004483 RID: 17539 RVA: 0x00235318 File Offset: 0x00234318
		public ImportedPageArea(string filePath, int pageNumber, float x, float y) : this(new ImportedPageContents(new PdfDocument(filePath).GetPage(pageNumber)), x, y, 1f)
		{
		}

		// Token: 0x06004484 RID: 17540 RVA: 0x0023533C File Offset: 0x0023433C
		public ImportedPageArea(string filePath, int pageNumber, float x, float y, float scale) : this(new ImportedPageContents(new PdfDocument(filePath).GetPage(pageNumber)), x, y, scale)
		{
		}

		// Token: 0x06004485 RID: 17541 RVA: 0x0023535D File Offset: 0x0023435D
		public ImportedPageArea(PdfPage pdfPage, float x, float y) : this(new ImportedPageContents(pdfPage), x, y, 1f)
		{
		}

		// Token: 0x06004486 RID: 17542 RVA: 0x00235375 File Offset: 0x00234375
		public ImportedPageArea(PdfPage pdfPage, float x, float y, float scale) : this(new ImportedPageContents(pdfPage), x, y, scale)
		{
		}

		// Token: 0x06004487 RID: 17543 RVA: 0x0023538A File Offset: 0x0023438A
		public ImportedPageArea(ImportedPageContents contents, float x, float y) : this(contents, x, y, 1f)
		{
		}

		// Token: 0x06004488 RID: 17544 RVA: 0x002353A0 File Offset: 0x002343A0
		public ImportedPageArea(ImportedPageContents contents, float x, float y, float scale)
		{
			this.a = x;
			this.b = y;
			this.f = contents;
			this.c = scale;
			this.d = scale;
			base.d(contents.j().b());
		}

		// Token: 0x06004489 RID: 17545 RVA: 0x00235424 File Offset: 0x00234424
		internal override x5 b7()
		{
			return x5.a(this.b);
		}

		// Token: 0x0600448A RID: 17546 RVA: 0x00235444 File Offset: 0x00234444
		internal override x5 b8()
		{
			return x5.a(this.b);
		}

		// Token: 0x0600448B RID: 17547 RVA: 0x00235464 File Offset: 0x00234464
		internal float a()
		{
			return this.g;
		}

		// Token: 0x0600448C RID: 17548 RVA: 0x0023547C File Offset: 0x0023447C
		internal void a(float A_0)
		{
			this.g = A_0;
		}

		// Token: 0x0600448D RID: 17549 RVA: 0x00235488 File Offset: 0x00234488
		internal float b()
		{
			return this.h;
		}

		// Token: 0x0600448E RID: 17550 RVA: 0x002354A0 File Offset: 0x002344A0
		internal void b(float A_0)
		{
			this.h = A_0;
		}

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x0600448F RID: 17551 RVA: 0x002354AC File Offset: 0x002344AC
		// (set) Token: 0x06004490 RID: 17552 RVA: 0x002354C4 File Offset: 0x002344C4
		public float X
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

		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x06004491 RID: 17553 RVA: 0x002354D0 File Offset: 0x002344D0
		// (set) Token: 0x06004492 RID: 17554 RVA: 0x002354E8 File Offset: 0x002344E8
		public float Y
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

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x06004493 RID: 17555 RVA: 0x002354F4 File Offset: 0x002344F4
		// (set) Token: 0x06004494 RID: 17556 RVA: 0x0023550C File Offset: 0x0023450C
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

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x06004495 RID: 17557 RVA: 0x00235518 File Offset: 0x00234518
		// (set) Token: 0x06004496 RID: 17558 RVA: 0x00235530 File Offset: 0x00234530
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

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x06004497 RID: 17559 RVA: 0x0023553C File Offset: 0x0023453C
		// (set) Token: 0x06004498 RID: 17560 RVA: 0x00235554 File Offset: 0x00234554
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

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06004499 RID: 17561 RVA: 0x00235560 File Offset: 0x00234560
		// (set) Token: 0x0600449A RID: 17562 RVA: 0x00235584 File Offset: 0x00234584
		public float Width
		{
			get
			{
				return this.c * this.f.Width;
			}
			set
			{
				this.c = value / this.f.Width;
			}
		}

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x0600449B RID: 17563 RVA: 0x0023559C File Offset: 0x0023459C
		// (set) Token: 0x0600449C RID: 17564 RVA: 0x002355C0 File Offset: 0x002345C0
		public float Height
		{
			get
			{
				return this.d * this.f.Height;
			}
			set
			{
				this.d = value / this.f.Height;
			}
		}

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x0600449D RID: 17565 RVA: 0x002355D8 File Offset: 0x002345D8
		public ImportedPageContents Contents
		{
			get
			{
				return this.f;
			}
		}

		// Token: 0x0600449E RID: 17566 RVA: 0x002355F0 File Offset: 0x002345F0
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
			if (this.f.j().d().b() != null)
			{
				writer.Write_Do(this.f);
			}
			writer.Write_Q(true);
			if (this.f.j().t() != null)
			{
				afe a_ = new afe(this.f.j().t());
				writer.a(a_);
			}
		}

		// Token: 0x0600449F RID: 17567 RVA: 0x00235714 File Offset: 0x00234714
		private void a(PageWriter A_0)
		{
			if (this.e == 0f)
			{
				float xOffset = A_0.Dimensions.GetPdfX(this.a + this.g) - this.f.a() * this.c;
				float yOffset = A_0.Dimensions.GetPdfY(this.b + this.h) - this.f.e() * this.ScaleY;
				A_0.Write_cm(xOffset, yOffset);
				if (this.c != 1f || this.d != 1f)
				{
					A_0.Write_cm(this.c, 0f, 0f, this.d);
				}
			}
			else
			{
				double num = (double)(-(double)this.e) * 0.017453292519943295;
				float num2 = (float)Math.Cos(num);
				float num3 = (float)Math.Sin(num);
				float num4 = -num3;
				float num5 = num2;
				float xOffset = A_0.Dimensions.GetPdfX(this.a + this.g) - this.f.a() * this.c * num2 + this.f.e() * this.d * num3;
				float yOffset = A_0.Dimensions.GetPdfY(this.b + this.h) + this.f.a() * this.c * num4 - this.f.e() * this.d * num5;
				A_0.Write_cm(xOffset, yOffset);
				A_0.Write_cm(num2, num3, num4, num5);
				if (this.c != 1f || this.d != 1f)
				{
					A_0.Write_cm(this.c, 0f, 0f, this.d);
				}
			}
		}

		// Token: 0x060044A0 RID: 17568 RVA: 0x002358F4 File Offset: 0x002348F4
		public void SetBounds(float maximumWidth, float maximumHeight)
		{
			float num = maximumWidth / this.f.i().Width;
			float num2 = maximumHeight / this.f.i().Height;
			if (num > num2)
			{
				this.c = num2;
				this.d = num2;
			}
			else
			{
				this.c = num;
				this.d = num;
			}
		}

		// Token: 0x060044A1 RID: 17569 RVA: 0x00235955 File Offset: 0x00234955
		public void SetSize(float width, float height)
		{
			this.c = width / this.f.i().Width;
			this.d = height / this.f.i().Height;
		}

		// Token: 0x0400263E RID: 9790
		private new float a;

		// Token: 0x0400263F RID: 9791
		private float b;

		// Token: 0x04002640 RID: 9792
		private float c = 0f;

		// Token: 0x04002641 RID: 9793
		private new float d = 0f;

		// Token: 0x04002642 RID: 9794
		private float e = 0f;

		// Token: 0x04002643 RID: 9795
		private ImportedPageContents f;

		// Token: 0x04002644 RID: 9796
		private float g = 0f;

		// Token: 0x04002645 RID: 9797
		private float h = 0f;
	}
}
