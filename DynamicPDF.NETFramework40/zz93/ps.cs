using System;

namespace zz93
{
	// Token: 0x0200025A RID: 602
	internal class ps : dy
	{
		// Token: 0x06001B60 RID: 7008 RVA: 0x0011A738 File Offset: 0x00119738
		internal ps(pt A_0) : base(null)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x06001B61 RID: 7009 RVA: 0x0011A788 File Offset: 0x00119788
		internal ps(pt A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001B62 RID: 7010 RVA: 0x0011A7E0 File Offset: 0x001197E0
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001B63 RID: 7011 RVA: 0x0011A7F8 File Offset: 0x001197F8
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001B64 RID: 7012 RVA: 0x0011A810 File Offset: 0x00119810
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001B65 RID: 7013 RVA: 0x0011A828 File Offset: 0x00119828
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001B66 RID: 7014 RVA: 0x0011A834 File Offset: 0x00119834
		internal override bool cp()
		{
			return true;
		}

		// Token: 0x06001B67 RID: 7015 RVA: 0x0011A848 File Offset: 0x00119848
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x06001B68 RID: 7016 RVA: 0x0011A860 File Offset: 0x00119860
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001B69 RID: 7017 RVA: 0x0011A86C File Offset: 0x0011986C
		internal override kz cm(ij A_0, kz A_1)
		{
			nq nq = new nq();
			A_0.c(this.ch());
			A_0.a(nq);
			n5 n = (n5)nq.db();
			nq.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(nq);
			}
			bool flag = true;
			bool a_ = false;
			lk lk = nq.c5();
			g2 valueOrDefault = lk.t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					nq = null;
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
				nq.j(A_1);
				hd a_2 = i3.b(nq);
				ig a_3 = new ig(new fc[]
				{
					new fc(6968946, a_2)
				});
				A_0.a(this.ch().cn(), a_3);
				i3.a(nq);
				i3.a(nq, A_0);
				m4.a(n, lk, a_);
				if (lk.ay().e() != null)
				{
					nq.b(mg.a(A_0, lk.ay().e(), A_0.e()));
				}
				if (n.h() == gs.a)
				{
					n.a(gs.c);
				}
				base.e(nq, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return nq;
		}

		// Token: 0x04000C5B RID: 3163
		private new pt a = null;

		// Token: 0x04000C5C RID: 3164
		private kl b = null;

		// Token: 0x04000C5D RID: 3165
		private bool c = false;

		// Token: 0x04000C5E RID: 3166
		private new bool d = true;
	}
}
