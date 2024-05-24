using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200053D RID: 1341
	internal class ai9 : aij
	{
		// Token: 0x060035F9 RID: 13817 RVA: 0x001D755C File Offset: 0x001D655C
		internal ai9(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.b = A_0.f();
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid FV function detected.");
			}
			A_0.a(A_0.d() + 1);
			this.a = A_0.l();
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid FV function detected.");
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
				throw new DlexParseException("Invalid FV function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060035FA RID: 13818 RVA: 0x001D76B8 File Offset: 0x001D66B8
		internal override bool l4(LayoutWriter A_0)
		{
			return this.b.l4(A_0) || this.c.l4(A_0);
		}

		// Token: 0x060035FB RID: 13819 RVA: 0x001D76E8 File Offset: 0x001D66E8
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.b.lw(A_0, A_1) || this.c.lw(A_0, A_1);
		}

		// Token: 0x060035FC RID: 13820 RVA: 0x001D771C File Offset: 0x001D671C
		internal override decimal l7(LayoutWriter A_0)
		{
			decimal num;
			if (this.d == null)
			{
				num = 0m;
			}
			else
			{
				num = this.d.l7(A_0);
			}
			int num2 = this.e;
			ajv ajv;
			if (num2 != 180033844)
			{
				if (num2 != 384384250)
				{
					throw new DlexParseException("Invalid FV function detected.");
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
				result = -num - this.c.l7(A_0) * this.a;
			}
			else
			{
				decimal d;
				if (ajv != ajv.b)
				{
					d = ++(this.b.l7(A_0) / 12m);
				}
				else
				{
					d = 1m;
				}
				decimal d2 = (decimal)Math.Pow((double)(++(this.b.l7(A_0) / 12m)), (double)this.a);
				result = -num * d2 - this.c.l7(A_0) / this.b.l7(A_0) / 12m * d * --d2;
			}
			return result;
		}

		// Token: 0x060035FD RID: 13821 RVA: 0x001D789C File Offset: 0x001D689C
		internal override decimal lz(LayoutWriter A_0, akk A_1)
		{
			decimal num;
			if (this.d == null)
			{
				num = 0m;
			}
			else
			{
				num = this.d.lz(A_0, A_1);
			}
			int num2 = this.e;
			ajv ajv;
			if (num2 != 180033844)
			{
				if (num2 != 384384250)
				{
					throw new DlexParseException("Invalid FV function detected.");
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
				result = -num - this.c.lz(A_0, A_1) * this.a;
			}
			else
			{
				decimal d;
				if (ajv != ajv.b)
				{
					d = ++(this.b.lz(A_0, A_1) / 12m);
				}
				else
				{
					d = 1m;
				}
				decimal d2 = (decimal)Math.Pow((double)(++(this.b.lz(A_0, A_1) / 12m)), (double)this.a);
				result = -num * d2 - this.c.lz(A_0, A_1) / this.b.lz(A_0, A_1) / 12m * d * --d2;
			}
			return result;
		}

		// Token: 0x060035FE RID: 13822 RVA: 0x001D7A23 File Offset: 0x001D6A23
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.b.mc(A_0, A_1, A_2);
			this.c.mc(A_0, A_1, A_2);
		}

		// Token: 0x060035FF RID: 13823 RVA: 0x001D7A44 File Offset: 0x001D6A44
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 2 && (A_0[A_1 + 1] == 'v' || A_0[A_1 + 1] == 'V') && (A_0[A_1] == 'F' || A_0[A_1] == 'f');
		}

		// Token: 0x040019C0 RID: 6592
		private new int a;

		// Token: 0x040019C1 RID: 6593
		private new ahq b;

		// Token: 0x040019C2 RID: 6594
		private new ahq c;

		// Token: 0x040019C3 RID: 6595
		private new ahq d = null;

		// Token: 0x040019C4 RID: 6596
		private new int e = 384384250;
	}
}
