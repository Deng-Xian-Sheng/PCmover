using System;

namespace zz93
{
	// Token: 0x020000B5 RID: 181
	internal class d5 : dy
	{
		// Token: 0x060008D7 RID: 2263 RVA: 0x000798C4 File Offset: 0x000788C4
		internal d5(d6 A_0) : base(null)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x00079914 File Offset: 0x00078914
		internal d5(d6 A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x0007996C File Offset: 0x0007896C
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x00079984 File Offset: 0x00078984
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x0007999C File Offset: 0x0007899C
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x000799B4 File Offset: 0x000789B4
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x000799C0 File Offset: 0x000789C0
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x000799D8 File Offset: 0x000789D8
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x000799E4 File Offset: 0x000789E4
		internal override kz cm(ij A_0, kz A_1)
		{
			k2 k = new k2();
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

		// Token: 0x04000498 RID: 1176
		private new d6 a = null;

		// Token: 0x04000499 RID: 1177
		private kl b = null;

		// Token: 0x0400049A RID: 1178
		private bool c = false;

		// Token: 0x0400049B RID: 1179
		private new bool d = true;
	}
}
