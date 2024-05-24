using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000316 RID: 790
	internal class up : tr
	{
		// Token: 0x060022A2 RID: 8866 RVA: 0x0014BFB8 File Offset: 0x0014AFB8
		internal up(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			if (A_0.w())
			{
				this.a = A_0.h();
			}
			else
			{
				this.a = A_0.g();
			}
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid Add function detected.");
			}
			A_0.a(A_0.e() + 1);
			A_0.q();
			if (A_0.w())
			{
				this.b = A_0.h();
			}
			else
			{
				this.b = A_0.g();
			}
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Add function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x060022A3 RID: 8867 RVA: 0x0014C098 File Offset: 0x0014B098
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0) || this.b.eq(A_0);
		}

		// Token: 0x060022A4 RID: 8868 RVA: 0x0014C0C8 File Offset: 0x0014B0C8
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1) || this.b.er(A_0, A_1);
		}

		// Token: 0x060022A5 RID: 8869 RVA: 0x0014C0FC File Offset: 0x0014B0FC
		internal override double ek(LayoutWriter A_0)
		{
			return Math.Pow(this.a.ek(A_0), this.b.ek(A_0));
		}

		// Token: 0x060022A6 RID: 8870 RVA: 0x0014C12C File Offset: 0x0014B12C
		internal override double el(LayoutWriter A_0, vi A_1)
		{
			return Math.Pow(this.a.el(A_0, A_1), this.b.el(A_0, A_1));
		}

		// Token: 0x060022A7 RID: 8871 RVA: 0x0014C15D File Offset: 0x0014B15D
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
			this.b.eu(A_0, A_1, A_2);
		}

		// Token: 0x060022A8 RID: 8872 RVA: 0x0014C180 File Offset: 0x0014B180
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'w' || A_0[A_1 + 2] == 'W') && (A_0[A_1] == 'P' || A_0[A_1] == 'p');
		}

		// Token: 0x04000EED RID: 3821
		private new q7 a;

		// Token: 0x04000EEE RID: 3822
		private new q7 b;
	}
}
