using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000522 RID: 1314
	internal class aii : aif
	{
		// Token: 0x0600351C RID: 13596 RVA: 0x001D3F76 File Offset: 0x001D2F76
		internal aii(rv A_0, akk A_1, ahm A_2) : base(A_0, A_1)
		{
			this.a = A_2;
		}

		// Token: 0x0600351D RID: 13597 RVA: 0x001D3F8C File Offset: 0x001D2F8C
		private object a(LayoutWriter A_0)
		{
			return this.a.a().l2(A_0, base.c());
		}

		// Token: 0x0600351E RID: 13598 RVA: 0x001D3FB8 File Offset: 0x001D2FB8
		internal override void mm(LayoutWriter A_0, bool A_1)
		{
			object obj = this.a(A_0);
			base.b().a(obj.ToString().ToCharArray(), A_1);
		}

		// Token: 0x0400199B RID: 6555
		private ahm a;
	}
}
