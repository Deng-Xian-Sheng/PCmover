using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200055A RID: 1370
	internal class aj2 : ai3
	{
		// Token: 0x060036D1 RID: 14033 RVA: 0x001DC37C File Offset: 0x001DB37C
		internal aj2(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid String Compare function detected.");
			}
			A_0.a(A_0.d() + 1);
			this.b = A_0.f();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid String Compare function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060036D2 RID: 14034 RVA: 0x001DC420 File Offset: 0x001DB420
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0) || this.b.l4(A_0);
		}

		// Token: 0x060036D3 RID: 14035 RVA: 0x001DC450 File Offset: 0x001DB450
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1) || this.b.lw(A_0, A_1);
		}

		// Token: 0x060036D4 RID: 14036 RVA: 0x001DC484 File Offset: 0x001DB484
		internal override int l9(LayoutWriter A_0)
		{
			return this.a.mb(A_0).CompareTo(this.b.mb(A_0));
		}

		// Token: 0x060036D5 RID: 14037 RVA: 0x001DC4B4 File Offset: 0x001DB4B4
		internal override int l1(LayoutWriter A_0, akk A_1)
		{
			return this.a.l3(A_0, A_1).CompareTo(this.b.l3(A_0, A_1));
		}

		// Token: 0x060036D6 RID: 14038 RVA: 0x001DC4E5 File Offset: 0x001DB4E5
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x060036D7 RID: 14039 RVA: 0x001DC4F8 File Offset: 0x001DB4F8
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 7 && (A_0[A_1 + 1] == 't' || A_0[A_1 + 1] == 'T') && (A_0[A_1 + 2] == 'r' || A_0[A_1 + 2] == 'R') && (A_0[A_1 + 3] == 'c' || A_0[A_1 + 3] == 'C') && (A_0[A_1 + 4] == 'o' || A_0[A_1 + 4] == 'O') && (A_0[A_1 + 5] == 'm' || A_0[A_1 + 5] == 'M') && (A_0[A_1 + 6] == 'p' || A_0[A_1 + 6] == 'P') && (A_0[A_1] == 'S' || A_0[A_1] == 's');
		}

		// Token: 0x04001A02 RID: 6658
		private new ahq a;

		// Token: 0x04001A03 RID: 6659
		private new ahq b;
	}
}
