using System;

namespace zz93
{
	// Token: 0x02000174 RID: 372
	internal class jg : dy
	{
		// Token: 0x06000D67 RID: 3431 RVA: 0x00098B24 File Offset: 0x00097B24
		internal jg(jj A_0) : base(null)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x06000D68 RID: 3432 RVA: 0x00098B74 File Offset: 0x00097B74
		internal jg(jj A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06000D69 RID: 3433 RVA: 0x00098BCC File Offset: 0x00097BCC
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000D6A RID: 3434 RVA: 0x00098BE4 File Offset: 0x00097BE4
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000D6B RID: 3435 RVA: 0x00098BFC File Offset: 0x00097BFC
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06000D6C RID: 3436 RVA: 0x00098C14 File Offset: 0x00097C14
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000D6D RID: 3437 RVA: 0x00098C20 File Offset: 0x00097C20
		internal override kz cm(ij A_0, kz A_1)
		{
			lw lw = new lw();
			A_0.c(this.ch());
			A_0.a(lw);
			n5 n = (n5)lw.db();
			lw.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(lw);
			}
			bool flag = true;
			bool a_ = false;
			lk lk = lw.c5();
			g2 valueOrDefault = lk.t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					lw = null;
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
				lw.j(A_1);
				hd a_2 = i3.b(lw);
				ig a_3 = new ig(new fc[]
				{
					new fc(6968946, a_2)
				});
				A_0.a(this.ch().cn(), a_3);
				n.a().a(f4.b);
				i3.a(lw);
				i3.a(lw, A_0);
				m4.a(n, lk, a_);
				if (lk.ay().e() != null)
				{
					lw.b(mg.a(A_0, lk.ay().e(), A_0.e()));
				}
				base.e(lw, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return lw;
		}

		// Token: 0x040006D0 RID: 1744
		private new jj a = null;

		// Token: 0x040006D1 RID: 1745
		private kl b = null;

		// Token: 0x040006D2 RID: 1746
		private bool c = false;

		// Token: 0x040006D3 RID: 1747
		private new bool d = true;
	}
}
