using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x0200078D RID: 1933
	public class Postnet : BarCode
	{
		// Token: 0x06004E2A RID: 20010 RVA: 0x00274A64 File Offset: 0x00273A64
		public Postnet(string value, float x, float y) : base(value, x, y, 9f, 3.2727273f)
		{
		}

		// Token: 0x1700061F RID: 1567
		// (get) Token: 0x06004E2B RID: 20011 RVA: 0x00274A84 File Offset: 0x00273A84
		// (set) Token: 0x06004E2C RID: 20012 RVA: 0x00274A9C File Offset: 0x00273A9C
		public Calculate AppendCheckDigit
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

		// Token: 0x06004E2D RID: 20013 RVA: 0x00274AA8 File Offset: 0x00273AA8
		public override float GetSymbolWidth()
		{
			ay ay = new ay(this.Value, this.XDimension, (int)this.AppendCheckDigit);
			return ay.d();
		}

		// Token: 0x06004E2E RID: 20014 RVA: 0x00274AD8 File Offset: 0x00273AD8
		protected override void DrawBarCode(PageWriter writer)
		{
			writer.SetGraphicsMode();
			if (writer.Document.Tag != null)
			{
				base.a(writer);
			}
			writer.SetFillColor(base.Color);
			ay ay;
			BitArray bitArray;
			try
			{
				ay = new ay(this.Value, this.XDimension, (int)this.AppendCheckDigit);
				bitArray = ay.f();
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			int num = 3 * base.PixelsPerXDimension;
			int num2 = bitArray.Length / 3;
			int num3 = 3;
			byte[] a_ = BarCode.a(bitArray, base.PixelsPerXDimension, num, num2, num3);
			writer.a(this.X, this.Y + this.Height, ay.d(), this.Height, num2 * base.PixelsPerXDimension, num3 * num, a_);
			if (writer.Document.Tag != null)
			{
				Tag.a(writer);
			}
		}

		// Token: 0x04002A4C RID: 10828
		private new Calculate a = Calculate.Auto;
	}
}
