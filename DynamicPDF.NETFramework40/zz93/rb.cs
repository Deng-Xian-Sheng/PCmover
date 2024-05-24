using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000292 RID: 658
	internal class rb : ra
	{
		// Token: 0x06001D83 RID: 7555 RVA: 0x0012BEE4 File Offset: 0x0012AEE4
		internal rb(w5 A_0)
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
				throw new DplxParseException("Invalid Mod function detected.");
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
				throw new DplxParseException("Invalid Mod function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06001D84 RID: 7556 RVA: 0x0012BFC4 File Offset: 0x0012AFC4
		internal rb(ArrayList A_0)
		{
			this.b = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06001D85 RID: 7557 RVA: 0x0012C02C File Offset: 0x0012B02C
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0) || this.b.eq(A_0);
		}

		// Token: 0x06001D86 RID: 7558 RVA: 0x0012C05C File Offset: 0x0012B05C
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1) || this.b.er(A_0, A_1);
		}

		// Token: 0x06001D87 RID: 7559 RVA: 0x0012C090 File Offset: 0x0012B090
		internal override decimal ei(LayoutWriter A_0)
		{
			return decimal.Remainder(this.a.ei(A_0), this.b.ei(A_0));
		}

		// Token: 0x06001D88 RID: 7560 RVA: 0x0012C0C0 File Offset: 0x0012B0C0
		internal override decimal ej(LayoutWriter A_0, vi A_1)
		{
			return decimal.Remainder(this.a.ej(A_0, A_1), this.b.ej(A_0, A_1));
		}

		// Token: 0x06001D89 RID: 7561 RVA: 0x0012C0F1 File Offset: 0x0012B0F1
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
			this.b.eu(A_0, A_1, A_2);
		}

		// Token: 0x06001D8A RID: 7562 RVA: 0x0012C114 File Offset: 0x0012B114
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 2] == 'd' || A_0[A_1 + 2] == 'D') && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1] == 'M' || A_0[A_1] == 'm');
		}

		// Token: 0x04000D33 RID: 3379
		private new q7 a;

		// Token: 0x04000D34 RID: 3380
		private new q7 b;
	}
}
