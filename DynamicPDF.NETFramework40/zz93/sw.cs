using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x020002D4 RID: 724
	internal class sw
	{
		// Token: 0x060020AA RID: 8362 RVA: 0x001410A8 File Offset: 0x001400A8
		internal sw(rm A_0, vp A_1)
		{
			this.a = A_1.e();
			this.b = A_1.d();
			this.c = A_1.c();
			this.d = new ReportElementList(A_0, A_1.b());
			A_0.b().DocumentLayout.a(this.a, this);
			this.e = A_1.f();
			this.f = A_1.g();
		}

		// Token: 0x060020AB RID: 8363 RVA: 0x00141134 File Offset: 0x00140134
		internal ReportElementList a()
		{
			return this.d;
		}

		// Token: 0x060020AC RID: 8364 RVA: 0x0014114C File Offset: 0x0014014C
		internal bool b()
		{
			return this.c;
		}

		// Token: 0x060020AD RID: 8365 RVA: 0x00141164 File Offset: 0x00140164
		internal w6 c()
		{
			return this.b;
		}

		// Token: 0x060020AE RID: 8366 RVA: 0x0014117C File Offset: 0x0014017C
		internal string d()
		{
			return this.a;
		}

		// Token: 0x060020AF RID: 8367 RVA: 0x00141194 File Offset: 0x00140194
		internal string e()
		{
			return this.e;
		}

		// Token: 0x060020B0 RID: 8368 RVA: 0x001411AC File Offset: 0x001401AC
		internal int f()
		{
			return this.f;
		}

		// Token: 0x04000E56 RID: 3670
		private string a;

		// Token: 0x04000E57 RID: 3671
		private w6 b;

		// Token: 0x04000E58 RID: 3672
		private bool c;

		// Token: 0x04000E59 RID: 3673
		private ReportElementList d;

		// Token: 0x04000E5A RID: 3674
		private string e = null;

		// Token: 0x04000E5B RID: 3675
		private int f = 1;
	}
}
