using System;
using System.Collections;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000773 RID: 1907
	public class MsiBarcode : TextBarCode
	{
		// Token: 0x06004D7B RID: 19835 RVA: 0x00271754 File Offset: 0x00270754
		public MsiBarcode(string value, float x, float y, float height) : base(value, x, y, height, 1f)
		{
		}

		// Token: 0x06004D7C RID: 19836 RVA: 0x00271770 File Offset: 0x00270770
		public MsiBarcode(string value, float x, float y, float height, bool showText) : base(value, x, y, height, 1f, showText)
		{
		}

		// Token: 0x06004D7D RID: 19837 RVA: 0x00271790 File Offset: 0x00270790
		public MsiBarcode(string value, float x, float y, float height, Font font, float fontSize) : base(value, x, y, height, 1f, true, font, fontSize)
		{
		}

		// Token: 0x06004D7E RID: 19838 RVA: 0x002717BC File Offset: 0x002707BC
		public MsiBarcode(string value, float x, float y, float height, float xDimension) : base(value, x, y, height, xDimension)
		{
		}

		// Token: 0x06004D7F RID: 19839 RVA: 0x002717D5 File Offset: 0x002707D5
		public MsiBarcode(string value, float x, float y, float height, float xDimension, bool showText) : base(value, x, y, height, xDimension, showText)
		{
		}

		// Token: 0x06004D80 RID: 19840 RVA: 0x002717F0 File Offset: 0x002707F0
		public MsiBarcode(string value, float x, float y, float height, float xDimension, Font font, float fontSize) : base(value, x, y, height, xDimension, true, font, fontSize)
		{
		}

		// Token: 0x17000605 RID: 1541
		// (get) Token: 0x06004D81 RID: 19841 RVA: 0x0027181C File Offset: 0x0027081C
		// (set) Token: 0x06004D82 RID: 19842 RVA: 0x00271834 File Offset: 0x00270834
		public MsiBarcodeCheckDigitMode AppendCheckDigit
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

		// Token: 0x06004D83 RID: 19843 RVA: 0x00271840 File Offset: 0x00270840
		public override float GetSymbolWidth()
		{
			@as @as = new @as(this.Value, this.X, this.XDimension, (int)this.AppendCheckDigit);
			return @as.e();
		}

		// Token: 0x06004D84 RID: 19844 RVA: 0x00271878 File Offset: 0x00270878
		protected override void DrawBarCode(PageWriter writer)
		{
			writer.SetGraphicsMode();
			if (writer.Document.Tag != null)
			{
				base.a(writer);
			}
			writer.SetFillColor(base.Color);
			float num = base.Height;
			TextLineList a_ = null;
			@as @as = null;
			BitArray bitArray = null;
			try
			{
				@as = new @as(this.Value, this.X, this.XDimension, (int)this.AppendCheckDigit);
				bitArray = @as.f();
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			float num2 = @as.e();
			float textWidth = base.Font.GetTextWidth(Encoding.ASCII.GetChars(@as.c()), base.FontSize);
			float a_2 = (num2 < textWidth) ? textWidth : num2;
			if (base.ShowText)
			{
				num -= base.a(Encoding.ASCII.GetChars(@as.c()), a_2, out a_);
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

		// Token: 0x040029CB RID: 10699
		private new MsiBarcodeCheckDigitMode a = MsiBarcodeCheckDigitMode.Mod10;
	}
}
