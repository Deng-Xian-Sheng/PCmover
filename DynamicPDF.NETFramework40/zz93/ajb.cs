using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200053F RID: 1343
	internal class ajb : aih
	{
		// Token: 0x06003608 RID: 13832 RVA: 0x001D7D10 File Offset: 0x001D6D10
		internal ajb(al5 A_0)
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
				throw new DlexParseException("Invalid Greater Than function detected.");
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
				throw new DlexParseException("Invalid Greater Than function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x06003609 RID: 13833 RVA: 0x001D7DF0 File Offset: 0x001D6DF0
		internal ajb(ArrayList A_0)
		{
			this.b = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x0600360A RID: 13834 RVA: 0x001D7E58 File Offset: 0x001D6E58
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0) || this.b.l4(A_0);
		}

		// Token: 0x0600360B RID: 13835 RVA: 0x001D7E88 File Offset: 0x001D6E88
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1) || this.b.lw(A_0, A_1);
		}

		// Token: 0x0600360C RID: 13836 RVA: 0x001D7EBC File Offset: 0x001D6EBC
		internal override bool l5(LayoutWriter A_0)
		{
			return decimal.Compare(this.a.l7(A_0), this.b.l7(A_0)) > 0;
		}

		// Token: 0x0600360D RID: 13837 RVA: 0x001D7EF0 File Offset: 0x001D6EF0
		internal override bool lx(LayoutWriter A_0, akk A_1)
		{
			return decimal.Compare(this.a.lz(A_0, A_1), this.b.lz(A_0, A_1)) > 0;
		}

		// Token: 0x0600360E RID: 13838 RVA: 0x001D7F24 File Offset: 0x001D6F24
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
			this.b.mc(A_0, A_1, A_2);
		}

		// Token: 0x0600360F RID: 13839 RVA: 0x001D7F48 File Offset: 0x001D6F48
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 2 && (A_0[A_1 + 1] == 't' || A_0[A_1 + 1] == 'T') && (A_0[A_1] == 'G' || A_0[A_1] == 'g');
		}

		// Token: 0x040019C7 RID: 6599
		private new ahq a;

		// Token: 0x040019C8 RID: 6600
		private new ahq b;
	}
}
