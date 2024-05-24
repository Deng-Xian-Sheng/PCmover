using System;

namespace zz93
{
	// Token: 0x0200026B RID: 619
	internal class p9 : dy
	{
		// Token: 0x06001BE6 RID: 7142 RVA: 0x0011FC28 File Offset: 0x0011EC28
		internal p9(qq A_0)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x06001BE7 RID: 7143 RVA: 0x0011FC78 File Offset: 0x0011EC78
		internal p9(qq A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001BE8 RID: 7144 RVA: 0x0011FCD0 File Offset: 0x0011ECD0
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001BE9 RID: 7145 RVA: 0x0011FCE8 File Offset: 0x0011ECE8
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001BEA RID: 7146 RVA: 0x0011FD00 File Offset: 0x0011ED00
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001BEB RID: 7147 RVA: 0x0011FD18 File Offset: 0x0011ED18
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001BEC RID: 7148 RVA: 0x0011FD24 File Offset: 0x0011ED24
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x06001BED RID: 7149 RVA: 0x0011FD3C File Offset: 0x0011ED3C
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001BEE RID: 7150 RVA: 0x0011FD48 File Offset: 0x0011ED48
		internal override kz cm(ij A_0, kz A_1)
		{
			n1 n = new n1();
			A_0.c(this.ch());
			A_0.a(n);
			n5 n2 = (n5)n.db();
			n.c5().c().i(n2.j());
			if (this.d)
			{
				A_0.b(n);
			}
			bool flag = true;
			bool a_ = false;
			lk lk = n.c5();
			g2 valueOrDefault = lk.t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					n = null;
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
				n.j(A_1);
				if (lk.ay().e() != null)
				{
					n.b(mg.a(A_0, lk.ay().e(), A_0.e()));
				}
				hd a_2 = i3.b(n);
				ig a_3 = new ig(new fc[]
				{
					new fc(6968946, a_2)
				});
				A_0.a(this.ch().cn(), a_3);
				n2.a().a("monospace");
				i3.a(n);
				i3.a(n, A_0);
				m4.a(n2, lk, a_);
				base.e(n, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return n;
		}

		// Token: 0x04000C98 RID: 3224
		private new qq a = null;

		// Token: 0x04000C99 RID: 3225
		private kl b = null;

		// Token: 0x04000C9A RID: 3226
		private bool c = false;

		// Token: 0x04000C9B RID: 3227
		private new bool d = true;
	}
}
