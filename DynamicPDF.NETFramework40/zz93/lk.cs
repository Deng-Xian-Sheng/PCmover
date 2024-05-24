using System;

namespace zz93
{
	// Token: 0x020001C0 RID: 448
	internal class lk : lj
	{
		// Token: 0x06001232 RID: 4658 RVA: 0x000D1194 File Offset: 0x000D0194
		internal lk()
		{
			this.h = new lf();
			this.i = new k8();
			this.j = new m2();
			this.k = new m8();
			this.l = null;
			this.n = g6.a;
			this.o = g7.a;
			this.s = null;
			this.p = g3.c;
			this.q = null;
			this.t = g9.a;
			this.ak = false;
			this.al = false;
			this.am = false;
			this.aa = i2.j;
			this.ab = i2.a;
			this.ac = i2.a;
			this.ad = i2.j;
			this.ae = i2.a;
			this.af = i2.a;
			this.ag = i2.j;
			this.ah = i2.j;
			this.ai = i2.j;
			this.aj = i2.j;
			this.an = false;
			this.ao = false;
			this.@as = false;
			this.at = false;
			this.u = null;
			this.v = null;
			this.ap = 0;
			this.ar = false;
			this.aq = false;
			this.au = false;
			this.av = false;
			this.aw = false;
			this.ax = false;
			this.ay = false;
			this.az = false;
			this.a0 = false;
			this.a3 = false;
			this.a2 = false;
			this.a1 = false;
		}

		// Token: 0x06001233 RID: 4659 RVA: 0x000D1308 File Offset: 0x000D0308
		internal override int[] ds()
		{
			return lj.d();
		}

		// Token: 0x06001234 RID: 4660 RVA: 0x000D1320 File Offset: 0x000D0320
		private new void a(fd[] A_0)
		{
			for (int i = 0; i < this.a4; i++)
			{
				fd fd = A_0[i];
				int num = fd.cv();
				if (num <= 7021096)
				{
					if (num != 136794)
					{
						if (num == 7021096)
						{
							hm hm = (hm)fd;
							if (hm.a().b())
							{
								this.ag = i2.j;
							}
							else if (hm.a().a())
							{
								this.ag = i2.b;
								this.b = new x5?(hm.a().c());
							}
							else
							{
								this.ag = hm.a().d();
								this.b = new x5?(hm.a().c());
								this.e = this.b;
							}
							if (this.o != g7.c)
							{
								this.o = g7.b;
							}
							else
							{
								this.o = g7.d;
							}
							this.aw = true;
						}
					}
					else
					{
						i0 i2 = (i0)fd;
						if (i2.a().b())
						{
							this.ai = i2.j;
							this.a = new x5?(i2.a().c());
						}
						else if (i2.a().a())
						{
							this.ai = i2.b;
							this.a = new x5?(i2.a().c());
						}
						else
						{
							this.ai = i2.a().d();
							this.a = new x5?(i2.a().c());
							this.d = this.a;
						}
						if (this.o != g7.b)
						{
							this.o = g7.c;
						}
						else
						{
							this.o = g7.d;
						}
						if (this.n == g6.b || this.n == g6.c)
						{
							this.au = true;
						}
						else
						{
							this.au = false;
						}
					}
				}
				else if (num != 426354259)
				{
					if (num == 448574430)
					{
						ib ib = (ib)fd;
						if (ib.a().b())
						{
							this.ah = i2.j;
						}
						else if (ib.a().a())
						{
							this.ah = i2.b;
							this.r = new x5?(ib.a().c());
						}
						else
						{
							this.ah = ib.a().d();
							this.r = new x5?(ib.a().c());
							this.f = this.r;
						}
						if (this.o != g7.c)
						{
							this.o = g7.b;
						}
						else
						{
							this.o = g7.d;
						}
						this.ax = true;
					}
				}
				else
				{
					fj fj = (fj)fd;
					if (fj.a().b())
					{
						this.aj = i2.j;
					}
					else if (fj.a().a())
					{
						this.aj = i2.b;
						this.m = new x5?(fj.a().c());
					}
					else
					{
						this.aj = fj.a().d();
						this.m = new x5?(fj.a().c());
						this.c = this.m;
					}
					if (this.o != g7.b)
					{
						this.o = g7.c;
					}
					else
					{
						this.o = g7.d;
					}
				}
			}
		}

