using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000552 RID: 1362
	internal class aju : aij
	{
		// Token: 0x0600369F RID: 13983 RVA: 0x001DAD94 File Offset: 0x001D9D94
		internal aju(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.b = A_0.f();
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid PV function detected.");
			}
			A_0.a(A_0.d() + 1);
			this.a = A_0.l();
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid PV function detected.");
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
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid PV function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060036A0 RID: 13984 RVA: 0x001DAEF0 File Offset: 0x001D9EF0
		internal override bool l4(LayoutWriter A_0)
		{
			return this.b.l4(A_0) || this.c.l4(A_0);
		}

		// Token: 0x060036A1 RID: 13985 RVA: 0x001DAF20 File Offset: 0x001D9F20
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.b.lw(A_0, A_1) || this.c.lw(A_0, A_1);
		}

		// Token: 0x060036A2 RID: 13986 RVA: 0x001DAF54 File Offset: 0x001D9F54
		internal override decimal l7(LayoutWriter A_0)
		{
			decimal d;
			if (this.d == null)
			{
				d = 0m;
			}
			else
			{
				d = this.d.l7(A_0);
			}
			int num = this.e;
			ajv ajv;
			if (num != 180033844)
			{
				if (num != 384384250)
				{
					throw new DlexParseException("Invalid PV function detected.");
				}
				ajv = ajv.a;
			}
			else
			{
				ajv = ajv.b;
			}
			decimal result;
			if (this.b.l7(A_0) / 12m == 0m)
			{
				result = -d - this.c.l7(A_0) * this.a;
			}
			else
			{
				decimal d2;
				if (ajv != ajv.b)
				{
					d2 = ++(this.b.l7(A_0) / 12m);
				}
				else
				{
					d2 = 1m;
				}
				decimal d3 = (decimal)Math.Pow((double)(++(this.b.l7(A_0) / 12m)), (double)this.a);
				result = -(d + this.c.l7(A_0) * d2 * (--d3 / this.b.l7(A_0) / 12m)) / d3;
			}
			return result;
		}

		// Token: 0x060036A3 RID: 13987 RVA: 0x001DB0D4 File Offset: 0x001DA0D4
		internal override decimal lz(LayoutWriter A_0, akk A_1)
		{
			decimal d;
			if (this.d == null)
			{
				d = 0m;
			}
			else
			{
				d = this.d.lz(A_0, A_1);
			}
			int num = this.e;
			ajv ajv;
			if (num != 180033844)
			{
				if (num != 384384250)
				{
					throw new DlexParseException("Invalid PV function detected.");
				}
				ajv = ajv.a;
			}
			else
			{
				ajv = ajv.b;
			}
			decimal result;
			if (this.b.lz(A_0, A_1) / 12m == 0m)
			{
				result = -d - this.c.lz(A_0, A_1) * this.a;
			}
			else
			{
				decimal d2;
				if (ajv != ajv.b)
				{
					d2 = ++(this.b.lz(A_0, A_1) / 12m);
				}
				else
				{
					d2 = 1m;
				}
				decimal d3 = (decimal)Math.Pow((double)(++(this.b.lz(A_0, A_1) / 12m)), (double)this.a);
				result = -(d + this.c.lz(A_0, A_1) * d2 * (--d3 / this.b.lz(A_0, A_1) / 12m)) / d3;
			}
			return result;
		}

		// Token: 0x060036A4 RID: 13988 RVA: 0x001DB25B File Offset: 0x001DA25B
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.b.mc(A_0, A_1, A_2);
			this.c.mc(A_0, A_1, A_2);
		}

		// Token: 0x060036A5 RID: 13989 RVA: 0x001DB27C File Offset: 0x001DA27C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 2 && (A_0[A_1 + 1] == 'v' || A_0[A_1 + 1] == 'V') && (A_0[A_1] == 'P' || A_0[A_1] == 'p');
		}

		// Token: 0x040019EB RID: 6635
		private new int a;

		// Token: 0x040019EC RID: 6636
		private new ahq b;

		// Token: 0x040019ED RID: 6637
		private new ahq c;

		// Token: 0x040019EE RID: 6638
		private new ahq d = null;

		// Token: 0x040019EF RID: 6639
		private new int e = 384384250;
	}
}
