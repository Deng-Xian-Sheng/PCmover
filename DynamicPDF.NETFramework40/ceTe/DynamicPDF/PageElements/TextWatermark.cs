using System;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200074D RID: 1869
	public class TextWatermark : Watermark
	{
		// Token: 0x06004C00 RID: 19456 RVA: 0x00269FAC File Offset: 0x00268FAC
		public TextWatermark(string text)
		{
			this.a = text;
			base.d(1);
		}

		// Token: 0x06004C01 RID: 19457 RVA: 0x0026A044 File Offset: 0x00269044
		public TextWatermark(string text, Font font)
		{
			this.a = text;
			this.b = font;
			base.d(1);
		}

		// Token: 0x06004C02 RID: 19458 RVA: 0x0026A0E4 File Offset: 0x002690E4
		public TextWatermark(string text, Font font, float fontSize)
		{
			this.AutoScale = false;
			this.a = text;
			this.b = font;
			this.c = fontSize;
			base.d(1);
		}

		// Token: 0x170005BC RID: 1468
		// (get) Token: 0x06004C03 RID: 19459 RVA: 0x0026A190 File Offset: 0x00269190
		// (set) Token: 0x06004C04 RID: 19460 RVA: 0x0026A1A8 File Offset: 0x002691A8
		public string Text
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

		// Token: 0x170005BD RID: 1469
		// (get) Token: 0x06004C05 RID: 19461 RVA: 0x0026A1B4 File Offset: 0x002691B4
		// (set) Token: 0x06004C06 RID: 19462 RVA: 0x0026A1CC File Offset: 0x002691CC
		public Font Font
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

		// Token: 0x170005BE RID: 1470
		// (get) Token: 0x06004C07 RID: 19463 RVA: 0x0026A1D8 File Offset: 0x002691D8
		// (set) Token: 0x06004C08 RID: 19464 RVA: 0x0026A1F0 File Offset: 0x002691F0
		public float FontSize
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
				this.AutoScale = false;
			}
		}

		// Token: 0x170005BF RID: 1471
		// (get) Token: 0x06004C09 RID: 19465 RVA: 0x0026A204 File Offset: 0x00269204
		// (set) Token: 0x06004C0A RID: 19466 RVA: 0x0026A21C File Offset: 0x0026921C
		public int ScalingPercentage
		{
			get
			{
				return this.m;
			}
			set
			{
				this.m = value;
				this.l = true;
			}
		}

		// Token: 0x170005C0 RID: 1472
		// (get) Token: 0x06004C0B RID: 19467 RVA: 0x0026A230 File Offset: 0x00269230
		// (set) Token: 0x06004C0C RID: 19468 RVA: 0x0026A248 File Offset: 0x00269248
		public bool AutoScale
		{
			get
			{
				return this.l;
			}
			set
			{
				this.l = value;
			}
		}

		// Token: 0x170005C1 RID: 1473
		// (get) Token: 0x06004C0D RID: 19469 RVA: 0x0026A254 File Offset: 0x00269254
		// (set) Token: 0x06004C0E RID: 19470 RVA: 0x0026A26C File Offset: 0x0026926C
		public Color TextColor
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

		// Token: 0x170005C2 RID: 1474
		// (get) Token: 0x06004C0F RID: 19471 RVA: 0x0026A278 File Offset: 0x00269278
		// (set) Token: 0x06004C10 RID: 19472 RVA: 0x0026A290 File Offset: 0x00269290
		public Color TextOutlineColor
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

		// Token: 0x170005C3 RID: 1475
		// (get) Token: 0x06004C11 RID: 19473 RVA: 0x0026A29C File Offset: 0x0026929C
		// (set) Token: 0x06004C12 RID: 19474 RVA: 0x0026A2B4 File Offset: 0x002692B4
		public float TextOutlineWidth
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

		// Token: 0x170005C4 RID: 1476
		// (get) Token: 0x06004C13 RID: 19475 RVA: 0x0026A2C0 File Offset: 0x002692C0
		// (set) Token: 0x06004C14 RID: 19476 RVA: 0x0026A2D8 File Offset: 0x002692D8
		public bool Strikethrough
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

		// Token: 0x170005C5 RID: 1477
		// (get) Token: 0x06004C15 RID: 19477 RVA: 0x0026A2E4 File Offset: 0x002692E4
		// (set) Token: 0x06004C16 RID: 19478 RVA: 0x0026A2FC File Offset: 0x002692FC
		public bool Underline
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

		// Token: 0x06004C17 RID: 19479 RVA: 0x0026A308 File Offset: 0x00269308
		public override void Draw(PageWriter writer)
		{
			if (writer.Document.PdfVersion == PdfVersion.v1_3 || writer.Document.PdfVersion == PdfVersion.v1_4 || writer.Document.PdfVersion == PdfVersion.v1_5)
			{
				throw new GeneratorException("The PDF version should be greater than or equal to 1.6");
			}
			base.a(writer);
		}

		// Token: 0x06004C18 RID: 19480 RVA: 0x0026A364 File Offset: 0x00269364
		public override void DrawAnnotation(DocumentWriter writer)
		{
			writer.WriteName(Watermark.i);
			writer.WriteName(Watermark.j);
			if (base.Name.Length > 0)
			{
				writer.WriteName(84);
				writer.WriteText(base.Name);
			}
			if (base.AlternateName.Length > 0)
			{
				writer.WriteName(Watermark.l);
				writer.WriteText(base.AlternateName);
			}
			if (this.Text != null)
			{
				writer.WriteName(Watermark.g);
				writer.WriteText(this.a);
			}
			this.ki(writer);
			writer.WriteName(FormField.y);
			writer.WriteNumber(4);
		}

		// Token: 0x06004C19 RID: 19481 RVA: 0x0026A42C File Offset: 0x0026942C
		internal override void ki(DocumentWriter A_0)
		{
			afs afs = new afs(this, A_0, this.j, this.k);
			afs.c();
			afs.w();
			A_0.WriteName(Watermark.k);
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Watermark.h);
			A_0.WriteReference(A_0.Resources.Add(afs));
			A_0.WriteDictionaryClose();
		}

		// Token: 0x06004C1A RID: 19482 RVA: 0x0026A498 File Offset: 0x00269498
		internal override void kj(float A_0, float A_1)
		{
			this.j = A_0;
			this.k = A_1;
			float num = 1f;
			if (this.AutoScale)
			{
				this.FontSize = 12f;
				this.AutoScale = true;
			}
			if (this.Text != "")
			{
				num = this.Font.GetTextWidth(this.Text, this.FontSize);
			}
			if (this.Text != "")
			{
				this.i = this.Font.GetTextLines(this.Text.ToCharArray(), num, this.FontSize);
				if (this.AutoScale)
				{
					if (base.Angle == 0f)
					{
						base.c(A_0 * (float)this.ScalingPercentage / 100f);
						base.d(A_1 * (float)this.ScalingPercentage / 100f);
						this.FontSize = this.a(this.Text, this.Font, base.c(), base.d());
					}
				}
				else
				{
					base.c(num);
					this.c = this.FontSize;
					base.d(this.i.GetRequiredHeight(0));
				}
			}
			if (base.Angle != 0f)
			{
				float num2 = 0f;
				float num3 = 0f;
				float num4 = base.Angle;
				if (base.Angle > 360f | base.Angle < -360f)
				{
					num4 = base.Angle % 360f;
				}
				if (this.AutoScale)
				{
					Rectangle a_ = new Rectangle(0f, 0f, (float)((int)A_0 * this.ScalingPercentage / 100), (float)((int)A_1 * this.ScalingPercentage / 100));
					float a_2 = base.d();
					float a_3 = base.c();
					base.a(this.Text, num4, a_, this.Font, ref a_3, ref a_2);
					base.c(a_3);
					base.d(a_2);
					this.FontSize = this.a(this.Text, this.Font, base.c(), base.d());
					this.AutoScale = true;
				}
				if (base.Position == WatermarkPosition.TopLeft)
				{
					base.a(base.c(), base.d(), num4, ref num2, ref num3);
					base.a(num2 + base.XOffset);
					base.b(num3 + base.YOffset);
				}
				else if (base.Position == WatermarkPosition.TopCenter)
				{
					base.a(A_0, A_1, num4, base.XOffset, base.YOffset);
				}
				else if (base.Position == WatermarkPosition.TopRight)
				{
					base.b(base.c(), base.d(), num4, ref num2, ref num3);
					base.a(A_0 - num2 - base.XOffset);
					base.b(num3 + base.YOffset);
				}
				else if (base.Position == WatermarkPosition.MiddleLeft)
				{
					base.b(A_0, A_1, num4, base.XOffset, base.YOffset);
				}
				else if (base.Position == WatermarkPosition.Center)
				{
					base.c(A_0, A_1, num4, base.XOffset, base.YOffset);
				}
				else if (base.Position == WatermarkPosition.MiddleRight)
				{
					base.d(A_0, A_1, num4, base.XOffset, base.YOffset);
				}
				else if (base.Position == WatermarkPosition.BottomLeft)
				{
					base.c(base.c(), base.d(), num4, ref num2, ref num3);
					base.a(num2 + base.XOffset);
					base.b(A_1 - num3 - base.YOffset);
				}
				else if (base.Position == WatermarkPosition.BottomCenter)
				{
					base.e(A_0, A_1, num4, base.XOffset, base.YOffset);
				}
				else if (base.Position == WatermarkPosition.BottomRight)
				{
					base.d(base.c(), base.d(), num4, ref num2, ref num3);
					base.a(A_0 - num2 - base.XOffset);
					base.b(A_1 - num3 - base.YOffset);
				}
			}
			else if (base.Position == WatermarkPosition.TopLeft)
			{
				base.a(base.XOffset);
				base.b(base.YOffset);
			}
			else if (base.Position == WatermarkPosition.TopCenter)
			{
				base.a(base.XOffset + (A_0 - base.c()) / 2f);
				base.b(base.YOffset);
			}
			else if (base.Position == WatermarkPosition.TopRight)
			{
				base.a(-base.XOffset + A_0 - base.c());
				base.b(base.YOffset);
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
				base.b(-base.YOffset + A_1 - base.d());
			}
			else if (base.Position == WatermarkPosition.BottomCenter)
			{
				base.a(base.XOffset + (A_0 - base.c()) / 2f);
				base.b(-base.YOffset + A_1 - base.d());
			}
			else if (base.Position == WatermarkPosition.BottomRight)
			{
				base.a(-base.XOffset + A_0 - base.c());
				base.b(-base.YOffset + A_1 - base.d());
			}
		}

		// Token: 0x06004C1B RID: 19483 RVA: 0x0026AB84 File Offset: 0x00269B84
		private float a(string A_0, Font A_1, float A_2, float A_3)
		{
			this.FontSize = this.a(A_0, A_1, A_2);
			this.i.Width = A_2;
			this.i.FontSize = this.FontSize;
			float textHeight = this.i.GetTextHeight();
			float num = (float)((int)this.FontSize);
			if (textHeight > A_3)
			{
				for (int i = (int)num - 1; i >= 0; i--)
				{
					textHeight = this.i.GetTextHeight();
					if (textHeight <= A_3)
					{
						num = (float)i;
						break;
					}
					this.i.FontSize = (float)i;
				}
			}
			this.FontSize = num;
			base.c(A_1.GetTextWidth(A_0, num));
			base.d(this.i.GetTextHeight());
			return num;
		}

		// Token: 0x06004C1C RID: 19484 RVA: 0x0026AC68 File Offset: 0x00269C68
		private float a(string A_0, Font A_1, float A_2)
		{
			float num = 1f;
			if (A_0 != "")
			{
				float textWidth;
				do
				{
					textWidth = A_1.GetTextWidth(A_0, num);
					if (textWidth > A_2 - 1f)
					{
						break;
					}
					num += 1f;
				}
				while (A_2 - 1f >= textWidth);
			}
			return num - 1f;
		}

		// Token: 0x0400290E RID: 10510
		private new string a = "";

		// Token: 0x0400290F RID: 10511
		private new Font b = Font.Helvetica;

		// Token: 0x04002910 RID: 10512
		private new float c = 12f;

		// Token: 0x04002911 RID: 10513
		private new Color d = Grayscale.Black;

		// Token: 0x04002912 RID: 10514
		private new Color e = null;

		// Token: 0x04002913 RID: 10515
		private float f = 1f;

		// Token: 0x04002914 RID: 10516
		private new bool g = false;

		// Token: 0x04002915 RID: 10517
		private new bool h = false;

		// Token: 0x04002916 RID: 10518
		private new TextLineList i;

		// Token: 0x04002917 RID: 10519
		private new float j = 0f;

		// Token: 0x04002918 RID: 10520
		private new float k = 0f;

		// Token: 0x04002919 RID: 10521
		private new bool l = true;

		// Token: 0x0400291A RID: 10522
		private int m = 100;
	}
}
