using System;
using System.Collections;
using System.Collections.Generic;

namespace zz93
{
	// Token: 0x020001EF RID: 495
	internal class mt
	{
		// Token: 0x060015F5 RID: 5621 RVA: 0x000F15F0 File Offset: 0x000F05F0
		internal mt(ms A_0)
		{
			this.b(A_0);
			this.a = new mu(A_0);
			this.b = this.a;
			this.e++;
		}

		// Token: 0x060015F6 RID: 5622 RVA: 0x000F1678 File Offset: 0x000F0678
		internal mt(ms A_0, bool A_1)
		{
			this.a = new mu(A_0);
			this.b = this.a;
			this.e++;
			this.j = A_1;
		}

		// Token: 0x060015F7 RID: 5623 RVA: 0x000F1700 File Offset: 0x000F0700
		internal mu c()
		{
			return this.a;
		}

		// Token: 0x060015F8 RID: 5624 RVA: 0x000F1718 File Offset: 0x000F0718
		internal void a(mu A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060015F9 RID: 5625 RVA: 0x000F1724 File Offset: 0x000F0724
		internal mu d()
		{
			return this.b;
		}

		// Token: 0x060015FA RID: 5626 RVA: 0x000F173C File Offset: 0x000F073C
		internal mt e()
		{
			return this.d;
		}

		// Token: 0x060015FB RID: 5627 RVA: 0x000F1754 File Offset: 0x000F0754
		internal void a(mt A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060015FC RID: 5628 RVA: 0x000F1760 File Offset: 0x000F0760
		internal int f()
		{
			return this.e;
		}

		// Token: 0x060015FD RID: 5629 RVA: 0x000F1778 File Offset: 0x000F0778
		internal void a(int A_0)
		{
			this.e = A_0;
		}

		// Token: 0x060015FE RID: 5630 RVA: 0x000F1784 File Offset: 0x000F0784
		internal x5 g()
		{
			return this.i;
		}

		// Token: 0x060015FF RID: 5631 RVA: 0x000F179C File Offset: 0x000F079C
		internal void a(x5 A_0)
		{
			this.i = A_0;
		}

		// Token: 0x06001600 RID: 5632 RVA: 0x000F17A8 File Offset: 0x000F07A8
		internal x5 h()
		{
			return this.c;
		}

		// Token: 0x06001601 RID: 5633 RVA: 0x000F17C0 File Offset: 0x000F07C0
		internal void b(x5 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001602 RID: 5634 RVA: 0x000F17CC File Offset: 0x000F07CC
		internal x5 i()
		{
			return this.f;
		}

		// Token: 0x06001603 RID: 5635 RVA: 0x000F17E4 File Offset: 0x000F07E4
		internal void c(x5 A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06001604 RID: 5636 RVA: 0x000F17F0 File Offset: 0x000F07F0
		internal bool j()
		{
			return this.j;
		}

		// Token: 0x06001605 RID: 5637 RVA: 0x000F1808 File Offset: 0x000F0808
		private ms b()
		{
			mu mu = this.c();
			ms result = null;
			if (mu != null)
			{
				if (mu.a() != null && mu.a().l() != null)
				{
					result = mu.a();
				}
			}
			return result;
		}

		// Token: 0x06001606 RID: 5638 RVA: 0x000F1858 File Offset: 0x000F0858
		private ms a()
		{
			mu mu = this.c();
			mu mu2 = this.c();
			ms result = this.c().a();
			while (mu != null)
			{
				mu2 = mu;
				mu = mu.b();
			}
			if (mu == null)
			{
				result = mu2.a();
			}
			return result;
		}

		// Token: 0x06001607 RID: 5639 RVA: 0x000F18B4 File Offset: 0x000F08B4
		private void b(ms A_0)
		{
			if (A_0 != null)
			{
				x5 a_ = x5.c();
				x5 a_2 = x5.c();
				x5 a_3 = x5.c();
				x5 a_4 = x5.c();
				if (!A_0.i())
				{
					A_0.a(ref a_, ref a_2, ref a_3, ref a_4);
					A_0.b(a_);
					A_0.a(a_2);
					A_0.d(a_3);
					A_0.c(a_4);
					A_0.b(true);
				}
			}
		}

		// Token: 0x06001608 RID: 5640 RVA: 0x000F1930 File Offset: 0x000F0930
		private void a(ref x5 A_0, ref x5 A_1, k0 A_2, ref x5 A_3, mu A_4, ref ms A_5, ref ms A_6, ref x5 A_7, ref bool A_8, ref x5 A_9)
		{
			A_5.a(A_6);
			A_6 = A_5;
			A_4.a().a5();
			if (A_5.u() == null)
			{
				this.a(A_2, ref A_3, A_5, ref A_8, ref A_9);
			}
			else
			{
				if (A_5.j())
				{
					A_5.ae(A_0);
				}
				A_3 = A_5.a(A_3, ref A_9);
				if (A_5.k())
				{
					A_5.af(A_0);
				}
				int num = A_2.dg();
				if (num <= 442866842)
				{
					if (num != 144937050 && num != 442866842)
					{
						goto IL_163;
					}
				}
				else if (num != 718642778 && num != 889490394)
				{
					goto IL_163;
				}
				if (this.h)
				{
					A_7 = this.a(A_5, false, null);
					A_3 = x5.f(A_3, A_7);
					this.c = x5.f(this.c, A_7);
					ms ms = A_5;
					ms.o(x5.f(ms.ag(), A_7));
					A_1 = x5.e(A_1, A_7);
				}
				IL_163:;
			}
			A_1 = x5.e(A_1, A_9);
			this.c = x5.f(this.c, A_9);
		}

		// Token: 0x06001609 RID: 5641 RVA: 0x000F1AD4 File Offset: 0x000F0AD4
		private void a(ref x5 A_0, k0 A_1, ref mu A_2, ref ms A_3, ms A_4, ref x5 A_5)
		{
			A_2.a().p(false);
			A_1.am(false);
			int num = A_1.dg();
			if (num <= 442866842)
			{
				if (num != 144937050 && num != 442866842)
				{
					goto IL_17B;
				}
			}
			else if (num != 718642778 && num != 889490394)
			{
				goto IL_17B;
			}
			A_3 = A_2.a();
			if (this.h)
			{
				A_5 = this.a(A_3, true, A_3);
				this.c = x5.f(this.c, A_5);
			}
			if (A_3.l() != null)
			{
				k0 k = (k0)A_3.l().a().b();
				bool flag = k.af() != null && k.af().Value;
				A_0 = x5.e(A_0, (A_1.dv().f() != null) ? A_1.dv().f().Value : x5.c());
				if (A_3.l().a().b().dg() == 1946 && flag)
				{
					this.b(A_1, A_4);
				}
				else
				{
					this.a(A_2, A_1, A_4);
				}
			}
			else
			{
				this.a(A_2, A_1, A_4);
			}
			goto IL_189;
			IL_17B:
			this.a(A_2, A_1, A_4);
			IL_189:
			A_2 = ((A_2 != null) ? A_2.b() : null);
		}

		// Token: 0x0600160A RID: 5642 RVA: 0x000F1C7C File Offset: 0x000F0C7C
		private void a(ref x5 A_0, k0 A_1, ref x5 A_2, mu A_3, ms A_4, ms A_5, ref x5 A_6)
		{
			int num = A_1.dg();
			if (num <= 144937050)
			{
				if (num == 1946)
				{
					this.c = x5.f(this.c, A_4.n());
					A_0 = x5.e(A_0, this.a(A_4, ref A_2));
					A_0 = x5.e(A_0, (A_1.dv().f() != null) ? A_1.dv().f().Value : x5.c());
					this.a(A_3, A_1, A_5);
					return;
				}
				if (num != 144937050)
				{
					goto IL_20F;
				}
			}
			else if (num != 442866842 && num != 718642778 && num != 889490394)
			{
				goto IL_20F;
			}
			this.c = x5.f(this.c, A_4.n());
			if (this.h)
			{
				A_6 = this.a(A_4, true, A_5);
			}
			A_0 = x5.e(A_0, this.a(A_4, ref A_2));
			if (A_4.l() != null)
			{
				k0 k = (k0)A_4.l().a().b();
				bool flag = k.af() != null && k.af().Value;
				A_0 = x5.e(A_0, (A_1.dv().f() != null) ? A_1.dv().f().Value : x5.c());
				if (A_4.l().a().b().dg() == 1946 && flag)
				{
					this.b(A_1, A_5);
				}
				else
				{
					this.a(A_3, A_1, A_5);
				}
			}
			else
			{
				this.a(A_3, A_1, A_5);
			}
			return;
			IL_20F:
			if (x5.c(A_4.q(), x5.c()))
			{
				if (A_1.c3())
				{
					this.c = x5.f(this.c, A_4.q());
					A_2 = A_4.q();
				}
				else
				{
					this.c = A_4.q();
					A_2 = A_4.q();
					A_4.o(A_2);
					A_4.i(x5.c());
				}
			}
			A_0 = x5.e(A_0, this.a(A_4, ref A_2));
			if (A_1.c1())
			{
				this.c = x5.f(this.c, A_4.n());
			}
			else if (A_1.dg() == 11228793 && x5.h(this.h(), x5.c()))
			{
				this.c = x5.f(this.c, A_4.n());
			}
			this.a(A_3, A_1, A_5);
		}

		// Token: 0x0600160B RID: 5643 RVA: 0x000F1FB8 File Offset: 0x000F0FB8
		private void a(ref x5 A_0, k0 A_1, ref x5 A_2, mu A_3, ms A_4)
		{
			if (x5.c(A_4.q(), x5.c()))
			{
				if (A_1.c3())
				{
					this.c = x5.f(this.c, A_4.q());
					A_2 = A_4.q();
				}
				else
				{
					this.c = A_4.q();
					A_2 = A_4.q();
					if (!A_4.ar())
					{
						A_4.o(A_2);
					}
				}
			}
			if (x5.c(A_4.ad(), x5.c()))
			{
				this.c = x5.f(this.c, A_4.ad());
				A_2 = x5.f(A_2, A_4.ad());
			}
			A_2 = x5.f(A_2, A_4.n());
			if (A_1.dg() == 144937050 && A_3.b() == null)
			{
				x5 a_ = (A_1.dv().f() != null) ? A_1.dv().f().Value : x5.c();
				this.b(x5.f(this.h(), a_));
			}
			if (x5.g(A_4.n(), x5.c()))
			{
				if (A_1.ci())
				{
					if (x5.b(x5.f(this.h(), A_4.n()), A_1.cj()))
					{
						this.b(x5.f(this.h(), A_4.n()));
						if (x5.h(A_1.ck(), x5.c()))
						{
							A_1.ay(A_1.cj());
						}
						A_1.ay(x5.e(A_1.ck(), A_4.n()));
					}
					else if (A_1.dg() != 594666565 || !A_3.a().v())
					{
						A_3.a(null);
						A_3.a(null);
						A_1.g(true);
						((k0)A_1.dr()).g(true);
					}
				}
				else
				{
					this.c = x5.f(this.c, A_4.n());
				}
			}
			A_0 = x5.e(A_0, this.a(A_4, ref A_2));
			A_4.i(x5.c());
		}

		// Token: 0x0600160C RID: 5644 RVA: 0x000F2258 File Offset: 0x000F1258
		private void a(ref x5 A_0, k0 A_1, ref x5 A_2, ms A_3)
		{
			int num = A_1.dg();
			if (num <= 442866842)
			{
				if (num == 144937050)
				{
					x5 a_ = (A_1.dv().f() != null) ? A_1.dv().f().Value : x5.c();
					if (A_3.l().a().b().dg() != 258605815)
					{
						A_0 = x5.e(A_0, a_);
						A_2 = x5.f(A_2, a_);
						this.c = x5.f(this.c, a_);
					}
					A_3.o(A_2);
					return;
				}
				if (num != 442866842)
				{
					return;
				}
			}
			else if (num != 718642778 && num != 889490394)
			{
				return;
			}
			if (A_3.u() != null)
			{
				x5 a_2 = (A_1.dv().f() != null) ? A_1.dv().f().Value : x5.c();
				A_0 = x5.e(A_0, a_2);
				A_2 = x5.f(A_2, a_2);
				A_3.o(A_2);
				this.c = x5.f(this.c, a_2);
			}
		}

		// Token: 0x0600160D RID: 5645 RVA: 0x000F23CC File Offset: 0x000F13CC
		private void a(k0 A_0, ref x5 A_1, ms A_2, ref bool A_3, ref x5 A_4)
		{
			if (A_2 != null)
			{
				mq mq = A_2.l();
				if (mq != null)
				{
					mr mr = mq.b();
					if (mr != null && mr.b() != null)
					{
						if (A_0.dg() == 11228793 && mr.b().de())
						{
							if (A_2.ab() > 1)
							{
								A_2.o(A_2.bc());
								A_4 = A_2.ag();
							}
						}
						else
						{
							mr mr2 = mq.a();
							if (mr2 != null && mr2.b() != null)
							{
								if ((A_0.c5().m() && mr2.b().de()) || A_0.c5().d())
								{
									A_2.o(x5.f(A_1, A_2.bc()));
									A_4 = A_2.bc();
								}
								else if (A_0.dg() == 3418)
								{
									A_2.o(x5.f(A_1, A_2.bc()));
									A_4 = A_2.bc();
								}
								else
								{
									A_2.o(A_1);
								}
							}
							else
							{
								A_2.o(A_1);
							}
						}
						if (mr.b().de() && A_0.c5().d())
						{
							if (this.e == 1)
							{
								A_3 = true;
							}
						}
						else if (A_0.dg() == 3418)
						{
							A_3 = true;
						}
					}
				}
			}
		}

		// Token: 0x0600160E RID: 5646 RVA: 0x000F25A4 File Offset: 0x000F15A4
		private bool a(k0 A_0, ref x5 A_1, ref x5 A_2, ref x5 A_3, ms A_4, ref bool A_5)
		{
			x5 x = x5.c();
			x5 x2 = x5.c();
			x5 x3 = x5.c();
			x5 x4 = x5.c();
			x5 a_ = x5.c();
			x5 a_2 = x5.c();
			bool flag = true;
			if (A_0.c5().q() == g6.c)
			{
				a_ = ((A_0.c5().a() != null) ? A_0.c5().a().Value : x5.c());
			}
			int num = A_0.dg();
			if (num == 3034 || num == 3418)
			{
				if (A_0.dv().f() != null)
				{
					a_2 = x5.b(A_0.dv().f().Value, A_0.d1() + 1);
				}
			}
			if (!A_0.cy())
			{
				if (A_0.c5().q() != g6.c && A_0.dg() != 3418 && A_0.dg() != 3034)
				{
					x = A_0.bv().a(x5.f(x5.f(x5.f(x5.f(A_0.ao(), A_2), A_0.ap()), a_), a_2));
					x2 = A_0.bv().a(x5.f(x5.f(x5.f(x5.f(A_0.ao(), A_2), A_0.ap()), a_), a_2), A_0);
				}
				if (A_0.c8() != null && A_0.c8().b().Count > 0)
				{
					x = x5.f(x, A_0.c8().a(x5.f(x5.f(x5.f(x5.f(A_0.ao(), A_2), A_0.ap()), a_), a_2)));
					x2 = x5.f(x2, A_0.c8().a(x5.f(x5.f(x5.f(x5.f(A_0.ao(), A_2), A_0.ap()), a_), a_2), A_0));
				}
				x3 = A_0.c5().e().d();
				x4 = A_0.c5().e().b();
				if (x5.c(x3, x5.c()) && x5.c(x5.f(A_0.ax(), x3), x) && x5.c(x4, x5.c()) && x5.c(x5.f(x4, A_0.ay()), x2))
				{
					if (x5.g(x, x5.c()) && x5.g(x2, x5.c()))
					{
						A_0.n(true);
						x = x5.c();
						x2 = x5.c();
					}
				}
				else if (x5.c(x5.f(A_0.ax(), x3), x5.c()) && x5.c(x, x5.c()))
				{
					if (x5.c(x5.f(A_0.ax(), x3), x))
					{
						x = x5.c();
						A_0.l(true);
					}
				}
				else if (x5.c(x5.f(x4, A_0.ay()), x5.c()) && x5.c(x2, x5.c()))
				{
					if (x5.c(x5.f(x4, A_0.ay()), x2))
					{
						x2 = x5.c();
						A_0.m(true);
					}
				}
				if (A_0.c5().am() != null && x5.g(A_0.c5().am().Value, x5.c()))
				{
					num = A_0.dg();
					if (num != 3034 && num != 3418)
					{
						if (A_0.dg() != 445520207 && A_0.dg() != 34721)
						{
							if (!A_0.c3())
							{
								A_1 = x5.e(A_0.bi(), x5.f(x, x2));
								A_1 = x5.e(A_1, A_0.aa());
							}
							else
							{
								A_1 = x5.e(A_0.dr().bi(), x5.f(x, x2));
								A_1 = x5.e(A_1, A_0.aa());
							}
							if (x5.d(A_0.c5().am().Value, A_1))
							{
								A_1 = A_0.c5().am().Value;
							}
						}
						else
						{
							A_1 = x5.e(A_1, x5.f(x, x2));
						}
					}
					else
					{
						A_1 = x5.e(A_0.aq(), x5.f(x, x2));
						A_1 = x5.e(A_1, A_0.aa());
					}
				}
				else if (A_0.bh())
				{
					A_1 = x5.e(A_0.bi(), x5.f(x3, x4));
					A_0.ak(true);
				}
				else
				{
					x5 x5 = A_0.c5().a1();
					x5 x6 = A_0.c5().a0();
					if (!A_0.bf() && !A_0.bg())
					{
						if (!this.c(A_0) || this.c((k0)A_0.dr()))
						{
							A_1 = x5.e(A_0.bi(), x5.f(x, x2));
						}
						else
						{
							A_0.ah(A_1);
						}
						if (x5.h(x, x5.c()))
						{
							A_1 = x5.e(A_1, x5);
						}
						if (x5.h(x2, x5.c()))
						{
							A_1 = x5.e(A_1, x6);
						}
					}
					else
					{
						A_1 = x5.e(A_0.bi(), x5.f(x, x2));
						if (x5.d(x5, x))
						{
							if (x5.c(x6, x2) && !A_0.bg())
							{
								A_1 = x5.e(A_1, x5.e(x6, x2));
							}
						}
						else
						{
							if (!A_0.bf())
							{
								A_1 = x5.e(A_1, x5.e(x5, x));
							}
							if (x5.c(x6, x2))
							{
								A_1 = x5.e(A_1, x5.e(x6, x2));
							}
						}
					}
					if (A_0.c5().ad())
					{
						if (x5.c(A_1, A_0.c5().aq()))
						{
							A_1 = A_0.c5().aq();
						}
					}
				}
			}
			x5 x7 = x5.f(x5.f(A_0.ao(), A_2), A_0.ap());
			ld ld;
			if (!A_0.c3())
			{
				ld = A_0.bv();
			}
			else
			{
				ld = A_0.c8();
			}
			while (x5.b(A_1, x5.a(0.75)) && x5.c(A_3, x5.c()))
			{
				A_2 = ld.a(x7, A_0.bi(), ref A_5);
				ld.a(A_2, ref A_1, A_0.bi(), A_0);
				x = ld.a(A_2);
				if (x5.h(x, x5.c()))
				{
					x2 = ld.a(A_2, A_0);
					A_1 = x5.e(A_1, A_0.aa());
					if (x5.h(x2, x5.c()))
					{
						flag = false;
						break;
					}
				}
				else
				{
					A_1 = x5.e(A_1, x);
				}
				flag = true;
				if (x5.g(A_2, x7))
				{
					A_4.i(x5.e(A_2, A_0.ao()));
					A_3 = x5.e(A_3, x5.e(A_2, x7));
					x7 = A_2;
				}
				else
				{
					x5 x8 = ld.d(x7);
					if (x5.c(x8, x7))
					{
						A_3 = x5.e(A_3, x5.e(x8, x7));
					}
					x7 = x8;
				}
			}
			bool result;
			if (x5.b(A_1, x5.a(0.75)))
			{
				this.b(A_0);
				result = false;
			}
			else
			{
				if (!flag && x5.g(A_2, x7))
				{
					A_4.i(x5.e(A_2, x7));
					A_3 = x5.e(A_3, x5.e(A_2, x7));
					if (x5.d(A_3, x5.c()))
					{
						this.c = x5.e(A_2, x7);
					}
					x7 = A_2;
				}
				if (x5.c(A_3, x5.c()))
				{
					if (A_5)
					{
						A_4.j(true);
						A_4.o(A_2);
					}
					A_0.a5(x);
					A_0.a6(x2);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0600160F RID: 5647 RVA: 0x000F2FCC File Offset: 0x000F1FCC
		private bool c(k0 A_0)
		{
			bool result;
			if (A_0 != null)
			{
				g6 g = A_0.c5().q();
				result = (g == g6.c);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001610 RID: 5648 RVA: 0x000F3004 File Offset: 0x000F2004
		private void b(k0 A_0)
		{
			this.k();
			A_0.b(null);
			lk lk = A_0.c5();
			lk.c().c(x5.c());
			lk.c().d(x5.c());
			lk.c().a(x5.c());
			lk.c().b(x5.c());
			lk.f().d(x5.c());
			lk.f().b(x5.c());
			lk.f().a(x5.c());
			lk.f().c(x5.c());
			lk.e().d(x5.c());
			lk.e().b(x5.c());
			lk.e().a(x5.c());
			lk.e().c(x5.c());
		}

		// Token: 0x06001611 RID: 5649 RVA: 0x000F30F4 File Offset: 0x000F20F4
		private void a(ms A_0, int A_1)
		{
			mq mq = ((k0)A_0.l().a().b()).n().c().a().l();
			mr mr = mq.a();
			bool flag = false;
			if (A_1 != -1)
			{
				while (mr != null && mr.b() != null)
				{
					int num = ((n5)mr.b().db()).z();
					int num2 = A_1 - 1 - mr.b().d1();
					mr.b().d2(A_1 - 1);
					flag = true;
					if (num > 1)
					{
						n5 n = (n5)mr.b().db();
						n.b(n.z() - num2);
					}
					mr = mr.c();
				}
			}
			else
			{
				while (mr != null && mr.b() != null)
				{
					((n5)mr.b().db()).b(1);
					mr = mr.c();
				}
			}
			if (flag)
			{
				A_0.l().a().b().d2(A_1 - 1);
			}
		}

		// Token: 0x06001612 RID: 5650 RVA: 0x000F3234 File Offset: 0x000F2234
		private bool a(ms A_0, mt A_1, int A_2)
		{
			mq mq = ((k0)A_0.l().a().b()).n().c().a().l();
			mr mr = mq.a();
			mr mr2 = A_1.c().a().l().a();
			bool result = false;
			bool flag = false;
			while (mr != null && mr.b() != null)
			{
				k0 k = (k0)mr.b();
				int num = k.dg();
				if (num == 3034 || num == 3418)
				{
					if (k.b5())
					{
						if (mr2 != null)
						{
							mr.a(mr2.b());
							mr2 = mr2.c();
							result = true;
						}
					}
					else
					{
						int num2 = ((n5)k.db()).z();
						if (num2 > 1)
						{
							n5 n = (n5)mr.b().db();
							n.b(n.z() - (A_2 - k.d1()));
							mr.b().d2(A_2);
							flag = true;
						}
					}
				}
				mr = mr.c();
			}
			if (flag)
			{
				A_0.l().a().b().d2(A_2);
			}
			return result;
		}

		// Token: 0x06001613 RID: 5651 RVA: 0x000F33A4 File Offset: 0x000F23A4
		private bool? a(mu A_0, ref int A_1, ref bool A_2, ref int A_3)
		{
			bool? result = null;
			if (A_0 != null && A_0.a() != null && A_0.a().l() != null)
			{
				ms ms = A_0.a();
				mr mr = ms.l().a();
				while (mr != null && mr.b() != null)
				{
					k0 k = (k0)mr.b();
					int num = k.dg();
					if (num == 3034 || num == 3418)
					{
						int num2 = ((n5)k.db()).z();
						int num3 = k.d1();
						if (A_1 < num3 + num2)
						{
							A_1 = num3 + num2;
						}
						if (k.b5())
						{
							if (result == null)
							{
								result = new bool?(true);
							}
						}
						else if (num2 == 1)
						{
							result = new bool?(false);
						}
						else
						{
							if (A_3 > num3 + num2)
							{
								A_3 = num3 + num2;
							}
							A_2 = true;
						}
					}
					mr = mr.c();
				}
			}
			return result;
		}

		// Token: 0x06001614 RID: 5652 RVA: 0x000F34F0 File Offset: 0x000F24F0
		private x5 a(ms A_0, bool A_1, ms A_2)
		{
			x5 result = x5.c();
			Hashtable hashtable = this.a(A_0);
			if (hashtable.Count > 1)
			{
				result = this.a(A_0, hashtable, A_1, A_2);
			}
			return result;
		}

		// Token: 0x06001615 RID: 5653 RVA: 0x000F3530 File Offset: 0x000F2530
		private x5 a(ms A_0, Hashtable A_1, bool A_2, ms A_3)
		{
			x5 x = x5.c();
			x5 a_ = x5.c();
			int num = int.MinValue;
			ms ms = A_0.u();
			bool flag = true;
			while (ms != null && ms.l() != null)
			{
				mr mr = ms.l().a();
				if (mr != null && mr.b() != null)
				{
					k0 k = (k0)mr.b();
					int num2 = k.dg();
					if (k.dv().f() != null)
					{
						a_ = k.dv().f().Value;
					}
					int num3 = k.d1();
					int num4 = num3;
					int num5 = num2;
					if (num5 == 1946)
					{
						mu mu = (k.n() != null) ? k.n().c() : null;
						bool flag2 = false;
						if (mu != null && mu.a() != null)
						{
							for (mr mr2 = mu.a().l().a(); mr2 != null; mr2 = mr2.c())
							{
								int num6 = ((n5)mr2.b().db()).z();
								if (num6 > 1)
								{
									flag2 = true;
									if (num < num6)
									{
										num = num6;
										num4 = num3 + num6 - 1;
									}
								}
							}
							if (flag2)
							{
								if (A_1.ContainsKey(num4) && flag)
								{
									x = x5.f(x, this.a(A_1, (nx)k, a_, A_0));
								}
								else if (A_2 && num3 < num4)
								{
									num4 = num3;
									if (A_2 && A_3 != null)
									{
										this.a(num, A_3);
									}
									if (A_1.ContainsKey(num4) && flag)
									{
										x = x5.f(x, this.a(A_1, (nx)k, a_, A_0));
									}
								}
								else
								{
									flag = false;
								}
							}
							else
							{
								flag = true;
							}
						}
					}
				}
				ms = ms.u();
			}
			return x;
		}

		// Token: 0x06001616 RID: 5654 RVA: 0x000F379C File Offset: 0x000F279C
		private void a(int A_0, ms A_1)
		{
			if (A_1 != null && A_1.l() != null)
			{
				mr mr = A_1.l().a();
				if (mr != null && mr.b() != null)
				{
					k0 k = (k0)mr.b();
					int num = k.dg();
					if (num == 1946)
					{
						mu mu = (k.n() != null) ? k.n().c() : null;
						if (mu != null && mu.a() != null)
						{
							mr mr2 = mu.a().l().a();
							((n5)mr2.b().db()).b(A_0 - A_1.ab() + 1);
						}
					}
				}
			}
		}

		// Token: 0x06001617 RID: 5655 RVA: 0x000F3870 File Offset: 0x000F2870
		private x5 a(Hashtable A_0, nx A_1, x5 A_2, ms A_3)
		{
			x5 x = x5.c();
			List<ne> list = A_1.c();
			mu a_ = this.c();
			foreach (ne ne in list)
			{
				int num = ne.c();
				x5 x2 = this.a(A_0, ne.a(), num, A_2);
				if (x5.d(ne.d(), x2))
				{
					ne.a(x2);
					ne.e().m(x2);
				}
				else
				{
					x5 x3 = x5.e(ne.d(), x2);
					if (x5.c(x3, x5.c()))
					{
						if (num > A_0.Count || !A_0.ContainsKey(ne.a() + num - 1))
						{
							return x;
						}
						int num2 = 0;
						for (int i = ne.a(); i < ne.a() + num; i++)
						{
							if (!A_0.ContainsKey(i))
							{
								break;
							}
							num2++;
						}
						if (num2 == 0)
						{
							num2 = 1;
						}
						x = x5.f(x, x3);
						x3 = x5.a(x5.b(x3) / (float)num2);
						this.a(A_0, x3, a_, A_3, ne.a(), num, ne.b());
					}
				}
			}
			return x;
		}

		// Token: 0x06001618 RID: 5656 RVA: 0x000F3A34 File Offset: 0x000F2A34
		private x5 a(Hashtable A_0, int A_1, int A_2, x5 A_3)
		{
			x5 a_ = x5.c();
			for (int i = A_1; i < A_1 + A_2; i++)
			{
				if (A_0.ContainsKey(i))
				{
					a_ = x5.f(a_, x5.f((x5)A_0[i], A_3));
				}
			}
			return x5.e(a_, A_3);
		}

		// Token: 0x06001619 RID: 5657 RVA: 0x000F3A9C File Offset: 0x000F2A9C
		private void a(Hashtable A_0, x5 A_1, mu A_2, ms A_3, int A_4, int A_5, int A_6)
		{
			int num = A_4 + A_5;
			while (A_2 != null && A_2.a() != null && A_2.a() != A_3)
			{
				ms ms = A_2.a();
				if (ms.l() != null)
				{
					mr mr = ms.l().a();
					while (mr != null && mr.b() != null)
					{
						k0 k = (k0)mr.b();
						int num2 = k.dg();
						if (num2 <= 3418)
						{
							if (num2 != 1946)
							{
								if (num2 == 3034 || num2 == 3418)
								{
									if (k.d1() != A_4 || ((nt)k).h() != A_6)
									{
										int num3 = ((n5)k.db()).z();
										if (num3 == 1)
										{
											mr.b().m((x5)A_0[k.d1()]);
										}
										else if (k.d1() == A_4)
										{
											if (num3 < A_5)
											{
												kz kz = mr.b();
												kz.m(x5.f(kz.ar(), A_1));
											}
										}
										else if (num3 == 1)
										{
											kz kz2 = mr.b();
											kz2.m(x5.f(kz2.ar(), A_1));
										}
									}
								}
							}
							else if (k.d1() >= A_4 && k.d1() < num)
							{
								if (k.d1() > A_4)
								{
									ms ms2 = ms;
									ms2.o(x5.f(ms2.ag(), A_1));
								}
								x5 x = x5.f(A_1, (x5)A_0[k.d1()]);
								A_0[k.d1()] = x;
								k.m(x);
								this.a(A_0, A_1, k.n().c(), A_3, A_4, num, A_6);
							}
						}
						else if (num2 == 442866842 || num2 == 718642778 || num2 == 889490394)
						{
							this.a(A_0, A_1, k.n().c(), A_3, A_4, num, A_6);
						}
						mr = mr.c();
					}
				}
				A_2 = A_2.b();
			}
		}

		// Token: 0x0600161A RID: 5658 RVA: 0x000F3D48 File Offset: 0x000F2D48
		private Hashtable a(ms A_0)
		{
			Hashtable hashtable = new Hashtable();
			mu mu = this.c();
			while (mu != null && mu.a() != null && mu.a() != A_0)
			{
				ms ms = mu.a();
				if (ms.l() != null)
				{
					mr mr = ms.l().a();
					while (mr != null && mr.b() != null)
					{
						int num = mr.b().dg();
						if (num == 1946)
						{
							if (hashtable.ContainsKey(mr.b().d1()))
							{
								hashtable[mr.b().d1()] = mr.b().ar();
							}
							else
							{
								hashtable.Add(mr.b().d1(), mr.b().ar());
							}
						}
						mr = mr.c();
					}
				}
				mu = mu.b();
			}
			return hashtable;
		}

		// Token: 0x0600161B RID: 5659 RVA: 0x000F3E78 File Offset: 0x000F2E78
		private void a(mu A_0, k0 A_1, ms A_2)
		{
			mu mu = A_0;
			bool flag = false;
			int num = 0;
			k0 k = (k0)A_1.dr();
			if (this.g != null)
			{
				if (A_2 == null && mu.a() != null && !mu.a().a1())
				{
					A_2 = mu.a();
					flag = true;
				}
				else if (A_2 == null)
				{
					return;
				}
				this.g.c(A_2);
				if (this.d == null)
				{
					this.d = this.g;
				}
				else
				{
					for (mu mu2 = this.g.c(); mu2 != null; mu2 = mu2.b())
					{
						this.d.c(mu2.a());
					}
				}
				this.g = null;
				mu = mu.b();
			}
			if (A_2 != null && !A_2.y())
			{
				if (this.d == null)
				{
					if (A_1.x() != null)
					{
						this.a(A_1, k);
					}
					if (A_1.y() != null)
					{
						this.a(A_1);
					}
					if (mu != null)
					{
						if (A_1.c0())
						{
							if (mu.a().l() != null && !A_1.cx())
							{
								int num2 = A_1.dg();
								if (num2 <= 144937050)
								{
									if (num2 != 1946 && num2 != 11228793 && num2 != 144937050)
									{
										goto IL_1CE;
									}
								}
								else if (num2 != 442866842 && num2 != 718642778 && num2 != 889490394)
								{
									goto IL_1CE;
								}
								goto IL_206;
								IL_1CE:
								ms a_ = mu.a();
								if (this.d == null)
								{
									this.d = new mt(a_);
								}
								else
								{
									this.d.c(a_);
								}
								flag = true;
								IL_206:;
							}
						}
						if (this.d == null)
						{
							this.d = new mt(A_2);
						}
						else
						{
							this.d.c(A_2);
						}
						mu = ((mu != null) ? mu.b() : null);
					}
				}
				num = 0;
				while (mu != null && mu.a() != null && mu.a().l() != null)
				{
					num++;
					this.d.c(mu.a());
					mu = mu.b();
				}
				if (!flag)
				{
					this.b(A_0.b());
				}
				else
				{
					this.b(A_0);
				}
			}
			else if (A_2 != null && !A_1.cx())
			{
				if (this.d == null)
				{
					this.d = new mt(A_2);
				}
				else
				{
					this.d.c(A_2);
				}
			}
			else if (A_0 != null && A_1 != null)
			{
				if (A_1.cx())
				{
					mu = A_0.b();
				}
				if (A_1.x() != null)
				{
					this.a(A_1, k);
				}
				if (A_1.y() != null)
				{
					this.a(A_1);
				}
				num = 0;
				if (A_0.a() != null && !A_0.a().a1())
				{
					if (A_0.a().l() == null)
					{
						mu = A_0.b();
					}
					else
					{
						mu = A_0;
					}
				}
				else
				{
					mu = A_0.b();
				}
				if (mu != null && mu.a() != null && mu.a().l() != null)
				{
					mu.a().n(false);
					if (this.d == null)
					{
						this.d = new mt(mu.a());
					}
					else
					{
						this.d.c(mu.a());
					}
					num++;
					mu = mu.b();
					while (mu != null && mu.a() != null)
					{
						num++;
						this.d.c(mu.a());
						mu = mu.b();
					}
					if (A_1.cx())
					{
						this.b(A_0.b());
					}
					else
					{
						this.b(A_0);
					}
				}
			}
			else
			{
				if (A_1.x() != null)
				{
					this.a(A_1, k);
				}
				if (A_1.y() != null)
				{
					this.a(A_1);
				}
			}
			this.e -= num;
			if (A_1 != null && A_1.dg() == 144937050 && A_1.n().c().a() != null)
			{
				this.a(A_1, A_2);
			}
			A_1.j(k);
		}

		// Token: 0x0600161C RID: 5660 RVA: 0x000F438C File Offset: 0x000F338C
		private void a(k0 A_0)
		{
			if (A_0 != null && A_0.y() != null)
			{
				if (this.d == null)
				{
					this.d = new mt(A_0.y());
				}
				else
				{
					this.d.d(A_0.y());
				}
			}
			A_0.e(null);
		}

		// Token: 0x0600161D RID: 5661 RVA: 0x000F43F0 File Offset: 0x000F33F0
		private void a(k0 A_0, k0 A_1)
		{
			if (A_0.x() != null && A_0.c3())
			{
				this.d = new mt(A_0.x());
				A_0.d(null);
			}
			else
			{
				if (A_1 != null && A_1.x() == null && A_0.x() != null)
				{
					A_1.d(A_0.x());
				}
				else if (A_1 != null && A_1.x() != null && A_0.x() != null)
				{
					for (mr mr = A_0.x().l().a(); mr != null; mr = mr.c())
					{
						A_1.x().l().a(mr.b());
					}
				}
				else if (A_1 == null && A_0.x() != null)
				{
					this.d = new mt(A_0.x());
				}
				A_0.d(null);
			}
		}

		// Token: 0x0600161E RID: 5662 RVA: 0x000F4500 File Offset: 0x000F3500
		private void b(k0 A_0, ms A_1)
		{
			if (this.g == null)
			{
				this.g = new mt(A_1);
			}
			else
			{
				this.g.c(A_1);
			}
			if (A_0.dg() == 144937050 && A_0.n().c().a() != null)
			{
				this.a(A_0, A_1);
			}
		}

		// Token: 0x0600161F RID: 5663 RVA: 0x000F456C File Offset: 0x000F356C
		private x5 a(ms A_0, ref x5 A_1)
		{
			x5 result;
			if (A_0.ar() && x5.c(A_0.am(), x5.c()))
			{
				x5 x = x5.c();
				if (x5.c(A_0.n(), x5.c()))
				{
					this.c = x5.e(this.c, A_0.n());
					A_1 = x5.e(A_1, A_0.n());
					x = x5.f(A_0.n(), A_0.am());
					A_0.o(x5.f(A_0.ag(), A_0.am()));
					this.c = x;
				}
				if (x5.h(A_0.n(), x5.c()))
				{
					A_1 = x5.f(A_1, x5.f(A_0.am(), A_0.n()));
					result = A_0.am();
				}
				else
				{
					result = x;
				}
			}
			else if (x5.c(A_0.ad(), x5.c()))
			{
				result = A_0.ad();
			}
			else if (x5.c(A_0.q(), x5.c()))
			{
				result = A_0.n();
			}
			else
			{
				result = A_0.n();
			}
			return result;
		}

		// Token: 0x06001620 RID: 5664 RVA: 0x000F46B4 File Offset: 0x000F36B4
		private void a(k0 A_0, ms A_1)
		{
			int num = 0;
			if (A_1 != null)
			{
				num = A_1.l().a().b().dg();
			}
			ms ms = A_0.n().c().a();
			if (ms.l() != null && ms.l().a().b().dg() == 889490394 && num != 889490394)
			{
				ms a_ = new ms(((nv)A_0).c().k(false));
				this.d.d(a_);
			}
		}

		// Token: 0x06001621 RID: 5665 RVA: 0x000F4750 File Offset: 0x000F3750
		private bool a(kz A_0)
		{
			g6 g = A_0.c5().q();
			bool result;
			if (g != g6.b)
			{
				switch (A_0.c5().n())
				{
				case g3.a:
				case g3.b:
					result = false;
					break;
				default:
				{
					g2 valueOrDefault = A_0.c5().t().GetValueOrDefault();
					g2? g2;
					if (g2 != null)
					{
						if (valueOrDefault == g2.b)
						{
							result = false;
							break;
						}
					}
					int num = A_0.dg();
					if (num <= 426354867)
					{
						if (num <= 86147604)
						{
							if (num != 23684646 && num != 86147604)
							{
								goto IL_DC;
							}
						}
						else if (num != 423471123 && num != 426354867)
						{
							goto IL_DC;
						}
					}
					else if (num <= 506042859)
					{
						if (num != 445520207 && num != 506042859)
						{
							goto IL_DC;
						}
					}
					else if (num != 622899778 && num != 673419368)
					{
						goto IL_DC;
					}
					result = true;
					break;
					IL_DC:
					result = false;
					break;
				}
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001622 RID: 5666 RVA: 0x000F4840 File Offset: 0x000F3840
		internal void c(ms A_0)
		{
			this.b(A_0);
			mu mu = new mu(A_0);
			this.b.a(mu);
			mu.b(this.b);
			this.b = mu;
			this.e++;
		}

		// Token: 0x06001623 RID: 5667 RVA: 0x000F488C File Offset: 0x000F388C
		internal void k()
		{
			this.c().a(null);
			this.c().a(null);
			this.e = 0;
		}

		// Token: 0x06001624 RID: 5668 RVA: 0x000F48B0 File Offset: 0x000F38B0
		internal void l()
		{
			this.c().a(null);
			this.c().a(null);
			this.e = 0;
			this.f = x5.c();
			this.i = x5.c();
			this.c = x5.c();
		}

		// Token: 0x06001625 RID: 5669 RVA: 0x000F4900 File Offset: 0x000F3900
		internal ms b(int A_0)
		{
			int i = 0;
			mu mu = this.a;
			while (i < A_0)
			{
				mu = mu.b();
				i++;
			}
			ms result;
			if (mu != null)
			{
				result = mu.a();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06001626 RID: 5670 RVA: 0x000F4944 File Offset: 0x000F3944
		internal mu c(int A_0)
		{
			mu mu = this.a;
			for (int i = 0; i < A_0; i++)
			{
				mu = mu.b();
			}
			return mu;
		}

		// Token: 0x06001627 RID: 5671 RVA: 0x000F4978 File Offset: 0x000F3978
		internal mu m()
		{
			mu mu = this.a;
			while (mu.b() != null)
			{
				mu = mu.b();
			}
			return mu;
		}

		// Token: 0x06001628 RID: 5672 RVA: 0x000F49AC File Offset: 0x000F39AC
		internal void a(mu A_0, mu A_1)
		{
			mu a_ = A_1.b();
			A_1.a(A_0);
			A_0.a(a_);
			if (A_1 != null)
			{
				A_0.b(A_1);
				if (A_0.b() != null)
				{
					A_0.b().b(A_0);
				}
			}
			this.e++;
		}

		// Token: 0x06001629 RID: 5673 RVA: 0x000F4A0C File Offset: 0x000F3A0C
		internal void d(ms A_0)
		{
			mu a_ = this.a;
			this.a = new mu(A_0);
			this.a.a(a_);
			this.a.b().b(this.a);
			this.e++;
		}

		// Token: 0x0600162A RID: 5674 RVA: 0x000F4A60 File Offset: 0x000F3A60
		internal void b(mu A_0, mu A_1)
		{
			mu mu = A_1.c();
			if (mu != null)
			{
				mu.a(A_0);
				A_0.b(mu);
			}
			else
			{
				A_1.a(A_0);
			}
		}

		// Token: 0x0600162B RID: 5675 RVA: 0x000F4A9C File Offset: 0x000F3A9C
		internal void b(mu A_0)
		{
			if (A_0 != null)
			{
				A_0.a(null);
				A_0.a(null);
			}
		}

		// Token: 0x0600162C RID: 5676 RVA: 0x000F4AC4 File Offset: 0x000F3AC4
		internal void c(mu A_0)
		{
			if (A_0.c() != null)
			{
				A_0.c().a(A_0.b());
				if (A_0.b() != null)
				{
					A_0.b().b(A_0.c());
				}
			}
			else
			{
				A_0 = A_0.b();
				if (A_0 != null)
				{
					A_0.b(null);
				}
				this.a = A_0;
			}
		}

		// Token: 0x0600162D RID: 5677 RVA: 0x000F4B38 File Offset: 0x000F3B38
		internal void a(x5 A_0, x5 A_1, k0 A_2, x5 A_3)
		{
			mu mu = null;
			ms ms = null;
			ms ms2 = null;
			x5 x = A_0;
			x5 x2 = x5.c();
			mu = this.c();
			int num = 0;
			this.c = x5.c();
			this.d = null;
			bool flag = false;
			bool flag2 = false;
			gf gf = gf.e;
			gf gf2 = gf.e;
			while (mu != null && mu.a() != null)
			{
				ms ms3 = null;
				x5 x3 = x5.c();
				if (x5.c(A_1, x5.a(10f)))
				{
					ms = mu.a();
					if (ms.l() != null && ms.l().a().b() != null)
					{
						if (ms.l().a().b().de())
						{
							if (x5.h(A_0, A_2.bm()) && x5.h(A_1, A_2.bl()))
							{
								if (num == 0)
								{
									num++;
								}
							}
							else
							{
								num++;
							}
						}
					}
					ms.c(num);
					ms.a(ref gf, ref gf2);
					if (gf == gf.a)
					{
						ms.a9();
						if (num > 1 || x5.d(A_1, A_2.bl()))
						{
							this.a(mu, A_2, null);
							A_2.am(false);
							if (A_2.dr() != null)
							{
								A_2.dr().am(false);
							}
						}
						else
						{
							gf = gf.e;
						}
					}
					if (gf != gf.a)
					{
						this.a(ref A_0, ref A_1, A_2, ref A_3, mu, ref ms, ref ms2, ref x2, ref flag, ref x3);
						this.a(ref A_1, A_2, ref A_3, ms);
						bool flag3 = true;
						bool flag4 = this.a(A_2);
						bool a_ = false;
						if (!flag4 || x5.d(A_0, x5.c()))
						{
							flag3 = this.a(A_2, ref A_0, ref A_3, ref A_1, ms, ref a_);
						}
						if (flag3)
						{
							A_0 = x5.e(A_0, ms.ac());
							A_2.e(A_0, A_1);
							ms3 = A_2.a(mu, num, A_3, a_);
							ms.a(ref gf, ref gf2);
							if (ms3 != null)
							{
								if (mu.a().a2())
								{
									mu.a().q(false);
									ms3.q(true);
								}
							}
							x5 a_2 = A_3;
							A_3 = ms.ag();
							if (x5.c(A_3, a_2))
							{
								a_2 = x5.e(A_3, a_2);
							}
							else
							{
								a_2 = x5.c();
							}
							if (A_2.ah())
							{
								this.h = A_2.ah();
							}
							if (A_2.c0())
							{
								if (x5.c(ms.r(), this.i))
								{
									this.i = ms.r();
								}
								if (ms3 != null)
								{
									if (!ms3.y())
									{
										if (x5.h(ms.n(), x5.c()) && x5.g(ms.ak(), x5.c()))
										{
											A_3 = A_2.bv().a(A_3, A_2.bi(), ref flag2);
										}
										if (!ms3.a1())
										{
											this.a(new mu(ms3), mu);
										}
									}
								}
								if (x5.h(A_2.ac(), x5.c()))
								{
									this.a(ref A_1, A_2, ref A_3, mu, ms);
								}
								else
								{
									g6 g = A_2.c5().q();
									if (g != g6.c)
									{
									}
									this.c = x5.f(this.c, ms.n());
									A_0 = x;
									A_3 = x5.f(A_3, ms.n());
								}
								if (gf2 == gf.a)
								{
									ms.ba();
									if (mu.b() == null && A_2.dg() != 11228793)
									{
										((n5)A_2.db()).b(gf.a);
									}
									else
									{
										this.a(mu.b(), A_2, ms3);
										A_2.am(false);
										if (A_2.dr() != null)
										{
											A_2.dr().am(false);
										}
									}
								}
							}
							else
							{
								if (x5.c(ms.r(), this.i) && A_2.c1())
								{
									this.i = ms.r();
								}
								if (num == 1 && !A_2.c1())
								{
									A_2.aj(true);
									this.c = ms.n();
									this.a(mu, A_2, ms3);
								}
								else if (!A_2.c3())
								{
									this.a(ref A_1, A_2, ref A_3, mu, ms, ms3, ref x2);
								}
								else
								{
									if (ms3 != null && A_2.c5().v() != null)
									{
										A_3 = x5.e(A_3, ms.n());
										ms.o(A_3);
										A_1 = A_2.ar();
									}
									this.b(x5.f(this.h(), ms.n()));
									this.a(mu, A_2, ms3);
								}
							}
							x5 a_3 = x5.c();
							a_3 = ms.d(A_2.dg());
							this.c = x5.f(this.c, a_3);
							A_1 = x5.e(A_1, a_3);
							A_3 = x5.f(A_3, a_3);
							a_3 = x5.c();
							if (ms.u() != null && !ms.u().@as())
							{
								a_3 = ms.u().a8();
								ms ms4 = ms;
								ms4.o(x5.f(ms4.ag(), a_3));
							}
							else
							{
								a_3 = ms.a8();
								A_3 = x5.f(A_3, a_3);
							}
							A_1 = x5.e(A_1, a_3);
							this.b(x5.f(this.h(), a_3));
							ms ms5 = ms;
							ms5.f(x5.f(ms5.n(), a_3));
							if (!flag && mu.b() == null && A_2.c5().d())
							{
								x5 a_4 = ms.bb();
								A_1 = x5.e(A_1, a_4);
								this.c = x5.f(this.c, a_4);
							}
							mu = ((mu != null) ? mu.b() : null);
							if (mu != null)
							{
								A_2.am(x5.c());
							}
						}
						else
						{
							if (this.e == 0)
							{
								return;
							}
							A_1 = x5.c();
							this.a(mu, A_2, null);
							mu = ((mu != null) ? mu.b() : null);
						}
						gf = gf.e;
						gf2 = gf.e;
					}
					else
					{
						mu = ((mu != null) ? mu.b() : null);
					}
				}
				else
				{
					this.a(ref A_1, A_2, ref mu, ref ms, ms3, ref x2);
				}
				if (flag)
				{
					if (this.e == 1 && ms.l() != null)
					{
						if (ms.l() != null)
						{
							this.c = x5.f(this.c, ms.bb());
						}
					}
				}
			}
			if (A_2.x() != null)
			{
				this.a(mu, A_2, null);
			}
			if (A_2.y() != null)
			{
				this.a(mu, A_2, null);
				return;
			}
		}

		// Token: 0x0600162E RID: 5678 RVA: 0x000F52E0 File Offset: 0x000F42E0
		internal int n()
		{
			int num = 0;
			mu mu = this.c();
			while (mu != null && mu.a() != null)
			{
				if (mu.a().l() != null && mu.a().l().a().b() != null)
				{
					int num2 = mu.a().l().a().b().dg();
					if (num2 <= 258605815)
					{
						if (num2 == 1946)
						{
							goto IL_9F;
						}
						if (num2 != 258605815)
						{
						}
					}
					else if (num2 == 442866842 || num2 == 718642778 || num2 == 889490394)
					{
						goto IL_9F;
					}
					goto IL_11C;
					IL_9F:
					k0 k = (k0)mu.a().l().a().b();
					if (k.n() != null)
					{
						if (k.n().e() != null)
						{
							return num + (k.n().f() - k.n().e().f());
						}
						num += k.n().f();
					}
					else
					{
						num++;
					}
				}
				IL_11C:
				mu = mu.b();
			}
			return num;
		}

		// Token: 0x0600162F RID: 5679 RVA: 0x000F5434 File Offset: 0x000F4434
		internal void o()
		{
			mu mu = this.c();
			int num = 0;
			int maxValue = int.MaxValue;
			bool? flag = null;
			int num2 = 0;
			bool flag2 = false;
			bool flag3 = false;
			while (mu != null && mu.a() != null && mu.a().l() != null)
			{
				ms ms = mu.a();
				mr mr = ms.l().a();
				while (mr != null && mr.b() != null)
				{
					k0 k = (k0)mr.b();
					int num3 = k.dg();
					if (num3 == 1946)
					{
						if (k.n() != null)
						{
							if (num2 == 0)
							{
								flag = this.a(k.n().c(), ref num, ref flag3, ref maxValue);
								if (flag != null)
								{
									num2++;
								}
							}
							else
							{
								if (num > k.d1() && (maxValue == 2147483647 || maxValue > k.d1()))
								{
									if (flag != null && flag.Value)
									{
										flag2 = this.a(mu.c().a(), k.n(), k.d1());
									}
								}
								else if (flag3)
								{
									this.a(mu.c().a(), k.d1());
								}
								num2++;
							}
						}
					}
					mr = mr.c();
				}
				if (flag2 || num2 > 1)
				{
					if (flag2)
					{
						mu a_ = mu.c();
						mu.c().a(mu.b());
						if (mu.b() != null)
						{
							mu.b().b(a_);
						}
						this.a(this.f() - 1);
					}
					break;
				}
				if (num2 == 1 && mu.b() == null)
				{
					if (mu.c() != null && flag3)
					{
						this.a(mu.c().a(), -1);
					}
				}
				mu = mu.b();
			}
		}

		// Token: 0x06001630 RID: 5680 RVA: 0x000F56B0 File Offset: 0x000F46B0
		internal void a(ref x5 A_0, ref x5 A_1, ref x5 A_2, ref x5 A_3)
		{
			x5 x = x5.c();
			x5 x2 = x5.c();
			x5 x3 = x5.c();
			x5 x4 = x5.c();
			if (this.f() > 1)
			{
				ms ms = this.b();
				ms ms2 = this.a();
				if (!ms.i())
				{
					ms.a(ref x, ref x2, ref x3, ref x4);
				}
				else
				{
					A_0 = ms.f();
					A_1 = ms.e();
				}
				if (ms2 != null)
				{
					if (!ms2.i())
					{
						ms2.a(ref x, ref x2, ref x3, ref x4);
					}
					else
					{
						A_2 = ms2.h();
						A_3 = ms2.g();
						ms ms3 = ms2;
						x5 a_;
						ms2.d(a_ = x5.c());
						ms3.c(a_);
					}
				}
			}
			else
			{
				ms ms4 = this.b();
				if (ms4 != null)
				{
					if (!ms4.i())
					{
						ms4.a(ref x, ref x2, ref x3, ref x4);
					}
					else
					{
						A_0 = ms4.f();
						A_1 = ms4.e();
						A_2 = ms4.h();
						A_3 = ms4.g();
					}
				}
			}
		}

		// Token: 0x06001631 RID: 5681 RVA: 0x000F5810 File Offset: 0x000F4810
		internal mt p()
		{
			mt mt = null;
			mu mu = this.a;
			if (mu != null && mu.a() != null)
			{
				mt = new mt(mu.a().bd());
				for (mu = mu.b(); mu != null; mu = mu.b())
				{
					mt.c(mu.a().bd());
				}
				mt.a(this.e);
			}
			return mt;
		}

		// Token: 0x04000A36 RID: 2614
		private mu a;

		// Token: 0x04000A37 RID: 2615
		private mu b;

		// Token: 0x04000A38 RID: 2616
		private x5 c = x5.c();

		// Token: 0x04000A39 RID: 2617
		private mt d = null;

		// Token: 0x04000A3A RID: 2618
		private int e = 0;

		// Token: 0x04000A3B RID: 2619
		private x5 f = x5.c();

		// Token: 0x04000A3C RID: 2620
		private mt g = null;

		// Token: 0x04000A3D RID: 2621
		private bool h = false;

		// Token: 0x04000A3E RID: 2622
		private x5 i = x5.c();

		// Token: 0x04000A3F RID: 2623
		private bool j = false;
	}
}
