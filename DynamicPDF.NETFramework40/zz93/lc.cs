using System;
using System.Collections.Generic;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001B8 RID: 440
	internal class lc : k0
	{
		// Token: 0x06001108 RID: 4360 RVA: 0x000C2854 File Offset: 0x000C1854
		internal override ld dq()
		{
			return this.c;
		}

		// Token: 0x06001109 RID: 4361 RVA: 0x000C286C File Offset: 0x000C186C
		internal override void dr(ld A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600110A RID: 4362 RVA: 0x000C2878 File Offset: 0x000C1878
		internal lc a()
		{
			return this.a;
		}

		// Token: 0x0600110B RID: 4363 RVA: 0x000C2890 File Offset: 0x000C1890
		internal override lj db()
		{
			return this.b;
		}

		// Token: 0x0600110C RID: 4364 RVA: 0x000C28A8 File Offset: 0x000C18A8
		internal override void dc(lj A_0)
		{
			this.b = (n5)A_0;
		}

		// Token: 0x0600110D RID: 4365 RVA: 0x000C28B8 File Offset: 0x000C18B8
		internal override bool de()
		{
			return this.d;
		}

		// Token: 0x0600110E RID: 4366 RVA: 0x000C28D0 File Offset: 0x000C18D0
		internal override void df(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x0600110F RID: 4367 RVA: 0x000C28DC File Offset: 0x000C18DC
		internal bool b()
		{
			return this.e;
		}

		// Token: 0x06001110 RID: 4368 RVA: 0x000C28F4 File Offset: 0x000C18F4
		internal void a(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06001111 RID: 4369 RVA: 0x000C2900 File Offset: 0x000C1900
		internal ij c()
		{
			return this.f;
		}

		// Token: 0x06001112 RID: 4370 RVA: 0x000C2918 File Offset: 0x000C1918
		internal void a(ij A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06001113 RID: 4371 RVA: 0x000C2924 File Offset: 0x000C1924
		internal override int dg()
		{
			return 11228793;
		}

		// Token: 0x06001114 RID: 4372 RVA: 0x000C293C File Offset: 0x000C193C
		internal override k0 dd()
		{
			return new lc();
		}

		// Token: 0x06001115 RID: 4373 RVA: 0x000C2954 File Offset: 0x000C1954
		private lc a(x5 A_0, x5 A_1)
		{
			this.a = null;
			x5 a_ = x5.c();
			ni.a().d();
			if (base.o() != null)
			{
				if (base.o().c().a().l() != null)
				{
					base.o().c().a().c(base.o().c().a().l().a());
					for (int i = base.o().f(); i > 0; i--)
					{
						ms ms = base.o().b(i - 1);
						if (ms != null && ms.l() != null)
						{
							if (base.n() == null)
							{
								base.c(new mt(ms));
							}
							else
							{
								base.n().d(ms);
							}
						}
					}
				}
			}
			if (base.n() != null)
			{
				this.a(this.b.n().a());
				base.n().a(null);
				base.n().a(A_0, A_1, this, a_);
				this.e = true;
				base.m(x5.f(base.n().h(), base.ae().l()));
				x5 a_2 = x5.c();
				x5 a_3 = x5.f(base.ae().l(), base.ae().m());
				A_1 = x5.f(A_1, base.ae().l());
				if (base.c5().v() != null)
				{
					if (x5.c(x5.f(base.c5().v().Value, a_3), A_1))
					{
						a_2 = x5.e(base.c5().v().Value, x5.e(A_1, base.ae().l()));
						base.m(A_1);
						base.g(true);
					}
					else
					{
						base.m(x5.f(base.c5().v().Value, a_3));
					}
					if (base.n().e() != null)
					{
						this.a = this.a(a_2);
						this.a.c(base.n().e());
						base.ae().c(this.a);
						if (x5.b(a_2, x5.c()))
						{
							this.a.g(true);
							this.a.d(true);
							this.a.e(true);
						}
					}
					else if (x5.c(a_2, x5.c()))
					{
						this.a = this.a(a_2);
						this.a.c(new mt(new ms(null)));
					}
				}
				else if (base.n().e() != null)
				{
					this.a = this.a(a_2);
					this.a.c(base.n().e());
					base.ae().c(this.a);
					base.g(true);
				}
				else
				{
					base.m(x5.f(base.ar(), base.ae().m()));
				}
			}
			else
			{
				base.m(base.ab());
			}
			if (this.a != null)
			{
				this.a.dr(this.c.f());
			}
			return (this.a != null) ? this.a : null;
		}

		// Token: 0x06001116 RID: 4374 RVA: 0x000C2D38 File Offset: 0x000C1D38
		private lc a(x5 A_0)
		{
			lc lc = (lc)this.dd();
			lc.dc(this.b);
			lc.a(base.c5());
			if (x5.g(A_0, x5.c()))
			{
				lc.c5().i(new x5?(A_0));
			}
			else
			{
				lc.c5().i(null);
			}
			lc.b(base.w());
			lc.f(true);
			return lc;
		}

		// Token: 0x06001117 RID: 4375 RVA: 0x000C2DC4 File Offset: 0x000C1DC4
		private void a(PageWriter A_0, x5 A_1, x5 A_2, List<li> A_3, int A_4, int A_5)
		{
			x5 x = A_2;
			x5 x2 = A_1;
			while (A_4 < A_5)
			{
				if (!A_3[A_4].a().ct())
				{
					kz kz = A_3[A_4].a();
					bool flag = !kz.d7();
					switch (kz.c5().q())
					{
					case g6.b:
					{
						this.a(kz);
						x5 a_ = (kz.c5().b() != null) ? kz.c5().b().Value : x5.c();
						x5 a_2 = (kz.c5().a() != null) ? kz.c5().a().Value : x5.c();
						if (kz.dr() != null)
						{
							x2 = kz.dr().an();
							x = kz.dr().ao();
						}
						x2 = x5.f(x2, x5.f(kz.an(), a_));
						x = x5.f(x, x5.f(kz.ao(), a_2));
						break;
					}
					case g6.c:
						switch (kz.c5().r())
						{
						case g7.a:
						case g7.b:
							x2 = x5.f(x2, this.b(kz, x2, false));
							x = x5.f(x, this.a(kz, x, flag));
							if (kz.dg() != 46415)
							{
								x = x5.f(x, x5.f(kz.dr().ao(), kz.ao()));
							}
							else
							{
								x = x5.f(x, x5.f(kz.ao(), kz.ar()));
							}
							break;
						case g7.c:
						case g7.d:
							if (flag)
							{
								x2 = x5.f(x2, kz.dr().an());
								x = x5.f(x, kz.dr().ao());
							}
							x2 = x5.f(x2, this.b(kz, x2, flag));
							if (flag)
							{
								x = this.a(kz, x, flag);
							}
							else
							{
								x = x5.f(x, this.a(kz, x, flag));
							}
							break;
						}
						break;
					}
					kz.dk(A_0, x2, x);
					x = A_2;
					x2 = A_1;
				}
				A_4++;
			}
		}

		// Token: 0x06001118 RID: 4376 RVA: 0x000C302C File Offset: 0x000C202C
		private void a(kz A_0)
		{
			if (A_0.c5().h() != null)
			{
				lk lk = A_0.c5();
				x5? x = A_0.c5().h();
				lk.a((x != null) ? new x5?(x5.d(x.GetValueOrDefault())) : null);
			}
			if (A_0.c5().s() != null)
			{
				lk lk2 = A_0.c5();
				x5? x = A_0.c5().s();
				lk2.b((x != null) ? new x5?(x5.d(x.GetValueOrDefault())) : null);
			}
		}

		// Token: 0x06001119 RID: 4377 RVA: 0x000C30F0 File Offset: 0x000C20F0
		private x5 b(kz A_0, x5 A_1, bool A_2)
		{
			x5 x = x5.c();
			lk lk = A_0.c5();
			if (lk.b() != null && x5.c(lk.b().Value, x5.c()))
			{
				x = m4.a(x5.b(lk.b().Value), x5.b(base.aq()), lk.ax());
			}
			else if (lk.s() != null && x5.c(lk.s().Value, x5.c()))
			{
				x = x5.e(base.aq(), x5.f(A_0.aq(), m4.a(x5.b(lk.s().Value), x5.b(base.aq()), lk.av())));
			}
			if (A_2)
			{
				A_1 = x5.f(A_1, x);
			}
			else
			{
				A_1 = x;
			}
			return A_1;
		}

		// Token: 0x0600111A RID: 4378 RVA: 0x000C3208 File Offset: 0x000C2208
		private x5 a(kz A_0, x5 A_1, bool A_2)
		{
			x5 x = x5.c();
			lk lk = A_0.c5();
			x5 a_ = base.ar();
			if (lk.a() != null)
			{
				x = m4.a(x5.b(lk.a().Value), x5.b(a_), lk.au());
			}
			else if (lk.h() != null)
			{
				a_ = base.bl();
				x = x5.e(a_, x5.f(A_0.ar(), m4.a(x5.b(lk.h().Value), x5.b(a_), lk.aw())));
			}
			if (A_2)
			{
				A_1 = x5.f(A_1, x);
			}
			else
			{
				A_1 = x;
			}
			return A_1;
		}

		// Token: 0x0600111B RID: 4379 RVA: 0x000C32E8 File Offset: 0x000C22E8
		private void a(PageWriter A_0, x5 A_1, x5 A_2)
		{
			if (base.bv() != null)
			{
				List<li> list = base.bv().b();
				for (int i = 0; i < list.Count; i++)
				{
					kz kz = list[i].a();
					if (!kz.cu())
					{
						x5 a_;
						x5 a_2;
						if (kz.dg() == 46415)
						{
							a_ = x5.f(kz.ao(), kz.ar());
							a_2 = x5.f(A_1, kz.an());
						}
						else
						{
							a_ = kz.ao();
							a_2 = x5.f(A_1, kz.an());
						}
						kz.dk(A_0, a_2, a_);
					}
				}
			}
		}

		// Token: 0x0600111C RID: 4380 RVA: 0x000C33BC File Offset: 0x000C23BC
		internal override kz dj(x5 A_0, x5 A_1)
		{
			base.l(A_0);
			base.m(A_1);
			base.ah(A_0);
			base.al(A_0);
			base.ak(A_1);
			x5 a_ = x5.c();
			x5 a_2 = x5.c();
			base.ai(base.ar());
			if (this.bv() == null)
			{
				this.a(new ld());
			}
			A_0 = base.aq();
			A_1 = base.ar();
			base.b(A_0, A_1);
			a_ = x5.e(A_1, base.ae().l());
			a_2 = base.aq();
			base.ah(base.aq());
			base.a(base.z());
			return this.a(a_2, a_);
		}

		// Token: 0x0600111D RID: 4381 RVA: 0x000C3484 File Offset: 0x000C2484
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c5().c().g(base.s());
			base.c5().c().h(base.t());
			base.c5().c().e(base.r());
			base.c5().c().f(base.q());
			A_0.Write_q_(true);
			A_0.Write_re(x5.b(A_1), x5.b(A_2), x5.b(base.bi()), x5.b(base.bl()));
			A_0.Write_W();
			A_0.Write_n();
			x5 x = x5.c();
			A_1 = x5.f(A_1, base.c5().e().d());
			if (!base.s() && !this.@do())
			{
				A_2 = x5.f(A_2, base.c5().e().a());
				x = base.c5().e().a();
			}
			if (!base.t())
			{
				x = x5.f(x, base.c5().e().c());
			}
			base.a(A_0, A_1, A_2, base.bi(), x5.e(base.bj(), x));
			List<li> list = base.a(this.dq().b());
			int num = base.b(list);
			if (base.c5().q() != g6.c && base.c5().q() != g6.b)
			{
				if (num > 0)
				{
					this.a(A_0, A_1, A_2, list, 0, num);
				}
			}
			x5 a_2;
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
						x5? x2 = base.c5().s();
						x5 a_ = x5.c();
						flag = (x2 != null && !x5.g(x2.GetValueOrDefault(), a_));
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
						x5? x2 = base.c5().h();
						x5 a_ = x5.c();
						flag2 = (x2 != null && !x5.g(x2.GetValueOrDefault(), a_));
					}
					else
					{
						flag2 = true;
					}
					if (!flag2)
					{
						A_2 = x5.e(A_2, base.c5().h().Value);
					}
				}
				break;
			case g6.c:
				if (base.c5().b() != null)
				{
					A_1 = x5.f(A_1, base.c5().b().Value);
				}
				if (base.c5().s() != null)
				{
					A_1 = x5.e(base.bi(), x5.f(base.aq(), base.c5().s().Value));
				}
				if (base.c5().a() != null)
				{
					A_2 = x5.f(A_2, base.c5().a().Value);
				}
				else if (base.c5().h() != null)
				{
					A_2 = x5.e(base.bj(), x5.f(base.ar(), base.c5().h().Value));
				}
				a_2 = x5.f(A_2, base.ao());
				A_2 = x5.f(A_2, base.ao());
				base.l(x5.e(base.aq(), x5.f(base.c5().a1(), base.c5().a0())));
				break;
			}
			A_1 = x5.f(A_1, base.cc());
			if (x5.h(base.ar(), x5.c()))
			{
				base.m(base.bj());
			}
			if (!base.s())
			{
				A_2 = x5.f(A_2, base.c5().c().f());
				A_2 = x5.f(A_2, base.c5().f().a());
			}
			A_1 = x5.f(A_1, base.c5().c().n());
			a_2 = A_2;
			x5 a_3 = A_1;
			if (base.n() != null)
			{
				A_1 = x5.f(A_1, base.c5().f().d());
				mu mu = base.n().c();
				while (mu != null && mu.a() != null)
				{
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
				}
			}
			this.a(A_0, a_3, a_2);
			this.a(A_0, a_3, a_2, list, num, list.Count);
			A_0.Write_Tc(0f);
			A_0.Write_Q(true);
		}

		// Token: 0x0600111E RID: 4382 RVA: 0x000C3AA8 File Offset: 0x000C2AA8
		internal float b(x5 A_0)
		{
			this.dj(A_0, x5.a(14400f));
			this.e = false;
			float result;
			if (base.c5().v() != null)
			{
				result = x5.b(base.c5().v().Value);
			}
			else
			{
				double num = Math.Ceiling((double)x5.b(base.n().h()));
				result = (float)num;
			}
			return result;
		}

		// Token: 0x0600111F RID: 4383 RVA: 0x000C3B24 File Offset: 0x000C2B24
		internal float a(x5 A_0, x5 A_1, ref bool A_2)
		{
			this.dj(A_0, A_1);
			this.e = false;
			if (base.n().e() == null)
			{
				A_2 = true;
			}
			else
			{
				A_2 = false;
			}
			float result;
			if (base.c5().v() != null)
			{
				result = x5.b(base.c5().v().Value);
			}
			else
			{
				double num = Math.Ceiling((double)x5.b(base.n().h()));
				result = (float)num;
			}
			return result;
		}

		// Token: 0x0400082B RID: 2091
		private new lc a = null;

		// Token: 0x0400082C RID: 2092
		private new n5 b = new n5();

		// Token: 0x0400082D RID: 2093
		private new ld c = new ld();

		// Token: 0x0400082E RID: 2094
		private new bool d = true;

		// Token: 0x0400082F RID: 2095
		private new bool e = false;

		// Token: 0x04000830 RID: 2096
		private new ij f = null;
	}
}
