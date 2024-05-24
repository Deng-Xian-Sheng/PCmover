using System;
using System.IO;

namespace zz93
{
	// Token: 0x020003E4 RID: 996
	internal class z3 : zv
	{
		// Token: 0x060029C0 RID: 10688 RVA: 0x00185C9C File Offset: 0x00184C9C
		internal z3(z4 A_0, int A_1)
		{
			this.f = A_0;
			this.c = A_0.h().o().b().b();
			this.a = A_1;
			this.e = A_0.h().Document.Pages.Count;
			this.d = base.c(A_0.h().i()) + 1;
			int num = base.c(A_1);
			num += this.d * 5;
			num += this.c.e();
			num += base.c(this.e);
			this.b = num + 53;
		}

		// Token: 0x060029C1 RID: 10689 RVA: 0x00185D4C File Offset: 0x00184D4C
		internal new void a(Stream A_0)
		{
			this.r = new byte[this.b];
			base.d(this.a);
			base.d();
			base.g();
			base.b(zv.q);
			base.d();
			this.r[this.s++] = 49;
			base.c(76);
			base.d();
			base.f(this.f.o());
			base.c(79);
			base.d();
			this.c.a(this.r, this.s);
			this.s += this.c.e();
			base.c(69);
			base.d();
			base.f(this.f.p());
			base.c(78);
			base.d();
			base.f(this.e);
			base.c(84);
			base.d();
			base.f(this.f.f().c());
			base.c(72);
			base.d();
			base.i();
			base.d();
			base.f(this.f.e().a());
			base.d();
			base.f(this.f.e().b());
			base.h();
			base.f();
			base.j();
			while (this.s < this.b - 1)
			{
				base.d();
			}
			base.e();
			A_0.Write(this.r, 0, this.s);
		}

		// Token: 0x060029C2 RID: 10690 RVA: 0x00185F1C File Offset: 0x00184F1C
		internal new int a()
		{
			return 15;
		}

		// Token: 0x060029C3 RID: 10691 RVA: 0x00185F30 File Offset: 0x00184F30
		internal new int b()
		{
			return this.b;
		}

		// Token: 0x0400130C RID: 4876
		private new int a;

		// Token: 0x0400130D RID: 4877
		private new int b;

		// Token: 0x0400130E RID: 4878
		private new zz c;

		// Token: 0x0400130F RID: 4879
		private new int d;

		// Token: 0x04001310 RID: 4880
		private new int e;

		// Token: 0x04001311 RID: 4881
		private new z4 f;
	}
}
