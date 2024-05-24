using System;
using System.IO;

namespace zz93
{
	// Token: 0x020003E6 RID: 998
	internal class z5 : zv
	{
		// Token: 0x060029D8 RID: 10712 RVA: 0x0018655C File Offset: 0x0018555C
		internal z5(z4 A_0)
		{
			this.e = A_0;
			this.d = A_0.m() + 1;
			int num = base.c(this.d) * 2;
			num += this.d * 20;
			num += base.c(A_0.g().a());
			this.c = num + 44 + 73;
			this.b = base.c(A_0.m() + 1) + 7;
		}

		// Token: 0x060029D9 RID: 10713 RVA: 0x001865E0 File Offset: 0x001855E0
		internal new int a()
		{
			return this.a;
		}

		// Token: 0x060029DA RID: 10714 RVA: 0x001865F8 File Offset: 0x001855F8
		internal new void a(int A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060029DB RID: 10715 RVA: 0x00186604 File Offset: 0x00185604
		internal new int b()
		{
			return this.c;
		}

		// Token: 0x060029DC RID: 10716 RVA: 0x0018661C File Offset: 0x0018561C
		internal new int c()
		{
			return this.a + this.b;
		}

		// Token: 0x060029DD RID: 10717 RVA: 0x0018663C File Offset: 0x0018563C
		internal new void a(Stream A_0)
		{
			this.r = new byte[this.c];
			base.a(zv.e);
			base.f(this.d);
			base.a(zv.f);
			for (int i = 0; i < this.e.m(); i++)
			{
				base.e(this.e.a(i).c());
			}
			base.a(zv.i);
			base.g();
			base.b(zv.j);
			base.d();
			base.f(this.d);
			base.b(zv.m);
			base.i();
			base.c(this.e.h().n());
			base.c(this.e.h().n());
			base.h();
			base.f();
			base.a(zv.p);
			base.f(this.e.g().a());
			base.a(zv.h);
			A_0.Write(this.r, 0, this.s);
		}

		// Token: 0x0400131F RID: 4895
		private new int a = 0;

		// Token: 0x04001320 RID: 4896
		private new int b;

		// Token: 0x04001321 RID: 4897
		private new int c;

		// Token: 0x04001322 RID: 4898
		private new int d;

		// Token: 0x04001323 RID: 4899
		private new z4 e;
	}
}
