using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000554 RID: 1364
	internal class ajw : aij
	{
		// Token: 0x060036A6 RID: 13990 RVA: 0x001DB2BC File Offset: 0x001DA2BC
		internal ajw(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.l();
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid Rate function detected.");
			}
			A_0.a(A_0.d() + 1);
			this.b = A_0.f();
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid Rate function detected.");
			}
			A_0.a(A_0.d() + 1);
			this.c = A_0.f();
			A_0.p();
			if (A_0.b() == ',')
			{
				A_0.a(A_0.d() + 1);
				this.d = A_0.f();
				A_0.p();
			}
			if (A_0.b() == ',')
			{
				A_0.a(A_0.d() + 1);
				this.e = A_0.j();
				A_0.p();
			}
			if (A_0.b() == ',')
			{
				A_0.a(A_0.d() + 1);
				this.f = A_0.f();
				A_0.p();
			}
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Rate function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060036A7 RID: 13991 RVA: 0x001DB454 File Offset: 0x001DA454
		internal override bool l4(LayoutWriter A_0)
		{
			return this.b.l4(A_0) || this.c.l4(A_0);
		}

		// Token: 0x060036A8 RID: 13992 RVA: 0x001DB484 File Offset: 0x001DA484
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.b.lw(A_0, A_1) || this.c.lw(A_0, A_1);
		}

		// Token: 0x060036A9 RID: 13993 RVA: 0x001DB4B8 File Offset: 0x001DA4B8
		internal override decimal l7(LayoutWriter A_0)
		{
			decimal a_;
			if (this.d == null)
			{
				a_ = 0m;
			}
			else
			{
				a_ = this.d.l7(A_0);
			}
			int num = this.e;
			ajv a_2;
			if (num != 180033844)
			{
				if (num != 384384250)
				{
					throw new DlexParseException("Invalid Rate function detected.");
				}
				a_2 = ajv.a;
			}
			else
			{
				a_2 = ajv.b;
			}
			decimal num2;
			if (this.f == null)
			{
				num2 = 0.033m;
			}
			else
			{
				num2 = this.f.l7(A_0);
			}
			decimal num3 = ajw.a(num2, this.a, this.b.l7(A_0), this.c.l7(A_0), a_, a_2);
			decimal num4;
			if (num3 > 0m)
			{
				num4 = num2 / 2m;
			}
			else
			{
				num4 = num2 * 2m;
			}
			decimal num5 = ajw.a(num4, this.a, this.b.l7(A_0), this.c.l7(A_0), a_, a_2);
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
					num3 = ajw.a(num2, this.a, this.b.l7(A_0), this.c.l7(A_0), a_, a_2);
				}
				num2 = num4 - (num4 - num2) * num5 / (num5 - num3);
				num3 = ajw.a(num2, this.a, this.b.l7(A_0), this.c.l7(A_0), a_, a_2);
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

		// Token: 0x060036AA RID: 13994 RVA: 0x001DB6E8 File Offset: 0x001DA6E8
		internal override decimal lz(LayoutWriter A_0, akk A_1)
		{
			decimal a_;
			if (this.d == null)
			{
				a_ = 0m;
			}
			else
			{
				a_ = this.d.lz(A_0, A_1);
			}
			int num = this.e;
			ajv a_2;
			if (num != 180033844)
			{
				if (num != 384384250)
				{
					throw new DlexParseException("Invalid Rate function detected.");
				}
				a_2 = ajv.a;
			}
			else
			{
				a_2 = ajv.b;
			}
			decimal num2;
			if (this.f == null)
			{
				num2 = 0.033m;
			}
			else
			{
				num2 = this.f.lz(A_0, A_1);
			}
			decimal num3 = ajw.a(num2, this.a, this.b.lz(A_0, A_1), this.c.lz(A_0, A_1), a_, a_2);
			decimal num4;
			if (num3 > 0m)
			{
				num4 = num2 / 2m;
			}
			else
			{
				num4 = num2 * 2m;
			}
			decimal num5 = ajw.a(num4, this.a, this.b.lz(A_0, A_1), this.c.lz(A_0, A_1), a_, a_2);
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
					num3 = ajw.a(num2, this.a, this.b.lz(A_0, A_1), this.c.lz(A_0, A_1), a_, a_2);
				}
				num2 = num4 - (num4 - num2) * num5 / (num5 - num3);
				num3 = ajw.a(num2, this.a, this.b.lz(A_0, A_1), this.c.lz(A_0, A_1), a_, a_2);
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

		// Token: 0x060036AB RID: 13995 RVA: 0x001DB91F File Offset: 0x001DA91F
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.b.mc(A_0, A_1, A_2);
			this.c.mc(A_0, A_1, A_2);
		}

		// Token: 0x060036AC RID: 13996 RVA: 0x001DB940 File Offset: 0x001DA940
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 4 && (A_0[A_1 + 1] == 'a' || A_0[A_1 + 1] == 'A') && (A_0[A_1 + 2] == 't' || A_0[A_1 + 2] == 'T') && (A_0[A_1 + 3] == 'e' || A_0[A_1 + 3] == 'E') && (A_0[A_1] == 'R' || A_0[A_1] == 'r');
		}

		// Token: 0x060036AD RID: 13997 RVA: 0x001DB9A4 File Offset: 0x001DA9A4
		private static decimal a(decimal A_0, int A_1, decimal A_2, decimal A_3, decimal A_4, ajv A_5)
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
				if (A_5 != ajv.b)
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

		// Token: 0x040019F3 RID: 6643
		private new int a;

		// Token: 0x040019F4 RID: 6644
		private new ahq b;

		// Token: 0x040019F5 RID: 6645
		private new ahq c;

		// Token: 0x040019F6 RID: 6646
		private new ahq d = null;

		// Token: 0x040019F7 RID: 6647
		private new int e = 384384250;

		// Token: 0x040019F8 RID: 6648
		private ahq f = null;
	}
}
