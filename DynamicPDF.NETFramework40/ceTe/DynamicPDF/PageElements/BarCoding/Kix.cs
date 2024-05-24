using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000770 RID: 1904
	public class Kix : TextBarCode
	{
		// Token: 0x06004D41 RID: 19777 RVA: 0x00270270 File Offset: 0x0026F270
		public Kix(string value, float x, float y) : this(value, x, y, 9f, 3.2727273f, false)
		{
		}

		// Token: 0x06004D42 RID: 19778 RVA: 0x00270289 File Offset: 0x0026F289
		public Kix(string value, float x, float y, bool showText) : this(value, x, y, 9f, 3.2727273f, showText)
		{
		}

		// Token: 0x06004D43 RID: 19779 RVA: 0x002702A4 File Offset: 0x0026F2A4
		internal Kix(string A_0, float A_1, float A_2, float A_3, float A_4, bool A_5) : base(A_0, A_1, A_2, A_3, A_4, A_5)
		{
			base.FontSize = 10f;
			TextLineList textLineList = null;
			float textWidth = base.Font.GetTextWidth(this.Value, base.FontSize);
			this.Height = 9f + base.a(this.Value, textWidth, out textLineList) + 2.016f;
		}

		// Token: 0x06004D44 RID: 19780 RVA: 0x00270314 File Offset: 0x0026F314
		internal float a()
		{
			return this.Height - (base.ShowText ? (BarCode.a(base.FontSize, base.Font) + 2.016f) : 0f);
		}

		// Token: 0x06004D45 RID: 19781 RVA: 0x00270354 File Offset: 0x0026F354
		public override float GetSymbolWidth()
		{
			a5 a = new a5(this.Value, this.XDimension, false, false);
			return a.b();
		}

		// Token: 0x06004D46 RID: 19782 RVA: 0x00270380 File Offset: 0x0026F380
		protected override void DrawBarCode(PageWriter writer)
		{
			writer.SetGraphicsMode();
			if (writer.Document.Tag != null)
			{
				base.a(writer);
			}
			writer.SetFillColor(base.Color);
			TextLineList a_ = null;
			BitArray bitArray = null;
			a5 a = null;
			try
			{
				a = new a5(this.Value, this.XDimension, false, false);
				bitArray = a.d();
			}
			catch (ap)
			{
				throw new InvalidValueBarCodeException("Invalid Dutch KIX barcode value, allows only 0-9 and A-Z");
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			float num = a.b();
			float textWidth = base.Font.GetTextWidth(this.Value, base.FontSize);
			float a_2 = (num < textWidth) ? textWidth : num;
			float num2 = this.Y;
			float num3 = base.a(this.Value, a_2, out a_);
			if (base.ShowText && this.d)
			{
				num2 += num3 + 2.016f;
			}
			int num4 = 3 * base.PixelsPerXDimension;
			int num5 = bitArray.Length / 3;
			int num6 = 3;
			byte[] a_3 = BarCode.a(bitArray, base.PixelsPerXDimension, num4, num5, num6);
			writer.a(this.X, num2 + this.a(), num, this.a(), num5 * base.PixelsPerXDimension, num6 * num4, a_3);
			if (base.ShowText && this.d)
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

		// Token: 0x040029C5 RID: 10693
		private new const float a = 10f;

		// Token: 0x040029C6 RID: 10694
		private new const float b = 2.016f;

		// Token: 0x040029C7 RID: 10695
		private const float c = 9f;

		// Token: 0x040029C8 RID: 10696
		private new bool d = false;
	}
}
