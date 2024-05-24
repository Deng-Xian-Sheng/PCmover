using System;

namespace zz93
{
	// Token: 0x020000CC RID: 204
	internal class es : er
	{
		// Token: 0x06000974 RID: 2420 RVA: 0x0007D980 File Offset: 0x0007C980
		internal es(eu A_0, kg A_1, d3 A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new et(A_1, A_2.k(), A_3);
			this.b.cq();
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x0007D9CC File Offset: 0x0007C9CC
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x0007D9E4 File Offset: 0x0007C9E4
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x0007D9FC File Offset: 0x0007C9FC
		internal override bool ci()
		{
			return true;
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x0007DA10 File Offset: 0x0007CA10
		internal override fa cr()
		{
			return fa.b;
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x0007DA24 File Offset: 0x0007CA24
		private void a(lo A_0, ij A_1, bool A_2)
		{
			if (((n5)A_0.db()).v())
			{
				((n5)A_0.db()).a(gn.c);
				((n5)A_0.db()).b(false);
			}
			if (A_0.dv().k() == io.e)
			{
				switch (this.a.a())
				{
				case ea.b:
				case ea.c:
				case ea.d:
				case ea.e:
					A_0.dv().a(io.a);
					break;
				case ea.f:
					A_0.dv().a(io.b);
					break;
				}
			}
			i3.a(A_0);
			i3.a(A_0, A_1);
			n5 a_ = (n5)A_0.db();
			m4.a(a_, A_0.c5(), A_2);
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x0007DAF8 File Offset: 0x0007CAF8
		internal override kz cm(ij A_0, kz A_1)
		{
			lo lo = new lo();
			A_0.c(this.ch());
			A_0.a(lo);
			n5 n = (n5)lo.db();
			lo.c5().c().i(n.j());
			A_0.b(lo);
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = lo.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					lo = null;
					flag = false;
					A_0.a(false);
					break;
				case g2.c:
					a_ = true;
					break;
				}
			}
			if (flag)
			{
				lo.j(A_1);
				A_0.c(lo);
				this.a(lo, A_0, a_);
				lo.aa(A_1.ch());
				if (lo.ch())
				{
					lo.ab(A_1.ci());
					lo.az(A_1.cl());
					lo.ay(A_1.ck());
				}
				base.g(lo, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return lo;
		}

		// Token: 0x040004CE RID: 1230
		private new eu a = null;

		// Token: 0x040004CF RID: 1231
		private et b = null;
	}
}
