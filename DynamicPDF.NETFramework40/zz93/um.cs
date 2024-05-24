using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000313 RID: 787
	internal class um : ra
	{
		// Token: 0x0600228B RID: 8843 RVA: 0x0014B5C4 File Offset: 0x0014A5C4
		internal um(w5 A_0)
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
				throw new DplxParseException("Invalid Format function detected.");
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
				throw new DplxParseException("Invalid Format function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x0600228C RID: 8844 RVA: 0x0014B6A4 File Offset: 0x0014A6A4
		internal um(ArrayList A_0)
		{
			this.b = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x0600228D RID: 8845 RVA: 0x0014B70C File Offset: 0x0014A70C
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0) || this.b.eq(A_0);
		}

		// Token: 0x0600228E RID: 8846 RVA: 0x0014B73C File Offset: 0x0014A73C
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1) || this.b.er(A_0, A_1);
		}

		// Token: 0x0600228F RID: 8847 RVA: 0x0014B770 File Offset: 0x0014A770
		internal override decimal ei(LayoutWriter A_0)
		{
			return decimal.Multiply(this.a.ei(A_0), this.b.ei(A_0));
		}

		// Token: 0x06002290 RID: 8848 RVA: 0x0014B7A0 File Offset: 0x0014A7A0
		internal override decimal ej(LayoutWriter A_0, vi A_1)
		{
			return decimal.Multiply(this.a.ej(A_0, A_1), this.b.ej(A_0, A_1));
		}

		// Token: 0x06002291 RID: 8849 RVA: 0x0014B7D1 File Offset: 0x0014A7D1
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
			this.b.eu(A_0, A_1, A_2);
		}

		// Token: 0x06002292 RID: 8850 RVA: 0x0014B7F4 File Offset: 0x0014A7F4
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 8 && (A_0[A_1 + 7] == 'y' || A_0[A_1 + 7] == 'Y') && (A_0[A_1] == 'M' || A_0[A_1] == 'm') && (A_0[A_1 + 1] == 'u' || A_0[A_1 + 1] == 'U') && (A_0[A_1 + 2] == 'l' || A_0[A_1 + 2] == 'L') && (A_0[A_1 + 3] == 't' || A_0[A_1 + 3] == 'T') && (A_0[A_1 + 4] == 'i' || A_0[A_1 + 4] == 'I') && (A_0[A_1 + 5] == 'p' || A_0[A_1 + 5] == 'P') && (A_0[A_1 + 6] == 'l' || A_0[A_1 + 6] == 'L');
		}

		// Token: 0x04000EE5 RID: 3813
		private new q7 a;

		// Token: 0x04000EE6 RID: 3814
		private new q7 b;
	}
}
