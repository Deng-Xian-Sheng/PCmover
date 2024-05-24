using System;

namespace zz93
{
	// Token: 0x0200017F RID: 383
	internal class jr : dy
	{
		// Token: 0x06000D94 RID: 3476 RVA: 0x00099D30 File Offset: 0x00098D30
		internal jr(jk A_0, jt A_1, p1 A_2, kg A_3, ij A_4) : base(null)
		{
			this.a = A_1;
			this.b = new js(A_0, A_3, A_2, A_4);
			this.b.cq();
		}

		// Token: 0x06000D95 RID: 3477 RVA: 0x00099D80 File Offset: 0x00098D80
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000D96 RID: 3478 RVA: 0x00099D98 File Offset: 0x00098D98
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000D97 RID: 3479 RVA: 0x00099DB0 File Offset: 0x00098DB0
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06000D98 RID: 3480 RVA: 0x00099DC8 File Offset: 0x00098DC8
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000D99 RID: 3481 RVA: 0x00099DD4 File Offset: 0x00098DD4
		internal override kz cm(ij A_0, kz A_1)
		{
			ly ly = new ly();
			A_0.c(this.ch());
			A_0.a(ly);
			n5 n = (n5)ly.db();
			ly.c5().c().i(n.j());
			A_0.b(ly);
			bool flag = true;
			bool a_ = false;
			lk lk = ly.c5();
			g2 valueOrDefault = lk.t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					ly = null;
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
				ly.j(A_1);
				i3.a(ly);
				i3.a(ly, A_0);
				m4.a(n, ly.c5(), a_);
				if (ly.c5().ay().d() && ly.c5().ay().e() != null)
				{
					ly.b(mg.a(A_0, ly.c5().ay().e(), A_0.e()));
				}
				base.f(ly, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return ly;
		}

		// Token: 0x040006DD RID: 1757
		private new jt a = null;

		// Token: 0x040006DE RID: 1758
		private js b = null;

		// Token: 0x040006DF RID: 1759
		private bool c = true;
	}
}
