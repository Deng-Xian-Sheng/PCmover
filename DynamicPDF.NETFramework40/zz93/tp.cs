using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002F2 RID: 754
	internal class tp : to
	{
		// Token: 0x06002185 RID: 8581 RVA: 0x00145F34 File Offset: 0x00144F34
		internal tp(w5 A_0)
		{
			A_0.o();
			int num = A_0.e();
			A_0.r();
			this.a = new string(A_0.d(), num, A_0.e() - num);
			A_0.o();
			A_0.q();
		}

		// Token: 0x06002186 RID: 8582 RVA: 0x00145F88 File Offset: 0x00144F88
		internal override bool eq(LayoutWriter A_0)
		{
			return false;
		}

		// Token: 0x06002187 RID: 8583 RVA: 0x00145F9C File Offset: 0x00144F9C
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return false;
		}

		// Token: 0x06002188 RID: 8584 RVA: 0x00145FB0 File Offset: 0x00144FB0
		internal override string eo(LayoutWriter A_0)
		{
			return this.a;
		}

		// Token: 0x06002189 RID: 8585 RVA: 0x00145FC8 File Offset: 0x00144FC8
		internal override string ep(LayoutWriter A_0, vi A_1)
		{
			return this.a;
		}

		// Token: 0x0600218A RID: 8586 RVA: 0x00145FE0 File Offset: 0x00144FE0
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
		}

		// Token: 0x04000EA8 RID: 3752
		private new string a;
	}
}
