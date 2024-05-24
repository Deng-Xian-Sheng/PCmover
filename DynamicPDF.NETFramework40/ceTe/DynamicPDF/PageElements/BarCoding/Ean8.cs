using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000788 RID: 1928
	public class Ean8 : UpcBase
	{
		// Token: 0x06004E0D RID: 19981 RVA: 0x002742A8 File Offset: 0x002732A8
		public Ean8(string value, float x, float y) : base(value, x, y)
		{
		}

		// Token: 0x06004E0E RID: 19982 RVA: 0x002742B6 File Offset: 0x002732B6
		public Ean8(string value, float x, float y, float scale) : base(value, x, y, scale)
		{
		}

		// Token: 0x06004E0F RID: 19983 RVA: 0x002742C8 File Offset: 0x002732C8
		public override float GetSymbolWidth()
		{
			return this.XDimension * ae.c();
		}

		// Token: 0x06004E10 RID: 19984 RVA: 0x002742E8 File Offset: 0x002732E8
		protected override void DrawBarCode(PageWriter writer)
		{
			writer.SetGraphicsMode();
			if (writer.Document.Tag != null)
			{
				base.a(writer);
			}
			writer.SetFillColor(base.Color);
			writer.SetTextDefaults();
			float a_ = base.c();
			float num = base.f();
			float num2 = base.g();
			ae ae;
			try
			{
				ae = new ae(this.Value);
				BitArray a_2 = ae.e();
				BitArray bitArray = ae.a(a_2);
				int a_3 = 67 * base.PixelsPerXDimension;
				int a_4 = 1;
				byte[] a_5 = BarCode.a(bitArray, base.PixelsPerXDimension, 1, bitArray.Length, a_4);
				writer.a(this.X, this.Y + num2, 67f * this.XDimension, num2, a_3, 1, a_5);
				BitArray bitArray2 = ae.b(a_2);
				a_5 = BarCode.a(bitArray2, base.PixelsPerXDimension, 1, bitArray2.Length, a_4);
				writer.a(this.X, this.Y + num, 67f * this.XDimension, num, a_3, 1, a_5);
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			this.a(writer, ae.d(), a_);
			if (writer.Document.Tag != null && !base.j())
			{
				writer.SetGraphicsMode();
				Tag.a(writer);
			}
		}

		// Token: 0x06004E11 RID: 19985 RVA: 0x00274478 File Offset: 0x00273478
		private void a(PageWriter A_0, char[] A_1, float A_2)
		{
			A_0.SetTextMode();
			float y = base.d();
			float num = this.X + this.XDimension * 3f;
			A_0.SetFont(Font.CourierBold, A_2);
			A_0.Write_Tm(num, y);
			A_0.b(A_1, 0, 4, false);
			num += this.XDimension * 32f;
			A_0.Write_Tm(num, y);
			A_0.b(A_1, 4, 4, false);
		}
	}
}
