using System;

namespace zz93
{
	// Token: 0x020000B7 RID: 183
	internal class d7 : dy
	{
		// Token: 0x060008E4 RID: 2276 RVA: 0x00079CD8 File Offset: 0x00078CD8
		internal d7(d9 A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new d8(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x00079D28 File Offset: 0x00078D28
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00079D40 File Offset: 0x00078D40
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x00079D58 File Offset: 0x00078D58
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x00079D70 File Offset: 0x00078D70
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x00079D7C File Offset: 0x00078D7C
		internal override kz cm(ij A_0, kz A_1)
		{
			k3 k = new k3();
			A_0.c(this.ch());
			A_0.a(k);
			n5 n = (n5)k.db();
			k.c5().c().i(n.j());
			A_0.b(k);
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = k.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					k = null;
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
				k.j(A_1);
				hd a_2 = i3.b(k);
				ig a_3 = new ig(new fc[]
				{
					new fc(6968946, a_2)
				});
				A_0.a(this.ch().cn(), a_3);
				i3.a(k);
				i3.a(k, A_0);
				m4.a(n, k.c5(), a_);
				if (k.c5().ay().e() != null)
				{
					k.b(mg.a(A_0, k.c5().ay().e(), A_0.e()));
				}
				base.f(k, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return k;
		}

		// Token: 0x0400049D RID: 1181
		private new d9 a = null;

		// Token: 0x0400049E RID: 1182
		private d8 b = null;

		// Token: 0x0400049F RID: 1183
		private bool c = true;
	}
}
