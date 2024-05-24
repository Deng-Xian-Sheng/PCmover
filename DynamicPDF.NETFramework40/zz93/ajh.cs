using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000545 RID: 1349
	internal class ajh : aih
	{
		// Token: 0x0600363D RID: 13885 RVA: 0x001D8DE4 File Offset: 0x001D7DE4
		internal ajh(al5 A_0)
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
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid Less Than Equal function detected.");
			}
			A_0.a(A_0.d() + 1);
			A_0.p();
			if (A_0.v())
			{
				this.b = A_0.g();
			}
			else
			{
				this.b = A_0.f();
			}
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Less Than Equal function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x0600363E RID: 13886 RVA: 0x001D8EC4 File Offset: 0x001D7EC4
		internal ajh(ArrayList A_0)
		{
			this.b = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x0600363F RID: 13887 RVA: 0x001D8F2C File Offset: 0x001D7F2C
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0) || this.b.l4(A_0);
		}

		// Token: 0x06003640 RID: 13888 RVA: 0x001D8F5C File Offset: 0x001D7F5C
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1) || this.b.lw(A_0, A_1);
		}

		// Token: 0x06003641 RID: 13889 RVA: 0x001D8F90 File Offset: 0x001D7F90
		internal override bool l5(LayoutWriter A_0)
		{
			return decimal.Compare(this.a.l7(A_0), this.b.l7(A_0)) <= 0;
		}

		// Token: 0x06003642 RID: 13890 RVA: 0x001D8FC8 File Offset: 0x001D7FC8
		internal override bool lx(LayoutWriter A_0, akk A_1)
		{
			return decimal.Compare(this.a.lz(A_0, A_1), this.b.lz(A_0, A_1)) <= 0;
		}

		// Token: 0x06003643 RID: 13891 RVA: 0x001D8FFF File Offset: 0x001D7FFF
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
			this.b.mc(A_0, A_1, A_2);
		}

		// Token: 0x06003644 RID: 13892 RVA: 0x001D9020 File Offset: 0x001D8020
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 't' || A_0[A_1 + 1] == 'T') && (A_0[A_1 + 2] == 'e' || A_0[A_1 + 2] == 'E') && (A_0[A_1] == 'L' || A_0[A_1] == 'l');
		}

		// Token: 0x040019D2 RID: 6610
		private new ahq a;

		// Token: 0x040019D3 RID: 6611
		private new ahq b;
	}
}
