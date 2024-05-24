using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200055B RID: 1371
	internal class aj3 : ail
	{
		// Token: 0x060036D8 RID: 14040 RVA: 0x001DC594 File Offset: 0x001DB594
		internal aj3(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid String Reverse function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060036D9 RID: 14041 RVA: 0x001DC5FC File Offset: 0x001DB5FC
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x060036DA RID: 14042 RVA: 0x001DC61C File Offset: 0x001DB61C
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x060036DB RID: 14043 RVA: 0x001DC63C File Offset: 0x001DB63C
		internal override string mb(LayoutWriter A_0)
		{
			char[] array = this.a.mb(A_0).ToCharArray();
			Array.Reverse(array);
			return new string(array);
		}

		// Token: 0x060036DC RID: 14044 RVA: 0x001DC670 File Offset: 0x001DB670
		internal override string l3(LayoutWriter A_0, akk A_1)
		{
			char[] array = this.a.l3(A_0, A_1).ToCharArray();
			Array.Reverse(array);
			return new string(array);
		}

		// Token: 0x060036DD RID: 14045 RVA: 0x001DC6A2 File Offset: 0x001DB6A2
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x060036DE RID: 14046 RVA: 0x001DC6B4 File Offset: 0x001DB6B4
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 10 && (A_0[A_1 + 1] == 't' || A_0[A_1 + 1] == 'T') && (A_0[A_1 + 2] == 'r' || A_0[A_1 + 2] == 'R') && (A_0[A_1 + 3] == 'r' || A_0[A_1 + 3] == 'R') && (A_0[A_1 + 4] == 'e' || A_0[A_1 + 4] == 'E') && (A_0[A_1 + 5] == 'v' || A_0[A_1 + 5] == 'V') && (A_0[A_1 + 6] == 'e' || A_0[A_1 + 6] == 'E') && (A_0[A_1 + 7] == 'r' || A_0[A_1 + 7] == 'R') && (A_0[A_1 + 8] == 's' || A_0[A_1 + 8] == 'S') && (A_0[A_1 + 9] == 'e' || A_0[A_1 + 9] == 'E') && (A_0[A_1] == 'S' || A_0[A_1] == 's');
		}

		// Token: 0x04001A04 RID: 6660
		private new ahq a;
	}
}
