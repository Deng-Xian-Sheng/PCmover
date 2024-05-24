using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x0200075C RID: 1884
	public class DeutschePostIdentcode : TextBarCode
	{
		// Token: 0x06004CAC RID: 19628 RVA: 0x0026CF59 File Offset: 0x0026BF59
		public DeutschePostIdentcode(string value, float x, float y, float height) : base(value, x, y, height, 1f)
		{
		}

		// Token: 0x06004CAD RID: 19629 RVA: 0x0026CF6E File Offset: 0x0026BF6E
		public DeutschePostIdentcode(string value, float x, float y, float height, bool showText) : base(value, x, y, height, 1f, showText)
		{
		}

		// Token: 0x06004CAE RID: 19630 RVA: 0x0026CF88 File Offset: 0x0026BF88
		public DeutschePostIdentcode(string value, float x, float y, float height, Font font, float fontSize) : base(value, x, y, height, 1f, true, font, fontSize)
		{
		}

		// Token: 0x06004CAF RID: 19631 RVA: 0x0026CFAD File Offset: 0x0026BFAD
		public DeutschePostIdentcode(string value, float x, float y, float height, float xDimension) : base(value, x, y, height, xDimension)
		{
		}

		// Token: 0x06004CB0 RID: 19632 RVA: 0x0026CFBF File Offset: 0x0026BFBF
		public DeutschePostIdentcode(string value, float x, float y, float height, float xDimension, bool showText) : base(value, x, y, height, xDimension, showText)
		{
		}

		// Token: 0x06004CB1 RID: 19633 RVA: 0x0026CFD4 File Offset: 0x0026BFD4
		public DeutschePostIdentcode(string value, float x, float y, float height, float xDimension, Font font, float fontSize) : base(value, x, y, height, xDimension, true, font, fontSize)
		{
		}

		// Token: 0x06004CB2 RID: 19634 RVA: 0x0026CFF8 File Offset: 0x0026BFF8
		public override float GetSymbolWidth()
		{
			aa aa = new aa(this.Value);
			return (float)aa.a();
		}

		// Token: 0x06004CB3 RID: 19635 RVA: 0x0026D020 File Offset: 0x0026C020
		protected override void DrawBarCode(PageWriter writer)
		{
			writer.SetGraphicsMode();
			if (writer.Document.Tag != null)
			{
				base.a(writer);
			}
			writer.SetFillColor(base.Color);
			aa aa;
			BitArray bitArray;
			float num;
			try
			{
				aa = new aa(this.Value);
				bitArray = aa.b();
				num = (float)aa.a();
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
			float textWidth = base.Font.GetTextWidth(aa.c(), base.FontSize);
			float a_2 = (num < textWidth) ? textWidth : num;
			if (base.ShowText)
			{
				num2 -= base.a(aa.c(), a_2, out a_);
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
