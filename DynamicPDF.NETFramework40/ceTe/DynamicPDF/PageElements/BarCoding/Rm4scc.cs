using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x0200077B RID: 1915
	public class Rm4scc : TextBarCode
	{
		// Token: 0x06004D9A RID: 19866 RVA: 0x00271F50 File Offset: 0x00270F50
		public Rm4scc(string value, float x, float y) : base(value, x, y, 9f, 3.2727273f, false)
		{
			TextLineList textLineList = null;
			float textWidth = base.Font.GetTextWidth(this.Value, base.FontSize);
			this.Height = 9f + base.a(this.Value, textWidth, out textLineList) + 2.016f;
		}

		// Token: 0x06004D9B RID: 19867 RVA: 0x00271FB8 File Offset: 0x00270FB8
		public Rm4scc(string value, float x, float y, bool showText) : base(value, x, y, 9f, 3.2727273f, showText)
		{
			TextLineList textLineList = null;
			float textWidth = base.Font.GetTextWidth(this.Value, base.FontSize);
			this.Height = 9f + base.a(this.Value, textWidth, out textLineList) + 2.016f;
		}

		// Token: 0x06004D9C RID: 19868 RVA: 0x00272020 File Offset: 0x00271020
		public override float GetSymbolWidth()
		{
			a5 a = new a5(this.Value, this.XDimension, true, true);
			return a.b();
		}

		// Token: 0x06004D9D RID: 19869 RVA: 0x0027204C File Offset: 0x0027104C
		protected override void DrawBarCode(PageWriter writer)
		{
			writer.SetGraphicsMode();
			if (writer.Document.Tag != null)
			{
				base.a(writer);
			}
			writer.SetFillColor(base.Color);
			TextLineList a_ = null;
			a5 a;
			BitArray bitArray;
			try
			{
				a = new a5(this.Value, this.XDimension, true, true);
				bitArray = a.d();
			}
			catch (ap ap)
			{
				throw new InvalidValueBarCodeException(ap.Message);
			}
			catch (Exception ex)
			{
				throw new BarCodeException(ex.Message);
			}
			float num = a.b();
			float textWidth = base.Font.GetTextWidth(this.Value, base.FontSize);
			float a_2 = (num < textWidth) ? textWidth : num;
			float num2 = this.Y;
			float num3 = base.a(this.Value, a_2, out a_);
			if (this.a())
			{
				num2 += num3 + 2.016f;
			}
			int num4 = 3 * base.PixelsPerXDimension;
			int num5 = bitArray.Length / 3;
			int num6 = 3;
			byte[] a_3 = BarCode.a(bitArray, base.PixelsPerXDimension, num4, num5, num6);
			writer.a(this.X, num2 + this.SymbolHeight, num, this.SymbolHeight, num5 * base.PixelsPerXDimension, num6 * num4, a_3);
			if (base.ShowText && this.a())
			{
				base.a(writer, a_, this.Y);
			}
			else if (base.ShowText)
			{
				base.a(writer, a_, this.Y + this.SymbolHeight + 2.016f);
			}
			if (writer.Document.Tag != null)
			{
				Tag.a(writer);
			}
		}

		// Token: 0x06004D9E RID: 19870 RVA: 0x00272220 File Offset: 0x00271220
		internal bool a()
		{
			return this.d;
		}

		// Token: 0x06004D9F RID: 19871 RVA: 0x00272238 File Offset: 0x00271238
		internal void a(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x17000608 RID: 1544
		// (get) Token: 0x06004DA0 RID: 19872 RVA: 0x00272244 File Offset: 0x00271244
		public float SymbolHeight
		{
			get
			{
				return this.Height - (base.ShowText ? (BarCode.a(base.FontSize, base.Font) + 2.016f) : 0f);
			}
		}

		// Token: 0x04002A15 RID: 10773
		private new const float a = 9f;

		// Token: 0x04002A16 RID: 10774
		private new const float b = 3.2727273f;

		// Token: 0x04002A17 RID: 10775
		private const float c = 2.016f;

		// Token: 0x04002A18 RID: 10776
		private new bool d = false;
	}
}
