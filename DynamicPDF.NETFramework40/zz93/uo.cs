using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000315 RID: 789
	internal class uo : ra
	{
		// Token: 0x0600229B RID: 8859 RVA: 0x0014BA80 File Offset: 0x0014AA80
		internal uo(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.b = A_0.g();
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid PMT function detected.");
			}
			A_0.a(A_0.e() + 1);
			this.a = A_0.m();
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid PMT function detected.");
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
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid PMT function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x0600229C RID: 8860 RVA: 0x0014BBDC File Offset: 0x0014ABDC
		internal override bool eq(LayoutWriter A_0)
		{
			return this.b.eq(A_0) || this.c.eq(A_0);
		}

		// Token: 0x0600229D RID: 8861 RVA: 0x0014BC0C File Offset: 0x0014AC0C
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.b.er(A_0, A_1) || this.c.er(A_0, A_1);
		}

		// Token: 0x0600229E RID: 8862 RVA: 0x0014BC40 File Offset: 0x0014AC40
		internal override decimal ei(LayoutWriter A_0)
		{
			decimal num;
			if (this.d == null)
			{
				num = 0m;
			}
			else
			{
				num = this.d.ei(A_0);
			}
			int num2 = this.e;
			ur ur;
			if (num2 != 180033844)
			{
				if (num2 != 384384250)
				{
					throw new DplxParseException("Invalid PMT function detected.");
				}
				ur = ur.a;
			}
			else
			{
				ur = ur.b;
			}
			decimal result;
			if (this.b.ei(A_0) / 12m == 0m)
			{
				result = (-num - this.c.ei(A_0)) / this.a;
			}
			else
			{
				decimal d;
				if (ur != ur.b)
				{
					d = ++(this.b.ei(A_0) / 12m);
				}
				else
				{
					d = 1m;
				}
				decimal d2 = (decimal)Math.Pow((double)(++(this.b.ei(A_0) / 12m)), (double)this.a);
				result = (-num - this.c.ei(A_0) * d2) / (d * --d2) * (this.b.ei(A_0) / 12m);
			}
			return result;
		}

		// Token: 0x0600229F RID: 8863 RVA: 0x0014BDC0 File Offset: 0x0014ADC0
		internal override decimal ej(LayoutWriter A_0, vi A_1)
		{
			decimal num;
			if (this.d == null)
			{
				num = 0m;
			}
			else
			{
				num = this.d.ej(A_0, A_1);
			}
			int num2 = this.e;
			ur ur;
			if (num2 != 180033844)
			{
				if (num2 != 384384250)
				{
					throw new DplxParseException("Invalid PMT function detected.");
				}
				ur = ur.a;
			}
			else
			{
				ur = ur.b;
			}
			decimal result;
			if (this.b.ej(A_0, A_1) / 12m == 0m)
			{
				result = (-num - this.c.ej(A_0, A_1)) / this.a;
			}
			else
			{
				decimal d;
				if (ur != ur.b)
				{
					d = ++(this.b.ej(A_0, A_1) / 12m);
				}
				else
				{
					d = 1m;
				}
				decimal d2 = (decimal)Math.Pow((double)(++(this.b.ej(A_0, A_1) / 12m)), (double)this.a);
				result = (-num - this.c.ej(A_0, A_1) * d2) / (d * --d2) * (this.b.ej(A_0, A_1) / 12m);
			}
			return result;
		}

		// Token: 0x060022A0 RID: 8864 RVA: 0x0014BF47 File Offset: 0x0014AF47
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.b.eu(A_0, A_1, A_2);
			this.c.eu(A_0, A_1, A_2);
		}

		// Token: 0x060022A1 RID: 8865 RVA: 0x0014BF68 File Offset: 0x0014AF68
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'm' || A_0[A_1 + 1] == 'M') && (A_0[A_1 + 2] == 't' || A_0[A_1 + 2] == 'T') && (A_0[A_1] == 'P' || A_0[A_1] == 'p');
		}

		// Token: 0x04000EE8 RID: 3816
		private new int a;

		// Token: 0x04000EE9 RID: 3817
		private new q7 b;

		// Token: 0x04000EEA RID: 3818
		private new q7 c;

		// Token: 0x04000EEB RID: 3819
		private new q7 d = null;

		// Token: 0x04000EEC RID: 3820
		private new int e = 384384250;
	}
}
