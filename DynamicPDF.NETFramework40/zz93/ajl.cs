using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000549 RID: 1353
	internal class ajl : ai3
	{
		// Token: 0x0600365C RID: 13916 RVA: 0x001D96FC File Offset: 0x001D86FC
		internal ajl(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Month function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x0600365D RID: 13917 RVA: 0x001D9764 File Offset: 0x001D8764
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x0600365E RID: 13918 RVA: 0x001D9784 File Offset: 0x001D8784
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x0600365F RID: 13919 RVA: 0x001D97A4 File Offset: 0x001D87A4
		internal override int l9(LayoutWriter A_0)
		{
			return this.a.l6(A_0).Month;
		}

		// Token: 0x06003660 RID: 13920 RVA: 0x001D97CC File Offset: 0x001D87CC
		internal override int l1(LayoutWriter A_0, akk A_1)
		{
			return this.a.ly(A_0, A_1).Month;
		}

		// Token: 0x06003661 RID: 13921 RVA: 0x001D97F3 File Offset: 0x001D87F3
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x06003662 RID: 13922 RVA: 0x001D9808 File Offset: 0x001D8808
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 5 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'n' || A_0[A_1 + 2] == 'N') && (A_0[A_1 + 3] == 't' || A_0[A_1 + 3] == 'T') && (A_0[A_1 + 4] == 'h' || A_0[A_1 + 4] == 'H') && (A_0[A_1] == 'M' || A_0[A_1] == 'm');
		}

		// Token: 0x040019D9 RID: 6617
		private new ahq a;
	}
}
