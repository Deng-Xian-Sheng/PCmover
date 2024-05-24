using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Forms;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x020003D0 RID: 976
	internal class zj : cm
	{
		// Token: 0x06002916 RID: 10518 RVA: 0x0017EB0E File Offset: 0x0017DB0E
		internal zj(ButtonField A_0, float A_1, float A_2, acp A_3, DocumentWriter A_4, zh A_5) : base(A_0, A_1, A_2, A_4, A_5)
		{
			this.b = A_0;
			this.a = A_3;
		}

		// Token: 0x06002917 RID: 10519 RVA: 0x0017EB30 File Offset: 0x0017DB30
		public new void i()
		{
			if (base.k() is ButtonField)
			{
				if (this.a == acp.a)
				{
					this.f();
				}
				else if (this.a == acp.b)
				{
					this.e();
				}
				else if (this.a == acp.c)
				{
					this.c();
				}
			}
		}

		// Token: 0x06002918 RID: 10520 RVA: 0x0017EBA4 File Offset: 0x0017DBA4
		private new void f()
		{
			this.a();
			if (this.b.i6() != null)
			{
				this.a(this.b.i6().ToCharArray());
			}
		}

		// Token: 0x06002919 RID: 10521 RVA: 0x0017EBE4 File Offset: 0x0017DBE4
		private new void e()
		{
			float num = (float)((this.b.BorderStyle != null) ? this.b.BorderStyle.b() : 1);
			if (this.b.BackgroundColor != null)
			{
				this.b.BackgroundColor.DrawFill(this);
			}
			else
			{
				this.Write_g_(new Grayscale(1f));
			}
			this.Write_re(0f, 0f, this.l, this.m);
			this.Write_f();
			if (this.b.BorderColor != null)
			{
				this.b.BorderColor.DrawStroke(this);
			}
			if (this.b.BorderStyle != null)
			{
				base.a(this.b.BorderStyle);
				if (this.b.BorderStyle.a() == 85)
				{
					this.Write_s_();
				}
				else
				{
					this.Write_re(num / 2f, num - num / 2f, this.l - num, this.m - num);
					this.Write_s_();
				}
			}
			base.Write_q_();
			this.Write_re(num, num, this.l - num * 2f, this.m - num * 2f);
			base.Write_W();
			base.Write_n();
			base.Write_cm(1f, -1f);
			string downLabel = ((PushBehavior)this.b.i5()).DownLabel;
			if (downLabel != null)
			{
				this.a(downLabel.ToCharArray());
			}
			else if (this.b.i6() != null)
			{
				this.a(this.b.i6().ToCharArray());
			}
		}

		// Token: 0x0600291A RID: 10522 RVA: 0x0017EDBC File Offset: 0x0017DDBC
		private new void c()
		{
			this.a();
			string rolloverLabel = ((PushBehavior)this.b.i5()).RolloverLabel;
			this.a(rolloverLabel.ToCharArray());
		}

		// Token: 0x0600291B RID: 10523 RVA: 0x0017EDF4 File Offset: 0x0017DDF4
		private new void a()
		{
			float num = (float)((this.b.BorderStyle != null) ? this.b.BorderStyle.b() : 1);
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
					this.Write_re(num / 2f, num - num / 2f, this.l - num, this.m - num);
					this.Write_s_();
				}
			}
			base.Write_q_();
			this.Write_re(num, num, this.l - num * 2f, this.m - num * 2f);
			base.Write_W();
			base.Write_n();
		}

		// Token: 0x0600291C RID: 10524 RVA: 0x0017EF4C File Offset: 0x0017DF4C
		private new void a(char[] A_0)
		{
			float y = this.m;
			float l = this.l;
			float num = this.m - 4f;
			Font font = this.b.Font;
			float num2 = this.b.FontSize;
			float num3 = (float)((base.l() == 0) ? 1 : base.l());
			if (num2 == 0f)
			{
				num2 = this.a(A_0, font, this.l - num3 * 2f, this.m - num3 * 2f);
			}
			base.a(true);
			base.b(font);
			base.Write_BT();
			this.Write_Tf(font, num2);
			base.k().TextColor.DrawFill(this);
			float x = l / 2f - font.GetTextWidth(A_0, num2) / 2f;
			y = num / 2f + font.GetDescender(num2);
			base.Write_Td_(x, y);
			base.b(A_0);
			base.Write_ET();
			base.Write_Q();
		}

		// Token: 0x0600291D RID: 10525 RVA: 0x0017F064 File Offset: 0x0017E064
		private new float a(char[] A_0, Font A_1, float A_2, float A_3)
		{
			bool flag = true;
			float num = 1f;
			float num2 = 5f;
			if (this.b.BorderStyle != null && (this.b.BorderStyle.a() == 66 || this.b.BorderStyle.a() == 73))
			{
				float num3 = (float)((base.l() == 0) ? 1 : base.l());
				A_2 -= num3 * 2f;
				A_3 -= num3 * 2f;
			}
			if ((!(A_1 is OpenTypeFont) || !((OpenTypeFont)A_1).a().ac().i()) && !(A_1 is c2))
			{
				A_3 *= 0.75f;
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

		// Token: 0x040012A3 RID: 4771
		private new acp a;

		// Token: 0x040012A4 RID: 4772
		private new ButtonField b;
	}
}
