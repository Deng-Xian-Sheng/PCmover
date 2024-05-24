using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000303 RID: 771
	internal class t6 : ra
	{
		// Token: 0x0600220A RID: 8714 RVA: 0x00148C08 File Offset: 0x00147C08
		internal t6(w5 A_0)
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

		// Token: 0x0600220B RID: 8715 RVA: 0x00148CE8 File Offset: 0x00147CE8
		internal t6(ArrayList A_0)
		{
			this.b = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x0600220C RID: 8716 RVA: 0x00148D50 File Offset: 0x00147D50
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0) || this.b.eq(A_0);
		}

		// Token: 0x0600220D RID: 8717 RVA: 0x00148D80 File Offset: 0x00147D80
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1) || this.b.er(A_0, A_1);
		}

		// Token: 0x0600220E RID: 8718 RVA: 0x00148DB4 File Offset: 0x00147DB4
		internal override decimal ei(LayoutWriter A_0)
		{
			return decimal.Divide(this.a.ei(A_0), this.b.ei(A_0));
		}

		// Token: 0x0600220F RID: 8719 RVA: 0x00148DE4 File Offset: 0x00147DE4
		internal override decimal ej(LayoutWriter A_0, vi A_1)
		{
			return decimal.Divide(this.a.ej(A_0, A_1), this.b.ej(A_0, A_1));
		}

		// Token: 0x06002210 RID: 8720 RVA: 0x00148E15 File Offset: 0x00147E15
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
			this.b.eu(A_0, A_1, A_2);
		}

		// Token: 0x06002211 RID: 8721 RVA: 0x00148E38 File Offset: 0x00147E38
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 6 && (A_0[A_1 + 2] == 'v' || A_0[A_1 + 2] == 'V') && (A_0[A_1 + 3] == 'i' || A_0[A_1 + 3] == 'I') && (A_0[A_1 + 4] == 'd' || A_0[A_1 + 4] == 'D') && (A_0[A_1 + 5] == 'e' || A_0[A_1 + 5] == 'E') && (A_0[A_1] == 'D' || A_0[A_1] == 'd') && (A_0[A_1 + 1] == 'i' || A_0[A_1 + 1] == 'I');
		}

		// Token: 0x04000EC6 RID: 3782
		private new q7 a;

		// Token: 0x04000EC7 RID: 3783
		private new q7 b;
	}
}
