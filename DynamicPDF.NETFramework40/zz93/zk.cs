using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Forms;

namespace zz93
{
	// Token: 0x020003D1 RID: 977
	internal class zk : cm
	{
		// Token: 0x0600291E RID: 10526 RVA: 0x0017F1CC File Offset: 0x0017E1CC
		internal zk(CheckBoxField A_0, float A_1, float A_2, acp A_3, DocumentWriter A_4, zh A_5) : base(A_0, A_1, A_2, A_4, A_5)
		{
			this.a = A_3;
			this.b = A_0;
		}

		// Token: 0x0600291F RID: 10527 RVA: 0x0017F1F0 File Offset: 0x0017E1F0
		public void j()
		{
			if (this.a == acp.d)
			{
				this.i();
			}
			else if (this.a == acp.e)
			{
				this.f();
			}
			else if (this.a == acp.f)
			{
				this.e();
			}
			else if (this.a == acp.g)
			{
				this.c();
			}
		}

		// Token: 0x06002920 RID: 10528 RVA: 0x0017F260 File Offset: 0x0017E260
		private new void i()
		{
			this.f();
			if (base.k() is CheckBoxField)
			{
				this.a((CheckBoxField)base.k());
			}
		}

		// Token: 0x06002921 RID: 10529 RVA: 0x0017F29C File Offset: 0x0017E29C
		private new void f()
		{
			if (base.k().BackgroundColor != null)
			{
				base.k().BackgroundColor.DrawFill(this);
				this.Write_re(0f, 0f, this.l, this.m);
				this.Write_f();
			}
			if (base.k().BorderStyle != null)
			{
				base.a(base.k().BorderStyle);
			}
			if (base.k().BorderColor != null)
			{
				base.k().BorderColor.DrawStroke(this);
			}
			if (base.k().BorderStyle != null && base.k().BorderStyle.a() == 85)
			{
				this.Write_s_();
			}
			else
			{
				float num = (float)((this.b.BorderStyle != null) ? this.b.BorderStyle.b() : 1);
				this.Write_re(num / 2f, num - num / 2f, this.l - num, this.m - num);
				this.Write_s_();
			}
		}

		// Token: 0x06002922 RID: 10530 RVA: 0x0017F3C8 File Offset: 0x0017E3C8
		private new void a(CheckBoxField A_0)
		{
			float l = this.l;
			float num = (float)((this.b.BorderStyle != null) ? this.b.BorderStyle.b() : 1);
			base.Write_q_();
			this.Write_re(num, num, this.l - num * 2f, this.m - num * 2f);
			base.Write_W();
			base.Write_n();
			if (A_0.hf() != Symbol.Cross)
			{
				A_0.TextColor.DrawFill(this);
				int num2 = (int)A_0.hf();
				float num3 = A_0.FontSize;
				Font font = A_0.Font;
				if (num3 == 0f)
				{
					num3 = this.a((char)num2, font);
				}
				base.a(true);
				base.b(font);
				base.Write_BT();
				this.Write_Tf(font, num3);
				float x = (l - font.GetTextWidth(new char[]
				{
					(char)num2
				}, num3)) / 2f;
				float num4 = (float)((font.Ascender + font.Descender) / 2) * (num3 / 1000f);
				float y = this.m / 2f - num4;
				base.Write_Td_(x, y);
				this.a(num2);
				base.Write_ET();
			}
			else
			{
				base.k().TextColor.DrawStroke(this);
				if (base.k().BorderStyle != null && (base.k().BorderStyle.a() == 66 || base.k().BorderStyle.a() == 73))
				{
					num *= 2f;
				}
				float num5;
				float num6;
				if (this.l > this.m)
				{
					num5 = Math.Abs(this.l - this.m) / 2f;
					num6 = 0f;
				}
				else
				{
					num5 = 0f;
					num6 = Math.Abs(this.m - this.l) / 2f;
				}
				float x2 = num5 + num + 1f;
				float x3 = this.l - (num + 1f) - num5;
				float y2 = num6 + num + 1f;
				float y3 = this.m - (num + 1f) - num6;
				if (base.l() != 1)
				{
					base.Write_w_(1f);
				}
				if (base.k().BorderStyle != null && base.k().BorderStyle.a() == 68)
				{
					this.a();
				}
				this.Write_m_(x2, y2);
				this.Write_l_(x3, y3);
				this.Write_m_(x3, y2);
				this.Write_l_(x2, y3);
				this.Write_s_();
			}
			base.Write_Q();
		}

