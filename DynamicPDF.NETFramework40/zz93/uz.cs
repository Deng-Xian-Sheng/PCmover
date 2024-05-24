using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000320 RID: 800
	internal class uz : to
	{
		// Token: 0x060022E2 RID: 8930 RVA: 0x0014D9D0 File Offset: 0x0014C9D0
		internal uz(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid String Reverse function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x060022E3 RID: 8931 RVA: 0x0014DA38 File Offset: 0x0014CA38
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x060022E4 RID: 8932 RVA: 0x0014DA58 File Offset: 0x0014CA58
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x060022E5 RID: 8933 RVA: 0x0014DA78 File Offset: 0x0014CA78
		internal override string eo(LayoutWriter A_0)
		{
			char[] array = this.a.eo(A_0).ToCharArray();
			Array.Reverse(array);
			return new string(array);
		}

		// Token: 0x060022E6 RID: 8934 RVA: 0x0014DAAC File Offset: 0x0014CAAC
		internal override string ep(LayoutWriter A_0, vi A_1)
		{
			char[] array = this.a.ep(A_0, A_1).ToCharArray();
			Array.Reverse(array);
			return new string(array);
		}

		// Token: 0x060022E7 RID: 8935 RVA: 0x0014DADE File Offset: 0x0014CADE
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x060022E8 RID: 8936 RVA: 0x0014DAF0 File Offset: 0x0014CAF0
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 10 && (A_0[A_1 + 1] == 't' || A_0[A_1 + 1] == 'T') && (A_0[A_1 + 2] == 'r' || A_0[A_1 + 2] == 'R') && (A_0[A_1 + 3] == 'r' || A_0[A_1 + 3] == 'R') && (A_0[A_1 + 4] == 'e' || A_0[A_1 + 4] == 'E') && (A_0[A_1 + 5] == 'v' || A_0[A_1 + 5] == 'V') && (A_0[A_1 + 6] == 'e' || A_0[A_1 + 6] == 'E') && (A_0[A_1 + 7] == 'r' || A_0[A_1 + 7] == 'R') && (A_0[A_1 + 8] == 's' || A_0[A_1 + 8] == 'S') && (A_0[A_1 + 9] == 'e' || A_0[A_1 + 9] == 'E') && (A_0[A_1] == 'S' || A_0[A_1] == 's');
		}

		// Token: 0x04000F08 RID: 3848
		private new q7 a;
	}
}
