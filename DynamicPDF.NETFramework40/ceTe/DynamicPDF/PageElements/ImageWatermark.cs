using System;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200074C RID: 1868
	public class ImageWatermark : Watermark
	{
		// Token: 0x06004BF4 RID: 19444 RVA: 0x002696D8 File Offset: 0x002686D8
		public ImageWatermark(string filePath)
		{
			this.a = ImageData.GetImage(filePath);
			base.d(1);
		}

		// Token: 0x06004BF5 RID: 19445 RVA: 0x00269744 File Offset: 0x00268744
		public ImageWatermark(ImageData imageData)
		{
			this.a = imageData;
			base.d(1);
		}

		// Token: 0x170005B9 RID: 1465
		// (get) Token: 0x06004BF6 RID: 19446 RVA: 0x002697AC File Offset: 0x002687AC
		// (set) Token: 0x06004BF7 RID: 19447 RVA: 0x002697C4 File Offset: 0x002687C4
		public ImageData ImageData
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

		// Token: 0x170005BA RID: 1466
		// (get) Token: 0x06004BF8 RID: 19448 RVA: 0x002697D0 File Offset: 0x002687D0
		// (set) Token: 0x06004BF9 RID: 19449 RVA: 0x002697E8 File Offset: 0x002687E8
		public float ScaleX
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

		// Token: 0x170005BB RID: 1467
		// (get) Token: 0x06004BFA RID: 19450 RVA: 0x002697F4 File Offset: 0x002687F4
		// (set) Token: 0x06004BFB RID: 19451 RVA: 0x0026980C File Offset: 0x0026880C
		public float ScaleY
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

		// Token: 0x06004BFC RID: 19452 RVA: 0x00269818 File Offset: 0x00268818
		public override void Draw(PageWriter writer)
		{
			if (writer.Document.PdfVersion == PdfVersion.v1_3 || writer.Document.PdfVersion == PdfVersion.v1_4 || writer.Document.PdfVersion == PdfVersion.v1_5)
			{
				throw new GeneratorException("The PDF version should be greater than or equal to 1.6");
			}
			base.a(writer);
		}

		// Token: 0x06004BFD RID: 19453 RVA: 0x00269874 File Offset: 0x00268874
		internal override void ki(DocumentWriter A_0)
		{
			afs afs = new afs(this, A_0, this.b, this.c);
			afs.e();
			afs.w();
			A_0.WriteName(Watermark.k);
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Watermark.h);
			A_0.WriteReference(A_0.Resources.Add(afs));
			A_0.WriteDictionaryClose();
		}

		// Token: 0x06004BFE RID: 19454 RVA: 0x002698E0 File Offset: 0x002688E0
		internal override void kj(float A_0, float A_1)
		{
			this.b = A_0;
			this.c = A_1;
			if (this.ImageData != null)
			{
				if (this.d != 1f || this.e != 1f)
				{
					base.c((float)this.a.Width * this.d);
					base.d((float)this.a.Height * this.e);
				}
				else
				{
					base.c((float)this.ImageData.Width);
					base.d((float)this.ImageData.Height);
				}
			}
			if (base.Angle != 0f)
			{
				float num = 0f;
				float num2 = 0f;
				float num3 = base.Angle;
				if (base.Angle > 360f | base.Angle < -360f)
				{
					num3 = base.Angle % 360f;
				}
				if (this.ScaleX != 1f || this.ScaleY != 1f)
				{
					Rectangle a_ = new Rectangle(0f, 0f, (float)((int)((float)this.a.Width * this.d)), (float)((int)((float)this.a.Height * this.e)));
					float a_2 = base.d();
					float a_3 = base.c();
					base.a("", num3, a_, Font.Helvetica, ref a_3, ref a_2);
					base.c(a_3);
					base.d(a_2);
				}
				if (base.Position == WatermarkPosition.TopLeft)
				{
					base.a(base.c(), base.d(), num3, ref num, ref num2);
					base.a(num + base.XOffset);
					base.b(num2 + base.YOffset);
				}
				else if (base.Position == WatermarkPosition.TopCenter)
				{
					base.a(A_0, A_1, num3, base.XOffset, base.YOffset);
				}
				else if (base.Position == WatermarkPosition.TopRight)
				{
					base.b(base.c(), base.d(), num3, ref num, ref num2);
					base.a(A_0 - num - base.XOffset);
					base.b(num2 + base.YOffset);
				}
				else if (base.Position == WatermarkPosition.MiddleLeft)
				{
					base.b(A_0, A_1, num3, base.XOffset, base.YOffset);
				}
				else if (base.Position == WatermarkPosition.Center)
				{
					base.c(A_0, A_1, num3, base.XOffset, base.YOffset);
				}
				else if (base.Position == WatermarkPosition.MiddleRight)
				{
					base.d(A_0, A_1, num3, base.XOffset, base.YOffset);
				}
				else if (base.Position == WatermarkPosition.BottomLeft)
				{
					base.c(base.c(), base.d(), num3, ref num, ref num2);
					base.a(num + base.XOffset);
					base.b(A_1 - num2 - base.YOffset);
				}
				else if (base.Position == WatermarkPosition.BottomCenter)
				{
					base.e(A_0, A_1, num3, base.XOffset, base.YOffset);
				}
				else if (base.Position == WatermarkPosition.BottomRight)
				{
					base.d(base.c(), base.d(), num3, ref num, ref num2);
					base.a(A_0 - num - base.XOffset);
					base.b(A_1 - num2 - base.YOffset);
				}
			}
			else if (base.Position == WatermarkPosition.TopLeft)
			{
				base.a(base.XOffset);
				base.b(A_1 - base.d() - base.YOffset);
			}
			else if (base.Position == WatermarkPosition.TopCenter)
			{
				base.a(base.XOffset + (A_0 - base.c()) / 2f);
				base.b(A_1 - base.d() - base.YOffset);
			}
			else if (base.Position == WatermarkPosition.TopRight)
			{
				base.a(-base.XOffset + A_0 - base.c());
				base.b(A_1 - base.d() - base.YOffset);
			}
			else if (base.Position == WatermarkPosition.MiddleLeft)
			{
				base.a(base.XOffset);
				base.b(base.YOffset + (A_1 - base.d()) / 2f);
			}
			else if (base.Position == WatermarkPosition.Center)
			{
				base.a(base.XOffset + (A_0 - base.c()) / 2f);
				base.b(base.YOffset + (A_1 - base.d()) / 2f);
			}
			else if (base.Position == WatermarkPosition.MiddleRight)
			{
				base.a(-base.XOffset + A_0 - base.c());
				base.b(base.YOffset + (A_1 - base.d()) / 2f);
			}
			else if (base.Position == WatermarkPosition.BottomLeft)
			{
				base.a(base.XOffset);
				base.b(base.YOffset);
			}
			else if (base.Position == WatermarkPosition.BottomCenter)
			{
				base.a(base.XOffset + (A_0 - base.c()) / 2f);
				base.b(base.YOffset);
			}
			else if (base.Position == WatermarkPosition.BottomRight)
			{
				base.a(-base.XOffset + A_0 - base.c());
				base.b(base.YOffset);
			}
		}

		// Token: 0x06004BFF RID: 19455 RVA: 0x00269F0C File Offset: 0x00268F0C
		public override void DrawAnnotation(DocumentWriter writer)
		{
			writer.WriteName(Watermark.i);
			writer.WriteName(Watermark.j);
			if (this.f.Length > 0)
			{
				writer.WriteName(84);
				writer.WriteText(base.Name);
			}
			if (this.g.Length > 0)
			{
				writer.WriteName(Watermark.l);
				writer.WriteText(this.g);
			}
			this.ki(writer);
			writer.WriteName(FormField.y);
			writer.WriteNumber(4);
		}

		// Token: 0x04002907 RID: 10503
		private new ImageData a;

		// Token: 0x04002908 RID: 10504
		private new float b = 0f;

		// Token: 0x04002909 RID: 10505
		private new float c = 0f;

		// Token: 0x0400290A RID: 10506
		private new float d = 1f;

		// Token: 0x0400290B RID: 10507
		private new float e = 1f;

		// Token: 0x0400290C RID: 10508
		private string f = "";

		// Token: 0x0400290D RID: 10509
		private new string g = "";
	}
}
