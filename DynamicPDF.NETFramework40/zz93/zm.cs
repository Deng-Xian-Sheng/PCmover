using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger.Forms;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x020003D3 RID: 979
	internal class zm : cm
	{
		// Token: 0x06002930 RID: 10544 RVA: 0x0018016A File Offset: 0x0017F16A
		internal zm(ListBoxField A_0, float A_1, float A_2, DocumentWriter A_3, zh A_4) : base(A_0, A_1, A_2, A_3, A_4)
		{
			this.a = A_0;
		}

		// Token: 0x06002931 RID: 10545 RVA: 0x00180184 File Offset: 0x0017F184
		public new void c()
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
			bool flag = false;
			float num = (this.a.BorderStyle != null) ? ((float)this.a.BorderStyle.b()) : 1f;
			if (base.k().BorderStyle != null)
			{
				base.a(base.k().BorderStyle);
				if (base.k().BorderStyle.a() == 85)
				{
					this.Write_s_();
					flag = true;
				}
				else
				{
					this.Write_re(num / 2f, num - num / 2f, this.l - num, this.m - num);
					this.Write_s_();
				}
			}
			if (this.a.hh() > 0)
			{
				this.a();
			}
			if (base.k().BorderStyle != null && !flag)
			{
				this.Write_re(num / 2f, num - num / 2f, this.l - num, this.m - num);
			}
			this.Write_s_();
		}

		// Token: 0x06002932 RID: 10546 RVA: 0x00180308 File Offset: 0x0017F308
		private new void a()
		{
			Font font = this.a.Font;
			float num = this.a.FontSize;
			DeviceColor textColor = base.k().TextColor;
			float l = this.l;
			float m = this.m;
			float num2 = (this.a.BorderStyle != null) ? ((float)(this.a.BorderStyle.b() * 2)) : 2f;
			string[] array = this.a.hj();
			string text = this.a(array);
			if (font != null)
			{
				base.a(this.a(font));
			}
			else
			{
				if (!base.k().UseSubstituteFont || (base.k().UseSubstituteFont && base.Document.Form.SubstituteFont == null))
				{
					throw new FontNotFoundException("One or more Form Field font not found.");
				}
				base.b(font = base.Document.Form.SubstituteFont);
			}
			if (base.m() != null)
			{
				font = ((base.m()[1] != null) ? base.m()[1] : ((base.m()[0] != null) ? base.m()[0] : this.a.Font));
			}
			if (num <= 0f)
			{
				num = this.a(text.ToCharArray(), font, l - num2 * 2f);
			}
			float num3 = (float)(font.bh() - font.bi()) * num / 1000f;
			float num4 = num2;
			int num5 = (int)Math.Round((double)((m - num2) / num3));
			if (num5 > 0)
			{
				base.a(true);
				base.n();
				base.Write_q_();
				this.Write_re(num2 / 2f, num2 - num2 / 2f, l - num2, m - num2);
				base.Write_W();
				base.Write_n();
				float num6 = m - num3;
				int num7 = array.Length;
				if (num7 > num5)
				{
					num7 = num5;
				}
				int num8 = 0;
				int num9;
				if (this.a.Value != null && !this.a.Value.Equals(string.Empty))
				{
					string[] array2 = this.a.Value.Split(new char[]
					{
						','
					});
					if (array2.Length > 1 && (this.a.Flags & FormFieldFlags.MultiSelect) != FormFieldFlags.MultiSelect)
					{
						throw new GeneratorException("The listbox does not have its multi select property set to true.");
					}
					for (int i = 0; i < array2.Length; i++)
					{
						num9 = this.a.hi(array2[i]);
						if (num9 != -1)
						{
							int num10;
							if (i <= 0 && num9 + 1 >= num5)
							{
								if (array.Length == num9 + 1)
								{
									num8 = array.Length - (num9 + 1);
								}
								else if (num9 + 1 == num5)
								{
									num8 = array.Length - num9 - 1;
								}
								else
								{
									num8 = array.Length - num9;
								}
								num9 -= num8;
								num10 = num9;
							}
							else
							{
								num10 = num9 - num8;
							}
							if (num10 <= num5)
							{
								float num11 = (float)base.l() + num3 * (float)num10;
								this.Write_rg_(new RgbColor(0.698044f, 0.705887f, 0.749023f));
								if (this.a.BorderStyle != null && (this.a.BorderStyle.a() == 66 || this.a.BorderStyle.a() == 73))
								{
									this.Write_re(num2, num11 + num2 / 2f, l - num2 * 2f, num3);
								}
								else
								{
									this.Write_re(num2 / 2f, num11, l - num2, num3);
								}
								this.Write_f();
							}
						}
					}
				}
				num6 = num6 - (float)font.bi() * num / 1000f - (float)base.l();
				if (this.a.BorderStyle != null && (this.a.BorderStyle.a() == 66 || this.a.BorderStyle.a() == 73))
				{
					num6 -= num2 / 2f;
					num4 += num2;
				}
				base.Write_BT();
				this.Write_Tf(font, num);
				textColor.DrawFill(this);
				base.Write_Td_(num4, num6);
				base.b(array[num8].ToCharArray());
				base.Write_ET();
				num9 = 1;
				while (num9 < num7 && num8 < array.Length - 1)
				{
					num6 -= num3;
					base.Write_BT();
					base.Write_Td_(num4, num6);
					base.b(array[++num8].ToCharArray());
					base.Write_ET();
					num9++;
				}
				base.Write_Q();
				base.o();
			}
		}

		// Token: 0x06002933 RID: 10547 RVA: 0x0018084C File Offset: 0x0017F84C
		private new Font[] a(Font A_0)
		{
			Font[] array = new Font[2];
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
					base.Document.Form.e().a(font);
					array[0] = font;
				}
				array[1] = A_0;
			}
			else
			{
				array[0] = A_0;
			}
			return array;
		}

		// Token: 0x06002934 RID: 10548 RVA: 0x00180920 File Offset: 0x0017F920
		private new string a(string[] A_0)
		{
			int num = 0;
			string result = "";
			foreach (string text in A_0)
			{
				if (num < text.Length)
				{
					num = text.Length;
					result = text;
				}
			}
			return result;
		}

		// Token: 0x06002935 RID: 10549 RVA: 0x00180980 File Offset: 0x0017F980
		private new float a(char[] A_0, Font A_1, float A_2)
		{
			bool flag = true;
			float num = 1f;
			float num2 = 5f;
			if (this.a.BorderStyle != null && (this.a.BorderStyle.a() == 66 || this.a.BorderStyle.a() == 73))
			{
				float num3 = (float)((this.a.BorderStyle.b() == 0) ? 1 : this.a.BorderStyle.b());
				A_2 -= num3 * 4f;
			}
			while (flag && num < 1600f)
			{
				float textWidth = A_1.GetTextWidth(A_0, num);
				if (textWidth >= A_2)
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

		// Token: 0x040012A9 RID: 4777
		private new ListBoxField a;
	}
}
