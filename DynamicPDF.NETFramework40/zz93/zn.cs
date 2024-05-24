using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Forms;

namespace zz93
{
	// Token: 0x020003D4 RID: 980
	internal class zn : cm
	{
		// Token: 0x06002936 RID: 10550 RVA: 0x00180AB2 File Offset: 0x0017FAB2
		internal zn(RadioButtonField A_0, float A_1, float A_2, acp A_3, DocumentWriter A_4, zh A_5) : base(A_0, A_1, A_2, A_4, A_5)
		{
			this.c = A_3;
			this.b = A_0;
		}

		// Token: 0x06002937 RID: 10551 RVA: 0x00180AD4 File Offset: 0x0017FAD4
		public new void c()
		{
			float a_;
			if (this.m < this.l)
			{
				a_ = this.m / 2f - 1f;
			}
			else
			{
				a_ = this.l / 2f - 1f;
			}
			if (this.c == acp.d)
			{
				this.g(a_);
			}
			else if (this.c == acp.e)
			{
				this.f(a_);
			}
			else if (this.c == acp.f)
			{
				this.e(a_);
			}
			else if (this.c == acp.g)
			{
				this.d(a_);
			}
		}

		// Token: 0x06002938 RID: 10552 RVA: 0x00180B8C File Offset: 0x0017FB8C
		private new void g(float A_0)
		{
			this.f(A_0);
			if (this.b.i7() == Symbol.Circle)
			{
				DeviceColor fillColor = Grayscale.Black;
				if (base.k().TextColor != null)
				{
					fillColor = base.k().TextColor;
				}
				base.SetFillColor(fillColor);
				base.Write_q_();
				this.c(A_0 / 2f);
				this.Write_f();
				base.Write_Q();
			}
			else
			{
				this.a(this.b);
			}
		}

		// Token: 0x06002939 RID: 10553 RVA: 0x00180C1C File Offset: 0x0017FC1C
		private new void f(float A_0)
		{
			if (this.b.i7() == Symbol.Circle)
			{
				if (base.k().BackgroundColor != null)
				{
					base.k().BackgroundColor.DrawFill(this);
				}
				else
				{
					Grayscale.White.DrawFill(this);
				}
				base.Write_q_();
				this.c(A_0);
				this.Write_f();
				base.Write_Q();
				if (base.k().BorderStyle != null)
				{
					if (base.k().BorderStyle.a() == 68)
					{
						base.a(base.k().BorderStyle);
					}
					else
					{
						base.Write_w_((float)base.k().BorderStyle.b());
					}
				}
				if (base.k().BorderColor != null)
				{
					base.k().BorderColor.DrawStroke(this);
				}
				base.Write_q_();
				this.c(A_0);
				this.Write_s_();
				base.Write_Q();
				if (base.k().BorderStyle != null && (base.k().BorderStyle.a() == 66 || base.k().BorderStyle.a() == 73))
				{
					if (base.k().BackgroundColor != null)
					{
						if (base.k().BorderStyle.a() == 66)
						{
							float a_ = base.k().BackgroundColor.R - 0.25f;
							float a_2 = base.k().BackgroundColor.G - 0.25f;
							float a_3 = base.k().BackgroundColor.B - 0.25f;
							base.f(a_, a_2, a_3);
						}
						else
						{
							this.Write_G(new Grayscale(0.75293f));
						}
					}
					else
					{
						this.Write_G(new Grayscale(0.749023f));
					}
					this.b(A_0 - (float)base.k().BorderStyle.b());
					this.Write_S();
					base.ResetDimensions();
					if (base.k().BorderStyle.a() == 66)
					{
						Grayscale.White.DrawStroke(this);
					}
					else
					{
						this.Write_G(new Grayscale(0.501953f));
					}
					this.a(A_0 - (float)base.k().BorderStyle.b());
					this.Write_S();
					base.ResetDimensions();
				}
			}
			else
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
		}

		// Token: 0x0600293A RID: 10554 RVA: 0x00180FF4 File Offset: 0x0017FFF4
		private new void e(float A_0)
		{
			this.d(A_0);
			if (this.b.i7() == Symbol.Circle)
			{
				DeviceColor fillColor = Grayscale.Black;
				if (base.k().TextColor != null)
				{
					fillColor = base.k().TextColor;
				}
				base.SetFillColor(fillColor);
				base.Write_q_();
				this.c(A_0 / 2f);
				this.Write_f();
				base.Write_Q();
			}
			else
			{
				this.a(this.b);
			}
		}

