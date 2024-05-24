using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000308 RID: 776
	internal class ub : rc
	{
		// Token: 0x06002230 RID: 8752 RVA: 0x00149A4C File Offset: 0x00148A4C
		internal ub(w5 A_0)
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
				throw new DplxParseException("Invalid Greater Than Equal function detected.");
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
				throw new DplxParseException("Invalid Greater Than Equal function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06002231 RID: 8753 RVA: 0x00149B2C File Offset: 0x00148B2C
		internal ub(ArrayList A_0)
		{
			this.b = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06002232 RID: 8754 RVA: 0x00149B94 File Offset: 0x00148B94
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0) || this.b.eq(A_0);
		}

		// Token: 0x06002233 RID: 8755 RVA: 0x00149BC4 File Offset: 0x00148BC4
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1) || this.b.er(A_0, A_1);
		}

		// Token: 0x06002234 RID: 8756 RVA: 0x00149BF8 File Offset: 0x00148BF8
		internal override bool ee(LayoutWriter A_0)
		{
			return decimal.Compare(this.a.ei(A_0), this.b.ei(A_0)) >= 0;
		}

		// Token: 0x06002235 RID: 8757 RVA: 0x00149C30 File Offset: 0x00148C30
		internal override bool ef(LayoutWriter A_0, vi A_1)
		{
			return decimal.Compare(this.a.ej(A_0, A_1), this.b.ej(A_0, A_1)) >= 0;
		}

		// Token: 0x06002236 RID: 8758 RVA: 0x00149C67 File Offset: 0x00148C67
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
			this.b.eu(A_0, A_1, A_2);
		}

		// Token: 0x06002237 RID: 8759 RVA: 0x00149C88 File Offset: 0x00148C88
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 't' || A_0[A_1 + 1] == 'T') && (A_0[A_1 + 2] == 'e' || A_0[A_1 + 2] == 'E') && (A_0[A_1] == 'G' || A_0[A_1] == 'g');
		}

		// Token: 0x04000ED2 RID: 3794
		private new q7 a;

		// Token: 0x04000ED3 RID: 3795
		private new q7 b;
	}
}
