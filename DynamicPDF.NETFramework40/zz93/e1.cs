using System;

namespace zz93
{
	// Token: 0x020000D5 RID: 213
	internal class e1 : dy
	{
		// Token: 0x060009A1 RID: 2465 RVA: 0x0007EA04 File Offset: 0x0007DA04
		internal e1(e2 A_0)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x0007EA54 File Offset: 0x0007DA54
		internal e1(e2 A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x0007EAAC File Offset: 0x0007DAAC
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x0007EAC4 File Offset: 0x0007DAC4
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0007EADC File Offset: 0x0007DADC
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x0007EAF4 File Offset: 0x0007DAF4
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x0007EB00 File Offset: 0x0007DB00
		internal override bool cp()
		{
			return true;
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x0007EB14 File Offset: 0x0007DB14
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x0007EB2C File Offset: 0x0007DB2C
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x0007EB38 File Offset: 0x0007DB38
		internal override kz cm(ij A_0, kz A_1)
		{
			ls ls = new ls();
			A_0.c(this.ch());
			A_0.a(ls);
			n5 n = (n5)ls.db();
			ls.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(ls);
			}
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = ls.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					ls = null;
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
				A_0.a(true);
				ls.j(A_1);
				hd a_2 = i3.b(ls);
				ig a_3 = new ig(new fc[]
				{
					new fc(6968946, a_2)
				});
				A_0.a(this.ch().cn(), a_3);
				n.a().a("monospace");
				i3.a(ls);
				i3.a(ls, A_0);
				m4.a(n, ls.c5(), a_);
				if (ls.c5().ay().e() != null)
				{
					ls.b(mg.a(A_0, ls.c5().ay().e(), A_0.e()));
				}
				base.e(ls, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return ls;
		}

		// Token: 0x040004DB RID: 1243
		private new e2 a = null;

		// Token: 0x040004DC RID: 1244
		private kl b = null;

		// Token: 0x040004DD RID: 1245
		private bool c = false;

		// Token: 0x040004DE RID: 1246
		private new bool d = true;
	}
}
