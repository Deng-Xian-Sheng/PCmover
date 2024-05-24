using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000558 RID: 1368
	internal class aj0 : ai3
	{
		// Token: 0x060036C3 RID: 14019 RVA: 0x001DC064 File Offset: 0x001DB064
		internal aj0(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Second function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060036C4 RID: 14020 RVA: 0x001DC0CC File Offset: 0x001DB0CC
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x060036C5 RID: 14021 RVA: 0x001DC0EC File Offset: 0x001DB0EC
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x060036C6 RID: 14022 RVA: 0x001DC10C File Offset: 0x001DB10C
		internal override int l9(LayoutWriter A_0)
		{
			return this.a.l6(A_0).Second;
		}

		// Token: 0x060036C7 RID: 14023 RVA: 0x001DC134 File Offset: 0x001DB134
		internal override int l1(LayoutWriter A_0, akk A_1)
		{
			return this.a.ly(A_0, A_1).Second;
		}

		// Token: 0x060036C8 RID: 14024 RVA: 0x001DC15B File Offset: 0x001DB15B
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x060036C9 RID: 14025 RVA: 0x001DC170 File Offset: 0x001DB170
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 6 && (A_0[A_1 + 1] == 'e' || A_0[A_1 + 1] == 'E') && (A_0[A_1 + 2] == 'c' || A_0[A_1 + 2] == 'C') && (A_0[A_1 + 3] == 'o' || A_0[A_1 + 3] == 'O') && (A_0[A_1 + 4] == 'n' || A_0[A_1 + 4] == 'N') && (A_0[A_1 + 5] == 'd' || A_0[A_1 + 5] == 'D') && (A_0[A_1] == 'S' || A_0[A_1] == 's');
		}

		// Token: 0x04001A00 RID: 6656
		private new ahq a;
	}
}
