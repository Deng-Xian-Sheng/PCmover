using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000791 RID: 1937
	public class UpcVersionE : UpcBase
	{
		// Token: 0x06004E44 RID: 20036 RVA: 0x002751D4 File Offset: 0x002741D4
		public UpcVersionE(string value, float x, float y) : base(value, x, y)
		{
		}

		// Token: 0x06004E45 RID: 20037 RVA: 0x002751E2 File Offset: 0x002741E2
		public UpcVersionE(string value, float x, float y, float scale) : base(value, x, y, scale)
		{
		}

		// Token: 0x06004E46 RID: 20038 RVA: 0x002751F4 File Offset: 0x002741F4
		public override float GetSymbolWidth()
		{
			return this.XDimension * bd.c();
		}

		// Token: 0x06004E47 RID: 20039 RVA: 0x00275214 File Offset: 0x00274214
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
			bd bd = new bd(this.Value);
			try
			{
				BitArray a_2 = bd.e();
				BitArray bitArray = bd.a(a_2);
				int a_3 = 51 * base.PixelsPerXDimension;
				int a_4 = 1;
				byte[] a_5 = BarCode.a(bitArray, base.PixelsPerXDimension, 1, bitArray.Length, a_4);
				writer.a(this.X + this.XDimension * 8f, this.Y + num2, 51f * this.XDimension, num2, a_3, 1, a_5);
				BitArray bitArray2 = bd.b(a_2);
				a_5 = BarCode.a(bitArray2, base.PixelsPerXDimension, 1, bitArray2.Length, a_4);
				writer.a(this.X + this.XDimension * 8f, this.Y + num, 51f * this.XDimension, num, a_3, 1, a_5);
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			this.a(writer, bd.d(), a_);
			if (writer.Document.Tag != null && !base.j())
			{
				writer.SetGraphicsMode();
				Tag.a(writer);
			}
		}

		// Token: 0x06004E48 RID: 20040 RVA: 0x002753C0 File Offset: 0x002743C0
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
			num += this.XDimension * 50f;
			A_0.SetFont(Font.CourierBold, A_2 * 0.75f);
			A_0.Write_Tm(num, y);
			A_0.b(A_1, 7, 1, false);
		}

		// Token: 0x02000792 RID: 1938
		private new enum a
		{
			// Token: 0x04002A50 RID: 10832
			a,
			// Token: 0x04002A51 RID: 10833
			b
		}
	}
}
