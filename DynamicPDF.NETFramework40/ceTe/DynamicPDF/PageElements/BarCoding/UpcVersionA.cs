using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x0200078E RID: 1934
	public class UpcVersionA : UpcBase
	{
		// Token: 0x06004E2F RID: 20015 RVA: 0x00274BF4 File Offset: 0x00273BF4
		public UpcVersionA(string value, float x, float y) : base(value, x, y)
		{
		}

		// Token: 0x06004E30 RID: 20016 RVA: 0x00274C02 File Offset: 0x00273C02
		public UpcVersionA(string value, float x, float y, float scale) : base(value, x, y, scale)
		{
		}

		// Token: 0x06004E31 RID: 20017 RVA: 0x00274C14 File Offset: 0x00273C14
		public override float GetSymbolWidth()
		{
			return this.XDimension * bc.c();
		}

		// Token: 0x06004E32 RID: 20018 RVA: 0x00274C34 File Offset: 0x00273C34
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
			bc bc;
			try
			{
				bc = new bc(this.Value);
				BitArray a_2 = bc.e();
				BitArray bitArray = bc.a(a_2);
				int a_3 = 95 * base.PixelsPerXDimension;
				int a_4 = 1;
				byte[] a_5 = BarCode.a(bitArray, base.PixelsPerXDimension, 1, bitArray.Length, a_4);
				writer.a(this.X + this.XDimension * 8f, this.Y + num2, 95f * this.XDimension, num2, a_3, 1, a_5);
				BitArray bitArray2 = bc.b(a_2);
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
			this.a(writer, bc.d(), a_);
			if (writer.Document.Tag != null && !base.j())
			{
				writer.SetGraphicsMode();
				Tag.a(writer);
			}
		}

		// Token: 0x06004E33 RID: 20019 RVA: 0x00274DE0 File Offset: 0x00273DE0
		private void a(PageWriter A_0, char[] A_1, float A_2)
		{
			A_0.SetTextMode();
			float y = base.d();
			float num = this.X;
			A_0.SetFont(Font.CourierBold, A_2 * 0.75f);
			A_0.Write_Tm(num, y);
			A_0.b(A_1, 0, 1, false);
			num += this.XDimension * 18f;
			A_0.SetFont(Font.CourierBold, A_2);
			A_0.Write_Tm(num, y);
			A_0.b(A_1, 1, 5, false);
			num += this.XDimension * 39f;
			A_0.Write_Tm(num, y);
			A_0.b(A_1, 6, 5, false);
			num += this.XDimension * 48f;
			A_0.SetFont(Font.CourierBold, A_2 * 0.75f);
			A_0.Write_Tm(num, y);
			A_0.b(A_1, 11, 1, false);
		}
	}
}
