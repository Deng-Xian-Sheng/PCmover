using System;

namespace zz93
{
	// Token: 0x02000184 RID: 388
	internal class jw : dy
	{
		// Token: 0x06000DAC RID: 3500 RVA: 0x0009A620 File Offset: 0x00099620
		internal jw(jy A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new jx(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06000DAD RID: 3501 RVA: 0x0009A670 File Offset: 0x00099670
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000DAE RID: 3502 RVA: 0x0009A688 File Offset: 0x00099688
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000DAF RID: 3503 RVA: 0x0009A6A0 File Offset: 0x000996A0
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06000DB0 RID: 3504 RVA: 0x0009A6B8 File Offset: 0x000996B8
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000DB1 RID: 3505 RVA: 0x0009A6C4 File Offset: 0x000996C4
		private void a(k0 A_0, ij A_1)
		{
			ms ms = null;
			mt mt = null;
			x5? x = ((n5)A_0.db()).p();
			bool flag = false;
			kz kz = null;
			bool flag2 = false;
			int num = this.cg().h();
			if (this.cg() != null && num > 0)
			{
				kz kz2 = this.cg().b(0).cm(A_1, A_0);
				if (kz2 != null)
				{
					kz2.aw(x5.a((float)this.cg().h()));
					ms = new ms(kz2);
					if (this.cg().b(0).ci())
					{
						ms.e(true);
						if (kz2.c5().q() != g6.c && kz2.c5().n() == g3.c)
						{
							mt = new mt(ms);
							ms = null;
						}
					}
					if (kz2.dg() == 622899778)
					{
						flag = true;
					}
					flag2 = dy.a(kz2);
				}
				g0? g = null;
				int i = 1;
				while (i < num)
				{
					if (this.cg().b(i).cr() == fa.e && kz2 != null)
					{
						if (ms == null || kz2.c5().q() == g6.c)
						{
							i++;
						}
						else if (kz2.c5().n() != g3.c)
						{
							goto IL_449;
						}
						goto IL_183;
					}
					goto IL_183;
					IL_449:
					i++;
					continue;
					IL_183:
					if (i < this.cg().h())
					{
						kz2 = this.cg().b(i).cm(A_1, A_0);
					}
					else
					{
						kz2 = null;
					}
					if (kz2 != null)
					{
						if (kz2.dg() == 622899778 && !flag)
						{
							flag = true;
							kz = kz2;
						}
						else
						{
							kz2.aw(x5.a((float)num));
							if (kz2.dg() == 1977)
							{
								if (ms != null)
								{
									if (kz2.c5().o() != null && kz2.c5().o().Value != g0.d)
									{
										g = kz2.c5().o();
									}
									if (flag2)
									{
										ms.l().a(kz2);
									}
									if (mt == null)
									{
										mt = new mt(ms);
									}
									else
									{
										mt.c(ms);
									}
								}
								else
								{
									ms = new ms(kz2);
									if (mt == null)
									{
										mt = new mt(ms);
									}
									else
									{
										mt.c(ms);
									}
								}
								ms = null;
								flag2 = false;
							}
							else
							{
								base.a(kz2, ref g);
								if (!this.cg().b(i).ci() || (kz2.c5().q() != g6.c && kz2.c5().n() != g3.c))
								{
									if (ms != null)
									{
										ms.l().a(kz2);
									}
									else
									{
										ms = new ms(kz2);
									}
									flag2 = dy.a(kz2);
								}
								else
								{
									if (flag2)
									{
										if (ms != null)
										{
											ms.l().a(kz2);
										}
										else
										{
											ms = new ms(kz2);
										}
									}
									else
									{
										if (ms != null)
										{
											if (mt == null)
											{
												mt = new mt(ms);
											}
											else
											{
												mt.c(ms);
											}
										}
										ms = new ms(kz2);
									}
									if (kz2.dg() != 1967)
									{
										ms.e(true);
									}
									if (mt == null)
									{
										mt = new mt(ms);
									}
									else
									{
										mt.c(ms);
									}
									ms = null;
									flag2 = false;
									if (i + 1 < num && this.cg().b(i + 1).cr() == fa.e)
									{
										this.cg().c(i + 1);
										num--;
									}
								}
							}
						}
					}
					goto IL_449;
				}
				if (ms != null)
				{
					if (mt == null)
					{
						mt = new mt(ms);
					}
					else
					{
						mt.c(ms);
					}
				}
				if (kz != null)
				{
					mt.d(new ms(kz));
				}
				if (mt != null && x != null)
				{
					mt.c().a().k(x.Value);
				}
				A_0.c(mt);
			}
		}

		// Token: 0x06000DB2 RID: 3506 RVA: 0x0009ABAC File Offset: 0x00099BAC
		private void a(kz A_0)
		{
			switch (A_0.c5().g())
			{
			case false:
			{
				m8 m = new m8();
				m.a(this.a().a());
				A_0.c5().a(m);
				A_0.c5().b(true);
				break;
			}
			case true:
				if (!A_0.c5().f().i())
				{
					A_0.c5().f().d(x5.a(7.5));
				}
				if (!A_0.c5().f().j())
				{
					A_0.c5().f().b(x5.a(7.5));
				}
				if (!A_0.c5().f().k())
				{
					A_0.c5().f().a(x5.a(3.75));
				}
				if (!A_0.c5().f().l())
				{
					A_0.c5().f().c(x5.a(7.5));
				}
				break;
			}
			if (!A_0.c5().d())
			{
				lf lf = new lf();
				x5 a_ = x5.a(1.5);
				string a_2 = "#E3E3E3";
				lf.a(this.a(a_, a_2).a());
				lf.n(true);
				A_0.c5().a(lf);
				A_0.c5().a(true);
			}
		}

		// Token: 0x06000DB3 RID: 3507 RVA: 0x0009AD4C File Offset: 0x00099D4C
		private hx a()
		{
			hx hx = new hx();
			ge ge = new ge(x5.a(7.5));
			ge ge2 = new ge(x5.a(3.75));
			ge ge3 = new ge(x5.a(9f));
			ge.a(i2.d);
			ge2.a(i2.d);
			ge3.a(i2.d);
			hx.a()[0] = new fb<ge>(136794, ge2);
			hx.a()[1] = new fb<ge>(426354259, ge3);
			hx.a()[2] = new fb<ge>(7021096, ge);
			hx.a()[3] = new fb<ge>(448574430, ge);
			return hx;
		}

		// Token: 0x06000DB4 RID: 3508 RVA: 0x0009AE28 File Offset: 0x00099E28
		private fg a(x5 A_0, string A_1)
		{
			fg fg = new fg();
			fv a_ = new fv(ft.h);
			fx a_2 = new fx(A_1);
			fw fw = new fw(A_0);
			fw.a(i2.d);
			fg.a()[0] = new fb<fu>(548864878, a_);
			fg.a()[1] = new fb<fu>(663309508, fw);
			fg.a()[2] = new fb<fu>(83960424, a_2);
			fg.a()[3] = new fb<fu>(1274012590, a_);
			fg.a()[4] = new fb<fu>(789921929, fw);
			fg.a()[5] = new fb<fu>(704614712, a_2);
			fg.a()[6] = new fb<fu>(1304279675, a_);
			fg.a()[7] = new fb<fu>(1930785673, fw);
			fg.a()[8] = new fb<fu>(1235296202, a_2);
			fg.a()[9] = new fb<fu>(758017896, a_);
			fg.a()[10] = new fb<fu>(1656587748, fw);
			fg.a()[11] = new fb<fu>(10890914, a_2);
			return fg;
		}

		// Token: 0x06000DB5 RID: 3509 RVA: 0x0009AFB4 File Offset: 0x00099FB4
		internal override kz cm(ij A_0, kz A_1)
		{
			l0 l = new l0();
			A_0.c(this.ch());
			A_0.a(l);
			n5 n = (n5)l.db();
			l.c5().c().i(n.j());
			A_0.b(l);
			lk lk = l.c5();
			bool flag = true;
			bool a_ = false;
			g2? g = lk.t();
			g2 valueOrDefault = g.GetValueOrDefault();
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					l = null;
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
				l.j(A_1);
				i3.a(l);
				i3.a(l, A_0);
				m4.a(n, l.c5(), a_);
				if (l.c5().ay().d() && l.c5().ay().e() != null)
				{
					l.b(mg.a(A_0, l.c5().ay().e(), A_0.e()));
				}
				this.a(l);
				g6 g2 = lk.q();
				if (g2 != g6.c)
				{
					switch (lk.n())
					{
					case g3.a:
					case g3.b:
						this.a(l, A_0);
						goto IL_1DD;
					}
					g = lk.t();
					valueOrDefault = g.GetValueOrDefault();
					if (g != null)
					{
						switch (valueOrDefault)
						{
						case g2.c:
							lk.e().a(x5.c());
							lk.e().c(x5.c());
							base.a(this.o(), l, A_0);
							l.df(false);
							goto IL_1DB;
						}
					}
					this.a(l, A_0);
					IL_1DB:
					IL_1DD:;
				}
				else
				{
					this.a(l, A_0);
				}
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return l;
		}

		// Token: 0x040006E5 RID: 1765
		private new jy a = null;

		// Token: 0x040006E6 RID: 1766
		private jx b = null;

		// Token: 0x040006E7 RID: 1767
		private bool c = true;
	}
}
