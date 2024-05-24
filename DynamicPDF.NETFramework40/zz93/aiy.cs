using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000532 RID: 1330
	internal class aiy : aiq
	{
		// Token: 0x060035A3 RID: 13731 RVA: 0x001D5A50 File Offset: 0x001D4A50
		internal aiy(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Ceiling function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060035A4 RID: 13732 RVA: 0x001D5AB8 File Offset: 0x001D4AB8
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x060035A5 RID: 13733 RVA: 0x001D5AD8 File Offset: 0x001D4AD8
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x060035A6 RID: 13734 RVA: 0x001D5AF8 File Offset: 0x001D4AF8
		internal override double l8(LayoutWriter A_0)
		{
			return Math.Ceiling(this.a.l8(A_0));
		}

		// Token: 0x060035A7 RID: 13735 RVA: 0x001D5B1C File Offset: 0x001D4B1C
		internal override double l0(LayoutWriter A_0, akk A_1)
		{
			return Math.Ceiling(this.a.l0(A_0, A_1));
		}

		// Token: 0x060035A8 RID: 13736 RVA: 0x001D5B40 File Offset: 0x001D4B40
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x060035A9 RID: 13737 RVA: 0x001D5B54 File Offset: 0x001D4B54
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 7 && (A_0[A_1 + 1] == 'e' || A_0[A_1 + 1] == 'E') && (A_0[A_1 + 2] == 'i' || A_0[A_1 + 2] == 'I') && (A_0[A_1 + 3] == 'l' || A_0[A_1 + 3] == 'L') && (A_0[A_1 + 4] == 'i' || A_0[A_1 + 4] == 'I') && (A_0[A_1 + 5] == 'n' || A_0[A_1 + 5] == 'N') && (A_0[A_1 + 6] == 'g' || A_0[A_1 + 6] == 'G') && (A_0[A_1] == 'C' || A_0[A_1] == 'c');
		}

		// Token: 0x040019AF RID: 6575
		private new ahq a;
	}
}
