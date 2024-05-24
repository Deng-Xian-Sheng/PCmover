using System;
using System.IO;

namespace zz93
{
	// Token: 0x020003DE RID: 990
	internal class zx : zv
	{
		// Token: 0x0600297E RID: 10622 RVA: 0x001843D8 File Offset: 0x001833D8
		internal zx(z4 A_0, int A_1)
		{
			this.e = A_1;
			this.f = A_0;
			this.g = new zy();
		}

		// Token: 0x0600297F RID: 10623 RVA: 0x00184414 File Offset: 0x00183414
		internal new void a(int A_0)
		{
			z7 z = this.f.h().o();
			z.d(A_0);
			aaa aaa = new aaa(this.f, z);
			z.a(this.g, aaa);
			this.j = this.g.d();
			aaa.a(this.g);
			this.k = this.g.d();
			this.g.a(this.f.h().l().b());
			this.g.a(this.f.h().l().c());
			this.g.a(1);
			this.g.a(this.f.h().l().a());
			this.h = 50 + base.c(this.e);
			this.h += base.c(this.g.d());
			this.h += base.c(this.j);
			this.h += base.c(this.k);
			this.r = new byte[this.h];
			base.d(this.e);
			base.g();
			base.b(zx.a);
			base.d();
			base.f(this.g.d());
			base.c(83);
			base.d();
			base.f(this.j);
			base.c(73);
			base.d();
			base.f(this.k);
			base.f();
			base.a(zx.b);
			this.i = this.s;
			base.e();
			base.a(zx.c);
			base.j();
		}

		// Token: 0x06002980 RID: 10624 RVA: 0x00184618 File Offset: 0x00183618
		internal new void a(Stream A_0)
		{
			A_0.Write(this.r, 0, this.i);
			this.g.a(A_0);
			A_0.Write(this.r, this.i, this.s - this.i);
		}

		// Token: 0x06002981 RID: 10625 RVA: 0x00184668 File Offset: 0x00183668
		internal new int a()
		{
			return this.d;
		}

		// Token: 0x06002982 RID: 10626 RVA: 0x00184680 File Offset: 0x00183680
		internal new void b(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06002983 RID: 10627 RVA: 0x0018468C File Offset: 0x0018368C
		internal new int b()
		{
			return this.h + this.g.d();
		}

		// Token: 0x040012DB RID: 4827
		private new static byte[] a = new byte[]
		{
			76,
			101,
			110,
			103,
			116,
			104
		};

		// Token: 0x040012DC RID: 4828
		private new static byte[] b = new byte[]
		{
			115,
			116,
			114,
			101,
			97,
			109,
			10
		};

		// Token: 0x040012DD RID: 4829
		private new static byte[] c = new byte[]
		{
			101,
			110,
			100,
			115,
			116,
			114,
			101,
			97,
			109
		};

		// Token: 0x040012DE RID: 4830
		private new int d = 0;

		// Token: 0x040012DF RID: 4831
		private new int e;

		// Token: 0x040012E0 RID: 4832
		private new z4 f;

		// Token: 0x040012E1 RID: 4833
		private new zy g;

		// Token: 0x040012E2 RID: 4834
		private new int h;

		// Token: 0x040012E3 RID: 4835
		private new int i;

		// Token: 0x040012E4 RID: 4836
		private new int j = 0;

		// Token: 0x040012E5 RID: 4837
		private new int k = 0;
	}
}
