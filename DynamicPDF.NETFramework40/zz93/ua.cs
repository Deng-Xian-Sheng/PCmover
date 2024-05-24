using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000307 RID: 775
	internal class ua : ra
	{
		// Token: 0x06002229 RID: 8745 RVA: 0x00149524 File Offset: 0x00148524
		internal ua(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.b = A_0.g();
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid FV function detected.");
			}
			A_0.a(A_0.e() + 1);
			this.a = A_0.m();
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid FV function detected.");
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
				throw new DplxParseException("Invalid FV function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x0600222A RID: 8746 RVA: 0x00149680 File Offset: 0x00148680
		internal override bool eq(LayoutWriter A_0)
		{
			return this.b.eq(A_0) || this.c.eq(A_0);
		}

		// Token: 0x0600222B RID: 8747 RVA: 0x001496B0 File Offset: 0x001486B0
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.b.er(A_0, A_1) || this.c.er(A_0, A_1);
		}

		// Token: 0x0600222C RID: 8748 RVA: 0x001496E4 File Offset: 0x001486E4
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
					throw new DplxParseException("Invalid FV function detected.");
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
				result = -num - this.c.ei(A_0) * this.a;
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
				result = -num * d2 - this.c.ei(A_0) / this.b.ei(A_0) / 12m * d * --d2;
			}
			return result;
		}

		// Token: 0x0600222D RID: 8749 RVA: 0x00149864 File Offset: 0x00148864
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
					throw new DplxParseException("Invalid FV function detected.");
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
				result = -num - this.c.ej(A_0, A_1) * this.a;
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
				result = -num * d2 - this.c.ej(A_0, A_1) / this.b.ej(A_0, A_1) / 12m * d * --d2;
			}
			return result;
		}

		// Token: 0x0600222E RID: 8750 RVA: 0x001499EB File Offset: 0x001489EB
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.b.eu(A_0, A_1, A_2);
			this.c.eu(A_0, A_1, A_2);
		}

		// Token: 0x0600222F RID: 8751 RVA: 0x00149A0C File Offset: 0x00148A0C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 2 && (A_0[A_1 + 1] == 'v' || A_0[A_1 + 1] == 'V') && (A_0[A_1] == 'F' || A_0[A_1] == 'f');
		}

		// Token: 0x04000ECD RID: 3789
		private new int a;

		// Token: 0x04000ECE RID: 3790
		private new q7 b;

		// Token: 0x04000ECF RID: 3791
		private new q7 c;

		// Token: 0x04000ED0 RID: 3792
		private new q7 d = null;

		// Token: 0x04000ED1 RID: 3793
		private new int e = 384384250;
	}
}
