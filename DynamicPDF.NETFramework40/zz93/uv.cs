using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200031C RID: 796
	internal class uv : ra
	{
		// Token: 0x060022C6 RID: 8902 RVA: 0x0014D2D8 File Offset: 0x0014C2D8
		internal uv(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ',')
			{
				this.b = 2;
			}
			else
			{
				A_0.a(A_0.e() + 1);
				A_0.q();
				this.b = A_0.m();
			}
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Round function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x060022C7 RID: 8903 RVA: 0x0014D384 File Offset: 0x0014C384
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x060022C8 RID: 8904 RVA: 0x0014D3A4 File Offset: 0x0014C3A4
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x060022C9 RID: 8905 RVA: 0x0014D3C4 File Offset: 0x0014C3C4
		internal override decimal ei(LayoutWriter A_0)
		{
			return decimal.Round(this.a.ei(A_0), this.b);
		}

		// Token: 0x060022CA RID: 8906 RVA: 0x0014D3F0 File Offset: 0x0014C3F0
		internal override decimal ej(LayoutWriter A_0, vi A_1)
		{
			return decimal.Round(this.a.ej(A_0, A_1), this.b);
		}

		// Token: 0x060022CB RID: 8907 RVA: 0x0014D41A File Offset: 0x0014C41A
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x060022CC RID: 8908 RVA: 0x0014D42C File Offset: 0x0014C42C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 5 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'u' || A_0[A_1 + 2] == 'U') && (A_0[A_1 + 3] == 'n' || A_0[A_1 + 3] == 'N') && (A_0[A_1 + 4] == 'd' || A_0[A_1 + 4] == 'D') && (A_0[A_1] == 'R' || A_0[A_1] == 'r');
		}

		// Token: 0x04000F02 RID: 3842
		private new q7 a;

		// Token: 0x04000F03 RID: 3843
		private new int b;
	}
}
