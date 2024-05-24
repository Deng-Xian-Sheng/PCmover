using System;

namespace zz93
{
	// Token: 0x020000AF RID: 175
	internal class dz : dy
	{
		// Token: 0x0600084E RID: 2126 RVA: 0x0007584C File Offset: 0x0007484C
		internal dz(d1 A_0) : base(null)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x0007589C File Offset: 0x0007489C
		internal dz(d1 A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x000758F4 File Offset: 0x000748F4
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x0007590C File Offset: 0x0007490C
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x00075924 File Offset: 0x00074924
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x0007593C File Offset: 0x0007493C
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x00075948 File Offset: 0x00074948
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x00075960 File Offset: 0x00074960
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x0007596C File Offset: 0x0007496C
		internal override kz cm(ij A_0, kz A_1)
		{
			k1 k = new k1();
			A_0.c(this.ch());
			A_0.a(k);
			n5 n = (n5)k.db();
			k.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(k);
			}
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
				i3.a(k);
				i3.a(k, A_0);
				m4.a(n, k.c5(), a_);
				if (k.c5().ay().e() != null)
				{
					k.b(mg.a(A_0, k.c5().ay().e(), A_0.e()));
				}
				base.e(k, A_0);
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

		// Token: 0x0400047B RID: 1147
		private new d1 a = null;

		// Token: 0x0400047C RID: 1148
		private kl b = null;

		// Token: 0x0400047D RID: 1149
		private bool c = false;

		// Token: 0x0400047E RID: 1150
		private new bool d = true;
	}
}
