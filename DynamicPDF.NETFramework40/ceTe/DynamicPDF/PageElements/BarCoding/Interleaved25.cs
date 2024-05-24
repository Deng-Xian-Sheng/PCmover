using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x0200078C RID: 1932
	public class Interleaved25 : TextBarCode
	{
		// Token: 0x06004E22 RID: 20002 RVA: 0x0027480C File Offset: 0x0027380C
		public Interleaved25(string value, float x, float y, float height) : base(value, x, y, height, 1f)
		{
		}

		// Token: 0x06004E23 RID: 20003 RVA: 0x00274821 File Offset: 0x00273821
		public Interleaved25(string value, float x, float y, float height, bool showText) : base(value, x, y, height, 1f, showText)
		{
		}

		// Token: 0x06004E24 RID: 20004 RVA: 0x00274838 File Offset: 0x00273838
		public Interleaved25(string value, float x, float y, float height, Font font, float fontSize) : base(value, x, y, height, 1f, true, font, fontSize)
		{
		}

		// Token: 0x06004E25 RID: 20005 RVA: 0x0027485D File Offset: 0x0027385D
		public Interleaved25(string value, float x, float y, float height, float xDimension) : base(value, x, y, height, xDimension)
		{
		}

		// Token: 0x06004E26 RID: 20006 RVA: 0x0027486F File Offset: 0x0027386F
		public Interleaved25(string value, float x, float y, float height, float xDimension, bool showText) : base(value, x, y, height, xDimension, showText)
		{
		}

		// Token: 0x06004E27 RID: 20007 RVA: 0x00274884 File Offset: 0x00273884
		public Interleaved25(string value, float x, float y, float height, float xDimension, Font font, float fontSize) : base(value, x, y, height, xDimension, true, font, fontSize)
		{
		}

		// Token: 0x06004E28 RID: 20008 RVA: 0x002748A8 File Offset: 0x002738A8
		public override float GetSymbolWidth()
		{
			am am = new am(this.Value, this.X, this.XDimension);
			return am.e();
		}

		// Token: 0x06004E29 RID: 20009 RVA: 0x002748D8 File Offset: 0x002738D8
		protected override void DrawBarCode(PageWriter writer)
		{
			writer.SetGraphicsMode();
			if (writer.Document.Tag != null)
			{
				base.a(writer);
			}
			writer.SetFillColor(base.Color);
			am am;
			BitArray bitArray;
			float num;
			try
			{
				am = new am(this.Value, this.X, this.XDimension);
				bitArray = am.d();
				num = am.e();
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
			float textWidth = base.Font.GetTextWidth(am.b(), base.FontSize);
			float a_2 = (num < textWidth) ? textWidth : num;
			if (base.ShowText)
			{
				num2 -= base.a(am.b(), a_2, out a_);
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
