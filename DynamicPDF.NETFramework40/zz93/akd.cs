using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000565 RID: 1381
	internal class akd : ait
	{
		// Token: 0x06003721 RID: 14113 RVA: 0x001DDB0C File Offset: 0x001DCB0C
		internal akd(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			if (A_0.b() != '"')
			{
				throw new DlexParseException("Invalid ReportParameters variable detected.");
			}
			A_0.a(A_0.d() + 1);
			int num = A_0.d();
			A_0.q();
			this.a = new string(A_0.c(), num, A_0.d() - num);
			A_0.a(A_0.d() + 1);
			A_0.p();
			if (A_0.b() != ']')
			{
				throw new DlexParseException("Invalid NetAppSettings variable detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x06003722 RID: 14114 RVA: 0x001DDBD0 File Offset: 0x001DCBD0
		internal override void lu(LayoutWriter A_0, alq A_1, char[] A_2)
		{
			string text = A_0.m6().a(this.a).ToString();
			if (text != null)
			{
				A_1.a(text);
			}
		}

		// Token: 0x06003723 RID: 14115 RVA: 0x001DDC08 File Offset: 0x001DCC08
		internal override bool l4(LayoutWriter A_0)
		{
			return A_0.m6().a(this.a) == null;
		}

		// Token: 0x06003724 RID: 14116 RVA: 0x001DDC30 File Offset: 0x001DCC30
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return A_0.m6().a(this.a) == null;
		}

		// Token: 0x06003725 RID: 14117 RVA: 0x001DDC58 File Offset: 0x001DCC58
		internal override object ma(LayoutWriter A_0)
		{
			return A_0.m6().a(this.a);
		}

		// Token: 0x06003726 RID: 14118 RVA: 0x001DDC7C File Offset: 0x001DCC7C
		internal override object l2(LayoutWriter A_0, akk A_1)
		{
			return A_0.m6().a(this.a);
		}

		// Token: 0x06003727 RID: 14119 RVA: 0x001DDC9F File Offset: 0x001DCC9F
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
		}

		// Token: 0x06003728 RID: 14120 RVA: 0x001DDCA4 File Offset: 0x001DCCA4
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 10 && (A_0[A_1] == 'P' || A_0[A_1] == 'p') && (A_0[A_1 + 1] == 'a' || A_0[A_1 + 1] == 'A') && (A_0[A_1 + 2] == 'r' || A_0[A_1 + 2] == 'R') && (A_0[A_1 + 3] == 'a' || A_0[A_1 + 3] == 'A') && (A_0[A_1 + 4] == 'm' || A_0[A_1 + 4] == 'M') && (A_0[A_1 + 5] == 'e' || A_0[A_1 + 5] == 'E') && (A_0[A_1 + 6] == 't' || A_0[A_1 + 6] == 'T') && (A_0[A_1 + 7] == 'e' || A_0[A_1 + 7] == 'E') && (A_0[A_1 + 8] == 'r' || A_0[A_1 + 8] == 'R') && (A_0[A_1 + 9] == 's' || A_0[A_1 + 9] == 'S');
		}

		// Token: 0x04001A12 RID: 6674
		private new string a;
	}
}
