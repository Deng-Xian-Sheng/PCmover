using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000314 RID: 788
	internal class un : ra
	{
		// Token: 0x06002293 RID: 8851 RVA: 0x0014B8A4 File Offset: 0x0014A8A4
		internal un(w5 A_0)
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
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Negate function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06002294 RID: 8852 RVA: 0x0014B926 File Offset: 0x0014A926
		internal un(ArrayList A_0)
		{
			this.a = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06002295 RID: 8853 RVA: 0x0014B95C File Offset: 0x0014A95C
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x06002296 RID: 8854 RVA: 0x0014B97C File Offset: 0x0014A97C
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x06002297 RID: 8855 RVA: 0x0014B99C File Offset: 0x0014A99C
		internal override decimal ei(LayoutWriter A_0)
		{
			return decimal.Negate(this.a.ei(A_0));
		}

		// Token: 0x06002298 RID: 8856 RVA: 0x0014B9C0 File Offset: 0x0014A9C0
		internal override decimal ej(LayoutWriter A_0, vi A_1)
		{
			return decimal.Negate(this.a.ej(A_0, A_1));
		}

		// Token: 0x06002299 RID: 8857 RVA: 0x0014B9E4 File Offset: 0x0014A9E4
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x0600229A RID: 8858 RVA: 0x0014B9F8 File Offset: 0x0014A9F8
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 6 && (A_0[A_1 + 1] == 'e' || A_0[A_1 + 1] == 'E') && (A_0[A_1 + 2] == 'g' || A_0[A_1 + 2] == 'G') && (A_0[A_1 + 3] == 'a' || A_0[A_1 + 3] == 'A') && (A_0[A_1 + 4] == 't' || A_0[A_1 + 4] == 'T') && (A_0[A_1 + 5] == 'e' || A_0[A_1 + 5] == 'E') && (A_0[A_1] == 'N' || A_0[A_1] == 'n');
		}

		// Token: 0x04000EE7 RID: 3815
		private new q7 a;
	}
}
