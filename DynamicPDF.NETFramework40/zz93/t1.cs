using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002FE RID: 766
	internal class t1 : tq
	{
		// Token: 0x060021E1 RID: 8673 RVA: 0x00147DC8 File Offset: 0x00146DC8
		internal t1(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid CurrentDateTime variable detected.");
			}
			A_0.a(A_0.e() + 1);
			A_0.q();
		}

		// Token: 0x060021E2 RID: 8674 RVA: 0x00147E24 File Offset: 0x00146E24
		internal override bool eq(LayoutWriter A_0)
		{
			return false;
		}

		// Token: 0x060021E3 RID: 8675 RVA: 0x00147E38 File Offset: 0x00146E38
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return false;
		}

		// Token: 0x060021E4 RID: 8676 RVA: 0x00147E4C File Offset: 0x00146E4C
		internal override DateTime eg(LayoutWriter A_0)
		{
			return A_0.ez().a();
		}

		// Token: 0x060021E5 RID: 8677 RVA: 0x00147E6C File Offset: 0x00146E6C
		internal override DateTime eh(LayoutWriter A_0, vi A_1)
		{
			return A_0.ez().a();
		}

		// Token: 0x060021E6 RID: 8678 RVA: 0x00147E89 File Offset: 0x00146E89
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
		}

		// Token: 0x060021E7 RID: 8679 RVA: 0x00147E8C File Offset: 0x00146E8C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 15 && (A_0[A_1 + 8] == 'a' || A_0[A_1 + 8] == 'A') && (A_0[A_1 + 9] == 't' || A_0[A_1 + 9] == 'T') && (A_0[A_1 + 10] == 'e' || A_0[A_1 + 10] == 'E') && (A_0[A_1 + 11] == 'T' || A_0[A_1 + 11] == 't') && (A_0[A_1 + 12] == 'i' || A_0[A_1 + 12] == 'I') && (A_0[A_1 + 13] == 'm' || A_0[A_1 + 13] == 'M') && (A_0[A_1 + 14] == 'e' || A_0[A_1 + 14] == 'E') && (A_0[A_1] == 'C' || A_0[A_1] == 'c') && (A_0[A_1 + 1] == 'u' || A_0[A_1 + 1] == 'U') && (A_0[A_1 + 2] == 'r' || A_0[A_1 + 2] == 'R') && (A_0[A_1 + 3] == 'r' || A_0[A_1 + 3] == 'R') && (A_0[A_1 + 4] == 'e' || A_0[A_1 + 4] == 'E') && (A_0[A_1 + 5] == 'n' || A_0[A_1 + 5] == 'N') && (A_0[A_1 + 6] == 't' || A_0[A_1 + 6] == 'T') && (A_0[A_1 + 7] == 'D' || A_0[A_1 + 7] == 'd');
		}
	}
}
