using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x02000287 RID: 647
	internal class q0
	{
		// Token: 0x06001D0F RID: 7439 RVA: 0x0012A948 File Offset: 0x00129948
		internal q0(Table2 A_0, PageWriter A_1)
		{
			this.a = A_0.X;
			this.b = A_0.Y;
			this.d = A_1;
			this.c = A_0;
		}

		// Token: 0x06001D10 RID: 7440 RVA: 0x0012A97C File Offset: 0x0012997C
		internal float a()
		{
			return this.a;
		}

		// Token: 0x06001D11 RID: 7441 RVA: 0x0012A994 File Offset: 0x00129994
		internal void a(float A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06001D12 RID: 7442 RVA: 0x0012A9A0 File Offset: 0x001299A0
		internal float b()
		{
			return this.b;
		}

		// Token: 0x06001D13 RID: 7443 RVA: 0x0012A9B8 File Offset: 0x001299B8
		internal void b(float A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001D14 RID: 7444 RVA: 0x0012A9C4 File Offset: 0x001299C4
		internal PageWriter c()
		{
			return this.d;
		}

		// Token: 0x06001D15 RID: 7445 RVA: 0x0012A9DC File Offset: 0x001299DC
		internal Table2 d()
		{
			return this.c;
		}

		// Token: 0x04000D19 RID: 3353
		private float a;

		// Token: 0x04000D1A RID: 3354
		private float b;

		// Token: 0x04000D1B RID: 3355
		private Table2 c;

		// Token: 0x04000D1C RID: 3356
		private PageWriter d;
	}
}
