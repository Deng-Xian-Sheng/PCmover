using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000785 RID: 1925
	public class Ean13 : UpcBase
	{
		// Token: 0x06004DF8 RID: 19960 RVA: 0x00273CFC File Offset: 0x00272CFC
		public Ean13(string value, float x, float y) : base(value, x, y)
		{
		}

		// Token: 0x06004DF9 RID: 19961 RVA: 0x00273D0A File Offset: 0x00272D0A
		public Ean13(string value, float x, float y, float scale) : base(value, x, y, scale)
		{
		}

		// Token: 0x06004DFA RID: 19962 RVA: 0x00273D1C File Offset: 0x00272D1C
		public override float GetSymbolWidth()
		{
			return this.XDimension * (float)ad.c();
		}

		// Token: 0x06004DFB RID: 19963 RVA: 0x00273D3C File Offset: 0x00272D3C
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
			ad ad;
			try
			{
				ad = new ad(this.Value);
				BitArray a_2 = ad.e();
				BitArray bitArray = ad.a(a_2);
				int a_3 = 95 * base.PixelsPerXDimension;
				int a_4 = 1;
				byte[] a_5 = BarCode.a(bitArray, base.PixelsPerXDimension, 1, bitArray.Length, a_4);
				writer.a(this.X + this.XDimension * 8f, this.Y + num2, 95f * this.XDimension, num2, a_3, 1, a_5);
				BitArray bitArray2 = ad.b(a_2);
				a_5 = BarCode.a(bitArray2, base.PixelsPerXDimension, 1, bitArray2.Length, a_4);
				writer.a(this.X + this.XDimension * 8f, this.Y + num, 95f * this.XDimension, num, a_3, 1, a_5);
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			this.a(writer, ad.d(), a_);
			if (writer.Document.Tag != null && !base.j())
			{
				writer.SetGraphicsMode();
				Tag.a(writer);
			}
		}

		// Token: 0x06004DFC RID: 19964 RVA: 0x00273EE8 File Offset: 0x00272EE8
		private void a(PageWriter A_0, char[] A_1, float A_2)
		{
			A_0.SetTextMode();
			float y = base.d();
			float num = this.X;
			A_0.SetFont(Font.CourierBold, A_2 * 0.75f);
			A_0.Write_Tm(num, y);
			A_0.b(A_1, 0, 1, false);
			num += this.XDimension * 11f;
			A_0.SetFont(Font.CourierBold, A_2);
			A_0.Write_Tm(num, y);
			A_0.b(A_1, 1, 6, false);
			num += this.XDimension * 46f;
			A_0.Write_Tm(num, y);
			A_0.b(A_1, 7, 6, false);
		}
	}
}
