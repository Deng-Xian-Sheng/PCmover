using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x0200075D RID: 1885
	public class DeutschePostLeitcode : TextBarCode
	{
		// Token: 0x06004CB4 RID: 19636 RVA: 0x0026D1A0 File Offset: 0x0026C1A0
		public DeutschePostLeitcode(string value, float x, float y, float height) : base(value, x, y, height, 1f)
		{
		}

		// Token: 0x06004CB5 RID: 19637 RVA: 0x0026D1B5 File Offset: 0x0026C1B5
		public DeutschePostLeitcode(string value, float x, float y, float height, bool showText) : base(value, x, y, height, 1f, showText)
		{
		}

		// Token: 0x06004CB6 RID: 19638 RVA: 0x0026D1CC File Offset: 0x0026C1CC
		public DeutschePostLeitcode(string value, float x, float y, float height, Font font, float fontSize) : base(value, x, y, height, 1f, true, font, fontSize)
		{
		}

		// Token: 0x06004CB7 RID: 19639 RVA: 0x0026D1F1 File Offset: 0x0026C1F1
		public DeutschePostLeitcode(string value, float x, float y, float height, float xDimension) : base(value, x, y, height, xDimension)
		{
		}

		// Token: 0x06004CB8 RID: 19640 RVA: 0x0026D203 File Offset: 0x0026C203
		public DeutschePostLeitcode(string value, float x, float y, float height, float xDimension, bool showText) : base(value, x, y, height, xDimension, showText)
		{
		}

		// Token: 0x06004CB9 RID: 19641 RVA: 0x0026D218 File Offset: 0x0026C218
		public DeutschePostLeitcode(string value, float x, float y, float height, float xDimension, Font font, float fontSize) : base(value, x, y, height, xDimension, true, font, fontSize)
		{
		}

		// Token: 0x06004CBA RID: 19642 RVA: 0x0026D23C File Offset: 0x0026C23C
		public override float GetSymbolWidth()
		{
			ab ab = new ab(this.Value);
			return (float)ab.a();
		}

		// Token: 0x06004CBB RID: 19643 RVA: 0x0026D264 File Offset: 0x0026C264
		protected override void DrawBarCode(PageWriter writer)
		{
			writer.SetGraphicsMode();
			if (writer.Document.Tag != null)
			{
				base.a(writer);
			}
			writer.SetFillColor(base.Color);
			ab ab;
			BitArray bitArray;
			float num;
			try
			{
				ab = new ab(this.Value);
				bitArray = ab.b();
				num = (float)ab.a();
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			float num2 = this.Height;
			TextLineList a_ = null;
			float textWidth = base.Font.GetTextWidth(ab.c(), base.FontSize);
			float a_2 = (num < textWidth) ? textWidth : num;
			if (base.ShowText)
			{
				num2 -= base.a(ab.c(), a_2, out a_);
			}
			int a_3 = bitArray.Length * base.PixelsPerXDimension;
			int num3 = 1;
			byte[] a_4 = BarCode.a(bitArray, base.PixelsPerXDimension, 1, bitArray.Length, num3);
			writer.a(this.X, this.Y + num2, num, (float)((int)num2), a_3, num3, a_4);
			if (base.ShowText)
			{
				base.a(writer, a_, this.Y + num2);
			}
			if (writer.Document.Tag != null)
			{
				writer.SetGraphicsMode();
				Tag.a(writer);
			}
		}
	}
}
