using System;

namespace zz93
{
	// Token: 0x020000D3 RID: 211
	internal class ez : dy
	{
		// Token: 0x06000994 RID: 2452 RVA: 0x0007E5E0 File Offset: 0x0007D5E0
		internal ez(e0 A_0)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x0007E630 File Offset: 0x0007D630
		internal ez(e0 A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x0007E688 File Offset: 0x0007D688
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x0007E6A0 File Offset: 0x0007D6A0
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x0007E6B8 File Offset: 0x0007D6B8
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x0007E6D0 File Offset: 0x0007D6D0
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x0007E6DC File Offset: 0x0007D6DC
		internal override bool cp()
		{
			return true;
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x0007E6F0 File Offset: 0x0007D6F0
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x0007E708 File Offset: 0x0007D708
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x0007E714 File Offset: 0x0007D714
		internal override kz cm(ij A_0, kz A_1)
		{
			lq lq = new lq();
			A_0.c(this.ch());
			A_0.a(lq);
			n5 n = (n5)lq.db();
			lq.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(lq);
			}
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = lq.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					lq = null;
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
				lq.j(A_1);
				hd a_2 = i3.b(lq);
				ig a_3 = new ig(new fc[]
				{
					new fc(6968946, a_2)
				});
				A_0.a(this.ch().cn(), a_3);
				n.a().a(f4.b);
				i3.a(lq);
				i3.a(lq, A_0);
				m4.a(n, lq.c5(), a_);
				if (lq.c5().ay().e() != null)
				{
					lq.b(mg.a(A_0, lq.c5().ay().e(), A_0.e()));
				}
				base.e(lq, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return lq;
		}

		// Token: 0x040004D7 RID: 1239
		private new e0 a = null;

		// Token: 0x040004D8 RID: 1240
		private kl b = null;

		// Token: 0x040004D9 RID: 1241
		private bool c = false;

		// Token: 0x040004DA RID: 1242
		private new bool d = true;
	}
}
