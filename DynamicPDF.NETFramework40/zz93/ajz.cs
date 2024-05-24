using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000557 RID: 1367
	internal class ajz : aij
	{
		// Token: 0x060036BC RID: 14012 RVA: 0x001DBE9C File Offset: 0x001DAE9C
		internal ajz(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ',')
			{
				this.b = 2;
			}
			else
			{
				A_0.a(A_0.d() + 1);
				A_0.p();
				this.b = A_0.l();
			}
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Round function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060036BD RID: 14013 RVA: 0x001DBF48 File Offset: 0x001DAF48
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x060036BE RID: 14014 RVA: 0x001DBF68 File Offset: 0x001DAF68
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x060036BF RID: 14015 RVA: 0x001DBF88 File Offset: 0x001DAF88
		internal override decimal l7(LayoutWriter A_0)
		{
			return decimal.Round(this.a.l7(A_0), this.b);
		}

		// Token: 0x060036C0 RID: 14016 RVA: 0x001DBFB4 File Offset: 0x001DAFB4
		internal override decimal lz(LayoutWriter A_0, akk A_1)
		{
			return decimal.Round(this.a.lz(A_0, A_1), this.b);
		}

		// Token: 0x060036C1 RID: 14017 RVA: 0x001DBFDE File Offset: 0x001DAFDE
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x060036C2 RID: 14018 RVA: 0x001DBFF0 File Offset: 0x001DAFF0
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 5 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'u' || A_0[A_1 + 2] == 'U') && (A_0[A_1 + 3] == 'n' || A_0[A_1 + 3] == 'N') && (A_0[A_1 + 4] == 'd' || A_0[A_1 + 4] == 'D') && (A_0[A_1] == 'R' || A_0[A_1] == 'r');
		}

		// Token: 0x040019FE RID: 6654
		private new ahq a;

		// Token: 0x040019FF RID: 6655
		private new int b;
	}
}
