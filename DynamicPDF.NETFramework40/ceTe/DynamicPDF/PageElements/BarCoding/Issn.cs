using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x0200076C RID: 1900
	public class Issn : UpcBase
	{
		// Token: 0x06004D1F RID: 19743 RVA: 0x0026F4BC File Offset: 0x0026E4BC
		public Issn(string value, float x, float y) : this(value, x, y, 1f)
		{
		}

		// Token: 0x06004D20 RID: 19744 RVA: 0x0026F4CF File Offset: 0x0026E4CF
		public Issn(string value, float x, float y, float scale) : base(value, x, y, scale)
		{
			this.a = value;
		}

		// Token: 0x170005F1 RID: 1521
		// (get) Token: 0x06004D21 RID: 19745 RVA: 0x0026F4FC File Offset: 0x0026E4FC
		// (set) Token: 0x06004D22 RID: 19746 RVA: 0x0026F514 File Offset: 0x0026E514
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

		// Token: 0x06004D23 RID: 19747 RVA: 0x0026F520 File Offset: 0x0026E520
		internal float b()
		{
			return this.d;
		}

		// Token: 0x06004D24 RID: 19748 RVA: 0x0026F538 File Offset: 0x0026E538
		public override float GetSymbolWidth()
		{
			return this.XDimension * (float)ad.c();
		}

		// Token: 0x06004D25 RID: 19749 RVA: 0x0026F558 File Offset: 0x0026E558
		protected override void DrawBarCode(PageWriter writer)
		{
			if (!this.a(this.a))
			{
				throw new InvalidValueBarCodeException("Invalid ISSN value.");
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

		// Token: 0x06004D26 RID: 19750 RVA: 0x0026F848 File Offset: 0x0026E848
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

		// Token: 0x06004D27 RID: 19751 RVA: 0x0026F8E8 File Offset: 0x0026E8E8
		private bool a(string A_0)
		{
			bool flag = true;
			foreach (char c in A_0)
			{
				if (c <= '/' || c >= ':')
				{
					if (c != '-')
					{
						if (c != 'X' && c != 'x')
						{
							flag = false;
							break;
						}
					}
				}
			}
			if (flag)
			{
				base.Value = this.a.Replace("-", "");
				if (base.Value.Length == 7)
				{
					this.a += this.a();
				}
				if (base.Value.Length == 8)
				{
					base.Value = base.Value.Substring(0, 7);
				}
				if (base.Value.Length == 7)
				{
					base.Value = "977" + base.Value + "00";
				}
				if (base.Value.Length < 8 || (base.Value.Length != 12 && base.Value.Length != 13))
				{
					throw new BarCodeException("ISSN barcode may have 12 or 13 digits only");
				}
				this.c = "ISSN " + this.a;
			}
			return flag;
		}

		// Token: 0x06004D28 RID: 19752 RVA: 0x0026FA84 File Offset: 0x0026EA84
		private string a()
		{
			int num = 2;
			int num2 = 0;
			for (int i = base.Value.Length - 1; i >= 0; i--)
			{
				num2 += int.Parse(base.Value[i].ToString()) * num;
				num++;
			}
			int num3 = num2 % 11;
			string result;
			if (num3 == 0)
			{
				result = num3.ToString();
			}
			else if (num3 == 10)
			{
				result = "X";
			}
			else
			{
				result = (11 - num3).ToString();
			}
			return result;
		}

		// Token: 0x040029BC RID: 10684
		private new string a;

		// Token: 0x040029BD RID: 10685
		private new bool b;

		// Token: 0x040029BE RID: 10686
		private new string c = string.Empty;

		// Token: 0x040029BF RID: 10687
		private new float d = 0f;
	}
}
