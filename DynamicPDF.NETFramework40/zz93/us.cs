using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000319 RID: 793
	internal class us : ra
	{
		// Token: 0x060022B0 RID: 8880 RVA: 0x0014C6F8 File Offset: 0x0014B6F8
		internal us(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.m();
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid Rate function detected.");
			}
			A_0.a(A_0.e() + 1);
			this.b = A_0.g();
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid Rate function detected.");
			}
			A_0.a(A_0.e() + 1);
			this.c = A_0.g();
			A_0.q();
			if (A_0.c() == ',')
			{
				A_0.a(A_0.e() + 1);
				this.d = A_0.g();
				A_0.q();
			}
			if (A_0.c() == ',')
			{
				A_0.a(A_0.e() + 1);
				this.e = A_0.k();
				A_0.q();
			}
			if (A_0.c() == ',')
			{
				A_0.a(A_0.e() + 1);
				this.f = A_0.g();
				A_0.q();
			}
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Rate function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x060022B1 RID: 8881 RVA: 0x0014C890 File Offset: 0x0014B890
		internal override bool eq(LayoutWriter A_0)
		{
			return this.b.eq(A_0) || this.c.eq(A_0);
		}

		// Token: 0x060022B2 RID: 8882 RVA: 0x0014C8C0 File Offset: 0x0014B8C0
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.b.er(A_0, A_1) || this.c.er(A_0, A_1);
		}

		// Token: 0x060022B3 RID: 8883 RVA: 0x0014C8F4 File Offset: 0x0014B8F4
		internal override decimal ei(LayoutWriter A_0)
		{
			decimal a_;
			if (this.d == null)
			{
				a_ = 0m;
			}
			else
			{
				a_ = this.d.ei(A_0);
			}
			int num = this.e;
			ur a_2;
			if (num != 180033844)
			{
				if (num != 384384250)
				{
					throw new DplxParseException("Invalid Rate function detected.");
				}
				a_2 = ur.a;
			}
			else
			{
				a_2 = ur.b;
			}
			decimal num2;
			if (this.f == null)
			{
				num2 = 0.033m;
			}
			else
			{
				num2 = this.f.ei(A_0);
			}
			decimal num3 = us.a(num2, this.a, this.b.ei(A_0), this.c.ei(A_0), a_, a_2);
			decimal num4;
			if (num3 > 0m)
			{
				num4 = num2 / 2m;
			}
			else
			{
				num4 = num2 * 2m;
			}
			decimal num5 = us.a(num4, this.a, this.b.ei(A_0), this.c.ei(A_0), a_, a_2);
			for (;;)
			{
				if (num5 == num3)
				{
					if (num4 > num2)
					{
						num2 -= 0.00001m;
					}
					else
					{
						num2 -= -0.00001m;
					}
					num3 = us.a(num2, this.a, this.b.ei(A_0), this.c.ei(A_0), a_, a_2);
				}
				num2 = num4 - (num4 - num2) * num5 / (num5 - num3);
				num3 = us.a(num2, this.a, this.b.ei(A_0), this.c.ei(A_0), a_, a_2);
				if (Math.Abs(num3) < 0.0000001m)
				{
					break;
				}
				decimal num6 = num3;
				num3 = num5;
				num5 = num6;
				num6 = num2;
				num2 = num4;
				num4 = num6;
			}
			return num2;
		}

		// Token: 0x060022B4 RID: 8884 RVA: 0x0014CB24 File Offset: 0x0014BB24
		internal override decimal ej(LayoutWriter A_0, vi A_1)
		{
			decimal a_;
			if (this.d == null)
			{
				a_ = 0m;
			}
			else
			{
				a_ = this.d.ej(A_0, A_1);
			}
			int num = this.e;
			ur a_2;
			if (num != 180033844)
			{
				if (num != 384384250)
				{
					throw new DplxParseException("Invalid Rate function detected.");
				}
				a_2 = ur.a;
			}
			else
			{
				a_2 = ur.b;
			}
			decimal num2;
			if (this.f == null)
			{
				num2 = 0.033m;
			}
			else
			{
				num2 = this.f.ej(A_0, A_1);
			}
			decimal num3 = us.a(num2, this.a, this.b.ej(A_0, A_1), this.c.ej(A_0, A_1), a_, a_2);
			decimal num4;
			if (num3 > 0m)
			{
				num4 = num2 / 2m;
			}
			else
			{
				num4 = num2 * 2m;
			}
			decimal num5 = us.a(num4, this.a, this.b.ej(A_0, A_1), this.c.ej(A_0, A_1), a_, a_2);
			for (;;)
			{
				if (num5 == num3)
				{
					if (num4 > num2)
					{
						num2 -= 0.00001m;
					}
					else
					{
						num2 -= -0.00001m;
					}
					num3 = us.a(num2, this.a, this.b.ej(A_0, A_1), this.c.ej(A_0, A_1), a_, a_2);
				}
				num2 = num4 - (num4 - num2) * num5 / (num5 - num3);
				num3 = us.a(num2, this.a, this.b.ej(A_0, A_1), this.c.ej(A_0, A_1), a_, a_2);
				if (Math.Abs(num3) < 0.0000001m)
				{
					break;
				}
				decimal num6 = num3;
				num3 = num5;
				num5 = num6;
				num6 = num2;
				num2 = num4;
				num4 = num6;
			}
			return num2;
		}

		// Token: 0x060022B5 RID: 8885 RVA: 0x0014CD5B File Offset: 0x0014BD5B
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.b.eu(A_0, A_1, A_2);
			this.c.eu(A_0, A_1, A_2);
		}

		// Token: 0x060022B6 RID: 8886 RVA: 0x0014CD7C File Offset: 0x0014BD7C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 4 && (A_0[A_1 + 1] == 'a' || A_0[A_1 + 1] == 'A') && (A_0[A_1 + 2] == 't' || A_0[A_1 + 2] == 'T') && (A_0[A_1 + 3] == 'e' || A_0[A_1 + 3] == 'E') && (A_0[A_1] == 'R' || A_0[A_1] == 'r');
		}

		// Token: 0x060022B7 RID: 8887 RVA: 0x0014CDE0 File Offset: 0x0014BDE0
		private static decimal a(decimal A_0, int A_1, decimal A_2, decimal A_3, decimal A_4, ur A_5)
		{
			decimal result;
			if (A_0 == 0m)
			{
				result = A_3 + A_2 * A_1 + A_4;
			}
			else
			{
				decimal d = (decimal)Math.Pow((double)(++A_0), (double)A_1);
				decimal d2;
				if (A_5 != ur.b)
				{
					d2 = ++A_0;
				}
				else
				{
					d2 = 1m;
				}
				result = A_3 * d + A_2 * d2 * --d / A_0 + A_4;
			}
			return result;
		}

		// Token: 0x04000EF7 RID: 3831
		private new int a;

		// Token: 0x04000EF8 RID: 3832
		private new q7 b;

		// Token: 0x04000EF9 RID: 3833
		private new q7 c;

		// Token: 0x04000EFA RID: 3834
		private new q7 d = null;

		// Token: 0x04000EFB RID: 3835
		private new int e = 384384250;

		// Token: 0x04000EFC RID: 3836
		private q7 f = null;
	}
}
