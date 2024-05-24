using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000783 RID: 1923
	public class Code39 : TextBarCode
	{
		// Token: 0x06004DF0 RID: 19952 RVA: 0x00273A98 File Offset: 0x00272A98
		public Code39(string value, float x, float y, float height) : base(value, x, y, height, 1f)
		{
		}

		// Token: 0x06004DF1 RID: 19953 RVA: 0x00273AAD File Offset: 0x00272AAD
		public Code39(string value, float x, float y, float height, bool showText) : base(value, x, y, height, 1f, showText)
		{
		}

		// Token: 0x06004DF2 RID: 19954 RVA: 0x00273AC4 File Offset: 0x00272AC4
		public Code39(string value, float x, float y, float height, Font font, float fontSize) : base(value, x, y, height, 1f, true, font, fontSize)
		{
		}

		// Token: 0x06004DF3 RID: 19955 RVA: 0x00273AE9 File Offset: 0x00272AE9
		public Code39(string value, float x, float y, float height, float xDimension) : base(value, x, y, height, xDimension)
		{
		}

		// Token: 0x06004DF4 RID: 19956 RVA: 0x00273AFB File Offset: 0x00272AFB
		public Code39(string value, float x, float y, float height, float xDimension, bool showText) : base(value, x, y, height, xDimension, showText)
		{
		}

		// Token: 0x06004DF5 RID: 19957 RVA: 0x00273B10 File Offset: 0x00272B10
		public Code39(string value, float x, float y, float height, float xDimension, Font font, float fontSize) : base(value, x, y, height, xDimension, true, font, fontSize)
		{
		}

		// Token: 0x06004DF6 RID: 19958 RVA: 0x00273B34 File Offset: 0x00272B34
		public override float GetSymbolWidth()
		{
			dr dr = new dr(this.Value, this.X, this.XDimension);
			return dr.e();
		}

		// Token: 0x06004DF7 RID: 19959 RVA: 0x00273B64 File Offset: 0x00272B64
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
				dr dr = new dr(this.Value, this.X, this.XDimension);
				bitArray = dr.d();
				num2 = dr.e();
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			float textWidth = base.Font.GetTextWidth(base.Value, base.FontSize);
			float a_2 = (num2 < textWidth) ? textWidth : num2;
			if (base.ShowText)
			{
				num -= base.a(base.Value, a_2, out a_);
			}
			int a_3 = bitArray.Length * base.PixelsPerXDimension;
			int num3 = 1;
			byte[] a_4 = BarCode.a(bitArray, base.PixelsPerXDimension, 1, bitArray.Length, num3);
			writer.a(this.X, this.Y + num, num2, (float)((int)num), a_3, num3, a_4);
			if (base.ShowText && base.ShowText)
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
