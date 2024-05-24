using System;
using System.Collections;
using System.Collections.Generic;

namespace zz93
{
	// Token: 0x020001C1 RID: 449
	internal class ll
	{
		// Token: 0x060012AB RID: 4779 RVA: 0x000D2CCE File Offset: 0x000D1CCE
		internal ll(k0 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060012AC RID: 4780 RVA: 0x000D2D04 File Offset: 0x000D1D04
		internal bool e()
		{
			return this.b;
		}

		// Token: 0x060012AD RID: 4781 RVA: 0x000D2D1C File Offset: 0x000D1D1C
		internal void a(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060012AE RID: 4782 RVA: 0x000D2D28 File Offset: 0x000D1D28
		private void d()
		{
			x5 x = x5.c();
			x5 x2 = x5.c();
			x5 x3 = x5.c();
			x5 x4 = x5.c();
			x5 x5 = x5.c();
			x5 x6 = x5.c();
			x5 x7 = x5.c();
			x5 value = x5.c();
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			bool flag7 = false;
			bool flag8 = false;
			if (this.a.c5().am() != null)
			{
				x = this.a.c5().am().Value;
				flag = true;
			}
			if (this.a.c5().ae())
			{
				x2 = this.a.c5().@as();
				flag2 = true;
			}
			if (this.a.c5().ad())
			{
				x3 = this.a.c5().aq();
				flag3 = true;
			}
			if (this.a.c5().v() != null)
			{
				x4 = this.a.c5().v().Value;
				flag4 = true;
			}
			if (this.a.c5().ag())
			{
				x5 = this.a.c5().ak();
				flag5 = true;
			}
			if (this.a.c5().af())
			{
				x6 = this.a.c5().ai();
				flag6 = true;
			}
			if (flag && flag4 && (flag2 || flag3) && flag5 && flag6)
			{
				flag7 = true;
				flag8 = true;
				if (x5.c(x, x3) && x5.c(x3, x5.c()))
				{
					x7 = x3;
					x5 x8 = x5.a(x5.b(x3) * (x5.b(x4) / x5.b(x)));
					value = (x5.c(x8, x5) ? x8 : x5);
				}
				if (x5.d(x, x2) && x5.c(x2, x5.c()))
				{
					x7 = x2;
					x5 x8 = x5.a(x5.b(x2) * (x5.b(x4) / x5.b(x)));
					value = (x5.d(x8, x6) ? x8 : x6);
				}
				if (x5.c(x4, x6) && x5.c(x6, x5.c()))
				{
					value = x6;
					x5 x9 = x5.a(x5.b(x6) * (x5.b(x) / x5.b(x4)));
					x7 = (x5.c(x9, x2) ? x9 : x2);
				}
				if (x5.d(x4, x5) && x5.c(x5, x5.c()))
				{
					value = x5;
					x5 x9 = x5.a(x5.b(x5) * (x5.b(x4) / x5.b(x)));
					x7 = (x5.d(x9, x3) ? x9 : x3);
				}
				if (x5.c(x, x3) && x5.c(x4, x6) && x5.c(x3, x5.c()) && x5.c(x6, x5.c()))
				{
					if (x5.b(x3) / x5.b(x) <= x5.b(x6) / x5.b(x4))
					{
						x7 = x3;
						x5 x8 = x5.a(x5.b(x3) * (x5.b(x4) / x5.b(x)));
						value = (x5.c(x8, x5) ? x8 : x5);
					}
					if (x5.b(x3) / x5.b(x) > x5.b(x6) / x5.b(x4))
					{
						value = x6;
						x5 x9 = x5.a(x5.b(x6) * (x5.b(x) / x5.b(x4)));
						x7 = (x5.c(x9, x2) ? x9 : x2);
					}
				}
				if (x5.d(x, x2) && x5.d(x4, x5) && x5.c(x2, x5.c()) && x5.c(x5, x5.c()))
				{
					if (x5.b(x2) / x5.b(x) <= x5.b(x5) / x5.b(x4))
					{
						value = x5;
						x5 x9 = x5.a(x5.b(x5) * (x5.b(x) / x5.b(x4)));
						x7 = (x5.d(x3, x9) ? x3 : x9);
					}
					if (x5.b(x2) / x5.b(x) > x5.b(x5) / x5.b(x4))
					{
						x7 = x2;
						x5 x8 = x5.a(x5.b(x2) * (x5.b(x4) * x5.b(x)));
						value = (x5.d(x6, x8) ? x6 : x8);
					}
				}
				if (x5.d(x, x2) && x5.c(x4, x6) && x5.c(x2, x5.c()) && x5.c(x6, x5.c()))
				{
					x7 = x2;
					value = x6;
				}
				if (x5.c(x, x3) && x5.d(x4, x5) && x5.c(x3, x5.c()) && x5.c(x5, x5.c()))
				{
					x7 = x3;
					value = x5;
				}
			}
			else
			{
				if (flag)
				{
					if (flag3 && x5.d(x3, x))
					{
						x7 = x3;
					}
					else if (flag2 && x5.c(x2, x))
					{
						x7 = x2;
					}
					else
					{
						x7 = x;
					}
					flag8 = true;
				}
				else if (!flag && flag3)
				{
					x7 = x3;
					flag8 = true;
				}
				else if (!flag && !flag3 && flag2)
				{
					x7 = x2;
					flag8 = true;
				}
				if (flag4)
				{
					if (flag5 && flag6 && x5.c(x5, x4) && x5.c(x5, x6))
					{
						value = x5;
					}
					else if (flag6 && x5.d(x6, x4) && x5.c(x6, x5.c()))
					{
						value = x6;
					}
					else if (flag5 && x5.c(x5, x4))
					{
						value = x5;
					}
					else
					{
						value = x4;
					}
					flag7 = true;
				}
				else if (!flag4 && flag6)
				{
					value = x6;
					flag7 = true;
				}
				else if (!flag4 && !flag6 && flag5)
				{
					value = x5;
					flag7 = true;
				}
			}
			if (this.a.c5().am() != null || flag8)
			{
				this.a.c5().j(new x5?(x7));
				this.a.l(x7);
			}
			if (this.a.c5().v() != null || flag7)
			{
				this.a.c5().i(new x5?(value));
			}
		}

		// Token: 0x060012AF RID: 4783 RVA: 0x000D34F0 File Offset: 0x000D24F0
		private void a(x5 A_0, ref bool A_1, ref bool A_2)
		{
			lk lk = this.a.c5();
			if (lk.am() != null || (lk.ap() == i2.j && lk.an()))
			{
				i2 i = lk.ap();
				if (i != i2.b)
				{
					if (i == i2.j)
					{
						this.a.dh();
						lk.d(i2.d);
						A_2 = true;
					}
				}
				else
				{
					A_0 = this.a(this.a);
					x5 value = x5.a(x5.b(A_0) * (x5.b(lk.am().Value) / 100f));
					lk.j(new x5?(value));
					lk.d(i2.d);
					lk.o(false);
					A_1 = true;
				}
			}
			if (lk.ae())
			{
				i2 i = lk.at();
				if (i == i2.b)
				{
					A_0 = this.a(this.a);
					x5 a_ = x5.a(x5.b(A_0) * (x5.b(lk.@as()) / 100f));
					lk.d(a_);
					lk.f(i2.d);
				}
			}
			if (lk.ad())
			{
				i2 i = lk.ar();
				if (i == i2.b)
				{
					A_0 = this.a(this.a);
					x5 a_2 = x5.a(x5.b(A_0) * (x5.b(lk.aq()) / 100f));
					lk.c(a_2);
					lk.e(i2.d);
				}
			}
		}

		// Token: 0x060012B0 RID: 4784 RVA: 0x000D3694 File Offset: 0x000D2694
		private x5 a(k0 A_0)
		{
			int num = this.a.dg();
			x5 x;
			if (num != 11228793)
			{
				if (A_0.c5().q() == g6.c)
				{
					x = A_0.dr().aq();
				}
				else
				{
					x = A_0.dr().bi();
				}
				x = x5.e(x, ((k0)A_0.dr()).aa());
			}
			else
			{
				x = A_0.bi();
			}
			return x;
		}

		// Token: 0x060012B1 RID: 4785 RVA: 0x000D3710 File Offset: 0x000D2710
		private void a(x5 A_0, ref bool A_1)
		{
			lk lk = this.a.c5();
			bool flag = false;
			if (lk.v() != null)
			{
				i2 i = lk.ah();
				if (i != i2.b)
				{
					if (i == i2.j)
					{
						lk.i(new x5?(A_0));
						lk.a(i2.d);
						A_1 = true;
					}
				}
				else
				{
					A_0 = this.a(this.a, ref flag);
					if (flag)
					{
						x5 value = x5.a(x5.b(A_0) * (x5.b(lk.v().Value) / 100f));
						lk.i(new x5?(value));
						lk.a(i2.d);
					}
					else
					{
						lk.i(null);
						lk.a(i2.a);
					}
					lk.j(false);
				}
			}
			if (lk.ag())
			{
				i2 i = lk.al();
				if (i == i2.b)
				{
					A_0 = this.a(this.a, ref flag);
					if (flag)
					{
						x5 a_ = x5.a(x5.b(A_0) * (x5.b(lk.ak()) / 100f));
						lk.b(a_);
						lk.c(i2.d);
					}
				}
			}
			if (lk.ag())
			{
				i2 i = lk.aj();
				if (i == i2.b)
				{
					A_0 = this.a(this.a, ref flag);
					if (flag)
					{
						x5 a_2 = x5.a(x5.b(A_0) * (x5.b(lk.ai()) / 100f));
						lk.a(a_2);
						lk.b(i2.d);
					}
				}
			}
		}

		// Token: 0x060012B2 RID: 4786 RVA: 0x000D38E8 File Offset: 0x000D28E8
		private x5 a(k0 A_0, ref bool A_1)
		{
			int num = this.a.dg();
			x5 x;
			if (num != 11228793)
			{
				lk lk = A_0.dr().c5();
				if (lk.v() != null && x5.c(lk.v().Value, x5.c()))
				{
					x = lk.v().Value;
				}
				else
				{
					x5 x2 = (A_0.dr().c5().a() != null) ? A_0.dr().c5().a().Value : x5.c();
					x5 x3 = (A_0.dr().c5().i() != null) ? A_0.dr().c5().i().Value : x5.c();
					if (x5.c(x2, x5.c()) && x5.c(x3, x5.c()))
					{
						x = x5.e(x5.e(A_0.bl(), x2), x3);
					}
					else
					{
						x = A_0.dr().bj();
					}
					x = x5.e(x, ((k0)A_0.dr()).ab());
				}
				A_1 = true;
			}
			else
			{
				x = A_0.bj();
				A_1 = true;
			}
			return x;
		}

		// Token: 0x060012B3 RID: 4787 RVA: 0x000D3A60 File Offset: 0x000D2A60
		internal void a(x5 A_0, x5 A_1)
		{
			lk lk = this.a.c5();
			bool flag = false;
			if (lk.v() != null && lk.ah() != i2.j)
			{
				if (lk.ah() == i2.b)
				{
					A_1 = this.a();
					this.a.m(x5.a(x5.b(A_1) * (x5.b(lk.v().Value) / 100f)));
					lk.i(new x5?(this.a.ar()));
					lk.a(i2.d);
					flag = true;
				}
				else if (x5.g(lk.v().Value, x5.c()))
				{
					this.a.m(lk.v().Value);
				}
				this.a(A_0);
				switch (lk.q())
				{
				case g6.a:
				case g6.d:
					goto IL_14C;
				case g6.c:
					this.a(this.a.ar(), this.a.ar(), true, false);
					goto IL_14C;
				}
				this.a(this.a.ar(), this.a.ar(), false, false);
				IL_14C:
				this.a.g(this.k());
				int num = this.a.dg();
				if (num <= 3418)
				{
					if (num != 1946 && num != 3034 && num != 3418)
					{
						goto IL_1FB;
					}
				}
				else if (num <= 442866842)
				{
					if (num != 144937050 && num != 442866842)
					{
						goto IL_1FB;
					}
				}
				else if (num != 718642778 && num != 889490394)
				{
					goto IL_1FB;
				}
				if (!flag)
				{
					k0 k = this.a;
					k.m(x5.f(k.ar(), x5.f(lk.e().a(), lk.e().c())));
				}
				goto IL_224;
				IL_1FB:
				if (!flag)
				{
					k0 k2 = this.a;
					k2.m(x5.f(k2.ar(), this.a.ab()));
				}
				IL_224:;
			}
			else if (lk.v() != null && lk.ah() == i2.j)
			{
				this.a(A_0);
				switch (lk.q())
				{
				case g6.a:
				case g6.d:
					goto IL_2B3;
				case g6.c:
					this.a(A_1, this.a.ar(), true, true);
					goto IL_2B3;
				}
				this.a(this.a.ar(), this.a.ar(), false, true);
				IL_2B3:
				this.a.g(this.k());
			}
		}

		// Token: 0x060012B4 RID: 4788 RVA: 0x000D3D34 File Offset: 0x000D2D34
		private void a(int A_0, kz A_1)
		{
			A_1.l(A_0);
			A_1.ai(this.a.bj());
			A_1.l(this.a.bf());
			A_1.m(this.a.bg());
			A_1.n(this.a.bh());
			A_1.al(this.a.cz());
			A_1.o(this.a.cm());
			A_1.ad(this.a.co());
		}

		// Token: 0x060012B5 RID: 4789 RVA: 0x000D3DC8 File Offset: 0x000D2DC8
		private void b(kz A_0)
		{
			if (this.c())
			{
				A_0.a(this.a.bv());
			}
			else
			{
				A_0.a(this.a.c8());
			}
			if (this.a.dg() != 1)
			{
				if (!this.a.c5().aa())
				{
					if (A_0.c5().q() == g6.a && this.a.c5().q() == g6.a)
					{
						A_0.dr(this.a.dq());
					}
					else if (this.a.c5().q() != g6.a)
					{
						A_0.dr(this.a.bw());
					}
					else
					{
						A_0.dr(this.a.dq());
					}
				}
				else
				{
					A_0.dr(this.a.bw());
				}
			}
			else
			{
				A_0.dr(this.a.dq());
			}
		}

		// Token: 0x060012B6 RID: 4790 RVA: 0x000D3EE4 File Offset: 0x000D2EE4
		private bool c()
		{
			return this.a.c5().n() == g3.c && this.a.c5().q() != g6.c && this.a.dg() != 3034 && this.a.dg() != 3418;
		}

		// Token: 0x060012B7 RID: 4791 RVA: 0x000D3F4C File Offset: 0x000D2F4C
		private void a(ref kz A_0, int A_1)
		{
			x5 a_ = ((A_0.dr().c5().v() != null) ? A_0.dr().c5().v() : new x5?(x5.c())).Value;
			x5 a_2 = ((A_0.dr().c5().am() != null) ? A_0.dr().c5().am() : new x5?(x5.c())).Value;
			if (x5.h(a_, x5.c()))
			{
				a_ = A_0.dr().ar();
			}
			if (x5.h(a_2, x5.c()))
			{
				a_2 = A_0.dr().aq();
			}
			if (A_1 <= 7021096)
			{
				if (A_1 != 136794)
				{
					if (A_1 == 7021096)
					{
						A_0.c5().b(new x5?(x5.a(x5.b(a_2) * x5.b(A_0.c5().b().Value) / 100f)));
						A_0.c5().j(i2.d);
					}
				}
				else
				{
					A_0.c5().a(new x5?(x5.a(x5.b(a_) * x5.b(A_0.c5().a().Value) / 100f)));
					A_0.c5().g(i2.d);
				}
			}
			else if (A_1 != 426354259)
			{
				if (A_1 == 448574430)
				{
					A_0.c5().h(new x5?(x5.a(x5.b(a_2) * x5.b(A_0.c5().s().Value) / 100f)));
					A_0.c5().h(i2.d);
				}
			}
			else
			{
				A_0.c5().c(new x5?(x5.a(x5.b(a_) * x5.b(A_0.c5().h().Value) / 100f)));
				A_0.c5().i(i2.d);
			}
		}

		// Token: 0x060012B8 RID: 4792 RVA: 0x000D41A4 File Offset: 0x000D31A4
		private bool a(kz A_0, x5 A_1, bool A_2, int A_3)
		{
			bool result = A_2;
			if (A_3 == 0)
			{
				this.a.r(A_0.b0());
				int num = A_0.dg();
				if (num != 46415)
				{
					this.a.aq(A_0.b2());
					if (!A_0.b1())
					{
						A_2 = true;
					}
				}
				else
				{
					this.a.aq(A_1);
					A_2 = true;
				}
			}
			else if (A_0.c5().u() && A_0.c5().t() == g2.c && A_0.c5().n() == g3.c)
			{
				int num = A_0.dg();
				if (num != 46415)
				{
					if (!A_0.b0())
					{
						k0 k = this.a;
						k.aq(x5.f(k.b2(), A_0.b2()));
						result = !A_0.b1();
					}
					else
					{
						result = false;
					}
				}
				else
				{
					bool flag;
					if (this.a.c5().am() != null)
					{
						x5 a_ = x5.f(this.a.b2(), A_1);
						x5? x = this.a.c5().am();
						flag = (x == null || !x5.c(a_, x.GetValueOrDefault()));
					}
					else
					{
						flag = true;
					}
					if (!flag)
					{
						result = false;
					}
					else
					{
						k0 k2 = this.a;
						k2.aq(x5.f(k2.b2(), A_1));
						result = true;
					}
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060012B9 RID: 4793 RVA: 0x000D4354 File Offset: 0x000D3354
		private x5 a(kz A_0, x5 A_1, x5 A_2, ref x5 A_3, bool A_4, bool A_5)
		{
			if (A_4 && !A_5 && !A_0.b0())
			{
				int num = A_0.dg();
				if (num != 46415)
				{
					A_2 = x5.f(A_2, A_0.b2());
					if (x5.d(A_2, A_1))
					{
						A_2 = A_1;
					}
				}
				else
				{
					A_2 = x5.f(A_2, A_1);
				}
			}
			else
			{
				if (x5.c(A_2, A_1) && x5.c(A_2, A_3))
				{
					A_3 = A_2;
				}
				A_2 = A_1;
			}
			return A_2;
		}

		// Token: 0x060012BA RID: 4794 RVA: 0x000D43EC File Offset: 0x000D33EC
		private void a(kz A_0)
		{
			A_0.dw(this.a.dv());
			A_0.a(this.a.b6());
			A_0.d2(this.a.d1());
		}

		// Token: 0x060012BB RID: 4795 RVA: 0x000D4428 File Offset: 0x000D3428
		private x5 b()
		{
			x5 x = x5.c();
			if (this.a.c5().f().i())
			{
				x = this.a.c5().f().d();
			}
			if (this.a.c5().f().j())
			{
				x = x5.f(x, this.a.c5().f().b());
			}
			return x;
		}

		// Token: 0x060012BC RID: 4796 RVA: 0x000D44AC File Offset: 0x000D34AC
		private void b(Hashtable A_0, k0 A_1)
		{
			x5 x = x5.c();
			x5 x2 = A_1.ar();
			mt a_ = A_1.n();
			nw nw = A_1.dv();
			float num = 0f;
			if (nw.f() != null)
			{
				num = x5.b(nw.f().Value);
			}
			x5 a_2 = x5.c();
			if (nw.h() != il.b)
			{
				a_2 = x5.a(num * (float)(A_0.Count - 1));
			}
			foreach (object obj in A_0)
			{
				x = x5.f(x, (x5)((DictionaryEntry)obj).Value);
			}
			x = x5.f(x, a_2);
			if (x5.d(x, x2))
			{
				x5 a_3 = x5.e(x2, x);
				if (x5.c(a_3, x5.c()))
				{
					int num2 = this.b(A_1.n());
					if (num2 == 0 || num2 == A_0.Count)
					{
						x5 a_4 = x5.a(a_3, A_0.Count);
						this.a(a_, a_4);
					}
					else
					{
						x5 a_4 = x5.a(a_3, num2);
						int num3 = 0;
						this.a(a_, a_4, ref num3);
					}
					this.a(A_1, A_0);
				}
			}
		}

		// Token: 0x060012BD RID: 4797 RVA: 0x000D464C File Offset: 0x000D364C
		private void a(Hashtable A_0, k0 A_1)
		{
			x5 x = x5.c();
			x5 x2 = A_1.ar();
			mt a_ = A_1.n();
			nw nw = A_1.dv();
			lk lk = A_1.c5();
			x5[] array = ((nv)A_1).k();
			float num = 0f;
			if (nw.f() != null)
			{
				num = x5.b(nw.f().Value);
			}
			x5 a_2 = x5.c();
			if (nw.h() != il.b)
			{
				a_2 = x5.a(num * (float)(A_0.Count + 1));
			}
			foreach (object obj in A_0)
			{
				x = x5.f(x, (x5)((DictionaryEntry)obj).Value);
			}
			x5 x3 = x5.c();
			il il = nw.h();
			if (il != il.b)
			{
				x3 = x5.f(x3, x5.f(lk.a2(), lk.a3()));
				x3 = x5.f(x3, a_2);
			}
			else
			{
				x3 = x5.f(x3, x5.f(lk.a5(), lk.a4()));
			}
			if (A_1.ah())
			{
				if (x5.d(x, x2))
				{
					x5 x4 = x5.e(x5.e(x2, x3), x);
					if (x5.c(x4, x5.c()))
					{
						this.a(a_, x, x4, num);
					}
				}
				else if (x5.c(x, x2))
				{
					x2 = x5.f(x, x3);
					A_1.m(x2);
				}
			}
			else if (x5.d(x, x2))
			{
				x5 x4 = x5.e(x5.e(x5.e(x5.e(x2, x3), x), array[0]), array[1]);
				if (x5.c(x4, x5.c()))
				{
					int num2 = this.b(A_1.n());
					if (num2 == 0 || num2 == A_0.Count)
					{
						x5 a_3 = x5.a(x4, A_0.Count);
						this.a(a_, a_3);
					}
					else
					{
						x5 a_3 = x5.a(x4, num2);
						int num3 = 0;
						this.a(a_, a_3, ref num3);
					}
				}
			}
		}

		// Token: 0x060012BE RID: 4798 RVA: 0x000D48F8 File Offset: 0x000D38F8
		private int b(mt A_0)
		{
			int num = 0;
			if (A_0 != null)
			{
				mu mu = A_0.c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					if (ms.l() != null)
					{
						mr mr = ms.l().a();
						while (mr != null && mr.b() != null)
						{
							k0 k = (k0)mr.b();
							int num2 = k.dg();
							if (num2 <= 442866842)
							{
								if (num2 == 1946 || num2 == 442866842)
								{
									goto IL_96;
								}
							}
							else if (num2 == 718642778 || num2 == 889490394)
							{
								goto IL_96;
							}
							IL_D2:
							mr = mr.c();
							continue;
							IL_96:
							if (k.c5().v() == null && k.n() != null)
							{
								num += k.n().f();
							}
							goto IL_D2;
						}
					}
					mu = mu.b();
				}
			}
			return num;
		}

		// Token: 0x060012BF RID: 4799 RVA: 0x000D4A28 File Offset: 0x000D3A28
		private void a(mt A_0, x5 A_1, ref int A_2)
		{
			if (A_0 != null)
			{
				mu mu = A_0.c();
				x5 x = x5.c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					if (ms.l() != null)
					{
						mr mr = ms.l().a();
						while (mr != null && mr.b() != null)
						{
							k0 k = (k0)mr.b();
							int num = k.dg();
							if (num <= 3418)
							{
								if (num != 1946)
								{
									if (num == 3034 || num == 3418)
									{
										k.m(A_1);
									}
								}
								else if (k.c5().v() == null)
								{
									k0 k2 = k;
									k2.m(x5.f(k2.ar(), A_1));
									if (((nx)k).d1() > 0 && A_2 > 0)
									{
										x = x5.f(x, A_1);
										ms ms2 = ms;
										ms2.o(x5.f(ms2.ag(), x));
										A_2++;
									}
									this.a(k.n(), k.ar(), ref A_2);
								}
							}
							else if (num == 442866842 || num == 718642778 || num == 889490394)
							{
								if (k.c5().v() == null)
								{
									this.a(k.n(), A_1, ref A_2);
									k0 k3 = k;
									k3.m(x5.f(k3.ar(), x5.a((float)k.n().f() * x5.b(A_1))));
								}
							}
							mr = mr.c();
						}
					}
					mu = mu.b();
				}
			}
		}

		// Token: 0x060012C0 RID: 4800 RVA: 0x000D4C38 File Offset: 0x000D3C38
		private void a(mt A_0, x5 A_1)
		{
			if (A_0 != null)
			{
				mu mu = A_0.c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					if (ms.l() != null)
					{
						mr mr = ms.l().a();
						while (mr != null && mr.b() != null)
						{
							k0 k = (k0)mr.b();
							int num = k.dg();
							if (num <= 3418)
							{
								if (num != 1946)
								{
									if (num == 3034 || num == 3418)
									{
										k.m(A_1);
									}
								}
								else
								{
									k0 k2 = k;
									k2.m(x5.f(k2.ar(), A_1));
									if (((nx)k).d1() > 0)
									{
										this.c = x5.f(this.c, A_1);
										ms ms2 = ms;
										ms2.o(x5.f(ms2.ag(), this.c));
									}
									this.a(k.n(), k.ar());
								}
							}
							else if (num == 442866842 || num == 718642778 || num == 889490394)
							{
								if (k.n() != null)
								{
									this.a(k.n(), A_1);
									k0 k3 = k;
									k3.m(x5.f(k3.ar(), x5.a((float)k.n().f() * x5.b(A_1))));
								}
							}
							mr = mr.c();
						}
					}
					mu = mu.b();
				}
			}
		}

		// Token: 0x060012C1 RID: 4801 RVA: 0x000D4E04 File Offset: 0x000D3E04
		private void a(mt A_0, x5 A_1, x5 A_2, float A_3)
		{
			if (A_0 != null)
			{
				mu mu = A_0.c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					if (ms.l() != null)
					{
						mr mr = ms.l().a();
						while (mr != null && mr.b() != null)
						{
							k0 k = (k0)mr.b();
							int num = k.dg();
							if (num <= 3418)
							{
								if (num != 1946)
								{
									if (num == 3034 || num == 3418)
									{
										int num2 = ((n5)k.db()).z();
										k.m(x5.a(x5.b(A_1) * (float)num2));
										if (num2 > 1)
										{
											k0 k2 = k;
											k2.m(x5.f(k2.ar(), x5.a(A_3 * (float)(num2 - 1))));
										}
									}
								}
								else
								{
									float num3 = x5.b(k.ar()) * (100f / x5.b(A_1));
									x5 a_ = x5.a(x5.b(A_2) * (num3 / 100f));
									k0 k3 = k;
									k3.m(x5.f(k3.ar(), a_));
									if (((nx)k).d1() > 0)
									{
										this.d = x5.f(this.d, a_);
										((nx)k).a(this.d);
									}
									this.a(k.n(), k.ar(), A_2, A_3);
								}
							}
							else if (num == 442866842 || num == 718642778 || num == 889490394)
							{
								this.a(k.n(), A_1, A_2, A_3);
							}
							mr = mr.c();
						}
					}
					mu = mu.b();
				}
			}
		}

		// Token: 0x060012C2 RID: 4802 RVA: 0x000D5020 File Offset: 0x000D4020
		private void a(k0 A_0, Hashtable A_1)
		{
			mt mt = A_0.n();
			if (mt != null)
			{
				mu mu = mt.c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					if (ms.l() != null)
					{
						mr mr = ms.l().a();
						while (mr != null && mr.b() != null)
						{
							int num = mr.b().dg();
							if (num <= 442866842)
							{
								if (num != 1946)
								{
									if (num == 442866842)
									{
										goto IL_109;
									}
								}
								else if (A_1.ContainsKey(mr.b().d1()))
								{
									A_1[mr.b().d1()] = mr.b().ar();
								}
								else
								{
									A_1.Add(mr.b().d1(), mr.b().ar());
								}
							}
							else if (num == 718642778 || num == 889490394)
							{
								goto IL_109;
							}
							IL_11E:
							mr = mr.c();
							continue;
							IL_109:
							this.a((k0)mr.b(), A_1);
							goto IL_11E;
						}
					}
					mu = mu.b();
				}
			}
		}