		// Token: 0x06001235 RID: 4661 RVA: 0x000D16D0 File Offset: 0x000D06D0
		internal override void dt(int A_0, fd A_1)
		{
			if (A_0 <= 445130693)
			{
				if (A_0 <= 254664735)
				{
					if (A_0 <= 7021096)
					{
						if (A_0 != 136794)
						{
							if (A_0 == 7021096)
							{
								if (this.g == null)
								{
									this.g = new fd[4];
								}
								hm hm = (hm)A_1;
								this.g[this.a4++] = hm;
							}
						}
						else
						{
							if (this.g == null)
							{
								this.g = new fd[4];
							}
							i0 i = (i0)A_1;
							this.g[this.a4++] = i;
						}
					}
					else if (A_0 != 8714757)
					{
						if (A_0 != 148235845)
						{
							if (A_0 == 254664735)
							{
								this.ao = true;
								this.j.a(((hr)A_1).a());
							}
						}
						else
						{
							this.an = true;
							this.h.a(((fg)A_1).a());
						}
					}
					else if (A_1 != null)
					{
						this.l = new lr();
						this.l.a(((fm)A_1).a());
					}
				}
				else if (A_0 <= 426354259)
				{
					if (A_0 != 265770411)
					{
						if (A_0 == 426354259)
						{
							if (this.g == null)
							{
								this.g = new fd[4];
							}
							fj fj = (fj)A_1;
							this.g[this.a4++] = fj;
						}
					}
					else
					{
						this.@as = true;
						this.k.a(((hx)A_1).a());
					}
				}
				else if (A_0 != 436574770)
				{
					if (A_0 != 440052479)
					{
						if (A_0 == 445130693)
						{
							if (((hs)A_1).a() != null)
							{
								if (((hs)A_1).a().a())
								{
									this.af = i2.b;
									this.z = ((hs)A_1).a().c();
								}
								else
								{
									this.af = ((hs)A_1).a().d();
									this.z = ((hs)A_1).a().c();
								}
								if (!((hs)A_1).a().b())
								{
									this.a3 = true;
								}
							}
						}
					}
					else
					{
						this.n = ((h1)A_1).a().a();
						if (this.n != g6.a && this.g != null)
						{
							this.a(this.g);
						}
					}
				}
				else
				{
					this.p = ((hc)A_1).a().a();
					this.av = true;
				}
			}
			else if (A_0 <= 663362251)
			{
				if (A_0 <= 448574430)
				{
					if (A_0 != 445330501)
					{
						if (A_0 == 448574430)
						{
							if (this.g == null)
							{
								this.g = new fd[4];
							}
							ib ib = (ib)A_1;
							this.g[this.a4++] = ib;
						}
					}
					else
					{
						if (((hu)A_1).a() != null)
						{
							if (((hu)A_1).a().a())
							{
								this.ae = i2.b;
								this.y = ((hu)A_1).a().b();
							}
							else
							{
								this.ae = ((hu)A_1).a().c();
								this.y = ((hu)A_1).a().b();
							}
						}
						this.a2 = true;
					}
				}
				else if (A_0 != 503613957)
				{
					if (A_0 != 663292235)
					{
						if (A_0 == 663362251)
						{
							if (((ht)A_1).a() != null)
							{
								if (((ht)A_1).a().a())
								{
									this.ac = i2.b;
									this.x = ((ht)A_1).a().c();
								}
								else
								{
									this.ac = ((ht)A_1).a().d();
									this.x = ((ht)A_1).a().c();
								}
								if (!((ht)A_1).a().b())
								{
									this.a0 = true;
								}
							}
						}
					}
					else if (((hv)A_1).a() != null)
					{
						if (((hv)A_1).a().a())
						{
							this.ab = i2.b;
							this.w = ((hv)A_1).a().b();
						}
						else
						{
							this.ab = ((hv)A_1).a().c();
							this.w = ((hv)A_1).a().b();
						}
						this.a1 = true;
					}
				}
				else
				{
					this.q = new g0?(((fl)A_1).a().a());
				}
			}
			else if (A_0 <= 795562982)
			{
				if (A_0 != 679876343)
				{
					if (A_0 != 791474715)
					{
						if (A_0 == 795562982)
						{
							if (((ja)A_1).a() != null)
							{
								if (((ja)A_1).a().b())
								{
									this.aa = i2.j;
									this.am = true;
								}
								else if (((ja)A_1).a().a())
								{
									this.aa = i2.b;
									this.u = new x5?(((ja)A_1).a().c());
									this.al = true;
								}
								else
								{
									this.aa = ((ja)A_1).a().d();
									this.u = new x5?(((ja)A_1).a().c());
								}
							}
						}
					}
					else
					{
						hh hh = (hh)A_1;
						if (hh.a() != null)
						{
							if (hh.a().b())
							{
								this.ad = i2.j;
							}
							else if (hh.a().a())
							{
								this.ad = i2.b;
								this.v = new x5?(hh.a().c());
								this.ak = true;
							}
							else
							{
								this.v = new x5?(hh.a().c());
								this.ad = hh.a().d();
							}
						}
					}
				}
				else if (((gz)A_1).a() != null)
				{
					this.s = new g2?(((gz)A_1).a().a());
					this.at = true;
				}
			}
			else if (A_0 != 898954496)
			{
				if (A_0 != 1617181893)
				{
					if (A_0 == 1844443081)
					{
						this.t = ((i7)A_1).a().a();
					}
				}
				else
				{
					this.i.a(((fe)A_1).a());
				}
			}
			else if (this.n == g6.c || this.n == g6.b)
			{
				if (((jc)A_1).a().a())
				{
					this.ap = 0;
					this.ar = true;
					this.az = true;
					this.ay = false;
				}
				else
				{
					this.ap = ((jc)A_1).a().b();
					this.az = (this.ay = true);
				}
				this.aq = true;
			}
		}

