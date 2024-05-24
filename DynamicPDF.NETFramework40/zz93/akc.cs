using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000564 RID: 1380
	internal class akc : ai3
	{
		// Token: 0x0600371A RID: 14106 RVA: 0x001DD99C File Offset: 0x001DC99C
		internal akc(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Year function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x0600371B RID: 14107 RVA: 0x001DDA04 File Offset: 0x001DCA04
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x0600371C RID: 14108 RVA: 0x001DDA24 File Offset: 0x001DCA24
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x0600371D RID: 14109 RVA: 0x001DDA44 File Offset: 0x001DCA44
		internal override int l9(LayoutWriter A_0)
		{
			return this.a.l6(A_0).Year;
		}

		// Token: 0x0600371E RID: 14110 RVA: 0x001DDA6C File Offset: 0x001DCA6C
		internal override int l1(LayoutWriter A_0, akk A_1)
		{
			return this.a.ly(A_0, A_1).Year;
		}

		// Token: 0x0600371F RID: 14111 RVA: 0x001DDA93 File Offset: 0x001DCA93
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x06003720 RID: 14112 RVA: 0x001DDAA8 File Offset: 0x001DCAA8
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 4 && (A_0[A_1 + 1] == 'e' || A_0[A_1 + 1] == 'E') && (A_0[A_1 + 2] == 'a' || A_0[A_1 + 2] == 'A') && (A_0[A_1 + 3] == 'r' || A_0[A_1 + 3] == 'R') && (A_0[A_1] == 'Y' || A_0[A_1] == 'y');
		}

		// Token: 0x04001A11 RID: 6673
		private new ahq a;
	}
}