		// Token: 0x0600293B RID: 10555 RVA: 0x00181084 File Offset: 0x00180084
		private new void d(float A_0)
		{
			if (this.b.i7() == Symbol.Circle)
			{
				if (base.k().BackgroundColor != null)
				{
					if (base.k().BorderStyle != null && base.k().BorderStyle.a() == 66)
					{
						base.k().BackgroundColor.DrawFill(this);
					}
					else
					{
						float a_ = base.k().BackgroundColor.R - 0.25f;
						float a_2 = base.k().BackgroundColor.G - 0.25f;
						float a_3 = base.k().BackgroundColor.B - 0.25f;
						base.e(a_, a_2, a_3);
					}
				}
				else
				{
					this.Write_g_(new Grayscale(0.749023f));
				}
				base.Write_q_();
				this.c(A_0);
				this.Write_f();
				base.Write_Q();
				if (base.k().BorderStyle != null)
				{
					if (base.k().BorderStyle.a() == 68)
					{
						base.a(base.k().BorderStyle);
					}
					else
					{
						base.Write_w_((float)base.k().BorderStyle.b());
					}
				}
				if (base.k().BorderColor != null)
				{
					base.k().BorderColor.DrawStroke(this);
				}
				base.Write_q_();
				this.c(A_0);
				this.Write_s_();
				base.Write_Q();
				if (base.k().BorderStyle != null && (base.k().BorderStyle.a() == 66 || base.k().BorderStyle.a() == 73))
				{
					if (base.k().BackgroundColor != null)
					{
						if (base.k().BorderStyle.a() == 66)
						{
							float a_ = base.k().BackgroundColor.R - 0.25f;
							float a_2 = base.k().BackgroundColor.G - 0.25f;
							float a_3 = base.k().BackgroundColor.B - 0.25f;
							base.f(a_, a_2, a_3);
						}
						else
						{
							Grayscale.Black.DrawStroke(this);
						}
					}
					else
					{
						this.Write_G(new Grayscale(0.749023f));
					}
					this.a(A_0 - (float)base.k().BorderStyle.b());
					this.Write_S();
					base.ResetDimensions();
					Grayscale.White.DrawStroke(this);
					this.b(A_0 - (float)base.k().BorderStyle.b());
					this.Write_S();
					base.ResetDimensions();
				}
			}
			else
			{
				if (base.k().BackgroundColor != null)
				{
					float a_ = base.k().BackgroundColor.R - 0.25f;
					float a_2 = base.k().BackgroundColor.G - 0.25f;
					float a_3 = base.k().BackgroundColor.B - 0.25f;
					base.e(a_, a_2, a_3);
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
		}

		// Token: 0x0600293C RID: 10556 RVA: 0x00181508 File Offset: 0x00180508
		private new void c(float A_0)
		{
			float num = this.l / 2f;
			float num2 = this.m / 2f;
			base.SetGraphicsMode();
			this.Write_m_(num, num2 - A_0);
			this.Write_c(num + A_0 * 0.5522848f, num2 - A_0, num + A_0, num2 - A_0 * 0.5522848f, num + A_0, num2);
			this.Write_c(num + A_0, num2 + A_0 * 0.5522848f, num + A_0 * 0.5522848f, num2 + A_0, num, num2 + A_0);
			this.Write_c(num - A_0 * 0.5522848f, num2 + A_0, num - A_0, num2 + A_0 * 0.5522848f, num - A_0, num2);
			this.Write_c(num - A_0, num2 - A_0 * 0.5522848f, num - A_0 * 0.5522848f, num2 - A_0, num, num2 - A_0);
		}

		// Token: 0x0600293D RID: 10557 RVA: 0x001815D0 File Offset: 0x001805D0
		private new void b(float A_0)
		{
			float num = this.l / 2f;
			float num2 = this.m / 2f;
			base.SetDimensionsSimpleRotate(num, num2, 45f);
			this.Write_m_(num, num2 - A_0);
			this.Write_c(num + A_0 * 0.5522848f, num2 - A_0, num + A_0, num2 - A_0 * 0.5522848f, num + A_0, num2);
			this.Write_c(num + A_0, num2 + A_0 * 0.5522848f, num + A_0 * 0.5522848f, num2 + A_0, num, num2 + A_0);
		}

		// Token: 0x0600293E RID: 10558 RVA: 0x00181658 File Offset: 0x00180658
		private new void a(float A_0)
		{
			float num = this.l / 2f;
			float num2 = this.m / 2f;
			base.SetDimensionsSimpleRotate(num, num2, 45f);
			this.Write_m_(num, num2 + A_0);
			this.Write_c(num - A_0 * 0.5522848f, num2 + A_0, num - A_0, num2 + A_0 * 0.5522848f, num - A_0, num2);
			this.Write_c(num - A_0, num2 - A_0 * 0.5522848f, num - A_0 * 0.5522848f, num2 - A_0, num, num2 - A_0);
		}

		// Token: 0x0600293F RID: 10559 RVA: 0x001816E0 File Offset: 0x001806E0
		private new void a(RadioButtonField A_0)
		{
			float num = (float)((this.b.BorderStyle != null) ? this.b.BorderStyle.b() : 1);
			float l = this.l;
			base.Write_q_();
			this.Write_re(num, num, this.l - num * 2f, this.m - num * 2f);
			base.Write_W();
			base.Write_n();
			if (A_0.i7() != Symbol.Cross)
			{
				A_0.TextColor.DrawFill(this);
				int num2 = (int)A_0.i7();
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

		// Token: 0x06002940 RID: 10560 RVA: 0x001819BC File Offset: 0x001809BC
		private new float a(char A_0, Font A_1)
		{
			float num = (float)(base.l() * 2);
			if (base.l() > 1)
			{
				num = (float)(base.l() * 3);
			}
			if (this.b.BorderStyle != null && (this.b.BorderStyle.a() == 66 || this.b.BorderStyle.a() == 73))
			{
				num *= 2f;
			}
			float num2 = this.l * 0.85f - num;
			if (A_0 == '4')
			{
				if (this.l > this.m)
				{
					num2 = this.m * 0.85f - num;
				}
			}
			else if (this.l > this.m)
			{
				num2 = this.m * 0.77f - num;
			}
			int glyphWidth = (int)A_1.GetGlyphWidth(A_0);
			return num2 * 1000.001f / (float)glyphWidth;
		}

		// Token: 0x06002941 RID: 10561 RVA: 0x00181AC8 File Offset: 0x00180AC8
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

		// Token: 0x06002942 RID: 10562 RVA: 0x00181B24 File Offset: 0x00180B24
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

		// Token: 0x040012AA RID: 4778
		private new const float a = 0.5522848f;

		// Token: 0x040012AB RID: 4779
		private new RadioButtonField b;

		// Token: 0x040012AC RID: 4780
		private new acp c;
	}
}
