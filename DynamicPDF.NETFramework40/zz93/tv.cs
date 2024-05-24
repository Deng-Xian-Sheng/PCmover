using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002F8 RID: 760
	internal class tv : q4
	{
		// Token: 0x060021BC RID: 8636 RVA: 0x00147447 File Offset: 0x00146447
		internal tv(rv A_0, vi A_1, tu A_2, wt A_3) : base(A_0, A_1)
		{
			this.a = A_2;
			this.b = A_3;
		}

		// Token: 0x060021BD RID: 8637 RVA: 0x00147463 File Offset: 0x00146463
		internal override void d7(LayoutWriter A_0, bool A_1)
		{
			A_0.a(A_1);
			base.b().a(this.a.a(A_0, base.c(), this.b), A_1);
			A_0.a(false);
		}

		// Token: 0x04000EB5 RID: 3765
		private tu a;

		// Token: 0x04000EB6 RID: 3766
		private wt b;
	}
}
