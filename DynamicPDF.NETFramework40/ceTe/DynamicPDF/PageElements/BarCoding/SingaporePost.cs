using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x0200077C RID: 1916
	public class SingaporePost : TextBarCode
	{
		// Token: 0x06004DA1 RID: 19873 RVA: 0x00272284 File Offset: 0x00271284
		public SingaporePost(string value, float x, float y) : this(value, x, y, 9f, 3.2727273f, false)
		{
		}

		// Token: 0x06004DA2 RID: 19874 RVA: 0x0027229D File Offset: 0x0027129D
		public SingaporePost(string value, float x, float y, bool showText) : this(value, x, y, 9f, 3.2727273f, showText)
		{
		}

		// Token: 0x06004DA3 RID: 19875 RVA: 0x002722B8 File Offset: 0x002712B8
		internal SingaporePost(string A_0, float A_1, float A_2, float A_3, float A_4, bool A_5) : base(A_0, A_1, A_2, A_3, A_4, A_5)
		{
			base.FontSize = 10f;
			TextLineList textLineList = null;
			float textWidth = base.Font.GetTextWidth(this.Value, base.FontSize);
			this.Height = 9f + base.a(this.Value, textWidth, out textLineList) + 2.016f;
		}

		// Token: 0x06004DA4 RID: 19876 RVA: 0x00272328 File Offset: 0x00271328
		private float a()
		{
			return this.Height - (base.ShowText ? (BarCode.a(base.FontSize, base.Font) + 2.016f) : 0f);
		}

		// Token: 0x06004DA5 RID: 19877 RVA: 0x00272368 File Offset: 0x00271368
		public override float GetSymbolWidth()
		{
			a5 a = new a5(this.Value, this.XDimension, true, true);
			return a.b();
		}

		// Token: 0x06004DA6 RID: 19878 RVA: 0x00272394 File Offset: 0x00271394
		protected override void DrawBarCode(PageWriter writer)
		{
			writer.SetGraphicsMode();
			if (writer.Document.Tag != null)
			{
				base.a(writer);
			}
			writer.SetFillColor(base.Color);
			TextLineList a_ = null;
			BitArray bitArray = null;
			a5 a = null;
			try
			{
				a = new a5(this.Value, this.XDimension, true, true);
				bitArray = a.d();
			}
			catch (ap)
			{
				throw new InvalidValueBarCodeException("Invalid Singapore Post character, allows only 0-9 and A-Z.");
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
			if (base.ShowText && this.d)
			{
				num2 += num3 + 2.016f;
			}
			int num4 = 3 * base.PixelsPerXDimension;
			int num5 = bitArray.Length / 3;
			int num6 = 3;
			byte[] a_3 = BarCode.a(bitArray, base.PixelsPerXDimension, num4, num5, num6);
			writer.a(this.X, num2 + this.a(), num, this.a(), num5 * base.PixelsPerXDimension, num6 * num4, a_3);
			if (base.ShowText && this.d)
			{
				base.a(writer, a_, this.Y);
			}
			else if (base.ShowText)
			{
				base.a(writer, a_, this.Y + this.a() + 2.016f);
			}
			if (writer.Document.Tag != null)
			{
				Tag.a(writer);
			}
		}

		// Token: 0x04002A19 RID: 10777
		private new const float a = 10f;

		// Token: 0x04002A1A RID: 10778
		private new const float b = 2.016f;

		// Token: 0x04002A1B RID: 10779
		private const float c = 9f;

		// Token: 0x04002A1C RID: 10780
		private new bool d = false;
	}
}
