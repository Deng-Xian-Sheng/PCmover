using System;

namespace zz93
{
	// Token: 0x020001A8 RID: 424
	internal class kw : dy
	{
		// Token: 0x06000ED3 RID: 3795 RVA: 0x000B0ECC File Offset: 0x000AFECC
		internal kw(ky A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kx(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06000ED4 RID: 3796 RVA: 0x000B0F1C File Offset: 0x000AFF1C
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000ED5 RID: 3797 RVA: 0x000B0F34 File Offset: 0x000AFF34
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000ED6 RID: 3798 RVA: 0x000B0F4C File Offset: 0x000AFF4C
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06000ED7 RID: 3799 RVA: 0x000B0F64 File Offset: 0x000AFF64
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000ED8 RID: 3800 RVA: 0x000B0F70 File Offset: 0x000AFF70
		internal override kz cm(ij A_0, kz A_1)
		{
			mp mp = new mp();
			A_0.c(this.ch());
			A_0.a(mp);
			n5 n = (n5)mp.db();
			mp.c5().c().i(n.j());
			A_0.b(mp);
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = mp.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					mp = null;
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
				mp.j(A_1);
				i3.a(mp);
				i3.a(mp, A_0);
				m4.a(n, mp.c5(), a_);
				if (mp.c5().ay().e() != null)
				{
					mp.b(mg.a(A_0, mp.c5().ay().e(), A_0.e()));
				}
				base.e(mp, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return mp;
		}

		// Token: 0x04000749 RID: 1865
		private new ky a = null;

		// Token: 0x0400074A RID: 1866
		private kx b = null;

		// Token: 0x0400074B RID: 1867
		private bool c = false;
	}
}
