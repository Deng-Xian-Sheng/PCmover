using System;
using System.Collections.Generic;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Html;

namespace zz93
{
	// Token: 0x020001AC RID: 428
	internal abstract class k0 : kz
	{
		// Token: 0x06000FE0 RID: 4064 RVA: 0x000B2A2C File Offset: 0x000B1A2C
		internal mt n()
		{
			return this.a;
		}

		// Token: 0x06000FE1 RID: 4065 RVA: 0x000B2A44 File Offset: 0x000B1A44
		internal void c(mt A_0)
		{
			if (A_0 != null)
			{
				this.a = A_0;
			}
		}

		// Token: 0x06000FE2 RID: 4066 RVA: 0x000B2A64 File Offset: 0x000B1A64
		internal mt o()
		{
			return this.@as;
		}

		// Token: 0x06000FE3 RID: 4067 RVA: 0x000B2A7C File Offset: 0x000B1A7C
		internal void d(mt A_0)
		{
			this.@as = A_0;
		}

		// Token: 0x06000FE4 RID: 4068 RVA: 0x000B2A88 File Offset: 0x000B1A88
		internal mt p()
		{
			return this.at;
		}

		// Token: 0x06000FE5 RID: 4069 RVA: 0x000B2AA0 File Offset: 0x000B1AA0
		internal void e(mt A_0)
		{
			this.@as = A_0;
		}

		// Token: 0x06000FE6 RID: 4070 RVA: 0x000B2AAC File Offset: 0x000B1AAC
		internal bool q()
		{
			return this.f;
		}

