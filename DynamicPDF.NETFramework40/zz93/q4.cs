using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200028B RID: 651
	internal abstract class q4
	{
		// Token: 0x06001D3B RID: 7483 RVA: 0x0012B534 File Offset: 0x0012A534
		internal q4(rv A_0, vi A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x06001D3C RID: 7484
		internal abstract void d7(LayoutWriter A_0, bool A_1);

		// Token: 0x06001D3D RID: 7485 RVA: 0x0012B550 File Offset: 0x0012A550
		internal q4 a()
		{
			return this.c;
		}

		// Token: 0x06001D3E RID: 7486 RVA: 0x0012B568 File Offset: 0x0012A568
		internal void a(q4 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001D3F RID: 7487 RVA: 0x0012B574 File Offset: 0x0012A574
		internal rv b()
		{
			return this.a;
		}

		// Token: 0x06001D40 RID: 7488 RVA: 0x0012B58C File Offset: 0x0012A58C
		internal vi c()
		{
			return this.b;
		}

		// Token: 0x04000D2D RID: 3373
		private rv a;

		// Token: 0x04000D2E RID: 3374
		private vi b;

		// Token: 0x04000D2F RID: 3375
		private q4 c;
	}
}
