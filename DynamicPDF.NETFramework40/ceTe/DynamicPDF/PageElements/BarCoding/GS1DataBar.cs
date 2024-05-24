using System;
using System.Collections;
using System.Collections.Generic;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000760 RID: 1888
	public class GS1DataBar : TextBarCode
	{
		// Token: 0x06004CC5 RID: 19653 RVA: 0x0026D660 File Offset: 0x0026C660
		public GS1DataBar(string value, float x, float y, float height, GS1DataBarType gs1type) : this(value, x, y, height, 1.5f, true, Font.Helvetica, 12f, gs1type)
		{
		}

		// Token: 0x06004CC6 RID: 19654 RVA: 0x0026D690 File Offset: 0x0026C690
		public GS1DataBar(string value, float x, float y, float height, GS1DataBarType gs1type, bool showText) : this(value, x, y, height, 1.5f, showText, Font.Helvetica, 12f, gs1type)
		{
		}

		// Token: 0x06004CC7 RID: 19655 RVA: 0x0026D6C0 File Offset: 0x0026C6C0
		public GS1DataBar(string value, float x, float y, float height, GS1DataBarType gs1type, Font font, float fontSize) : this(value, x, y, height, 1.5f, true, font, fontSize, gs1type)
		{
		}

		// Token: 0x06004CC8 RID: 19656 RVA: 0x0026D6E8 File Offset: 0x0026C6E8
		public GS1DataBar(string value, float x, float y, float height, GS1DataBarType gs1type, float xDimension) : this(value, x, y, height, xDimension, true, Font.Helvetica, 12f, gs1type)
		{
		}

		// Token: 0x06004CC9 RID: 19657 RVA: 0x0026D714 File Offset: 0x0026C714
		public GS1DataBar(string value, float x, float y, float height, GS1DataBarType gs1type, float xDimension, bool showText) : this(value, x, y, height, xDimension, showText, Font.Helvetica, 12f, gs1type)
		{
		}

		// Token: 0x06004CCA RID: 19658 RVA: 0x0026D740 File Offset: 0x0026C740
		public GS1DataBar(string value, float x, float y, float height, GS1DataBarType gs1type, float xDimension, Font font, float fontSize) : this(value, x, y, height, xDimension, true, font, fontSize, gs1type)
		{
		}

		// Token: 0x06004CCB RID: 19659 RVA: 0x0026D764 File Offset: 0x0026C764
		private GS1DataBar(string A_0, float A_1, float A_2, float A_3, float A_4, bool A_5, Font A_6, float A_7, GS1DataBarType A_8) : base(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7)
		{
			this.a = A_8;
		}

		// Token: 0x06004CCC RID: 19660 RVA: 0x0026D798 File Offset: 0x0026C798
		public override float GetSymbolWidth()
		{
			float result;
			try
			{
				ag ag = new ag(base.Value, (int)this.a, this.b, 0, false);
				result = (float)((int)ag.k()) * this.XDimension;
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (ao ao)
			{
				throw new dt(ao.Message);
			}
			catch (an an)
			{
				throw new ds(an.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			return result;
		}

		// Token: 0x06004CCD RID: 19661 RVA: 0x0026D848 File Offset: 0x0026C848
		protected override void DrawBarCode(PageWriter writer)
		{
			writer.SetGraphicsMode();
			if (writer.Document.Tag != null)
			{
				base.a(writer);
			}
			writer.SetFillColor(base.Color);
			ag ag = null;
			BitArray bitArray = null;
			try
			{
				ag = new ag(base.Value, (int)this.a, this.b, 0, false);
				bitArray = ag.j()[0];
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (ao ao)
			{
				throw new dt(ao.Message);
			}
			catch (an an)
			{
				throw new ds(an.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			float num = (float)bitArray.Length * this.XDimension;
			float num2 = this.Height;
			List<string> list = new List<string>();
			float num3 = 0f;
			if (base.ShowText)
			{
				num2 = this.Height - base.a(ag.h(), num, out list, out num3);
			}
			float num4 = this.Y;
			int a_ = bitArray.Length * base.PixelsPerXDimension;
			int num5 = 1;
			byte[] a_2 = BarCode.a(bitArray, base.PixelsPerXDimension, 1, bitArray.Length, num5);
			writer.a(this.X, num4 += num2, num, num2, a_, num5, a_2);
			if (base.ShowText)
			{
				writer.SetTextMode();
				writer.SetTextDefaults();
				writer.SetFont(base.Font, base.FontSize);
				writer.SetFillColor(base.TextColor);
				num4 += base.Font.GetBaseLine(base.FontSize, base.Font.GetDefaultLeading(base.FontSize));
				foreach (string text in list)
				{
					switch (base.TextAlign)
					{
					case Align.Left:
						writer.Write_Tm(this.X, num4);
						break;
					case Align.Center:
						writer.Write_Tm(this.X + (num - base.Font.GetTextWidth(text, base.FontSize)) / 2f, num4);
						break;
					default:
						writer.Write_Tm(this.X + num - base.Font.GetTextWidth(text, base.FontSize), num4);
						break;
					}
					writer.Write_Tj_(text.ToCharArray(), false);
					num4 += num3;
				}
			}
			if (writer.Document.Tag != null)
			{
				writer.SetGraphicsMode();
				Tag.a(writer);
			}
		}

		// Token: 0x040029A4 RID: 10660
		private new GS1DataBarType a;

		// Token: 0x040029A5 RID: 10661
		private new bool b = false;
	}
}
