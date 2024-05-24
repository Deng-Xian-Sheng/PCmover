using System;
using System.IO;

namespace zz93
{
	// Token: 0x020003DD RID: 989
	internal class zw : zv
	{
		// Token: 0x06002979 RID: 10617 RVA: 0x00184030 File Offset: 0x00183030
		internal zw(z4 A_0)
		{
			this.i = A_0;
			this.c = A_0.h().k();
			this.d = A_0.h().l();
			this.e = A_0.h().m();
			this.g = A_0.m() + 1;
			this.h = A_0.n() - this.g + 3;
			int num = base.c(this.g);
			num += base.c(this.h);
			num += this.h * 20;
			num += base.c(A_0.n() + 3);
			this.f = base.c(A_0.h().i()) + 1;
			num += this.f;
			num += this.c.e() + 4;
			num += this.d.e() + 4;
			if (this.e != null)
			{
				num += this.e.e() + 13;
			}
			this.b = num + 136;
		}

		// Token: 0x0600297A RID: 10618 RVA: 0x00184150 File Offset: 0x00183150
		internal new void a(Stream A_0)
		{
			this.r = new byte[this.b];
			base.a(zv.d);
			base.f(this.g);
			base.d();
			base.f(this.h);
			base.e();
			base.e(this.i.d().a());
			for (int i = this.i.m(); i < this.i.n(); i++)
			{
				base.e(this.i.a(i).c());
			}
			base.e(this.i.e().a());
			base.a(zv.i);
			base.g();
			base.b(zv.j);
			base.d();
			base.f(this.i.n() + 3);
			base.b(zv.o);
			base.d();
			base.f(this.i.f().a());
			base.b(zv.k);
			base.d();
			base.a(this.c);
			base.b(zv.n);
			base.d();
			base.a(this.d);
			if (this.e != null)
			{
				base.b(zv.l);
				base.d();
				base.a(this.e);
			}
			base.b(zv.m);
			base.i();
			base.c(this.i.h().n());
			base.c(this.i.h().n());
			base.h();
			base.f();
			base.a(zv.p);
			this.r[this.s++] = 48;
			base.a(zv.h);
			while (this.s < this.b - 1)
			{
				base.d();
			}
			base.e();
			A_0.Write(this.r, 0, this.s);
		}

		// Token: 0x0600297B RID: 10619 RVA: 0x0018439C File Offset: 0x0018339C
		internal new int a()
		{
			return this.a;
		}

		// Token: 0x0600297C RID: 10620 RVA: 0x001843B4 File Offset: 0x001833B4
		internal new void a(int A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600297D RID: 10621 RVA: 0x001843C0 File Offset: 0x001833C0
		internal new int b()
		{
			return this.b;
		}

		// Token: 0x040012D2 RID: 4818
		private new int a = 0;

		// Token: 0x040012D3 RID: 4819
		private new int b;

		// Token: 0x040012D4 RID: 4820
		private new zz c;

		// Token: 0x040012D5 RID: 4821
		private new zz d;

		// Token: 0x040012D6 RID: 4822
		private new zz e;

		// Token: 0x040012D7 RID: 4823
		private new int f;

		// Token: 0x040012D8 RID: 4824
		private new int g;

		// Token: 0x040012D9 RID: 4825
		private new int h;

		// Token: 0x040012DA RID: 4826
		private new z4 i;
	}
}
