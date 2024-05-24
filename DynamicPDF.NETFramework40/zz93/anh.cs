using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x020005DB RID: 1499
	internal class anh : aih
	{
		// Token: 0x06003B60 RID: 15200 RVA: 0x001FC394 File Offset: 0x001FB394
		internal anh(char[] A_0, int A_1, int A_2)
		{
			al5 al = new al5(A_0, A_1, A_2);
			al.a(true);
			al.d(true);
			if (al.b(false))
			{
				this.a = al.c(false);
			}
			else
			{
				this.a = al.f();
			}
			this.b = al.e();
		}

		// Token: 0x06003B61 RID: 15201 RVA: 0x001FC3FC File Offset: 0x001FB3FC
		internal bool a()
		{
			return this.b != null && this.b.b() != 0;
		}

		// Token: 0x06003B62 RID: 15202 RVA: 0x001FC42C File Offset: 0x001FB42C
		internal ahs b()
		{
			return this.b;
		}

		// Token: 0x06003B63 RID: 15203 RVA: 0x001FC444 File Offset: 0x001FB444
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x06003B64 RID: 15204 RVA: 0x001FC464 File Offset: 0x001FB464
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x06003B65 RID: 15205 RVA: 0x001FC484 File Offset: 0x001FB484
		internal override bool l5(LayoutWriter A_0)
		{
			return this.a.l5(A_0);
		}

		// Token: 0x06003B66 RID: 15206 RVA: 0x001FC4A4 File Offset: 0x001FB4A4
		internal override bool lx(LayoutWriter A_0, akk A_1)
		{
			return this.a.lx(A_0, A_1);
		}

		// Token: 0x06003B67 RID: 15207 RVA: 0x001FC4C3 File Offset: 0x001FB4C3
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x04001BF5 RID: 7157
		private new ahq a;

		// Token: 0x04001BF6 RID: 7158
		private new ahs b;
	}
}
