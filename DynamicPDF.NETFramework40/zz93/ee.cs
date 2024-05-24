using System;

namespace zz93
{
	// Token: 0x020000BE RID: 190
	internal class ee : dy
	{
		// Token: 0x06000904 RID: 2308 RVA: 0x0007A7D8 File Offset: 0x000797D8
		internal ee(eg A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new ef(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x0007A828 File Offset: 0x00079828
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x0007A840 File Offset: 0x00079840
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x0007A858 File Offset: 0x00079858
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x0007A870 File Offset: 0x00079870
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x0007A87C File Offset: 0x0007987C
		internal override kz cm(ij A_0, kz A_1)
		{
			lb lb = new lb();
			A_0.c(this.ch());
			A_0.a(lb);
			n5 n = (n5)lb.db();
			lb.c5().c().i(n.j());
			A_0.b(lb);
			bool flag = true;
			bool flag2 = false;
			g2 valueOrDefault = lb.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					lb = null;
					flag = false;
					A_0.a(false);
					break;
				case g2.c:
					flag2 = true;
					break;
				}
			}
			if (flag)
			{
				lb.j(A_1);
				i3.a(lb);
				i3.a(lb);
				i3.a(lb, A_0);
				n5 a_ = (n5)lb.db();
				if (!flag2)
				{
					lb.c5().e().a(new int?(lb.dg()));
				}
				m4.a(a_, lb.c5(), flag2);
				if (lb.c5().ay().e() != null)
				{
					lb.b(mg.a(A_0, lb.c5().ay().e(), A_0.e()));
				}
				base.f(lb, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return lb;
		}

		// Token: 0x040004AF RID: 1199
		private new eg a = null;

		// Token: 0x040004B0 RID: 1200
		private ef b = null;

		// Token: 0x040004B1 RID: 1201
		private bool c = true;
	}
}
