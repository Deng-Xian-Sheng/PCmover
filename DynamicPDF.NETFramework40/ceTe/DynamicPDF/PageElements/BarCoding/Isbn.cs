using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000766 RID: 1894
	public class Isbn : UpcBase
	{
		// Token: 0x06004CF5 RID: 19701 RVA: 0x0026E552 File Offset: 0x0026D552
		public Isbn(string value, float x, float y) : this(value, x, y, 1f)
		{
		}

		// Token: 0x06004CF6 RID: 19702 RVA: 0x0026E565 File Offset: 0x0026D565
		public Isbn(string value, float x, float y, float scale) : base(value, x, y, scale)
		{
			this.a = value;
		}

		// Token: 0x170005EB RID: 1515
		// (get) Token: 0x06004CF7 RID: 19703 RVA: 0x0026E594 File Offset: 0x0026D594
		// (set) Token: 0x06004CF8 RID: 19704 RVA: 0x0026E5AC File Offset: 0x0026D5AC
		public bool ShowText
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

		// Token: 0x06004CF9 RID: 19705 RVA: 0x0026E5B8 File Offset: 0x0026D5B8
		internal float a()
		{
			return this.d;
		}

		// Token: 0x06004CFA RID: 19706 RVA: 0x0026E5D0 File Offset: 0x0026D5D0
		public override float GetSymbolWidth()
		{
			return this.XDimension * (float)ad.c();
		}

		// Token: 0x06004CFB RID: 19707 RVA: 0x0026E5F0 File Offset: 0x0026D5F0
		protected override void DrawBarCode(PageWriter writer)
		{
			if (!this.a(this.a))
			{
				throw new InvalidValueBarCodeException("Invalid ISBN value.");
			}
			writer.SetGraphicsMode();
			if (writer.Document.Tag != null)
			{
				base.a(writer);
			}
			writer.SetFillColor(base.Color);
			writer.SetTextDefaults();
			float fontSize = base.c() * 0.6f;
			float textWidth = Font.CourierBold.GetTextWidth(this.c, fontSize);
			float width = (this.GetSymbolWidth() < textWidth) ? textWidth : this.GetSymbolWidth();
			TextLineList textLines = Font.CourierBold.GetTextLines(this.c.ToCharArray(), width, fontSize);
			this.d = textLines.GetRequiredHeight(0);
			float a_ = base.c();
			float num = this.b ? (base.f() - this.d) : base.f();
			float num2 = this.b ? (base.g() - this.d) : base.g();
			float num3 = this.Y;
			try
			{
				ad ad = new ad(this.Value);
				if (base.Value.Length == 12)
				{
					this.c = this.c + "-" + ad.d()[12];
				}
				BitArray a_2 = ad.e();
				if (this.b)
				{
					num3 += this.d;
					base.a(writer, textLines, this.X + 8f * this.XDimension, this.Y);
				}
				BitArray bitArray = ad.a(a_2);
				int a_3 = 95 * base.PixelsPerXDimension;
				int a_4 = 1;
				byte[] a_5 = BarCode.a(bitArray, base.PixelsPerXDimension, 1, bitArray.Length, a_4);
				writer.a(this.X + this.XDimension * 8f, num3 + num2, 95f * this.XDimension, num2, a_3, 1, a_5);
				BitArray bitArray2 = ad.b(a_2);
				a_5 = BarCode.a(bitArray2, base.PixelsPerXDimension, 1, bitArray2.Length, a_4);
				writer.a(this.X + this.XDimension * 8f, num3 + num, 95f * this.XDimension, num, a_3, 1, a_5);
				this.a(writer, ad.d(), a_);
				if (writer.Document.Tag != null && !base.j())
				{
					writer.SetGraphicsMode();
					Tag.a(writer);
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
		}

		// Token: 0x06004CFC RID: 19708 RVA: 0x0026E8E0 File Offset: 0x0026D8E0
		private void a(PageWriter A_0, char[] A_1, float A_2)
		{
			A_0.SetTextMode();
			float y = base.d();
			float num = this.X;
			A_0.SetFont(Font.CourierBold, A_2 * 0.75f);
			A_0.Write_Tm(num, y);
			A_0.Write_Tj_(A_1, 0, 1, false);
			num += this.XDimension * 11f;
			A_0.SetFont(Font.CourierBold, A_2);
			A_0.Write_Tm(num, y);
			A_0.Write_Tj_(A_1, 1, 6, false);
			num += this.XDimension * 46f;
			A_0.Write_Tm(num, y);
			A_0.Write_Tj_(A_1, 7, 6, false);
		}

		// Token: 0x06004CFD RID: 19709 RVA: 0x0026E980 File Offset: 0x0026D980
		private bool a(string A_0)
		{
			bool flag = true;
			foreach (char c in A_0)
			{
				if (c <= '/' || c >= ':')
				{
					if (c != '-')
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				base.Value = this.a.Replace("-", "");
				if (base.Value.Length != 12 && base.Value.Length != 13)
				{
					throw new BarCodeException("ISBN barcode may have 12 or 13 digits only");
				}
				this.c = "ISBN " + this.a;
			}
			return flag;
		}

		// Token: 0x040029B0 RID: 10672
		private new string a;

		// Token: 0x040029B1 RID: 10673
		private new bool b;

		// Token: 0x040029B2 RID: 10674
		private new string c = string.Empty;

		// Token: 0x040029B3 RID: 10675
		private new float d = 0f;
	}
}
