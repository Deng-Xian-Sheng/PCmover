using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000309 RID: 777
	internal class uc : rc
	{
		// Token: 0x06002238 RID: 8760 RVA: 0x00149CD8 File Offset: 0x00148CD8
		internal uc(w5 A_0)
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
				throw new DplxParseException("Invalid Greater Than function detected.");
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
				throw new DplxParseException("Invalid Greater Than function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06002239 RID: 8761 RVA: 0x00149DB8 File Offset: 0x00148DB8
		internal uc(ArrayList A_0)
		{
			this.b = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x0600223A RID: 8762 RVA: 0x00149E20 File Offset: 0x00148E20
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0) || this.b.eq(A_0);
		}

		// Token: 0x0600223B RID: 8763 RVA: 0x00149E50 File Offset: 0x00148E50
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1) || this.b.er(A_0, A_1);
		}

		// Token: 0x0600223C RID: 8764 RVA: 0x00149E84 File Offset: 0x00148E84
		internal override bool ee(LayoutWriter A_0)
		{
			return decimal.Compare(this.a.ei(A_0), this.b.ei(A_0)) > 0;
		}

		// Token: 0x0600223D RID: 8765 RVA: 0x00149EB8 File Offset: 0x00148EB8
		internal override bool ef(LayoutWriter A_0, vi A_1)
		{
			return decimal.Compare(this.a.ej(A_0, A_1), this.b.ej(A_0, A_1)) > 0;
		}

		// Token: 0x0600223E RID: 8766 RVA: 0x00149EEC File Offset: 0x00148EEC
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
			this.b.eu(A_0, A_1, A_2);
		}

		// Token: 0x0600223F RID: 8767 RVA: 0x00149F10 File Offset: 0x00148F10
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 2 && (A_0[A_1 + 1] == 't' || A_0[A_1 + 1] == 'T') && (A_0[A_1] == 'G' || A_0[A_1] == 'g');
		}

		// Token: 0x04000ED4 RID: 3796
		private new q7 a;

		// Token: 0x04000ED5 RID: 3797
		private new q7 b;
	}
}
