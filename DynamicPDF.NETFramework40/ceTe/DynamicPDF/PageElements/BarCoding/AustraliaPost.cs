using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000751 RID: 1873
	public class AustraliaPost : TextBarCode
	{
		// Token: 0x06004C4D RID: 19533 RVA: 0x0026B694 File Offset: 0x0026A694
		public AustraliaPost(string value, float x, float y) : this(value, x, y, 9f, 3.2727273f, false)
		{
		}

		// Token: 0x06004C4E RID: 19534 RVA: 0x0026B6AD File Offset: 0x0026A6AD
		public AustraliaPost(string value, float x, float y, bool showText) : this(value, x, y, 9f, 3.2727273f, showText)
		{
		}

		// Token: 0x06004C4F RID: 19535 RVA: 0x0026B6C8 File Offset: 0x0026A6C8
		internal AustraliaPost(string A_0, float A_1, float A_2, float A_3, float A_4, bool A_5) : base(A_0, A_1, A_2, A_3, A_4, A_5)
		{
			base.FontSize = 10f;
			this.Height = 9f + BarCode.a(base.FontSize, base.Font) + 2.016f;
		}

		// Token: 0x170005D3 RID: 1491
		// (get) Token: 0x06004C50 RID: 19536 RVA: 0x0026B728 File Offset: 0x0026A728
		// (set) Token: 0x06004C51 RID: 19537 RVA: 0x0026B740 File Offset: 0x0026A740
		public bool ShowTextAbove
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

		// Token: 0x170005D4 RID: 1492
		// (get) Token: 0x06004C52 RID: 19538 RVA: 0x0026B74C File Offset: 0x0026A74C
		// (set) Token: 0x06004C53 RID: 19539 RVA: 0x0026B764 File Offset: 0x0026A764
		public AustraliaPostEncodingType CustomerDataEncoding
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

		// Token: 0x06004C54 RID: 19540 RVA: 0x0026B770 File Offset: 0x0026A770
		private float a()
		{
			return this.Height - (base.ShowText ? (BarCode.a(base.FontSize, base.Font) + 2.016f) : 0f);
		}

		// Token: 0x06004C55 RID: 19541 RVA: 0x0026B7B0 File Offset: 0x0026A7B0
		public override float GetSymbolWidth()
		{
			a a = new a(this.Value, (b)this.e);
			return (float)(a.f() / 2) * this.XDimension;
		}

		// Token: 0x06004C56 RID: 19542 RVA: 0x0026B7E4 File Offset: 0x0026A7E4
		protected override void DrawBarCode(PageWriter writer)
		{
			if (writer.Document.Tag != null)
			{
				base.a(writer);
			}
			writer.SetGraphicsMode();
			writer.SetFillColor(base.Color);
			a a = null;
			BitArray bitArray;
			try
			{
				a = new a(this.Value, (b)this.e);
				bitArray = a.g();
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			TextLineList a_ = null;
			float num = (float)(a.f() / 2) * this.XDimension;
			float textWidth = base.Font.GetTextWidth(this.Value, base.FontSize);
			float a_2 = (num < textWidth) ? textWidth : num;
			float num2 = this.Y;
			float num3 = base.a(this.Value, a_2, out a_);
			if (base.ShowText && this.ShowTextAbove)
			{
				num2 += num3 + 2.016f;
			}
			int num4 = 3 * base.PixelsPerXDimension;
			int num5 = bitArray.Length / 3;
			int num6 = 3;
			byte[] a_3 = BarCode.a(bitArray, base.PixelsPerXDimension, num4, num5, num6);
			writer.a(this.X, num2 + this.a(), num, this.a(), num5 * base.PixelsPerXDimension, num6 * num4, a_3);
			if (base.ShowText && this.ShowTextAbove)
			{
				base.a(writer, a_, this.Y);
			}
			else if (base.ShowText)
			{
				base.a(writer, a_, this.Y + this.a() + 2.016f);
			}
			if (writer.Document.Tag != null)
			{
				Tag.a(writer);
			}
		}

		// Token: 0x0400292F RID: 10543
		private new const float a = 10f;

		// Token: 0x04002930 RID: 10544
		private new const float b = 2.016f;

		// Token: 0x04002931 RID: 10545
		private const float c = 9f;

		// Token: 0x04002932 RID: 10546
		private new bool d = false;

		// Token: 0x04002933 RID: 10547
		private AustraliaPostEncodingType e = AustraliaPostEncodingType.C;
	}
}
