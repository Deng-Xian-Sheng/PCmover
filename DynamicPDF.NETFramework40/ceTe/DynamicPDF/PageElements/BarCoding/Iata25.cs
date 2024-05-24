using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000762 RID: 1890
	public class Iata25 : TextBarCode
	{
		// Token: 0x06004CCE RID: 19662 RVA: 0x0026DB30 File Offset: 0x0026CB30
		public Iata25(string value, float x, float y, float height) : base(value, x, y, height, 1f)
		{
		}

		// Token: 0x06004CCF RID: 19663 RVA: 0x0026DB45 File Offset: 0x0026CB45
		public Iata25(string value, float x, float y, float height, bool showText) : base(value, x, y, height, 1f, showText)
		{
		}

		// Token: 0x06004CD0 RID: 19664 RVA: 0x0026DB5C File Offset: 0x0026CB5C
		public Iata25(string value, float x, float y, float height, Font font, float fontSize) : base(value, x, y, height, 1f, true, font, fontSize)
		{
		}

		// Token: 0x06004CD1 RID: 19665 RVA: 0x0026DB81 File Offset: 0x0026CB81
		public Iata25(string value, float x, float y, float height, float xDimension) : base(value, x, y, height, xDimension)
		{
		}

		// Token: 0x06004CD2 RID: 19666 RVA: 0x0026DB93 File Offset: 0x0026CB93
		public Iata25(string value, float x, float y, float height, float xDimension, bool showText) : base(value, x, y, height, xDimension, showText)
		{
		}

		// Token: 0x06004CD3 RID: 19667 RVA: 0x0026DBA8 File Offset: 0x0026CBA8
		public Iata25(string value, float x, float y, float height, float xDimension, Font font, float fontSize) : base(value, x, y, height, xDimension, true, font, fontSize)
		{
		}

		// Token: 0x170005E7 RID: 1511
		// (get) Token: 0x06004CD4 RID: 19668 RVA: 0x0026DBCC File Offset: 0x0026CBCC
		// (set) Token: 0x06004CD5 RID: 19669 RVA: 0x0026DBE4 File Offset: 0x0026CBE4
		public bool IncludeCheckDigit
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

		// Token: 0x06004CD6 RID: 19670 RVA: 0x0026DBF0 File Offset: 0x0026CBF0
		public override float GetSymbolWidth()
		{
			a7 a = new a7(this.Value, this.a, a8.b);
			return (float)a.i();
		}

		// Token: 0x06004CD7 RID: 19671 RVA: 0x0026DC1C File Offset: 0x0026CC1C
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
			a7 a = null;
			BitArray bitArray;
			float num2;
			try
			{
				a = new a7(this.Value, this.a, a8.b);
				bitArray = a.j();
				num2 = (float)a.i();
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			float textWidth = base.Font.GetTextWidth(a.h(), base.FontSize);
			float a_2 = (num2 < textWidth) ? textWidth : num2;
			if (base.ShowText)
			{
				num -= base.a(a.h(), a_2, out a_);
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

		// Token: 0x040029AA RID: 10666
		private new bool a;
	}
}
