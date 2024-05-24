using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000780 RID: 1920
	public class Codabar : TextBarCode
	{
		// Token: 0x06004DD0 RID: 19920 RVA: 0x002730F8 File Offset: 0x002720F8
		public Codabar(string value, float x, float y, float height) : base(value, x, y, height, 1f)
		{
		}

		// Token: 0x06004DD1 RID: 19921 RVA: 0x0027310D File Offset: 0x0027210D
		public Codabar(string value, float x, float y, float height, bool showText) : base(value, x, y, height, 1f, showText)
		{
		}

		// Token: 0x06004DD2 RID: 19922 RVA: 0x00273124 File Offset: 0x00272124
		public Codabar(string value, float x, float y, float height, Font font, float fontSize) : base(value, x, y, height, 1f, true, font, fontSize)
		{
		}

		// Token: 0x06004DD3 RID: 19923 RVA: 0x00273149 File Offset: 0x00272149
		public Codabar(string value, float x, float y, float height, float xDimension) : base(value, x, y, height, xDimension)
		{
		}

		// Token: 0x06004DD4 RID: 19924 RVA: 0x0027315B File Offset: 0x0027215B
		public Codabar(string value, float x, float y, float height, float xDimension, bool showText) : base(value, x, y, height, xDimension, showText)
		{
		}

		// Token: 0x06004DD5 RID: 19925 RVA: 0x00273170 File Offset: 0x00272170
		public Codabar(string value, float x, float y, float height, float xDimension, Font font, float fontSize) : base(value, x, y, height, xDimension, true, font, fontSize)
		{
		}

		// Token: 0x06004DD6 RID: 19926 RVA: 0x00273194 File Offset: 0x00272194
		public override float GetSymbolWidth()
		{
			l l = new l(this.Value, this.X, this.XDimension);
			float result;
			try
			{
				result = l.d();
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			return result;
		}

		// Token: 0x06004DD7 RID: 19927 RVA: 0x00273200 File Offset: 0x00272200
		protected override void DrawBarCode(PageWriter writer)
		{
			writer.SetGraphicsMode();
			if (writer.Document.Tag != null)
			{
				base.a(writer);
			}
			writer.SetFillColor(base.Color);
			float num = this.Height;
			TextLineList a_ = null;
			l l = new l(this.Value, this.X, this.XDimension);
			BitArray bitArray;
			float num2;
			try
			{
				bitArray = l.c();
				num2 = l.d();
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			float textWidth = base.Font.GetTextWidth(this.Value, base.FontSize);
			float a_2 = (num2 < textWidth) ? textWidth : num2;
			if (base.ShowText)
			{
				num -= base.a(this.Value, a_2, out a_);
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
