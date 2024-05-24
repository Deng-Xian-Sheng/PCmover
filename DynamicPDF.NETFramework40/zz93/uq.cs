using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000317 RID: 791
	internal class uq : ra
	{
		// Token: 0x060022A9 RID: 8873 RVA: 0x0014C1D0 File Offset: 0x0014B1D0
		internal uq(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.b = A_0.g();
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid PV function detected.");
			}
			A_0.a(A_0.e() + 1);
			this.a = A_0.m();
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid PV function detected.");
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
				throw new DplxParseException("Invalid PV function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x060022AA RID: 8874 RVA: 0x0014C32C File Offset: 0x0014B32C
		internal override bool eq(LayoutWriter A_0)
		{
			return this.b.eq(A_0) || this.c.eq(A_0);
		}

		// Token: 0x060022AB RID: 8875 RVA: 0x0014C35C File Offset: 0x0014B35C
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.b.er(A_0, A_1) || this.c.er(A_0, A_1);
		}

		// Token: 0x060022AC RID: 8876 RVA: 0x0014C390 File Offset: 0x0014B390
		internal override decimal ei(LayoutWriter A_0)
		{
			decimal d;
			if (this.d == null)
			{
				d = 0m;
			}
			else
			{
				d = this.d.ei(A_0);
			}
			int num = this.e;
			ur ur;
			if (num != 180033844)
			{
				if (num != 384384250)
				{
					throw new DplxParseException("Invalid PV function detected.");
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
				result = -d - this.c.ei(A_0) * this.a;
			}
			else
			{
				decimal d2;
				if (ur != ur.b)
				{
					d2 = ++(this.b.ei(A_0) / 12m);
				}
				else
				{
					d2 = 1m;
				}
				decimal d3 = (decimal)Math.Pow((double)(++(this.b.ei(A_0) / 12m)), (double)this.a);
				result = -(d + this.c.ei(A_0) * d2 * (--d3 / this.b.ei(A_0) / 12m)) / d3;
			}
			return result;
		}

		// Token: 0x060022AD RID: 8877 RVA: 0x0014C510 File Offset: 0x0014B510
		internal override decimal ej(LayoutWriter A_0, vi A_1)
		{
			decimal d;
			if (this.d == null)
			{
				d = 0m;
			}
			else
			{
				d = this.d.ej(A_0, A_1);
			}
			int num = this.e;
			ur ur;
			if (num != 180033844)
			{
				if (num != 384384250)
				{
					throw new DplxParseException("Invalid PV function detected.");
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
				result = -d - this.c.ej(A_0, A_1) * this.a;
			}
			else
			{
				decimal d2;
				if (ur != ur.b)
				{
					d2 = ++(this.b.ej(A_0, A_1) / 12m);
				}
				else
				{
					d2 = 1m;
				}
				decimal d3 = (decimal)Math.Pow((double)(++(this.b.ej(A_0, A_1) / 12m)), (double)this.a);
				result = -(d + this.c.ej(A_0, A_1) * d2 * (--d3 / this.b.ej(A_0, A_1) / 12m)) / d3;
			}
			return result;
		}

		// Token: 0x060022AE RID: 8878 RVA: 0x0014C697 File Offset: 0x0014B697
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.b.eu(A_0, A_1, A_2);
			this.c.eu(A_0, A_1, A_2);
		}

		// Token: 0x060022AF RID: 8879 RVA: 0x0014C6B8 File Offset: 0x0014B6B8
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 2 && (A_0[A_1 + 1] == 'v' || A_0[A_1 + 1] == 'V') && (A_0[A_1] == 'P' || A_0[A_1] == 'p');
		}

		// Token: 0x04000EEF RID: 3823
		private new int a;

		// Token: 0x04000EF0 RID: 3824
		private new q7 b;

		// Token: 0x04000EF1 RID: 3825
		private new q7 c;

		// Token: 0x04000EF2 RID: 3826
		private new q7 d = null;

		// Token: 0x04000EF3 RID: 3827
		private new int e = 384384250;
	}
}
