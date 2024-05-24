using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000555 RID: 1365
	internal class ajx : ail
	{
		// Token: 0x060036AE RID: 13998 RVA: 0x001DBA48 File Offset: 0x001DAA48
		internal ajx(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid Replace function detected.");
			}
			A_0.a(A_0.d() + 1);
			this.b = A_0.f();
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid Replace function detected.");
			}
			A_0.a(A_0.d() + 1);
			this.c = A_0.f();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Replace function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060036AF RID: 13999 RVA: 0x001DBB28 File Offset: 0x001DAB28
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x060036B0 RID: 14000 RVA: 0x001DBB48 File Offset: 0x001DAB48
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x060036B1 RID: 14001 RVA: 0x001DBB68 File Offset: 0x001DAB68
		internal override string mb(LayoutWriter A_0)
		{
			return this.a.mb(A_0).Replace(this.b.mb(A_0), this.c.mb(A_0));
		}

		// Token: 0x060036B2 RID: 14002 RVA: 0x001DBBA4 File Offset: 0x001DABA4
		internal override string l3(LayoutWriter A_0, akk A_1)
		{
			return this.a.l3(A_0, A_1).Replace(this.b.l3(A_0, A_1), this.c.l3(A_0, A_1));
		}

		// Token: 0x060036B3 RID: 14003 RVA: 0x001DBBE2 File Offset: 0x001DABE2
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x060036B4 RID: 14004 RVA: 0x001DBBF4 File Offset: 0x001DABF4
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 7 && (A_0[A_1 + 1] == 'e' || A_0[A_1 + 1] == 'E') && (A_0[A_1 + 2] == 'p' || A_0[A_1 + 2] == 'P') && (A_0[A_1 + 3] == 'l' || A_0[A_1 + 3] == 'L') && (A_0[A_1 + 4] == 'a' || A_0[A_1 + 4] == 'A') && (A_0[A_1 + 5] == 'c' || A_0[A_1 + 5] == 'C') && (A_0[A_1 + 6] == 'e' || A_0[A_1 + 6] == 'E') && (A_0[A_1] == 'R' || A_0[A_1] == 'r');
		}

		// Token: 0x040019F9 RID: 6649
		private new ahq a;

		// Token: 0x040019FA RID: 6650
		private new ahq b;

		// Token: 0x040019FB RID: 6651
		private new ahq c;
	}
}
