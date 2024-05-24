using System;

namespace zz93
{
	// Token: 0x020000AE RID: 174
	internal abstract class dy
	{
		// Token: 0x06000820 RID: 2080 RVA: 0x00072D74 File Offset: 0x00071D74
		internal dy()
		{
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x00072DCC File Offset: 0x00071DCC
		internal dy(p1 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x00072E28 File Offset: 0x00071E28
		internal p1 m()
		{
			return this.a;
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x00072E40 File Offset: 0x00071E40
		internal void a(p1 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x00072E4C File Offset: 0x00071E4C
		internal virtual bool ci()
		{
			return this.i;
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x00072E64 File Offset: 0x00071E64
		internal virtual void cj(bool A_0)
		{
			this.i = A_0;
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x00072E70 File Offset: 0x00071E70
		internal virtual bool n()
		{
			return this.f;
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x00072E88 File Offset: 0x00071E88
		internal virtual void e(bool A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x00072E94 File Offset: 0x00071E94
		internal virtual bool cp()
		{
			return false;
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x00072EA8 File Offset: 0x00071EA8
		internal virtual bool d5()
		{
			return this.d;
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x00072EC0 File Offset: 0x00071EC0
		internal virtual void d6(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x00072ECC File Offset: 0x00071ECC
		internal virtual bool ck()
		{
			return this.g;
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x00072EE4 File Offset: 0x00071EE4
		internal virtual void cl(bool A_0)
		{
			this.g = true;
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x00072EF0 File Offset: 0x00071EF0
		internal virtual bool o()
		{
			return this.e;
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x00072F08 File Offset: 0x00071F08
		internal virtual void f(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x00072F14 File Offset: 0x00071F14
		internal virtual d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x00072F2C File Offset: 0x00071F2C
		internal virtual d0 ch()
		{
			return this.c;
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x00072F44 File Offset: 0x00071F44
		internal virtual fa cr()
		{
			return fa.a;
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x00072F58 File Offset: 0x00071F58
		internal virtual bool p()
		{
			return this.h;
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x00072F70 File Offset: 0x00071F70
		internal virtual void g(bool A_0)
		{
			this.h = A_0;
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x00072F7C File Offset: 0x00071F7C
		internal virtual kz cm(ij A_0, kz A_1)
		{
			return null;
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x00072F90 File Offset: 0x00071F90
		private void a(k0 A_0, ref bool A_1, kz A_2, ref lk A_3)
		{
			A_1 = A_0.c5().a(A_3);
			A_3 = A_2.c5();
			if (A_1)
			{
				A_0.c5().a(g4.b, A_3);
				A_2.a(A_3);
			}
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x00072FDC File Offset: 0x00071FDC
		private void b(k0 A_0, ref ms A_1, ref mt A_2, kz A_3)
		{
			lx lx = new lx();
			kz kz = lx;
			bool a_;
			A_3.ai(a_ = true);
			kz.ah(a_);
			lx.a(A_3.c5());
			lx.c(null);
			A_0.o().d().a().l().a(lx);
			A_2 = new mt(A_1);
			A_1 = null;
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x00073044 File Offset: 0x00072044
		private void a(k0 A_0, ref ms A_1, ref mt A_2, kz A_3)
		{
			bool flag = false;
			if (A_3.c5().q() == g6.c)
			{
				if (A_3.c5().r() == g7.d || A_3.c5().r() == g7.c)
				{
					if (A_3.c5().a9() && A_0.c5().a8())
					{
						A_0.o().d().a().l().a(A_3);
					}
					else if (A_0.c5().q() == g6.a)
					{
						A_0.o().d().a().l().a(A_3);
					}
					else
					{
						A_0.o().d().a().l().a(A_3);
					}
				}
				else
				{
					flag = true;
				}
			}
			else if (A_3.c5().q() == g6.b)
			{
				flag = true;
			}
			else
			{
				A_1 = new ms(A_3);
			}
			if (flag)
			{
				lx lx = new lx();
				kz kz = lx;
				bool a_;
				A_3.ai(a_ = true);
				kz.ah(a_);
				lx.a(A_3.c5());
				lx.c(null);
				A_0.o().d().a().l().a(lx);
				if (A_1 == null || A_3.de())
				{
					if (A_1 != null)
					{
						if (A_2 == null)
						{
							A_2 = new mt(A_1);
						}
						else
						{
							A_2.c(A_1);
						}
					}
					A_1 = new ms(A_3);
				}
				else
				{
					A_1.l().a(A_3);
				}
				A_1.e(true);
				if (A_2 != null)
				{
					A_2.c(A_1);
				}
				else
				{
					A_2 = new mt(A_1);
				}
				A_1 = null;
			}
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x00073248 File Offset: 0x00072248
		internal void a(mt A_0, kz A_1)
		{
			mu mu = this.b(A_0.c());
			bool flag = A_1.c5().d();
			if (mu != null)
			{
				mq mq = mu.a().l();
				kz kz = mq.b().b();
				kz kz2 = null;
				x5 x = x5.c();
				int num = A_0.f();
				bool flag2 = false;
				if (mu != null && kz.de() && !kz.c5().m())
				{
					this.a(kz, ref x);
				}
				if (num >= 2 && mu != null)
				{
					mu mu2 = null;
					do
					{
						if (mu != null)
						{
							mu2 = this.b(mu.b());
						}
						if (mu2 != null)
						{
							this.a(mu, mu2, ref kz, ref kz2);
							if (kz != null && kz2 != null && kz.de() && kz2.de())
							{
								if (kz != null && kz2 != null)
								{
									this.b(kz2, kz);
								}
								else if (kz != null && kz.de())
								{
									this.b(kz);
								}
								else if (kz2.de() && !this.c(kz2))
								{
									this.a(kz2, ref x);
								}
							}
							else if (kz != null && kz.de())
							{
								this.b(kz);
							}
							else if (kz2.de() && !this.c(kz2))
							{
								this.a(kz2, ref x);
							}
						}
						if (mu2 == null)
						{
							if (kz2 != null)
							{
								this.b(kz2);
							}
							flag2 = true;
						}
						mu = mu2;
					}
					while (mu != null);
				}
				if (!flag2 && kz.de() && kz.c5().v() == null)
				{
					this.b(kz);
				}
				else if (kz.c5().v() != null && A_1.c5().v() == null)
				{
					this.b(kz);
				}
			}
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x000734B8 File Offset: 0x000724B8
		private mu b(mu A_0)
		{
			bool flag = false;
			bool flag2 = false;
			if (A_0 != null)
			{
				if (A_0.a() != null)
				{
					if (A_0.a().l() != null)
					{
						if (A_0.a().l().a() != null)
						{
							mr mr = A_0.a().l().a();
							while (mr != null)
							{
								if (mr.b().de())
								{
									if (this.c(mr.b()))
									{
										mr = mr.c();
										flag = true;
									}
									else
									{
										if (!mr.b().c5().m())
										{
											flag = false;
											flag2 = true;
											break;
										}
										mr = mr.c();
										flag = false;
									}
								}
								else
								{
									if (mr.c() == null)
									{
										flag2 = true;
										break;
									}
									mr = mr.c();
								}
							}
						}
					}
				}
				if (!flag2)
				{
					if (flag && A_0.a().l().b().b().de())
					{
						A_0 = A_0.b();
					}
					else if (A_0.b() != null)
					{
						A_0 = A_0.b();
					}
				}
			}
			return A_0;
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x0007363C File Offset: 0x0007263C
		private void a(mu A_0, mu A_1, ref kz A_2, ref kz A_3)
		{
			if (A_0.a().z())
			{
				A_2 = this.a(A_0);
			}
			else
			{
				A_2 = A_0.a().l().a().b();
			}
			if (A_1.a() != null && A_1.a().z())
			{
				A_3 = this.a(A_1);
			}
			else if (A_1.a() != null)
			{
				A_3 = A_1.a().l().a().b();
			}
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x000736D8 File Offset: 0x000726D8
		private bool c(kz A_0)
		{
			g6 g = A_0.c5().q();
			lk lk = A_0.c5();
			bool result;
			switch (g)
			{
			case g6.b:
				result = lk.aa();
				break;
			case g6.c:
				result = true;
				break;
			default:
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x00073730 File Offset: 0x00072730
		private void b(kz A_0, kz A_1)
		{
			if (!A_0.c5().m() && !A_1.c5().m())
			{
				x5 a_ = this.a(A_0, A_1);
				A_0.c5().e().a(x5.c());
				A_0.bb(a_);
				k0 k = (k0)A_0;
				while (k.n() != null && k.dg() != 1977 && !k.c5().m())
				{
					mu mu = k.n().c();
					if (mu == null)
					{
						break;
					}
					ms ms = mu.a();
					if (ms == null)
					{
						break;
					}
					mq mq = ms.l();
					if (mq == null)
					{
						break;
					}
					mr mr = mq.a();
					if (mr == null)
					{
						break;
					}
					kz kz = mr.b();
					if (kz == null || !kz.de())
					{
						break;
					}
					if (kz.c5().m())
					{
						break;
					}
					kz.c5().e().a(x5.c());
					k = (k0)kz;
				}
				A_1.c5().e().c(x5.c());
				k0 k2 = (k0)A_1;
				while (k2.n() != null && k2.dg() != 1977 && !k2.c5().m())
				{
					mu mu = k2.n().c(k2.n().f() - 1);
					if (mu == null)
					{
						break;
					}
					ms ms = mu.a();
					if (ms == null)
					{
						break;
					}
					mq mq = mu.a().l();
					if (mq == null)
					{
						break;
					}
					mr mr = mq.a();
					if (mr == null)
					{
						break;
					}
					kz kz = mq.a().b();
					if (kz == null || !kz.de())
					{
						break;
					}
					if (kz.c5().m())
					{
						break;
					}
					kz.c5().e().c(x5.c());
					k2 = (k0)kz;
				}
			}
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x000739E4 File Offset: 0x000729E4
		private x5 a(kz A_0, kz A_1)
		{
			x5 x = x5.c();
			m2 m = A_0.c5().e();
			m2 m2 = A_1.c5().e();
			if (A_1.cq() && A_0.cq())
			{
				if (!A_1.c5().d() && !A_0.c5().d())
				{
					m.a(m2);
					m.b(m2);
				}
				else
				{
					x = this.a(A_0, x, m, m2);
				}
			}
			else if (A_1.cq())
			{
				x = m2.k(m.a());
			}
			else if (!A_0.cq())
			{
				if (!A_1.cq() && !A_0.cq())
				{
					x = this.a(A_0, x, m, m2);
				}
			}
			return x;
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x00073AD0 File Offset: 0x00072AD0
		private x5 a(kz A_0, x5 A_1, m2 A_2, m2 A_3)
		{
			x5 x = A_2.o();
			x5 a_ = A_2.p();
			x5 x2 = A_3.q();
			x5 x3 = A_3.r();
			if (x5.a(x3, a_))
			{
				a_ = x3;
			}
			if (x5.b(x2, x))
			{
				x = x2;
			}
			A_0.a0(this.a(x2, x3));
			return this.a(x, a_);
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x00073B44 File Offset: 0x00072B44
		private void a(kz A_0, ref x5 A_1)
		{
			x5 a_ = A_0.c5().e().o();
			x5 a_2 = A_0.c5().e().p();
			x5 a_3 = x5.c();
			a_3 = (A_1 = this.a(a_, a_2));
			A_0.c5().e().a(x5.c());
			if (x5.h(A_0.d5(), x5.c()))
			{
				A_0.bb(a_3);
			}
			k0 k = (k0)A_0;
			while (k.n() != null && k.dg() != 1977 && !k.c5().m())
			{
				mu mu = k.n().c();
				if (mu == null)
				{
					break;
				}
				ms ms = mu.a();
				if (ms == null)
				{
					break;
				}
				mq mq = ms.l();
				if (mq == null)
				{
					break;
				}
				mr mr = mq.a();
				if (mr == null)
				{
					break;
				}
				kz kz = mr.b();
				if (kz == null || !kz.de())
				{
					break;
				}
				if (kz.c5().m())
				{
					break;
				}
				kz.c5().e().a(x5.c());
				k = (k0)kz;
			}
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x00073CD8 File Offset: 0x00072CD8
		private void b(kz A_0)
		{
			x5 a_ = A_0.c5().e().q();
			x5 a_2 = A_0.c5().e().r();
			x5 a_3 = x5.c();
			a_3 = this.a(a_, a_2);
			A_0.c5().e().c(x5.c());
			A_0.bc(a_3);
			if (A_0.de())
			{
				k0 k = (k0)A_0;
				while (k.n() != null && k.n().c().a().l().a().b() != null && !k.n().c().a().l().a().b().c5().m())
				{
					mu mu = k.n().c(k.n().f() - 1);
					if (mu == null)
					{
						break;
					}
					ms ms = mu.a();
					if (ms == null)
					{
						break;
					}
					mq mq = mu.a().l();
					if (mq == null)
					{
						break;
					}
					mr mr = mq.a();
					if (mr == null)
					{
						break;
					}
					kz kz = mq.a().b();
					if (kz == null || !kz.de())
					{
						break;
					}
					if (kz.c5().m())
					{
						break;
					}
					kz.c5().e().c(x5.c());
					k = (k0)kz;
				}
			}
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x00073EAC File Offset: 0x00072EAC
		internal x5 a(x5 A_0, x5 A_1)
		{
			x5 result = x5.c();
			if (x5.a(A_0, x5.c()) && x5.a(A_1, x5.c()))
			{
				if (x5.a(A_0, A_1))
				{
					result = A_0;
				}
				else
				{
					result = A_1;
				}
			}
			else if (x5.d(A_0, x5.c()) && x5.d(A_1, x5.c()))
			{
				if (x5.b(A_0, A_1))
				{
					result = A_0;
				}
				else
				{
					result = A_1;
				}
			}
			else
			{
				result = x5.f(A_0, A_1);
			}
			return result;
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x00073F44 File Offset: 0x00072F44
		private kz a(mu A_0)
		{
			mr mr = null;
			kz result;
			if (A_0 == null)
			{
				result = null;
			}
			else
			{
				if (A_0 != null)
				{
					ms ms = A_0.a();
					if (ms != null)
					{
						mq mq = ms.l();
						if (mq != null)
						{
							mr = mq.a();
							bool flag = false;
							bool flag2 = false;
							x5 a_ = x5.c();
							x5 a_2 = x5.c();
							while (mr != null)
							{
								if (mr.b() != null)
								{
									if (!mr.b().de())
									{
										break;
									}
									if (mr.b().c5().m())
									{
										flag = true;
										a_ = x5.c(a_);
										mr = mr.c();
									}
									else
									{
										if (mr.b().c5().q() != g6.b && mr.b().c5().q() != g6.c)
										{
											break;
										}
										flag2 = true;
										a_2 = x5.c(a_2);
										mr = mr.c();
									}
								}
								else
								{
									mr = mr.c();
								}
							}
							if (mr == null)
							{
								if (flag)
								{
									mr = mq.a();
									while (mr != null)
									{
										if (mr.b().c5().q() == g6.c)
										{
											mr = mr.c();
										}
										else
										{
											if (mr.b().c5().m())
											{
												break;
											}
											mr = mr.c();
										}
									}
								}
								if (flag2 && x5.h(a_2, x5.a(1f)) && x5.h(a_, x5.a(0f)))
								{
									return this.a(A_0.b());
								}
							}
						}
					}
				}
				if (mr != null)
				{
					result = mr.b();
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x00074170 File Offset: 0x00073170
		private void a(k0 A_0, ms A_1, ij A_2, int A_3)
		{
			mt mt = null;
			int num = this.cg().h();
			bool flag = false;
			bool flag2 = false;
			this.d(A_0);
			if (A_3 == 0)
			{
				kz kz = this.cg().b(0).cm(A_2, A_0);
				A_1 = new ms(kz);
				A_1.f(true);
				mt = new mt(A_1);
				A_1 = null;
				A_3++;
			}
			else if (A_1 != null)
			{
				A_1.f(true);
				mt = new mt(A_1);
				flag2 = true;
			}
			for (int i = A_3; i < num; i++)
			{
				if (this.cg().b(i).ci())
				{
					if (A_1 != null && !flag2)
					{
						mt.c(A_1);
						A_1 = null;
					}
					kz kz = this.cg().b(i).cm(A_2, A_0);
					A_1 = new ms(kz);
					A_1.f(true);
					if (mt == null)
					{
						mt = new mt(A_1);
					}
					else
					{
						mt.c(A_1);
					}
					A_1 = null;
				}
				else
				{
					flag2 = false;
					kz kz = this.cg().b(i).cm(A_2, A_0);
					if (kz != null)
					{
						if (kz.dg() != 1977)
						{
							flag = false;
						}
						else
						{
							if (flag)
							{
								((lm)kz).c(true);
							}
							else
							{
								((lm)kz).c(false);
							}
							flag = true;
						}
						if (A_1 != null)
						{
							A_1.l().a(kz);
						}
						else
						{
							A_1 = new ms(kz);
						}
					}
				}
			}
			if (A_1 != null)
			{
				mt.c(A_1);
			}
			A_0.c(mt);
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x0007434C File Offset: 0x0007334C
		internal void d(kz A_0)
		{
			if (A_0.dg() != 11228793)
			{
				if (A_0.c5().q() != g6.c && A_0.c5().q() != g6.b)
				{
					((k0)A_0).d(((k0)A_0.dr()).o());
				}
				else if (((k0)A_0).o() == null)
				{
					((k0)A_0).d(new mt(new ms(null), true));
				}
			}
			else
			{
				((k0)A_0).d(new mt(new ms(null), true));
			}
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x000743F8 File Offset: 0x000733F8
		internal void a(kz A_0, ref g0? A_1)
		{
			if (A_1 != null)
			{
				if (A_0.c5().o() == null)
				{
					A_0.c5().a(A_1);
				}
				else
				{
					switch (A_0.c5().o().Value)
					{
					case g0.a:
						if (A_1.Value == g0.b)
						{
							A_0.c5().a(new g0?(g0.c));
						}
						else
						{
							A_0.c5().a(A_1);
						}
						goto IL_F3;
					case g0.b:
						if (A_1.Value == g0.a)
						{
							A_0.c5().a(new g0?(g0.c));
						}
						else
						{
							A_0.c5().a(A_1);
						}
						goto IL_F3;
					}
					A_0.c5().a(A_1);
					IL_F3:;
				}
				A_1 = null;
			}
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x00074504 File Offset: 0x00073504
		internal static bool a(kz A_0)
		{
			bool result;
			switch (A_0.c5().n())
			{
			case g3.a:
			case g3.b:
				result = (A_0.c5().o() == null || A_0.c5().o().Value == g0.d);
				break;
			default:
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x00074570 File Offset: 0x00073570
		internal bool h(int A_0)
		{
			if (this.cg().b(A_0).ch() != null)
			{
				int num = this.cg().b(A_0).ch().cn();
				if (num <= 3567)
				{
					if (num <= 1946)
					{
						if (num <= 687)
						{
							if (num != 33 && num != 431 && num != 687)
							{
								goto IL_1CA;
							}
						}
						else if (num <= 1000)
						{
							if (num != 879 && num != 1000)
							{
								goto IL_1CA;
							}
						}
						else if (num != 1717 && num != 1946)
						{
							goto IL_1CA;
						}
					}
					else if (num <= 2613)
					{
						if (num != 2585 && num != 2595 && num != 2613)
						{
							goto IL_1CA;
						}
					}
					else if (num <= 3375)
					{
						if (num != 3119 && num != 3375)
						{
							goto IL_1CA;
						}
					}
					else if (num != 3445 && num != 3567)
					{
						goto IL_1CA;
					}
				}
				else if (num <= 144937050)
				{
					if (num <= 5629554)
					{
						if (num != 34721 && num != 95221 && num != 5629554)
						{
							goto IL_1CA;
						}
					}
					else if (num <= 141185593)
					{
						if (num != 46574465 && num != 141185593)
						{
							goto IL_1CA;
						}
					}
					else if (num != 142298369 && num != 144937050)
					{
						goto IL_1CA;
					}
				}
				else if (num <= 622899778)
				{
					if (num != 442866842 && num != 594666565 && num != 622899778)
					{
						goto IL_1CA;
					}
				}
				else if (num <= 889490394)
				{
					if (num != 718642778 && num != 889490394)
					{
						goto IL_1CA;
					}
				}
				else if (num != 899925938 && num != 1106840163)
				{
					goto IL_1CA;
				}
				return true;
				IL_1CA:;
			}
			return false;
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x00074750 File Offset: 0x00073750
		internal void d(k0 A_0)
		{
			if (A_0.n() != null)
			{
				mu mu = A_0.n().c();
				while (mu != null && mu.a() != null)
				{
					if (mu.a().l() != null)
					{
						mr mr = mu.a().l().a();
						while (mr != null && mr.b() != null)
						{
							if (mr.b().c5().v() == null)
							{
								mr.b().c5().i(A_0.c5().v());
								mr.b().c5().a(A_0.c5().ah());
								mr.b().c5().j(A_0.c5().ac());
							}
							int num = mr.b().dg();
							if (num == 1946)
							{
								this.d((k0)mr.b());
							}
							mr = mr.c();
						}
					}
					mu = mu.b();
				}
			}
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x00074894 File Offset: 0x00073894
		internal bool a(int A_0, ms A_1, kz A_2, ij A_3)
		{
			bool result = false;
			if (!this.cg().b(A_0 - 1).ci() && this.cg().b(A_0 - 1).cr() != fa.e && this.cg().b(A_0).cr() != fa.e)
			{
				pl a_ = new pl();
				this.cg().a(a_, A_0);
				kz kz = this.cg().b(A_0).cm(A_3, A_2);
				kz.j(A_2);
				A_1.l().a(kz);
				result = true;
			}
			return result;
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x00074934 File Offset: 0x00073934
		internal void e(k0 A_0, ij A_1)
		{
			A_0.aa(A_0.dr().ch());
			if (A_0.ch())
			{
				A_0.ab(A_0.dr().ci());
				A_0.az(A_0.dr().cl());
				A_0.ay(A_0.dr().ck());
			}
			g6 g = A_0.c5().q();
			if (g != g6.c)
			{
				switch (A_0.c5().n())
				{
				case g3.a:
				case g3.b:
					this.g(A_0, A_1);
					A_0.df(true);
					goto IL_12C;
				}
				if (A_0.c5().u())
				{
					g2 valueOrDefault = A_0.c5().t().GetValueOrDefault();
					g2? g2;
					if (g2 != null)
					{
						if (valueOrDefault == g2.b)
						{
							this.g(A_0, A_1);
							A_0.df(true);
							this.cj(true);
							goto IL_116;
						}
					}
					this.a(this.e, A_0, A_1);
					IL_116:;
				}
				else
				{
					this.a(this.e, A_0, A_1);
				}
				IL_12C:;
			}
			else
			{
				this.g(A_0, A_1);
				A_0.df(true);
			}
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x00074A70 File Offset: 0x00073A70
		internal void f(k0 A_0, ij A_1)
		{
			lk lk = A_0.c5();
			A_0.aa(A_0.dr().ch());
			if (A_0.ch())
			{
				A_0.ab(A_0.dr().ci());
				A_0.az(A_0.dr().cl());
				A_0.ay(A_0.dr().ck());
			}
			m4.a((n5)A_0.db(), A_0.c5());
			switch (lk.q())
			{
			case g6.b:
			case g6.c:
				this.g(A_0, A_1);
				break;
			default:
			{
				switch (lk.n())
				{
				case g3.a:
				case g3.b:
					this.g(A_0, A_1);
					goto IL_181;
				}
				g2? g = lk.t();
				g2 valueOrDefault = g.GetValueOrDefault();
				if (g != null)
				{
					switch (valueOrDefault)
					{
					case g2.c:
						lk.e().a(x5.c());
						lk.e().c(x5.c());
						this.a(this.e, A_0, A_1);
						A_0.df(false);
						goto IL_17F;
					}
				}
				this.cj(true);
				this.g(A_0, A_1);
				int num = A_0.dg();
				if (num == 426354867)
				{
					g = A_0.c5().t();
					if (g == null)
					{
						this.cj(false);
						A_0.df(false);
					}
				}
				IL_17F:
				IL_181:
				break;
			}
			}
		}

		// Token: 0x0600084C RID: 2124 RVA: 0x00074C00 File Offset: 0x00073C00
		internal void a(bool A_0, k0 A_1, ij A_2)
		{
			this.cj(false);
			A_1.df(false);
			A_1.v(this.e);
			bool flag = false;
			int num = this.cg().h();
			bool flag2 = false;
			this.d(A_1);
			if (this.cg() != null && num > 0)
			{
				this.cg().b(0).f(this.e);
				ms ms = null;
				if (this.cg().b(0).ci() || (A_1.c5().t() != null && A_1.c5().t().Value != g2.c && A_1.c5().t().Value != g2.d))
				{
					flag = true;
					A_1.df(true);
					this.g(A_1, A_2);
				}
				else
				{
					kz kz = this.cg().b(0).cm(A_2, A_1);
					this.d = this.cg().b(0).d5();
					if (kz != null)
					{
						kz.v(A_0);
						if (A_1.dg() == 673419368)
						{
							if (kz.dg() == 100)
							{
								kz.av(true);
							}
						}
						if (A_0 && this.d)
						{
							kz.ar(true);
						}
						ms = new ms(kz);
						if (kz.dg() == 1977)
						{
							((lm)kz).c(true);
							flag2 = true;
						}
					}
					for (int i = 1; i < num; i++)
					{
						this.cg().b(i).f(this.e);
						if (this.cg().b(i).ci() || (A_1.c5().t() != null && A_1.c5().t().Value != g2.c && A_1.c5().t().Value != g2.d))
						{
							flag = true;
							A_1.df(true);
							this.g(A_1, A_2);
							break;
						}
						kz = this.cg().b(i).cm(A_2, A_1);
						this.d = this.cg().b(i).d5();
						if (kz != null)
						{
							kz.v(A_0);
							if (A_0 && this.d)
							{
								kz.ar(true);
							}
							if (kz.dg() != 1977)
							{
								flag2 = false;
							}
							else
							{
								if (flag2)
								{
									((lm)kz).c(true);
								}
								else
								{
									((lm)kz).c(false);
								}
								flag2 = true;
							}
							if (A_1.dg() == 673419368)
							{
								if (kz.dg() == 100)
								{
									kz.av(true);
								}
							}
							if (ms != null)
							{
								ms.l().a(kz);
							}
							else
							{
								ms = new ms(kz);
							}
						}
					}
				}
				if (!flag)
				{
					A_1.c(new mt(ms));
				}
			}
			int num2 = A_1.dg();
			if (num2 != 86163053 && num2 != 445520207)
			{
				if (A_1.c5().q() != g6.c)
				{
					if (A_1.c5().n() == g3.c)
					{
						A_1.c5().j(null);
					}
				}
			}
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x00075004 File Offset: 0x00074004
		internal void g(k0 A_0, ij A_1)
		{
			A_0.df(true);
			ms ms = null;
			mt mt = null;
			x5? x = ((n5)A_0.db()).p();
			bool flag = false;
			bool flag2 = false;
			int num = this.cg().h();
			bool flag3 = false;
			bool flag4 = false;
			this.d(A_0);
			if (this.cg() != null && num > 0)
			{
				kz kz = this.cg().b(0).cm(A_1, A_0);
				lk lk = null;
				if (kz != null)
				{
					lk = kz.c5();
				}
				if (kz != null)
				{
					kz.aw(x5.a((float)this.cg().h()));
					ms = new ms(kz);
					if (this.cg().b(0).ci())
					{
						ms.e(true);
						if (kz.c5().q() != g6.c && kz.c5().q() != g6.b && kz.c5().n() == g3.c)
						{
							mt = new mt(ms);
							ms = null;
						}
						else if (kz.c5().q() == g6.c)
						{
							if (kz.c5().r() == g7.d || kz.c5().r() == g7.c)
							{
								A_0.o().d().a().l().a(kz);
								ms = null;
							}
							else
							{
								this.b(A_0, ref ms, ref mt, kz);
							}
						}
						else if (kz.c5().q() == g6.b)
						{
							this.b(A_0, ref ms, ref mt, kz);
						}
					}
					if (!dy.a(kz))
					{
						flag2 = true;
					}
					else
					{
						flag4 = true;
					}
					flag3 = A_0.c5().a(lk);
					if (num == 1)
					{
						if (flag3)
						{
							A_0.c5().a(g4.d, lk);
						}
					}
					else if (flag3 && !flag4)
					{
						A_0.c5().a(g4.c, lk);
					}
					kz.a(lk);
					flag3 = false;
				}
				else if (num > 1)
				{
					flag4 = true;
				}
				g0? g = null;
				int i = 1;
				while (i < num)
				{
					if (this.cg().b(i).cr() == fa.e && kz != null)
					{
						if (ms == null || kz.c5().q() == g6.c)
						{
							i++;
						}
						else if (kz.c5().n() != g3.c)
						{
							goto IL_7B0;
						}
						goto IL_2D9;
					}
					goto IL_2D9;
					IL_7B0:
					i++;
					continue;
					IL_2D9:
					if (i < num)
					{
						kz = this.cg().b(i).cm(A_1, A_0);
					}
					else
					{
						kz = null;
					}
					if (kz != null)
					{
						kz.aw(x5.a((float)this.cg().h()));
						if (kz.de())
						{
							if (ms != null)
							{
								ms.q(true);
							}
						}
						if (kz.dg() == 1977)
						{
							if (ms != null)
							{
								if (kz.c5().o() != null && kz.c5().o().Value != g0.d)
								{
									g = kz.c5().o();
								}
								if (flag)
								{
									ms.l().a(kz);
									ms.i(flag);
								}
								else
								{
									ms.q(true);
								}
							}
							else
							{
								ms = new ms(kz);
							}
							if (mt == null)
							{
								mt = new mt(ms);
							}
							else
							{
								mt.c(ms);
							}
							flag2 = false;
							ms = null;
							flag = false;
						}
						else
						{
							if (kz.c5().o() == g0.c)
							{
								flag = false;
							}
							this.a(kz, ref g);
							if (!this.cg().b(i).ci() || kz.c5().q() == g6.c || kz.c5().q() == g6.b || kz.c5().n() != g3.c)
							{
								if (ms != null)
								{
									if ((kz.c5().q() == g6.c || kz.c5().q() == g6.b) && flag2)
									{
										this.a(A_0, ref ms, ref mt, kz);
									}
									else
									{
										bool flag5 = false;
										if (this.h(i) && kz.dg() != 34721)
										{
											if (kz.c5().q() == g6.b)
											{
												this.a(A_0, ref ms, ref mt, kz);
												flag5 = true;
											}
											else
											{
												bool flag6 = this.a(i, ms, A_0, A_1);
												if (flag6)
												{
													i++;
													num++;
												}
											}
										}
										if ((this.cg().b(i).cr() != fa.e || i + 1 >= num || !this.h(i + 1)) && !flag5)
										{
											ms.l().a(kz);
										}
									}
								}
								else if (kz.de() || (kz.dg() == 46415 && kz.c5().q() != g6.a))
								{
									this.a(A_0, ref ms, ref mt, kz);
								}
								else
								{
									ms = new ms(kz);
								}
								flag = dy.a(kz);
								if (ms != null)
								{
									if (flag)
									{
										ms.i(flag);
									}
									if (kz.dg() != 1967)
									{
										ms.e(true);
									}
								}
								flag2 = !flag;
							}
							else
							{
								if (flag && !flag2)
								{
									if (ms != null)
									{
										ms.l().a(kz);
									}
									else
									{
										ms = new ms(kz);
									}
									ms.i(true);
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
										ms = null;
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
								if (flag4)
								{
									this.a(A_0, ref flag3, kz, ref lk);
									flag4 = false;
								}
								flag = false;
								flag2 = false;
								if (i + 1 < num && this.cg().b(i + 1).cr() == fa.e)
								{
									this.cg().c(i + 1);
									num--;
								}
							}
						}
					}
					if (i == num - 1)
					{
						if (kz != null)
						{
							this.a(A_0, ref flag3, kz, ref lk);
						}
						flag3 = false;
					}
					goto IL_7B0;
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
				if (mt != null && x != null)
				{
					mt.c().a().k(x.Value);
				}
				if (mt != null)
				{
				}
				A_0.c(mt);
			}
		}

		// Token: 0x04000472 RID: 1138
		private p1 a = null;

		// Token: 0x04000473 RID: 1139
		private d3 b = null;

		// Token: 0x04000474 RID: 1140
		private d0 c = null;

		// Token: 0x04000475 RID: 1141
		private bool d = false;

		// Token: 0x04000476 RID: 1142
		private bool e = false;

		// Token: 0x04000477 RID: 1143
		private bool f = false;

		// Token: 0x04000478 RID: 1144
		private bool g = true;

		// Token: 0x04000479 RID: 1145
		private bool h = false;

		// Token: 0x0400047A RID: 1146
		private bool i = false;
	}
}
