using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000561 RID: 1377
	internal class aj9 : ail
	{
		// Token: 0x06003704 RID: 14084 RVA: 0x001DD268 File Offset: 0x001DC268
		internal aj9(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Trim function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x06003705 RID: 14085 RVA: 0x001DD2D0 File Offset: 0x001DC2D0
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x06003706 RID: 14086 RVA: 0x001DD2F0 File Offset: 0x001DC2F0
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x06003707 RID: 14087 RVA: 0x001DD310 File Offset: 0x001DC310
		internal override string mb(LayoutWriter A_0)
		{
			return this.a.mb(A_0).Trim();
		}

		// Token: 0x06003708 RID: 14088 RVA: 0x001DD334 File Offset: 0x001DC334
		internal override string l3(LayoutWriter A_0, akk A_1)
		{
			return this.a.l3(A_0, A_1).Trim();
		}

		// Token: 0x06003709 RID: 14089 RVA: 0x001DD358 File Offset: 0x001DC358
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x0600370A RID: 14090 RVA: 0x001DD36C File Offset: 0x001DC36C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 4 && (A_0[A_1 + 1] == 'r' || A_0[A_1 + 1] == 'R') && (A_0[A_1 + 2] == 'i' || A_0[A_1 + 2] == 'I') && (A_0[A_1 + 3] == 'm' || A_0[A_1 + 3] == 'M') && (A_0[A_1] == 'T' || A_0[A_1] == 't');
		}

		// Token: 0x04001A0D RID: 6669
		private new ahq a;
	}
}
