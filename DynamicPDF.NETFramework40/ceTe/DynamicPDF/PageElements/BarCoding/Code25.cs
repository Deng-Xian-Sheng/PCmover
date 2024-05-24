using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000782 RID: 1922
	public class Code25 : TextBarCode
	{
		// Token: 0x06004DE8 RID: 19944 RVA: 0x00273844 File Offset: 0x00272844
		public Code25(string value, float x, float y, float height) : base(value, x, y, height, 1f)
		{
		}

		// Token: 0x06004DE9 RID: 19945 RVA: 0x00273859 File Offset: 0x00272859
		public Code25(string value, float x, float y, float height, bool showText) : base(value, x, y, height, 1f, showText)
		{
		}

		// Token: 0x06004DEA RID: 19946 RVA: 0x00273870 File Offset: 0x00272870
		public Code25(string value, float x, float y, float height, Font font, float fontSize) : base(value, x, y, height, 1f, true, font, fontSize)
		{
		}

		// Token: 0x06004DEB RID: 19947 RVA: 0x00273895 File Offset: 0x00272895
		public Code25(string value, float x, float y, float height, float xDimension) : base(value, x, y, height, xDimension)
		{
		}

		// Token: 0x06004DEC RID: 19948 RVA: 0x002738A7 File Offset: 0x002728A7
		public Code25(string value, float x, float y, float height, float xDimension, bool showText) : base(value, x, y, height, xDimension, showText)
		{
		}

		// Token: 0x06004DED RID: 19949 RVA: 0x002738BC File Offset: 0x002728BC
		public Code25(string value, float x, float y, float height, float xDimension, Font font, float fontSize) : base(value, x, y, height, xDimension, true, font, fontSize)
		{
		}

		// Token: 0x06004DEE RID: 19950 RVA: 0x002738E0 File Offset: 0x002728E0
		public override float GetSymbolWidth()
		{
			n n = new n(this.Value, this.X, this.XDimension);
			return n.b();
		}

		// Token: 0x06004DEF RID: 19951 RVA: 0x00273910 File Offset: 0x00272910
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
			BitArray bitArray;
			float num2;
			try
			{
				n n = new n(this.Value, this.X, this.XDimension);
				bitArray = n.c();
				num2 = n.b();
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
