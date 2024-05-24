using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000547 RID: 1351
	internal class ajj : ai3
	{
		// Token: 0x0600364D RID: 13901 RVA: 0x001D92E8 File Offset: 0x001D82E8
		internal ajj(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Minute function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x0600364E RID: 13902 RVA: 0x001D9350 File Offset: 0x001D8350
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x0600364F RID: 13903 RVA: 0x001D9370 File Offset: 0x001D8370
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x06003650 RID: 13904 RVA: 0x001D9390 File Offset: 0x001D8390
		internal override int l9(LayoutWriter A_0)
		{
			return this.a.l6(A_0).Minute;
		}

		// Token: 0x06003651 RID: 13905 RVA: 0x001D93B8 File Offset: 0x001D83B8
		internal override int l1(LayoutWriter A_0, akk A_1)
		{
			return this.a.ly(A_0, A_1).Minute;
		}

		// Token: 0x06003652 RID: 13906 RVA: 0x001D93DF File Offset: 0x001D83DF
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x06003653 RID: 13907 RVA: 0x001D93F4 File Offset: 0x001D83F4
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 6 && (A_0[A_1 + 1] == 'i' || A_0[A_1 + 1] == 'I') && (A_0[A_1 + 2] == 'n' || A_0[A_1 + 2] == 'N') && (A_0[A_1 + 3] == 'u' || A_0[A_1 + 3] == 'U') && (A_0[A_1 + 4] == 't' || A_0[A_1 + 4] == 'T') && (A_0[A_1 + 5] == 'e' || A_0[A_1 + 5] == 'E') && (A_0[A_1] == 'M' || A_0[A_1] == 'm');
		}

		// Token: 0x040019D6 RID: 6614
		private new ahq a;
	}
}
