using System;
using System.Collections;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000756 RID: 1878
	public class Code11 : TextBarCode
	{
		// Token: 0x06004C89 RID: 19593 RVA: 0x0026C4A8 File Offset: 0x0026B4A8
		public Code11(string value, float x, float y, float height) : base(value, x, y, height, 1f)
		{
		}

		// Token: 0x06004C8A RID: 19594 RVA: 0x0026C4BD File Offset: 0x0026B4BD
		public Code11(string value, float x, float y, float height, bool showText) : base(value, x, y, height, 1f, showText)
		{
		}

		// Token: 0x06004C8B RID: 19595 RVA: 0x0026C4D4 File Offset: 0x0026B4D4
		public Code11(string value, float x, float y, float height, Font font, float fontSize) : base(value, x, y, height, 1f, true, font, fontSize)
		{
		}

		// Token: 0x06004C8C RID: 19596 RVA: 0x0026C4F9 File Offset: 0x0026B4F9
		public Code11(string value, float x, float y, float height, float xDimension) : base(value, x, y, height, xDimension)
		{
		}

		// Token: 0x06004C8D RID: 19597 RVA: 0x0026C50B File Offset: 0x0026B50B
		public Code11(string value, float x, float y, float height, float xDimension, bool showText) : base(value, x, y, height, xDimension, showText)
		{
		}

		// Token: 0x06004C8E RID: 19598 RVA: 0x0026C520 File Offset: 0x0026B520
		public Code11(string value, float x, float y, float height, float xDimension, Font font, float fontSize) : base(value, x, y, height, xDimension, true, font, fontSize)
		{
		}

		// Token: 0x06004C8F RID: 19599 RVA: 0x0026C544 File Offset: 0x0026B544
		public override float GetSymbolWidth()
		{
			m m = new m(this.Value);
			return (float)m.g() * this.XDimension;
		}

		// Token: 0x06004C90 RID: 19600 RVA: 0x0026C570 File Offset: 0x0026B570
		protected override void DrawBarCode(PageWriter writer)
		{
			writer.SetGraphicsMode();
			if (writer.Document.Tag != null)
			{
				base.a(writer);
			}
			writer.SetFillColor(base.Color);
			m m = new m(this.Value);
			TextLineList a_ = null;
			float num = base.Height;
			try
			{
				BitArray bitArray = m.f();
				float num2 = (float)m.g() * this.XDimension;
				float textWidth = base.Font.GetTextWidth(Encoding.ASCII.GetChars(m.e()), base.FontSize);
				float a_2 = (num2 < textWidth) ? textWidth : num2;
				if (base.ShowText)
				{
					num -= base.a(Encoding.ASCII.GetChars(m.e()), a_2, out a_);
				}
				int a_3 = bitArray.Length * base.PixelsPerXDimension;
				int num3 = 1;
				byte[] a_4 = BarCode.a(bitArray, base.PixelsPerXDimension, 1, bitArray.Length, num3);
				writer.a(this.X, this.Y + num, num2, (float)((int)num), a_3, num3, a_4);
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			if (base.ShowText)
			{
				base.a(writer, a_, this.Y + num);
			}
			if (writer.Document.Tag != null)
			{
				writer.SetGraphicsMode();
				Tag.a(writer);
			}
		}
	}
}
