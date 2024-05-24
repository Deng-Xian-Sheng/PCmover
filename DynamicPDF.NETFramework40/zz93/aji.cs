using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000546 RID: 1350
	internal class aji : aih
	{
		// Token: 0x06003645 RID: 13893 RVA: 0x001D9070 File Offset: 0x001D8070
		internal aji(al5 A_0)
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
				throw new DlexParseException("Invalid Less Than function detected.");
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
				throw new DlexParseException("Invalid Less Than function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x06003646 RID: 13894 RVA: 0x001D9150 File Offset: 0x001D8150
		internal aji(ArrayList A_0)
		{
			this.b = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06003647 RID: 13895 RVA: 0x001D91B8 File Offset: 0x001D81B8
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0) || this.b.l4(A_0);
		}

		// Token: 0x06003648 RID: 13896 RVA: 0x001D91E8 File Offset: 0x001D81E8
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1) || this.b.lw(A_0, A_1);
		}

		// Token: 0x06003649 RID: 13897 RVA: 0x001D921C File Offset: 0x001D821C
		internal override bool l5(LayoutWriter A_0)
		{
			return decimal.Compare(this.a.l7(A_0), this.b.l7(A_0)) < 0;
		}

		// Token: 0x0600364A RID: 13898 RVA: 0x001D9250 File Offset: 0x001D8250
		internal override bool lx(LayoutWriter A_0, akk A_1)
		{
			return decimal.Compare(this.a.lz(A_0, A_1), this.b.lz(A_0, A_1)) < 0;
		}

		// Token: 0x0600364B RID: 13899 RVA: 0x001D9284 File Offset: 0x001D8284
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
			this.b.mc(A_0, A_1, A_2);
		}

		// Token: 0x0600364C RID: 13900 RVA: 0x001D92A8 File Offset: 0x001D82A8
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 2 && (A_0[A_1 + 1] == 't' || A_0[A_1 + 1] == 'T') && (A_0[A_1] == 'L' || A_0[A_1] == 'l');
		}

		// Token: 0x040019D4 RID: 6612
		private new ahq a;

		// Token: 0x040019D5 RID: 6613
		private new ahq b;
	}
}
