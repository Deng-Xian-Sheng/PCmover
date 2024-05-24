using System;

namespace zz93
{
	// Token: 0x0200024C RID: 588
	internal class pe : dy
	{
		// Token: 0x06001AE1 RID: 6881 RVA: 0x00117114 File Offset: 0x00116114
		internal pe(pf A_0)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x06001AE2 RID: 6882 RVA: 0x00117164 File Offset: 0x00116164
		internal pe(pf A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001AE3 RID: 6883 RVA: 0x001171BC File Offset: 0x001161BC
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001AE4 RID: 6884 RVA: 0x001171D4 File Offset: 0x001161D4
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001AE5 RID: 6885 RVA: 0x001171EC File Offset: 0x001161EC
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001AE6 RID: 6886 RVA: 0x00117204 File Offset: 0x00116204
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001AE7 RID: 6887 RVA: 0x00117210 File Offset: 0x00116210
		internal override bool cp()
		{
			return true;
		}

		// Token: 0x06001AE8 RID: 6888 RVA: 0x00117224 File Offset: 0x00116224
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x06001AE9 RID: 6889 RVA: 0x0011723C File Offset: 0x0011623C
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001AEA RID: 6890 RVA: 0x00117248 File Offset: 0x00116248
		internal override kz cm(ij A_0, kz A_1)
		{
			nf nf = new nf();
			A_0.c(this.ch());
			A_0.a(nf);
			n5 n = (n5)nf.db();
			nf.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(nf);
			}
			bool flag = true;
			bool a_ = false;
			lk lk = nf.c5();
			g2 valueOrDefault = lk.t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					nf = null;
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
				nf.j(A_1);
				if (lk.ay().e() != null)
				{
					nf.b(mg.a(A_0, lk.ay().e(), A_0.e()));
				}
				hd a_2 = i3.b(nf);
				ig a_3 = new ig(new fc[]
				{
					new fc(6968946, a_2)
				});
				A_0.a(this.ch().cn(), a_3);
				n.a().a("monospace");
				i3.a(nf);
				i3.a(nf, A_0);
				m4.a(n, lk, a_);
				base.e(nf, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return nf;
		}

		// Token: 0x04000C36 RID: 3126
		private new pf a = null;

		// Token: 0x04000C37 RID: 3127
		private kl b = null;

		// Token: 0x04000C38 RID: 3128
		private bool c = false;

		// Token: 0x04000C39 RID: 3129
		private new bool d = true;
	}
}
