using System;

namespace zz93
{
	// Token: 0x0200025C RID: 604
	internal class pu : dy
	{
		// Token: 0x06001B6D RID: 7021 RVA: 0x0011AB64 File Offset: 0x00119B64
		internal pu(pv A_0) : base(null)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x06001B6E RID: 7022 RVA: 0x0011ABB4 File Offset: 0x00119BB4
		internal pu(pv A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001B6F RID: 7023 RVA: 0x0011AC0C File Offset: 0x00119C0C
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001B70 RID: 7024 RVA: 0x0011AC24 File Offset: 0x00119C24
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001B71 RID: 7025 RVA: 0x0011AC3C File Offset: 0x00119C3C
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001B72 RID: 7026 RVA: 0x0011AC54 File Offset: 0x00119C54
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001B73 RID: 7027 RVA: 0x0011AC60 File Offset: 0x00119C60
		internal override bool cp()
		{
			return true;
		}

		// Token: 0x06001B74 RID: 7028 RVA: 0x0011AC74 File Offset: 0x00119C74
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x06001B75 RID: 7029 RVA: 0x0011AC8C File Offset: 0x00119C8C
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001B76 RID: 7030 RVA: 0x0011AC98 File Offset: 0x00119C98
		internal override kz cm(ij A_0, kz A_1)
		{
			nr nr = new nr();
			A_0.c(this.ch());
			A_0.a(nr);
			n5 n = (n5)nr.db();
			nr.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(nr);
			}
			bool flag = true;
			bool a_ = false;
			lk lk = nr.c5();
			g2 valueOrDefault = lk.t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					nr = null;
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
				nr.j(A_1);
				if (lk.ay().e() != null)
				{
					nr.b(mg.a(A_0, lk.ay().e(), A_0.e()));
				}
				A_0.a(true);
				hd a_2 = i3.b(nr);
				ig a_3 = new ig(new fc[]
				{
					new fc(6968946, a_2)
				});
				A_0.a(this.ch().cn(), a_3);
				i3.a(nr);
				i3.a(nr, A_0);
				m4.a(n, nr.c5(), a_);
				if (n.h() == gs.a)
				{
					n.a(gs.d);
				}
				base.e(nr, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return nr;
		}

		// Token: 0x04000C5F RID: 3167
		private new pv a = null;

		// Token: 0x04000C60 RID: 3168
		private kl b = null;

		// Token: 0x04000C61 RID: 3169
		private bool c = false;

		// Token: 0x04000C62 RID: 3170
		private new bool d = true;
	}
}
