using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200055F RID: 1375
	internal class aj7 : ail
	{
		// Token: 0x060036F6 RID: 14070 RVA: 0x001DCF28 File Offset: 0x001DBF28
		internal aj7(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid ToLower function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060036F7 RID: 14071 RVA: 0x001DCF90 File Offset: 0x001DBF90
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x060036F8 RID: 14072 RVA: 0x001DCFB0 File Offset: 0x001DBFB0
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x060036F9 RID: 14073 RVA: 0x001DCFD0 File Offset: 0x001DBFD0
		internal override string mb(LayoutWriter A_0)
		{
			return this.a.mb(A_0).ToLower();
		}

		// Token: 0x060036FA RID: 14074 RVA: 0x001DCFF4 File Offset: 0x001DBFF4
		internal override string l3(LayoutWriter A_0, akk A_1)
		{
			return this.a.l3(A_0, A_1).ToLower();
		}

		// Token: 0x060036FB RID: 14075 RVA: 0x001DD018 File Offset: 0x001DC018
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x060036FC RID: 14076 RVA: 0x001DD02C File Offset: 0x001DC02C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 7 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'l' || A_0[A_1 + 2] == 'L') && (A_0[A_1 + 3] == 'o' || A_0[A_1 + 3] == 'O') && (A_0[A_1 + 4] == 'w' || A_0[A_1 + 4] == 'W') && (A_0[A_1 + 5] == 'e' || A_0[A_1 + 5] == 'E') && (A_0[A_1 + 6] == 'r' || A_0[A_1 + 6] == 'R') && (A_0[A_1] == 'T' || A_0[A_1] == 't');
		}

		// Token: 0x04001A0B RID: 6667
		private new ahq a;
	}
}
