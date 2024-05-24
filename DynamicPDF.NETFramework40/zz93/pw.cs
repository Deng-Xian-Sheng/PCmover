using System;
using System.Collections.Generic;

namespace zz93
{
	// Token: 0x0200025E RID: 606
	internal class pw : er
	{
		// Token: 0x06001B7A RID: 7034 RVA: 0x0011AF94 File Offset: 0x00119F94
		internal pw(p0 A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new px(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001B7B RID: 7035 RVA: 0x0011AFF8 File Offset: 0x00119FF8
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001B7C RID: 7036 RVA: 0x0011B010 File Offset: 0x0011A010
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001B7D RID: 7037 RVA: 0x0011B028 File Offset: 0x0011A028
		internal override bool ci()
		{
			return this.f;
		}

		// Token: 0x06001B7E RID: 7038 RVA: 0x0011B040 File Offset: 0x0011A040
		internal override void cj(bool A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06001B7F RID: 7039 RVA: 0x0011B04C File Offset: 0x0011A04C
		private void a(int A_0, mt A_1)
		{
			if (A_1 != null && A_1.c() != null)
			{
				ms ms = A_1.c().a();
				if (ms != null)
				{
					mr mr = ms.l().a();
					while (mr != null && mr.b() != null)
					{
						if (((n5)mr.b().db()).z() > A_0)
						{
							((n5)mr.b().db()).b(A_0);
						}
						mr = mr.c();
					}
				}
			}
		}

		// Token: 0x06001B80 RID: 7040 RVA: 0x0011B0EC File Offset: 0x0011A0EC
		private void c(mt A_0)
		{
			int num = 0;
			if (A_0 != null && A_0.c() != null)
			{
				ms ms = A_0.c().a();
				if (ms != null)
				{
					int num2 = ms.l().c();
					mr mr = ms.l().a();
					int num3 = 0;
					while (mr != null && mr.b() != null)
					{
						int num4 = ((n5)mr.b().db()).y();
						if (num + num4 < this.e)
						{
							num += num4;
						}
						else
						{
							num4 = this.a(num);
							((n5)mr.b().db()).a(num4);
							num += num4;
						}
						mr = mr.c();
						num3++;
					}
				}
			}
		}

		// Token: 0x06001B81 RID: 7041 RVA: 0x0011B1D8 File Offset: 0x0011A1D8
		private int a(int A_0)
		{
			int num;
			if (A_0 != 0)
			{
				num = this.e - A_0;
			}
			else
			{
				num = this.e - 1;
			}
			int result;
			if (num == 0)
			{
				result = 1;
			}
			else
			{
				result = num;
			}
			return result;
		}

		// Token: 0x06001B82 RID: 7042 RVA: 0x0011B218 File Offset: 0x0011A218
		private int b(mt A_0)
		{
			int num = 0;
			if (A_0 != null)
			{
				mu mu = A_0.c();
				while (mu != null && mu.a() != null)
				{
					mr mr = mu.a().l().a();
					while (mr != null && mr.b() != null)
					{
						k0 k = (k0)mr.b();
						int num2 = k.dg();
						if (num2 == 3034 || num2 == 3418)
						{
							int num3 = ((n5)mr.b().db()).y();
							num += num3;
						}
						mr = mr.c();
					}
					mu = mu.b();
				}
			}
			return num;
		}

		// Token: 0x06001B83 RID: 7043 RVA: 0x0011B2EC File Offset: 0x0011A2EC
		private int a(mt A_0)
		{
			int num = 0;
			if (A_0 != null)
			{
				mu mu = A_0.c();
				while (mu != null && mu.a() != null)
				{
					mr mr = mu.a().l().a();
					while (mr != null && mr.b() != null)
					{
						k0 k = (k0)mr.b();
						int num2 = k.dg();
						if (num2 <= 442866842)
						{
							if (num2 != 1946)
							{
								if (num2 == 442866842)
								{
									goto IL_77;
								}
							}
							else
							{
								num++;
							}
						}
						else if (num2 == 718642778 || num2 == 889490394)
						{
							goto IL_77;
						}
						IL_9C:
						mr = mr.c();
						continue;
						IL_77:
						if (k.n() != null)
						{
							num += k.n().f();
						}
						goto IL_9C;
					}
					mu = mu.b();
				}
			}
			return num;
		}

		// Token: 0x06001B84 RID: 7044 RVA: 0x0011B3E8 File Offset: 0x0011A3E8
		private void a(lo A_0, io A_1)
		{
			switch (A_1)
			{
			case io.a:
			case io.c:
			case io.d:
			case io.e:
				A_0.dv().a(io.a);
				break;
			case io.b:
				A_0.dv().a(io.b);
				break;
			}
		}

		// Token: 0x06001B85 RID: 7045 RVA: 0x0011B434 File Offset: 0x0011A434
		private List<kz> a(ij A_0, nv A_1)
		{
			il a_ = A_1.dv().h();
			List<kz> list = new List<kz>();
			kz kz = null;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			if (this.cg() != null && this.cg().h() > 0)
			{
				for (int i = 0; i < this.cg().h(); i++)
				{
					switch (this.cg().b(i).cr())
					{
					case fa.c:
					case fa.d:
						((er)this.cg().b(i)).c(base.e());
						if (num == 0)
						{
							A_0.a(a_);
						}
						num++;
						if (this.cg().b(i).cr() == fa.c)
						{
							((e3)this.cg().b(i)).a(num3);
							kz = this.cg().b(i).cm(A_0, A_1);
							list.Add(kz);
						}
						else
						{
							((e5)this.cg().b(i)).a(num2);
							((e5)this.cg().b(i)).e(num3);
							kz = this.cg().b(i).cm(A_0, A_1);
							if (((e5)this.cg().b(i)).b().Count > 0)
							{
								foreach (kz kz2 in ((e5)this.cg().b(i)).b())
								{
									nu item = (nu)kz2;
									list.Add(item);
								}
							}
							else
							{
								list.Add(kz);
							}
							num2++;
						}
						if (this.cg().b(i).cr() == fa.c)
						{
							num3 += ((n5)kz.db()).y();
						}
						else
						{
							num3 = ((e5)this.cg().b(i)).c();
						}
						break;
					}
				}
			}
			if (num == 0)
			{
				A_0.a(a_);
			}
			return list;
		}

		// Token: 0x06001B86 RID: 7046 RVA: 0x0011B6CC File Offset: 0x0011A6CC
		private void a(nv A_0)
		{
			int num = this.a(A_0.n());
			ny ny = new ny(A_0, num);
			if (num > 0)
			{
				int num2 = 0;
				this.a(A_0.n(), ny, ref num2);
			}
			ny.i();
			if (A_0.dv().c() != pz.a || A_0.dv().h() == il.b)
			{
				ny.l();
			}
			A_0.a(ny);
		}

		// Token: 0x06001B87 RID: 7047 RVA: 0x0011B74C File Offset: 0x0011A74C
		private void a(mt A_0, ny A_1, ref int A_2)
		{
			if (A_0 != null)
			{
				mu mu = A_0.c();
				while (mu != null && mu.a() != null)
				{
					if (mu.a().l() != null && mu.a().l().a().b() != null)
					{
						k0 k = (k0)mu.a().l().a().b();
						int num = k.dg();
						if (num <= 442866842)
						{
							if (num != 1946)
							{
								if (num == 442866842)
								{
									goto IL_96;
								}
							}
							else
							{
								A_1.a((nx)k, A_2, this.e);
								A_2++;
							}
						}
						else if (num == 718642778 || num == 889490394)
						{
							goto IL_96;
						}
						goto IL_C5;
						IL_96:
						this.a(k.n(), A_1, ref A_2);
					}
					IL_C5:
					mu = mu.b();
				}
			}
		}

		// Token: 0x06001B88 RID: 7048 RVA: 0x0011B844 File Offset: 0x0011A844
		private int a(mt A_0, int A_1)
		{
			if (A_0 != null)
			{
				mu mu = A_0.c();
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
									goto IL_74;
								}
							}
							else
							{
								mr.b().d2(A_1);
								A_1++;
							}
						}
						else if (num == 718642778 || num == 889490394)
						{
							goto IL_74;
						}
						IL_A3:
						mr = mr.c();
						continue;
						IL_74:
						A_1 = this.a(((k0)mr.b()).n(), A_1);
						goto IL_A3;
					}
					mu = mu.b();
				}
			}
			return A_1;
		}

		// Token: 0x06001B89 RID: 7049 RVA: 0x0011B944 File Offset: 0x0011A944
		private void a(ij A_0)
		{
			int num = 0;
			fe fe = null;
			ja ja = null;
			if (this.a.a() != null || this.a.c() != null)
			{
				fb<fs>[] a_ = new fb<fs>[]
				{
					new fb<fs>(510035525, new afu(this.a.a())),
					new fb<fs>(137106767, new afv(this.a.c())),
					new fb<fs>(19010090, new afx(gl.a)),
					new fb<fs>(808234079, new aft(fq.c)),
					new fb<fs>(440052479, new afw(fr.a, x5.c(), i2.d, x5.c(), i2.d))
				};
				fe = new fe();
				fe.a(a_);
				num++;
			}
			if (this.a.h().a().a() != 0f)
			{
				f9 a_2 = new f9(m4.a(this.a.h()));
				ja = new ja();
				ja.a(a_2);
				if (this.a.h().a().b() == i2.b)
				{
					ja.a().a(true);
				}
				else
				{
					ja.a().a(false);
				}
				num++;
			}
			if (num > 0)
			{
				fc[] array = new fc[num];
				int num2 = 0;
				if (fe != null)
				{
					array[num2] = new fc(1617181893, fe);
					num2++;
				}
				if (ja != null)
				{
					array[num2] = new fc(795562982, ja);
					num2++;
				}
				ig a_3 = new ig(array);
				A_0.a(this.ch().cn(), a_3);
				A_0.a(true);
			}
		}

		// Token: 0x06001B8A RID: 7050 RVA: 0x0011BB68 File Offset: 0x0011AB68
		private void a(ij A_0, nv A_1, bool A_2)
		{
			nw nw = A_1.dv();
			lk lk = A_1.c5();
			if (nw.h() == il.b)
			{
				nw.a(new x5?(x5.c()));
				nw.b(new x5?(x5.c()));
			}
			if (this.a.g() == null && nw.h() != il.b)
			{
				if (!nw.g())
				{
					nw.a(new x5?(x5.a((float)this.a.e() * 0.75f)));
					nw.b(new x5?(x5.a((float)this.a.e() * 0.75f)));
				}
			}
			else
			{
				nw.a(new x5?(x5.c()));
				nw.b(new x5?(x5.c()));
				nw.b(true);
				string text = this.a.g();
				if (text != null)
				{
					if (text == "groups")
					{
						nw.a(pz.b);
						goto IL_16A;
					}
					if (text == "rows")
					{
						nw.a(pz.c);
						goto IL_16A;
					}
					if (text == "cols")
					{
						nw.a(pz.d);
						goto IL_16A;
					}
					if (text == "all")
					{
						nw.a(pz.e);
						goto IL_16A;
					}
				}
				nw.a(pz.a);
				IL_16A:;
			}
			if (!lk.m())
			{
				switch (this.a.i())
				{
				case gn.a:
					lk.a(g3.a);
					break;
				case gn.b:
					lk.a(g3.b);
					break;
				case gn.c:
					((n5)A_1.db()).a(gn.c);
					break;
				}
			}
			if (this.a.b() != -2147483648 && lk.az() != g9.b)
			{
				this.c = this.a(false);
			}
			fg fg = this.a(true);
			if (!lk.d() && (this.a.b() != -2147483648 || this.a.f() != null))
			{
				lf lf = new lf();
				if (this.a.f() != null)
				{
					string text = this.a.f();
					switch (text)
					{
					case "void":
						nw.a(py.a);
						fg.a()[1].a(new fw(x5.c()));
						fg.a()[3].a(new fw(x5.c()));
						fg.a()[5].a(new fw(x5.c()));
						fg.a()[7].a(new fw(x5.c()));
						goto IL_5B9;
					case "above":
						fg.a()[3].a(new fw(x5.c()));
						fg.a()[5].a(new fw(x5.c()));
						fg.a()[7].a(new fw(x5.c()));
						nw.a(py.b);
						goto IL_5B9;
					case "below":
						fg.a()[1].a(new fw(x5.c()));
						fg.a()[3].a(new fw(x5.c()));
						fg.a()[7].a(new fw(x5.c()));
						nw.a(py.c);
						goto IL_5B9;
					case "hsides":
						fg.a()[3].a(new fw(x5.c()));
						fg.a()[7].a(new fw(x5.c()));
						nw.a(py.d);
						goto IL_5B9;
					case "lhs":
						fg.a()[1].a(new fw(x5.c()));
						fg.a()[3].a(new fw(x5.c()));
						fg.a()[5].a(new fw(x5.c()));
						nw.a(py.e);
						goto IL_5B9;
					case "rhs":
						fg.a()[1].a(new fw(x5.c()));
						fg.a()[5].a(new fw(x5.c()));
						fg.a()[7].a(new fw(x5.c()));
						nw.a(py.f);
						goto IL_5B9;
					case "vsides":
						fg.a()[1].a(new fw(x5.c()));
						fg.a()[5].a(new fw(x5.c()));
						nw.a(py.g);
						goto IL_5B9;
					case "box":
						nw.a(py.h);
						goto IL_5B9;
					}
					nw.a(py.i);
					IL_5B9:
					nw.a(true);
				}
				lf.a(fg.a());
				lk.a(lf);
			}
			this.d = new hx();
			ge ge = new ge(m4.a(this.a.d()));
			ge.a(this.a.d().a().b());
			this.d.a()[0] = new fb<ge>(136794, ge);
			this.d.a()[1] = new fb<ge>(426354259, ge);
			this.d.a()[2] = new fb<ge>(7021096, ge);
			this.d.a()[3] = new fb<ge>(448574430, ge);
			if (!lk.g() && this.a.d().a().a() != 0f)
			{
				m8 m = new m8();
				m.a(this.d.a());
				m.c(false);
				m.d(false);
				m.a(false);
				m.b(false);
				lk.b(false);
				lk.a(m);
			}
			i3.a(A_1);
			i3.a(A_1, A_0);
			n5 n = (n5)A_1.db();
			m4.a(n, lk, A_2);
			if (A_1.j() && lk.ay().e() != null)
			{
				A_1.b(mg.a(A_0, lk.ay().e(), A_0.e()));
			}
			else if (this.a.c() != null)
			{
				A_1.b(mg.a(A_0, this.a.c(), A_0.e()));
			}
			if (n.r() == gn.e)
			{
				it it = new it();
				it.a(new iu(gn.a));
				ig a_ = new ig(new fc[]
				{
					new fc(1982903832, it)
				});
				A_0.a(this.ch().cn(), a_);
				A_0.a(true);
			}
		}

		// Token: 0x06001B8B RID: 7051 RVA: 0x0011C3A8 File Offset: 0x0011B3A8
		private fg a(bool A_0)
		{
			fg fg = new fg();
			fv a_ = new fv(ft.h);
			fw fw;
			if (A_0 && this.a.b() != -2147483648)
			{
				fw = new fw(x5.a((float)this.a.b() * 0.75f));
			}
			else if (this.a.b() != 0)
			{
				fw = new fw(x5.a(0.75f));
			}
			else
			{
				fw = new fw(x5.c());
			}
			fw.a(i2.d);
			fg.a()[0] = new fb<fu>(548864878, a_);
			fg.a()[1] = new fb<fu>(663309508, fw);
			fg.a()[2] = new fb<fu>(1274012590, a_);
			fg.a()[3] = new fb<fu>(789921929, fw);
			fg.a()[4] = new fb<fu>(1304279675, a_);
			fg.a()[5] = new fb<fu>(1930785673, fw);
			fg.a()[6] = new fb<fu>(758017896, a_);
			fg.a()[7] = new fb<fu>(1656587748, fw);
			return fg;
		}

		// Token: 0x06001B8C RID: 7052 RVA: 0x0011C524 File Offset: 0x0011B524
		internal override kz cm(ij A_0, kz A_1)
		{
			nv nv = new nv();
			this.a(A_0);
			A_0.c(this.ch());
			A_0.a(nv);
			n5 n = (n5)nv.db();
			nv.c5().c().i(n.j());
			A_0.b(nv);
			A_0.a(false);
			bool flag = true;
			bool flag2 = false;
			if (nv.c5().u())
			{
				g2? g = nv.c5().t();
				g2 valueOrDefault = g.GetValueOrDefault();
				if (g != null)
				{
					switch (valueOrDefault)
					{
					case g2.a:
						flag = false;
						nv = null;
						break;
					case g2.c:
						flag2 = true;
						break;
					}
				}
			}
			if (flag)
			{
				A_0.c(nv);
				A_0.a(true);
				if (!flag2)
				{
					nv.df(true);
				}
				nv.j(A_1);
				nv.aa(A_1.ch());
				if (nv.ch())
				{
					nv.ab(A_1.ci());
					nv.az(A_1.cl());
					nv.ay(A_1.ck());
				}
				this.a(A_0, nv, flag2);
				g2? g = nv.c5().t();
				if (g == g2.c)
				{
					this.f = false;
					nv.df(false);
				}
				mt mt = null;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int a_ = 0;
				List<kz> list = new List<kz>();
				base.c(A_0.a().Count);
				List<kz> list2 = this.a(A_0, nv);
				if (list2.Count > 0)
				{
					nv.a(list2);
				}
				bool flag3 = false;
				n7 n2 = null;
				base.d(nv);
				if (!nv.c5().az().Equals(g9.c))
				{
					if (this.cg() != null && this.cg().h() > 0)
					{
						for (int i = 0; i < this.cg().h(); i++)
						{
							er er = (er)this.cg().b(i);
							if (er != null && !er.d())
							{
								er.a(this.c);
								er.a(this.d);
								er.c(base.e());
								er.a(nv.dv());
								er.d(a_);
								kz kz = er.cm(A_0, nv);
								if (kz != null)
								{
									kz.j(nv);
									a_ = ((er)this.cg().b(i)).h();
									if (kz.dg() == 889490394 && num3 == 0)
									{
										n2 = (n7)kz;
										num3++;
									}
									else if (kz.dg() == 442866842 && num == 0)
									{
										nv.a((n6)kz);
										num++;
									}
									else
									{
										int num4 = kz.dg();
										if (num4 != 165445)
										{
											if (num4 != 258605815)
											{
												if (num4 != 506116087)
												{
													ms a_2 = new ms(kz);
													if (mt == null)
													{
														mt = new mt(a_2);
													}
													else
													{
														mt.c(a_2);
													}
												}
											}
											else
											{
												list.Add((lo)kz);
												num2++;
											}
										}
									}
								}
							}
						}
						if (num > 0)
						{
							if (mt == null)
							{
								mt = new mt(new ms(nv.e()));
							}
							else
							{
								mt.c(new ms(nv.e()));
								flag3 = true;
							}
						}
						if (num3 > 0)
						{
							nv.a((n7)n2.k(true));
							if (mt == null)
							{
								mt = new mt(new ms(n2));
							}
							else
							{
								mt.d(new ms(n2));
								flag3 = true;
							}
						}
						if (num2 > 0)
						{
							int i = 0;
							while (i < list.Count)
							{
								if (((lo)list[i]).dv().k() == io.e)
								{
									this.a((lo)list[i], nv.dv().k());
								}
								switch (((lo)list[i]).dv().k())
								{
								case io.a:
								case io.c:
								case io.d:
									goto IL_552;
								case io.b:
									if (mt == null)
									{
										mt = new mt(new ms((lo)list[i]));
									}
									else
									{
										mt.c(new ms((lo)list[i]));
									}
									break;
								default:
									goto IL_552;
								}
								IL_599:
								i++;
								continue;
								IL_552:
								if (mt == null)
								{
									mt = new mt(new ms((lo)list[i]));
								}
								else
								{
									mt.d(new ms((lo)list[i]));
								}
								goto IL_599;
							}
						}
						nv.c(mt);
						if (mt != null)
						{
							this.e = base.e(mt);
							this.d(mt);
							if (flag3)
							{
								this.a(mt, 0);
							}
							base.f(mt);
						}
					}
					if (nv.n() != null)
					{
						this.a(nv);
					}
					if (nv.ch() || A_1.ch())
					{
						nv.aa(true);
						if (nv.ci())
						{
							nv.dh();
							nv.di();
						}
						else
						{
							nv.di();
							nv.a8(nv.dn());
						}
					}
					else
					{
						nv.dh();
						nv.di();
					}
					if (n2 != null)
					{
						nv.c().q(n2.dk());
						nv.c().a8(n2.dp());
						nv.c().a7(n2.dn());
					}
				}
				else
				{
					nv = null;
				}
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			if (A_0.a().Count > 0)
			{
				A_0.a()[A_0.a().Count - 1] = null;
			}
			return nv;
		}

		// Token: 0x06001B8D RID: 7053 RVA: 0x0011CC98 File Offset: 0x0011BC98
		internal void d(mt A_0)
		{
			if (A_0 != null)
			{
				mu mu = A_0.c();
				while (mu != null && mu.a() != null)
				{
					mr mr = mu.a().l().a();
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
									goto IL_78;
								}
							}
							else
							{
								int num2 = this.b(k.n());
								if (num2 > this.e)
								{
									this.c(k.n());
								}
							}
						}
						else if (num == 718642778 || num == 889490394)
						{
							goto IL_78;
						}
						IL_B5:
						mr = mr.c();
						continue;
						IL_78:
						this.d(k.n());
						goto IL_B5;
					}
					mu = mu.b();
				}
			}
		}

		// Token: 0x04000C63 RID: 3171
		private new p0 a = null;

		// Token: 0x04000C64 RID: 3172
		private px b = null;

		// Token: 0x04000C65 RID: 3173
		private fg c = null;

		// Token: 0x04000C66 RID: 3174
		private new hx d = null;

		// Token: 0x04000C67 RID: 3175
		private new int e = 0;

		// Token: 0x04000C68 RID: 3176
		private new bool f = true;
	}
}
