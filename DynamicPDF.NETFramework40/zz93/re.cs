using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000295 RID: 661
	internal class re : rc
	{
		// Token: 0x06001DA0 RID: 7584 RVA: 0x0012C5C4 File Offset: 0x0012B5C4
		internal re(w5 A_0)
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
				throw new DplxParseException("Invalid Not function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06001DA1 RID: 7585 RVA: 0x0012C646 File Offset: 0x0012B646
		internal re(ArrayList A_0)
		{
			this.a = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06001DA2 RID: 7586 RVA: 0x0012C67C File Offset: 0x0012B67C
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x06001DA3 RID: 7587 RVA: 0x0012C69C File Offset: 0x0012B69C
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x06001DA4 RID: 7588 RVA: 0x0012C6BC File Offset: 0x0012B6BC
		internal override bool ee(LayoutWriter A_0)
		{
			return !this.a.ee(A_0);
		}

		// Token: 0x06001DA5 RID: 7589 RVA: 0x0012C6E0 File Offset: 0x0012B6E0
		internal override bool ef(LayoutWriter A_0, vi A_1)
		{
			return !this.a.ef(A_0, A_1);
		}

		// Token: 0x06001DA6 RID: 7590 RVA: 0x0012C702 File Offset: 0x0012B702
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x06001DA7 RID: 7591 RVA: 0x0012C714 File Offset: 0x0012B714
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 't' || A_0[A_1 + 2] == 'T') && (A_0[A_1] == 'N' || A_0[A_1] == 'n');
		}

		// Token: 0x04000D37 RID: 3383
		private new q7 a;
	}
}
