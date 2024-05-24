using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000534 RID: 1332
	internal class ai0 : aip
	{
		// Token: 0x060035B1 RID: 13745 RVA: 0x001D5E00 File Offset: 0x001D4E00
		internal ai0(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid CurrentDateTime variable detected.");
			}
			A_0.a(A_0.d() + 1);
			A_0.p();
		}

		// Token: 0x060035B2 RID: 13746 RVA: 0x001D5E5C File Offset: 0x001D4E5C
		internal override bool l4(LayoutWriter A_0)
		{
			return false;
		}

		// Token: 0x060035B3 RID: 13747 RVA: 0x001D5E70 File Offset: 0x001D4E70
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return false;
		}

		// Token: 0x060035B4 RID: 13748 RVA: 0x001D5E84 File Offset: 0x001D4E84
		internal override DateTime l6(LayoutWriter A_0)
		{
			return A_0.nc().a();
		}

		// Token: 0x060035B5 RID: 13749 RVA: 0x001D5EA4 File Offset: 0x001D4EA4
		internal override DateTime ly(LayoutWriter A_0, akk A_1)
		{
			return A_0.nc().a();
		}

		// Token: 0x060035B6 RID: 13750 RVA: 0x001D5EC1 File Offset: 0x001D4EC1
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
		}

		// Token: 0x060035B7 RID: 13751 RVA: 0x001D5EC4 File Offset: 0x001D4EC4
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 15 && (A_0[A_1 + 8] == 'a' || A_0[A_1 + 8] == 'A') && (A_0[A_1 + 9] == 't' || A_0[A_1 + 9] == 'T') && (A_0[A_1 + 10] == 'e' || A_0[A_1 + 10] == 'E') && (A_0[A_1 + 11] == 'T' || A_0[A_1 + 11] == 't') && (A_0[A_1 + 12] == 'i' || A_0[A_1 + 12] == 'I') && (A_0[A_1 + 13] == 'm' || A_0[A_1 + 13] == 'M') && (A_0[A_1 + 14] == 'e' || A_0[A_1 + 14] == 'E') && (A_0[A_1] == 'C' || A_0[A_1] == 'c') && (A_0[A_1 + 1] == 'u' || A_0[A_1 + 1] == 'U') && (A_0[A_1 + 2] == 'r' || A_0[A_1 + 2] == 'R') && (A_0[A_1 + 3] == 'r' || A_0[A_1 + 3] == 'R') && (A_0[A_1 + 4] == 'e' || A_0[A_1 + 4] == 'E') && (A_0[A_1 + 5] == 'n' || A_0[A_1 + 5] == 'N') && (A_0[A_1 + 6] == 't' || A_0[A_1 + 6] == 'T') && (A_0[A_1 + 7] == 'D' || A_0[A_1 + 7] == 'd');
		}
	}
}
