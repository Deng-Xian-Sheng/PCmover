using System;

namespace zz93
{
	// Token: 0x020001A6 RID: 422
	internal class ku : dy
	{
		// Token: 0x06000EC6 RID: 3782 RVA: 0x000B0AA4 File Offset: 0x000AFAA4
		internal ku(kv A_0) : base(null)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x06000EC7 RID: 3783 RVA: 0x000B0AF4 File Offset: 0x000AFAF4
		internal ku(kv A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06000EC8 RID: 3784 RVA: 0x000B0B4C File Offset: 0x000AFB4C
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000EC9 RID: 3785 RVA: 0x000B0B64 File Offset: 0x000AFB64
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000ECA RID: 3786 RVA: 0x000B0B7C File Offset: 0x000AFB7C
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06000ECB RID: 3787 RVA: 0x000B0B94 File Offset: 0x000AFB94
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000ECC RID: 3788 RVA: 0x000B0BA0 File Offset: 0x000AFBA0
		internal override bool cp()
		{
			return true;
		}

		// Token: 0x06000ECD RID: 3789 RVA: 0x000B0BB4 File Offset: 0x000AFBB4
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x06000ECE RID: 3790 RVA: 0x000B0BCC File Offset: 0x000AFBCC
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06000ECF RID: 3791 RVA: 0x000B0BD8 File Offset: 0x000AFBD8
		internal override kz cm(ij A_0, kz A_1)
		{
			mo mo = new mo();
			A_0.c(this.ch());
			A_0.a(mo);
			n5 n = (n5)mo.db();
			mo.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(mo);
			}
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = mo.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					mo = null;
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
				mo.j(A_1);
				hd a_2 = i3.b(mo);
				ig a_3 = new ig(new fc[]
				{
					new fc(6968946, a_2)
				});
				A_0.a(this.ch().cn(), a_3);
				n.a().a("monospace");
				i3.a(mo);
				i3.a(mo, A_0);
				m4.a(n, mo.c5(), a_);
				if (mo.c5().ay().e() != null)
				{
					mo.b(mg.a(A_0, mo.c5().ay().e(), A_0.e()));
				}
				base.e(mo, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return mo;
		}

		// Token: 0x04000745 RID: 1861
		private new kv a = null;

		// Token: 0x04000746 RID: 1862
		private kl b = null;

		// Token: 0x04000747 RID: 1863
		private bool c = false;

		// Token: 0x04000748 RID: 1864
		private new bool d = true;
	}
}
