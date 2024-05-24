using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200028C RID: 652
	internal class q5 : q4
	{
		// Token: 0x06001D41 RID: 7489 RVA: 0x0012B5A4 File Offset: 0x0012A5A4
		internal q5(rv A_0, vi A_1, sv A_2) : base(A_0, A_1)
		{
			this.a = A_2;
		}

		// Token: 0x06001D42 RID: 7490 RVA: 0x0012B5B8 File Offset: 0x0012A5B8
		private object a(LayoutWriter A_0)
		{
			return this.a.a().et(A_0, base.c());
		}

		// Token: 0x06001D43 RID: 7491 RVA: 0x0012B5E4 File Offset: 0x0012A5E4
		internal override void d7(LayoutWriter A_0, bool A_1)
		{
			object obj = this.a(A_0);
			base.b().a(obj.ToString().ToCharArray(), A_1);
		}

		// Token: 0x04000D30 RID: 3376
		private sv a;
	}
}
