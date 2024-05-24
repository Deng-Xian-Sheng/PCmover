using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001D0 RID: 464
	internal class l0 : k0
	{
		// Token: 0x060013B0 RID: 5040 RVA: 0x000DDC98 File Offset: 0x000DCC98
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060013B1 RID: 5041 RVA: 0x000DDCB0 File Offset: 0x000DCCB0
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060013B2 RID: 5042 RVA: 0x000DDCC0 File Offset: 0x000DCCC0
		internal override int dg()
		{
			return 899925938;
		}

		// Token: 0x060013B3 RID: 5043 RVA: 0x000DDCD8 File Offset: 0x000DCCD8
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x060013B4 RID: 5044 RVA: 0x000DDCF0 File Offset: 0x000DCCF0
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060013B5 RID: 5045 RVA: 0x000DDCFC File Offset: 0x000DCCFC
		internal override k0 dd()
		{
			return new l0();
		}

		// Token: 0x060013B6 RID: 5046 RVA: 0x000DDD14 File Offset: 0x000DCD14
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x060013B7 RID: 5047 RVA: 0x000DDD33 File Offset: 0x000DCD33
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x060013B8 RID: 5048 RVA: 0x000DDD40 File Offset: 0x000DCD40
		private void a(PageWriter A_0, x5 A_1, x5 A_2, x5 A_3)
		{
			if (base.c5().c().g() != ft.a)
			{
				LineStyle lineStyle = LineStyle.None;
				switch (base.c5().c().g())
				{
				case ft.f:
					lineStyle = LineStyle.Dots;
					break;
				case ft.g:
					lineStyle = LineStyle.Dash;
					break;
				default:
					lineStyle = LineStyle.Solid;
					break;
				}
				A_0.SetLineStyle(lineStyle);
				A_0.SetLineWidth(x5.b(base.c5().c().f()));
				A_0.SetStrokeColor(base.c5().c().e());
				A_0.Write_m_(x5.b(A_1), x5.b(A_2));
				A_0.Write_l_(x5.b(x5.f(A_1, base.c5().f().d())), x5.b(A_2));
				A_0.Write_S();
				A_0.Write_m_(x5.b(x5.f(x5.f(A_1, base.c5().f().d()), base.n().c().a().l().a().b().aq())), x5.b(A_2));
				A_0.Write_l_(x5.b(x5.f(A_1, A_3)), x5.b(A_2));
				A_0.Write_S();
				base.c5().c().a(ft.a);
			}
		}

		// Token: 0x060013B9 RID: 5049 RVA: 0x000DDEB8 File Offset: 0x000DCEB8
		internal override kz dj(x5 A_0, x5 A_1)
		{
			kz result;
			switch (this.de())
			{
			case false:
				result = base.c(A_0, A_1);
				break;
			case true:
				result = base.f(A_0, A_1);
				break;
			default:
				result = null;
				break;
			}
			return result;
		}

		// Token: 0x060013BA RID: 5050 RVA: 0x000DDEF8 File Offset: 0x000DCEF8
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c5().c().e(base.r());
			base.c5().c().f(base.q());
			base.c5().c().g(base.s());
			base.c5().c().h(base.t());
			A_1 = x5.f(A_1, base.cc());
			switch (base.c5().q())
			{
			case g6.b:
				if (base.c5().b() != null)
				{
					A_1 = x5.f(A_1, base.c5().b().Value);
				}
				else
				{
					bool flag;
					if (base.c5().s() != null)
					{
						x5? x = base.c5().s();
						x5 a_ = x5.c();
						flag = (x != null && !x5.g(x.GetValueOrDefault(), a_));
					}
					else
					{
						flag = true;
					}
					if (!flag)
					{
						A_1 = x5.e(base.aq(), base.c5().s().Value);
					}
				}
				if (base.c5().a() != null)
				{
					A_2 = x5.f(A_2, base.c5().a().Value);
				}
				else
				{
					bool flag2;
					if (base.c5().h() != null)
					{
						x5? x = base.c5().h();
						x5 a_ = x5.c();
						flag2 = (x != null && !x5.g(x.GetValueOrDefault(), a_));
					}
					else
					{
						flag2 = true;
					}
					if (!flag2)
					{
						A_2 = x5.e(base.ao(), base.c5().h().Value);
					}
				}
				break;
			case g6.c:
				if (base.c5().b() != null)
				{
					A_1 = x5.f(A_1, base.c5().b().Value);
				}
				else
				{
					bool flag3;
					if (base.c5().s() != null)
					{
						x5? x = base.c5().s();
						x5 a_ = x5.c();
						flag3 = (x != null && !x5.g(x.GetValueOrDefault(), a_));
					}
					else
					{
						flag3 = true;
					}
					if (!flag3)
					{
						A_1 = x5.e(base.bi(), base.c5().s().Value);
					}
				}
				if (!base.c1())
				{
					if (base.c5().a() != null)
					{
						A_2 = x5.f(A_2, base.c5().a().Value);
					}
					else
					{
						bool flag4;
						if (base.c5().h() != null)
						{
							x5? x = base.c5().h();
							x5 a_ = x5.c();
							flag4 = (x != null && !x5.g(x.GetValueOrDefault(), a_));
						}
						else
						{
							flag4 = true;
						}
						if (!flag4)
						{
							A_2 = x5.e(base.bj(), base.c5().h().Value);
						}
					}
				}
				break;
			}
			x5 x2 = x5.c();
			x5 a_2 = x5.c();
			x5 x3 = A_2;
			if (!base.s() && !this.@do())
			{
				x2 = x5.f(x2, base.c5().e().a());
				x3 = x5.f(x3, base.c5().e().a());
			}
			if (!base.t())
			{
				x2 = x5.f(x2, base.c5().e().c());
			}
			a_2 = x5.f(base.c5().e().d(), base.c5().e().b());
			A_1 = x5.f(A_1, base.c5().e().d());
			x5 x4 = x5.e(base.ar(), x2);
			bool flag5 = true;
			x5 a_3 = x5.c();
			if (base.n() != null && base.n().c().a() != null && base.n().c().a().l() != null)
			{
				kz kz = base.n().c().a().l().a().b();
				if (kz != null && kz.dg() == 622899778)
				{
					a_3 = x5.a(kz.ar(), 2);
					x3 = x5.f(x3, a_3);
					x4 = x5.e(x4, a_3);
					flag5 = false;
				}
			}
			if (this.c3())
			{
				A_1 = x5.f(A_1, base.an());
				x5 x5 = x5.c();
				if (base.c5().v() != null && x5.g(base.c5().v().Value, x5.c()))
				{
					x5 = base.c5().v().Value;
				}
				else
				{
					x5 = x5.e(base.ar(), x2);
				}
				x5 = x5.e(x5, a_3);
				base.a(A_0, A_1, x3, x5.e(base.aq(), a_2), x5);
				if (!flag5)
				{
					this.a(A_0, A_1, x3, x5.e(base.aq(), a_2));
				}
			}
			else if (base.c5().am() != null)
			{
				base.a(A_0, A_1, x3, x5.e(base.aq(), a_2), x4);
				if (!flag5)
				{
					this.a(A_0, A_1, x3, x5.e(base.aq(), a_2));
				}
			}
			else
			{
				base.a(A_0, A_1, x3, base.bi(), x4);
				if (!flag5)
				{
					this.a(A_0, A_1, x3, base.bi());
				}
			}
			if (base.n() != null)
			{
				if (!base.q())
				{
					A_1 = x5.f(A_1, base.c5().f().d());
				}
				if (base.c5().c().o() != ft.a)
				{
					A_1 = x5.f(A_1, base.c5().c().n());
				}
				int num = 0;
				mu mu = base.n().c();
				while (mu != null && mu.a() != null)
				{
					if (flag5 && num == 0)
					{
						A_2 = x5.f(A_2, base.c5().f().a());
						num++;
					}
					ms ms = mu.a();
					switch (base.c5().az())
					{
					case g9.b:
					case g9.c:
						ms.m(true);
						break;
					default:
						ms.m(false);
						break;
					}
					if (ms != null && ms.l() != null)
					{
						ms.a(this, mu.b());
						ms.a(A_0, A_1, A_2);
					}
					mu = mu.b();
					flag5 = true;
				}
			}
		}

		// Token: 0x060013BB RID: 5051 RVA: 0x000DE688 File Offset: 0x000DD688
		internal override kz dm()
		{
			l0 l = new l0();
			l.j(this.dr());
			l.dc(this.db().du());
			l.a((lk)base.c5().du());
			l.df(this.b);
			if (base.n() != null)
			{
				l.c(base.n().p());
			}
			return l;
		}

		// Token: 0x0400094C RID: 2380
		private new n5 a = new n5();

		// Token: 0x0400094D RID: 2381
		private new bool b = true;
	}
}
