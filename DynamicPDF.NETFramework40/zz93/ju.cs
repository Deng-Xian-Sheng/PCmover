using System;

namespace zz93
{
	// Token: 0x02000182 RID: 386
	internal class ju : dy
	{
		// Token: 0x06000D9F RID: 3487 RVA: 0x0009A1FC File Offset: 0x000991FC
		internal ju(jv A_0) : base(null)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x06000DA0 RID: 3488 RVA: 0x0009A24C File Offset: 0x0009924C
		internal ju(jv A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06000DA1 RID: 3489 RVA: 0x0009A2A4 File Offset: 0x000992A4
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000DA2 RID: 3490 RVA: 0x0009A2BC File Offset: 0x000992BC
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000DA3 RID: 3491 RVA: 0x0009A2D4 File Offset: 0x000992D4
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06000DA4 RID: 3492 RVA: 0x0009A2EC File Offset: 0x000992EC
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000DA5 RID: 3493 RVA: 0x0009A2F8 File Offset: 0x000992F8
		internal override bool cp()
		{
			return true;
		}

		// Token: 0x06000DA6 RID: 3494 RVA: 0x0009A30C File Offset: 0x0009930C
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x06000DA7 RID: 3495 RVA: 0x0009A324 File Offset: 0x00099324
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06000DA8 RID: 3496 RVA: 0x0009A330 File Offset: 0x00099330
		internal override kz cm(ij A_0, kz A_1)
		{
			lz lz = new lz();
			A_0.c(this.ch());
			A_0.a(lz);
			n5 n = (n5)lz.db();
			lz.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(lz);
			}
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = lz.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					lz = null;
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
				lz.j(A_1);
				hd a_2 = i3.b(lz);
				ig a_3 = new ig(new fc[]
				{
					new fc(6968946, a_2)
				});
				A_0.a(this.ch().cn(), a_3);
				n.a().a(f4.b);
				i3.a(lz);
				i3.a(lz, A_0);
				m4.a(n, lz.c5(), a_);
				if (lz.c5().ay().e() != null)
				{
					lz.b(mg.a(A_0, lz.c5().ay().e(), A_0.e()));
				}
				base.e(lz, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return lz;
		}

		// Token: 0x040006E1 RID: 1761
		private new jv a = null;

		// Token: 0x040006E2 RID: 1762
		private kl b = null;

		// Token: 0x040006E3 RID: 1763
		private bool c = false;

		// Token: 0x040006E4 RID: 1764
		private new bool d = true;
	}
}
