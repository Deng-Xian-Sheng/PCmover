using System;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.Data;

namespace zz93
{
	// Token: 0x02000528 RID: 1320
	internal class aio
	{
		// Token: 0x0600354B RID: 13643 RVA: 0x001D45CC File Offset: 0x001D35CC
		public aio(LayoutData A_0)
		{
			this.a = A_0;
			this.b = null;
			this.c = null;
		}

		// Token: 0x0600354C RID: 13644 RVA: 0x001D45EC File Offset: 0x001D35EC
		internal aio(ReportData A_0, aio A_1)
		{
			this.a = A_0;
			this.b = A_0;
			this.c = A_1;
		}

		// Token: 0x0600354D RID: 13645 RVA: 0x001D460C File Offset: 0x001D360C
		internal DataProvider a()
		{
			return this.a;
		}

		// Token: 0x0600354E RID: 13646 RVA: 0x001D4624 File Offset: 0x001D3624
		internal ReportData b()
		{
			return this.b;
		}

		// Token: 0x0600354F RID: 13647 RVA: 0x001D463C File Offset: 0x001D363C
		internal aio c()
		{
			return this.c;
		}

		// Token: 0x040019A0 RID: 6560
		private DataProvider a;

		// Token: 0x040019A1 RID: 6561
		private ReportData b;

		// Token: 0x040019A2 RID: 6562
		private aio c;
	}
}
