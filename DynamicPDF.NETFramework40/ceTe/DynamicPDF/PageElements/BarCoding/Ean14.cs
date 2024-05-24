using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x0200075E RID: 1886
	public class Ean14 : TextBarCode
	{
		// Token: 0x06004CBC RID: 19644 RVA: 0x0026D3E4 File Offset: 0x0026C3E4
		public Ean14(string value, float x, float y, float height) : base(value, x, y, height, 1f)
		{
		}

		// Token: 0x06004CBD RID: 19645 RVA: 0x0026D3F9 File Offset: 0x0026C3F9
		public Ean14(string value, float x, float y, float height, bool showText) : base(value, x, y, height, 1f, showText)
		{
		}

		// Token: 0x06004CBE RID: 19646 RVA: 0x0026D410 File Offset: 0x0026C410
		public Ean14(string value, float x, float y, float height, Font font, float fontSize) : base(value, x, y, height, 1f, true, font, fontSize)
		{
		}

		// Token: 0x06004CBF RID: 19647 RVA: 0x0026D435 File Offset: 0x0026C435
		public Ean14(string value, float x, float y, float height, float xDimension) : base(value, x, y, height, xDimension)
		{
		}

		// Token: 0x06004CC0 RID: 19648 RVA: 0x0026D447 File Offset: 0x0026C447
		public Ean14(string value, float x, float y, float height, float xDimension, bool showText) : base(value, x, y, height, xDimension, showText)
		{
		}

		// Token: 0x06004CC1 RID: 19649 RVA: 0x0026D45C File Offset: 0x0026C45C
		public Ean14(string value, float x, float y, float height, float xDimension, Font font, float fontSize) : base(value, x, y, height, xDimension, true, font, fontSize)
		{
		}

		// Token: 0x06004CC2 RID: 19650 RVA: 0x0026D480 File Offset: 0x0026C480
		public override float GetSymbolWidth()
		{
			dq dq = new dq(dq.a(this.Value), this.XDimension, 32, false, true, false);
			return dq.g();
		}

		// Token: 0x06004CC3 RID: 19651 RVA: 0x0026D4B4 File Offset: 0x0026C4B4
		protected override void DrawBarCode(PageWriter writer)
		{
			string text = dq.a(this.Value);
			dq dq = new dq(text, this.XDimension, 32, false, true, false);
			BitArray bitArray = null;
			try
			{
				bitArray = dq.f();
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			writer.SetGraphicsMode();
			if (writer.Document.Tag != null)
			{
				base.a(writer);
			}
			writer.SetFillColor(base.Color);
			float num = this.Height;
			TextLineList a_ = null;
			float num2 = dq.g();
			if (base.ShowText)
			{
				float textWidth = base.Font.GetTextWidth(text, base.FontSize);
				float a_2 = (num2 < textWidth) ? textWidth : num2;
				if (base.ShowText)
				{
					num -= base.a(text, a_2, out a_);
				}
			}
			int a_3 = bitArray.Length * base.PixelsPerXDimension;
			int num3 = 1;
			byte[] a_4 = BarCode.a(bitArray, base.PixelsPerXDimension, 1, bitArray.Length, num3);
			writer.a(this.X, this.Y + num, num2, (float)((int)num), a_3, num3, a_4);
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
