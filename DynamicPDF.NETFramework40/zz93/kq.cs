using System;

namespace zz93
{
	// Token: 0x020001A2 RID: 418
	internal class kq : dy
	{
		// Token: 0x06000EAC RID: 3756 RVA: 0x000B0248 File Offset: 0x000AF248
		internal kq(kr A_0) : base(null)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x06000EAD RID: 3757 RVA: 0x000B0298 File Offset: 0x000AF298
		internal kq(kr A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06000EAE RID: 3758 RVA: 0x000B02F0 File Offset: 0x000AF2F0
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000EAF RID: 3759 RVA: 0x000B0308 File Offset: 0x000AF308
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000EB0 RID: 3760 RVA: 0x000B0320 File Offset: 0x000AF320
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06000EB1 RID: 3761 RVA: 0x000B0338 File Offset: 0x000AF338
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000EB2 RID: 3762 RVA: 0x000B0344 File Offset: 0x000AF344
		internal override bool cp()
		{
			return true;
		}

		// Token: 0x06000EB3 RID: 3763 RVA: 0x000B0358 File Offset: 0x000AF358
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x06000EB4 RID: 3764 RVA: 0x000B0370 File Offset: 0x000AF370
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06000EB5 RID: 3765 RVA: 0x000B037C File Offset: 0x000AF37C
		internal override kz cm(ij A_0, kz A_1)
		{
			mm mm = new mm();
			A_0.c(this.ch());
			A_0.a(mm);
			n5 n = (n5)mm.db();
			mm.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(mm);
			}
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = mm.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					mm = null;
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
				mm.j(A_1);
				i3.a(mm);
				i3.a(mm, A_0);
				m4.a(n, mm.c5(), a_);
				if (mm.c5().ay().e() != null)
				{
					mm.b(mg.a(A_0, mm.c5().ay().e(), A_0.e()));
				}
				switch (n.m()[0])
				{
				case gx.a:
					if (n.w())
					{
						n.m()[0] = gx.b;
					}
					goto IL_15A;
				case gx.c:
				case gx.d:
					goto IL_15A;
				}
				n.m()[0] = gx.b;
				IL_15A:
				base.e(mm, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return mm;
		}

		// Token: 0x0400073D RID: 1853
		private new kr a = null;

		// Token: 0x0400073E RID: 1854
		private kl b = null;

		// Token: 0x0400073F RID: 1855
		private bool c = false;

		// Token: 0x04000740 RID: 1856
		private new bool d = true;
	}
}
