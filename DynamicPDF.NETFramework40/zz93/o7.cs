using System;

namespace zz93
{
	// Token: 0x02000245 RID: 581
	internal class o7 : dy
	{
		// Token: 0x06001ABA RID: 6842 RVA: 0x00115EA8 File Offset: 0x00114EA8
		internal o7(o9 A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new o8(A_2, A_1, A_3);
			this.b.cq();
			this.f(true);
		}

		// Token: 0x06001ABB RID: 6843 RVA: 0x00115F00 File Offset: 0x00114F00
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001ABC RID: 6844 RVA: 0x00115F18 File Offset: 0x00114F18
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001ABD RID: 6845 RVA: 0x00115F30 File Offset: 0x00114F30
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001ABE RID: 6846 RVA: 0x00115F48 File Offset: 0x00114F48
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001ABF RID: 6847 RVA: 0x00115F54 File Offset: 0x00114F54
		private void a(nc A_0, ij A_1)
		{
			mt mt = null;
			bool flag = false;
			if (this.cg() != null && this.cg().h() > 0)
			{
				this.cg().b(0).f(this.o());
				kz kz = this.cg().b(0).cm(A_1, A_0);
				bool flag2 = this.cg().b(0).d5();
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
					this.cg().b(i).f(this.o());
					kz = this.cg().b(i).cm(A_1, A_0);
					flag2 = this.cg().b(i).d5();
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
								if (this.cg().b(i).ci() || flag2)
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

		// Token: 0x06001AC0 RID: 6848 RVA: 0x001163B4 File Offset: 0x001153B4
		internal override kz cm(ij A_0, kz A_1)
		{
			nc nc = new nc();
			A_0.c(this.ch());
			A_0.a(nc);
			n5 n = (n5)nc.db();
			nc.c5().c().i(n.j());
			A_0.b(nc);
			lk lk = nc.c5();
			bool flag = true;
			bool flag2 = false;
			g2? g = lk.t();
			g2 valueOrDefault = g.GetValueOrDefault();
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					nc = null;
					flag = false;
					A_0.a(false);
					break;
				case g2.c:
					flag2 = true;
					break;
				}
			}
			if (flag)
			{
				A_0.a(true);
				nc.j(A_1);
				if (!flag2)
				{
					lk.e().a(new int?(nc.dg()));
				}
				hd hd = i3.b(nc);
				if (hd != null)
				{
					ig a_ = new ig(new fc[]
					{
						new fc(6968946, hd)
					});
					A_0.a(this.ch().cn(), a_);
				}
				i3.a(nc);
				i3.a(nc, A_0);
				g = lk.t();
				if (g != g2.c)
				{
					lk.e().a(new int?(nc.dg()));
				}
				m4.a(n, lk, flag2);
				if (lk.ay().e() != null)
				{
					nc.b(mg.a(A_0, lk.ay().e(), A_0.e()));
				}
				nc.aa(A_1.ch());
				if (nc.ch())
				{
					nc.ab(A_1.ci());
					nc.az(A_1.cl());
					nc.ay(A_1.ck());
				}
				g6 g2 = lk.q();
				if (g2 != g6.c)
				{
					switch (lk.n())
					{
					case g3.a:
					case g3.b:
						this.a(nc, A_0);
						goto IL_2AA;
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
							base.a(this.o(), nc, A_0);
							nc.df(false);
							goto IL_2A8;
						}
					}
					this.a(nc, A_0);
					IL_2A8:
					IL_2AA:;
				}
				else
				{
					this.a(nc, A_0);
				}
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return nc;
		}

		// Token: 0x04000C29 RID: 3113
		private new o9 a = null;

		// Token: 0x04000C2A RID: 3114
		private o8 b = null;

		// Token: 0x04000C2B RID: 3115
		private bool c = true;
	}
}
