using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000560 RID: 1376
	internal class aj8 : ail
	{
		// Token: 0x060036FD RID: 14077 RVA: 0x001DD0C8 File Offset: 0x001DC0C8
		internal aj8(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid ToUpper function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060036FE RID: 14078 RVA: 0x001DD130 File Offset: 0x001DC130
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x060036FF RID: 14079 RVA: 0x001DD150 File Offset: 0x001DC150
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x06003700 RID: 14080 RVA: 0x001DD170 File Offset: 0x001DC170
		internal override string mb(LayoutWriter A_0)
		{
			return this.a.mb(A_0).ToUpper();
		}

		// Token: 0x06003701 RID: 14081 RVA: 0x001DD194 File Offset: 0x001DC194
		internal override string l3(LayoutWriter A_0, akk A_1)
		{
			return this.a.l3(A_0, A_1).ToUpper();
		}

		// Token: 0x06003702 RID: 14082 RVA: 0x001DD1B8 File Offset: 0x001DC1B8
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x06003703 RID: 14083 RVA: 0x001DD1CC File Offset: 0x001DC1CC
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 7 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'u' || A_0[A_1 + 2] == 'U') && (A_0[A_1 + 3] == 'p' || A_0[A_1 + 3] == 'P') && (A_0[A_1 + 4] == 'p' || A_0[A_1 + 4] == 'P') && (A_0[A_1 + 5] == 'e' || A_0[A_1 + 5] == 'E') && (A_0[A_1 + 6] == 'r' || A_0[A_1 + 6] == 'R') && (A_0[A_1] == 'T' || A_0[A_1] == 't');
		}

		// Token: 0x04001A0C RID: 6668
		private new ahq a;
	}
}
