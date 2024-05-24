using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000294 RID: 660
	internal class rd : rc
	{
		// Token: 0x06001D98 RID: 7576 RVA: 0x0012C314 File Offset: 0x0012B314
		internal rd(w5 A_0)
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
				throw new DplxParseException("Invalid NotEq function detected.");
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
				throw new DplxParseException("Invalid NotEq function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06001D99 RID: 7577 RVA: 0x0012C3F4 File Offset: 0x0012B3F4
		internal rd(ArrayList A_0)
		{
			this.b = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06001D9A RID: 7578 RVA: 0x0012C45C File Offset: 0x0012B45C
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0) || this.b.eq(A_0);
		}

		// Token: 0x06001D9B RID: 7579 RVA: 0x0012C48C File Offset: 0x0012B48C
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1) || this.b.er(A_0, A_1);
		}

		// Token: 0x06001D9C RID: 7580 RVA: 0x0012C4C0 File Offset: 0x0012B4C0
		internal override bool ee(LayoutWriter A_0)
		{
			return decimal.Compare(this.a.ei(A_0), this.b.ei(A_0)) != 0;
		}

		// Token: 0x06001D9D RID: 7581 RVA: 0x0012C4F8 File Offset: 0x0012B4F8
		internal override bool ef(LayoutWriter A_0, vi A_1)
		{
			return decimal.Compare(this.a.ej(A_0, A_1), this.b.ej(A_0, A_1)) != 0;
		}

		// Token: 0x06001D9E RID: 7582 RVA: 0x0012C52F File Offset: 0x0012B52F
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
			this.b.eu(A_0, A_1, A_2);
		}

		// Token: 0x06001D9F RID: 7583 RVA: 0x0012C550 File Offset: 0x0012B550
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 5 && (A_0[A_1 + 2] == 't' || A_0[A_1 + 2] == 'T') && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 3] == 'E' || A_0[A_1 + 3] == 'e') && (A_0[A_1 + 4] == 'q' || A_0[A_1 + 4] == 'Q') && (A_0[A_1] == 'N' || A_0[A_1] == 'n');
		}

		// Token: 0x04000D35 RID: 3381
		private new q7 a;

		// Token: 0x04000D36 RID: 3382
		private new q7 b;
	}
}
