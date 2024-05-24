using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200055E RID: 1374
	internal class aj6 : ait
	{
		// Token: 0x060036EE RID: 14062 RVA: 0x001DCD50 File Offset: 0x001DBD50
		internal aj6(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			if (A_0.v())
			{
				this.a = A_0.g();
			}
			else
			{
				this.a = A_0.f();
			}
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Tilde function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060036EF RID: 14063 RVA: 0x001DCDD2 File Offset: 0x001DBDD2
		internal aj6(ArrayList A_0)
		{
			this.a = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x060036F0 RID: 14064 RVA: 0x001DCE08 File Offset: 0x001DBE08
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x060036F1 RID: 14065 RVA: 0x001DCE28 File Offset: 0x001DBE28
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x060036F2 RID: 14066 RVA: 0x001DCE48 File Offset: 0x001DBE48
		internal override object ma(LayoutWriter A_0)
		{
			object value = this.a.ma(A_0);
			return ~Convert.ToInt64(value);
		}

		// Token: 0x060036F3 RID: 14067 RVA: 0x001DCE74 File Offset: 0x001DBE74
		internal override object l2(LayoutWriter A_0, akk A_1)
		{
			object value = this.a.l2(A_0, A_1);
			return ~Convert.ToInt64(value);
		}

		// Token: 0x060036F4 RID: 14068 RVA: 0x001DCEA0 File Offset: 0x001DBEA0
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x060036F5 RID: 14069 RVA: 0x001DCEB4 File Offset: 0x001DBEB4
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 5 && (A_0[A_1 + 2] == 'l' || A_0[A_1 + 2] == 'L') && (A_0[A_1 + 1] == 'i' || A_0[A_1 + 1] == 'I') && (A_0[A_1 + 3] == 'd' || A_0[A_1 + 3] == 'D') && (A_0[A_1 + 4] == 'e' || A_0[A_1 + 4] == 'E') && (A_0[A_1] == 'T' || A_0[A_1] == 't');
		}

		// Token: 0x04001A0A RID: 6666
		private new ahq a;
	}
}
