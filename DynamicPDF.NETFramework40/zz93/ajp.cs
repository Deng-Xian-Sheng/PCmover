using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200054D RID: 1357
	internal class ajp : aih
	{
		// Token: 0x0600367B RID: 13947 RVA: 0x001D9FE8 File Offset: 0x001D8FE8
		internal ajp(al5 A_0)
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
				throw new DlexParseException("Invalid Not function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x0600367C RID: 13948 RVA: 0x001DA06A File Offset: 0x001D906A
		internal ajp(ArrayList A_0)
		{
			this.a = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x0600367D RID: 13949 RVA: 0x001DA0A0 File Offset: 0x001D90A0
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x0600367E RID: 13950 RVA: 0x001DA0C0 File Offset: 0x001D90C0
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x0600367F RID: 13951 RVA: 0x001DA0E0 File Offset: 0x001D90E0
		internal override bool l5(LayoutWriter A_0)
		{
			return !this.a.l5(A_0);
		}

		// Token: 0x06003680 RID: 13952 RVA: 0x001DA104 File Offset: 0x001D9104
		internal override bool lx(LayoutWriter A_0, akk A_1)
		{
			return !this.a.lx(A_0, A_1);
		}

		// Token: 0x06003681 RID: 13953 RVA: 0x001DA126 File Offset: 0x001D9126
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x06003682 RID: 13954 RVA: 0x001DA138 File Offset: 0x001D9138
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 't' || A_0[A_1 + 2] == 'T') && (A_0[A_1] == 'N' || A_0[A_1] == 'n');
		}

		// Token: 0x040019DF RID: 6623
		private new ahq a;
	}
}