		// Token: 0x06001236 RID: 4662 RVA: 0x000D1F44 File Offset: 0x000D0F44
		internal new bool a(lk A_0)
		{
			if (A_0 != null)
			{
				if (A_0.m() || A_0.q() == g6.c || A_0.d() || A_0.n() != g3.c || this.q() == g6.c || this.d() || this.m())
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06001237 RID: 4663 RVA: 0x000D1FAC File Offset: 0x000D0FAC
		internal new void a(g4 A_0, lk A_1)
		{
			switch (A_0)
			{
			case g4.b:
				if (!A_1.c().az() && this.v() == null)
				{
					this.e().b(A_1.e());
				}
				break;
			case g4.c:
				if (!A_1.c().ay())
				{
					this.e().a(A_1.e());
				}
				break;
			case g4.d:
				if (!A_1.c().az() && this.v() == null)
				{
					this.e().b(A_1.e());
				}
				if (!A_1.c().ay())
				{
					this.e().a(A_1.e());
				}
				break;
			}
		}

		// Token: 0x06001238 RID: 4664 RVA: 0x000D2094 File Offset: 0x000D1094
		internal new x5? a()
		{
			return this.a;
		}

		// Token: 0x06001239 RID: 4665 RVA: 0x000D20AC File Offset: 0x000D10AC
		internal new void a(x5? A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600123A RID: 4666 RVA: 0x000D20B8 File Offset: 0x000D10B8
		internal new x5? b()
		{
			return this.b;
		}

		// Token: 0x0600123B RID: 4667 RVA: 0x000D20D0 File Offset: 0x000D10D0
		internal new void b(x5? A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600123C RID: 4668 RVA: 0x000D20DC File Offset: 0x000D10DC
		internal new lf c()
		{
			return this.h;
		}

		// Token: 0x0600123D RID: 4669 RVA: 0x000D20F4 File Offset: 0x000D10F4
		internal new void a(lf A_0)
		{
			this.h = A_0;
		}

		// Token: 0x0600123E RID: 4670 RVA: 0x000D2100 File Offset: 0x000D1100
		internal new bool d()
		{
			return this.an;
		}

		// Token: 0x0600123F RID: 4671 RVA: 0x000D2118 File Offset: 0x000D1118
		internal new void a(bool A_0)
		{
			this.an = A_0;
		}

		// Token: 0x06001240 RID: 4672 RVA: 0x000D2124 File Offset: 0x000D1124
		internal new m2 e()
		{
			return this.j;
		}

		// Token: 0x06001241 RID: 4673 RVA: 0x000D213C File Offset: 0x000D113C
		internal new void a(m2 A_0)
		{
			this.j = A_0;
		}

		// Token: 0x06001242 RID: 4674 RVA: 0x000D2148 File Offset: 0x000D1148
		internal new m8 f()
		{
			return this.k;
		}

		// Token: 0x06001243 RID: 4675 RVA: 0x000D2160 File Offset: 0x000D1160
		internal new void a(m8 A_0)
		{
			this.k = A_0;
		}

		// Token: 0x06001244 RID: 4676 RVA: 0x000D216C File Offset: 0x000D116C
		internal new bool g()
		{
			return this.@as;
		}

		// Token: 0x06001245 RID: 4677 RVA: 0x000D2184 File Offset: 0x000D1184
		internal new void b(bool A_0)
		{
			this.@as = A_0;
		}

		// Token: 0x06001246 RID: 4678 RVA: 0x000D2190 File Offset: 0x000D1190
		internal new x5? h()
		{
			return this.m;
		}

		// Token: 0x06001247 RID: 4679 RVA: 0x000D21A8 File Offset: 0x000D11A8
		internal new void c(x5? A_0)
		{
			this.m = A_0;
		}

		// Token: 0x06001248 RID: 4680 RVA: 0x000D21B4 File Offset: 0x000D11B4
		internal new x5? i()
		{
			return this.c;
		}

		// Token: 0x06001249 RID: 4681 RVA: 0x000D21CC File Offset: 0x000D11CC
		internal new void d(x5? A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600124A RID: 4682 RVA: 0x000D21D8 File Offset: 0x000D11D8
		internal new x5? j()
		{
			return this.d;
		}

		// Token: 0x0600124B RID: 4683 RVA: 0x000D21F0 File Offset: 0x000D11F0
		internal new void e(x5? A_0)
		{
			this.d = A_0;
		}

		// Token: 0x0600124C RID: 4684 RVA: 0x000D21FC File Offset: 0x000D11FC
		internal new x5? k()
		{
			return this.e;
		}

		// Token: 0x0600124D RID: 4685 RVA: 0x000D2214 File Offset: 0x000D1214
		internal new void f(x5? A_0)
		{
			this.e = A_0;
		}

		// Token: 0x0600124E RID: 4686 RVA: 0x000D2220 File Offset: 0x000D1220
		internal new x5? l()
		{
			return this.f;
		}

		// Token: 0x0600124F RID: 4687 RVA: 0x000D2238 File Offset: 0x000D1238
		internal new void g(x5? A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06001250 RID: 4688 RVA: 0x000D2244 File Offset: 0x000D1244
		internal new bool m()
		{
			return this.av;
		}

		// Token: 0x06001251 RID: 4689 RVA: 0x000D225C File Offset: 0x000D125C
		internal new void c(bool A_0)
		{
			this.av = A_0;
		}

		// Token: 0x06001252 RID: 4690 RVA: 0x000D2268 File Offset: 0x000D1268
		internal new g3 n()
		{
			return this.p;
		}

		// Token: 0x06001253 RID: 4691 RVA: 0x000D2280 File Offset: 0x000D1280
		internal new void a(g3 A_0)
		{
			this.p = A_0;
		}

		// Token: 0x06001254 RID: 4692 RVA: 0x000D228C File Offset: 0x000D128C
		internal new g0? o()
		{
			return this.q;
		}

		// Token: 0x06001255 RID: 4693 RVA: 0x000D22A4 File Offset: 0x000D12A4
		internal new void a(g0? A_0)
		{
			this.q = A_0;
		}

		// Token: 0x06001256 RID: 4694 RVA: 0x000D22B0 File Offset: 0x000D12B0
		internal new lr p()
		{
			return this.l;
		}

		// Token: 0x06001257 RID: 4695 RVA: 0x000D22C8 File Offset: 0x000D12C8
		internal new void a(lr A_0)
		{
			this.l = A_0;
		}

		// Token: 0x06001258 RID: 4696 RVA: 0x000D22D4 File Offset: 0x000D12D4
		internal new g6 q()
		{
			return this.n;
		}

		// Token: 0x06001259 RID: 4697 RVA: 0x000D22EC File Offset: 0x000D12EC
		internal new void a(g6 A_0)
		{
			this.n = A_0;
		}

		// Token: 0x0600125A RID: 4698 RVA: 0x000D22F8 File Offset: 0x000D12F8
		internal new g7 r()
		{
			return this.o;
		}

		// Token: 0x0600125B RID: 4699 RVA: 0x000D2310 File Offset: 0x000D1310
		internal new void a(g7 A_0)
		{
			this.o = A_0;
		}

		// Token: 0x0600125C RID: 4700 RVA: 0x000D231C File Offset: 0x000D131C
		internal new x5? s()
		{
			return this.r;
		}

		// Token: 0x0600125D RID: 4701 RVA: 0x000D2334 File Offset: 0x000D1334
		internal new void h(x5? A_0)
		{
			this.r = A_0;
		}

		// Token: 0x0600125E RID: 4702 RVA: 0x000D2340 File Offset: 0x000D1340
		internal new g2? t()
		{
			return this.s;
		}

		// Token: 0x0600125F RID: 4703 RVA: 0x000D2358 File Offset: 0x000D1358
		internal new void a(g2? A_0)
		{
			this.s = A_0;
		}

		// Token: 0x06001260 RID: 4704 RVA: 0x000D2364 File Offset: 0x000D1364
		internal new bool u()
		{
			return this.at;
		}

		// Token: 0x06001261 RID: 4705 RVA: 0x000D237C File Offset: 0x000D137C
		internal new void d(bool A_0)
		{
			this.at = A_0;
		}

		// Token: 0x06001262 RID: 4706 RVA: 0x000D2388 File Offset: 0x000D1388
		internal new x5? v()
		{
			return this.v;
		}

		// Token: 0x06001263 RID: 4707 RVA: 0x000D23A0 File Offset: 0x000D13A0
		internal new void i(x5? A_0)
		{
			this.v = A_0;
		}

		// Token: 0x06001264 RID: 4708 RVA: 0x000D23AC File Offset: 0x000D13AC
		internal new int w()
		{
			return this.ap;
		}

		// Token: 0x06001265 RID: 4709 RVA: 0x000D23C4 File Offset: 0x000D13C4
		internal new void a(int A_0)
		{
			this.ap = A_0;
		}

		// Token: 0x06001266 RID: 4710 RVA: 0x000D23D0 File Offset: 0x000D13D0
		internal new bool x()
		{
			return this.au;
		}

		// Token: 0x06001267 RID: 4711 RVA: 0x000D23E8 File Offset: 0x000D13E8
		internal new void e(bool A_0)
		{
			this.au = A_0;
		}

		// Token: 0x06001268 RID: 4712 RVA: 0x000D23F4 File Offset: 0x000D13F4
		internal new bool y()
		{
			return this.aw;
		}

		// Token: 0x06001269 RID: 4713 RVA: 0x000D240C File Offset: 0x000D140C
		internal new void f(bool A_0)
		{
			this.aw = A_0;
		}

		// Token: 0x0600126A RID: 4714 RVA: 0x000D2418 File Offset: 0x000D1418
		internal new bool z()
		{
			return this.ax;
		}

		// Token: 0x0600126B RID: 4715 RVA: 0x000D2430 File Offset: 0x000D1430
		internal new void g(bool A_0)
		{
			this.ax = A_0;
		}

		// Token: 0x0600126C RID: 4716 RVA: 0x000D243C File Offset: 0x000D143C
		internal new bool aa()
		{
			return this.aq;
		}

		// Token: 0x0600126D RID: 4717 RVA: 0x000D2454 File Offset: 0x000D1454
		internal new void h(bool A_0)
		{
			this.aq = A_0;
		}

		// Token: 0x0600126E RID: 4718 RVA: 0x000D2460 File Offset: 0x000D1460
		internal new bool ab()
		{
			return this.ar;
		}

		// Token: 0x0600126F RID: 4719 RVA: 0x000D2478 File Offset: 0x000D1478
		internal new void i(bool A_0)
		{
			this.ar = A_0;
		}

		// Token: 0x06001270 RID: 4720 RVA: 0x000D2484 File Offset: 0x000D1484
		internal new bool ac()
		{
			return this.ak;
		}

		// Token: 0x06001271 RID: 4721 RVA: 0x000D249C File Offset: 0x000D149C
		internal new void j(bool A_0)
		{
			this.ak = A_0;
		}

		// Token: 0x06001272 RID: 4722 RVA: 0x000D24A8 File Offset: 0x000D14A8
		internal new bool ad()
		{
			return this.a0;
		}

		// Token: 0x06001273 RID: 4723 RVA: 0x000D24C0 File Offset: 0x000D14C0
		internal new void k(bool A_0)
		{
			this.a0 = A_0;
		}

		// Token: 0x06001274 RID: 4724 RVA: 0x000D24CC File Offset: 0x000D14CC
		internal new bool ae()
		{
			return this.a1;
		}

		// Token: 0x06001275 RID: 4725 RVA: 0x000D24E4 File Offset: 0x000D14E4
		internal new void l(bool A_0)
		{
			this.a1 = A_0;
		}

		// Token: 0x06001276 RID: 4726 RVA: 0x000D24F0 File Offset: 0x000D14F0
		internal new bool af()
		{
			return this.a3;
		}

		// Token: 0x06001277 RID: 4727 RVA: 0x000D2508 File Offset: 0x000D1508
		internal new void m(bool A_0)
		{
			this.a3 = A_0;
		}

		// Token: 0x06001278 RID: 4728 RVA: 0x000D2514 File Offset: 0x000D1514
		internal new bool ag()
		{
			return this.a2;
		}

		// Token: 0x06001279 RID: 4729 RVA: 0x000D252C File Offset: 0x000D152C
		internal new void n(bool A_0)
		{
			this.a2 = A_0;
		}

		// Token: 0x0600127A RID: 4730 RVA: 0x000D2538 File Offset: 0x000D1538
		internal new i2 ah()
		{
			return this.ad;
		}

		// Token: 0x0600127B RID: 4731 RVA: 0x000D2550 File Offset: 0x000D1550
		internal new void a(i2 A_0)
		{
			this.ad = A_0;
		}

		// Token: 0x0600127C RID: 4732 RVA: 0x000D255C File Offset: 0x000D155C
		internal new x5 ai()
		{
			return this.z;
		}

		// Token: 0x0600127D RID: 4733 RVA: 0x000D2574 File Offset: 0x000D1574
		internal new void a(x5 A_0)
		{
			this.z = A_0;
		}

		// Token: 0x0600127E RID: 4734 RVA: 0x000D2580 File Offset: 0x000D1580
		internal new i2 aj()
		{
			return this.af;
		}

		// Token: 0x0600127F RID: 4735 RVA: 0x000D2598 File Offset: 0x000D1598
		internal new void b(i2 A_0)
		{
			this.af = A_0;
		}

		// Token: 0x06001280 RID: 4736 RVA: 0x000D25A4 File Offset: 0x000D15A4
		internal new x5 ak()
		{
			return this.y;
		}

		// Token: 0x06001281 RID: 4737 RVA: 0x000D25BC File Offset: 0x000D15BC
		internal new void b(x5 A_0)
		{
			this.y = A_0;
		}

		// Token: 0x06001282 RID: 4738 RVA: 0x000D25C8 File Offset: 0x000D15C8
		internal new i2 al()
		{
			return this.ae;
		}

		// Token: 0x06001283 RID: 4739 RVA: 0x000D25E0 File Offset: 0x000D15E0
		internal new void c(i2 A_0)
		{
			this.ae = A_0;
		}

		// Token: 0x06001284 RID: 4740 RVA: 0x000D25EC File Offset: 0x000D15EC
		internal new x5? am()
		{
			return this.u;
		}

		// Token: 0x06001285 RID: 4741 RVA: 0x000D2604 File Offset: 0x000D1604
		internal new void j(x5? A_0)
		{
			this.u = A_0;
		}

		// Token: 0x06001286 RID: 4742 RVA: 0x000D2610 File Offset: 0x000D1610
		internal new bool an()
		{
			return this.am;
		}

		// Token: 0x06001287 RID: 4743 RVA: 0x000D2628 File Offset: 0x000D1628
		internal new bool ao()
		{
			return this.al;
		}

		// Token: 0x06001288 RID: 4744 RVA: 0x000D2640 File Offset: 0x000D1640
		internal new void o(bool A_0)
		{
			this.al = A_0;
		}

		// Token: 0x06001289 RID: 4745 RVA: 0x000D264C File Offset: 0x000D164C
		internal new i2 ap()
		{
			return this.aa;
		}

		// Token: 0x0600128A RID: 4746 RVA: 0x000D2664 File Offset: 0x000D1664
		internal new void d(i2 A_0)
		{
			this.aa = A_0;
		}

		// Token: 0x0600128B RID: 4747 RVA: 0x000D2670 File Offset: 0x000D1670
		internal new x5 aq()
		{
			return this.x;
		}

		// Token: 0x0600128C RID: 4748 RVA: 0x000D2688 File Offset: 0x000D1688
		internal new void c(x5 A_0)
		{
			this.x = A_0;
		}

		// Token: 0x0600128D RID: 4749 RVA: 0x000D2694 File Offset: 0x000D1694
		internal new i2 ar()
		{
			return this.ac;
		}

		// Token: 0x0600128E RID: 4750 RVA: 0x000D26AC File Offset: 0x000D16AC
		internal new void e(i2 A_0)
		{
			this.ac = A_0;
		}

		// Token: 0x0600128F RID: 4751 RVA: 0x000D26B8 File Offset: 0x000D16B8
		internal new x5 @as()
		{
			return this.w;
		}

		// Token: 0x06001290 RID: 4752 RVA: 0x000D26D0 File Offset: 0x000D16D0
		internal new void d(x5 A_0)
		{
			this.w = A_0;
		}

		// Token: 0x06001291 RID: 4753 RVA: 0x000D26DC File Offset: 0x000D16DC
		internal new i2 at()
		{
			return this.ab;
		}

		// Token: 0x06001292 RID: 4754 RVA: 0x000D26F4 File Offset: 0x000D16F4
		internal new void f(i2 A_0)
		{
			this.ab = A_0;
		}

		// Token: 0x06001293 RID: 4755 RVA: 0x000D2700 File Offset: 0x000D1700
		internal new i2 au()
		{
			return this.ai;
		}

		// Token: 0x06001294 RID: 4756 RVA: 0x000D2718 File Offset: 0x000D1718
		internal new void g(i2 A_0)
		{
			this.ai = A_0;
		}

		// Token: 0x06001295 RID: 4757 RVA: 0x000D2724 File Offset: 0x000D1724
		internal new i2 av()
		{
			return this.ah;
		}

		// Token: 0x06001296 RID: 4758 RVA: 0x000D273C File Offset: 0x000D173C
		internal new void h(i2 A_0)
		{
			this.ah = A_0;
		}

		// Token: 0x06001297 RID: 4759 RVA: 0x000D2748 File Offset: 0x000D1748
		internal new i2 aw()
		{
			return this.aj;
		}

		// Token: 0x06001298 RID: 4760 RVA: 0x000D2760 File Offset: 0x000D1760
		internal new void i(i2 A_0)
		{
			this.aj = A_0;
		}

		// Token: 0x06001299 RID: 4761 RVA: 0x000D276C File Offset: 0x000D176C
		internal new i2 ax()
		{
			return this.ag;
		}

		// Token: 0x0600129A RID: 4762 RVA: 0x000D2784 File Offset: 0x000D1784
		internal new void j(i2 A_0)
		{
			this.ag = A_0;
		}

		// Token: 0x0600129B RID: 4763 RVA: 0x000D2790 File Offset: 0x000D1790
		internal new k8 ay()
		{
			return this.i;
		}

		// Token: 0x0600129C RID: 4764 RVA: 0x000D27A8 File Offset: 0x000D17A8
		internal new void a(k8 A_0)
		{
			this.i = A_0;
		}

		// Token: 0x0600129D RID: 4765 RVA: 0x000D27B4 File Offset: 0x000D17B4
		internal new g9 az()
		{
			return this.t;
		}

		// Token: 0x0600129E RID: 4766 RVA: 0x000D27CC File Offset: 0x000D17CC
		internal new void a(g9 A_0)
		{
			this.t = A_0;
		}

		// Token: 0x0600129F RID: 4767 RVA: 0x000D27D8 File Offset: 0x000D17D8
		internal new x5 a0()
		{
			x5 x = x5.c(this.j.b(), x5.c()) ? x5.f(this.j.b(), this.k.b()) : this.k.b();
			x5 result;
			if (this.h != null)
			{
				result = x5.f(this.h.r(), x);
			}
			else
			{
				result = x;
			}
			return result;
		}

		// Token: 0x060012A0 RID: 4768 RVA: 0x000D2850 File Offset: 0x000D1850
		internal new x5 a1()
		{
			x5 x = x5.c(this.j.d(), x5.c()) ? x5.f(this.j.d(), this.k.d()) : this.k.d();
			x5 result;
			if (this.h != null)
			{
				result = x5.f(this.h.n(), x);
			}
			else
			{
				result = x;
			}
			return result;
		}

		// Token: 0x060012A1 RID: 4769 RVA: 0x000D28C8 File Offset: 0x000D18C8
		internal new x5 a2()
		{
			x5 x = this.j.a();
			if (this.g() && this.f().k())
			{
				x = x5.f(x, this.k.a());
			}
			x5 result;
			if (this.h != null)
			{
				result = x5.f(this.h.f(), x);
			}
			else
			{
				result = x;
			}
			return result;
		}

		// Token: 0x060012A2 RID: 4770 RVA: 0x000D2938 File Offset: 0x000D1938
		internal new x5 a3()
		{
			x5 x = this.j.c();
			if (this.g() && this.f().l())
			{
				x = x5.f(x, this.k.c());
			}
			x5 result;
			if (this.h != null)
			{
				result = x5.f(this.h.j(), x);
			}
			else
			{
				result = x;
			}
			return result;
		}

		// Token: 0x060012A3 RID: 4771 RVA: 0x000D29A8 File Offset: 0x000D19A8
		internal new x5 a4()
		{
			x5 x = this.j.c();
			x = x5.f(x, this.g() ? this.k.c() : x5.c());
			x5 result;
			if (this.h != null)
			{
				result = x5.f(this.h.y(), x);
			}
			else
			{
				result = x;
			}
			return result;
		}

		// Token: 0x060012A4 RID: 4772 RVA: 0x000D2A0C File Offset: 0x000D1A0C
		internal new x5 a5()
		{
			x5 x = this.j.a();
			x = x5.f(x, this.g() ? this.k.a() : x5.c());
			x5 result;
			if (this.h != null)
			{
				result = x5.f(this.h.v(), x);
			}
			else
			{
				result = x;
			}
			return result;
		}

		// Token: 0x060012A5 RID: 4773 RVA: 0x000D2A70 File Offset: 0x000D1A70
		internal new bool a6()
		{
			bool flag;
			if (this.n() != g3.c)
			{
				if (this.u != null)
				{
					x5 value = this.u.Value;
					flag = (1 == 0);
				}
				else
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			return !flag;
		}

		// Token: 0x060012A6 RID: 4774 RVA: 0x000D2ABC File Offset: 0x000D1ABC
		internal new bool a7()
		{
			return this.ao;
		}

		// Token: 0x060012A7 RID: 4775 RVA: 0x000D2AD4 File Offset: 0x000D1AD4
		internal new void p(bool A_0)
		{
			this.ao = A_0;
		}

		// Token: 0x060012A8 RID: 4776 RVA: 0x000D2AE0 File Offset: 0x000D1AE0
		internal new bool a8()
		{
			return this.ay;
		}

		// Token: 0x060012A9 RID: 4777 RVA: 0x000D2AF8 File Offset: 0x000D1AF8
		internal new bool a9()
		{
			return this.az;
		}

		// Token: 0x060012AA RID: 4778 RVA: 0x000D2B10 File Offset: 0x000D1B10
		internal override lj du()
		{
			lk lk = new lk();
			lk.a(this.c().be());
			lk.a(this.d());
			lk.a(this.ay().l());
			lk.a(this.e().t());
			lk.p(this.a7());
			lk.a(this.f().m());
			lk.b(this.g());
			lk.a(this.p());
			lk.a(this.q());
			lk.a(this.t());
			lk.d(this.u());
			lk.a(this.n());
			lk.a(this.az());
			lk.a(this.o());
			lk.i(this.v());
			lk.a(this.ah());
			lk.j(this.ac());
			lk.b(this.b());
			lk.j(this.ax());
			lk.aw = this.aw;
			lk.h(this.s());
			lk.h(this.av());
			lk.ax = this.ax;
			lk.c(this.h());
			lk.i(this.aw());
			lk.a(this.a());
			lk.g(this.au());
			lk.j(this.am());
			lk.d(this.ap());
			lk.o(this.ao());
			lk.a(this.w());
			return lk;
		}

		// Token: 0x040008EA RID: 2282
		private new x5? a;

		// Token: 0x040008EB RID: 2283
		private new x5? b;

		// Token: 0x040008EC RID: 2284
		private new x5? c;

		// Token: 0x040008ED RID: 2285
		private new x5? d;

		// Token: 0x040008EE RID: 2286
		private new x5? e;

		// Token: 0x040008EF RID: 2287
		private new x5? f;

		// Token: 0x040008F0 RID: 2288
		private new fd[] g;

		// Token: 0x040008F1 RID: 2289
		private new lf h;

		// Token: 0x040008F2 RID: 2290
		private new k8 i;

		// Token: 0x040008F3 RID: 2291
		private new m2 j;

		// Token: 0x040008F4 RID: 2292
		private new m8 k;

		// Token: 0x040008F5 RID: 2293
		private new lr l;

		// Token: 0x040008F6 RID: 2294
		private new x5? m;

		// Token: 0x040008F7 RID: 2295
		private new g6 n;

		// Token: 0x040008F8 RID: 2296
		private new g7 o;

		// Token: 0x040008F9 RID: 2297
		private new g3 p;

		// Token: 0x040008FA RID: 2298
		private new g0? q;

		// Token: 0x040008FB RID: 2299
		private new x5? r;

		// Token: 0x040008FC RID: 2300
		private new g2? s;

		// Token: 0x040008FD RID: 2301
		private new g9 t;

		// Token: 0x040008FE RID: 2302
		private new x5? u;

		// Token: 0x040008FF RID: 2303
		private new x5? v;

		// Token: 0x04000900 RID: 2304
		private new x5 w;

		// Token: 0x04000901 RID: 2305
		private new x5 x;

		// Token: 0x04000902 RID: 2306
		private new x5 y;

		// Token: 0x04000903 RID: 2307
		private new x5 z;

		// Token: 0x04000904 RID: 2308
		private new i2 aa;

		// Token: 0x04000905 RID: 2309
		private new i2 ab;

		// Token: 0x04000906 RID: 2310
		private new i2 ac;

		// Token: 0x04000907 RID: 2311
		private new i2 ad;

		// Token: 0x04000908 RID: 2312
		private new i2 ae;

		// Token: 0x04000909 RID: 2313
		private new i2 af;

		// Token: 0x0400090A RID: 2314
		private new i2 ag;

		// Token: 0x0400090B RID: 2315
		private new i2 ah;

		// Token: 0x0400090C RID: 2316
		private new i2 ai;

		// Token: 0x0400090D RID: 2317
		private new i2 aj;

		// Token: 0x0400090E RID: 2318
		private new bool ak;

		// Token: 0x0400090F RID: 2319
		private new bool al;

		// Token: 0x04000910 RID: 2320
		private new bool am;

		// Token: 0x04000911 RID: 2321
		private new bool an;

		// Token: 0x04000912 RID: 2322
		private new bool ao;

		// Token: 0x04000913 RID: 2323
		private new int ap;

		// Token: 0x04000914 RID: 2324
		private new bool aq;

		// Token: 0x04000915 RID: 2325
		private new bool ar;

		// Token: 0x04000916 RID: 2326
		private new bool @as;

		// Token: 0x04000917 RID: 2327
		private new bool at;

		// Token: 0x04000918 RID: 2328
		private new bool au;

		// Token: 0x04000919 RID: 2329
		private new bool av;

		// Token: 0x0400091A RID: 2330
		private new bool aw;

		// Token: 0x0400091B RID: 2331
		private new bool ax;

		// Token: 0x0400091C RID: 2332
		private new bool ay;

		// Token: 0x0400091D RID: 2333
		private new bool az;

		// Token: 0x0400091E RID: 2334
		private new bool a0;

		// Token: 0x0400091F RID: 2335
		private new bool a1;

		// Token: 0x04000920 RID: 2336
		private new bool a2;

		// Token: 0x04000921 RID: 2337
		private new bool a3;

		// Token: 0x04000922 RID: 2338
		private new int a4 = 0;
	}
}
