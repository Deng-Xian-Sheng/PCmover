using System;

namespace zz93
{
	// Token: 0x0200022C RID: 556
	internal class oi : dy
	{
		// Token: 0x06001A23 RID: 6691 RVA: 0x0010FA7C File Offset: 0x0010EA7C
		internal oi(jk A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new oj(A_0, A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001A24 RID: 6692 RVA: 0x0010FACC File Offset: 0x0010EACC
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001A25 RID: 6693 RVA: 0x0010FAE4 File Offset: 0x0010EAE4
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001A26 RID: 6694 RVA: 0x0010FAFC File Offset: 0x0010EAFC
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001A27 RID: 6695 RVA: 0x0010FB14 File Offset: 0x0010EB14
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001A28 RID: 6696 RVA: 0x0010FB20 File Offset: 0x0010EB20
		private void a(mz A_0, ij A_1, bool A_2, m1 A_3, string A_4)
		{
			ms ms = null;
			mt mt = null;
			bool flag = false;
			int num = this.cg().h();
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			lk lk = null;
			x5? x = ((n5)A_0.db()).p();
			base.d(A_0);
			if (A_0.a() != ol.c)
			{
				if (!A_0.c5().g() || !A_0.c5().f().i())
				{
					A_0.c5().f().d(x5.a(30f));
					A_0.c5().b(true);
					A_0.c5().f().a(true);
				}
			}
			if (this.cg() != null && this.cg().h() > 0)
			{
				kz kz = this.cg().b(0).cm(A_1, A_0);
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
					lk = kz.c5();
					flag3 = A_0.c5().a(lk);
					if (num == 1)
					{
						if (flag3)
						{
							A_0.c5().a(g4.d, lk);
						}
					}
					else if (flag3)
					{
						A_0.c5().a(g4.c, lk);
					}
					kz.a(lk);
					flag3 = false;
					lk = kz.c5();
					kz.aw(x5.a((float)this.cg().h()));
					kz.j(A_0);
					if (!A_2)
					{
						if (kz.dg() == 1000)
						{
							A_3.dc(kz.db());
							A_3.a(A_0.c5().f().d());
							if (((n5)kz.db()).a().d() && ((n5)A_0.db()).a().d())
							{
								((n5)A_3.db()).a().a(x5.a(12f));
							}
							((n5)A_3.db()).a().a("Arial");
							A_3.a(kz.c5());
							if (kz.de() && !kz.c5().u())
							{
								((mx)kz).a(A_3);
							}
						}
					}
					kz.aw(x5.a((float)this.cg().h()));
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
							goto IL_ACC;
						}
						goto IL_454;
					}
					goto IL_454;
					IL_ACC:
					i++;
					continue;
					IL_454:
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
							if (kz.c5().o() == g0.c)
							{
								flag = false;
							}
							base.a(kz, ref g);
							if (kz.de())
							{
								A_3 = new m1(A_1);
								if (A_4 != null)
								{
									A_3.a(A_4);
									A_3.b(A_1.e());
								}
								if (this.cg().b(i).ch().cn() == 2585 || this.cg().b(i).ch().cn() == 2595)
								{
									A_3.a(true);
								}
								else
								{
									A_3.a(false);
								}
								if (!A_2)
								{
									if (kz.dg() == 1000)
									{
										A_3.dc(kz.db());
										A_3.a(A_0.c5().f().d());
										if (((n5)kz.db()).a().d() && ((n5)A_0.db()).a().d())
										{
											((n5)A_3.db()).a().a(x5.a(12f));
										}
										((n5)A_3.db()).a().a("Arial");
										A_3.a(kz.c5());
										if (!kz.c5().u())
										{
											((mx)kz).a(A_3);
										}
									}
								}
							}
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
										if (base.h(i) && kz.dg() != 34721)
										{
											if (kz.c5().q() == g6.b)
											{
												this.a(A_0, ref ms, ref mt, kz);
												flag5 = true;
											}
											else
											{
												bool flag6 = base.a(i, ms, A_0, A_1);
												if (flag6)
												{
													i++;
													num++;
												}
											}
										}
										if ((this.cg().b(i).cr() != fa.e || i + 1 >= num || !base.h(i + 1)) && !flag5)
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
							lk = kz.c5();
							flag3 = A_0.c5().a(lk);
							if (flag3)
							{
								A_0.c5().a(g4.b, lk);
								kz.a(lk);
							}
						}
						flag3 = false;
					}
					goto IL_ACC;
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
			else if (num > 1)
			{
			}
		}

		// Token: 0x06001A29 RID: 6697 RVA: 0x00110698 File Offset: 0x0010F698
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

		// Token: 0x06001A2A RID: 6698 RVA: 0x001106E4 File Offset: 0x0010F6E4
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

		// Token: 0x06001A2B RID: 6699 RVA: 0x0011074C File Offset: 0x0010F74C
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

