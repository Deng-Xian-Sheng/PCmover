using System;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x0200026C RID: 620
	internal class qa : dy
	{
		// Token: 0x06001BEF RID: 7151 RVA: 0x0011FF20 File Offset: 0x0011EF20
		internal qa(qc A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new qb(A_2, A_1, A_3);
			this.b.cq();
			this.c = true;
		}

		// Token: 0x06001BF0 RID: 7152 RVA: 0x0011FF7C File Offset: 0x0011EF7C
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001BF1 RID: 7153 RVA: 0x0011FF94 File Offset: 0x0011EF94
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001BF2 RID: 7154 RVA: 0x0011FFAC File Offset: 0x0011EFAC
		internal override bool ci()
		{
			return this.d;
		}

		// Token: 0x06001BF3 RID: 7155 RVA: 0x0011FFC4 File Offset: 0x0011EFC4
		internal override void cj(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001BF4 RID: 7156 RVA: 0x0011FFD0 File Offset: 0x0011EFD0
		private void b(n2 A_0, ij A_1)
		{
			n5 n = (n5)A_0.db();
			l2 l = A_1.c().a(n, A_1);
			A_0.a(l);
			if (A_0.c5().am() == null)
			{
				A_0.c5().j(new x5?(this.b(l.e(), n.a().i())));
				A_0.c5().d(i2.d);
				A_0.c5().o(false);
			}
			if (A_0.c5().v() == null)
			{
				A_0.c5().i(new x5?(this.a(l.e(), n.a().i())));
				A_0.c5().a(i2.d);
			}
		}

		// Token: 0x06001BF5 RID: 7157 RVA: 0x001200AC File Offset: 0x0011F0AC
		private x5 b(Font A_0, x5 A_1)
		{
			int num = this.a.b();
			pa pa = null;
			if (this.cg().h() != 0)
			{
				pa = (pa)this.cg().b(0);
			}
			x5 result;
			if (pa == null || pa.e() < num)
			{
				char[] text = new char[]
				{
					'n'
				};
				float textWidth = A_0.GetTextWidth(text, x5.b(A_1));
				result = x5.a(textWidth * (float)num);
			}
			else
			{
				result = x5.a(A_0.a(pa.c(), pa.d(), num, x5.b(A_1)));
			}
			return result;
		}

		// Token: 0x06001BF6 RID: 7158 RVA: 0x00120160 File Offset: 0x0011F160
		private x5 a(Font A_0, x5 A_1)
		{
			int num = this.a.c();
			float defaultLeading = A_0.GetDefaultLeading(x5.b(A_1));
			return x5.a(defaultLeading * (float)num);
		}

		// Token: 0x06001BF7 RID: 7159 RVA: 0x00120198 File Offset: 0x0011F198
		private void a(n2 A_0)
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
					A_0.c5().f().d(x5.a(1.5));
				}
				if (!A_0.c5().f().j())
				{
					A_0.c5().f().b(x5.a(1.5));
				}
				if (!A_0.c5().f().k())
				{
					A_0.c5().f().a(x5.a(1.5));
				}
				if (!A_0.c5().f().l())
				{
					A_0.c5().f().c(x5.a(1.5));
				}
				break;
			}
			if (!A_0.c5().d())
			{
				lf lf = new lf();
				x5 a_ = x5.a(0.75);
				string a_2 = "#E3E3E3";
				if (this.a.a())
				{
					a_2 = "#A0A0A0";
				}
				lf.a(this.a(a_, a_2).a());
				lf.n(true);
				A_0.c5().a(lf);
				A_0.c5().a(true);
			}
			if (A_0.c5().ay() != null)
			{
				if (!A_0.c5().ay().b())
				{
					A_0.c5().ay().a(Color.d("white"));
				}
			}
			else
			{
				fe fe = new fe();
				fb<fs>[] array = new fb<fs>[5];
				array[0] = new fb<fs>(510035525, new afu("white"));
				fe.a(array);
				k8 k = new k8();
				k.a(array);
				A_0.c5().a(k);
			}
			if (this.a.a())
			{
				((n5)A_0.db()).a(Color.d("#A0A0A0"));
			}
		}

		// Token: 0x06001BF8 RID: 7160 RVA: 0x00120424 File Offset: 0x0011F424
		private hx a()
		{
			hx hx = new hx();
			ge ge = new ge(x5.a(1.5));
			ge.a(i2.d);
			hx.a()[0] = new fb<ge>(136794, ge);
			hx.a()[1] = new fb<ge>(426354259, ge);
			hx.a()[2] = new fb<ge>(7021096, ge);
			hx.a()[3] = new fb<ge>(448574430, ge);
			return hx;
		}

		// Token: 0x06001BF9 RID: 7161 RVA: 0x001204CC File Offset: 0x0011F4CC
		private fg a(x5 A_0, string A_1)
		{
			fg fg = new fg();
			fv a_ = new fv(ft.h);
			fx a_2 = new fx(A_1);
			fw a_3 = new fw(A_0);
			fg.a()[0] = new fb<fu>(548864878, a_);
			fg.a()[1] = new fb<fu>(663309508, a_3);
			fg.a()[2] = new fb<fu>(83960424, a_2);
			fg.a()[3] = new fb<fu>(1274012590, a_);
			fg.a()[4] = new fb<fu>(789921929, a_3);
			fg.a()[5] = new fb<fu>(704614712, a_2);
			fg.a()[6] = new fb<fu>(1304279675, a_);
			fg.a()[7] = new fb<fu>(1930785673, a_3);
			fg.a()[8] = new fb<fu>(1235296202, a_2);
			fg.a()[9] = new fb<fu>(758017896, a_);
			fg.a()[10] = new fb<fu>(1656587748, a_3);
			fg.a()[11] = new fb<fu>(10890914, a_2);
			return fg;
		}

		// Token: 0x06001BFA RID: 7162 RVA: 0x00120650 File Offset: 0x0011F650
		private void a(n2 A_0, ij A_1)
		{
			mt mt = null;
			bool flag = false;
			if (this.cg() != null && this.cg().h() > 0)
			{
				bool flag2 = this.cg().b(0).d5();
				this.cg().b(0).f(this.c);
				kz kz = this.cg().b(0).cm(A_1, A_0);
				kz.j(A_0);
				ms ms = new ms(kz);
				if (this.cg().b(0).ci() || flag2)
				{
					ms.e(true);
					if (kz.c5().q() != g6.c && kz.c5().n() == g3.c)
					{
						mt = new mt(ms);
						ms = null;
					}
					flag = dy.a(kz);
				}
				g0? g = null;
				for (int i = 1; i < this.cg().h(); i++)
				{
					flag2 = this.cg().b(i).d5();
					kz = this.cg().b(i).cm(A_1, A_0);
					kz.j(A_0);
					if (kz != null)
					{
						kz.aw(x5.a((float)this.cg().h()));
						if (kz.dg() == 1977)
						{
							if (ms != null)
							{
								if (kz.c5().o() != null && kz.c5().o().Value != g0.d)
								{
									g = kz.c5().o();
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
								ms = new ms(kz);
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
							flag = false;
						}
						else
						{
							base.a(kz, ref g);
							if (!this.cg().b(i).ci() || kz.c5().q() == g6.c || kz.c5().n() != g3.c)
							{
								if (ms != null)
								{
									if (base.h(i) && kz.dg() != 34721)
									{
										bool flag3 = base.a(i, ms, A_0, A_1);
										if (flag3)
										{
											i++;
										}
									}
									ms.l().a(kz);
								}
								else
								{
									ms = new ms(kz);
								}
								flag = dy.a(kz);
								if (flag2)
								{
									if (mt == null)
									{
										mt = new mt(ms);
									}
									else
									{
										mt.c(ms);
									}
									ms = null;
								}
							}
							else
							{
								if (flag)
								{
									if (ms != null)
									{
										ms.l().a(kz);
									}
									else
									{
										ms = new ms(kz);
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
									ms = new ms(kz);
								}
								if (kz.dg() != 1967)
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
								flag = false;
							}
						}
					}
					else if (flag2)
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
							ms = null;
						}
					}
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
				A_0.c(mt);
			}
		}

		// Token: 0x06001BFB RID: 7163 RVA: 0x00120A80 File Offset: 0x0011FA80
		internal override kz cm(ij A_0, kz A_1)
		{
			n2 n = new n2();
			A_0.c(this.ch());
			A_0.a(n);
			n5 n2 = (n5)n.db();
			n.c5().c().i(n2.j());
			A_0.b(n);
			bool flag = true;
			bool a_ = false;
			lk lk = n.c5();
			g2? g = lk.t();
			g2 valueOrDefault = g.GetValueOrDefault();
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					n = null;
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
				n.j(A_1);
				if (n2.a().a() & n2.a().b())
				{
					i3.b(n);
				}
				i3.a(n);
				i3.a(n, A_0);
				m4.a(n2, lk, a_);
				if (lk.ay().d() && lk.ay().e() != null)
				{
					n.b(mg.a(A_0, lk.ay().e(), A_0.e()));
				}
				this.b(n, A_0);
				this.a(n);
				if (this.cg().h() == 0)
				{
					pl a_2 = new pl();
					this.b.a(a_2);
				}
				bool flag2;
				if (lk.u())
				{
					g = lk.t();
					flag2 = !(g == g2.b);
				}
				else
				{
					flag2 = true;
				}
				if (!flag2)
				{
					this.d = true;
				}
				this.a(n, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return n;
		}

		// Token: 0x04000C9C RID: 3228
		private new qc a = null;

		// Token: 0x04000C9D RID: 3229
		private qb b = null;

		// Token: 0x04000C9E RID: 3230
		private bool c = false;

		// Token: 0x04000C9F RID: 3231
		private new bool d = false;
	}
}