		// Token: 0x06002923 RID: 10531 RVA: 0x0017F6B4 File Offset: 0x0017E6B4
		private new void e()
		{
			this.c();
			if (base.k() is CheckBoxField)
			{
				this.a((CheckBoxField)base.k());
			}
		}

		// Token: 0x06002924 RID: 10532 RVA: 0x0017F6F0 File Offset: 0x0017E6F0
		private new void c()
		{
			if (base.k().BackgroundColor != null)
			{
				float a_ = base.k().BackgroundColor.R - 0.25f;
				float a_2 = base.k().BackgroundColor.G - 0.25f;
				float a_3 = base.k().BackgroundColor.B - 0.25f;
				base.f(a_, a_2, a_3);
			}
			else
			{
				this.Write_g_(new Grayscale(0.749023f));
			}
			this.Write_re(0f, 0f, this.l, this.m);
			this.Write_f();
			if (base.k().BorderStyle != null)
			{
				base.a(base.k().BorderStyle);
			}
			if (base.k().BorderColor != null)
			{
				base.k().BorderColor.DrawStroke(this);
			}
			if (base.k().BorderStyle != null && base.k().BorderStyle.a() == 85)
			{
				this.Write_s_();
			}
			else
			{
				float num = (float)((this.b.BorderStyle != null) ? this.b.BorderStyle.b() : 1);
				this.Write_re(num / 2f, num - num / 2f, this.l - num, this.m - num);
				this.Write_s_();
			}
		}

		// Token: 0x06002925 RID: 10533 RVA: 0x0017F878 File Offset: 0x0017E878
		private new float a(char A_0, Font A_1)
		{
			float num = (float)(base.l() * 3);
			if (this.b.BorderStyle != null && (this.b.BorderStyle.a() == 66 || this.b.BorderStyle.a() == 73))
			{
				if (base.l() > 1)
				{
					num = (float)(base.l() * 7);
				}
				else
				{
					num *= 2f;
				}
			}
			float num2 = this.l * 0.97f - num;
			if (this.l == this.m)
			{
				num2 = this.l * 0.85f - num;
			}
			if (A_0 == '4')
			{
				if (this.l > this.m)
				{
					num2 = this.m * 0.85f - num;
				}
			}
			else if (this.l > this.m)
			{
				num2 = this.m * 0.81f - num;
			}
			int glyphWidth = (int)A_1.GetGlyphWidth(A_0);
			return num2 * 1000.001f / (float)glyphWidth;
		}

		// Token: 0x06002926 RID: 10534 RVA: 0x0017F9AC File Offset: 0x0017E9AC
		private new void a(int A_0)
		{
			br br = base.s().b(7);
			br.a(40);
			br.a((byte)A_0);
			br.a(41);
			br.a(32);
			br.a(84);
			br.a(106);
			br.a(10);
		}

		// Token: 0x06002927 RID: 10535 RVA: 0x0017FA08 File Offset: 0x0017EA08
		private new void a()
		{
			br br = base.s().b(7);
			br.a(91);
			br.a(93);
			br.a(32);
			br.a(48);
			br.a(32);
			br.a(100);
			br.a(10);
		}

		// Token: 0x040012A5 RID: 4773
		private new acp a;

		// Token: 0x040012A6 RID: 4774
		private new CheckBoxField b;
	}
}