		// Token: 0x06001A2C RID: 6700 RVA: 0x00110950 File Offset: 0x0010F950
		private void a(ij A_0)
		{
			if (this.a.b() != ok.i)
			{
				hq hq = new hq();
				af4 a_ = new af4(null);
				af5 a_2 = new af5(hp.b);
				af6 a_3 = new af6(ok.v);
				switch (this.a.b())
				{
				case ok.a:
				case ok.b:
				case ok.c:
				case ok.d:
				case ok.e:
				case ok.f:
				case ok.g:
				case ok.h:
				case ok.j:
				case ok.k:
				case ok.l:
				case ok.m:
				case ok.n:
				case ok.o:
				case ok.p:
				case ok.q:
				case ok.r:
				case ok.s:
				case ok.t:
				case ok.u:
					a_3 = new af6(this.a.b());
					break;
				}
				fb<f8>[] array = new fb<f8>[3];
				array[0].a(514326864);
				array[0].a(a_);
				array[1].a(389285250);
				array[1].a(a_2);
				array[2].a(430959576);
				array[2].a(a_3);
				hq.a(array);
				ig a_4 = new ig(new fc[]
				{
					new fc(6947816, hq)
				});
				A_0.a(this.ch().cn(), a_4);
				A_0.a(true);
			}
		}

		// Token: 0x06001A2D RID: 6701 RVA: 0x00110AC8 File Offset: 0x0010FAC8
		internal override kz cm(ij A_0, kz A_1)
		{
			mz mz = new mz(this.ch().cn());
			this.a(A_0);
			A_0.c(this.ch());
			A_0.a(mz);
			n5 n = (n5)mz.db();
			mz.c5().c().i(n.j());
			A_0.b(mz);
			lk lk = mz.c5();
			m2 m = lk.e();
			bool flag = true;
			bool flag2 = false;
			g2? g = lk.t();
			g2 valueOrDefault = g.GetValueOrDefault();
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					mz = null;
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
				mz.j(A_1);
				m1 m2 = new m1(A_0);
				m2.dc(n);
				bool a_ = false;
				string text = null;
				int num = this.a.cn();
				if (num != 2585)
				{
					if (num != 2595)
					{
						if (num == 2613)
						{
							mz.a(ol.c);
							a_ = true;
						}
					}
					else
					{
						if (mz.dr().dg() == 2595)
						{
							mz.j(mz.dr().bc());
						}
						mz mz2 = mz;
						mz2.j(mz2.bc() + 1);
						mz.a(ol.b);
						if (n.b().a() == null)
						{
							if (n.b().b() != ok.v)
							{
								m2.a(n.b().b());
							}
							else
							{
								switch (mz.bc())
								{
								case 1:
									m2.a(ok.f);
									goto IL_28B;
								case 2:
									m2.a(ok.h);
									goto IL_28B;
								}
								m2.a(ok.g);
								IL_28B:
								n.b().a(m2.b());
							}
							if (n.b().b() == ok.i || n.b().b() == ok.v)
							{
								a_ = true;
							}
						}
						else
						{
							text = n.b().a();
							m2.a(text);
							m2.b(A_0.e());
						}
					}
				}
				else
				{
					mz.a(ol.a);
					int num2 = ((ox)this.a).a();
					if (this.a.b() == ok.v || this.a.b() == ok.e)
					{
						if (n.b().b() != ok.v)
						{
							this.a.a(n.b().b());
						}
						else
						{
							this.a.a(ok.e);
						}
					}
					mz.a(this.a.b());
					mz.a((num2 != int.MinValue) ? num2 : 1);
				}
				num = mz.dr().dg();
				if (num != 1000 && num != 2585 && num != 2595)
				{
					if (!flag2)
					{
						lk.e().a(new int?(mz.dg()));
					}
				}
				i3.a(mz);
				i3.a(mz, A_0);
				m4.a(n, mz.c5(), flag2);
				if (mz.c5().ay().e() != null)
				{
					mz.b(mg.a(A_0, mz.c5().ay().e(), A_0.e()));
				}
				mz.aa(A_1.ch());
				if (mz.ch())
				{
					mz.ab(A_1.ci());
					mz.az(A_1.cl());
					mz.ay(A_1.ck());
				}
				g6 g2 = lk.q();
				if (g2 != g6.c)
				{
					switch (lk.n())
					{
					case g3.a:
					case g3.b:
						this.a(mz, A_0, a_, m2, text);
						goto IL_4B8;
					}
					g = lk.t();
					valueOrDefault = g.GetValueOrDefault();
					if (g != null)
					{
						switch (valueOrDefault)
						{
						case g2.c:
							m.a(x5.c());
							m.c(x5.c());
							base.a(this.o(), mz, A_0);
							mz.df(false);
							goto IL_4B6;
						}
					}
					this.a(mz, A_0, a_, m2, text);
					IL_4B6:
					IL_4B8:;
				}
				else
				{
					this.a(mz, A_0, a_, m2, text);
				}
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
				int num = this.a.cn();
				if (num != 2585)
				{
					if (num == 2595)
					{
						if (mz != null && mz.dr().dg() == 2595 && mz.bc() > 3)
						{
							mz mz3 = mz;
							mz3.j(mz3.bc() - 1);
						}
					}
				}
			}
			return mz;
		}

		// Token: 0x04000BCE RID: 3022
		private new jk a = null;

		// Token: 0x04000BCF RID: 3023
		private oj b = null;

		// Token: 0x04000BD0 RID: 3024
		private bool c = true;
	}
}
