using System;

namespace zz93
{
	// Token: 0x020000C1 RID: 193
	internal class eh : dy
	{
		// Token: 0x0600090F RID: 2319 RVA: 0x0007ACD3 File Offset: 0x00079CD3
		internal eh() : base(null)
		{
			this.a = new ej();
			this.b = new ei();
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x0007AD0C File Offset: 0x00079D0C
		internal eh(ej A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new ei(A_2, A_1, A_3);
			this.b.a(this.a);
			this.b.cq();
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x0007AD6C File Offset: 0x00079D6C
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x0007AD84 File Offset: 0x00079D84
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x0007AD9C File Offset: 0x00079D9C
		internal override bool ci()
		{
			return true;
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x0007ADB0 File Offset: 0x00079DB0
		internal kh a()
		{
			return this.c;
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x0007ADC8 File Offset: 0x00079DC8
		internal void a(kh A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x0007ADD4 File Offset: 0x00079DD4
		private void a(ij A_0)
		{
			int num = 0;
			fe fe = null;
			iv iv = null;
			it it = null;
			if (this.a.b() != null)
			{
				iv = new iv();
				iv.a(new go(this.a.b()));
				num++;
			}
			if (this.a.d() != gn.e)
			{
				it = new it();
				it.a(new iu(this.a.d()));
				num++;
			}
			if (this.a.a() != null || this.a.c() != null)
			{
				fb<fs>[] a_ = new fb<fs>[]
				{
					new fb<fs>(510035525, new afu(this.a.a())),
					new fb<fs>(137106767, new afv(this.a.c())),
					new fb<fs>(19010090, new afx(gl.a)),
					new fb<fs>(808234079, new aft(fq.c)),
					new fb<fs>(440052479, new afw(fr.a, x5.c(), i2.d, x5.c(), i2.d))
				};
				fe = new fe();
				fe.a(a_);
				num++;
			}
			if (num > 0)
			{
				fc[] array = new fc[num];
				int num2 = 0;
				if (fe != null)
				{
					array[num2] = new fc(1617181893, fe);
					num2++;
				}
				if (iv != null)
				{
					array[num2] = new fc(510035525, iv);
					num2++;
				}
				if (it != null)
				{
					array[num2] = new fc(1982903832, it);
					num2++;
				}
				ig a_2 = new ig(array);
				A_0.a(this.ch().cn(), a_2);
				A_0.a(true);
			}
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x0007AFF8 File Offset: 0x00079FF8
		internal override kz cm(ij A_0, kz A_1)
		{
			lc lc = new lc();
			lc.m(1);
			lc.j(A_1);
			if (this.c != null)
			{
				A_0.c(this.c);
			}
			A_0.a(false);
			this.a(A_0);
			lc.a(A_0);
			A_0.c(this.ch());
			A_0.a(lc);
			n5 n = (n5)lc.db();
			lc.c5().c().i(n.j());
			A_0.b(lc);
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = lc.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					lc = null;
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
				i3.a(lc);
				i3.a(lc, A_0);
				m4.a(n, lc.c5(), a_);
				if (lc.c5().ay().e() != null)
				{
					lc.b(mg.a(A_0, lc.c5().ay().e(), A_0.e()));
				}
				else if (this.a.c() != null)
				{
					lc.b(mg.a(A_0, this.a.c(), A_0.e()));
				}
				if (x5.h(n.a().i(), x5.c()))
				{
					n.a().a(x5.a(12f));
				}
				base.g(lc, A_0);
			}
			A_0.b().a(A_0.i().b(), A_0);
			A_0.i().l(A_0.i().b());
			return lc;
		}

		// Token: 0x040004B2 RID: 1202
		private new ej a = null;

		// Token: 0x040004B3 RID: 1203
		private ei b = null;

		// Token: 0x040004B4 RID: 1204
		private kh c = null;
	}
}