		// Token: 0x060012C3 RID: 4803 RVA: 0x000D5198 File Offset: 0x000D4198
		private void a(mt A_0, Hashtable A_1)
		{
			if (A_0 != null)
			{
				mu mu = A_0.c(A_0.f() - 1);
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					if (ms.l() != null)
					{
						mr mr = ms.l().a();
						while (mr != null && mr.b() != null)
						{
							k0 k = (k0)mr.b();
							int num = k.dg();
							if (num <= 442866842)
							{
								if (num != 1946)
								{
									if (num == 442866842)
									{
										goto IL_B9;
									}
								}
								else
								{
									List<ne> a_ = ((nx)k).c();
									this.a(A_1, k, a_, A_0.c());
								}
							}
							else if (num == 718642778 || num == 889490394)
							{
								goto IL_B9;
							}
							IL_102:
							mr = mr.c();
							continue;
							IL_B9:
							if (!k.c1())
							{
								this.a(k.n(), A_1);
							}
							x5 a_2 = this.a(k.n());
							if (x5.c(a_2, k.ar()))
							{
								k.m(a_2);
							}
							goto IL_102;
						}
					}
					mu = mu.c();
				}
			}
		}

		// Token: 0x060012C4 RID: 4804 RVA: 0x000D52F4 File Offset: 0x000D42F4
		private x5 a(mt A_0)
		{
			x5 x = x5.c();
			if (A_0 != null)
			{
				mu mu = A_0.c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					if (ms.l() != null)
					{
						mr mr = ms.l().a();
						if (mr != null && mr.b() != null)
						{
							k0 k = (k0)mr.b();
							int num = k.dg();
							if (num == 1946)
							{
								x = x5.f(x, k.ar());
							}
						}
					}
					mu = mu.b();
				}
			}
			return x;
		}

		// Token: 0x060012C5 RID: 4805 RVA: 0x000D53BC File Offset: 0x000D43BC
		private void a(Hashtable A_0, k0 A_1, List<ne> A_2, mu A_3)
		{
			x5 a_ = x5.c();
			if (A_1.dv().f() != null)
			{
				a_ = A_1.dv().f().Value;
			}
			foreach (ne ne in A_2)
			{
				int num = ne.c();
				x5 x = this.a(A_0, ne.a(), num, a_);
				if (x5.d(ne.d(), x))
				{
					ne.a(x);
					ne.e().m(x);
				}
				else
				{
					x5 x2 = x5.e(ne.d(), x);
					if (x5.c(x2, x5.c()))
					{
						if (num > A_0.Count || !A_0.ContainsKey(ne.a() + num - 1))
						{
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
							x2 = x5.a(x5.b(x2) / (float)num2);
						}
						else
						{
							x2 = x5.a(x5.b(x2) / (float)num);
						}
						this.a(A_0, x2, A_3, ne.a(), num, ne.b());
					}
				}
			}
		}

		// Token: 0x060012C6 RID: 4806 RVA: 0x000D5590 File Offset: 0x000D4590
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

		// Token: 0x060012C7 RID: 4807 RVA: 0x000D55F8 File Offset: 0x000D45F8
		private void a(Hashtable A_0, x5 A_1, mu A_2, int A_3, int A_4, int A_5)
		{
			int num = A_3 + A_4;
			while (A_2 != null && A_2.a() != null)
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
									if (k.d1() != A_3 || ((nt)k).h() != A_5)
									{
										int num3 = ((n5)k.db()).z();
										if (num3 == 1)
										{
											mr.b().m((x5)A_0[k.d1()]);
										}
										else if (k.d1() == A_3)
										{
											if (num3 < A_4)
											{
												kz kz = mr.b();
												kz.m(x5.f(kz.ar(), A_1));
											}
										}
										else
										{
											kz kz2 = mr.b();
											kz2.m(x5.f(kz2.ar(), A_1));
										}
									}
								}
							}
							else if (k.d1() >= A_3 && k.d1() < num)
							{
								if (k.d1() > A_3)
								{
									ms ms2 = ms;
									ms2.o(x5.f(ms2.ag(), A_1));
								}
								x5 x = x5.f(A_1, (x5)A_0[k.d1()]);
								A_0[k.d1()] = x;
								k.m(x);
								this.a(A_0, A_1, k.n().c(), A_3, num, A_5);
							}
						}
						else if (num2 == 442866842 || num2 == 718642778 || num2 == 889490394)
						{
							this.a(A_0, A_1, k.n().c(), A_3, num, A_5);
						}
						mr = mr.c();
					}
				}
				A_2 = A_2.b();
			}
		}

		// Token: 0x060012C8 RID: 4808 RVA: 0x000D5888 File Offset: 0x000D4888
		private void b(x5 A_0, x5 A_1, bool A_2, bool A_3)
		{
			lk lk = this.a.c5();
			x5? x = (lk.b() != null) ? lk.b() : null;
			x5? x2 = (lk.s() != null) ? lk.s() : null;
			bool a_ = false;
			i2 i = lk.ax();
			if (i != i2.j)
			{
				i = lk.av();
				if (i != i2.j)
				{
					x = new x5?(lk.b().Value);
					x2 = new x5?(lk.s().Value);
					lk.g(x2);
					if (A_3)
					{
						if (x != null)
						{
							k0 k = this.a;
							k.l(x5.e(k.aq(), x.Value));
						}
						if (x2 != null)
						{
							k0 k2 = this.a;
							k2.l(x5.e(k2.aq(), x2.Value));
						}
					}
				}
				else
				{
					x = new x5?(lk.b().Value);
					lk.f(x);
					if (A_3 && x != null)
					{
						k0 k3 = this.a;
						k3.l(x5.e(k3.aq(), x.Value));
					}
					lk.h(x2);
				}
			}
			else
			{
				i = lk.av();
				if (i != i2.j)
				{
					lk.b(x);
					x2 = new x5?(lk.s().Value);
					lk.g(x2);
					lk.f(x);
					if (A_3 && x2 != null)
					{
						k0 k4 = this.a;
						k4.l(x5.e(k4.aq(), x2.Value));
					}
				}
				else
				{
					lk.b(x);
					lk.h(x2);
					a_ = A_2;
				}
			}
			this.b(A_0, A_1, x, x2, a_);
		}

		// Token: 0x060012C9 RID: 4809 RVA: 0x000D5ABC File Offset: 0x000D4ABC
		private void a(x5 A_0, x5 A_1, bool A_2, bool A_3)
		{
			lk lk = this.a.c5();
			x5? x = (lk.a() != null) ? lk.a() : null;
			x5? x2 = (lk.h() != null) ? lk.h() : null;
			bool a_ = false;
			i2 i = lk.au();
			if (i != i2.j)
			{
				i = lk.aw();
				if (i != i2.j)
				{
					x = lk.a();
					x2 = lk.h();
					if (A_3 && x != null && x2 != null)
					{
						k0 k = this.a;
						k.m(x5.e(k.ar(), x5.f(x.Value, x2.Value)));
					}
				}
				else
				{
					x = lk.a();
					if (A_3 && x != null)
					{
						k0 k2 = this.a;
						k2.m(x5.e(k2.ar(), x.Value));
					}
					lk.c(x2);
					a_ = A_2;
				}
				if (lk.au() == i2.b)
				{
					x = lk.a();
				}
			}
			else
			{
				i = lk.aw();
				if (i != i2.j)
				{
					if (lk.aw() == i2.b)
					{
						if (lk.v() != null)
						{
							lk.c(new x5?(this.a(x5.b(lk.v().Value), lk.h().Value, lk.aw())));
						}
						else
						{
							lk.c(new x5?(this.a(x5.b(A_1), lk.h().Value, lk.aw())));
						}
						lk.i(i2.d);
					}
					lk.a(x);
					x2 = lk.h();
					lk.d(x2);
					if (A_3 && x2 != null)
					{
						k0 k3 = this.a;
						k3.m(x5.e(k3.ar(), x2.Value));
					}
					a_ = A_2;
				}
				else
				{
					lk.a(x);
					lk.c(x2);
					a_ = A_2;
				}
			}
			this.a(A_0, A_1, x, x2, a_);
		}

		// Token: 0x060012CA RID: 4810 RVA: 0x000D5D54 File Offset: 0x000D4D54
		private void a(x5 A_0)
		{
			m2 m = this.a.c5().e();
			m8 m2 = this.a.c5().f();
			float a_ = x5.b(A_0);
			i2 i = m.h();
			if (i == i2.b)
			{
				m.d(this.a(a_, m.d()));
				m.d(i2.d);
			}
			i = m.f();
			if (i == i2.b)
			{
				m.b(this.a(a_, m.b()));
				m.b(i2.d);
			}
			i = m.e();
			if (i == i2.b)
			{
				m.a(this.a(a_, m.a()));
				m.a(i2.d);
			}
			i = m.g();
			if (i == i2.b)
			{
				m.c(this.a(a_, m.c()));
				m.c(i2.d);
			}
			i = m2.h();
			if (i == i2.b)
			{
				m2.d(this.a(a_, m2.d()));
				m2.d(i2.d);
			}
			i = m2.f();
			if (i == i2.b)
			{
				m2.b(this.a(a_, m2.b()));
				m2.b(i2.d);
			}
			i = m2.e();
			if (i == i2.b)
			{
				m2.a(this.a(a_, m2.a()));
				m2.a(i2.d);
			}
			i = m2.g();
			if (i == i2.b)
			{
				m2.c(this.a(a_, m2.c()));
				m2.c(i2.d);
			}
		}

		// Token: 0x060012CB RID: 4811 RVA: 0x000D5EE8 File Offset: 0x000D4EE8
		private x5 a(float A_0, x5 A_1)
		{
			return x5.a(A_0 * (x5.b(A_1) / 100f));
		}

		// Token: 0x060012CC RID: 4812 RVA: 0x000D5F10 File Offset: 0x000D4F10
		private x5 a(float A_0, x5 A_1, i2 A_2)
		{
			x5 result = A_1;
			if (A_2 == i2.b)
			{
				result = x5.a(A_0 * (x5.b(A_1) / 100f));
			}
			return result;
		}

		// Token: 0x060012CD RID: 4813 RVA: 0x000D5F48 File Offset: 0x000D4F48
		private void b(x5 A_0, x5 A_1, x5? A_2, x5? A_3, bool A_4)
		{
			x5 a_ = x5.c();
			m2 m = this.a.c5().e();
			x5 a_2 = this.a.c5().a1();
			x5 a_3 = this.a.c5().a0();
			x5 a_4 = (A_2 != null) ? A_2.Value : x5.c();
			x5 a_5 = (A_3 != null) ? A_3.Value : x5.c();
			i2 i = m.h();
			if (i != i2.j)
			{
				if (m.f() == i2.j && this.a.c5().n() == g3.c)
				{
					if (x5.c(A_1, x5.f(x5.f(A_0, a_2), a_3)))
					{
						m.b(x5.e(A_1, x5.f(x5.f(A_0, a_2), a_3)));
					}
					else
					{
						m.b(x5.c());
					}
				}
			}
			else
			{
				i = m.f();
				if (i != i2.j)
				{
					if (this.a.c5().n() == g3.c && x5.c(A_1, x5.f(x5.f(A_0, a_2), a_3)))
					{
						m.d(x5.e(A_1, x5.f(x5.f(A_0, a_2), a_3)));
					}
					else
					{
						m.d(x5.c());
					}
				}
				else if (this.a.c5().n() == g3.c && x5.g(A_0, x5.c()) && !A_4)
				{
					a_ = x5.e(A_1, x5.f(x5.f(A_0, a_4), a_5));
					a_ = x5.a(a_, 2);
					if (x5.c(a_, x5.c()))
					{
						m.d(a_);
						m.b(a_);
					}
				}
			}
		}

		// Token: 0x060012CE RID: 4814 RVA: 0x000D6134 File Offset: 0x000D5134
		private void a(x5 A_0, x5 A_1, x5? A_2, x5? A_3, bool A_4)
		{
			x5 a_ = x5.c();
			m2 m = this.a.c5().e();
			x5 a_2 = (A_2 != null) ? A_2.Value : x5.c();
			x5 a_3 = (A_3 != null) ? A_3.Value : x5.c();
			i2 i = m.e();
			if (i != i2.j)
			{
				if (m.g() == i2.j)
				{
					m.c(x5.c());
				}
			}
			else
			{
				i = m.g();
				if (i != i2.j)
				{
					m.a(x5.c());
				}
				else if (x5.g(A_0, x5.c()) && !A_4)
				{
					a_ = x5.e(A_1, x5.f(x5.f(A_0, a_2), a_3));
					a_ = x5.a(a_, 2);
					if (x5.c(a_, x5.c()))
					{
						m.a(a_);
						m.c(a_);
					}
				}
			}
		}

		// Token: 0x060012CF RID: 4815 RVA: 0x000D623C File Offset: 0x000D523C
		private x5 a()
		{
			x5 x = x5.c();
			kz kz = this.a.dr();
			while (x5.h(x, x5.c()) && kz != null)
			{
				if (kz.c5().v() != null)
				{
					x = kz.c5().v().Value;
				}
				else
				{
					x = x5.c();
				}
				kz = kz.dr();
			}
			if (x5.h(x, x5.c()))
			{
				x = this.a.bl();
			}
			return x;
		}

		// Token: 0x060012D0 RID: 4816 RVA: 0x000D62E4 File Offset: 0x000D52E4
		internal void b(x5 A_0, x5 A_1)
		{
			if (!this.b)
			{
				this.b = true;
				bool flag = false;
				bool flag2 = false;
				bool a_ = false;
				bool a_2 = false;
				lk lk = this.a.c5();
				this.a(A_0, ref flag, ref a_);
				this.a(A_1, ref a_2);
				this.d();
				if (x5.g(this.a.aq(), x5.c()))
				{
					this.a(this.a.aq());
				}
				else
				{
					this.a(A_0);
				}
				if (this.a.de())
				{
					switch (lk.q())
					{
					case g6.c:
						this.b(this.a.aq(), this.a.bi(), true, a_);
						this.a(this.a.ar(), this.a.ar(), true, a_2);
						break;
					case g6.d:
						break;
					default:
						this.b(this.a.aq(), x5.e(this.a.bi(), this.a.aa()), false, a_);
						this.a(this.a.ar(), this.a.ar(), false, a_2);
						break;
					}
				}
				this.a.f(this.j());
				this.a.g(this.k());
				int num = this.a.dg();
				if (num <= 3418)
				{
					if (num <= 1977)
					{
						if (num != 1946)
						{
							if (num != 1977)
							{
								goto IL_22C;
							}
							goto IL_280;
						}
					}
					else if (num != 3034 && num != 3418)
					{
						goto IL_22C;
					}
				}
				else if (num <= 442866842)
				{
					if (num != 144937050 && num != 442866842)
					{
						goto IL_22C;
					}
				}
				else if (num != 718642778 && num != 889490394)
				{
					goto IL_22C;
				}
				if (!flag2)
				{
					k0 k = this.a;
					k.m(x5.f(k.ar(), x5.f(lk.e().a(), lk.e().c())));
				}
				goto IL_280;
				IL_22C:
				if (!flag)
				{
					k0 k2 = this.a;
					k2.l(x5.f(k2.aq(), this.a.aa()));
				}
				if (!flag2)
				{
					k0 k3 = this.a;
					k3.m(x5.f(k3.ar(), this.a.ab()));
				}
				IL_280:;
			}
		}

		// Token: 0x060012D1 RID: 4817 RVA: 0x000D6572 File Offset: 0x000D5572
		internal void c(x5 A_0, x5 A_1)
		{
			this.a.f(this.j());
			this.a.g(this.k());
			this.b(A_0, A_1);
		}

		// Token: 0x060012D2 RID: 4818 RVA: 0x000D65A4 File Offset: 0x000D55A4
		internal void d(x5 A_0, x5 A_1)
		{
			x5 x = x5.c();
			if (!this.a.c3())
			{
				A_0 = (x5.g(A_0, x5.c()) ? A_0 : x);
			}
			lk lk = this.a.c5();
			this.a.m(A_0);
			x5 a_ = x5.e(A_1, A_0);
			x5 x2 = x5.c();
			int num = this.a.dg();
			if (num <= 3418)
			{
				if (num == 1946)
				{
					goto IL_3BD;
				}
				if (num != 3034 && num != 3418)
				{
					goto IL_3DA;
				}
			}
			else if (num <= 442866842)
			{
				if (num != 144937050)
				{
					if (num != 442866842)
					{
						goto IL_3DA;
					}
					goto IL_3BD;
				}
			}
			else
			{
				if (num != 718642778 && num != 889490394)
				{
					goto IL_3DA;
				}
				goto IL_3BD;
			}
			bool flag = this.a.dv().h() == il.b;
			if (x5.c(A_0, x5.c()) && this.a.n().e() != null)
			{
				if (this.a.s() != this.a.t())
				{
					if (this.a.s())
					{
						if (flag)
						{
							x2 = x5.f(x2, lk.a4());
						}
						else
						{
							x2 = x5.f(x2, lk.a3());
						}
						if (this.a.dg() != 144937050 && !lk.f().l())
						{
							x2 = x5.f(x2, lk.f().c());
						}
					}
					else if (this.a.t())
					{
						if (flag)
						{
							x2 = x5.f(x2, lk.a5());
						}
						else
						{
							x2 = x5.f(x2, lk.a2());
						}
						if (this.a.dg() != 144937050 && !lk.f().k())
						{
							x2 = x5.f(x2, lk.f().a());
						}
					}
				}
			}
			else if (this.a.s())
			{
				if (flag)
				{
					x2 = x5.f(x2, lk.a4());
				}
				else
				{
					x2 = x5.f(x2, lk.a3());
				}
				if (this.a.dg() != 144937050 && !lk.f().l())
				{
					x2 = x5.f(x2, lk.f().c());
				}
			}
			else if (this.a.t())
			{
				if (flag)
				{
					x2 = x5.f(x2, lk.a5());
				}
				else
				{
					x2 = x5.f(x2, lk.a2());
				}
				if (this.a.dg() != 144937050 && !lk.f().k())
				{
					x2 = x5.f(x2, lk.f().a());
				}
			}
			else
			{
				if (flag)
				{
					x2 = x5.f(x2, x5.f(lk.a5(), lk.a4()));
				}
				else
				{
					x2 = x5.f(x2, x5.f(lk.a2(), lk.a3()));
				}
				if (this.a.dg() != 144937050)
				{
					if (!this.a.c5().g())
					{
						x2 = x5.f(x2, lk.f().a());
						x2 = x5.f(x2, lk.f().c());
					}
				}
			}
			goto IL_4E6;
			IL_3BD:
			x2 = x5.f(x2, x5.f(this.f(), this.h()));
			goto IL_4E6;
			IL_3DA:
			x2 = x5.f(x2, this.l());
			a_ = x5.e(a_, this.l());
			if (this.a.n().e() == null)
			{
				x5 x3 = x5.c();
				if (lk.c() != null)
				{
					x3 = x5.f(x3, lk.c().j());
				}
				if (lk.f().l())
				{
					x3 = x5.f(x3, lk.f().c());
				}
				if (x5.a(x5.e(a_, x3), x5.c()))
				{
					x3 = x5.f(x3, lk.e().c());
					x2 = x5.f(x2, x3);
				}
				else
				{
					this.a.g(false);
				}
			}
			else if (x5.d(x5.f(x5.f(x2, this.m()), A_0), A_1))
			{
				x2 = x5.f(x2, this.m());
			}
			IL_4E6:
			k0 k = this.a;
			k.m(x5.f(k.ar(), x2));
		}

		// Token: 0x060012D3 RID: 4819 RVA: 0x000D6AB0 File Offset: 0x000D5AB0
		internal x5 f()
		{
			x5 x = x5.c();
			m2 m = this.a.c5().e();
			if (!this.a.s())
			{
				x = x5.f(x, m.a());
			}
			if (!this.a.t() && this.a.n() != null && this.a.n().e() == null)
			{
				x = x5.f(x, m.c());
			}
			return x;
		}

		// Token: 0x060012D4 RID: 4820 RVA: 0x000D6B3C File Offset: 0x000D5B3C
		internal x5 g()
		{
			x5 result;
			if (!this.a.t() && this.a.n().e() == null)
			{
				result = this.a.c5().e().c();
			}
			else
			{
				result = x5.c();
			}
			return result;
		}

		// Token: 0x060012D5 RID: 4821 RVA: 0x000D6B98 File Offset: 0x000D5B98
		internal x5 h()
		{
			m8 m = this.a.c5().f();
			x5 x = x5.c();
			if (!this.a.s() && m.k())
			{
				x = m.a();
			}
			if (!this.a.t() && m.l() && this.a.n() != null && this.a.n().e() == null)
			{
				x = x5.f(x, m.c());
			}
			return x;
		}

		// Token: 0x060012D6 RID: 4822 RVA: 0x000D6C34 File Offset: 0x000D5C34
		internal x5 i()
		{
			x5 result;
			if (!this.a.s())
			{
				result = this.a.c5().e().a();
			}
			else
			{
				result = x5.c();
			}
			return result;
		}

		// Token: 0x060012D7 RID: 4823 RVA: 0x000D6C74 File Offset: 0x000D5C74
		internal x5 j()
		{
			lk lk = this.a.c5();
			x5 x = x5.c();
			if (lk.e().h() != i2.j)
			{
				x = x5.f(x, lk.e().d());
			}
			if (lk.e().f() != i2.j)
			{
				x = x5.f(x, lk.e().b());
			}
			x5 x2 = x5.f(lk.f().d(), lk.f().b());
			int num = this.a.dg();
			if (num <= 3418)
			{
				if (num != 1946)
				{
					if (num != 3034 && num != 3418)
					{
						goto IL_2E6;
					}
					if (this.a.dv().h() == il.b)
					{
						x5 a_ = x5.f(lk.c().ab(), lk.c().ae());
						return x5.f(x5.f(x5.f(lk.e().d(), lk.e().b()), x2), a_);
					}
					if (lk.g())
					{
						return x5.f(lk.a1(), lk.a0());
					}
					return x5.f(x2, x);
				}
			}
			else if (num <= 442866842)
			{
				if (num != 144937050)
				{
					if (num != 442866842)
					{
						goto IL_2E6;
					}
				}
				else
				{
					if (this.a.dv().h() == il.b)
					{
						x5 a_ = x5.f(lk.c().ab(), lk.c().ae());
						return x5.f(x5.f(x5.f(lk.e().d(), lk.e().b()), a_), this.b());
					}
					x5 x3 = (this.a.dv().e() != null) ? this.a.dv().e().Value : x5.c();
					if (this.a.ad() != null)
					{
						x3 = x5.a(x5.b(x3) * (float)(this.a.ad().k() + 1));
					}
					if (lk.c() != null)
					{
						return x5.f(x5.f(x5.f(x5.f(lk.c().n(), lk.c().r()), x), this.b()), x3);
					}
					return x5.f(x5.f(x, this.b()), x3);
				}
			}
			else if (num != 718642778 && num != 889490394)
			{
				goto IL_2E6;
			}
			return x5.f(x, this.b());
			IL_2E6:
			return x5.f(lk.a1(), lk.a0());
		}

		// Token: 0x060012D8 RID: 4824 RVA: 0x000D6F80 File Offset: 0x000D5F80
		internal x5 k()
		{
			lk lk = this.a.c5();
			lf lf = lk.c();
			int num = this.a.dg();
			if (num <= 3418)
			{
				if (num != 1946)
				{
					if (num != 3034 && num != 3418)
					{
						goto IL_2D4;
					}
					if (this.a.dv().h() == il.b)
					{
						x5 x = x5.f(lf.v(), lf.y());
						if (x5.g(lf.ak(), x5.b()) && x5.g(lf.al(), x5.a()))
						{
							x = x5.f(x, x5.e(lf.al(), lf.ak()));
						}
						return x5.f(x5.f(x5.f(this.f(), lk.f().a()), lk.f().c()), x);
					}
					if (!lk.g())
					{
						return x5.f(x5.f(x5.f(lk.a2(), lk.a3()), lk.f().a()), lk.f().c());
					}
					return x5.f(lk.a2(), lk.a3());
				}
			}
			else if (num <= 442866842)
			{
				if (num != 144937050)
				{
					if (num != 442866842)
					{
						goto IL_2D4;
					}
				}
				else
				{
					if (this.a.dv().h() != il.b)
					{
						x5 x2 = (this.a.dv().f() != null) ? this.a.dv().f().Value : x5.c();
						x2 = x5.a(x5.b(x2) * 2f);
						return x5.f(x5.f(lk.a2(), lk.a3()), x2);
					}
					x5 x = x5.f(lf.v(), lf.y());
					if (x5.g(lf.ak(), x5.b()) && x5.g(lf.al(), x5.a()))
					{
						x = x5.f(x, x5.e(lf.al(), lf.ak()));
					}
					if (lk.g())
					{
						return x5.f(x5.f(this.f(), this.h()), x);
					}
					return x5.f(this.f(), x);
				}
			}
			else if (num != 718642778 && num != 889490394)
			{
				goto IL_2D4;
			}
			return x5.f(this.f(), this.h());
			IL_2D4:
			return x5.f(this.l(), this.m());
		}

		// Token: 0x060012D9 RID: 4825 RVA: 0x000D7278 File Offset: 0x000D6278
		internal x5 l()
		{
			x5 x = x5.c();
			lk lk = this.a.c5();
			if (!this.a.s())
			{
				if (!this.a.@do())
				{
					x = x5.f(x, lk.e().a());
				}
				if (lk.c() != null)
				{
					int num = this.a.dg();
					if (num != 3034 && num != 3418 && num != 144937050)
					{
						x = x5.f(x, lk.c().f());
					}
					else if (this.a.dv().h() == il.b)
					{
						x = x5.f(x, lk.c().v());
					}
					else
					{
						x = x5.f(x, lk.c().f());
					}
				}
				if (lk.f().k())
				{
					x = x5.f(x, lk.f().a());
				}
			}
			return x;
		}

		// Token: 0x060012DA RID: 4826 RVA: 0x000D7388 File Offset: 0x000D6388
		internal x5 m()
		{
			x5 x = x5.c();
			lk lk = this.a.c5();
			if (!this.a.t())
			{
				x = x5.f(x, lk.e().c());
				if (lk.c() != null)
				{
					x = x5.f(x, lk.c().j());
				}
				if (lk.f().l())
				{
					x = x5.f(x, lk.f().c());
				}
			}
			return x;
		}

		// Token: 0x060012DB RID: 4827 RVA: 0x000D7414 File Offset: 0x000D6414
		internal void a(mr A_0, int A_1, x5 A_2, ref bool A_3, int A_4, x5 A_5, x5 A_6)
		{
			kz kz = A_0.b();
			n5 n = (n5)this.a.db();
			n5 n2 = null;
			if (this.a.dg() != 46415)
			{
				kz.a(n.n().a());
			}
			if (kz.dg() != 46415)
			{
				n2 = (n5)kz.db();
			}
			if (this.a.dg() != 86163053)
			{
				kz.a(n.n().a());
			}
			this.b(kz);
			this.a(A_1, kz);
			int num;
			if (kz.ci() || kz.ch())
			{
				num = kz.dg();
				if (num != 11228793)
				{
					kz.ax(kz.dr().ck());
					x5? x = kz.c5().v();
					x5 a_ = kz.cj();
					if (x != null && x5.c(x.GetValueOrDefault(), a_))
					{
						kz.ax(kz.c5().v().Value);
					}
					kz.ay(kz.cj());
				}
			}
			if (kz.ch() && kz.c5().am() == null)
			{
				kz.c5().j(this.a.c5().am());
				x5? x = kz.c5().am();
				x5 a_ = x5.c();
				if (x != null && x5.h(x.GetValueOrDefault(), a_))
				{
					kz.c5().j(null);
				}
			}
			num = kz.dg();
			switch (num)
			{
			case 100:
			case 101:
			case 102:
				break;
			default:
				if (num != 46415)
				{
					((k0)A_0.b()).a(this.a.z());
					((k0)A_0.b()).h(this.a.u());
				}
				break;
			}
			if (n.n() != null)
			{
				kz.a(n.n().a());
				kz.at(n.n().c() == mw.d);
			}
			else
			{
				kz.a(this.a.ds());
				kz.at(this.a.du());
			}
			if ((kz.dg() == 100 || kz.dg() == 101) && n2.n().c() == mw.b && !kz.dt())
			{
				n2.n().a(kz.ds());
			}
			if (x5.c(this.a.ap(), x5.c()))
			{
				kz.k(this.a.ap());
			}
			if (this.a.c3())
			{
				if (kz.c5().n() == g3.c)
				{
					kz.j(x5.f(A_2, this.a.ao()));
				}
				else
				{
					kz.j(A_2);
				}
			}
			else
			{
				kz.j(x5.f(this.a.ao(), A_2));
			}
			if (kz.c5().r() == g7.d || kz.c5().r() == g7.c)
			{
				kz.j(this.a);
				if (kz.c5().q() == g6.c)
				{
					kz.j((kz.c5().a() != null) ? kz.c5().a().Value : x5.c());
				}
				else
				{
					kz.j(A_2);
				}
			}
			else if (kz.c5().q() == g6.b)
			{
				kz.j(A_2);
				kz.j(this.a);
			}
			num = kz.dg();
			if (num > 3418)
			{
				if (num <= 46574465)
				{
					if (num <= 46415)
					{
						if (num <= 3567)
						{
							if (num == 3445)
							{
								goto IL_6F6;
							}
							if (num != 3567)
							{
								goto IL_7F5;
							}
							goto IL_6CC;
						}
						else
						{
							if (num == 34721)
							{
								A_3 = true;
								A_4++;
								goto IL_7FE;
							}
							if (num != 46415)
							{
								goto IL_7F5;
							}
							goto IL_72F;
						}
					}
					else if (num <= 5629554)
					{
						if (num != 95221 && num != 5629554)
						{
							goto IL_7F5;
						}
					}
					else if (num != 23684646)
					{
						if (num != 46574465)
						{
							goto IL_7F5;
						}
						goto IL_6EA;
					}
				}
				else if (num <= 258605815)
				{
					if (num <= 141185593)
					{
						if (num == 86163053)
						{
							goto IL_72F;
						}
						if (num != 141185593)
						{
							goto IL_7F5;
						}
						A_3 = true;
						A_4 = 0;
						kz.j(x5.f(this.a.ao(), A_2));
						goto IL_7FE;
					}
					else if (num != 142298369)
					{
						if (num != 258605815)
						{
							goto IL_7F5;
						}
						A_3 = true;
						if (A_0.b().c5().am() == null)
						{
							if (this.a.b6().Count > 0)
							{
								A_0.b().c5().j(new x5?(this.a.aq()));
								A_0.b().c5().d(i2.d);
							}
						}
						goto IL_7FE;
					}
				}
				else if (num <= 445520207)
				{
					if (num == 442866842)
					{
						goto IL_738;
					}
					if (num != 445520207)
					{
						goto IL_7F5;
					}
				}
				else if (num != 594666565)
				{
					if (num != 718642778 && num != 889490394)
					{
						goto IL_7F5;
					}
					goto IL_738;
				}
				A_3 = true;
				kz.p(A_4);
				A_4 = 0;
				goto IL_7FE;
				IL_72F:
				A_3 = true;
				goto IL_7FE;
			}
			if (num <= 1946)
			{
				if (num <= 687)
				{
					if (num <= 102)
					{
						if (num != 33)
						{
							switch (num)
							{
							case 100:
							case 101:
							case 102:
								A_3 = true;
								goto IL_7FE;
							default:
								goto IL_7F5;
							}
						}
					}
					else if (num != 431 && num != 687)
					{
						goto IL_7F5;
					}
				}
				else if (num <= 1000)
				{
					if (num != 879)
					{
						if (num != 1000)
						{
							goto IL_7F5;
						}
						goto IL_6F6;
					}
				}
				else
				{
					if (num == 1717)
					{
						goto IL_6F6;
					}
					if (num != 1946)
					{
						goto IL_7F5;
					}
					goto IL_738;
				}
			}
			else if (num <= 2613)
			{
				if (num <= 2585)
				{
					if (num == 1977)
					{
						if (A_3)
						{
							A_3 = false;
						}
						A_3 = true;
						goto IL_7FE;
					}
					if (num != 2585)
					{
						goto IL_7F5;
					}
					goto IL_6EA;
				}
				else
				{
					if (num != 2595 && num != 2613)
					{
						goto IL_7F5;
					}
					goto IL_6EA;
				}
			}
			else if (num <= 3119)
			{
				if (num == 3034)
				{
					goto IL_738;
				}
				if (num != 3119)
				{
					goto IL_7F5;
				}
			}
			else if (num != 3375)
			{
				if (num != 3418)
				{
					goto IL_7F5;
				}
				goto IL_738;
			}
			IL_6CC:
			A_3 = true;
			A_4++;
			goto IL_7FE;
			IL_6EA:
			A_3 = true;
			A_4 = 0;
			goto IL_7FE;
			IL_6F6:
			A_3 = true;
			A_4 = 0;
			goto IL_7FE;
			IL_738:
			A_3 = true;
			kz.a(this.a.b6());
			kz.dw(this.a.dv());
			goto IL_7FE;
			IL_7F5:
			A_3 = true;
			A_4 = 0;
			IL_7FE:
			if (kz.c5().n() != g3.c)
			{
				A_5 = this.a.bi();
			}
			else
			{
				A_0.b().ah(this.a.bi());
			}
			num = kz.dg();
			if (num <= 3034)
			{
				switch (num)
				{
				case 100:
				case 101:
				case 102:
					return;
				default:
					if (num != 3034)
					{
						goto IL_93C;
					}
					break;
				}
			}
			else if (num != 3418)
			{
				if (num != 46415)
				{
					goto IL_93C;
				}
				kz.ah(x5.e(this.a.bi(), this.a.aa()));
				((md)kz).e(A_5);
				return;
			}
			if (((nt)kz).h() < this.a.b6().Count)
			{
				A_5 = (x5)this.a.b6()[((nt)kz).h()];
				((k0)A_0.b()).ae().b(A_5, A_6);
			}
			kz.ah(kz.aq());
			return;
			IL_93C:
			((k0)A_0.b()).b(A_5, A_6);
			kz.u(this.a.c5().a1());
			kz.v(this.a.c5().a0());
			kz kz2 = kz;
			kz2.s(x5.f(kz2.ax(), x5.f(this.a.c5().a1(), this.a.ax())));
			kz kz3 = kz;
			kz3.t(x5.f(kz3.ay(), x5.f(this.a.c5().a0(), this.a.ay())));
			x5 a_2 = x5.f(kz.c5().a1(), kz.c5().a0());
			if (kz.c5().am() != null && x5.g(kz.c5().am().Value, x5.c()))
			{
				kz.l(x5.f(kz.c5().am().Value, a_2));
				if (kz.c5().q() == g6.c)
				{
					kz.ah(this.a.bi());
				}
				else
				{
					kz.ah(x5.f(kz.c5().am().Value, a_2));
				}
			}
			else
			{
				kz.ah(x5.e(this.a.bi(), this.a.aa()));
				i2 i = ((n5)kz.db()).q();
				if (i == i2.b)
				{
					n5 n3 = (n5)kz.db();
					n3.e(new x5?(x5.a(x5.b(A_5) * (x5.b(n3.p().Value) / 100f))));
					n3.c(i2.d);
					num = kz.dg();
					if (num != 46415)
					{
						if (!kz.c1())
						{
							mt mt = ((k0)kz).n();
							if (mt != null && mt.c() != null)
							{
								ms ms = mt.c().a();
								ms.k(n3.p().Value);
							}
						}
					}
				}
			}
		}

		// Token: 0x060012DC RID: 4828 RVA: 0x000D7FDC File Offset: 0x000D6FDC
		internal void b(k0 A_0)
		{
			A_0.dc(this.a.db().du());
			A_0.a((lk)this.a.c5().du());
			if (A_0.c5().v() != null)
			{
				x5 x = x5.e(A_0.c5().v().Value, this.a.ar());
				if (x5.d(x, x5.c()))
				{
					x = x5.c();
					A_0.d(true);
					A_0.e(true);
					A_0.g(true);
				}
				else
				{
					this.a.g(true);
				}
				A_0.c5().i(new x5?(x));
			}
			else
			{
				this.a.g(true);
			}
			A_0.b(this.a.w());
			A_0.j(this.a.dr());
			A_0.f(true);
			int num = A_0.dg();
			if (num <= 3418)
			{
				if (num != 1946)
				{
					if (num != 3034 && num != 3418)
					{
						return;
					}
					this.a(A_0);
					return;
				}
			}
			else if (num <= 442866842)
			{
				if (num == 144937050)
				{
					((nv)A_0).a(((nv)this.a).g());
					this.a(A_0);
					A_0.a(this.a.ad());
					if (((nv)this.a).c() != null)
					{
						A_0.f(false);
					}
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
			this.a(A_0);
			A_0.a(this.a.ad());
		}

		// Token: 0x060012DD RID: 4829 RVA: 0x000D81CC File Offset: 0x000D71CC
		internal x5 n()
		{
			lk lk = this.a.c5();
			x5 x = x5.c();
			x5 a_ = x5.f(x5.f(x5.f(lk.e().d(), lk.e().b()), lk.f().d()), lk.f().b());
			bool a_2 = true;
			bool flag = false;
			x5 x2 = x5.c();
			x5 a_3 = x5.c();
			x5 x3 = x5.c();
			int num = 0;
			bool a_4 = false;
			x5 result;
			if (lk.am() == null || lk.ap() == i2.b)
			{
				if (this.a.n() != null)
				{
					mu mu = this.a.n().c();
					while (mu != null && mu.a() != null)
					{
						ms ms = mu.a();
						mr mr = ms.l().a();
						while (mr != null && mr.b() != null)
						{
							kz kz = mr.b();
							kz.o(flag);
							kz.dh();
							x3 = kz.dp();
							a_4 = this.a(kz, x3, a_4, num);
							num++;
							if (kz.c5().u())
							{
								g2 valueOrDefault = kz.c5().t().GetValueOrDefault();
								g2? g;
								if (g == null)
								{
									goto IL_17D;
								}
								if (valueOrDefault != g2.c)
								{
									goto IL_17D;
								}
								x2 = this.a(kz, x3, x2, ref x, a_2, flag);
								a_2 = true;
								goto IL_258;
								IL_17D:
								if (x5.d(a_3, x3))
								{
									a_3 = x3;
								}
								a_2 = false;
							}
							else
							{
								switch (a_2)
								{
								case false:
								{
									bool flag2 = kz.de();
									if (flag2)
									{
										if (x5.d(a_3, x3))
										{
											a_3 = x3;
										}
										a_2 = false;
									}
									else
									{
										if (x5.c(x2, x3) && x5.c(x2, x))
										{
											x = x2;
										}
										x2 = x3;
										a_2 = true;
									}
									break;
								}
								case true:
									switch (kz.de())
									{
									case false:
										x2 = this.a(kz, x3, x2, ref x, a_2, flag);
										break;
									case true:
										if (x5.d(a_3, x3))
										{
											a_3 = x3;
										}
										a_2 = false;
										break;
									}
									break;
								}
							}
							IL_258:
							flag = kz.b1();
							mr = mr.c();
						}
						mu = mu.b();
						a_4 = false;
						if (mu != null)
						{
							flag = true;
						}
					}
				}
				if (flag)
				{
					this.a.s(true);
				}
				if (x5.c(x2, x))
				{
					x = x2;
				}
				if (x5.c(a_3, x))
				{
					result = x5.f(a_3, a_);
				}
				else
				{
					result = x5.f(x, a_);
				}
			}
			else
			{
				result = x5.f(lk.am().Value, a_);
			}
			return result;
		}

		// Token: 0x060012DE RID: 4830 RVA: 0x000D850C File Offset: 0x000D750C
		internal x5 o()
		{
			x5 x = x5.c();
			x5 x2 = x5.c();
			x5 a_ = x5.c();
			x5 x3 = x5.c();
			x5 x4 = x5.c();
			x5 x5 = this.p();
			bool flag = this.a.bp();
			bool flag2 = true;
			bool a_2 = this.a.c5().n() != g3.c || this.a.c3();
			x5 result;
			if (this.a.c5().am() == null || this.a.c5().ap() == i2.b || this.a.dg() == 3418 || this.a.dg() == 3034)
			{
				if (this.a.n() != null)
				{
					mu mu = this.a.n().c();
					int num = this.a.n().f();
					while (mu != null && mu.a() != null)
					{
						ms ms = mu.a();
						if (ms != null && ms.l() != null)
						{
							mr mr = ms.l().a();
							int num2 = 1;
							while (mr != null && mr.b() != null)
							{
								kz kz = mr.b();
								kz.m(num2);
								kz.ap(a_2);
								kz.o(flag);
								kz.di();
								x2 = kz.dn();
								this.a.aq(kz.b2());
								this.a.ar(kz.b3());
								this.a.i(kz.bb());
								if (kz.c5().u())
								{
									g2 valueOrDefault = kz.c5().t().GetValueOrDefault();
									g2? g;
									if (g == null)
									{
										goto IL_23C;
									}
									if (valueOrDefault != g2.c)
									{
										goto IL_23C;
									}
									if (flag2)
									{
										x3 = x5.f(x3, x2);
									}
									else
									{
										if (x5.c(x3, x2) && x5.c(x3, x))
										{
											x = x3;
										}
										x3 = x2;
										flag2 = true;
									}
									goto IL_3F3;
									IL_23C:
									if (x5.d(a_, x2))
									{
										a_ = x2;
									}
									flag2 = false;
								}
								else
								{
									switch (flag2)
									{
									case false:
										if ((!kz.de() && !kz.c3()) || kz.c5().n() != g3.c)
										{
											if (x5.c(x3, x2) && x5.c(x3, x))
											{
												x = x3;
											}
											x3 = x2;
											flag2 = true;
										}
										else if (num == 1)
										{
											x3 = x5.f(x3, x2);
										}
										else
										{
											if (x5.d(a_, x2))
											{
												a_ = x2;
											}
											flag2 = false;
										}
										break;
									case true:
										if ((!kz.de() && !kz.c3()) || kz.c5().n() != g3.c)
										{
											x3 = x5.f(x3, x2);
										}
										else if (kz.dr() != null && kz.dr().dg() == 5629554)
										{
											x3 = x5.f(x3, x2);
										}
										else if (num == 1)
										{
											if (kz.dg() == 1977)
											{
												if (x5.c(x3, x4))
												{
													x4 = x3;
												}
												x3 = x2;
											}
											else if (x5.c(x4, x5.c()))
											{
												x3 = x2;
											}
											else
											{
												x3 = x5.f(x3, x2);
											}
										}
										else
										{
											if (x5.d(a_, x2))
											{
												a_ = x2;
											}
											flag2 = false;
										}
										break;
									}
								}
								IL_3F3:
								flag = kz.b1();
								mr = mr.c();
								num2++;
							}
						}
						mu = mu.b();
					}
					if (flag)
					{
						this.a.s(flag);
					}
					if (x5.c(x4, x5.c()) && x5.c(x4, x3))
					{
						x3 = x4;
					}
					if (x5.c(x3, x))
					{
						x = x3;
					}
					if (x5.c(a_, x))
					{
						result = x5.f(a_, x5);
					}
					else
					{
						result = x5.f(x, x5);
					}
				}
				else
				{
					result = x5;
				}
			}
			else
			{
				result = x5.f(this.a.c5().am().Value, x5);
			}
			return result;
		}

		// Token: 0x060012DF RID: 4831 RVA: 0x000D8A1C File Offset: 0x000D7A1C
		internal x5 p()
		{
			x5 x = x5.c();
			bool flag = false;
			lk lk = this.a.c5();
			int num = this.a.dg();
			if (num == 3034 || num == 3418 || num == 144937050)
			{
				if (this.a.dv().h() == il.b)
				{
					x = x5.f(x, lk.c().ab());
					x = x5.f(x, lk.c().ae());
					flag = true;
				}
			}
			if (!flag)
			{
				lk.c().n();
				bool flag2 = 1 == 0;
				x = x5.f(x, lk.c().n());
				lk.c().r();
				flag2 = (1 == 0);
				x = x5.f(x, lk.c().r());
			}
			if (x5.c(lk.e().d(), x5.c()))
			{
				x = x5.f(x, lk.e().d());
			}
			if (x5.c(lk.e().b(), x5.c()))
			{
				x = x5.f(x, lk.e().b());
			}
			if (this.a.dg() == 144937050)
			{
				if (lk.g())
				{
					x = x5.f(x, x5.f(lk.f().d(), lk.f().b()));
				}
			}
			else
			{
				x = x5.f(x, x5.f(lk.f().d(), lk.f().b()));
			}
			return x;
		}

		// Token: 0x060012E0 RID: 4832 RVA: 0x000D8BD8 File Offset: 0x000D7BD8
		internal void a(ref x5[] A_0, ref f9[] A_1, int A_2, x5 A_3, mt A_4)
		{
			if (A_4 != null)
			{
				mu mu = A_4.c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					mr mr = ms.l().a();
					while (mr != null && mr.b() != null)
					{
						int num = mr.b().dg();
						if (num <= 442866842)
						{
							if (num != 1946)
							{
								if (num == 442866842)
								{
									goto IL_89;
								}
							}
							else
							{
								((nx)mr.b()).a(ref A_0, ref A_1);
							}
						}
						else if (num == 718642778 || num == 889490394)
						{
							goto IL_89;
						}
						IL_A7:
						mr = mr.c();
						continue;
						IL_89:
						this.a(ref A_0, ref A_1, A_2, A_3, ((k0)mr.b()).n());
						goto IL_A7;
					}
					mu = mu.b();
				}
			}
		}

		// Token: 0x060012E1 RID: 4833 RVA: 0x000D8CD4 File Offset: 0x000D7CD4
		internal void q()
		{
			x5 a_ = x5.c();
			int num = 0;
			x5? x = null;
			int num2 = this.a.dg();
			if (num2 <= 442866842)
			{
				if (num2 == 144937050)
				{
					if (this.a.n() != null)
					{
						num = this.a.n().f();
					}
					x = this.a.dv().f();
					if (x != null)
					{
						a_ = x5.b(x.Value, num + 1);
					}
					k0 k = this.a;
					k.m(x5.f(k.ar(), a_));
					return;
				}
				if (num2 != 442866842)
				{
					return;
				}
			}
			else if (num2 != 718642778 && num2 != 889490394)
			{
				return;
			}
			if (this.a.n() != null)
			{
				num = this.a.n().f();
			}
			x = this.a.dv().f();
			if (x != null)
			{
				a_ = x5.b(x.Value, num - 1);
			}
			if (x5.c(x5.f(this.a.n().h(), a_), this.a.ar()))
			{
				k0 k2 = this.a;
				k2.m(x5.f(k2.ar(), a_));
			}
		}

		// Token: 0x060012E2 RID: 4834 RVA: 0x000D8E4C File Offset: 0x000D7E4C
		internal void a(mu A_0, x5 A_1)
		{
			ms ms = A_0.a();
			ms.f(A_1);
			ms.h(A_1);
			if (ms != null && ms.l() != null)
			{
				mr mr = ms.l().a();
				while (mr != null && mr.b() != null)
				{
					int num = mr.b().dg();
					if (num <= 3034)
					{
						switch (num)
						{
						case 100:
						case 101:
						case 102:
							break;
						default:
							if (num != 3034)
							{
								goto IL_D9;
							}
							goto IL_A6;
						}
					}
					else
					{
						if (num == 3418)
						{
							goto IL_A6;
						}
						if (num != 46415)
						{
							goto IL_D9;
						}
						mr.b().ai(A_1);
					}
					IL_2CC:
					mr = mr.c();
					continue;
					IL_A6:
					if (((n5)mr.b().db()).z() == 1)
					{
						mr.b().m(A_1);
					}
					goto IL_2CC;
					IL_D9:
					k0 k = (k0)mr.b();
					mt a_ = k.n();
					num = k.dg();
					Hashtable hashtable;
					if (num <= 442866842)
					{
						if (num != 144937050)
						{
							if (num == 442866842)
							{
								goto IL_19E;
							}
						}
						else
						{
							this.c = x5.c();
							hashtable = new Hashtable();
							this.a(k, hashtable);
							if (hashtable.Count >= 1)
							{
								if (k.ah())
								{
									this.a(a_, hashtable);
									if (!k.c1())
									{
										this.a(hashtable, k);
									}
								}
								else
								{
									this.a(hashtable, k);
								}
							}
						}
					}
					else if (num == 718642778 || num == 889490394)
					{
						goto IL_19E;
					}
					IL_2CA:
					goto IL_2CC;
					IL_19E:
					hashtable = new Hashtable();
					this.a(k, hashtable);
					if (k.ah())
					{
						if (!k.c1())
						{
							this.a(a_, hashtable);
						}
						x5 x = x5.c();
						foreach (object obj in hashtable.Values)
						{
							x5 a_2 = (x5)obj;
							x = x5.f(x, a_2);
						}
						x5 a_3 = x5.c();
						if (k.dv().f() != null)
						{
							a_3 = x5.b(k.dv().f().Value, hashtable.Count + 1);
						}
						x = x5.f(x, a_3);
						if (x5.d(k.ar(), x))
						{
							k.m(x);
						}
					}
					else if (hashtable.Count > 1)
					{
						this.b(hashtable, k);
					}
					goto IL_2CA;
				}
			}
		}

		// Token: 0x060012E3 RID: 4835 RVA: 0x000D915C File Offset: 0x000D815C
		internal x5 c(mt A_0)
		{
			if (A_0 != null)
			{
				mu mu = A_0.c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					if (ms.l() != null)
					{
						mr mr = ms.l().a();
						while (mr != null && mr.b() != null)
						{
							int num = mr.b().dg();
							if (num <= 442866842)
							{
								if (num == 1946)
								{
									return mr.b().ar();
								}
								if (num == 442866842)
								{
									goto IL_93;
								}
							}
							else if (num == 718642778 || num == 889490394)
							{
								goto IL_93;
							}
							mr = mr.c();
							continue;
							IL_93:
							return this.c(((k0)mr.b()).n());
						}
					}
					mu = mu.b();
				}
			}
			return x5.c();
		}

		// Token: 0x060012E4 RID: 4836 RVA: 0x000D9268 File Offset: 0x000D8268
		internal void c(k0 A_0)
		{
			mt mt = A_0.n();
			mu mu = mt.c();
			while (mu != null && mu.a() != null)
			{
				mq mq = mu.a().l();
				if (mq != null)
				{
					mr mr = mq.a();
					while (mr != null && mr.b() != null)
					{
						mr.b().j(A_0);
						mr.b().am(true);
						mr = mr.c();
					}
				}
				mu = mu.b();
			}
		}

		// Token: 0x04000923 RID: 2339
		private k0 a = null;

		// Token: 0x04000924 RID: 2340
		private bool b = false;

		// Token: 0x04000925 RID: 2341
		private x5 c = x5.c();

		// Token: 0x04000926 RID: 2342
		private x5 d = x5.c();
	}
}
