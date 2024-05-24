using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000757 RID: 1879
	public class Code93 : TextBarCode
	{
		// Token: 0x06004C91 RID: 19601 RVA: 0x0026C708 File Offset: 0x0026B708
		public Code93(string value, float x, float y, float height) : base(value, x, y, height, 1f)
		{
		}

		// Token: 0x06004C92 RID: 19602 RVA: 0x0026C71D File Offset: 0x0026B71D
		public Code93(string value, float x, float y, float height, bool showText) : base(value, x, y, height, 1f, showText)
		{
		}

		// Token: 0x06004C93 RID: 19603 RVA: 0x0026C734 File Offset: 0x0026B734
		public Code93(string value, float x, float y, float height, Font font, float fontSize) : base(value, x, y, height, 1f, true, font, fontSize)
		{
		}

		// Token: 0x06004C94 RID: 19604 RVA: 0x0026C759 File Offset: 0x0026B759
		public Code93(string value, float x, float y, float height, float xDimension) : base(value, x, y, height, xDimension)
		{
		}

		// Token: 0x06004C95 RID: 19605 RVA: 0x0026C76B File Offset: 0x0026B76B
		public Code93(string value, float x, float y, float height, float xDimension, bool showText) : base(value, x, y, height, xDimension, showText)
		{
		}

		// Token: 0x06004C96 RID: 19606 RVA: 0x0026C780 File Offset: 0x0026B780
		public Code93(string value, float x, float y, float height, float xDimension, Font font, float fontSize) : base(value, x, y, height, xDimension, true, font, fontSize)
		{
		}

		// Token: 0x06004C97 RID: 19607 RVA: 0x0026C7A4 File Offset: 0x0026B7A4
		public override float GetSymbolWidth()
		{
			o o = new o(this.Value);
			return (float)o.g();
		}

		// Token: 0x06004C98 RID: 19608 RVA: 0x0026C7CC File Offset: 0x0026B7CC
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
			o o = null;
			BitArray bitArray;
			float num2;
			try
			{
				o = new o(this.Value);
				bitArray = o.f();
				num2 = (float)o.g();
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			float textWidth = base.Font.GetTextWidth(o.e() + o.d(), base.FontSize);
			float a_2 = (num2 < textWidth) ? textWidth : num2;
			if (base.ShowText)
			{
				num -= base.a(o.e() + o.d(), a_2, out a_);
			}
			int a_3 = bitArray.Length * base.PixelsPerXDimension;
			int num3 = 1;
			byte[] a_4 = BarCode.a(bitArray, base.PixelsPerXDimension, 1, bitArray.Length, num3);
			writer.a(this.X, this.Y + num, num2, (float)((int)num), a_3, num3, a_4);
			if (base.ShowText && base.ShowText)
			{
				base.a(writer, a_, this.Y + num);
			}
			if (writer.Document.Tag != null)
			{
				writer.SetGraphicsMode();
				Tag.a(writer);
			}
		}
	}
}
