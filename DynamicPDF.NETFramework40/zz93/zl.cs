using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger.Forms;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x020003D2 RID: 978
	internal class zl : cm
	{
		// Token: 0x06002928 RID: 10536 RVA: 0x0017FA62 File Offset: 0x0017EA62
		internal zl(ComboBoxField A_0, float A_1, float A_2, DocumentWriter A_3, zh A_4) : base(A_0, A_1, A_2, A_3, A_4)
		{
			this.a = A_0;
		}

		// Token: 0x06002929 RID: 10537 RVA: 0x0017FA88 File Offset: 0x0017EA88
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
			if (base.k().BorderStyle != null)
			{
				base.a(base.k().BorderStyle);
				if (base.k().BorderStyle.a() == 85)
				{
					this.Write_s_();
				}
				else
				{
					float num = (float)((this.a.BorderStyle != null) ? this.a.BorderStyle.b() : 1);
					this.Write_re(num / 2f, num - num / 2f, this.l - num, this.m - num);
					this.Write_s_();
				}
			}
			if (this.a.Default != null)
			{
				this.a();
			}
		}

		// Token: 0x0600292A RID: 10538 RVA: 0x0017FBC4 File Offset: 0x0017EBC4
		private new void a()
		{
			Font font = this.a.Font;
			float num = this.a.FontSize;
			DeviceColor textColor = base.k().TextColor;
			int num2 = (this.a.BorderStyle != null) ? ((this.a.BorderStyle.b() == 0) ? 2 : this.a.BorderStyle.b()) : 2;
			base.a(true);
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
			float num3 = (float)((this.a.BorderStyle != null) ? ((this.a.BorderStyle.b() == 0) ? 1 : this.a.BorderStyle.b()) : 1);
			string[] array = this.a.hg();
			string text = this.a(array);
			if (num <= 0f)
			{
				num = this.a(text.ToCharArray(), font, this.l - num3 * 2f, this.m - num3 * 2f);
			}
			float defaultLeading = font.GetDefaultLeading(num);
			base.n();
			base.Write_q_();
			this.Write_re((float)num2, (float)num2, this.l - (float)(num2 * 2), this.m - (float)(num2 * 2));
			base.Write_W();
			base.Write_n();
			base.Write_BT();
			this.Write_Tf(font, num);
			textColor.DrawFill(this);
			base.Write_Td_(2f, (this.m - defaultLeading) / 2f);
			if (this.a.Default != string.Empty)
			{
				bool flag = false;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] == this.a.Default)
					{
						base.Write_Tj_(this.a.Default.ToCharArray(), false);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					int num4;
					bool flag2 = int.TryParse(this.a.Default, out num4);
					if (flag2)
					{
						base.Write_Tj_(array[num4].ToCharArray(), false);
					}
				}
			}
			else
			{
				base.b(this.e().ToCharArray());
			}
			base.Write_ET();
			base.Write_Q();
			base.o();
		}

		// Token: 0x0600292B RID: 10539 RVA: 0x0017FEE8 File Offset: 0x0017EEE8
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

		// Token: 0x0600292C RID: 10540 RVA: 0x0017FFBC File Offset: 0x0017EFBC
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

		// Token: 0x0600292D RID: 10541 RVA: 0x0018001C File Offset: 0x0017F01C
		private new float a(char[] A_0, Font A_1, float A_2, float A_3)
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
			return num;
		}

		// Token: 0x0600292E RID: 10542 RVA: 0x00180148 File Offset: 0x0017F148
		internal new string e()
		{
			return this.b;
		}

		// Token: 0x0600292F RID: 10543 RVA: 0x00180160 File Offset: 0x0017F160
		internal new void a(string A_0)
		{
			this.b = A_0;
		}

		// Token: 0x040012A7 RID: 4775
		private new ComboBoxField a;

		// Token: 0x040012A8 RID: 4776
		private new string b = string.Empty;
	}
}
