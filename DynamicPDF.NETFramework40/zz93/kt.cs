using System;

namespace zz93
{
	// Token: 0x020001A5 RID: 421
	internal class kt : dy
	{
		// Token: 0x06000EBC RID: 3772 RVA: 0x000B0774 File Offset: 0x000AF774
		internal kt(ks A_0) : base(null)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x06000EBD RID: 3773 RVA: 0x000B07C4 File Offset: 0x000AF7C4
		internal kt(ks A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06000EBE RID: 3774 RVA: 0x000B081C File Offset: 0x000AF81C
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000EBF RID: 3775 RVA: 0x000B0834 File Offset: 0x000AF834
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000EC0 RID: 3776 RVA: 0x000B084C File Offset: 0x000AF84C
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06000EC1 RID: 3777 RVA: 0x000B0864 File Offset: 0x000AF864
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000EC2 RID: 3778 RVA: 0x000B0870 File Offset: 0x000AF870
		internal override bool cp()
		{
			return true;
		}

		// Token: 0x06000EC3 RID: 3779 RVA: 0x000B0884 File Offset: 0x000AF884
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x06000EC4 RID: 3780 RVA: 0x000B089C File Offset: 0x000AF89C
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06000EC5 RID: 3781 RVA: 0x000B08A8 File Offset: 0x000AF8A8
		internal override kz cm(ij A_0, kz A_1)
		{
			mn mn = new mn();
			A_0.c(this.ch());
			A_0.a(mn);
			n5 n = (n5)mn.db();
			mn.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(mn);
			}
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = mn.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					mn = null;
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
				mn.j(A_1);
				hd a_2 = i3.b(mn);
				ig a_3 = new ig(new fc[]
				{
					new fc(6968946, a_2)
				});
				A_0.a(this.ch().cn(), a_3);
				i3.a(mn);
				i3.a(mn, A_0);
				m4.a(n, mn.c5(), a_);
				if (mn.c5().ay().e() != null)
				{
					mn.b(mg.a(A_0, mn.c5().ay().e(), A_0.e()));
				}
				if (!mn.c2() && !n.a().e())
				{
					n.a().a(f4.b);
				}
				base.e(mn, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return mn;
		}

		// Token: 0x04000741 RID: 1857
		private new ks a = null;

		// Token: 0x04000742 RID: 1858
		private kl b = null;

		// Token: 0x04000743 RID: 1859
		private bool c = false;

		// Token: 0x04000744 RID: 1860
		private new bool d = true;
	}
}
