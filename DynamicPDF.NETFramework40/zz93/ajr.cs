using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200054F RID: 1359
	internal class ajr : aij
	{
		// Token: 0x0600368B RID: 13963 RVA: 0x001DA47C File Offset: 0x001D947C
		internal ajr(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.b = A_0.f();
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid PMT function detected.");
			}
			A_0.a(A_0.d() + 1);
			this.a = A_0.l();
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid PMT function detected.");
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
				throw new DlexParseException("Invalid PMT function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x0600368C RID: 13964 RVA: 0x001DA5D8 File Offset: 0x001D95D8
		internal override bool l4(LayoutWriter A_0)
		{
			return this.b.l4(A_0) || this.c.l4(A_0);
		}

		// Token: 0x0600368D RID: 13965 RVA: 0x001DA608 File Offset: 0x001D9608
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.b.lw(A_0, A_1) || this.c.lw(A_0, A_1);
		}

		// Token: 0x0600368E RID: 13966 RVA: 0x001DA63C File Offset: 0x001D963C
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
					throw new DlexParseException("Invalid PMT function detected.");
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
				result = (-num - this.c.l7(A_0)) / this.a;
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
				result = (-num - this.c.l7(A_0) * d2) / (d * --d2) * (this.b.l7(A_0) / 12m);
			}
			return result;
		}

		// Token: 0x0600368F RID: 13967 RVA: 0x001DA7BC File Offset: 0x001D97BC
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
					throw new DlexParseException("Invalid PMT function detected.");
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
				result = (-num - this.c.lz(A_0, A_1)) / this.a;
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
				result = (-num - this.c.lz(A_0, A_1) * d2) / (d * --d2) * (this.b.lz(A_0, A_1) / 12m);
			}
			return result;
		}

		// Token: 0x06003690 RID: 13968 RVA: 0x001DA943 File Offset: 0x001D9943
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.b.mc(A_0, A_1, A_2);
			this.c.mc(A_0, A_1, A_2);
		}

		// Token: 0x06003691 RID: 13969 RVA: 0x001DA964 File Offset: 0x001D9964
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'm' || A_0[A_1 + 1] == 'M') && (A_0[A_1 + 2] == 't' || A_0[A_1 + 2] == 'T') && (A_0[A_1] == 'P' || A_0[A_1] == 'p');
		}

		// Token: 0x040019E2 RID: 6626
		private new int a;

		// Token: 0x040019E3 RID: 6627
		private new ahq b;

		// Token: 0x040019E4 RID: 6628
		private new ahq c;

		// Token: 0x040019E5 RID: 6629
		private new ahq d = null;

		// Token: 0x040019E6 RID: 6630
		private new int e = 384384250;
	}
}