		// Token: 0x06000FE7 RID: 4071 RVA: 0x000B2AC4 File Offset: 0x000B1AC4
		internal void d(bool A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06000FE8 RID: 4072 RVA: 0x000B2AD0 File Offset: 0x000B1AD0
		internal bool r()
		{
			return this.e;
		}

		// Token: 0x06000FE9 RID: 4073 RVA: 0x000B2AE8 File Offset: 0x000B1AE8
		internal void e(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06000FEA RID: 4074 RVA: 0x000B2AF4 File Offset: 0x000B1AF4
		internal bool s()
		{
			return this.g;
		}

		// Token: 0x06000FEB RID: 4075 RVA: 0x000B2B0C File Offset: 0x000B1B0C
		internal void f(bool A_0)
		{
			this.g = A_0;
		}

		// Token: 0x06000FEC RID: 4076 RVA: 0x000B2B18 File Offset: 0x000B1B18
		internal bool t()
		{
			return this.h;
		}

		// Token: 0x06000FED RID: 4077 RVA: 0x000B2B30 File Offset: 0x000B1B30
		internal void g(bool A_0)
		{
			this.h = A_0;
		}

		// Token: 0x06000FEE RID: 4078 RVA: 0x000B2B3C File Offset: 0x000B1B3C
		internal bool u()
		{
			return this.aq;
		}

		// Token: 0x06000FEF RID: 4079 RVA: 0x000B2B54 File Offset: 0x000B1B54
		internal void h(bool A_0)
		{
			this.aq = A_0;
		}

		// Token: 0x06000FF0 RID: 4080 RVA: 0x000B2B60 File Offset: 0x000B1B60
		internal x5 v()
		{
			return this.ao;
		}

		// Token: 0x06000FF1 RID: 4081 RVA: 0x000B2B78 File Offset: 0x000B1B78
		internal void e(x5 A_0)
		{
			this.ao = A_0;
		}

		// Token: 0x06000FF2 RID: 4082 RVA: 0x000B2B84 File Offset: 0x000B1B84
		internal mf w()
		{
			return this.j;
		}

		// Token: 0x06000FF3 RID: 4083 RVA: 0x000B2B9C File Offset: 0x000B1B9C
		internal void b(mf A_0)
		{
			this.j = A_0;
		}

		// Token: 0x06000FF4 RID: 4084 RVA: 0x000B2BA8 File Offset: 0x000B1BA8
		internal ms x()
		{
			return this.o;
		}

		// Token: 0x06000FF5 RID: 4085 RVA: 0x000B2BC0 File Offset: 0x000B1BC0
		internal void d(ms A_0)
		{
			this.o = A_0;
		}

		// Token: 0x06000FF6 RID: 4086 RVA: 0x000B2BCC File Offset: 0x000B1BCC
		internal ms y()
		{
			return this.p;
		}

		// Token: 0x06000FF7 RID: 4087 RVA: 0x000B2BE4 File Offset: 0x000B1BE4
		internal void e(ms A_0)
		{
			this.p = A_0;
		}

		// Token: 0x06000FF8 RID: 4088 RVA: 0x000B2BF0 File Offset: 0x000B1BF0
		internal virtual k0 dd()
		{
			return null;
		}

		// Token: 0x06000FF9 RID: 4089 RVA: 0x000B2C04 File Offset: 0x000B1C04
		internal override ld c8()
		{
			return this.an;
		}

		// Token: 0x06000FFA RID: 4090 RVA: 0x000B2C1C File Offset: 0x000B1C1C
		internal override void c9(ld A_0)
		{
			this.an = A_0;
		}

		// Token: 0x06000FFB RID: 4091 RVA: 0x000B2C28 File Offset: 0x000B1C28
		internal HtmlArea z()
		{
			return this.ai;
		}

		// Token: 0x06000FFC RID: 4092 RVA: 0x000B2C40 File Offset: 0x000B1C40
		internal void a(HtmlArea A_0)
		{
			this.ai = A_0;
		}

		// Token: 0x06000FFD RID: 4093 RVA: 0x000B2C4C File Offset: 0x000B1C4C
		internal x5 aa()
		{
			return this.r;
		}

		// Token: 0x06000FFE RID: 4094 RVA: 0x000B2C64 File Offset: 0x000B1C64
		internal void f(x5 A_0)
		{
			this.r = A_0;
		}

		// Token: 0x06000FFF RID: 4095 RVA: 0x000B2C70 File Offset: 0x000B1C70
		internal x5 ab()
		{
			return this.s;
		}

		// Token: 0x06001000 RID: 4096 RVA: 0x000B2C88 File Offset: 0x000B1C88
		internal void g(x5 A_0)
		{
			this.s = A_0;
		}

		// Token: 0x06001001 RID: 4097 RVA: 0x000B2C94 File Offset: 0x000B1C94
		internal x5 ac()
		{
			return this.q;
		}

		// Token: 0x06001002 RID: 4098 RVA: 0x000B2CAC File Offset: 0x000B1CAC
		internal void h(x5 A_0)
		{
			this.q = A_0;
		}

		// Token: 0x06001003 RID: 4099 RVA: 0x000B2CB8 File Offset: 0x000B1CB8
		internal ny ad()
		{
			return this.ac;
		}

		// Token: 0x06001004 RID: 4100 RVA: 0x000B2CD0 File Offset: 0x000B1CD0
		internal void a(ny A_0)
		{
			this.ac = A_0;
		}

		// Token: 0x06001005 RID: 4101 RVA: 0x000B2CDC File Offset: 0x000B1CDC
		internal ll ae()
		{
			if (this.ag == null)
			{
				this.ag = new ll(this);
			}
			return this.ag;
		}

		// Token: 0x06001006 RID: 4102 RVA: 0x000B2D10 File Offset: 0x000B1D10
		internal bool? af()
		{
			return this.aj;
		}

		// Token: 0x06001007 RID: 4103 RVA: 0x000B2D28 File Offset: 0x000B1D28
		internal int? ag()
		{
			return this.ak;
		}

		// Token: 0x06001008 RID: 4104 RVA: 0x000B2D40 File Offset: 0x000B1D40
		internal void b(int? A_0)
		{
			this.ak = A_0;
		}

		// Token: 0x06001009 RID: 4105 RVA: 0x000B2D4C File Offset: 0x000B1D4C
		internal bool ah()
		{
			return this.al;
		}

		// Token: 0x0600100A RID: 4106 RVA: 0x000B2D64 File Offset: 0x000B1D64
		internal void i(bool A_0)
		{
			this.al = A_0;
		}

		// Token: 0x0600100B RID: 4107 RVA: 0x000B2D70 File Offset: 0x000B1D70
		internal bool ai()
		{
			return this.am;
		}

		// Token: 0x0600100C RID: 4108 RVA: 0x000B2D88 File Offset: 0x000B1D88
		internal void j(bool A_0)
		{
			this.am = A_0;
		}

		// Token: 0x0600100D RID: 4109 RVA: 0x000B2D94 File Offset: 0x000B1D94
		private bool f()
		{
			bool result = false;
			if (!base.c5().c().au() && !base.c5().f().k())
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600100E RID: 4110 RVA: 0x000B2DD8 File Offset: 0x000B1DD8
		private bool e()
		{
			bool result = false;
			if (base.c5().v() == null && !base.c5().f().l())
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600100F RID: 4111 RVA: 0x000B2E1E File Offset: 0x000B1E1E
		private void a(ref x5 A_0, ref x5 A_1, ref x5 A_2, ref x5 A_3)
		{
			this.a(ref A_0, ref A_1);
			this.b(ref A_2, ref A_3);
		}

		// Token: 0x06001010 RID: 4112 RVA: 0x000B2E34 File Offset: 0x000B1E34
		private void b(ref x5 A_0, ref x5 A_1)
		{
			if (x5.d(A_1, base.c5().e().c()))
			{
				A_1 = base.c5().e().c();
			}
			if (x5.c(A_0, base.c5().e().c()))
			{
				A_0 = base.c5().e().c();
			}
		}

		// Token: 0x06001011 RID: 4113 RVA: 0x000B2EB8 File Offset: 0x000B1EB8
		private void a(ref x5 A_0, ref x5 A_1)
		{
			if (x5.d(A_1, base.c5().e().a()))
			{
				A_1 = base.c5().e().a();
			}
			if (x5.c(A_0, base.c5().e().a()))
			{
				A_0 = base.c5().e().a();
			}
		}

		// Token: 0x06001012 RID: 4114 RVA: 0x000B2F3C File Offset: 0x000B1F3C
		private bool a(int? A_0)
		{
			int valueOrDefault = A_0.GetValueOrDefault();
			if (A_0 != null)
			{
				if (valueOrDefault <= 423471123)
				{
					if (valueOrDefault <= 23684646)
					{
						if (valueOrDefault != 46415 && valueOrDefault != 23684646)
						{
							goto IL_7D;
						}
					}
					else if (valueOrDefault != 86147604 && valueOrDefault != 423471123)
					{
						goto IL_7D;
					}
				}
				else if (valueOrDefault <= 445520207)
				{
					if (valueOrDefault != 426354867 && valueOrDefault != 445520207)
					{
						goto IL_7D;
					}
				}
				else if (valueOrDefault != 506042859 && valueOrDefault != 673419368 && valueOrDefault != 899925938)
				{
					goto IL_7D;
				}
				return true;
			}
			IL_7D:
			return false;
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x000B2FCC File Offset: 0x000B1FCC
		private bool a(int A_0)
		{
			return A_0 == 445520207;
		}

		// Token: 0x06001014 RID: 4116 RVA: 0x000B2FF0 File Offset: 0x000B1FF0
		private void a(k0 A_0, bool A_1)
		{
			A_0.a((lk)base.c5().du());
			A_0.u(base.b5());
			A_0.ao(this.c2());
			A_0.h(base.ba());
			A_0.i(base.bb());
			A_0.l(base.bx());
			A_0.au(this.dy());
			A_0.@as(this.dt());
			A_0.a9(this.dw());
			A_0.j(this.dr());
			A_0.d4(this.d3());
			A_0.a(this.ds());
			A_0.d2(this.d1());
			A_0.dc(this.db().du());
			if (!A_1)
			{
				A_0.a(base.b6());
				A_0.a(this.bv());
			}
			if (this.dv() != null)
			{
				A_0.dw((nw)this.dv().du());
			}
			if (this.n() != null)
			{
				mt mt = null;
				mt mt2 = this.n();
				mu mu = mt2.c();
				while (mu != null && mu.a() != null)
				{
					ms ms = null;
					mq mq = mu.a().l();
					if (mq != null)
					{
						mr mr = mq.a();
						while (mr != null && mr.b() != null)
						{
							int num = mr.b().dg();
							kz kz;
							if (num != 100)
							{
								if (num != 1977 && num != 46415)
								{
									kz = ((k0)mr.b()).k(A_1);
									kz.j(mr.b().dr());
								}
								else
								{
									kz = mr.b();
									kz.j(mr.b().dr());
									kz.a((lk)mr.b().c5().du());
									kz.dc(mr.b().db().du());
								}
							}
							else
							{
								n3 n = (n3)mr.b();
								kz = n.dm();
								kz.j(mr.b().dr());
								kz.a((lk)mr.b().c5().du());
								kz.dc(mr.b().db().du());
							}
							if (ms == null)
							{
								ms = new ms(kz);
							}
							else
							{
								ms.l().a(kz);
							}
							mr = mr.c();
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
					mu = mu.b();
				}
				A_0.c(mt);
			}
		}

		// Token: 0x06001015 RID: 4117 RVA: 0x000B3310 File Offset: 0x000B2310
		private ae6 d()
		{
			ae6 result = null;
			ok a_ = ((mz)this).b();
			switch (a_)
			{
			case ok.a:
			case ok.b:
			case ok.c:
			case ok.d:
			case ok.e:
			case ok.j:
			case ok.k:
			case ok.l:
			case ok.m:
				result = new ae6(a_);
				break;
			case ok.f:
			case ok.g:
			case ok.h:
			case ok.i:
				break;
			default:
				result = new ae6(a_);
				break;
			}
			return result;
		}

		// Token: 0x06001016 RID: 4118 RVA: 0x000B3384 File Offset: 0x000B2384
		private void i(kz A_0)
		{
			ae6 ae = null;
			if (this.dg() == 2585 || this.dg() == 2595)
			{
				ae = this.d();
			}
			m1 m = ((mx)A_0).a();
			if (((mx)A_0).b() != -2147483648)
			{
				this.ah = ((mx)A_0).b();
			}
			if (m != null && !m.g())
			{
				ok ok = ((n5)m.db()).b().b();
				m.a(ok);
				ok a_;
				if (this.dg() != 1000)
				{
					a_ = ((ok != ok.v) ? ok : ((mz)this).b());
				}
				else
				{
					a_ = ok;
				}
				switch (a_)
				{
				case ok.f:
				case ok.g:
				case ok.h:
				case ok.i:
					if (!m.c())
					{
						this.ah++;
					}
					m.dj(this.b, this.c);
					break;
				default:
					if (ae == null)
					{
						ae = new ae6(a_);
					}
					ae.a(a_);
					m.a(ae.t(this.ah));
					if (!m.c())
					{
						this.ah++;
					}
					m.a(a_);
					m.dj(this.b, this.c);
					if (x5.c(A_0.a7(), x5.c()))
					{
						m.m(A_0.a7());
					}
					break;
				}
				((mx)A_0).a(m);
				if (x5.h(this.t, x5.c()) || x5.h(A_0.a9(), x5.c()))
				{
					this.t = m.ar();
				}
			}
			else
			{
				((mx)A_0).a(null);
			}
		}

		// Token: 0x06001017 RID: 4119 RVA: 0x000B3594 File Offset: 0x000B2594
		private void a(mr A_0, bool A_1)
		{
			if (A_0 != null && A_0.b() != null)
			{
				kz kz = A_0.b();
				if (kz.dg() == 86163053)
				{
					kz.ad(kz.ar());
					kz.ac(kz.ar());
					kz.y(kz.ar());
				}
				if (((x5.c(kz.aq(), x5.c()) || x5.c(this.l, x5.c())) && kz.c0()) || A_1)
				{
					if ((this.dg() == 11228793 && !kz.de()) || this.dg() != 11228793)
					{
						if (x5.d(base.a8(), kz.a8()))
						{
							base.ad(kz.a8());
						}
						if (x5.d(base.a7(), kz.a7()))
						{
							base.ac(kz.a7());
						}
						if (x5.d(base.a9(), kz.a9()))
						{
							base.ae(kz.a9());
						}
						if (x5.d(base.a3(), kz.a3()))
						{
							base.y(kz.a3());
						}
						if (x5.d(base.a4(), kz.a4()))
						{
							base.z(kz.a4());
						}
						if (x5.d(base.a5(), kz.a5()))
						{
							base.aa(kz.a5());
						}
						if (x5.c(kz.a3(), this.w))
						{
							this.w = kz.a3();
							this.x = kz.a4();
							this.y = kz.a5();
						}
						int num = this.dg();
						if (num == 86147604 || num == 506042859)
						{
							base.x(this.x);
						}
						if (x5.c(kz.a8(), this.ad))
						{
							this.ad = kz.a8();
						}
						if (x5.c(kz.a7(), this.ae))
						{
							this.ae = kz.a7();
						}
						if (x5.c(kz.a9(), this.af))
						{
							this.af = kz.a9();
						}
					}
				}
			}
		}

		// Token: 0x06001018 RID: 4120 RVA: 0x000B381B File Offset: 0x000B281B
		private void h(kz A_0)
		{
			A_0.i(x5.c());
			A_0.j(x5.c());
			A_0.k(x5.c());
			A_0.m(x5.c());
			A_0.l(x5.c());
		}

		// Token: 0x06001019 RID: 4121 RVA: 0x000B385C File Offset: 0x000B285C
		private void c()
		{
			if (this.dg() != 100 && this.dg() != 101 && this.dg() != 46415)
			{
				if (base.c5().n() == g3.a || base.c5().n() == g3.b)
				{
					x5 a_ = x5.c();
					if (this.c8().b().Count > 0)
					{
						x5 x = this.an.d();
						a_ = this.an.e();
						if (x5.d(x5.f(base.ao(), this.n().h()), x))
						{
							x5 a_2 = x5.e(x, x5.f(x5.f(base.ao(), this.n().h()), base.c5().a2()));
							mt mt = this.n();
							mt.b(x5.f(mt.h(), a_2));
						}
					}
					if (base.c5().an() && x5.c(a_, x5.c()))
					{
						base.l(a_);
					}
					else if (base.c5().am() == null)
					{
						if (base.c5().q() == g6.c)
						{
							base.l(x5.f(this.a.g(), this.aa()));
						}
						else
						{
							x5 a_3 = this.n().g();
							base.l(x5.g(a_3, x5.c()) ? (x5.c(x5.f(a_3, this.aa()), base.aq()) ? x5.f(a_3, this.aa()) : base.aq()) : base.aq());
						}
					}
				}
				else
				{
					int num = this.dg();
					if (num > 3418)
					{
						if (num <= 426354867)
						{
							if (num == 258605815)
							{
								goto IL_332;
							}
							if (num != 426354867)
							{
								goto IL_354;
							}
						}
						else if (num != 445520207)
						{
							if (num != 718642778)
							{
								goto IL_354;
							}
							goto IL_332;
						}
						if (base.c5().am() == null)
						{
							base.l(x5.f(this.a.g(), this.aa()));
						}
						goto IL_406;
					}
					if (num != 1946)
					{
						if (num != 3034 && num != 3418)
						{
							goto IL_354;
						}
						if (this.c8().b().Count > 0)
						{
							x5 x = this.an.d();
							if (x5.d(x5.f(base.ao(), this.n().h()), x))
							{
								x5 a_2 = x5.e(x, x5.f(base.ao(), this.n().h()));
								mt mt2 = this.n();
								mt2.b(x5.f(mt2.h(), a_2));
							}
						}
						goto IL_406;
					}
					IL_332:
					base.l(x5.f(this.a.g(), this.aa()));
					goto IL_406;
					IL_354:
					if (base.c5().am() == null)
					{
						if (base.c5().q() == g6.c)
						{
							base.l(x5.f(this.a.g(), this.aa()));
						}
						else
						{
							x5 a_3 = this.n().g();
							base.l(x5.g(a_3, x5.c()) ? (x5.c(x5.f(a_3, this.aa()), base.aq()) ? x5.f(a_3, this.aa()) : base.aq()) : base.aq());
						}
					}
					IL_406:;
				}
			}
		}

		// Token: 0x0600101A RID: 4122 RVA: 0x000B3C74 File Offset: 0x000B2C74
		private void b()
		{
			if (base.c5().v() == null && this.n().e() == null)
			{
				if (x5.g(base.c5().ak(), x5.c()) && x5.g(base.c5().ai(), x5.c()))
				{
					if (x5.c(base.c5().ak(), base.c5().ai()))
					{
						base.c5().i(new x5?(base.c5().ak()));
					}
					else if (x5.c(this.a.h(), base.c5().ai()))
					{
						base.c5().i(new x5?(base.c5().ai()));
					}
				}
				else if (x5.g(base.c5().ak(), x5.c()) && x5.d(this.a.h(), base.c5().ak()))
				{
					base.c5().i(new x5?(base.c5().ak()));
				}
				else if (x5.g(base.c5().ai(), x5.c()) && x5.c(this.a.h(), base.c5().ai()))
				{
					base.c5().i(new x5?(base.c5().ai()));
				}
			}
		}

		// Token: 0x0600101B RID: 4123 RVA: 0x000B3E2C File Offset: 0x000B2E2C
		private bool b(g3 A_0)
		{
			if (this.o != null)
			{
				for (mr mr = this.o.l().a(); mr != null; mr = mr.c())
				{
					if (A_0 == g3.a)
					{
						if (mr.b().c5().n() == g3.a)
						{
							if (mr.b().c1())
							{
								return false;
							}
						}
					}
					else if (A_0 == g3.b)
					{
						if (mr.b().c5().n() == g3.b)
						{
							if (mr.b().c1())
							{
								return false;
							}
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0600101C RID: 4124 RVA: 0x000B3F00 File Offset: 0x000B2F00
		private void a()
		{
			this.m = this.dc();
			this.n = this.df();
			this.z = null;
			this.k = null;
			this.d = x5.c();
			this.u = x5.c();
			this.l = x5.c();
			this.t = x5.c();
			this.q = x5.c();
			this.v = x5.c();
			this.w = x5.c();
			this.x = x5.c();
			this.y = x5.c();
			this.ae = x5.c();
			this.ad = x5.c();
			this.af = x5.c();
			this.ao = x5.c();
			base.a1(x5.c());
			base.a2(x5.c());
		}

		// Token: 0x0600101D RID: 4125 RVA: 0x000B3FDC File Offset: 0x000B2FDC
		private void a(g3? A_0, x5 A_1, ref mr A_2, mu A_3, x5 A_4, ref bool A_5)
		{
			kz kz = A_2.b();
			kz.ai(base.ar());
			lk lk = kz.c5();
			kz.a(new nb());
			A_5 = true;
			bool flag = false;
			x5 x = this.c;
			if (!kz.ct())
			{
				x = this.a(kz, x);
				if (x5.h(x, x5.c()))
				{
					x = this.c;
				}
				if (lk.q() == g6.b || lk.q() == g6.c)
				{
					switch (kz.c5().r())
					{
					case g7.c:
					case g7.d:
						if (x5.d(x, x5.c()))
						{
							flag = true;
							lk.a(new x5?(x5.d(x)));
						}
						break;
					}
				}
				if (A_0 != null && A_0 != g3.c)
				{
					kz.ap(true);
				}
			}
			if (!kz.ct())
			{
				this.k = kz.dj(A_1, x);
				if (kz.dg() == 46415)
				{
					if (!kz.c0() && !flag)
					{
						md md = (md)kz;
						this.i = true;
						this.k = md.d(x);
					}
				}
				if (kz.c5().q() == g6.b)
				{
					this.t = kz.ar();
					if (x5.c(this.d, x5.c()))
					{
						kz.n(this.d);
					}
				}
			}
			if (base.ch())
			{
				if (!base.ci())
				{
					this.k = null;
					if (A_2.b().dg() != 3418)
					{
						if (x5.a(A_2.b().aq(), this.b))
						{
							A_2.a(null);
						}
					}
				}
			}
			if (this.k != null)
			{
				if (this.p == null)
				{
					this.p = new ms(this.k);
				}
				else
				{
					this.p.l().a(this.k);
				}
				this.k = null;
			}
			if (!flag)
			{
				this.a(A_3, A_2);
			}
			else
			{
				A_3.a().c(A_2);
			}
		}

		// Token: 0x0600101E RID: 4126 RVA: 0x000B42A4 File Offset: 0x000B32A4
		private x5 a(kz A_0, x5 A_1)
		{
			lk lk = A_0.c5();
			if (this.dg() == 11228793)
			{
				if (A_0.dg() == 46415)
				{
					A_1 = x5.e(A_1, ((A_0.c5().a() != null) ? A_0.c5().a() : new x5?(x5.c())).Value);
				}
				else
				{
					A_1 = (((k0)A_0).ar = x5.e(A_1, ((A_0.c5().a() != null) ? A_0.c5().a() : new x5?(x5.c())).Value));
				}
			}
			else if (lk.q() == g6.c)
			{
				if (A_0.dg() == 46415)
				{
					A_1 = x5.e(A_1, ((A_0.c5().a() != null) ? A_0.c5().a() : new x5?(x5.c())).Value);
				}
				else
				{
					A_1 = (((k0)A_0).ar = x5.e(this.ar, ((A_0.c5().a() != null) ? A_0.c5().a() : new x5?(x5.c())).Value));
				}
			}
			else if (lk.q() == g6.b)
			{
				if (A_0.dg() == 46415)
				{
					A_1 = x5.e(A_1, ((A_0.c5().a() != null) ? A_0.c5().a() : new x5?(x5.c())).Value);
				}
				else
				{
					A_1 = (((k0)A_0).ar = x5.e(A_1, (A_0.c5().a() != null) ? A_0.c5().a().Value : x5.c()));
				}
			}
			return A_1;
		}

		// Token: 0x0600101F RID: 4127 RVA: 0x000B44F0 File Offset: 0x000B34F0
		private void a(g0? A_0, g3 A_1, x5 A_2, x5 A_3, ref mr A_4, mu A_5, int A_6, bool A_7)
		{
			kz kz = A_4.b();
			x5 x = A_5.a().am();
			x5 x2 = A_3;
			x5 x3 = x5.c();
			bool flag = false;
			bool flag2 = false;
			if ((kz.de() || kz.dg() == 46415) && A_0 != null && A_0 != g0.d)
			{
				if (x5.g(this.t, x5.c()))
				{
					A_3 = x5.f(A_3, this.t);
				}
				if (x5.c(A_5.a().am(), x5.c()))
				{
					A_3 = x5.f(A_3, A_5.a().am());
				}
				x3 = this.a(kz, ref A_2, x5.f(A_3, base.ao()), A_5.a(), true);
				if (x5.h(x3, x5.c()))
				{
					x2 = x5.f(A_3, base.ao());
					flag2 = true;
				}
				if (x5.c(x3, x5.c()))
				{
					if (x5.g(x3, A_3))
					{
						x2 = x3;
					}
					else if (kz.de())
					{
						x2 = x3;
					}
				}
			}
			else if (x5.c(x, x5.c()) && x5.c(x, x5.f(base.ao(), A_5.a().ag())))
			{
				x2 = x;
			}
			else
			{
				x2 = A_3;
				if (!A_7 && !flag2)
				{
					x2 = x5.f(x2, base.ao());
				}
			}
			kz.di();
			x5 x4 = this.a(A_1);
			x5 x5 = x5.c();
			int num = kz.dg();
			if (num == 144937050)
			{
				((nv)kz).d(this.b);
			}
			if (kz.c5().am() != null)
			{
				x5 = x5.f(x5.f(kz.c5().am().Value, kz.c5().a1()), kz.c5().a0());
			}
			else if (x5.d(kz.dn(), x4))
			{
				x5 = kz.dn();
			}
			else
			{
				x5 = x4;
			}
			bool flag3 = true;
			x5 x6 = x5.c();
			bool flag4 = false;
			if (x5.a(x2, A_5.a().ag()))
			{
				x6 = x2;
				if (x5.c(A_2, x5))
				{
					flag4 = true;
				}
			}
			else
			{
				if (A_0 == null || A_0.Value == g0.d)
				{
					if (!base.cp() && base.c5().q() != g6.b && base.c5().q() != g6.c)
					{
						if (!flag2)
						{
							x6 = x5.f(x6, base.ao());
						}
					}
				}
				x5 x7 = x5.c();
				if (A_5.c() != null)
				{
					x7 = A_5.a().a6();
					if (x5.c(x7, x5.c()))
					{
						x6 = x5.e(x6, x7);
					}
					else
					{
						x6 = x5.f(x6, x7);
					}
				}
				else
				{
					x6 = x5.e(x6, A_5.a().bc());
				}
			}
			if (x5.c(base.ap(), x5.c()))
			{
				x6 = x5.f(x6, base.ap());
			}
			x2 = x6;
			x5 x8 = this.m;
			x5 x9 = x2;
			x5 x10 = x5.c();
			int num2 = 0;
			ld ld = this.bv();
			x5 a_ = x5.c();
			num = this.dg();
			if (num != 3034 && num != 3418)
			{
				if (kz.c3() && base.c5().n() != g3.c)
				{
					ld = this.c8();
				}
			}
			else
			{
				ld = this.c8();
			}
			if (this.dg() == 11228793 && kz.dr().dg() != 11228793)
			{
				x4 = kz.dr().bi();
			}
			if (x5.c(x5, A_2) && !flag4)
			{
				if (x5.g(this.t, x5.c()))
				{
					x9 = x5.f(x9, this.t);
				}
				else
				{
					x9 = ld.d(x9);
				}
				x9 = x5.f(x9, this.ao);
				num2++;
			}
			x5 a_2 = x5.f(kz.c5().a1(), kz.c5().a0());
			if (kz.c5().am() == null)
			{
				kz.c5().j(new x5?(x5.e(x5, a_2)));
				kz.c5().d(i2.d);
			}
			if (x5.c(x5, x5.c()))
			{
				if (kz.c3())
				{
					kz.ah(x4);
				}
				else
				{
					kz.ah(x5);
				}
			}
			if (x5.c(base.cv(), base.cw()) && x5.c(base.cv(), x9))
			{
				x9 = base.cv();
			}
			else if (x5.c(base.cw(), base.cv()) && x5.c(base.cw(), x9))
			{
				x9 = base.cw();
			}
			if (x5.c(this.c, x5.c()))
			{
				do
				{
					x2 = x9;
					x8 = ld.a(x9);
					x10 = ld.a(x9, x4);
					if (x5.c(x8, base.ax()))
					{
						A_2 = x5.e(x4, x8);
					}
					else
					{
						A_2 = x5.e(x4, kz.ax());
					}
					if (x5.c(x10, base.ay()))
					{
						A_2 = x5.e(A_2, x10);
					}
					else
					{
						A_2 = x5.e(A_2, kz.ay());
					}
					if (x5.h(x8, x5.c()) && x5.h(x10, x5.c()))
					{
						break;
					}
					flag3 = false;
					num = num2;
					if (num != 0)
					{
						if (x5.d(A_2, x5))
						{
							x9 = ld.d(x9);
						}
					}
					else if (x5.d(A_2, x5))
					{
						x9 = ld.d(x9);
						this.t = x5.c();
					}
					num2++;
					if (x5.h(x9, x2) && x5.d(A_2, x5))
					{
						x9 = x5.f(x9, x5.a(5f));
					}
				}
				while (x5.c(x5, A_2) && x5.c(base.bl(), x2));
				if (x5.c(x9, x2))
				{
					x8 = x5.c();
					x10 = x5.c();
					flag3 = true;
					x2 = x9;
				}
			}
			if (A_1 == g3.a)
			{
				if (x5.h(base.cv(), x5.c()))
				{
					base.a1(x2);
				}
				else if (x5.c(x2, base.cv()))
				{
					base.a1(x2);
				}
			}
			if (A_1 == g3.b)
			{
				if (flag3)
				{
					x10 = ld.a(x2, kz.aq());
				}
				if (x5.d(base.ay(), x10))
				{
					A_2 = x5.e(x4, x10);
				}
				else
				{
					A_2 = x5.e(x4, base.ay());
				}
				if (x5.h(base.cw(), x5.c()))
				{
					base.a2(x2);
				}
				else if (x5.c(x2, base.cw()))
				{
					base.a2(x2);
				}
			}
			kz.ap(true);
			x5 x11 = A_2;
			kz.j(x2);
			x5 x12 = x5.e(this.c, x5.e(x2, x5.f(base.ao(), A_5.a().ag())));
			if (A_6 == 0)
			{
				kz kz2 = kz;
				kz2.j(x5.f(kz2.ao(), kz.d5()));
			}
			this.k = kz.dj(x11, x12);
			if (this.k != null)
			{
				this.k.a8(kz.dp());
				this.k.a7(kz.dn());
			}
			if (base.ch())
			{
				if (!base.ci())
				{
					this.k = null;
					if (A_4.b().dg() != 3418)
					{
						if (x5.a(A_4.b().aq(), x11))
						{
							A_4.a(null);
						}
					}
				}
			}
			if (A_4 != null && kz != null && kz.dg() == 1000)
			{
				this.i(kz);
			}
			if (x5.h(this.m, x5.c()) && x5.c(x8, x5.c()))
			{
				this.m = x8;
			}
			if (x5.h(x2, A_3) || x5.h(x2, x5.f(x5.f(x5.f(A_3, base.ao()), base.ap()), a_)))
			{
				A_4 = this.a(A_5, A_4, x2, false, flag3, x11, x12, ref flag);
			}
			else
			{
				A_4 = this.a(A_5, A_4, x2, true, flag3, x11, x12, ref flag);
			}
			if (A_0 != null && A_0.Value == g0.c && x5.c(x3, x5.c()))
			{
				A_3 = x2;
				A_5.a().k(true);
				A_5.a().u(x2);
			}
		}

		// Token: 0x06001020 RID: 4128 RVA: 0x000B4FA4 File Offset: 0x000B3FA4
		private x5 a(g3 A_0)
		{
			x5 a_ = x5.c();
			int num = this.dg();
			x5 result;
			if (num != 11228793)
			{
				if (base.c5().n() == g3.c)
				{
					if (base.c5().am() == null)
					{
						kz kz = this.dr();
						while (kz != null)
						{
							if (kz.c5().am() == null)
							{
								if (kz.c5().n() != g3.c)
								{
									return x5.e(kz.bi(), x5.f(kz.c5().a1(), kz.c5().a0()));
								}
								if (kz.dg() == 11228793)
								{
									a_ = x5.e(kz.bi(), x5.f(kz.c5().a1(), kz.c5().a0()));
								}
								kz = kz.dr();
							}
							else
							{
								if (kz.c5().am() != null)
								{
									return kz.bi();
								}
								if (kz.c5().n() != g3.c)
								{
									return x5.e(kz.bi(), x5.f(kz.c5().a1(), kz.c5().a0()));
								}
								if (kz.dg() == 11228793)
								{
									return x5.e(kz.bi(), x5.f(kz.c5().a1(), kz.c5().a0()));
								}
								kz = kz.dr();
							}
						}
						if (this.dg() == 11228793)
						{
							result = base.bi();
						}
						else if (A_0 == g3.b)
						{
							result = x5.e(a_, base.c5().a0());
						}
						else
						{
							result = x5.e(a_, base.c5().a1());
						}
					}
					else if (A_0 == g3.b)
					{
						result = base.bi();
					}
					else
					{
						result = x5.e(base.bi(), base.c5().a1());
					}
				}
				else if (A_0 == g3.b)
				{
					result = base.bi();
				}
				else
				{
					result = x5.e(base.bi(), base.c5().a1());
				}
			}
			else
			{
				result = base.bi();
			}
			return result;
		}

		// Token: 0x06001021 RID: 4129 RVA: 0x000B5250 File Offset: 0x000B4250
		private void a(ref mr A_0, mu A_1, x5 A_2, int A_3, ref int A_4, ref int A_5, ref bool A_6, bool A_7)
		{
			ms ms = A_1.a();
			kz kz = A_0.b();
			bool flag = false;
			kz.ak(this.cy());
			if (!kz.de())
			{
				kz.r(this.d);
				if (A_7)
				{
					kz.i(this.d);
				}
			}
			if (this.ag() == null || kz.d1() <= this.ag())
			{
				if (A_0 != null && kz != null && kz.dg() == 1000)
				{
					this.i(kz);
				}
				if (kz.de() && kz.de() == this.de())
				{
					if (this.dg() == 11228793)
					{
						((k0)kz).ar = base.bl();
					}
					else
					{
						((k0)kz).ar = this.ar;
					}
				}
				int num = kz.dg();
				switch (num)
				{
				case 100:
					if (kz.bo() != -1)
					{
						bool a_ = this.a(A_0, A_2);
						((n3)kz).g(a_);
					}
					break;
				case 101:
					if (kz.bo() != -1)
					{
						bool a_ = this.a(A_0, A_2);
						((nn)kz).a(a_);
					}
					break;
				default:
					if (num == 137440 || num == 235744)
					{
						if (kz.dg() == 235744)
						{
							kz.q(true);
						}
						if (kz.dg() == 137440)
						{
							kz.p(true);
						}
						if (x5.d(this.b, x5.f(kz.b2(), x5.a(1f))))
						{
							mr mr = A_0.d();
							if (!mr.b().b1())
							{
								this.k = mr.b().dl();
								A_0 = A_0.d();
								switch (mr.b().dg())
								{
								case 100:
									this.d = x5.e(this.d, ((n3)mr.b()).b3());
									break;
								case 101:
									this.d = x5.e(this.d, ((nn)mr.b()).b3());
									break;
								default:
									this.d = x5.e(this.d, mr.b().b3());
									break;
								}
								flag = true;
							}
						}
					}
					break;
				}
				if (!flag)
				{
					this.k = kz.dj(A_2, this.c);
					if (base.bt() && kz.dg() != 100)
					{
						base.ao(kz.br());
						base.ap(kz.bs());
					}
					if (base.bt() && kz.dg() != 100)
					{
						base.an(kz.bq());
					}
				}
				if (this.k != null && (!kz.c1() || this.k.c5().q() == g6.d))
				{
					ms.p(true);
				}
				num = kz.dg();
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
							goto IL_54B;
						}
						goto IL_3ED;
					}
				}
				else
				{
					if (num == 3418)
					{
						goto IL_3ED;
					}
					if (num != 46415)
					{
						goto IL_54B;
					}
				}
				goto IL_5EC;
				IL_3ED:
				if (((n5)kz.db()).z() > 1)
				{
					this.i(true);
					((k0)this.dr()).i(true);
					if (this.c0() && !kz.c0())
					{
						this.am(kz.c0());
					}
				}
				if (this.k != null)
				{
					mr mr2 = A_0;
					if (A_0.d() != null)
					{
						while (mr2.d() != null)
						{
							if (!mr2.d().b().c1())
							{
								((nt)mr2.d().b()).g(true);
							}
							mr2 = mr2.d();
						}
					}
					if (!mr2.b().c1())
					{
						((nt)mr2.b()).g(true);
					}
				}
				else if (!A_0.b().c1() && this.z != null)
				{
					((nt)A_0.b()).g(true);
				}
				this.c(((k0)kz).x());
				this.b(((k0)kz).y());
				goto IL_5EC;
				IL_54B:
				num = this.dg();
				if (num == 1946 || num == 144937050 || num == 718642778)
				{
					if (this.ah())
					{
						((k0)this.dr()).i(this.ah());
					}
					int? a_2 = ((k0)kz).ag();
					if (a_2 != null)
					{
						this.b(a_2);
					}
				}
				this.c(((k0)kz).x());
				this.b(((k0)kz).y());
				this.e(kz);
				IL_5EC:;
			}
			else
			{
				kz.am(false);
				kz.dr().am(false);
				A_6 = true;
			}
			if (kz.dg() == 144937050 && kz.c5().t() == g2.c)
			{
				ms.aa(this.ag.c(((k0)A_0.b()).n()));
			}
			if (kz.c0())
			{
				A_5 += kz.ba();
				A_4 += kz.bb();
				this.l = kz.ar();
				if (kz.dg() == 46415)
				{
					this.l = x5.f(this.l, x5.a(3f));
				}
				if (x5.c(kz.a6(), x5.c()))
				{
					ms.l(kz.a6());
				}
			}
			else if (kz.c1())
			{
				this.l = kz.ar();
			}
			if (kz.dg() != 102)
			{
				this.a(A_1, ref A_0, A_3);
			}
			if (base.ch())
			{
				if (!base.ci())
				{
					this.k = null;
					int num = kz.dg();
					if (num <= 144937050)
					{
						if (num != 1946 && num != 3418 && num != 144937050)
						{
							goto IL_7C3;
						}
					}
					else if (num <= 442866842)
					{
						if (num != 258605815 && num != 442866842)
						{
							goto IL_7C3;
						}
					}
					else if (num != 718642778 && num != 889490394)
					{
						goto IL_7C3;
					}
					goto IL_7E8;
					IL_7C3:
					if (x5.a(kz.aq(), this.b))
					{
						A_0.a(null);
					}
					IL_7E8:;
				}
			}
			if (this.k == null && kz != null && kz.dj())
			{
				this.a(A_1.a(), ref A_0, true, false);
			}
			else if (A_6)
			{
				this.a(A_1.a(), ref A_0, false, false);
			}
			else if (x5.c(kz.a6(), x5.c()) && kz.c0())
			{
				A_0 = ((A_0.c() != null) ? A_0.c() : null);
				this.a(A_1.a(), ref A_0, false, false);
			}
		}

		// Token: 0x06001022 RID: 4130 RVA: 0x000B5AE8 File Offset: 0x000B4AE8
		private bool a(mr A_0, x5 A_1)
		{
			x5 a_ = x5.c();
			x5 x = x5.c();
			x5 x2 = x5.c();
			x5 a_2 = x5.c();
			bool flag = false;
			if (A_0.b() != null)
			{
				switch (A_0.b().dg())
				{
				case 100:
				{
					n3 n = (n3)A_0.b();
					a_ = n.dn();
					x = n.b3();
					a_ = x5.e(a_, x);
					break;
				}
				case 101:
				{
					nn nn = (nn)A_0.b();
					a_ = nn.dn();
					x = nn.b3();
					a_ = x5.e(a_, x);
					break;
				}
				}
				if (A_0.c() != null)
				{
					mr mr = A_0.c();
					if (mr != null && mr.b() != null)
					{
						x2 = mr.b().b2();
						if (mr.b().bb() == 1)
						{
							mr mr2 = mr.c();
							if (mr2 != null && mr2.b() != null)
							{
								if (mr2.b().bo() != -1)
								{
									flag = true;
									a_2 = mr2.b().b2();
								}
							}
						}
					}
				}
				if (x5.c(x, x5.c()))
				{
					if (x5.c(x2, x5.c()))
					{
						if (flag)
						{
							if (x5.c(x5.f(x5.f(x5.f(a_, x), x2), a_2), A_1))
							{
								return true;
							}
						}
						else if (x5.c(x5.f(x5.f(a_, x), x2), A_1))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06001023 RID: 4131 RVA: 0x000B5CD0 File Offset: 0x000B4CD0
		private void c(ms A_0)
		{
			if (A_0 != null)
			{
				if (this.o == null)
				{
					this.o = A_0;
				}
				else if (A_0.l() != null)
				{
					for (mr mr = A_0.l().a(); mr != null; mr = mr.c())
					{
						if (this.o.l() != null)
						{
							this.o.l().a(mr.b());
						}
						else
						{
							this.o = new ms(mr.b());
						}
					}
				}
			}
		}

		// Token: 0x06001024 RID: 4132 RVA: 0x000B5D74 File Offset: 0x000B4D74
		private void b(ms A_0)
		{
			if (A_0 != null)
			{
				if (this.p == null)
				{
					this.p = A_0;
				}
				else if (A_0.l() != null)
				{
					for (mr mr = A_0.l().a(); mr != null; mr = mr.c())
					{
						if (this.p.l() != null)
						{
							this.p.l().a(mr.b());
						}
						else
						{
							this.p = new ms(mr.b());
						}
					}
				}
			}
		}

		// Token: 0x06001025 RID: 4133 RVA: 0x000B5E18 File Offset: 0x000B4E18
		private void g(kz A_0)
		{
			if (A_0 != null)
			{
				if (this.o == null)
				{
					this.o = new ms(A_0);
				}
				else
				{
					this.o.l().a(A_0);
				}
			}
		}

		// Token: 0x06001026 RID: 4134 RVA: 0x000B5E60 File Offset: 0x000B4E60
		private x5 a(kz A_0, ref x5 A_1, x5 A_2, ms A_3, bool A_4)
		{
			bool flag = false;
			x5 x = x5.c();
			if (this.bv().b().Count > 0)
			{
				flag = true;
			}
			else if (this.c8().b().Count > 0)
			{
				flag = true;
			}
			x5 result;
			if (flag || x5.g(A_1, base.aq()))
			{
				int num = this.dg();
				g0? g;
				g0 valueOrDefault;
				if (num != 3034 && num != 3418)
				{
					g = A_0.c5().o();
					valueOrDefault = g.GetValueOrDefault();
					if (g != null)
					{
						switch (valueOrDefault)
						{
						case g0.a:
							if (!this.c3() || A_0.c5().n() == g3.c)
							{
								x = this.bv().a(true, false, A_0, A_2, false, A_4);
							}
							else
							{
								x = this.c8().a(true, false, A_0, A_2, true, A_4);
							}
							this.m = x5.c();
							break;
						case g0.b:
							if (!this.c3() || A_0.c5().n() == g3.c)
							{
								x = this.bv().a(false, true, A_0, A_2, false, A_4);
							}
							else
							{
								x = this.c8().a(false, true, A_0, A_2, true, A_4);
							}
							break;
						case g0.c:
						{
							x5 x2 = x5.c();
							if (!this.c3() || A_0.c5().n() == g3.c)
							{
								bool flag2 = false;
								while (!flag2)
								{
									x = this.bv().a(true, true, A_0, A_2, false, A_4);
									x5 a_ = this.bv().a(x5.f(A_2, x));
									x5 a_2 = this.bv().a(x5.f(A_2, x), A_0);
									if ((x5.h(a_, x5.c()) && x5.h(a_2, x5.c())) || x5.h(x, x5.c()))
									{
										flag2 = true;
									}
									else
									{
										A_2 = x5.f(A_2, x);
										x2 = x5.f(x2, x);
										if (x5.h(x, x5.c()))
										{
											flag2 = true;
										}
									}
								}
								x2 = x5.f(x2, x);
							}
							else
							{
								x = this.c8().a(true, true, A_0, A_2, true, A_4);
							}
							x = x2;
							this.m = x5.c();
							A_3.m(x5.c());
							A_0.dp(true);
							break;
						}
						}
					}
				}
				else
				{
					g = A_0.c5().o();
					valueOrDefault = g.GetValueOrDefault();
					if (g != null)
					{
						switch (valueOrDefault)
						{
						case g0.a:
							x = this.c8().a(true, false, A_0, A_2, this.c3(), A_4);
							this.m = x5.c();
							break;
						case g0.b:
							x = this.c8().a(false, true, A_0, A_2, this.c3(), A_4);
							break;
						case g0.c:
							x = this.c8().a(true, true, A_0, A_2, this.c3(), A_4);
							this.m = x5.c();
							A_3.m(x5.c());
							A_0.dp(true);
							break;
						}
					}
				}
				if (A_0.c5().n() == g3.c)
				{
					this.b = x5.e(x5.e(A_0.bi(), A_0.ax()), A_0.ay());
					A_3.k(true);
					g = A_0.c5().o();
					valueOrDefault = g.GetValueOrDefault();
					if (g != null)
					{
						switch (valueOrDefault)
						{
						case g0.a:
							this.b = x5.e(this.b, A_0.bv().a(A_2));
							break;
						case g0.b:
							this.b = x5.e(this.b, A_0.bv().a(A_2, A_0));
							break;
						}
					}
				}
				A_1 = x5.e(x5.e(base.bi(), A_0.ax()), A_0.ay());
				A_0.al(true);
				g = A_0.c5().o();
				valueOrDefault = g.GetValueOrDefault();
				if (g != null)
				{
					switch (valueOrDefault)
					{
					case g0.a:
						A_1 = x5.e(A_1, A_0.bv().a(x));
						break;
					case g0.b:
						A_1 = x5.e(A_1, A_0.bv().a(x, A_0));
						break;
					}
				}
				result = x;
			}
			else
			{
				result = x5.c();
			}
			return result;
		}

		// Token: 0x06001027 RID: 4135 RVA: 0x000B6324 File Offset: 0x000B5324
		private mr a(kz A_0, mu A_1, mr A_2, int A_3)
		{
			if (this.k != null)
			{
				if (A_0 != null)
				{
					int num = A_0.dg();
					switch (num)
					{
					case 100:
					case 101:
					case 102:
						break;
					default:
						if (num == 3034 || num == 3418)
						{
							if (A_3 == 1)
							{
								this.z = null;
							}
							base.an(true);
							int num2 = ((n5)A_0.db()).z();
							if (num2 > 1)
							{
								if (this.aj == null)
								{
									this.aj = new bool?(true);
								}
								if (this.ag() == null || this.ag().Value < A_0.d1() + num2 - 1)
								{
									this.b(new int?(A_0.d1() + num2 - 1));
								}
							}
							else
							{
								this.aj = new bool?(false);
							}
							this.a(A_1.a(), A_3);
						}
						break;
					}
				}
				if (this.dg() != 11228793 && A_2 != null)
				{
					base.x(A_0.b9());
				}
				if (this.dg() != 1946 && !this.cx() && this.k.c5().q() == g6.a)
				{
					this.a(A_1.a(), ref A_2, false, false);
				}
				else
				{
					A_2 = ((A_2 != null) ? A_2.c() : null);
				}
			}
			else if (A_2 != null && A_0 != null)
			{
				int num = A_0.dg();
				if (num != 3034 && num != 3418)
				{
					A_2 = A_2.c();
				}
				else
				{
					if (this.z != null)
					{
						nt nt = ((nt)A_0).m();
						nt.g = true;
						this.z.l().a(nt);
					}
					A_2 = A_2.c();
				}
			}
			else
			{
				A_2 = ((A_2 != null) ? A_2.c() : null);
			}
			return A_2;
		}

		// Token: 0x06001028 RID: 4136 RVA: 0x000B655C File Offset: 0x000B555C
		private bool a(kz A_0, x5 A_1, int A_2, ms A_3)
		{
			if (A_0.c5().n() == g3.c)
			{
				x5 x = x5.c();
				if (!A_0.de())
				{
					int num = A_0.dg();
					if (num <= 3034)
					{
						switch (num)
						{
						case 100:
						case 101:
						case 102:
							num = this.dg();
							if (num <= 86147604)
							{
								if (num != 23684646 && num != 86147604)
								{
									goto IL_11E;
								}
							}
							else if (num != 423471123)
							{
								if (num == 445520207)
								{
									if (this is mj)
									{
										x = A_0.c5().am().Value;
									}
									else
									{
										x = base.c5().am().Value;
									}
									goto IL_185;
								}
								if (num != 506042859)
								{
									goto IL_11E;
								}
							}
							x = base.c5().am().Value;
							goto IL_185;
							IL_11E:
							if (A_3.a1())
							{
								x = A_0.aq();
							}
							else
							{
								x = A_0.dh();
								x = A_0.b2();
								if (x5.d(this.b, A_0.b2()))
								{
									if (A_0.cx())
									{
										A_3.p(true);
									}
									A_0.aj(true);
								}
							}
							IL_185:
							goto IL_203;
						default:
							if (num != 3034)
							{
								goto IL_187;
							}
							break;
						}
					}
					else if (num != 3418 && num != 144937050)
					{
						goto IL_187;
					}
					x = A_1;
					goto IL_203;
					IL_187:
					if (this.a(new int?(A_0.dg())))
					{
						if (A_3.a1())
						{
							x = A_0.aq();
						}
						else if (A_0.c5().am() != null)
						{
							x = A_0.c5().am().Value;
						}
					}
					else
					{
						x = this.b((k0)A_0);
					}
					IL_203:;
				}
				else
				{
					int num = A_0.dg();
					if (num == 144937050)
					{
						if (A_0.c5().am() != null)
						{
							x = A_0.c5().am().Value;
						}
						else
						{
							x = A_0.dh();
						}
					}
				}
				if (x5.c(x, A_1))
				{
					if (A_2 > 1)
					{
						return false;
					}
					ld ld = this.bv();
					if (this.dg() == 3418 || this.dg() == 3034 || this.c3())
					{
						ld = this.an;
					}
					if (ld.b().Count > 0)
					{
						bool flag = false;
						x5 x2 = x5.c();
						x5 x3 = x5.c();
						x5 x4 = A_0.bi();
						if (A_0.dg() == 100 || A_0.dg() == 101)
						{
							x4 = x5.e(base.bi(), this.aa());
						}
						x5 x5 = x5.f(A_3.ag(), base.ao());
						x5 x6 = x5;
						int num2 = 0;
						while (x5.a(x, A_1) && x5.d(A_1, x4))
						{
							x5 = x6;
							if (A_0.dg() == 100 || A_0.dg() == 101)
							{
								x2 = ld.a(x5);
								x3 = ld.a(x5, this);
								x4 = base.bi();
							}
							else
							{
								x2 = ld.a(x5);
								x3 = ld.a(x5, A_0);
							}
							if (x5.h(x2, x5.c()) && x5.h(x3, x5.c()))
							{
								A_1 = x4;
								break;
							}
							x5 x7 = x5.f(A_0.c5().a1(), A_0.ax());
							x5 x8 = x5.f(A_0.c5().a0(), A_0.ay());
							if (!A_0.bf() && !A_0.bg())
							{
								A_1 = x5.e(x4, x5.f(x2, x3));
								if (x5.h(x2, x5.c()))
								{
									A_1 = x5.e(A_1, x7);
								}
								if (x5.h(x3, x5.c()))
								{
									A_1 = x5.e(A_1, x8);
								}
							}
							else
							{
								A_1 = x5.e(x4, x5.f(x2, x3));
								if (x5.c(x8, x3))
								{
									A_1 = x5.e(A_1, x5.e(x8, x3));
								}
								if (x5.c(x7, x2))
								{
									A_1 = x5.e(A_1, x5.e(x7, x2));
								}
							}
							int num = num2;
							if (num != 0)
							{
								x6 = ld.d(x5);
							}
							else if (x5.d(A_1, x))
							{
								x6 = ld.d(x5);
								this.t = x5.c();
							}
							else
							{
								x6 = x5.f(x6, this.t);
							}
							num2++;
							this.m = x5.c();
							if (x5.a(x6, base.bl()))
							{
								this.am(false);
								break;
							}
							if (x5.h(x6, x5) && x5.d(A_1, x))
							{
								x6 = x5.f(x6, x5.a(5f));
							}
							flag = true;
						}
						if (!this.c0())
						{
							return false;
						}
						if (x5.g(x5.f(A_3.ag(), base.ao()), x5))
						{
							A_3.i(x5.e(x5, base.ao()));
							this.c = x5.e(this.c, x5.e(x5, x5.f(A_3.ag(), base.ao())));
						}
						if (x5.d(A_1, x5.a(0.75)))
						{
							if (!A_0.cx() && x5.h(x5.f(this.b, this.r), base.aq()) && x5.d(this.b, A_1))
							{
								A_3.p(false);
							}
							return false;
						}
						if (flag)
						{
							this.b = A_1;
						}
						return true;
					}
				}
			}
			return true;
		}

		// Token: 0x06001029 RID: 4137 RVA: 0x000B6C10 File Offset: 0x000B5C10
		private x5 b(k0 A_0)
		{
			mt mt = A_0.n();
			if (mt != null)
			{
				mu mu = mt.c();
				while (mu != null && mu.a() != null)
				{
					mq mq = mu.a().l();
					if (mq != null)
					{
						mr mr = mq.a();
						while (mr != null && mr.b() != null)
						{
							int num = mr.b().dg();
							switch (num)
							{
							case 100:
							case 101:
							case 102:
								mr.b().dh();
								return mr.b().b2();
							default:
								if (num != 46415)
								{
									if (mr.b().de())
									{
										return x5.c();
									}
									return this.b((k0)mr.b());
								}
								else
								{
									mr = mr.c();
								}
								break;
							}
						}
					}
					mu = mu.b();
				}
			}
			return x5.c();
		}

		// Token: 0x0600102A RID: 4138 RVA: 0x000B6D44 File Offset: 0x000B5D44
		private k0 a(x5 A_0, x5 A_1, k0 A_2)
		{
			x5 x = this.ag.l();
			x5 x2 = this.ag.i();
			x5 a_ = x5.c();
			if (x5.h(base.ap(), x5.c()))
			{
				if (!base.c5().e().s())
				{
					a_ = (x5.c(x2, x5.c()) ? x : (x5.c(x, x5.c()) ? x5.e(x, x2) : x5.c()));
				}
			}
			if (base.c5().q() == g6.b || base.c5().q() == g6.c)
			{
				if (this.o() != null && this.o().c().a().l() != null)
				{
					this.o().c().a().c(this.o().c().a().l().a());
					if (this.o().c().a().l() != null)
					{
						for (int i = this.o().f(); i > 0; i--)
						{
							if (this.a == null)
							{
								mt mt = new mt(this.o().b(i - 1));
								this.a = mt;
							}
							else
							{
								this.n().d(this.o().b(i - 1));
							}
						}
					}
				}
			}
			if (this.n() != null)
			{
				this.n().a(A_0, A_1, this, a_);
				this.c();
				this.b();
				if (base.c5().v() == null)
				{
					if (this.x() == null || this.y() == null)
					{
						if (x5.g(base.c5().ak(), x5.c()) && x5.g(base.c5().ai(), x5.c()))
						{
							if (x5.c(base.c5().ak(), base.c5().ai()))
							{
								if (x5.c(base.c5().ak(), this.n().h()))
								{
									lk lk = base.c5();
									lk.b(x5.e(lk.ak(), this.a.h()));
								}
								else
								{
									base.c5().i(new x5?(base.c5().ak()));
								}
								base.c5().a(x5.c());
							}
							else if (x5.c(this.a.h(), base.c5().ai()))
							{
								lk lk2 = base.c5();
								lk2.a(x5.e(lk2.ai(), this.a.h()));
								base.c5().b(x5.c());
							}
						}
						else if (x5.g(base.c5().ak(), x5.c()) && this.n().e() != null)
						{
							if (x5.c(base.c5().ak(), this.n().h()))
							{
								lk lk3 = base.c5();
								lk3.b(x5.e(lk3.ak(), this.a.h()));
							}
						}
						else if (x5.g(base.c5().ai(), x5.c()) && this.n().e() != null)
						{
							if (x5.d(base.c5().ai(), this.n().h()))
							{
								lk lk4 = base.c5();
								lk4.a(x5.e(lk4.ai(), this.a.h()));
							}
						}
					}
					this.ag.d(this.a.h(), A_1);
				}
				else
				{
					int num = this.dg();
					if (num <= 3418)
					{
						if (num != 1946)
						{
							if (num != 3034 && num != 3418)
							{
								goto IL_75C;
							}
							if (this.n().e() == null)
							{
								x5? x3 = base.c5().v();
								x5 a_2 = x5.f(this.n().h(), this.ab());
								if ((x3 != null && x5.d(x3.GetValueOrDefault(), a_2)) || base.c5().ac())
								{
									base.m(x5.f(x5.f(this.n().h(), this.ag.l()), this.ag.m()));
								}
								else
								{
									base.m(base.c5().v().Value);
								}
							}
							else
							{
								base.m(x5.f(this.n().h(), this.ag.l()));
								if (x5.c(base.ar(), A_1))
								{
									base.m(A_1);
								}
							}
							goto IL_9C7;
						}
					}
					else if (num <= 442866842)
					{
						if (num != 144937050 && num != 442866842)
						{
							goto IL_75C;
						}
					}
					else if (num != 718642778 && num != 889490394)
					{
						goto IL_75C;
					}
					if (this.n().e() == null)
					{
						x5? x3 = base.c5().v();
						x5 a_2 = this.n().h();
						if ((x3 != null && x5.d(x3.GetValueOrDefault(), a_2)) || base.c5().ac())
						{
							this.ag.d(this.n().h(), A_1);
							this.ag.q();
						}
						else
						{
							x5 value = base.c5().v().Value;
							this.ag.d(value, A_1);
							this.ag.q();
							if (x5.d(x5.f(x5.e(base.ar(), value), this.n().h()), value))
							{
								base.m(x5.e(base.ar(), x5.e(base.ar(), value)));
							}
							if (x5.c(base.ar(), A_1))
							{
								base.m(A_1);
							}
						}
						base.m(x5.f(base.ar(), this.ag.f()));
					}
					else
					{
						base.m(x5.f(this.n().h(), this.ag.l()));
						this.ag.q();
					}
					goto IL_9C7;
					IL_75C:
					if (this.n().e() == null)
					{
						x5 x4 = x5.c();
						x5 a_3 = x5.c();
						switch (base.c5().q())
						{
						case g6.b:
						case g6.c:
							x4 = ((base.c5().a() != null) ? base.c5().a().Value : x5.c());
							a_3 = ((base.c5().h() != null) ? base.c5().h().Value : x5.c());
							break;
						}
						if (x5.d(base.c5().v().Value, base.bl()))
						{
							if (x5.c(x5.e(base.c5().v().Value, a_3), A_1))
							{
								A_2 = this.a(A_2);
							}
							else if (x5.d(x5.f(base.c5().v().Value, x4), base.bl()))
							{
								base.m(x5.f(base.c5().v().Value, this.ab()));
							}
							else
							{
								base.m(x5.f(base.c5().v().Value, this.ab()));
								if (x5.c(base.ar(), A_1))
								{
									this.am(false);
								}
								if (x5.d(x4, A_1))
								{
									A_2 = this.a(A_2);
								}
							}
						}
						else if (x5.d(base.c5().v().Value, this.n().h()))
						{
							base.m(base.c5().v().Value);
						}
						else if (!x5.h(base.ar(), A_1))
						{
							base.m(A_1);
							A_2 = this.a(A_2);
						}
					}
					else
					{
						base.m(this.a.h());
						A_2 = this.a(A_2);
					}
					IL_9C7:;
				}
				if (this.n().e() != null)
				{
					A_2 = this.a(A_2);
					if (this.dg() == 2585 || this.dg() == 2595)
					{
						((mz)A_2).a(((mz)this).b());
						((mz)A_2).a(this.ah);
					}
					A_2.c(this.n().e());
					this.ag.c(A_2);
				}
				else if (this.dg() == 144937050)
				{
					this.h = false;
				}
				if (x5.h(base.ar(), x5.c()))
				{
					x5? x3 = base.c5().v();
					x5 a_2 = x5.c();
					if (x3 != null && x5.h(x3.GetValueOrDefault(), a_2))
					{
						base.m(x5.c());
					}
					else
					{
						base.m(this.n().h());
					}
				}
			}
			else
			{
				if (this.dg() != 3034 && this.dg() != 3418)
				{
					if (base.c5().am() != null)
					{
						if (base.c5().ap() != i2.b)
						{
							base.l(x5.f(base.c5().am().Value, this.aa()));
						}
					}
				}
				if (base.c5().v() != null)
				{
					if (x5.b(base.c5().v().Value, A_1))
					{
						if (this.dg() == 144937050)
						{
							base.m(x5.f(base.c5().v().Value, this.ag.f()));
						}
						else
						{
							base.m(x5.f(base.c5().v().Value, this.ab()));
						}
					}
					else
					{
						base.m(A_1);
						A_2 = this.a(A_2);
					}
				}
				else
				{
					base.m(this.ab());
				}
			}
			if (base.c5().h() != null && x5.d(base.c5().h().Value, x5.c()) && base.c5().a() == null && this.a != null && base.c5().v() == null)
			{
				x5 x5 = x5.c();
				x5 x6 = base.c5().h().Value;
				if (x5.d(x6, x5.c()))
				{
					x6 = x5.d(x6);
				}
				x5 x7 = x5.e(base.bl(), x5.f(this.a.h(), x6));
				if (x5.d(x7, base.bl()))
				{
					x5 = x5.e(base.bl(), x7);
				}
				A_1 = x5;
				x5 a_4 = x5.c();
				mu mu = this.n().c();
				while (mu != null && mu.a() != null)
				{
					a_4 = x5.f(a_4, mu.a().n());
					if (!x5.d(a_4, A_1))
					{
						this.am(false);
						mu mu2 = mu;
						mt mt2 = new mt(mu.a());
						while (mu2 != null)
						{
							mt2.c(mu2.a());
							mu2 = mu2.b();
						}
						A_2 = this.a(A_2);
						A_2.c(mt2);
						this.n().b(mu);
						break;
					}
					mu = mu.b();
				}
			}
			base.aj(x5.e(base.bj(), base.ar()));
			if (A_2 != null)
			{
				A_2.b(this.bw().f());
			}
			return A_2;
		}

		// Token: 0x0600102B RID: 4139 RVA: 0x000B7BA8 File Offset: 0x000B6BA8
		private kz a(x5 A_0, x5 A_1)
		{
			k0 k = null;
			mu mu = null;
			x5 x = x5.c();
			this.t = x5.c();
			this.z = null;
			this.o = null;
			this.p = null;
			int a_ = 0;
			int a_2 = 0;
			base.ab(x5.c());
			if (this.n() != null)
			{
				mu = this.n().c();
				x = x5.c();
				while (mu != null && mu.a() != null)
				{
					if (this.dg() == 505061334)
					{
						if (mu.c() != null)
						{
							this.b = x5.f(this.b, base.c5().a1());
						}
						else if (mu.b() != null)
						{
							this.b = x5.f(this.b, base.c5().a0());
						}
					}
					this.t = x5.c();
					ms ms = mu.a();
					this.b = A_0;
					ms.o(A_1);
					if (!x5.c(this.c, x5.c()))
					{
						return this.a(k, mu);
					}
					if (this.a(mu, A_0, A_1))
					{
						if (this.ab && base.c5().v() != null)
						{
							x5 a_3 = x;
							x5 a_4;
							ms.f(a_4 = (x5.g(ms.n(), x5.c()) ? base.c5().v().Value : this.t));
							x = x5.f(a_3, a_4);
						}
						else
						{
							x5 a_5 = x;
							x5 a_4;
							ms.f(a_4 = (x5.g(ms.n(), x5.c()) ? ms.n() : this.t));
							x = x5.f(a_5, a_4);
						}
						A_1 = x5.f(A_1, ms.n());
						if (x5.c(base.a6(), x5.c()))
						{
							A_1 = x5.f(A_1, base.a6());
						}
						a_ = ms.s();
						a_2 = ms.t();
						mu = mu.b();
						this.u = (x5.c(this.d, this.u) ? this.d : this.u);
						if (mu != null && mu.a() != null && mu.a().l() != null)
						{
							ms.j(this.d);
							if (x5.g(x, x5.c()))
							{
								x = x5.f(x, base.a6());
								if (this.ab && base.c5().v() != null)
								{
									base.m(base.c5().v().Value);
								}
								else
								{
									base.m(x);
								}
							}
							else
							{
								base.m(ms.n());
							}
							base.h(a_);
							base.i(a_2);
							base.l(this.u);
							if (x5.g(base.a6(), x5.c()))
							{
								this.c = x5.e(this.c, base.a6());
							}
							base.ab(x5.c());
							this.c = x5.e(this.c, ms.n());
						}
					}
					else
					{
						ms.f(this.t);
						this.u = (x5.c(this.d, this.u) ? this.d : this.u);
						ms.j(this.d);
						x5 a_6 = x;
						x5 a_4;
						ms.f(a_4 = (x5.g(ms.n(), x5.c()) ? ms.n() : this.t));
						x = x5.f(a_6, a_4);
						if (x5.g(x, x5.c()))
						{
							base.m(x);
						}
						else
						{
							base.m(ms.n());
						}
						if (x5.c(base.a6(), x5.c()))
						{
							base.m(x5.f(base.ar(), base.a6()));
						}
						base.h(a_);
						a_2 = ms.t();
						base.i(a_2);
						base.l(this.u);
						if (this.o != null || this.z != null || this.p != null)
						{
							return this.a(k, mu);
						}
						return null;
					}
				}
				if (base.c5().am() != null)
				{
					base.l(base.c5().am().Value);
				}
				else
				{
					base.l(x5.c(this.d, this.u) ? this.d : this.u);
				}
				base.l(x5.f(base.aq(), x5.f(base.c5().a1(), base.c5().a0())));
				base.h(a_);
				base.i(a_2);
				if (this.ab && base.c5().v() != null)
				{
					base.m(base.c5().v().Value);
				}
				else
				{
					base.m(x);
				}
				if (k != null)
				{
					if (!base.c1())
					{
						base.l(x5.f(base.aq(), base.c5().e().d()));
					}
					return k;
				}
				if (base.c1())
				{
					base.l(x5.f(base.aq(), base.c5().e().b()));
				}
			}
			else
			{
				this.r = this.ag.j();
				this.s = this.ag.k();
				int num = this.dg();
				if (num != 86163053)
				{
					base.l(x5.f(((base.c5().am() != null) ? base.c5().am() : new x5?(x5.c())).Value, this.r));
					base.m(x5.f(((base.c5().v() != null) ? base.c5().v() : new x5?(x5.c())).Value, this.s));
					if (x5.d(base.ar(), this.c))
					{
						this.am(true);
					}
				}
				else
				{
					base.l(x5.f(((base.c5().am() != null) ? base.c5().am() : new x5?(x5.c())).Value, this.r));
					base.m(x5.f(((base.c5().v() != null) ? base.c5().v() : new x5?(x5.c())).Value, this.s));
					if (x5.c(base.ar(), this.c))
					{
						return this.a(k, mu);
					}
				}
			}
			kz result;
			if (this.z != null)
			{
				result = this.a(k, mu);
			}
			else
			{
				if (this.o != null)
				{
					this.d(this.o);
				}
				if (this.p != null)
				{
					this.e(this.p);
				}
				result = null;
			}
			return result;
		}

		// Token: 0x0600102C RID: 4140 RVA: 0x000B8414 File Offset: 0x000B7414
		private bool a(mu A_0, x5 A_1, x5 A_2)
		{
			ms ms = A_0.a();
			mr mr = (ms.l() != null) ? ms.l().a() : null;
			int num = 0;
			this.d = x5.c();
			int num2 = 0;
			int num3 = 0;
			this.q = x5.c();
			kz kz = null;
			bool flag = false;
			while (mr != null && mr.b() != null)
			{
				if (x5.c(this.b, x5.c()))
				{
					if (mr.b().dg() == 102)
					{
						if (mr.c() != null && mr.c().b().b0())
						{
							mr = mr.c();
						}
					}
					if (mr.d() != null && mr.d().b().b1())
					{
						mr.b().o(true);
					}
					kz = mr.b();
					g3 g = kz.c5().n();
					g0? a_ = kz.c5().o();
					kz.ak(base.bl());
					kz.al(base.bm());
					kz.ap(this.c3());
					kz.p(base.bt());
					kz.q(base.bu());
					num++;
					kz.m(num);
					if (num == 1)
					{
						kz.n(base.bz());
					}
					else
					{
						kz.n(num);
					}
					int num4 = kz.dg();
					switch (num4)
					{
					case 100:
					case 101:
					case 102:
						break;
					default:
						if (num4 != 46415)
						{
							kz.am(base.bn());
						}
						break;
					}
					IL_1BB:
					kz.ah(A_1);
					kz.ai(base.bj());
					if (((n5)this.db()).n() != null)
					{
						kz.a(((n5)this.db()).n().a());
						kz.at(((n5)this.db()).n().c() == mw.d);
					}
					else
					{
						kz.a(this.ds());
						kz.at(this.du());
					}
					num4 = kz.dg();
					switch (num4)
					{
					case 100:
					case 101:
					case 102:
						break;
					default:
						if (num4 != 46415)
						{
							if (((n5)kz.db()).n().c() == mw.b && !kz.dt())
							{
								((n5)kz.db()).n().a(kz.ds());
							}
							((k0)kz).a(this.z());
							kz.j(x5.f(base.ao(), A_2));
							kz.ah(base.bi());
							((k0)kz).e(this.ao);
						}
						break;
					}
					if (base.c5().n() != g3.c)
					{
						kz.a(this.c8());
					}
					kz.a(this.bv());
					if (!base.c5().aa())
					{
						kz.dr(this.dq());
					}
					else
					{
						kz.dr(this.bw());
					}
					g6 g2 = kz.c5().q();
					kz.r(this.d);
					num4 = kz.dg();
					if (num4 <= 3375)
					{
						if (num4 <= 1946)
						{
							if (num4 <= 687)
							{
								if (num4 != 33 && num4 != 431 && num4 != 687)
								{
									goto IL_7A5;
								}
								goto IL_725;
							}
							else if (num4 <= 1000)
							{
								if (num4 != 879 && num4 != 1000)
								{
									goto IL_7A5;
								}
								goto IL_725;
							}
							else
							{
								if (num4 != 1717 && num4 != 1946)
								{
									goto IL_7A5;
								}
								goto IL_725;
							}
						}
						else if (num4 <= 2595)
						{
							if (num4 <= 1977)
							{
								if (num4 == 1967)
								{
									goto IL_725;
								}
								if (num4 != 1977)
								{
									goto IL_7A5;
								}
								bool flag2 = false;
								if (mr.c() != null)
								{
									kz.dj(this.b, this.c);
									this.a(A_0, ref mr, base.bx());
									this.a(ms);
									if (mr.c() != null)
									{
										if (mr.c().b().dg() == 1977)
										{
											flag2 = true;
										}
										base.an(true);
										if (flag2)
										{
											mr = ((mr.d() != null) ? mr.d() : mr);
										}
										this.z = this.c(mr);
										if (!flag2)
										{
											ms.b(mr);
										}
									}
									this.e(true);
									return false;
								}
								if (mr.c() == null)
								{
									kz.dj(this.b, this.c);
									this.a(A_0, ref mr, base.bx());
									this.a(mr, false);
									this.a(ms);
									base.ar(true);
									if (this.z == null && A_0.b() != null)
									{
										this.z = A_0.b().a();
										this.n().c(A_0.b());
									}
									return false;
								}
							}
							else
							{
								if (num4 != 2585 && num4 != 2595)
								{
									goto IL_7A5;
								}
								goto IL_725;
							}
						}
						else if (num4 <= 3034)
						{
							if (num4 != 2613 && num4 != 3034)
							{
								goto IL_7A5;
							}
							goto IL_725;
						}
						else
						{
							if (num4 != 3119 && num4 != 3375)
							{
								goto IL_7A5;
							}
							goto IL_725;
						}
					}
					else if (num4 <= 46574465)
					{
						if (num4 <= 3567)
						{
							if (num4 != 3418 && num4 != 3445 && num4 != 3567)
							{
								goto IL_7A5;
							}
							goto IL_725;
						}
						else if (num4 <= 95221)
						{
							if (num4 != 34721 && num4 != 95221)
							{
								goto IL_7A5;
							}
							goto IL_725;
						}
						else
						{
							if (num4 != 5629554 && num4 != 46574465)
							{
								goto IL_7A5;
							}
							goto IL_725;
						}
					}
					else if (num4 <= 258605815)
					{
						if (num4 <= 142298369)
						{
							if (num4 != 141185593 && num4 != 142298369)
							{
								goto IL_7A5;
							}
							goto IL_725;
						}
						else
						{
							if (num4 != 144937050 && num4 != 258605815)
							{
								goto IL_7A5;
							}
							goto IL_725;
						}
					}
					else if (num4 <= 594666565)
					{
						if (num4 != 442866842 && num4 != 594666565)
						{
							goto IL_7A5;
						}
						goto IL_725;
					}
					else
					{
						if (num4 != 718642778 && num4 != 889490394)
						{
							goto IL_7A5;
						}
						goto IL_725;
					}
					continue;
					IL_725:
					if (!kz.c5().u())
					{
						this.a(A_0, ref mr, this.c, ref num, A_2);
						continue;
					}
					if (kz.c5().t().Value != g2.c && kz.c5().t().Value != g2.d)
					{
						this.a(A_0, ref mr, this.c, ref num, A_2);
						continue;
					}
					IL_7A5:
					switch (kz.dg())
					{
					case 100:
					case 101:
					case 102:
						break;
					default:
						kz.ab(base.a6());
						break;
					}
					if (g2 == g6.c || kz.ct() || (g2 == g6.b && g == g3.c))
					{
						this.k = kz.dj(this.b, this.c);
						if (this.k != null)
						{
							if (this.p == null)
							{
								this.p = new ms(this.k);
							}
							else
							{
								this.p.l().a(this.k);
							}
							this.k = null;
						}
						if (g2 == g6.b)
						{
							this.t = kz.ar();
						}
						this.a(A_0, mr);
					}
					else
					{
						if (g == g3.c)
						{
							num4 = kz.dg();
							switch (num4)
							{
							case 100:
								if (kz.bo() != -1)
								{
									bool a_2 = this.a(mr, this.b);
									((n3)kz).g(a_2);
								}
								break;
							case 101:
								if (kz.bo() != -1)
								{
									bool a_2 = this.a(mr, this.b);
									((nn)kz).a(a_2);
								}
								break;
							default:
								if (num4 == 137440 || num4 == 235744)
								{
									if (kz.dg() == 235744)
									{
										kz.q(true);
									}
									if (kz.dg() == 137440)
									{
										kz.p(true);
									}
									if (x5.d(this.b, x5.f(kz.b2(), x5.a(0.0001))))
									{
										mr mr2 = mr.d();
										if (!mr2.b().b1())
										{
											this.k = mr2.b().dl();
											mr = mr.d();
											switch (mr2.b().dg())
											{
											case 100:
												this.d = x5.e(this.d, ((n3)mr2.b()).b3());
												break;
											case 101:
												this.d = x5.e(this.d, ((nn)mr2.b()).b3());
												break;
											default:
												this.d = x5.e(this.d, mr2.b().b3());
												break;
											}
											flag = true;
										}
									}
								}
								break;
							}
							if (!flag)
							{
								this.k = kz.dj(this.b, this.c);
								if (base.bt() && kz.dg() != 100)
								{
									base.ao(kz.br());
									base.ap(kz.bs());
								}
								else
								{
									base.p(false);
								}
								if (base.bt() && kz.dg() != 100)
								{
									base.an(kz.bq());
								}
								else
								{
									base.q(false);
								}
							}
							if (kz.dg() == 144937050 && kz.c5().t() == g2.c)
							{
								ms.aa(this.ag.c(((k0)kz).n()));
							}
							num4 = kz.dg();
							switch (num4)
							{
							case 100:
							case 101:
							case 102:
								goto IL_C38;
							default:
								if (num4 == 46415)
								{
									goto IL_C38;
								}
								this.b(((k0)kz).y());
								this.c(((k0)kz).x());
								break;
							}
							IL_C8D:
							if (kz.dg() != 100)
							{
								base.ar(kz.dj());
							}
							if (x5.c(kz.aq(), x5.c()) || kz.c0())
							{
								num2 += kz.ba();
								num3 += kz.bb();
								this.a(A_0, ref mr, base.bx());
								this.a(ms);
								this.am(kz.c0());
								base.s(kz.b1());
							}
							else if (x5.g(this.m, x5.c()))
							{
								this.d(kz);
							}
							if (x5.c(kz.a6(), x5.c()))
							{
								base.ab(x5.f(base.a6(), kz.a6()));
							}
							goto IL_D7B;
							IL_C38:
							if (x5.c(kz.aq(), base.bm()))
							{
								this.aj(kz.cx());
							}
							goto IL_C8D;
						}
						if (this.b(g))
						{
							this.a(a_, g, this.b, A_2, ref mr, A_0, A_0.a().ab(), false);
						}
						else
						{
							this.c(new ms(mr.b()));
							A_0.a().c(mr);
						}
						kz kz2 = kz;
						kz2.am(x5.f(kz2.bn(), this.m));
						num--;
						this.a(ms);
					}
					IL_D7B:
					this.f(kz);
					if (this.k == null)
					{
						if (kz.dj())
						{
							switch (kz.dg())
							{
							case 100:
							case 101:
							case 102:
								if (kz.b7())
								{
									kz.dr().ar(kz.dj());
								}
								break;
							}
							this.z = this.a(ms, ref mr, true, false);
						}
						mr = ((mr != null) ? mr.c() : null);
						continue;
					}
					if (kz != null)
					{
						switch (kz.dg())
						{
						case 100:
						case 101:
						case 102:
							if (kz.c1())
							{
								this.k.an(true);
							}
							break;
						}
					}
					if (!this.cx())
					{
						this.z = this.a(ms, ref mr, false, false);
					}
					else if (base.bx() == 0 && base.by() == 1)
					{
						this.z = this.a(ms, ref mr, false, false);
					}
					this.a(ms, num2, num3);
					return false;
					goto IL_1BB;
				}
				this.z = this.a(ms, ref mr, false, false);
				this.f(kz);
				mr = ((mr != null) ? mr.c() : null);
			}
			this.a(ms, num2, num3);
			return this.c0();
		}

		// Token: 0x0600102D RID: 4141 RVA: 0x000B9348 File Offset: 0x000B8348
		private void a(ms A_0, int A_1, int A_2)
		{
			A_0.a(A_1);
			A_0.b(A_2);
			A_0.f(this.t);
			A_0.p(this.w);
			A_0.q(this.x);
			A_0.r(this.y);
			A_0.x(this.ae);
			A_0.w(this.ad);
			A_0.y(this.af);
			this.u = (x5.c(this.d, this.u) ? this.d : this.u);
			A_0.j(this.d);
			A_0.a7();
		}

		// Token: 0x0600102E RID: 4142 RVA: 0x000B9400 File Offset: 0x000B8400
		private void a(ms A_0)
		{
			if (A_0 != null)
			{
				A_0.w(this.ad);
				A_0.x(this.ae);
				A_0.y(this.af);
				A_0.p(this.w);
				A_0.q(this.x);
				A_0.r(this.y);
			}
		}

		// Token: 0x0600102F RID: 4143 RVA: 0x000B9468 File Offset: 0x000B8468
		private void a(mu A_0, ref mr A_1, x5 A_2, ref int A_3, x5 A_4)
		{
			kz kz = A_1.b();
			g6 g = kz.c5().q();
			g3 g2 = kz.c5().n();
			g0? a_ = kz.c5().o();
			bool flag = false;
			if (base.by() == 1 && A_3 == 1 && x5.h(base.a6(), x5.c()))
			{
				bool flag2 = false;
				x5 x = x5.c();
				kz kz2 = this.dr();
				bool flag3 = false;
				while (kz2 != null && !flag3)
				{
					if (kz2.de())
					{
						x = kz2.aq();
						flag3 = true;
					}
					kz2 = kz2.dr();
				}
				this.ae().a(A_1, 1, A_4, ref flag2, 0, x, A_2);
				if (g == g6.c || g == g6.b)
				{
					this.a(A_0, A_1);
				}
				else if (g2 != g3.c)
				{
					if (this.b(g2))
					{
						this.a(a_, g2, x, A_4, ref A_1, A_0, A_0.a().ab(), false);
					}
					else
					{
						this.c(new ms(A_1.b()));
						A_0.a().c(A_1);
						A_1 = A_1.c();
					}
					A_3--;
				}
				else
				{
					this.k = kz.dj(x, A_2);
					if (this.k != null)
					{
						this.a(A_0.a(), ref A_1, false, false);
						flag = true;
					}
					if (x5.g(kz.ar(), x5.c()))
					{
						A_4 = kz.ar();
					}
					base.ab(x5.f(base.a6(), A_4));
				}
				A_1 = ((A_1 != null) ? A_1.c() : null);
			}
			if (!flag)
			{
				this.a(A_0.a(), ref A_1, false, false);
			}
		}

		// Token: 0x06001030 RID: 4144 RVA: 0x000B966C File Offset: 0x000B866C
		private kz a(k0 A_0, mu A_1)
		{
			if (this.c0())
			{
				base.an(true);
			}
			if (A_0 == null)
			{
				A_0 = this.dd();
				A_0.df(this.de());
			}
			if (this.z != null)
			{
				A_0.c(new mt(this.z));
			}
			if (this.o != null)
			{
				A_0.c(new mt(this.o));
			}
			if (this.p != null)
			{
				A_0.c(new mt(this.p));
			}
			if (A_1 != null)
			{
				mu a_ = A_1;
				if (A_0.n() == null)
				{
					A_0.c(new mt(A_1.a()));
				}
				A_1 = A_1.b();
				int num = 0;
				if (this.z != null || this.p != null)
				{
					a_ = A_1;
				}
				if (this.z != null || this.o != null)
				{
					a_ = A_1;
				}
				while (A_1 != null && A_1.a() != null)
				{
					num++;
					A_0.n().c(A_1.a());
					if (A_1.b() == null)
					{
						A_1 = null;
					}
					else
					{
						A_1 = A_1.b();
					}
					if (A_1 != null)
					{
						A_1.b(null);
					}
				}
				mt mt = this.n();
				mt.a(mt.f() - num);
				this.n().b(a_);
			}
			kz result;
			if (A_0 != null)
			{
				A_0.dc(this.db());
				A_0.a(base.c5());
				A_0.c5().e().a(x5.c());
				A_0.c5().e().c(x5.c());
				A_0.w(base.a1());
				A_0.x(base.a2());
				A_0.ac(base.a7());
				A_0.aa(base.a5());
				A_0.ad(base.a8());
				A_0.b(this.w());
				A_0.j(this.dr());
				this.e = true;
				A_0.f = true;
				A_0.an(true);
				if (A_0.dg() == 86163053)
				{
					((m5)A_0).a(((m5)this).b());
				}
				if (!base.c1())
				{
					if (!this.f)
					{
						base.l(x5.f(base.aq(), base.c5().e().d()));
					}
				}
				if (A_0.a != null)
				{
					this.ag.c(A_0);
				}
				result = A_0;
			}
			else
			{
				base.l(x5.f(base.aq(), base.c5().a0()));
				result = null;
			}
			return result;
		}

		// Token: 0x06001031 RID: 4145 RVA: 0x000B9970 File Offset: 0x000B8970
		private ms c(mr A_0)
		{
			for (mr mr = A_0.c(); mr != null; mr = mr.c())
			{
				if (this.z == null)
				{
					this.z = new ms(mr.b());
				}
				else
				{
					this.z.l().a(mr.b());
				}
			}
			A_0.a();
			return this.z;
		}

		// Token: 0x06001032 RID: 4146 RVA: 0x000B99E8 File Offset: 0x000B89E8
		private x5 b(mr A_0)
		{
			kz kz = A_0.b();
			int num = this.dg();
			x5 result;
			if (num != 1946)
			{
				if (num != 144937050)
				{
					result = this.b;
				}
				else
				{
					result = x5.e(base.bi(), this.r);
				}
			}
			else
			{
				int num2 = ((nt)kz).h();
				x5 x = x5.c();
				if (num2 < base.b6().Count)
				{
					x = (x5)base.b6()[num2];
				}
				if (((n5)kz.db()).y() > 1)
				{
					x5 a_ = x5.c();
					if (this.dv().e() != null)
					{
						a_ = this.dv().e().Value;
					}
					for (int i = num2 + 1; i < ((n5)kz.db()).y() + num2; i++)
					{
						if (i < base.b6().Count)
						{
							x = x5.f(x, x5.f((x5)base.b6()[i], a_));
						}
					}
				}
				result = x;
			}
			return result;
		}

		// Token: 0x06001033 RID: 4147 RVA: 0x000B9B48 File Offset: 0x000B8B48
		private k0 a(k0 A_0)
		{
			if (A_0 == null)
			{
				A_0 = this.dd();
				A_0.df(this.de());
				if (this.c0())
				{
					base.an(true);
				}
				else if (this.n().f() >= 1)
				{
					base.an(true);
					if (this.dg() != 11228793)
					{
						this.dr().an(true);
					}
				}
				else if (this.dg() == 1000 && this.n().e() != null)
				{
					base.an(true);
				}
				else if (base.c1())
				{
					this.dr().an(true);
				}
				this.ag.b(A_0);
			}
			if (A_0.c5().q() == g6.b || A_0.c5().q() == g6.c)
			{
				if (A_0.c5().a() != null)
				{
					A_0.c5().a(new x5?(x5.c()));
				}
			}
			return A_0;
		}

		// Token: 0x06001034 RID: 4148 RVA: 0x000B9C88 File Offset: 0x000B8C88
		internal void b(ref x5 A_0, ref x5 A_1, ref x5 A_2, ref x5 A_3)
		{
			x5 x = x5.c();
			x5 x2 = x5.c();
			x5 x3 = x5.c();
			x5 x4 = x5.c();
			bool flag = this.f();
			bool flag2 = this.e();
			if (flag)
			{
				if (this.a != null)
				{
					this.a.a(ref x, ref x2, ref x3, ref x4);
					if (flag2)
					{
						A_2 = x3;
						A_3 = x4;
					}
					A_0 = x;
					A_1 = x2;
				}
			}
			this.a(ref A_0, ref A_1, ref A_2, ref A_3);
			base.c5().e().a(x5.c());
			base.c5().e().c(x5.c());
		}

		// Token: 0x06001035 RID: 4149 RVA: 0x000B9D54 File Offset: 0x000B8D54
		internal void b(x5 A_0, x5 A_1)
		{
			this.b = A_0;
			this.c = A_1;
			this.ae().c(A_0, A_1);
			if (base.c5().am() != null && x5.g(base.c5().am().Value, x5.c()))
			{
				this.b = x5.f(base.c5().am().Value, this.r);
			}
			else
			{
				if (base.c5().n() == g3.c)
				{
					this.di();
				}
				if (base.c5().q() == g6.c || base.c5().q() == g6.b)
				{
					x5 a_ = (base.c5().b() != null) ? base.c5().b().Value : x5.c();
					x5 a_2 = (base.c5().s() != null) ? base.c5().s().Value : x5.c();
					x5 a_3 = x5.f(a_, a_2);
					if (x5.d(base.c5().@as(), x5.e(A_0, a_3)) && x5.g(base.c5().@as(), x5.c()))
					{
						base.c5().d(x5.e(A_0, a_3));
					}
					if (x5.g(base.c5().@as(), x5.c()) && x5.d(this.dn(), base.c5().@as()))
					{
						base.c5().j(new x5?(x5.e(A_0, a_3)));
						if (x5.d(base.c5().@as(), a_3))
						{
							base.c5().j(new x5?(base.c5().@as()));
							this.b = x5.f(base.c5().am().Value, this.r);
						}
					}
				}
				else if (x5.g(base.c5().@as(), x5.c()) && x5.d(this.dn(), base.c5().@as()))
				{
					base.c5().j(new x5?(base.c5().@as()));
					this.b = x5.f(base.c5().am().Value, this.r);
				}
			}
			base.l(this.b);
		}

		// Token: 0x06001036 RID: 4150 RVA: 0x000BA030 File Offset: 0x000B9030
		protected void aj()
		{
			if (x5.h(this.dp(), x5.c()))
			{
				this.a8(this.ae().n());
			}
		}

		// Token: 0x06001037 RID: 4151 RVA: 0x000BA068 File Offset: 0x000B9068
		protected void ak()
		{
			if (x5.h(this.dn(), x5.c()))
			{
				this.a7(this.ae().o());
			}
		}

		// Token: 0x06001038 RID: 4152 RVA: 0x000BA0A0 File Offset: 0x000B90A0
		protected x5 al()
		{
			return this.ae().p();
		}

		// Token: 0x06001039 RID: 4153 RVA: 0x000BA0C0 File Offset: 0x000B90C0
		protected f9[] b(ref x5[] A_0, int A_1, x5 A_2)
		{
			f9[] result = new f9[A_1];
			this.ag.a(ref A_0, ref result, A_1, A_2, this.n());
			return result;
		}

		// Token: 0x0600103A RID: 4154 RVA: 0x000BA0F4 File Offset: 0x000B90F4
		protected List<li> a(List<li> A_0)
		{
			if (A_0.Count > 1)
			{
				for (int i = 0; i < A_0.Count; i++)
				{
					for (int j = 0; j < A_0.Count - 1; j++)
					{
						if (A_0[j].a().c5().w() > A_0[j + 1].a().c5().w())
						{
							li value = A_0[j];
							A_0[j] = A_0[j + 1];
							A_0[j + 1] = value;
						}
					}
				}
			}
			return A_0;
		}

		// Token: 0x0600103B RID: 4155 RVA: 0x000BA1C0 File Offset: 0x000B91C0
		protected int b(List<li> A_0)
		{
			int i;
			for (i = 0; i < A_0.Count; i++)
			{
				if (A_0[i].a().c5().w() >= 0)
				{
					return i;
				}
			}
			return i;
		}

		// Token: 0x0600103C RID: 4156 RVA: 0x000BA210 File Offset: 0x000B9210
		protected kz am()
		{
			if (this.n() != null)
			{
				mu mu = this.n().c();
				if (mu.a() != null)
				{
					ms ms = mu.a();
					if (ms.l() != null)
					{
						mr mr = ms.l().a();
						switch (mr.b().dg())
						{
						case 100:
						case 101:
						{
							kz a_ = mr.b().dl();
							base.an(mr.b().c1());
							base.ar(mr.b().b3());
							base.l(x5.e(base.aq(), base.b3()));
							ms a_2 = new ms(a_);
							k0 k = this.dd();
							k.c(new mt(a_2));
							k.j(this.dr());
							k.dc(this.db().du());
							k.a((lk)base.c5().du());
							k.df(this.de());
							return k;
						}
						default:
							mr.b().dl();
							break;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x0600103D RID: 4157 RVA: 0x000BA370 File Offset: 0x000B9370
		internal bool c(int A_0)
		{
			if (A_0 <= 3445)
			{
				if (A_0 <= 1717)
				{
					if (A_0 <= 687)
					{
						if (A_0 != 33 && A_0 != 431 && A_0 != 687)
						{
							goto IL_181;
						}
					}
					else if (A_0 != 879 && A_0 != 1000 && A_0 != 1717)
					{
						goto IL_181;
					}
				}
				else if (A_0 <= 2595)
				{
					if (A_0 != 1946 && A_0 != 2585 && A_0 != 2595)
					{
						goto IL_181;
					}
				}
				else if (A_0 <= 3119)
				{
					if (A_0 != 2613 && A_0 != 3119)
					{
						goto IL_181;
					}
				}
				else if (A_0 != 3375 && A_0 != 3445)
				{
					goto IL_181;
				}
			}
			else if (A_0 <= 142298369)
			{
				if (A_0 <= 95221)
				{
					if (A_0 != 3567 && A_0 != 34721 && A_0 != 95221)
					{
						goto IL_181;
					}
				}
				else if (A_0 <= 46574465)
				{
					if (A_0 != 5629554 && A_0 != 46574465)
					{
						goto IL_181;
					}
				}
				else if (A_0 != 141185593 && A_0 != 142298369)
				{
					goto IL_181;
				}
			}
			else if (A_0 <= 442866842)
			{
				if (A_0 != 144937050 && A_0 != 258605815 && A_0 != 442866842)
				{
					goto IL_181;
				}
			}
			else if (A_0 <= 718642778)
			{
				if (A_0 != 594666565 && A_0 != 718642778)
				{
					goto IL_181;
				}
			}
			else if (A_0 != 889490394 && A_0 != 1106840163)
			{
				goto IL_181;
			}
			return true;
			IL_181:
			return false;
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x000BA504 File Offset: 0x000B9504
		protected kz c(x5 A_0, x5 A_1)
		{
			g6 g = base.c5().q();
			kz result;
			if (g != g6.c)
			{
				switch (base.c5().n())
				{
				case g3.a:
				case g3.b:
					result = this.f(A_0, A_1);
					break;
				default:
				{
					g2 valueOrDefault = base.c5().t().GetValueOrDefault();
					g2? g2;
					if (g2 != null)
					{
						if (valueOrDefault == g2.b)
						{
							result = this.f(A_0, A_1);
							break;
						}
					}
					if (!this.de())
					{
						result = this.d(A_0, A_1);
					}
					else
					{
						result = this.f(A_0, A_1);
					}
					break;
				}
				}
			}
			else
			{
				result = this.f(A_0, A_1);
			}
			return result;
		}

		// Token: 0x0600103F RID: 4159 RVA: 0x000BA5A8 File Offset: 0x000B95A8
		protected kz d(x5 A_0, x5 A_1)
		{
			base.l(A_0);
			base.m(A_1);
			x5 a_ = x5.c();
			A_1 = x5.e(base.ar(), a_);
			if (!this.q())
			{
				this.b = x5.e(base.aq(), this.ae().j());
			}
			else
			{
				this.b = base.aq();
			}
			if (x5.d(this.b, x5.c()))
			{
				this.b = x5.e(base.aq(), base.c5().a1());
			}
			this.c = A_1;
			kz result;
			if (x5.c(this.c, x5.c()) && x5.c(this.b, x5.c()))
			{
				kz kz = this.a(this.b, x5.c());
				this.da();
				result = kz;
			}
			else
			{
				this.am(false);
				base.an(false);
				base.m(x5.c());
				result = this;
			}
			return result;
		}

		// Token: 0x06001040 RID: 4160 RVA: 0x000BA6B5 File Offset: 0x000B96B5
		internal void e(x5 A_0, x5 A_1)
		{
			this.b = A_0;
			this.c = A_1;
		}

		// Token: 0x06001041 RID: 4161 RVA: 0x000BA6C8 File Offset: 0x000B96C8
		protected k0 f(x5 A_0, x5 A_1)
		{
			k0 a_ = null;
			base.l(A_0);
			base.m(A_1);
			base.ai(base.ar());
			int num = this.dg();
			if (num <= 3034)
			{
				if (num <= 2585)
				{
					if (num == 1946)
					{
						goto IL_AB;
					}
					if (num != 2585)
					{
						goto IL_121;
					}
				}
				else if (num != 2595)
				{
					if (num != 3034)
					{
						goto IL_121;
					}
					goto IL_C7;
				}
				this.ah = ((mz)this).c();
				this.b(A_0, A_1);
				goto IL_12C;
			}
			if (num <= 258605815)
			{
				if (num == 3418)
				{
					goto IL_C7;
				}
				if (num != 258605815)
				{
					goto IL_121;
				}
			}
			else if (num != 442866842 && num != 718642778 && num != 889490394)
			{
				goto IL_121;
			}
			IL_AB:
			if (!base.c1())
			{
				this.ae().a(A_0, A_1);
			}
			goto IL_12C;
			IL_C7:
			this.r = this.ae().j();
			this.s = this.ag.k();
			if (!base.c1())
			{
				this.ag.a(A_0, A_1);
			}
			goto IL_12C;
			IL_121:
			this.b(A_0, A_1);
			IL_12C:
			x5 x = x5.c();
			num = this.dg();
			if (num <= 3375)
			{
				if (num <= 1717)
				{
					if (num <= 687)
					{
						if (num != 33 && num != 431 && num != 687)
						{
							goto IL_30B;
						}
					}
					else if (num != 879 && num != 1000 && num != 1717)
					{
						goto IL_30B;
					}
				}
				else if (num <= 2595)
				{
					if (num != 1967 && num != 2585 && num != 2595)
					{
						goto IL_30B;
					}
				}
				else if (num <= 3034)
				{
					if (num != 2613 && num != 3034)
					{
						goto IL_30B;
					}
				}
				else if (num != 3119 && num != 3375)
				{
					goto IL_30B;
				}
			}
			else if (num <= 5629554)
			{
				if (num <= 3567)
				{
					if (num != 3418 && num != 3445 && num != 3567)
					{
						goto IL_30B;
					}
				}
				else if (num != 34721 && num != 95221 && num != 5629554)
				{
					goto IL_30B;
				}
			}
			else if (num <= 142298369)
			{
				if (num != 46574465 && num != 141185593 && num != 142298369)
				{
					goto IL_30B;
				}
			}
			else if (num <= 594666565)
			{
				if (num != 144937050 && num != 594666565)
				{
					goto IL_30B;
				}
			}
			else if (num != 622899778 && num != 899925938)
			{
				goto IL_30B;
			}
			x = this.ag.l();
			if (x5.c(x, x5.c()))
			{
				A_1 = x5.e(A_1, x);
				base.ax(x5.e(base.cj(), x));
			}
			IL_30B:
			if (base.c1())
			{
				if (base.c5().v() != null)
				{
					base.m(base.av());
				}
				if (this.dg() == 2585 || this.dg() == 35)
				{
					this.ah = ((mz)this).c();
				}
			}
			A_0 = base.aq();
			if (this.dg() == 594666565)
			{
				A_0 = x5.e(A_0, this.ae().j());
				base.l(A_0);
			}
			else if (this.dg() != 426354867)
			{
				A_0 = x5.e(A_0, this.ae().j());
			}
			k0 result;
			if (x5.c(A_1, x5.a(0.75)))
			{
				k0 k = this.a(A_0, A_1, a_);
				this.da();
				result = k;
			}
			else
			{
				this.am(false);
				this.da();
				base.an(false);
				result = this;
			}
			return result;
		}

		// Token: 0x06001042 RID: 4162 RVA: 0x000BAB0C File Offset: 0x000B9B0C
		internal ms a(mu A_0, int A_1, x5 A_2, bool A_3)
		{
			ms ms = A_0.a();
			mr mr = (ms.l() != null) ? ms.l().a() : null;
			this.ap = x5.c();
			this.a();
			int num = 0;
			int a_ = 0;
			int a_2 = 0;
			bool flag = false;
			x5 x = x5.c();
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = true;
			bool a_3 = false;
			if (base.c5().am() != null)
			{
				this.aq = true;
			}
			x5 a_4 = base.bn();
			while (mr != null && mr.b() != null)
			{
				this.q = x5.c();
				if (mr.b().dg() == 102)
				{
					if (mr.c() != null && mr.c().b().b0())
					{
						mr = mr.c();
					}
				}
				if (mr.d() != null && mr.d().b().b1())
				{
					mr.b().o(true);
				}
				kz kz = mr.b();
				this.h(kz);
				g3 g = kz.c5().n();
				g6 g2 = kz.c5().q();
				g0? g3 = kz.c5().o();
				x = this.b(mr);
				if (x5.c(x, x5.c()))
				{
					kz.al(base.bm());
					kz.ak(base.bl());
					num++;
					kz.m(num);
					kz.n(num);
					if (!kz.ct())
					{
						this.ae().a(mr, A_1, A_2, ref flag2, this.aa, this.b, this.c);
					}
					int num2 = kz.dg();
					switch (num2)
					{
					case 100:
					case 101:
					case 102:
						break;
					default:
						if (num2 != 46415)
						{
							kz.ap(this.c3());
							kz.q(base.bu());
							kz.p(base.bt());
							((k0)kz).e(this.t);
							kz.am(base.bn());
						}
						else
						{
							kz.ap(this.c3());
						}
						break;
					}
					if (g2 == g6.c || (kz.ct() || mr.b().c5().aa()) || (g2 == g6.b && g == g3.c))
					{
						this.a(new g3?(g), x, ref mr, A_0, A_2, ref flag);
						num--;
						if (g2 == g6.b && !kz.de())
						{
							a_3 = true;
						}
					}
					else
					{
						if (kz.de())
						{
							if (this.dg() == 11228793)
							{
								((k0)kz).ar = base.bl();
							}
							else
							{
								((k0)kz).ar = this.ar;
							}
						}
						if (g != g3.c && !kz.ct())
						{
							if (this.b(g))
							{
								this.a(g3, g, x, A_2, ref mr, A_0, A_1, A_3);
								kz kz2 = kz;
								kz2.am(x5.f(kz2.bn(), this.dc()));
								if (!kz.c0() && this.z == null)
								{
									if (A_0.b() == null && mr.c() == null)
									{
										if (this.x() == null)
										{
											this.am(false);
										}
									}
									else if (A_0.b() != null && g3 != null && g3.Value == g0.c)
									{
										this.am(kz.c0());
									}
								}
							}
							else
							{
								this.g(mr.b());
								A_0.a().c(mr);
								if (kz.c0() && this.z == null && A_0.b() == null && mr.c() == null)
								{
									this.am(false);
								}
								mr = mr.c();
								flag4 = false;
							}
							num--;
						}
						else
						{
							if (kz.de() && g3 != null && g3 != g0.d)
							{
								switch (kz.dg())
								{
								case 100:
								case 101:
								case 102:
									break;
								default:
								{
									x5 x2 = this.a(kz, ref x, x5.f(A_2, base.ao()), ms, false);
									if (x5.g(x2, x5.c()))
									{
										ms.u(x2);
										if (x5.c(A_2, x2))
										{
											ms.o(A_2);
										}
										else
										{
											kz.k(x5.f(ms.ag(), x2));
											ms.u(x2);
											ms.o(x2);
										}
										if (!kz.c3())
										{
											x2 = x5.f(x2, base.ao());
										}
										A_2 = x5.f(A_2, x2);
									}
									break;
								}
								}
							}
							else
							{
								flag4 = this.a(kz, x, num, ms);
							}
							if (flag4 && x5.b(A_2, base.bl()))
							{
								this.a(ref mr, A_0, x, A_1, ref a_2, ref a_, ref flag3, a_3);
							}
							else
							{
								num2 = kz.dg();
								if (num2 == 137440 || num2 == 235744)
								{
									mr mr2 = mr.d();
									if (!mr2.b().b1())
									{
										this.k = mr2.b().dl();
										mr = mr.d();
										switch (mr2.b().dg())
										{
										case 100:
											this.d = x5.e(this.d, ((n3)mr2.b()).b3());
											break;
										case 101:
											this.d = x5.e(this.d, ((nn)mr2.b()).b3());
											break;
										default:
											this.d = x5.e(this.d, mr2.b().b3());
											break;
										}
									}
								}
								if (x5.c(A_2, base.bl()))
								{
									this.am(false);
									this.dr().am(false);
								}
								if (this.dg() != 1946)
								{
									this.a(A_0.a(), ref mr, false, false);
								}
								else
								{
									mr = ((mr != null) ? mr.c() : null);
								}
							}
						}
					}
					if (flag4)
					{
						mr = this.a(kz, A_0, mr, num);
					}
					flag4 = true;
				}
				else if (this.dg() != 1946)
				{
					if (g != g3.c && x5.c(this.v, base.bl()))
					{
						this.g(mr.b());
						A_0.a().c(mr);
						mr = mr.c();
					}
					else
					{
						if (this.z == null)
						{
							this.z = new ms(mr.b());
						}
						else
						{
							this.z.l().a(mr.b());
						}
						ms.c(mr);
						mr = ((mr != null) ? mr.c() : null);
						while (mr != null && mr.b() != null)
						{
							this.z.l().a(mr.b());
							ms.c(mr);
							mr = mr.c();
						}
					}
				}
				else
				{
					mr = ((mr != null) ? mr.c() : null);
				}
			}
			this.ag.a(A_0, this.t);
			if (ms.l() != null)
			{
				ms.p(this.w);
				ms.q(this.x);
				ms.r(this.y);
				ms.x(this.ae);
				ms.w(this.ad);
				ms.y(this.af);
			}
			ms.s(this.v);
			this.u = (x5.c(this.d, this.u) ? this.d : this.u);
			ms.j(this.d);
			ms.a(a_);
			ms.b(a_2);
			ms.a7();
			if (x5.g(this.m, x5.c()) && !base.bf())
			{
				ms.m(this.m);
				ms.a(this);
			}
			if (x5.c(base.bn(), a_4))
			{
				ms ms2 = ms;
				ms2.m(x5.f(ms2.ae(), x5.e(base.bn(), a_4)));
				ms.a(this);
			}
			if (x5.g(this.n, x5.c()) && !base.bg())
			{
				ms.n(this.n);
			}
			return this.z;
		}

		// Token: 0x06001043 RID: 4163 RVA: 0x000BB4D8 File Offset: 0x000BA4D8
		private void a(mu A_0, mr A_1)
		{
			kz kz = A_1.b();
			if (this.dg() == 11228793 && base.c5().q() == g6.c)
			{
				this.dq().a(kz);
			}
			else
			{
				switch (base.c5().q())
				{
				case g6.b:
				case g6.c:
					if (this.dg() != 1 && this.dg() != 11228793)
					{
						if (!base.c5().aa())
						{
							switch (kz.c5().q())
							{
							case g6.b:
							case g6.c:
								if (!A_1.b().c5().aa())
								{
									this.bw().a(kz);
								}
								else if (A_1.b().c5().ab())
								{
									this.bw().a(kz);
								}
								else
								{
									kz.ax(false);
									this.dq().a(kz);
								}
								break;
							default:
								kz.ax(false);
								this.dq().a(kz);
								break;
							}
						}
						else if (!A_1.b().c5().ab())
						{
							if (base.c5().ab() && A_1.b().c5().w() <= 0)
							{
								kz.ax(false);
								this.dq().a(kz);
							}
							else
							{
								this.bw().a(kz);
							}
						}
						else if (A_1.b().c5().ab())
						{
							this.bw().a(kz);
						}
						else
						{
							kz.ax(false);
							this.dq().a(kz);
						}
					}
					else
					{
						kz.ax(false);
						this.dq().a(kz);
					}
					break;
				default:
					kz.ax(true);
					this.dq().a(kz);
					break;
				}
			}
			if (!this.c(kz.dg()) && kz.c5().q() == g6.b)
			{
				this.b = x5.e(this.b, kz.aq());
				this.d = x5.f(this.d, kz.aq());
			}
			if (kz.c5().q() == g6.b)
			{
				A_0.a().e(A_1.b().c5().e().c());
			}
			A_0.a().c(A_1);
			this.ap = x5.f(this.ap, kz.aq());
		}

		// Token: 0x06001044 RID: 4164 RVA: 0x000BB7B4 File Offset: 0x000BA7B4
		private mr a(mu A_0, mr A_1, x5 A_2, bool A_3, bool A_4, x5 A_5, x5 A_6, ref bool A_7)
		{
			kz kz = A_1.b();
			ms ms = A_0.a();
			if (x5.c(kz.ar(), A_6) || this.k != null)
			{
				if (kz.c1() && this.k != null)
				{
					if (x5.a(kz.aq(), A_5) && kz.c5().n() != g3.b)
					{
						A_7 = true;
					}
					this.k.an(true);
				}
				this.a(ms, A_1, A_2, A_3, A_4, A_5, A_6, A_7);
			}
			else if (x5.d(A_5, kz.aq()) && this.k != null)
			{
				this.a(A_0.a(), ref A_1, false, true);
				this.k = null;
			}
			else
			{
				if (x5.a(kz.aq(), A_5) && kz.c5().n() != g3.b)
				{
					A_7 = true;
				}
				this.a(kz, A_2, A_3, A_4, A_5);
				ms.i(true);
				ms.c(A_1);
				this.i = false;
			}
			return A_1;
		}

		// Token: 0x06001045 RID: 4165 RVA: 0x000BB8F4 File Offset: 0x000BA8F4
		private void a(mu A_0, ref mr A_1, int A_2)
		{
			x5 a_ = x5.c();
			kz kz = A_1.b();
			a_ = kz.aq();
			int num = kz.dg();
			if (num <= 86163053)
			{
				if (num <= 46415)
				{
					if (num == 3034 || num == 3418)
					{
						if (((n5)kz.db()).z() == 1)
						{
							this.l = kz.ar();
						}
						else if (A_0.a().l().c() > 1)
						{
							this.l = x5.c();
						}
						goto IL_3E1;
					}
					if (num != 46415)
					{
						goto IL_33D;
					}
				}
				else if (num != 23684646 && num != 86147604 && num != 86163053)
				{
					goto IL_33D;
				}
			}
			else if (num <= 445520207)
			{
				if (num != 423471123 && num != 426354867 && num != 445520207)
				{
					goto IL_33D;
				}
			}
			else if (num != 506042859 && num != 673419368 && num != 899925938)
			{
				goto IL_33D;
			}
			if (x5.h(this.l, x5.c()))
			{
				this.l = kz.ar();
			}
			if (x5.c(this.l, this.c) && !kz.c0())
			{
				if (kz.dg() == 46415 && x5.c(this.l, base.bl()))
				{
					this.a(A_1);
					this.a(A_1, this.i);
				}
				else if (kz.dg() == 86163053)
				{
					kz.m(this.c);
					kz.c5().i(new x5?(this.c));
					base.an(true);
					this.am(true);
				}
				else
				{
					kz.da();
					this.a(A_1, false);
					this.z = this.a(A_0.a(), ref A_1, false, false);
					this.k = null;
				}
			}
			else if (x5.d(this.b, a_))
			{
				if (kz.by() == 1 && kz.bz() == 1)
				{
					if (!kz.cx() && x5.d(this.b, a_))
					{
						kz.aj(true);
						this.a(A_1, false);
					}
					else if (x5.d(base.aq(), x5.f(this.b, this.r)))
					{
						A_0.a().p(true);
					}
				}
				if (!kz.cx() && !A_0.a().a1())
				{
					A_0.a().p(true);
					this.l = this.t;
					a_ = x5.c();
					this.z = this.a(A_0.a(), ref A_1, false, false);
					this.k = null;
				}
			}
			else if (x5.c(kz.aq(), x5.c()))
			{
				this.a(A_1, false);
			}
			goto IL_3E1;
			IL_33D:
			g6 g = kz.c5().q();
			if (g != g6.b)
			{
				if (kz.dg() == 1000)
				{
					if (x5.g(kz.ar(), x5.c()))
					{
						this.l = kz.ar();
					}
				}
				else
				{
					this.l = kz.ar();
				}
			}
			else
			{
				this.l = kz.ar();
			}
			if (x5.c(kz.aq(), x5.c()) || x5.c(this.l, x5.c()))
			{
				this.a(A_1, false);
			}
			IL_3E1:
			if (kz.dg() == 1977 && !this.ab)
			{
				this.b = x5.c();
			}
			else
			{
				this.d = x5.f(this.d, a_);
				this.b = x5.e(this.b, a_);
				this.d(kz);
			}
			if (kz != null)
			{
				if (x5.c(kz.aq(), x5.c()) || kz.dg() == 1977 || x5.c(this.l, x5.c()))
				{
					if (x5.c(this.l, this.t))
					{
						this.t = this.l;
					}
				}
			}
		}

		// Token: 0x06001046 RID: 4166 RVA: 0x000BBDA4 File Offset: 0x000BADA4
		private void a(kz A_0, x5 A_1, bool A_2, bool A_3, x5 A_4)
		{
			x5 x = A_0.aq();
			x5 a_ = A_0.c7();
			bool flag = false;
			switch (base.c5().n())
			{
			case g3.a:
			case g3.b:
				flag = true;
				break;
			}
			if (!A_2)
			{
				x5 x2 = x5.f(this.m, base.bn());
				if (base.c5().q() != g6.c)
				{
					if (flag)
					{
						x2 = this.an.b(A_1);
					}
					else
					{
						x2 = this.bv().b(A_1);
					}
				}
				if (this.c2())
				{
					x2 = x5.f(x2, base.c5().a1());
				}
				x2 = x5.f(x2, base.ax());
				if (A_3)
				{
					int num = this.dg();
					if (num == 3034 || num == 3418)
					{
						flag = true;
					}
				}
				this.a(A_0, A_4, x2, A_1, flag);
				switch (A_0.c5().n())
				{
				case g3.a:
				case g3.b:
					this.b = x5.e(this.b, x5.f(x, a_));
					break;
				}
			}
			else
			{
				x5 x3 = x5.c();
				int num = this.dg();
				if (num != 3034 && num != 3418)
				{
					if (flag)
					{
						x3 = this.an.b(A_1);
					}
					else
					{
						x3 = this.bv().b(A_1);
					}
				}
				else
				{
					x3 = this.an.b(A_1);
					flag = true;
				}
				if (this.c2())
				{
					x3 = x5.f(x3, base.c5().a1());
				}
				x3 = x5.f(x3, base.ax());
				this.a(A_0, A_4, x3, A_1, flag);
				switch (A_0.c5().n())
				{
				case g3.a:
				case g3.b:
					A_4 = x5.e(A_4, x5.f(x, a_));
					break;
				}
			}
			this.v = A_0.ar();
			if (A_0.c5().n() == g3.a)
			{
				if (!A_2)
				{
					if (x5.c(A_0.ar(), x5.c()))
					{
						this.m = x5.f(this.m, x);
					}
				}
			}
			else
			{
				this.n = x5.f(this.n, x);
			}
		}

		// Token: 0x06001047 RID: 4167 RVA: 0x000BC02C File Offset: 0x000BB02C
		internal x5 a(kz A_0, x5 A_1, x5 A_2, x5 A_3)
		{
			switch (A_0.c5().n())
			{
			case g3.a:
				A_0.i(A_2);
				A_2 = x5.f(A_2, A_0.aq());
				break;
			case g3.b:
				if (this.bv().c().Count >= 1)
				{
					x5 a_ = this.bv().b(A_3, A_1);
					A_0.i(x5.e(a_, A_0.aq()));
				}
				else
				{
					A_0.i(x5.e(A_1, A_0.aq()));
				}
				break;
			}
			A_0.j(A_3);
			this.bv().a(A_0);
			return A_2;
		}

		// Token: 0x06001048 RID: 4168 RVA: 0x000BC0E0 File Offset: 0x000BB0E0
		internal x5 a(kz A_0, x5 A_1, x5 A_2, x5 A_3, bool A_4)
		{
			switch (A_0.c5().n())
			{
			case g3.a:
				A_0.i(A_2);
				A_2 = x5.f(A_2, A_0.aq());
				break;
			case g3.b:
				if (this.bv().c().Count >= 1)
				{
					x5 a_ = this.bv().b(A_3, A_1);
					if (x5.h(a_, x5.c()))
					{
						a_ = A_1;
					}
					A_0.i(x5.e(a_, A_0.aq()));
				}
				else
				{
					A_0.i(x5.e(A_1, A_0.aq()));
				}
				break;
			}
			A_0.j(A_3);
			if (A_4)
			{
				this.c8().a(A_0);
				this.c8().a(true);
			}
			else
			{
				this.bv().a(A_0);
				if (this.c3())
				{
					this.bv().a(true);
				}
			}
			if (A_0.c5().q() == g6.b)
			{
				if (base.c5().q() == g6.b || base.c5().q() == g6.c)
				{
					this.bw().a(A_0);
				}
			}
			return A_2;
		}

		// Token: 0x06001049 RID: 4169 RVA: 0x000BC238 File Offset: 0x000BB238
		private void f(kz A_0)
		{
			if (A_0 != null)
			{
				int num = A_0.dg();
				switch (num)
				{
				case 100:
				case 101:
				case 102:
					break;
				default:
					if (num != 3034 && num != 3418)
					{
						base.am(A_0.bn());
					}
					break;
				}
			}
		}

		// Token: 0x0600104A RID: 4170 RVA: 0x000BC290 File Offset: 0x000BB290
		private void e(kz A_0)
		{
			if (A_0 != null)
			{
				int num = A_0.dg();
				switch (num)
				{
				case 100:
				case 101:
				case 102:
					break;
				default:
					if (num != 3034 && num != 3418)
					{
						if (x5.a(A_0.bn(), this.m))
						{
							this.m = A_0.bn();
						}
						else
						{
							this.m = x5.f(this.m, A_0.bn());
						}
					}
					break;
				}
			}
		}

		// Token: 0x0600104B RID: 4171 RVA: 0x000BC318 File Offset: 0x000BB318
		private void d(kz A_0)
		{
			int num = A_0.dg();
			switch (num)
			{
			case 100:
			case 101:
			case 102:
				break;
			default:
				if (num != 46415)
				{
					if (x5.c(A_0.bn(), base.bn()))
					{
						this.b = x5.e(this.b, x5.e(A_0.bn(), base.bn()));
					}
				}
				break;
			}
		}

		// Token: 0x0600104C RID: 4172 RVA: 0x000BC38C File Offset: 0x000BB38C
		private void a(mr A_0)
		{
			md md = (md)A_0.b();
			this.k = md.d(this.c);
			md.dr().an(true);
			if (this.k != null)
			{
				this.k.j(md.dr());
				((md)this.k).a(true);
			}
			this.l = md.ar();
			md md2 = md;
			md2.l(x5.f(md2.aq(), x5.f(md.c5().a1(), md.c5().a0())));
			md md3 = md;
			md3.m(x5.f(md3.ar(), x5.f(md.c5().a2(), md.c5().a3())));
			md.ad(this.l);
			md.y(this.l);
			md.ac(this.l);
		}

		// Token: 0x0600104D RID: 4173 RVA: 0x000BC488 File Offset: 0x000BB488
		private void a(ms A_0, mr A_1, x5 A_2, bool A_3, bool A_4, x5 A_5, x5 A_6, bool A_7)
		{
			if (A_1.b().dg() == 46415)
			{
				md md = (md)A_1.b();
				this.i = true;
				if (x5.c(A_6, x5.a(1f)))
				{
					this.k = md.d(A_6);
					((md)this.k).a(true);
					this.a(md, A_2, A_3, A_4, A_5);
					A_0.i(true);
				}
				else
				{
					this.k = md;
				}
				bool flag = false;
				bool flag2 = false;
				if (base.cu())
				{
					flag2 = true;
				}
				else
				{
					kz kz = this.dr();
					while (kz != null && !flag)
					{
						if (kz.cu())
						{
							flag2 = true;
							flag = true;
						}
						else
						{
							kz = kz.dr();
						}
					}
				}
				if (!flag2)
				{
					if (this.o == null)
					{
						this.o = new ms(this.k);
					}
					else
					{
						this.o.l().a(this.k);
					}
				}
				else if (this.p == null)
				{
					this.p = new ms(this.k);
				}
				else
				{
					this.p.l().a(this.k);
				}
				mq mq = A_0.l();
				mq.a(mq.c() - 1);
				A_0.c(A_1);
				this.k = null;
			}
			else
			{
				if (this.k != null)
				{
					if (this.o == null)
					{
						this.o = new ms(this.k);
					}
					else
					{
						this.o.l().a(this.k);
					}
				}
				if (A_1.b().c0() || A_1.b().c1())
				{
					this.a(A_1.b(), A_2, A_3, A_4, A_5);
					A_0.i(true);
				}
				if (!this.c0() && !A_7)
				{
					this.am(true);
				}
				mq mq2 = A_0.l();
				mq2.a(mq2.c() - 1);
				A_0.c(A_1);
				this.k = null;
			}
		}

		// Token: 0x0600104E RID: 4174 RVA: 0x000BC6F8 File Offset: 0x000BB6F8
		private ms a(ms A_0, ref mr A_1, bool A_2, bool A_3)
		{
			bool flag = false;
			bool flag2 = false;
			if (this.k != null)
			{
				if (A_1 != null && A_1.b().dg() == 1000 && this.k.dg() == 1000)
				{
					m1 m = ((mx)A_1.b()).a();
					if (m != null && m.g())
					{
						if (!A_1.b().c0())
						{
							((mx)this.k).a(null);
						}
					}
				}
				if (A_1 != null && A_1.b().c5().n() == g3.c && A_1.b().c3() && A_1.b().de() && A_1.b().c0())
				{
					if (this.o == null)
					{
						this.o = new ms(this.k);
					}
					else
					{
						this.o.l().a(this.k);
					}
					if (this.p == null)
					{
						this.p = new ms(this.k);
					}
					else
					{
						this.p.l().a(this.k);
					}
				}
				else if (this.z == null)
				{
					this.z = new ms(this.k);
				}
				else
				{
					this.z.l().a(this.k);
				}
				if (A_1 != null && !A_1.b().c1())
				{
					A_0.c(A_1);
				}
				this.k = null;
			}
			else if (A_1 != null)
			{
				if (A_1.b().c0())
				{
					if (!A_2)
					{
						if (A_1.b().c5().n() == g3.c && A_1.b().c3() && A_1.b().de() && A_1.b().c0())
						{
							if (this.o == null)
							{
								this.o = new ms(A_1.b());
							}
							else
							{
								this.o.l().a(A_1.b());
							}
							if (this.p == null)
							{
								this.p = new ms(A_1.b());
							}
							else
							{
								this.p.l().a(A_1.b());
							}
						}
						else if (this.z == null)
						{
							this.z = new ms(A_1.b());
						}
						else
						{
							this.z.l().a(A_1.b());
						}
					}
					if (A_1.b() != null && A_1.b().dg() == 46415)
					{
						if (x5.c(((md)A_1.b()).aq(), this.b))
						{
							if (A_3)
							{
								flag = true;
							}
							A_0.c(A_1);
						}
					}
					else if (!A_2)
					{
						A_0.c(A_1);
					}
				}
				else if (!A_1.b().c1())
				{
					if (A_1.b().c5().n() == g3.c && A_1.b().c3() && A_1.b().de() && A_1.b().c0())
					{
						if (this.o == null)
						{
							this.o = new ms(A_1.b());
						}
						else
						{
							this.o.l().a(A_1.b());
						}
						if (this.p == null)
						{
							this.p = new ms(A_1.b());
						}
						else
						{
							this.p.l().a(A_1.b());
						}
					}
					else if (this.z == null)
					{
						this.z = new ms(A_1.b());
					}
					else
					{
						this.z.l().a(A_1.b());
					}
					A_0.c(A_1);
				}
			}
			if (!flag && A_1 != null && !flag2)
			{
				A_1 = A_1.c();
				while (A_1 != null && A_1.b() != null)
				{
					if (this.z == null)
					{
						this.z = new ms(A_1.b());
					}
					else
					{
						this.z.l().a(A_1.b());
					}
					A_0.c(A_1);
					A_1 = A_1.c();
				}
			}
			if (this.z != null)
			{
				this.z.e(A_0.v());
			}
			return this.z;
		}

		// Token: 0x0600104F RID: 4175 RVA: 0x000BCC8C File Offset: 0x000BBC8C
		private ms a(ms A_0, int A_1)
		{
			if (this.k != null)
			{
				if (A_1 == 1 && !this.k.c1())
				{
					this.z = new ms(this.k);
				}
				else if (this.z == null)
				{
					if (A_1 > 1)
					{
						mr mr = A_0.l().a();
						for (int i = 1; i < A_1; i++)
						{
							nt nt = ((nt)mr.b()).m();
							nt.f(true);
							if (i == 1)
							{
								this.z = new ms(nt);
							}
							else
							{
								this.z.l().a(nt);
							}
							mr = mr.c();
						}
						this.z.l().a(this.k);
					}
					else
					{
						this.z = new ms(this.k);
					}
				}
				else
				{
					this.z.l().a(this.k);
				}
			}
			return this.z;
		}

		// Token: 0x06001050 RID: 4176 RVA: 0x000BCDC4 File Offset: 0x000BBDC4
		protected void c(PageWriter A_0, x5 A_1, x5 A_2)
		{
			g6 g = base.c5().q();
			if (g != g6.c)
			{
				switch (base.c5().n())
				{
				case g3.a:
				case g3.b:
					this.d(A_0, A_1, A_2);
					break;
				default:
				{
					g2 valueOrDefault = base.c5().t().GetValueOrDefault();
					g2? g2;
					if (g2 != null)
					{
						if (valueOrDefault == g2.b)
						{
							this.d(A_0, A_1, A_2);
							break;
						}
					}
					this.b(A_0, A_1, A_2);
					break;
				}
				}
			}
			else
			{
				this.d(A_0, A_1, A_2);
			}
		}

		// Token: 0x06001051 RID: 4177 RVA: 0x000BCE58 File Offset: 0x000BBE58
		private void b(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c5().c().e(this.r());
			base.c5().c().f(this.q());
			base.c5().c().g(this.s());
			base.c5().c().h(this.t());
			x5 a_ = A_2;
			x5 a_2 = A_1;
			if (this.dg() == 1)
			{
				a_ = x5.c();
				a_2 = x5.c();
			}
			A_1 = x5.f(A_1, base.an());
			A_1 = x5.f(A_1, base.cc());
			if (!this.c3())
			{
				A_1 = x5.f(A_1, this.dc());
			}
			bool flag = false;
			if (!base.c1() || !this.q())
			{
				A_1 = x5.f(A_1, base.c5().e().d());
				flag = true;
			}
			switch (base.c5().q())
			{
			case g6.b:
				if (!this.c(this.dg()))
				{
					A_1 = x5.f(A_1, base.@as());
				}
				if (base.c5().b() != null)
				{
					A_1 = x5.f(A_1, base.c5().b().Value);
				}
				else if (base.c5().s() != null)
				{
					A_1 = x5.e(A_1, base.c5().s().Value);
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
						x5 a_3 = x5.c();
						flag2 = (x != null && !x5.g(x.GetValueOrDefault(), a_3));
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
				else if (base.c5().s() != null)
				{
					A_1 = x5.e(base.bi(), x5.f(base.aq(), base.c5().s().Value));
				}
				if (!this.c(this.dg()) && !base.c5().y())
				{
					A_1 = x5.f(A_1, base.@as());
				}
				if (base.c5().a() != null)
				{
					A_2 = x5.f(A_2, base.c5().a().Value);
				}
				else if (base.c5().h() != null)
				{
					A_2 = x5.e(base.bj(), base.c5().h().Value);
				}
				break;
			}
			x5 x2 = x5.f(base.c5().e().d(), base.c5().e().b());
			x5 a_4 = x5.f(base.c5().e().a(), base.c5().e().c());
			x5 a_5 = x5.e(x5.f(base.c5().a2(), base.c5().a3()), a_4);
			x5 a_6 = x5.e(x5.f(base.c5().a1(), base.c5().a0()), x2);
			x5 x3 = A_1;
			x5 x4 = x5.c();
			if (!this.f && base.c5().c().o() != ft.a)
			{
				A_1 = x5.f(A_1, base.c5().c().n());
			}
			if (!this.f)
			{
				A_1 = x5.f(A_1, base.c5().f().d());
			}
			List<li> list = this.a(this.bw().b());
			int num = this.b(list);
			if (base.c5().q() != g6.c && base.c5().q() != g6.b)
			{
				if (num > 0)
				{
					this.a(A_0, A_1, A_2, list, 0, num);
				}
			}
			x5 a_7 = A_1;
			x5 a_8 = A_2;
			x5 x5 = x5.e(x5.e(A_2, base.c5().f().a()), base.c5().e().a());
			bool flag3 = false;
			if (this.n() != null)
			{
				bool flag4 = false;
				x5 a_9 = x5.c();
				mu mu = this.n().c();
				int num2 = 0;
				while (mu != null && mu.a() != null)
				{
					num2++;
					ms ms = mu.a();
					if (ms.l() != null)
					{
						ms.ac(base.cb());
						ms.b(this);
						if (base.c1() && this.r())
						{
							x2 = x5.e(x2, x2);
						}
						if (this.dg() != 505061334)
						{
							x5 a_10 = x5.e(ms.ah(), base.a1());
							if (!ms.w())
							{
								this.a(A_0, x3, A_2, x5.e(base.aq(), x2), x5.f(ms.n(), a_5));
								flag4 = true;
							}
							if (num2 == 1)
							{
								if (this.dg() != 1)
								{
									if (num > 0)
									{
										if (base.c5().q() == g6.c)
										{
											this.a(A_0, a_2, a_, list, 0, num);
										}
										else
										{
											this.a(A_0, A_1, A_2, list, 0, num);
										}
									}
									if (base.c5().aa())
									{
										this.a(A_0, x3, A_2, x5.e(base.aq(), x2), base.ar());
									}
									else if (!flag4)
									{
										this.a(A_0, x3, x5.f(A_2, a_10), x5.e(base.aq(), x2), base.ar());
									}
								}
								else
								{
									this.a(A_0, A_1, A_2, x5.e(base.aq(), x2), base.ar());
								}
							}
						}
						else
						{
							x5 x6 = x5.f(ms.r(), a_6);
							if (mu.c() != null)
							{
								base.c5().c().f(true);
								if (flag)
								{
									a_9 = base.c5().a1();
								}
								else
								{
									a_9 = base.c5().c().n();
								}
								x6 = x5.e(x6, base.c5().c().n());
								x6 = x5.e(x6, base.c5().f().d());
							}
							if (ms.l() == null || ms.l().a() == null || ms.l().a().b() == null || !ms.l().a().b().de())
							{
								if (mu.b() != null)
								{
									x6 = x5.e(x6, base.c5().c().r());
									x6 = x5.e(x6, base.c5().f().b());
								}
								this.a(A_0, x5.e(x3, a_9), x5.f(ms.ag(), x5), x6, x5.f(ms.n(), a_5));
								base.c5().c().a(A_0, x5.e(x3, a_9), x5.f(ms.ag(), x5), x6, x5.f(ms.n(), a_5));
							}
						}
						if (!base.b7() && !this.c3())
						{
							ms.g(true);
						}
						if (mu.c() != null && mu.c().a().l() != null)
						{
							kz kz = mu.c().a().l().a().b();
							if (kz != null)
							{
								if (!this.de() || kz.c5().t() == g2.b)
								{
									ms.g(false);
								}
							}
						}
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
						x4 = A_2;
						if (base.c5().d())
						{
							if (!base.c5().c().au() && base.c5().c().g() != ft.a)
							{
								x4 = x5.f(x4, base.c5().c().f());
							}
						}
						if (ms.w())
						{
							A_1 = x5.e(A_1, this.dc());
						}
						if (this.dg() != 1)
						{
							ms.a(A_0, x5.e(A_1, a_9), x4);
						}
						else
						{
							ms.a(A_0, x5.e(A_1, a_9), A_2);
						}
						A_1 = x5.e(A_1, a_9);
					}
					else if (base.c5().q() == g6.b)
					{
						this.a(A_0, x3, A_2, x5.e(base.aq(), x2), base.ar());
						base.c5().c().a(A_0, x3, x5, x5.e(base.aq(), x2), x5.f(base.ar(), a_5));
					}
					mu = mu.b();
				}
				this.a(A_0, a_7, a_8);
				if (this.dg() != 1)
				{
					if (base.c5().q() == g6.c)
					{
						this.a(A_0, a_2, a_, list, 0, list.Count);
					}
					else
					{
						this.a(A_0, A_1, A_2, list, num, list.Count);
					}
				}
				else
				{
					this.a(A_0, x5.a(0f), x5.a(0f), list, num, list.Count);
				}
			}
			else
			{
				this.a(A_0, x3, x5, x5.e(base.aq(), x2), x5.f(base.ar(), a_5));
				if (this.dg() != 86163053)
				{
					base.c5().c().a(A_0, x3, x5, x5.e(base.aq(), x2), x5.f(base.ar(), a_5));
				}
				else
				{
					base.c5().c().a(A_0, x3, x5, base.aq(), base.ar());
				}
				flag3 = true;
			}
			if (this.dg() == 86163053 && !flag3)
			{
				base.c5().c().a(A_0, x3, x5, x5.e(base.aq(), x2), x5.f(base.ar(), a_5));
			}
			base.i(x5.c());
			base.j(x4);
			base.au(x5.c());
		}

		// Token: 0x06001052 RID: 4178 RVA: 0x000BDAC4 File Offset: 0x000BCAC4
		protected void d(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c5().c().e(this.r());
			base.c5().c().f(this.q());
			base.c5().c().g(this.s());
			base.c5().c().h(this.t());
			A_1 = x5.f(A_1, base.cc());
			x5 a_ = A_2;
			x5 x = A_1;
			x5 x2 = x5.c();
			x5 x3 = x5.f(base.c5().e().d(), base.c5().e().b());
			x5 x4 = A_2;
			if (!this.s() && !this.@do())
			{
				x2 = x5.f(x2, base.c5().e().a());
				if (base.c5().q() == g6.c)
				{
					x4 = x5.f(x4, base.c5().e().m());
				}
				else if (base.c5().h() == null)
				{
					x4 = x5.f(x4, base.c5().e().a());
				}
				a_ = x4;
			}
			if (base.c5().q() == g6.b)
			{
				A_2 = x5.f(A_2, base.c5().e().m());
			}
			if (!this.t())
			{
				x2 = x5.f(x2, base.c5().e().c());
			}
			A_1 = x5.f(A_1, base.c5().e().d());
			x5 x5 = A_1;
			List<li> list = this.a(this.bw().b());
			int num = 0;
			if (list != null)
			{
				num = this.b(list);
			}
			if (this.c3() || base.c5().q() == g6.c)
			{
				x5 a_2 = x5.c();
				if (base.c5().v() != null && x5.g(base.c5().v().Value, x5.c()))
				{
					a_2 = x5.e(x5.f(base.c5().v().Value, this.ab()), x2);
				}
				else
				{
					x5 a_3 = x5.c();
					bool flag;
					if (base.c5().a() != null)
					{
						x5? x6 = base.c5().a();
						x5 a_4 = x5.c();
						if (x6 != null && x5.c(x6.GetValueOrDefault(), a_4) && base.c5().h() != null)
						{
							flag = (base.c5().i() == null);
							goto IL_2EF;
						}
					}
					flag = true;
					IL_2EF:
					if (!flag)
					{
						a_3 = x5.f(base.c5().a().Value, base.c5().i().Value);
						a_2 = x5.e(x5.e(base.ar(), x2), a_3);
					}
					else
					{
						a_2 = x5.e(x5.e(base.ar(), x2), a_3);
					}
				}
				if (x5.c(x5.e(base.aq(), x3), x5.c()))
				{
					x5 a_5 = base.aq();
					if (x5.c(x3, x5.c()))
					{
						a_5 = x5.e(base.aq(), x3);
					}
					if (base.c5().an())
					{
						if (x5.c(base.c5().aq(), x5.c()))
						{
							a_5 = base.c5().aq();
						}
						else if (x5.c(base.c5().@as(), x5.c()))
						{
							a_5 = base.c5().@as();
						}
					}
					else if (base.c5().an())
					{
						if (x5.c(base.c5().aq(), x5.c()))
						{
							a_5 = base.c5().aq();
						}
						else if (x5.c(base.c5().@as(), x5.c()))
						{
							a_5 = base.c5().@as();
						}
					}
					this.a(A_0, A_1, x4, a_5, a_2);
				}
			}
			else
			{
				x5 a_6 = x5.e(base.ar(), x2);
				int num2 = this.dg();
				if (num2 != 34721 && num2 != 622899778)
				{
					x5 x7 = x5.e(base.bi(), x3);
					if (base.c5().am() != null)
					{
						x7 = base.c5().am().Value;
						x7 = x5.f(x7, x5.f(x5.f(x5.f(base.c5().f().d(), base.c5().c().n()), base.c5().f().b()), base.c5().c().r()));
					}
					this.a(A_0, A_1, x4, x7, a_6);
				}
				else if (base.c5().q() == g6.b && this.dg() == 34721)
				{
					this.a(A_0, A_1, x4, x5.e(base.bi(), x3), a_6);
				}
				else
				{
					this.a(A_0, A_1, x4, x5.e(base.aq(), x3), a_6);
				}
			}
			bool flag2 = false;
			base.i(x5);
			base.j(x4);
			if (num > 0)
			{
				this.a(A_0, x, a_, list, 0, num);
			}
			x5 = A_1;
			if (!this.q())
			{
				x = x5.f(x, base.c5().a1());
			}
			if (this.n() != null)
			{
				mu mu = this.n().c();
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
						if (!this.q())
						{
							A_1 = x5.f(A_1, x5.e(base.c5().a1(), base.c5().e().d()));
							if (x5.g(ms.ae(), x5.c()) && !this.c3())
							{
								if (x5.c(ms.ae(), base.az()))
								{
									A_1 = x5.e(A_1, base.az());
								}
								else
								{
									A_1 = x5.e(A_1, ms.ae());
								}
							}
						}
						ms.a(this, mu.b(), base.cr());
						if (this.dg() == 1000 && !flag2)
						{
							x5 a_7 = x5.c();
							x5 a_8 = x5.c();
							if (((mx)this).a() != null)
							{
								a_8 = x5.f(x5.a(this.dr().c5().f().d(), 5), ((mx)this).a().aq());
							}
							if (this.n() != null && this.n().c() != null && this.n().c().a() != null && x5.g(this.n().c().a().ah(), x5.c()))
							{
								a_7 = x5.f(this.n().c().a().ah(), base.c5().f().a());
							}
							else if (((mx)this).a() != null)
							{
								a_7 = x5.f(((mx)this).a().ar(), base.c5().f().a());
							}
							if (((mx)this).a() != null)
							{
								if (((n5)((mx)this).dr().db()).b().c() == hp.a)
								{
									((mx)this).a().b(true);
								}
								((mx)this).a().dk(A_0, A_1, x5.f(x5.f(A_2, a_7), base.c5().e().a()));
								if (((mx)this).a().f())
								{
									A_1 = x5.f(A_1, a_8);
								}
								if (mu.b() != null)
								{
									flag2 = true;
								}
							}
						}
						ms.a(A_0, A_1, A_2);
						A_1 = x5;
					}
					mu = mu.b();
				}
			}
			x5 = x5.f(x5, x5.e(base.c5().a1(), base.c5().e().d()));
			x4 = x5.f(x4, x5.f(base.c5().c().f(), base.c5().f().a()));
			this.a(A_0, x5, x4);
			if (list != null && list.Count > 0)
			{
				this.a(A_0, x5, x4, list, num, list.Count);
			}
			base.au(x5.c());
		}

		// Token: 0x06001053 RID: 4179 RVA: 0x000BE4EC File Offset: 0x000BD4EC
		private void a(PageWriter A_0, x5 A_1, x5 A_2)
		{
			List<li> list = this.c8().b();
			for (int i = 0; i < list.Count; i++)
			{
				kz kz = list[i].a();
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

		// Token: 0x06001054 RID: 4180 RVA: 0x000BE598 File Offset: 0x000BD598
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
						this.c(kz);
						x5 a_ = (kz.c5().b() != null) ? kz.c5().b().Value : x5.c();
						x5 a_2 = (kz.c5().a() != null) ? kz.c5().a().Value : x5.c();
						if (kz.dr() != null)
						{
							x2 = x5.f(x2, kz.dr().an());
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
							if (flag)
							{
								x2 = x5.f(x2, kz.dr().an());
								x = x5.f(x, kz.dr().ao());
							}
							else
							{
								x2 = x5.f(x2, this.b(kz));
								x = x5.f(x, kz.ao());
							}
							break;
						case g7.c:
						case g7.d:
							if (flag)
							{
								x2 = x5.f(x2, kz.dr().an());
								x = x5.f(x, kz.dr().ao());
							}
							if (kz.c5().s() != null)
							{
								x2 = this.b(kz);
							}
							else
							{
								x2 = x5.f(x2, this.b(kz));
							}
							x = x5.f(x, this.a(kz));
							break;
						}
						break;
					}
					if (kz.dg() == 46415)
					{
						x = x5.f(x, kz.ar());
					}
					kz.dk(A_0, x2, x);
					x = A_2;
					x2 = A_1;
				}
				A_4++;
			}
		}

		// Token: 0x06001055 RID: 4181 RVA: 0x000BE818 File Offset: 0x000BD818
		private void c(kz A_0)
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

		// Token: 0x06001056 RID: 4182 RVA: 0x000BE8DC File Offset: 0x000BD8DC
		private x5 b(kz A_0)
		{
			x5 x = x5.c();
			lk lk = A_0.c5();
			if (lk.b() != null)
			{
				x = m4.a(x5.b(lk.b().Value), x5.b(base.aq()), lk.ax());
			}
			else if (lk.s() != null)
			{
				x = x5.e(base.aq(), x5.f(A_0.aq(), m4.a(x5.b(lk.s().Value), x5.b(base.aq()), lk.av())));
				lk.e().b();
				bool flag = 1 == 0;
				x = x5.e(x, lk.e().b());
			}
			return x;
		}

		// Token: 0x06001057 RID: 4183 RVA: 0x000BE9C8 File Offset: 0x000BD9C8
		private x5 a(kz A_0)
		{
			x5 result = x5.c();
			lk lk = A_0.c5();
			x5 a_ = base.ar();
			if (lk.a() != null)
			{
				result = m4.a(x5.b(lk.a().Value), x5.b(a_), lk.au());
			}
			else if (lk.h() != null)
			{
				if (x5.g(a_, x5.c()))
				{
					result = x5.e(a_, x5.f(A_0.ar(), m4.a(x5.b(lk.h().Value), x5.b(a_), lk.aw())));
				}
				else
				{
					result = x5.f(A_0.ar(), m4.a(x5.b(lk.h().Value), x5.b(a_), lk.aw()));
				}
			}
			return result;
		}

		// Token: 0x06001058 RID: 4184 RVA: 0x000BEAD8 File Offset: 0x000BDAD8
		internal void a(OperatorWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			switch (base.c5().az())
			{
			case g9.b:
			case g9.c:
				break;
			default:
				if (this.w() != null)
				{
					if (this.dg() == 86163053)
					{
						A_2 = x5.e(A_2, base.ar());
					}
					if (!this.de())
					{
						this.w().a(base.aq());
					}
					else
					{
						this.w().b(false);
					}
					if (x5.c(A_4, x5.c()))
					{
						base.c5().c().a(A_0, A_1, A_2, A_3, A_4);
						A_1 = x5.f(A_1, base.c5().c().n());
						A_2 = x5.f(A_2, base.c5().c().f());
						base.c5().ay().a(A_0, A_1, A_2, A_3, A_4);
					}
					this.w().a(this.de());
					A_3 = x5.e(A_3, x5.f(base.c5().c().n(), base.c5().c().r()));
					A_4 = x5.e(A_4, x5.f(base.c5().c().f(), base.c5().c().j()));
					this.w().a(base.c5(), A_0, A_1, A_2, A_3, A_4);
				}
				else if (x5.c(A_4, x5.c()))
				{
					base.c5().c().a(A_0, A_1, A_2, A_3, A_4);
					A_1 = x5.f(A_1, base.c5().c().n());
					A_2 = x5.f(A_2, base.c5().c().f());
					A_3 = x5.e(A_3, x5.f(base.c5().c().n(), base.c5().c().r()));
					A_4 = x5.e(A_4, x5.f(base.c5().c().f(), base.c5().c().j()));
					base.c5().ay().a(A_0, A_1, A_2, A_3, A_4);
				}
				break;
			}
		}

		// Token: 0x06001059 RID: 4185 RVA: 0x000BED44 File Offset: 0x000BDD44
		internal k0 k(bool A_0)
		{
			k0 k = this.dd();
			k.df(this.de());
			this.a(k, A_0);
			return k;
		}

		// Token: 0x0600105A RID: 4186 RVA: 0x000BED74 File Offset: 0x000BDD74
		internal override void da()
		{
			int num = this.dg();
			if (num != 3034 && num != 3418)
			{
				k0 k = (k0)this.dr();
				x5 x = x5.f(k.c5().a1(), k.ax());
				x5 x2 = x5.f(k.c5().a0(), k.ay());
				x = (x5.d(x, x5.c()) ? x5.d(x) : x);
				x2 = (x5.d(x2, x5.c()) ? x5.d(x2) : x2);
				if (base.c5().q() != g6.c && !base.c5().x())
				{
					if (x5.b(x5.e(k.b, x5.f(x, x2)), x5.f(base.aq(), x5.a(0.0001))) || !this.de() || !this.c3())
					{
						this.dr().am(this.c0());
					}
					else if (x5.d(this.c, base.ar()) && !base.c5().m())
					{
						this.dr().am(this.c0());
					}
					else if (!this.c0())
					{
						this.dr().am(this.c0());
					}
				}
			}
			else if (((n5)this.db()).z() == 1)
			{
				if (this.dr().c0())
				{
					this.dr().am(this.c0());
				}
			}
		}

		// Token: 0x040007C7 RID: 1991
		private mt a = null;

		// Token: 0x040007C8 RID: 1992
		private x5 b = x5.c();

		// Token: 0x040007C9 RID: 1993
		private x5 c = x5.c();

		// Token: 0x040007CA RID: 1994
		private x5 d = x5.c();

		// Token: 0x040007CB RID: 1995
		private bool e = false;

		// Token: 0x040007CC RID: 1996
		private bool f = false;

		// Token: 0x040007CD RID: 1997
		private bool g = false;

		// Token: 0x040007CE RID: 1998
		private bool h = false;

		// Token: 0x040007CF RID: 1999
		private bool i = false;

		// Token: 0x040007D0 RID: 2000
		private mf j = null;

		// Token: 0x040007D1 RID: 2001
		private kz k = null;

		// Token: 0x040007D2 RID: 2002
		private x5 l = x5.c();

		// Token: 0x040007D3 RID: 2003
		private x5 m = x5.c();

		// Token: 0x040007D4 RID: 2004
		private x5 n = x5.c();

		// Token: 0x040007D5 RID: 2005
		private ms o = null;

		// Token: 0x040007D6 RID: 2006
		private ms p = null;

		// Token: 0x040007D7 RID: 2007
		private x5 q = x5.c();

		// Token: 0x040007D8 RID: 2008
		private new x5 r = x5.c();

		// Token: 0x040007D9 RID: 2009
		private x5 s = x5.c();

		// Token: 0x040007DA RID: 2010
		private x5 t = x5.c();

		// Token: 0x040007DB RID: 2011
		private x5 u = x5.c();

		// Token: 0x040007DC RID: 2012
		private x5 v = x5.c();

		// Token: 0x040007DD RID: 2013
		private x5 w = x5.c();

		// Token: 0x040007DE RID: 2014
		private x5 x = x5.c();

		// Token: 0x040007DF RID: 2015
		private x5 y = x5.c();

		// Token: 0x040007E0 RID: 2016
		private ms z = null;

		// Token: 0x040007E1 RID: 2017
		private int aa = 0;

		// Token: 0x040007E2 RID: 2018
		private bool ab = false;

		// Token: 0x040007E3 RID: 2019
		private ny ac = null;

		// Token: 0x040007E4 RID: 2020
		private x5 ad = x5.c();

		// Token: 0x040007E5 RID: 2021
		private x5 ae = x5.c();

		// Token: 0x040007E6 RID: 2022
		private x5 af = x5.c();

		// Token: 0x040007E7 RID: 2023
		private ll ag = null;

		// Token: 0x040007E8 RID: 2024
		private int ah = 1;

		// Token: 0x040007E9 RID: 2025
		private HtmlArea ai = null;

		// Token: 0x040007EA RID: 2026
		private bool? aj = null;

		// Token: 0x040007EB RID: 2027
		private int? ak = null;

		// Token: 0x040007EC RID: 2028
		private bool al = false;

		// Token: 0x040007ED RID: 2029
		private bool am = false;

		// Token: 0x040007EE RID: 2030
		private ld an = new ld();

		// Token: 0x040007EF RID: 2031
		private x5 ao = x5.c();

		// Token: 0x040007F0 RID: 2032
		private x5 ap = x5.c();

		// Token: 0x040007F1 RID: 2033
		private bool aq = false;

		// Token: 0x040007F2 RID: 2034
		private x5 ar = x5.c();

		// Token: 0x040007F3 RID: 2035
		private mt @as = null;

		// Token: 0x040007F4 RID: 2036
		private mt at = null;
	}
}
