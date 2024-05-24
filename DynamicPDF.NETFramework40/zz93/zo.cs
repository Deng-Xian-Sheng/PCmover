using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger.Forms;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x020003D5 RID: 981
	internal class zo : cm
	{
		// Token: 0x06002943 RID: 10563 RVA: 0x00181B7E File Offset: 0x00180B7E
		internal zo(TextField A_0, float A_1, float A_2, DocumentWriter A_3, zh A_4) : base(A_0, A_1, A_2, A_3, A_4)
		{
			this.a = A_0;
		}

		// Token: 0x06002944 RID: 10564 RVA: 0x00181B98 File Offset: 0x00180B98
		internal new void f()
		{
			if (base.k().BackgroundColor != null)
			{
				base.k().BackgroundColor.DrawFill(this);
				this.Write_re(0f, 0f, this.l, this.m);
				this.Write_f();
			}
			if (base.k().BorderColor != null)
			{
				base.k().BorderColor.DrawStroke(this);
			}
			if (base.k().BorderStyle != null)
			{
				if (base.k().BorderColor != null)
				{
					base.a(base.k().BorderStyle);
					if (base.k().BorderStyle.a() == 85)
					{
						this.Write_s_();
					}
					else
					{
						this.Write_re((float)base.l() / 2f, (float)base.l() - (float)base.l() / 2f, this.l - (float)base.l(), this.m - (float)base.l());
						this.Write_s_();
					}
					if ((this.a.hk() & 16777216) == 16777216)
					{
						if (base.k().BorderStyle.a() == 83 || base.k().BorderStyle.a() == 68)
						{
							if (base.k().BorderStyle.a() == 68)
							{
								base.Write_d(3, 0);
							}
							this.e();
						}
					}
				}
			}
			if (this.a.hl() != null)
			{
				this.a();
			}
		}

		// Token: 0x06002945 RID: 10565 RVA: 0x00181D64 File Offset: 0x00180D64
		private new void e()
		{
			float num = this.c();
			int num2 = this.a.MaximumLength - 1;
			float num3 = num;
			float y = this.m - (float)base.l() / 2f;
			for (int i = 0; i < num2; i++)
			{
				this.Write_m_(num3, 1f);
				this.Write_l_(num3, y);
				num3 += num;
			}
			this.Write_s_();
		}

		// Token: 0x06002946 RID: 10566 RVA: 0x00181DD8 File Offset: 0x00180DD8
		private new float c()
		{
			return this.l / (float)this.a.MaximumLength;
		}

		// Token: 0x06002947 RID: 10567 RVA: 0x00181E00 File Offset: 0x00180E00
		private new void a()
		{
			Font font = this.a.Font;
			DeviceColor deviceColor = (base.k().TextColor != null) ? base.k().TextColor : Grayscale.Black;
			float num = this.l - (float)(base.l() * 2);
			float num2 = this.m - (float)(base.l() * 2);
			float num3 = 0f;
			int num4 = 1;
			if (base.k().BorderStyle != null)
			{
				num4 = base.k().BorderStyle.b();
			}
			switch (this.a.c())
			{
			case FormFieldAlign.Left:
			case FormFieldAlign.Center:
				num3 = (float)(num4 * 2);
				break;
			case FormFieldAlign.Right:
				if (base.l() != 0)
				{
					if ((this.a.hk() & 4096) != 4096)
					{
						num3 = (float)(num4 * 2);
					}
				}
				break;
			}
			if (this.a.BorderStyle != null && (this.a.BorderStyle.a() == 66 || this.a.BorderStyle.a() == 73))
			{
				num3 *= 2f;
			}
			float num5 = this.m;
			base.a(true);
			if (font == null)
			{
				if (!base.k().UseSubstituteFont || (base.k().UseSubstituteFont && base.Document.Form.SubstituteFont == null))
				{
					throw new FontNotFoundException("One or more Form Field font not found.");
				}
				base.b(font = base.Document.Form.SubstituteFont);
			}
			else
			{
				base.a(this.a(font));
			}
			if (base.m() != null)
			{
				font = ((base.m()[1] != null) ? base.m()[1] : ((base.m()[0] != null) ? base.m()[0] : this.a.Font));
			}
			float num6 = this.a.FontSize;
			base.n();
			base.Write_q_();
			this.Write_re((float)num4, (float)num4, this.l - (float)(num4 * 2), this.m - (float)(num4 * 2));
			base.Write_W();
			base.Write_n();
			char[] array = this.a.hl().ToCharArray();
			int num7 = this.a.hk();
			if ((num7 & 8192) == 8192)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = '*';
				}
				float num8 = (float)num4;
				if (num6 <= 0f)
				{
					num6 = this.a(array, font, this.l - num8 * 2f, this.m - num8 * 2f, false);
				}
				num5 = this.a(num5, font, num6);
				switch (this.a.c())
				{
				case FormFieldAlign.Center:
					num3 += (num - font.GetTextWidth(array, num6) - (float)(num4 * 2)) / 2f;
					break;
				case FormFieldAlign.Right:
					num3 += num - font.GetTextWidth(array, num6) - (float)(num4 * 2);
					break;
				}
				base.Write_BT();
				base.SetFont(font, num6);
				base.SetFillColor(deviceColor);
				base.Write_Td_(num3, num5);
				base.b(array);
				base.Write_ET();
			}
			else if ((num7 & 16777216) == 16777216)
			{
				int num9 = array.Length;
				float num10 = this.c();
				float num11 = -num10 / 2f;
				float num8 = (float)num4;
				if (num6 <= 0f)
				{
					if ((font is OpenTypeFont && ((OpenTypeFont)font).a().ac().i()) || font.bk())
					{
						num6 = this.a(new char[]
						{
							array[0]
						}, font, num10 - (float)(base.l() * 2), this.m - (float)(base.l() * 2), true);
					}
					else
					{
						num6 = this.a(new char[]
						{
							array[0]
						}, font, num10 - num8 * 2f, this.m, true);
					}
				}
				num5 = this.a(num5, font, num6);
				float num12 = 0f;
				int j = 0;
				switch (this.a.c())
				{
				case FormFieldAlign.Center:
				{
					num3 += (num - font.GetTextWidth(array, num6) - (float)(num4 * 2)) / 2f;
					int num13 = (this.a.MaximumLength - 1) / 2;
					int num14 = num9 / 2;
					if (this.a.MaximumLength % 2 == 0 && num9 % 2 == 0)
					{
						num14--;
					}
					j = num13 - num14;
					break;
				}
				case FormFieldAlign.Right:
				{
					num3 += num - font.GetTextWidth(array, num6) - (float)(num4 * 2);
					int num13 = this.a.MaximumLength;
					int num14 = num9;
					j = num13 - num14;
					break;
				}
				}
				while (j > 0)
				{
					num12 += num10;
					j--;
				}
				base.Write_BT();
				base.SetFont(font, num6);
				base.SetFillColor(deviceColor);
				for (int i = 0; i < num9; i++)
				{
					char[] a_ = new char[]
					{
						array[i]
					};
					num3 = num12 + num10 - (float)font.GetGlyphWidth(array[i]) * num6 / 1000f / 2f + num11;
					base.Write_Td_(num3, num5);
					base.b(a_);
					num11 = (float)font.GetGlyphWidth(array[i]) * num6 / 1000f / 2f;
					num5 = 0f;
					num12 = 0f;
				}
				base.Write_ET();
			}
			else if ((num7 & 4096) != 4096)
			{
				if (font == null)
				{
					font = Font.Helvetica;
				}
				float num8 = (float)num4;
				if (num6 <= 0f)
				{
					num6 = this.a(array, font, this.l - num8 * 2f, this.m - num8 * 2f, false);
				}
				num5 = this.a(num5, font, num6);
				float num15 = num3;
				switch (this.a.c())
				{
				case FormFieldAlign.Center:
					num3 += num - font.GetTextWidth(array, num6) - (float)(num4 * 2);
					num3 /= 2f;
					break;
				case FormFieldAlign.Right:
					if (this.a.BorderStyle != null && (this.a.BorderStyle.a() == 66 || this.a.BorderStyle.a() == 73))
					{
						num3 = 0f;
					}
					num3 += num - font.GetTextWidth(array, num6) - (float)(num4 * 2);
					break;
				}
				if (num3 < num15)
				{
					num3 = num15;
				}
				base.Write_BT();
				base.SetFont(font, num6);
				base.SetFillColor(deviceColor);
				base.Write_Td_(num3, num5);
				base.b(array);
				base.Write_ET();
			}
			else
			{
				float num8 = (float)num4;
				if (num6 <= 0f)
				{
					num6 = this.a(array, font, this.l, this.m, num8);
				}
				float num16 = 0f;
				float num17 = 0f;
				this.a(ref num16, ref num17, font);
				float num18 = (num16 - num17) * num6 / 1000f;
				float num19 = num8 * 2f;
				TextLineList textLineList;
				if (font is CoreLatinFont)
				{
					if (this.a.BorderStyle != null && (this.a.BorderStyle.a() == 66 || this.a.BorderStyle.a() == 73))
					{
						switch ((int)num8)
						{
						case 1:
							num19 = num8 * 4f;
							break;
						case 2:
							num19 = num8 * 8f;
							break;
						case 3:
							num19 = num8 * 6f;
							break;
						}
						num = this.l - num19;
						num5 = num8 * 4f - num17 * num6 / 1000f;
					}
					else
					{
						num19 = num8 * 2f;
						num = this.l - num19;
						num5 = num8 * 2f - num17 * num6 / 1000f;
					}
					textLineList = font.a(array, num, num2, num6, num18);
					if (num5 > num2 - textLineList.m() + 0.001f)
					{
						num5 = num8;
					}
				}
				else if (font is OpenTypeFont && ((OpenTypeFont)font).a() is ad3)
				{
					if (this.a.BorderStyle != null && (this.a.BorderStyle.a() == 66 || this.a.BorderStyle.a() == 73))
					{
						switch ((int)num8)
						{
						case 1:
							num = this.l - num8 * 5f;
							num5 = num8 * 2f + font.GetDefaultLeading(num6) / 2f;
							break;
						case 2:
							num = this.l - num8 * 6f;
							num5 = num8 * 2f + num8 + font.GetDefaultLeading(num6) / 2f;
							break;
						case 3:
							num = this.l - num8 * 6f - num8 / 2f;
							num5 = num8 * 2f + num8 + font.GetDefaultLeading(num6) / 2f;
							break;
						}
					}
					else
					{
						if (num6 >= 6f)
						{
							num = this.l - num8 * 2.75f;
						}
						else
						{
							num = this.l - num8 * 2f;
						}
						num5 = num8 * 2f + font.GetDefaultLeading(num6) / 2f;
					}
					textLineList = font.a(array, num, num2, num6, num18);
					if (textLineList.Leading + num5 > num2 - num8 * 2f && num5 > num2 - textLineList.m() + 0.001f)
					{
						num5 = num2 - textLineList.m() + 0.001f;
					}
				}
				else
				{
					if (this.a.BorderStyle != null && (this.a.BorderStyle.a() == 66 || this.a.BorderStyle.a() == 73))
					{
						switch ((int)num8)
						{
						case 1:
							num = this.l - num8 * 5f;
							break;
						case 2:
							num = this.l - num8 * 8f;
							break;
						case 3:
							num = this.l - num8 * 6f - num8 / 2f;
							break;
						}
						num5 = ((num8 == 1f) ? (num8 * 2f) : (num8 * 3f));
					}
					else
					{
						num = this.l - num8 * 2f;
						num5 = num8 * (num8 / 2f);
					}
					float num20 = (num16 - num17) * num6 / 1000f;
					float defaultLeading = font.GetDefaultLeading(num6);
					num18 = ((num20 > defaultLeading) ? ((num20 - defaultLeading) / 2f) : ((defaultLeading - num20) / 2f));
					textLineList = font.a(array, num, num2, num6, defaultLeading + num18);
					if (num5 > num2 - textLineList.m() + 0.001f)
					{
						num5 = num8;
					}
				}
				switch (this.a.c())
				{
				case FormFieldAlign.Center:
					textLineList.ja(this, num3, num5, TextAlign.Center, deviceColor, null, 0f, false, false, false);
					break;
				case FormFieldAlign.Right:
					num3 = (this.l - num) / 2f;
					textLineList.Draw(this, num3, num5, TextAlign.Right, deviceColor, false, false);
					break;
				default:
					textLineList.ja(this, num3, num5, TextAlign.Left, deviceColor, null, 0f, false, false, false);
					break;
				}
			}
			base.Write_Q();
			base.o();
		}

		// Token: 0x06002948 RID: 10568 RVA: 0x00182AF0 File Offset: 0x00181AF0
		private new Font[] a(Font A_0)
		{
			Font[] array = new Font[2];
			if (A_0 != null)
			{
				if (A_0 is OpenTypeFont)
				{
					if (!((OpenTypeFont)A_0).a().ac().i())
					{
						Font font = new dw((OpenTypeFont)A_0, LineBreaker.Default);
						if (base.Document.Form.e().b(font) == null)
						{
							base.Document.Form.e().a(font);
						}
						else
						{
							font = base.Document.Form.e().b(font);
						}
						array[0] = font;
					}
					array[1] = A_0;
				}
				else if (A_0.bk())
				{
					c2 c = (c2)A_0;
					if (c.i() != null)
					{
						Font font = c.i();
						if (c.f())
						{
							array[0] = A_0;
						}
						if (base.Document.Form.e().b(font) == null)
						{
							base.Document.Form.e().a(font);
						}
						else
						{
							font = base.Document.Form.e().b(font);
						}
						array[1] = font;
					}
					else
					{
						array[0] = A_0;
					}
				}
				else
				{
					array[0] = A_0;
				}
			}
			return array;
		}

		// Token: 0x06002949 RID: 10569 RVA: 0x00182C6C File Offset: 0x00181C6C
		private new float a(char[] A_0, Font A_1, float A_2, float A_3, bool A_4)
		{
			bool flag = true;
			float num = 1f;
			float num2 = 5f;
			if (this.a.BorderStyle != null && (this.a.BorderStyle.a() == 66 || this.a.BorderStyle.a() == 73))
			{
				float num3 = (float)((base.l() == 0) ? 1 : base.l());
				A_2 -= num3 * 2f;
				A_3 -= num3 * 2f;
			}
			if (!A_4)
			{
				A_2 = ((base.l() == 1) ? (A_2 * 0.99f) : ((base.l() == 2) ? (A_2 * 0.98f) : ((base.l() == 3) ? (A_2 * 0.97f) : (A_2 * 0.99f))));
			}
			float result;
			if ((!(A_1 is OpenTypeFont) || !((OpenTypeFont)A_1).a().ac().i()) && !A_1.bk())
			{
				A_3 *= 0.85f;
				while (flag && num < 1600f)
				{
					float textWidth = A_1.GetTextWidth(A_0, num);
					float defaultLeading = A_1.GetDefaultLeading(num);
					if (textWidth >= A_2 || defaultLeading >= A_3)
					{
						if (num2 <= 0.01f)
						{
							num -= num2;
							flag = false;
						}
						else
						{
							num -= num2;
							num2 /= 2f;
						}
					}
					else
					{
						num += num2;
					}
				}
				if (num < 4f)
				{
					num = 4f;
				}
				result = num;
			}
			else
			{
				result = this.a(A_0, A_1, A_2, A_3);
			}
			return result;
		}

		// Token: 0x0600294A RID: 10570 RVA: 0x00182E34 File Offset: 0x00181E34
		private new float a(char[] A_0, Font A_1, float A_2, float A_3)
		{
			bool flag = true;
			float num = 1f;
			float num2 = 5f;
			while (flag && num < 1600f)
			{
				float textWidth = A_1.GetTextWidth(A_0, num);
				float num3 = this.a(num, A_1);
				if (textWidth >= A_2 || num3 >= A_3)
				{
					if (num2 <= 0.01f)
					{
						num -= num2;
						flag = false;
					}
					else
					{
						num -= num2;
						num2 /= 2f;
					}
				}
				else
				{
					num += num2;
				}
			}
			if (num < 4f)
			{
				num = 4f;
			}
			return num;
		}

		// Token: 0x0600294B RID: 10571 RVA: 0x00182EEC File Offset: 0x00181EEC
		private new float a(float A_0, Font A_1)
		{
			float num = 0f;
			float num2 = 0f;
			this.a(ref num, ref num2, A_1);
			return (num - num2) * (A_0 / 1000f);
		}

		// Token: 0x0600294C RID: 10572 RVA: 0x00182F24 File Offset: 0x00181F24
		private new float a(char[] A_0, Font A_1, float A_2, float A_3, float A_4)
		{
			if (A_1 is CoreLatinFont)
			{
				if (this.a.BorderStyle != null && (this.a.BorderStyle.a() == 66 || this.a.BorderStyle.a() == 73))
				{
					switch ((int)A_4)
					{
					case 1:
						A_3 -= A_4 * 2f;
						A_2 -= A_4 * 4f;
						break;
					case 2:
						A_3 -= A_4 * 4f;
						A_2 -= A_4 * 6f;
						break;
					case 3:
						A_3 -= A_4 * 5f;
						A_2 = A_2 - A_4 * 5f - A_4;
						break;
					}
					A_2 -= A_4 * 2f;
					A_3 -= A_4 * 2f;
					A_3 *= 0.92f;
				}
				else
				{
					A_2 -= A_4 * 2f;
					A_3 -= A_4 * 2f;
					if (A_3 > A_2)
					{
						A_3 *= 0.92f;
					}
					else
					{
						A_3 *= 0.85f;
					}
				}
			}
			else if (A_1 is OpenTypeFont && ((OpenTypeFont)A_1).a() is ad9)
			{
				if (this.a.BorderStyle != null && (this.a.BorderStyle.a() == 66 || this.a.BorderStyle.a() == 73))
				{
					switch ((int)A_4)
					{
					case 1:
						A_3 -= A_4;
						A_2 -= A_4 * 4f;
						break;
					case 2:
						A_3 -= A_4 * 2f;
						A_2 -= A_4 * 6f;
						break;
					case 3:
						A_3 -= A_4 * 3f;
						A_2 = A_2 - A_4 * 6f - A_4;
						break;
					}
				}
				A_2 -= A_4 * 2f;
				A_3 -= A_4 * 2f;
				if (A_3 > A_2)
				{
					A_3 *= 0.85f;
				}
				else
				{
					A_3 *= 0.92f;
				}
			}
			else if (this.a.BorderStyle != null && (this.a.BorderStyle.a() == 66 || this.a.BorderStyle.a() == 73))
			{
				switch ((int)A_4)
				{
				case 1:
					A_3 -= A_4 * 2f;
					A_2 -= A_4 * 6f;
					break;
				case 2:
					A_3 -= A_4 * 6f;
					A_2 -= A_4 * 6f;
					break;
				case 3:
					A_3 -= A_4 * 5f;
					A_2 -= A_4 * 7f;
					break;
				}
				A_3 *= 0.85f;
			}
			else
			{
				if (A_3 > A_2)
				{
					A_3 -= A_3 * 0.175f;
				}
				else if (A_3 == A_2)
				{
					A_3 *= 0.9f;
				}
				else if (A_3 * 10f < A_2)
				{
					A_3 *= 0.5f;
				}
				else if (A_3 * 9f < A_2)
				{
					A_3 *= 0.55f;
				}
				else if (A_3 * 6f < A_2)
				{
					A_3 *= 0.83f;
				}
				else if (A_3 * 4f < A_2)
				{
					A_3 *= 0.78f;
				}
				else if (A_3 * 3f < A_2)
				{
					A_3 *= 0.8f;
				}
				else if (A_3 * 2f < A_2)
				{
					A_3 *= 0.81f;
				}
				else if (A_3 <= A_2 / 2f)
				{
					A_3 *= 0.71f;
				}
				else
				{
					A_3 *= 0.82f;
				}
				A_2 -= A_4 * 2.5f;
			}
			bool flag = true;
			float num = 1f;
			float num2 = 5f;
			float num3 = 0f;
			float num4 = 0f;
			this.a(ref num3, ref num4, A_1);
			float a_ = (num3 - num4) * num / 1000f;
			while (flag && num < 1600f)
			{
				a_ = (num3 - num4) * num / 1000f;
				TextLineList textLineList;
				if (A_1 is OpenTypeFont && ((OpenTypeFont)A_1).a() is ad9)
				{
					textLineList = A_1.GetTextLines(A_0, A_2, A_3, num);
				}
				else
				{
					textLineList = A_1.a(A_0, A_2, A_3, num, a_);
				}
				if (textLineList.HasOverflow())
				{
					if (num2 <= 0.01f)
					{
						num -= num2;
						flag = false;
					}
					else
					{
						num -= num2;
						num2 /= 2f;
					}
				}
				else
				{
					num += num2;
				}
			}
			if (num < 4f)
			{
				num = 4f;
			}
			else if (num > 12f)
			{
				num = 12f;
			}
			return num;
		}

		// Token: 0x0600294D RID: 10573 RVA: 0x001834B8 File Offset: 0x001824B8
		private new float a(float A_0, Font A_1, float A_2)
		{
			float num = 0f;
			float num2 = 0f;
			this.a(ref num, ref num2, A_1);
			float num3 = (num + num2) / 2f * (A_2 / 1000f);
			return A_0 / 2f - num3;
		}

		// Token: 0x0600294E RID: 10574 RVA: 0x001834FD File Offset: 0x001824FD
		private new void a(ref float A_0, ref float A_1, Font A_2)
		{
			A_0 = (float)A_2.bh();
			A_1 = (float)A_2.bi();
		}

		// Token: 0x040012AD RID: 4781
		private new TextField a;
	}
}
