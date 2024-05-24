using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000305 RID: 773
	internal class t8 : tr
	{
		// Token: 0x0600221A RID: 8730 RVA: 0x00149138 File Offset: 0x00148138
		internal t8(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Floor function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x0600221B RID: 8731 RVA: 0x001491A0 File Offset: 0x001481A0
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x0600221C RID: 8732 RVA: 0x001491C0 File Offset: 0x001481C0
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x0600221D RID: 8733 RVA: 0x001491E0 File Offset: 0x001481E0
		internal override double ek(LayoutWriter A_0)
		{
			return Math.Floor(this.a.ek(A_0));
		}

		// Token: 0x0600221E RID: 8734 RVA: 0x00149204 File Offset: 0x00148204
		internal override double el(LayoutWriter A_0, vi A_1)
		{
			return Math.Floor(this.a.el(A_0, A_1));
		}

		// Token: 0x0600221F RID: 8735 RVA: 0x00149228 File Offset: 0x00148228
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x0014923C File Offset: 0x0014823C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 5 && (A_0[A_1 + 1] == 'l' || A_0[A_1 + 1] == 'L') && (A_0[A_1 + 2] == 'o' || A_0[A_1 + 2] == 'O') && (A_0[A_1 + 3] == 'o' || A_0[A_1 + 3] == 'O') && (A_0[A_1 + 4] == 'r' || A_0[A_1 + 4] == 'R') && (A_0[A_1] == 'F' || A_0[A_1] == 'f');
		}

		// Token: 0x04000ECA RID: 3786
		private new q7 a;
	}
}
