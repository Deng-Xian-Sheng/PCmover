using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x0200076F RID: 1903
	public class Itf14 : TextBarCode
	{
		// Token: 0x06004D35 RID: 19765 RVA: 0x0026FDD0 File Offset: 0x0026EDD0
		public Itf14(string value, float x, float y, float height) : base(value, x, y, height, 1f)
		{
		}

		// Token: 0x06004D36 RID: 19766 RVA: 0x0026FDF4 File Offset: 0x0026EDF4
		public Itf14(string value, float x, float y, float height, bool showText) : base(value, x, y, height, 1f, showText)
		{
		}

		// Token: 0x06004D37 RID: 19767 RVA: 0x0026FE1C File Offset: 0x0026EE1C
		public Itf14(string value, float x, float y, float height, Font font, float fontSize) : base(value, x, y, height, 1f, true, font, fontSize)
		{
		}

		// Token: 0x06004D38 RID: 19768 RVA: 0x0026FE50 File Offset: 0x0026EE50
		public Itf14(string value, float x, float y, float height, float xDimension) : base(value, x, y, height, xDimension)
		{
		}

		// Token: 0x06004D39 RID: 19769 RVA: 0x0026FE71 File Offset: 0x0026EE71
		public Itf14(string value, float x, float y, float height, float xDimension, bool showText) : base(value, x, y, height, xDimension, showText)
		{
		}

		// Token: 0x06004D3A RID: 19770 RVA: 0x0026FE94 File Offset: 0x0026EE94
		public Itf14(string value, float x, float y, float height, float xDimension, Font font, float fontSize) : base(value, x, y, height, xDimension, true, font, fontSize)
		{
		}

		// Token: 0x170005F4 RID: 1524
		// (get) Token: 0x06004D3B RID: 19771 RVA: 0x0026FEC8 File Offset: 0x0026EEC8
		// (set) Token: 0x06004D3C RID: 19772 RVA: 0x0026FEE0 File Offset: 0x0026EEE0
		public int BearerBarWidthMultiple
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

		// Token: 0x170005F5 RID: 1525
		// (get) Token: 0x06004D3D RID: 19773 RVA: 0x0026FEEC File Offset: 0x0026EEEC
		// (set) Token: 0x06004D3E RID: 19774 RVA: 0x0026FF04 File Offset: 0x0026EF04
		public bool ShowVerticalBearerBars
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x06004D3F RID: 19775 RVA: 0x0026FF10 File Offset: 0x0026EF10
		public override float GetSymbolWidth()
		{
			aq aq = new aq(this.Value);
			float num = (float)aq.b();
			float result;
			if (this.b)
			{
				result = (float)this.a * this.XDimension * 2f + num + (float)(2 * this.c) * this.XDimension;
			}
			else
			{
				result = num + (float)(2 * this.c) * this.XDimension;
			}
			return result;
		}

		// Token: 0x06004D40 RID: 19776 RVA: 0x0026FF80 File Offset: 0x0026EF80
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
			aq aq = null;
			BitArray bitArray;
			float num2;
			float num3;
			try
			{
				aq = new aq(this.Value);
				bitArray = aq.c();
				num2 = (float)aq.b();
				if (this.b)
				{
					num3 = num2 + (float)(2 * this.c) * this.XDimension + (float)(2 * this.a) * this.XDimension;
				}
				else
				{
					num3 = num2 + (float)(2 * this.c) * this.XDimension;
				}
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			float textWidth = base.Font.GetTextWidth(aq.a(), base.FontSize);
			float a_2 = (num3 < textWidth) ? textWidth : num3;
			if (base.ShowText)
			{
				num -= base.a(aq.a(), a_2, out a_);
			}
			int a_3 = bitArray.Length * base.PixelsPerXDimension;
			int num4 = 1;
			byte[] a_4 = BarCode.a(bitArray, base.PixelsPerXDimension, 1, bitArray.Length, num4);
			float num5 = this.XDimension * (float)this.a;
			num -= 2f * num5;
			writer.Write_re(this.X, this.Y, num3, num5);
			writer.Write_f();
			if (this.b)
			{
				writer.Write_re(this.X, this.Y + num5, num5, num);
				writer.Write_f();
				writer.Write_re(this.X + num2 + (float)(2 * this.c) * this.XDimension + num5, this.Y + num5, num5, num);
				writer.Write_f();
				writer.a(this.X + (float)this.c * this.XDimension + num5, this.Y + num + num5, num2, num, a_3, num4, a_4);
			}
			else
			{
				writer.a(this.X + (float)this.c * this.XDimension, this.Y + num + num5, num2, num, a_3, num4, a_4);
			}
			writer.Write_re(this.X, this.Y + num5 + num, num3, num5);
			writer.Write_f();
			if (base.ShowText && base.ShowText)
			{
				base.a(writer, a_, this.Y + num + 2f * num5);
			}
			if (writer.Document.Tag != null)
			{
				writer.SetGraphicsMode();
				Tag.a(writer);
			}
		}

		// Token: 0x040029C2 RID: 10690
		private new int a = 3;

		// Token: 0x040029C3 RID: 10691
		private new bool b;

		// Token: 0x040029C4 RID: 10692
		private int c = 10;
	}
}
