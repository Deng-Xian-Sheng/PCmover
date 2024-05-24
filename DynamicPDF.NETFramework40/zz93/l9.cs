using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001DB RID: 475
	internal class l9 : k0
	{
		// Token: 0x06001437 RID: 5175 RVA: 0x000E0B14 File Offset: 0x000DFB14
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001438 RID: 5176 RVA: 0x000E0B2C File Offset: 0x000DFB2C
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001439 RID: 5177 RVA: 0x000E0B3C File Offset: 0x000DFB3C
		internal override int dg()
		{
			return 1967;
		}

		// Token: 0x0600143A RID: 5178 RVA: 0x000E0B54 File Offset: 0x000DFB54
		internal override bool de()
		{
			return this.c;
		}

		// Token: 0x0600143B RID: 5179 RVA: 0x000E0B6C File Offset: 0x000DFB6C
		internal override void df(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600143C RID: 5180 RVA: 0x000E0B78 File Offset: 0x000DFB78
		internal bool a()
		{
			return this.b;
		}

		// Token: 0x0600143D RID: 5181 RVA: 0x000E0B90 File Offset: 0x000DFB90
		internal void a(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600143E RID: 5182 RVA: 0x000E0B9C File Offset: 0x000DFB9C
		internal override k0 dd()
		{
			l9 l = new l9();
			l.a(this.b);
			return l;
		}

		// Token: 0x0600143F RID: 5183 RVA: 0x000E0BC4 File Offset: 0x000DFBC4
		private void b(PageWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			x5 x = A_1;
			x5 x2 = A_2;
			x5 x3 = A_3;
			x5 x4 = A_4;
			if (base.c5().c().o() != ft.a)
			{
				x = x5.f(x, base.c5().c().n());
				x3 = x5.e(x3, base.c5().c().n());
			}
			if (base.c5().c().g() != ft.a)
			{
				x2 = x5.f(x2, base.c5().c().f());
				x4 = x5.e(x4, base.c5().c().f());
			}
			if (base.c5().c().s() != ft.a)
			{
				x3 = x5.e(x3, base.c5().c().r());
			}
			if (base.c5().c().k() != ft.a)
			{
				x4 = x5.e(x4, base.c5().c().j());
			}
			this.a(A_0, x, x2, x3, x4);
		}

		// Token: 0x06001440 RID: 5184 RVA: 0x000E0CDC File Offset: 0x000DFCDC
		private void a(PageWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			Color fillColor = new RgbColor(128, 128, 128);
			Color fillColor2 = new RgbColor(byte.MaxValue, byte.MaxValue, byte.MaxValue);
			A_0.SetGraphicsMode();
			if (this.dr().c5().ay().a() == null)
			{
				if (base.c5().ay().a() == null)
				{
					if (this.b)
					{
						A_0.SetFillColor(fillColor);
					}
					else
					{
						A_0.SetFillColor(fillColor2);
					}
				}
				else
				{
					A_0.SetFillColor(base.c5().ay().a());
				}
				A_0.Write_re(x5.b(A_1), x5.b(A_2), x5.b(A_3), x5.b(A_4));
				A_0.Write_f();
			}
		}

		// Token: 0x06001441 RID: 5185 RVA: 0x000E0DC4 File Offset: 0x000DFDC4
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.f(A_0, A_1);
		}

		// Token: 0x06001442 RID: 5186 RVA: 0x000E0DE0 File Offset: 0x000DFDE0
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			if (!base.c5().az().Equals(g9.b) && !base.c5().az().Equals(g9.c))
			{
				base.c5().c().e(base.r());
				base.c5().c().f(base.q());
				base.c5().c().g(base.s());
				base.c5().c().h(base.t());
				if (!base.q())
				{
					if (x5.c(base.c5().e().d(), this.dc()))
					{
						A_1 = x5.f(A_1, base.c5().e().d());
					}
				}
				if (this.c3())
				{
					A_1 = x5.f(A_1, base.an());
				}
				if (!base.s())
				{
					A_2 = x5.f(A_2, base.c5().e().a());
				}
				x5 a_ = x5.f(base.c5().e().a(), base.c5().e().c());
				x5 x = x5.e(base.bi(), base.aa());
				switch (this.a.r())
				{
				case gn.b:
					x = x5.e(x5.e(base.bm(), base.aa()), x);
					A_1 = x5.f(A_1, x);
					break;
				case gn.c:
				{
					x5? x2 = base.c5().am();
					x5 a_2 = x5.c();
					if ((x2 != null && x5.h(x2.GetValueOrDefault(), a_2)) || this.dr().dg() == 11228793)
					{
						x = x5.e(x5.e(base.bm(), base.aa()), x);
					}
					else
					{
						x = x5.e(x5.e(base.bi(), base.aa()), x);
					}
					x = x5.a(x, 2);
					A_1 = x5.f(A_1, x);
					break;
				}
				}
				base.c5().c().a(A_0, A_1, A_2, base.bi(), x5.e(base.ar(), a_));
				this.b(A_0, A_1, A_2, base.bi(), x5.e(base.ar(), a_));
			}
		}

		// Token: 0x06001443 RID: 5187 RVA: 0x000E106C File Offset: 0x000E006C
		internal override kz dm()
		{
			l9 l = new l9();
			l.j(this.dr());
			l.dc(this.db().du());
			l.a((lk)base.c5().du());
			l.df(this.c);
			if (base.n() != null)
			{
				l.c(base.n().p());
			}
			return l;
		}

		// Token: 0x04000990 RID: 2448
		private new n5 a = new n5();

		// Token: 0x04000991 RID: 2449
		private new bool b = false;

		// Token: 0x04000992 RID: 2450
		private new bool c = true;
	}
}
