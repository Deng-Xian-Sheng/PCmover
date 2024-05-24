using System;

namespace zz93
{
	// Token: 0x02000171 RID: 369
	internal class jd : dy
	{
		// Token: 0x06000D5C RID: 3420 RVA: 0x000985F0 File Offset: 0x000975F0
		internal jd(jk A_0, jf A_1, p1 A_2, kg A_3, ij A_4) : base(null)
		{
			this.a = A_1;
			this.b = new je(A_0, A_3, A_2, A_4);
			this.b.cq();
		}

		// Token: 0x06000D5D RID: 3421 RVA: 0x00098640 File Offset: 0x00097640
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000D5E RID: 3422 RVA: 0x00098658 File Offset: 0x00097658
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000D5F RID: 3423 RVA: 0x00098670 File Offset: 0x00097670
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06000D60 RID: 3424 RVA: 0x00098688 File Offset: 0x00097688
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000D61 RID: 3425 RVA: 0x00098694 File Offset: 0x00097694
		internal override kz cm(ij A_0, kz A_1)
		{
			lu lu = new lu();
			A_0.c(this.ch());
			A_0.a(lu);
			n5 n = (n5)lu.db();
			lu.c5().c().i(n.j());
			A_0.b(lu);
			lk lk = lu.c5();
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = lk.t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					lu = null;
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
				lu.j(A_1);
				i3.a(lu);
				i3.a(lu, A_0);
				if (!lu.c5().a7() || lu.c5().e().k())
				{
					lu.c5().e().d(x5.a(30f));
					lu.c5().p(true);
				}
				m4.a(n, lu.c5(), a_);
				if (lu.c5().ay().d() && lu.c5().ay().e() != null)
				{
					lu.b(mg.a(A_0, lu.c5().ay().e(), A_0.e()));
				}
				base.f(lu, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return lu;
		}

		// Token: 0x040006CC RID: 1740
		private new jf a = null;

		// Token: 0x040006CD RID: 1741
		private je b = null;

		// Token: 0x040006CE RID: 1742
		private bool c = true;
	}
}
