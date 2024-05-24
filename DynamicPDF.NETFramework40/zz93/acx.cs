using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x02000455 RID: 1109
	internal class acx
	{
		// Token: 0x06002DC5 RID: 11717 RVA: 0x0019F860 File Offset: 0x0019E860
		public acx(Table A_0, PageWriter A_1)
		{
			this.a = A_0.X;
			this.b = A_0.Y;
			this.d = A_1;
			this.c = A_0;
		}

		// Token: 0x06002DC6 RID: 11718 RVA: 0x0019F894 File Offset: 0x0019E894
		internal float a()
		{
			return this.a;
		}

		// Token: 0x06002DC7 RID: 11719 RVA: 0x0019F8AC File Offset: 0x0019E8AC
		internal void a(float A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002DC8 RID: 11720 RVA: 0x0019F8B8 File Offset: 0x0019E8B8
		internal float b()
		{
			return this.b;
		}

		// Token: 0x06002DC9 RID: 11721 RVA: 0x0019F8D0 File Offset: 0x0019E8D0
		internal void b(float A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06002DCA RID: 11722 RVA: 0x0019F8DC File Offset: 0x0019E8DC
		internal PageWriter c()
		{
			return this.d;
		}

		// Token: 0x06002DCB RID: 11723 RVA: 0x0019F8F4 File Offset: 0x0019E8F4
		internal Table d()
		{
			return this.c;
		}

		// Token: 0x040015C3 RID: 5571
		private float a;

		// Token: 0x040015C4 RID: 5572
		private float b;

		// Token: 0x040015C5 RID: 5573
		private Table c;

		// Token: 0x040015C6 RID: 5574
		private PageWriter d;
	}
}
