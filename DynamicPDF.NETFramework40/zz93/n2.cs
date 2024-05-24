using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200021C RID: 540
	internal class n2 : k0
	{
		// Token: 0x0600191B RID: 6427 RVA: 0x00108438 File Offset: 0x00107438
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x0600191C RID: 6428 RVA: 0x00108450 File Offset: 0x00107450
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x0600191D RID: 6429 RVA: 0x00108460 File Offset: 0x00107460
		internal override int dg()
		{
			return 23684646;
		}

		// Token: 0x0600191E RID: 6430 RVA: 0x00108478 File Offset: 0x00107478
		internal override bool de()
		{
			return this.c;
		}

		// Token: 0x0600191F RID: 6431 RVA: 0x00108490 File Offset: 0x00107490
		internal override void df(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001920 RID: 6432 RVA: 0x0010849C File Offset: 0x0010749C
		internal l2 a()
		{
			return this.b;
		}

		// Token: 0x06001921 RID: 6433 RVA: 0x001084B4 File Offset: 0x001074B4
		internal void a(l2 A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001922 RID: 6434 RVA: 0x001084C0 File Offset: 0x001074C0
		internal override k0 dd()
		{
			n2 n = new n2();
			n.a(this.a());
			return n;
		}

		// Token: 0x06001923 RID: 6435 RVA: 0x001084E8 File Offset: 0x001074E8
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001924 RID: 6436 RVA: 0x00108507 File Offset: 0x00107507
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001925 RID: 6437 RVA: 0x00108514 File Offset: 0x00107514
		internal override kz dj(x5 A_0, x5 A_1)
		{
			base.ad(x5.f(x5.f(base.c5().v().Value, base.c5().e().a()), base.c5().f().a()));
			if (base.c5().d())
			{
				base.ad(x5.f(base.a8(), base.c5().c().f()));
			}
			base.ac(base.a8());
			base.y(base.a8());
			base.w(base.a8());
			kz result = base.f(A_0, A_1);
			base.y(base.a8());
			base.w(base.a8());
			return result;
		}

		// Token: 0x06001926 RID: 6438 RVA: 0x001085EC File Offset: 0x001075EC
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c5().c().e(base.r());
			base.c5().c().f(base.q());
			base.c5().c().g(base.s());
			base.c5().c().h(base.t());
			A_1 = x5.f(A_1, base.cc());
			if (this.c3())
			{
				A_1 = x5.f(A_1, base.an());
			}
			x5 x = x5.c();
			if (!base.s() && !this.@do())
			{
				x = x5.f(x, base.c5().e().a());
				A_2 = x5.f(A_2, base.c5().e().a());
			}
			if (!base.t())
			{
				x = x5.f(x, base.c5().e().c());
			}
			A_1 = x5.f(A_1, base.c5().e().d());
			if (base.c5().am() != null)
			{
				base.l(base.c5().am().Value);
			}
			mb mb = new mb(this, A_0);
			mb.i();
			mb.w();
			A_0.Write_q_();
			A_0.Write_cm(1f, 0f, 0f, 1f, A_0.Dimensions.aw(x5.b(A_1)), A_0.Dimensions.ax(x5.b(x5.e(x5.f(A_2, base.ar()), x))));
			A_0.Write_Do(mb);
			A_0.Write_Q();
			base.o(A_1);
			base.p(A_2);
		}

		// Token: 0x06001927 RID: 6439 RVA: 0x001087C8 File Offset: 0x001077C8
		internal override kz dm()
		{
			n2 n = new n2();
			n.j(this.dr());
			n.dc(this.db().du());
			n.a((lk)base.c5().du());
			n.df(this.c);
			n.a(this.b);
			if (base.n() != null)
			{
				n.c(base.n().p());
			}
			return n;
		}

		// Token: 0x04000B77 RID: 2935
		private new n5 a = new n5();

		// Token: 0x04000B78 RID: 2936
		private new l2 b = null;

		// Token: 0x04000B79 RID: 2937
		private new bool c = false;
	}
}
