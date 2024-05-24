using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000322 RID: 802
	internal class u1 : ra
	{
		// Token: 0x060022F0 RID: 8944 RVA: 0x0014DEAC File Offset: 0x0014CEAC
		internal u1(w5 A_0)
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
				throw new DplxParseException("Invalid Subtract function detected.");
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
				throw new DplxParseException("Invalid Subtract function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x060022F1 RID: 8945 RVA: 0x0014DF8C File Offset: 0x0014CF8C
		internal u1(ArrayList A_0)
		{
			this.b = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x060022F2 RID: 8946 RVA: 0x0014DFF4 File Offset: 0x0014CFF4
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0) || this.b.eq(A_0);
		}

		// Token: 0x060022F3 RID: 8947 RVA: 0x0014E024 File Offset: 0x0014D024
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1) || this.b.er(A_0, A_1);
		}

		// Token: 0x060022F4 RID: 8948 RVA: 0x0014E058 File Offset: 0x0014D058
		internal override decimal ei(LayoutWriter A_0)
		{
			return decimal.Subtract(this.a.ei(A_0), this.b.ei(A_0));
		}

		// Token: 0x060022F5 RID: 8949 RVA: 0x0014E088 File Offset: 0x0014D088
		internal override decimal ej(LayoutWriter A_0, vi A_1)
		{
			return decimal.Subtract(this.a.ej(A_0, A_1), this.b.ej(A_0, A_1));
		}

		// Token: 0x060022F6 RID: 8950 RVA: 0x0014E0B9 File Offset: 0x0014D0B9
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
			this.b.eu(A_0, A_1, A_2);
		}

		// Token: 0x060022F7 RID: 8951 RVA: 0x0014E0DC File Offset: 0x0014D0DC
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 8 && (A_0[A_1 + 4] == 'r' || A_0[A_1 + 4] == 'R') && (A_0[A_1 + 5] == 'a' || A_0[A_1 + 5] == 'A') && (A_0[A_1 + 6] == 'c' || A_0[A_1 + 6] == 'C') && (A_0[A_1 + 7] == 't' || A_0[A_1 + 7] == 'T') && (A_0[A_1] == 'S' || A_0[A_1] == 's') && (A_0[A_1 + 1] == 'u' || A_0[A_1 + 1] == 'U') && (A_0[A_1 + 2] == 'b' || A_0[A_1 + 2] == 'B') && (A_0[A_1 + 3] == 't' || A_0[A_1 + 3] == 'T');
		}

		// Token: 0x04000F0C RID: 3852
		private new q7 a;

		// Token: 0x04000F0D RID: 3853
		private new q7 b;
	}
}
