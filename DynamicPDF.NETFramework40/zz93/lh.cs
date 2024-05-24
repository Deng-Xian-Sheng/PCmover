using System;
using System.Collections;
using System.Collections.Generic;

namespace zz93
{
	// Token: 0x020001BD RID: 445
	internal class lh
	{
		// Token: 0x06001205 RID: 4613 RVA: 0x000CC374 File Offset: 0x000CB374
		internal lh(nv A_0, ny A_1)
		{
			this.a = A_0.b6();
			this.i = A_0.h();
			this.b = A_1.k();
			this.h = A_1.e();
			this.j = A_0.i();
			List<int> list = new List<int>(this.i.Keys);
			if (list.Count > 0)
			{
				this.k = this.j + list[list.Count - 1];
				if (this.j != 0)
				{
					this.l = new kz[this.h[this.j].Length];
					this.a(A_0.n().c());
				}
				this.d(A_0);
			}
		}

		// Token: 0x06001206 RID: 4614 RVA: 0x000CC468 File Offset: 0x000CB468
		internal List<lg> k()
		{
			return this.c;
		}

		// Token: 0x06001207 RID: 4615 RVA: 0x000CC480 File Offset: 0x000CB480
		internal List<lg> l()
		{
			return this.d;
		}

		// Token: 0x06001208 RID: 4616 RVA: 0x000CC498 File Offset: 0x000CB498
		internal List<lg> m()
		{
			return this.e;
		}

		// Token: 0x06001209 RID: 4617 RVA: 0x000CC4B0 File Offset: 0x000CB4B0
		internal List<lg> n()
		{
			return this.f;
		}

		// Token: 0x0600120A RID: 4618 RVA: 0x000CC4C8 File Offset: 0x000CB4C8
		internal List<lg> o()
		{
			return this.g;
		}

		// Token: 0x0600120B RID: 4619 RVA: 0x000CC4E0 File Offset: 0x000CB4E0
		internal kz[][] p()
		{
			return this.h;
		}

		// Token: 0x0600120C RID: 4620 RVA: 0x000CC4F8 File Offset: 0x000CB4F8
		private void a(mu A_0)
		{
			if (A_0 != null)
			{
				ms ms = A_0.a();
				if (ms != null && ms.l() != null)
				{
					for (mr mr = ms.l().a(); mr != null; mr = mr.c())
					{
						int num = mr.b().dg();
						if (num <= 3418)
						{
							if (num == 1946)
							{
								goto IL_90;
							}
							if (num != 3034 && num != 3418)
							{
								goto IL_F1;
							}
							int num2 = ((nt)mr.b()).h();
							this.l[num2] = mr.b();
							mr = mr.c();
						}
						else
						{
							if (num != 442866842 && num != 718642778 && num != 889490394)
							{
								goto IL_F1;
							}
							goto IL_90;
						}
						continue;
						IL_90:
						if (((k0)mr.b()).n() != null)
						{
							this.a(((k0)mr.b()).n().c());
						}
						mr = null;
						continue;
						IL_F1:;
					}
				}
				else
				{
					this.l = this.h[this.j];
				}
			}
			else
			{
				this.l = this.h[this.j];
			}
		}

		// Token: 0x0600120D RID: 4621 RVA: 0x000CC63C File Offset: 0x000CB63C
		private void d(nv A_0)
		{
			this.c = new List<lg>();
			this.i();
			this.g();
			this.d = new List<lg>();
			this.h();
			this.e = new List<lg>();
			this.c(A_0);
			this.f = new List<lg>();
			this.a(A_0);
			this.f();
			this.j();
		}

		// Token: 0x0600120E RID: 4622 RVA: 0x000CC6AC File Offset: 0x000CB6AC
		private void j()
		{
			x5 a_ = x5.c();
			for (int i = 0; i < this.h.Length; i++)
			{
				a_ = x5.c();
				for (int j = 0; j < this.b - 1; j++)
				{
					nt nt = (nt)this.h[i][j];
					x5 a_2 = x5.c();
					if (nt != null)
					{
						if (nt.dr() != null)
						{
							a_2 = ((k0)nt.dr()).ab();
						}
						lg lg = new lg();
						lg.a(i);
						lg.d(j);
						lg.h(nt.ar());
						if (nt.h() == j && ((n5)nt.db()).y() == 1)
						{
							lg lg2 = lg;
							lg2.h(x5.e(lg2.h(), nt.c5().c().v()));
							lg lg3 = lg;
							lg3.h(x5.e(lg3.h(), nt.c5().c().y()));
						}
						else
						{
							if (i - 1 >= 0 && this.h[i - 1][j] != null)
							{
								lg lg4 = lg;
								lg4.h(x5.e(lg4.h(), this.h[i - 1][j].c5().c().y()));
							}
							else
							{
								lg lg5 = lg;
								lg5.h(x5.e(lg5.h(), nt.c5().c().v()));
							}
							if (i + 1 < this.h.Length)
							{
								lg lg6 = lg;
								lg6.h(x5.e(lg6.h(), this.h[i + 1][j].c5().c().v()));
							}
							else
							{
								lg lg7 = lg;
								lg7.h(x5.e(lg7.h(), nt.c5().c().y()));
							}
						}
						lg lg8 = lg;
						lg8.h(x5.f(lg8.h(), a_2));
						if (((n5)nt.db()).z() > 1)
						{
							lg.h(a_);
						}
						else
						{
							a_ = lg.h();
						}
						this.g.Add(lg);
					}
				}
			}
		}

		// Token: 0x0600120F RID: 4623 RVA: 0x000CC91C File Offset: 0x000CB91C
		private kz[] b(int A_0)
		{
			kz[] result;
			if (A_0 == this.j && this.j != 0)
			{
				result = this.l;
			}
			else
			{
				result = this.h[A_0];
			}
			return result;
		}

		// Token: 0x06001210 RID: 4624 RVA: 0x000CC95C File Offset: 0x000CB95C
		private void i()
		{
			int num = 1;
			for (int i = this.j; i <= this.k; i++)
			{
				if (this.i.ContainsKey(i))
				{
					int j = 0;
					while (j < this.b - 1)
					{
						nt nt = (nt)this.h[i][j];
						if (nt != null)
						{
							if (nt.h() == j)
							{
								num = ((n5)nt.db()).y();
								nt nt2;
								if (j + num < this.b)
								{
									nt2 = (nt)this.h[i][j + num];
								}
								else
								{
									nt2 = (nt)this.h[i][this.b - 1];
								}
								if (nt.h() + num < this.b)
								{
									int num2 = ((n5)nt.db()).z();
									lg lg = new lg();
									lg.d(nt.h() + num - 1);
									lg.c(nt.h());
									lg.g(nt.j());
									lg.f(num);
									for (int k = nt.h(); k < num + nt.h(); k++)
									{
										lg lg2 = lg;
										lg2.f(x5.f(lg2.f(), (x5)this.a[k]));
									}
									if (nt2 != null)
									{
										int num3 = ((n5)nt2.db()).z();
										if (num2 == 1)
										{
											this.d(lg, nt, num2, i);
										}
										else if (num3 == 1)
										{
											this.c(lg, nt2, num3, i);
										}
										else if (num2 + nt.d1() - 1 < num3 + nt2.d1() - 1)
										{
											this.d(lg, nt, num2, i);
										}
										else
										{
											this.c(lg, nt2, num3, i);
										}
										this.a(nt, nt2, lg, i);
									}
									else
									{
										this.d(lg, nt, num2, i);
										lg lg3 = lg;
										lg3.h(x5.f(lg3.h(), x5.f(nt.c5().c().y(), nt.c5().c().y())));
										lg.e(nt.c5().c().y());
										lg lg4 = lg;
										lg4.h(x5.f(lg4.h(), x5.f(nt.c5().c().v(), nt.c5().c().v())));
										lg.d(nt.c5().c().v());
									}
									if (num >= 1 && !nt.b5())
									{
										this.c.Add(lg);
									}
									else if (num2 > 1)
									{
										this.c.Add(lg);
									}
								}
							}
							j += num;
						}
						else
						{
							j++;
						}
					}
				}
			}
			this.b();
		}

		// Token: 0x06001211 RID: 4625 RVA: 0x000CCCC8 File Offset: 0x000CBCC8
		private void h()
		{
			for (int i = 0; i < this.b; i++)
			{
				for (int j = this.j; j < this.k; j++)
				{
					if (this.i.ContainsKey(j))
					{
						nt nt = (nt)this.h[j][i];
						if (nt != null && !nt.b5())
						{
							int num = ((n5)nt.db()).z();
							if (nt.d1() == j && nt.d1() + num < this.h.Length)
							{
								nt nt2 = (nt)this.h[j + 1][i];
								if (nt2 != null)
								{
									int num2 = ((n5)nt.db()).y();
									if (nt.h() == i || nt2.h() == i)
									{
										lg lg = new lg();
										lg.g(nt.j());
										lg.a(nt.d1() + num - 1);
										lg.h(this.i[j]);
										if (nt2 != null && !nt2.b5())
										{
											int num3 = ((n5)nt2.db()).y();
											bool a_ = true;
											if (num2 == 1)
											{
												this.b(lg, nt, num2, i);
											}
											else if (num3 == 1)
											{
												lg.f(num3);
												this.a(lg, nt2, num3, i);
												a_ = false;
											}
											else if (num2 + nt.h() - 1 < num3 + nt2.h() - 1)
											{
												lg.f(num2 + nt.h() - i);
												this.b(lg, nt, num2 + nt.h() - i, i);
											}
											else
											{
												lg.f(num3 + nt2.h() - i);
												this.a(lg, nt2, num3 + nt2.h() - i, i);
												a_ = false;
											}
											this.a(lg, nt, nt2, i, a_);
										}
										else
										{
											this.b(lg, nt, num2, i);
											this.a(lg, nt, i);
										}
										this.d.Add(lg);
									}
								}
							}
						}
						else if (this.i.ContainsKey(j + 1))
						{
							nt nt2 = (nt)this.h[j + 1][i];
							if (nt2 != null && !nt2.b5())
							{
								int num2 = ((n5)nt2.db()).y();
								lg lg = new lg();
								lg.g(nt2.j());
								lg.a(j);
								lg.f(num2);
								lg.h(this.a(j, this.d));
								this.a(lg, nt2, num2, i);
								if (x5.h(lg.a(), x5.c()) && x5.g(nt2.c5().c().f(), x5.c()))
								{
									lg.a(nt2.c5().c().f());
								}
								if (lg.p() == ft.a && nt2.c5().c().g() != ft.a)
								{
									lg.a(nt2.c5().c().g());
								}
								lg.a(nt2.c5().c().e());
								this.b(lg, nt2, i);
								this.d.Add(lg);
							}
						}
					}
				}
			}
			this.a();
		}

		// Token: 0x06001212 RID: 4626 RVA: 0x000CD0E4 File Offset: 0x000CC0E4
		private void g()
		{
			for (int i = 0; i < this.c.Count; i++)
			{
				if (this.c[i] != null)
				{
					for (int j = i + 1; j < this.c.Count; j++)
					{
						if (this.c[j] != null)
						{
							if (this.c[i].l() == this.c[j].l() && this.c[i].i() + this.c[i].m() + this.c[i].r() == this.c[j].i())
							{
								if (this.c[i].o() != null)
								{
									if (x5.h(this.c[i].a(), this.c[j].a()) && this.c[i].o().Equals(this.c[j].o()) && this.c[i].p() == this.c[j].p())
									{
										lg lg = this.c[i];
										lg.h(x5.f(lg.h(), this.c[j].h()));
										lg lg2 = this.c[i];
										lg2.g(lg2.r() + this.c[j].m());
										this.c.RemoveAt(j);
										j--;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06001213 RID: 4627 RVA: 0x000CD2F0 File Offset: 0x000CC2F0
		private void f()
		{
			x5 a_ = x5.c();
			if (this.h[0][0] != null)
			{
				a_ = x5.f(a_, this.h[0][0].c5().c().ab());
			}
			for (int i = 0; i < this.d.Count; i++)
			{
				if (this.d[i] != null)
				{
					bool flag = false;
					for (int j = i + 1; j < this.d.Count; j++)
					{
						if (this.d[j] != null)
						{
							if (this.d[i].l() + this.d[i].n() == this.d[j].l() && this.d[i].i() == this.d[j].i())
							{
								if (this.d[i].o() != null)
								{
									if (x5.h(this.d[i].a(), this.d[j].a()) && this.d[i].o().Equals(this.d[j].o()) && this.d[i].p() == this.d[j].p())
									{
										lg lg = this.d[i];
										lg.f(x5.f(lg.f(), this.d[j].f()));
										this.d[i].g(this.d[i].n() + this.d[j].n() - 1);
										lg lg2 = this.d[i];
										lg2.f(lg2.n() + this.d[j].n());
										flag = true;
										this.d.RemoveAt(j);
										j--;
									}
								}
							}
						}
					}
					if (!flag)
					{
						this.d[i].g(this.d[i].n() - 1);
					}
				}
			}
		}

		// Token: 0x06001214 RID: 4628 RVA: 0x000CD59C File Offset: 0x000CC59C
		private void c(nv A_0)
		{
			this.e();
			this.b(A_0);
			int num = this.j;
			for (int i = 0; i < this.e.Count; i++)
			{
				num = this.e[i].i();
				if (num != -1)
				{
					int num2 = this.e[i].l();
					for (int j = i + 1; j < this.e.Count; j++)
					{
						if (this.e[j].i() > num)
						{
							if (num + this.e[i].m() == this.e[j].i() && this.e[j].l() == num2)
							{
								if (x5.d(this.e[i].a(), this.e[j].a()))
								{
									lg lg = this.e[i];
									lg.h(x5.e(lg.h(), x5.f(this.e[i].e(), this.e[i].e())));
								}
								else if (x5.c(this.e[i].a(), this.e[j].a()))
								{
									lg lg2 = this.e[j];
									lg2.h(x5.e(lg2.h(), x5.f(this.e[j].d(), this.e[j].d())));
								}
								else if (this.e[i].s())
								{
									lg lg3 = this.e[i];
									lg3.h(x5.e(lg3.h(), x5.f(this.e[i].e(), this.e[i].e())));
								}
								else if (this.e[j].s())
								{
									lg lg4 = this.e[j];
									lg4.h(x5.e(lg4.h(), x5.f(this.e[j].d(), this.e[j].d())));
								}
								else
								{
									lg lg5 = this.e[i];
									lg5.h(x5.e(lg5.h(), x5.f(this.e[i].e(), this.e[i].e())));
								}
							}
						}
					}
				}
			}
			this.d();
		}

		// Token: 0x06001215 RID: 4629 RVA: 0x000CD8B4 File Offset: 0x000CC8B4
		private void e()
		{
			int num = 0;
			int i = this.j;
			int num2 = 0;
			while (i <= this.k)
			{
				if (this.i.ContainsKey(i))
				{
					nt nt = (nt)this.h[i][num];
					if (nt != null)
					{
						int num3 = ((n5)nt.db()).z();
						lg lg = new lg();
						lg.e(num3);
						lg.d(num);
						int num4 = ((n5)nt.db()).y();
						this.c(lg, nt, num3, i);
						if (num4 == 1 || i - 1 < 0 || nt.h() + num4 < ((nt)this.h[i - 1][num]).h() + ((n5)this.h[i - 1][num].db()).y())
						{
							lg lg2 = lg;
							lg2.h(x5.f(lg2.h(), nt.c5().c().v()));
							lg.d(nt.c5().c().v());
						}
						else
						{
							lg lg3 = lg;
							lg3.h(x5.f(lg3.h(), this.h[i - 1][num].c5().c().y()));
							lg.d(this.h[i - 1][num].c5().c().y());
						}
						if (num4 == 1 || i + 1 >= this.h.Length || nt.h() + num4 < ((nt)this.h[i + 1][num]).h() + ((n5)this.h[i + 1][num].db()).y())
						{
							lg lg4 = lg;
							lg4.h(x5.f(lg4.h(), nt.c5().c().y()));
							lg.e(nt.c5().c().y());
						}
						else
						{
							lg lg5 = lg;
							lg5.h(x5.f(lg5.h(), this.h[i + 1][num].c5().c().v()));
							lg.e(this.h[i + 1][num].c5().c().v());
						}
						if (x5.h(nt.c5().c().ab(), x5.a(x5.b(nt.c5().c().n()) / 2f)) && nt.c5().c().o() == nt.c5().c().ac() && nt.c5().c().m() == nt.c5().c().aa())
						{
							lg.b(false);
						}
						else
						{
							lg.b(true);
						}
						this.e.Add(lg);
						if (i == nt.d1())
						{
							i += num3;
						}
						else
						{
							i = nt.d1() + num3;
						}
						num2++;
						if (num2 >= this.i.Count)
						{
							break;
						}
					}
					else
					{
						i++;
					}
				}
				else
				{
					i++;
				}
			}
		}

		// Token: 0x06001216 RID: 4630 RVA: 0x000CDC44 File Offset: 0x000CCC44
		private void b(nv A_0)
		{
			int i = this.j;
			int num = this.b - 1;
			int num2 = 0;
			i = this.j;
			while (i <= this.k)
			{
				if (this.i.ContainsKey(i))
				{
					nt nt = (nt)this.h[i][num];
					lg lg = new lg();
					lg.d(num);
					if (nt != null)
					{
						int num3 = ((n5)nt.db()).z();
						lg.e(num3);
						int num4 = ((n5)nt.db()).y();
						this.d(lg, nt, num3, i);
						if (i - 1 >= 0 && this.h[i - 1][num] != null)
						{
							if (num4 == 1 || i - 1 < 0 || nt.h() > ((nt)this.h[i - 1][num]).h())
							{
								lg lg2 = lg;
								lg2.h(x5.f(lg2.h(), nt.c5().c().v()));
								lg.d(nt.c5().c().v());
							}
							else
							{
								lg lg3 = lg;
								lg3.h(x5.f(lg3.h(), this.h[i - 1][num].c5().c().y()));
								lg.d(this.h[i - 1][num].c5().c().y());
							}
						}
						else if (i == 0 && this.h[i][num] != null)
						{
							lg lg4 = lg;
							lg4.h(x5.f(lg4.h(), this.h[i][num].c5().c().y()));
							lg.d(this.h[i][num].c5().c().y());
						}
						if (i + 1 < this.h.Length && this.h[i + 1][num] != null)
						{
							if (num4 == 1 || i + 1 >= this.h.Length || nt.h() > ((nt)this.h[i + 1][num]).h())
							{
								lg lg5 = lg;
								lg5.h(x5.f(lg5.h(), nt.c5().c().y()));
								lg.e(nt.c5().c().y());
							}
							else
							{
								lg lg6 = lg;
								lg6.h(x5.f(lg6.h(), this.h[i + 1][num].c5().c().v()));
								lg.e(this.h[i + 1][num].c5().c().v());
							}
						}
						if (x5.h(nt.c5().c().ae(), x5.a(x5.b(nt.c5().c().r()) / 2f)) && nt.c5().c().s() == nt.c5().c().af() && nt.c5().c().q() == nt.c5().c().ad())
						{
							lg.b(false);
						}
						else
						{
							lg.b(true);
						}
						if (nt.d1() == i)
						{
							i += num3;
						}
						else
						{
							i = nt.d1() + num3;
						}
					}
					else
					{
						lg.e(1);
						lg.b(i);
						lg.a(i);
						lg.h(this.a(i));
						lg.b(true);
						lg.a(A_0.c5().c().r());
						lg.a(A_0.c5().c().q());
						lg.a(A_0.c5().c().s());
						i++;
					}
					lg.c(true);
					if (this.b == 1)
					{
						lg.d(1);
					}
					this.e.Add(lg);
					num2++;
					if (num2 >= this.i.Count)
					{
						break;
					}
				}
				else
				{
					i++;
				}
			}
		}

		// Token: 0x06001217 RID: 4631 RVA: 0x000CE108 File Offset: 0x000CD108
		private void a(nv A_0)
		{
			int num = 0;
			int i = 0;
			while (i < this.b)
			{
				nt nt = (nt)this.h[num][i];
				if (nt != null)
				{
					int num2 = ((n5)nt.db()).y();
					lg lg = new lg();
					lg.f(num2);
					this.a(lg, nt, num2, i);
					lg lg2 = lg;
					lg2.f(x5.f(lg2.f(), nt.c5().c().ab()));
					lg.b(nt.c5().c().ab());
					lg lg3 = lg;
					lg3.f(x5.f(lg3.f(), nt.c5().c().ae()));
					lg.c(nt.c5().c().ae());
					if (x5.h(nt.c5().c().v(), x5.a(x5.b(nt.c5().c().f()) / 2f)) && nt.c5().c().g() == nt.c5().c().w() && nt.c5().c().e() == nt.c5().c().u())
					{
						lg.b(false);
					}
					else
					{
						lg.b(true);
					}
					this.f.Add(lg);
					i += num2;
				}
				else
				{
					lg lg = new lg();
					lg.d(i);
					lg.f(1);
					lg.f((x5)this.a[i]);
					lg.c(A_0.c5().c().r());
					lg.b(true);
					lg.a(A_0.c5().c().f());
					lg.a(A_0.c5().c().e());
					lg.a(A_0.c5().c().g());
					this.f.Add(lg);
					i++;
				}
			}
			num = this.h.Length - 1;
			i = 0;
			while (i < this.b)
			{
				nt nt = (nt)this.h[num][i];
				if (nt != null)
				{
					int num2 = ((n5)nt.db()).y();
					lg lg = new lg();
					lg.f(num2);
					this.b(lg, nt, num2, i);
					lg lg4 = lg;
					lg4.f(x5.f(lg4.f(), nt.c5().c().ab()));
					lg.b(nt.c5().c().ab());
					lg lg5 = lg;
					lg5.f(x5.f(lg5.f(), nt.c5().c().ae()));
					lg.c(nt.c5().c().ae());
					if (x5.h(nt.c5().c().y(), x5.a(x5.b(nt.c5().c().j()) / 2f)) && nt.c5().c().k() == nt.c5().c().z() && nt.c5().c().i() == nt.c5().c().x())
					{
						lg.b(false);
					}
					else
					{
						lg.b(true);
					}
					lg.a(this.k);
					this.f.Add(lg);
					i += num2;
				}
				else
				{
					lg lg = new lg();
					lg.d(i);
					lg.a(this.i.Count);
					lg.f(1);
					lg.f((x5)this.a[i]);
					lg.c(A_0.c5().c().r());
					lg.b(true);
					lg.a(A_0.c5().c().j());
					lg.a(A_0.c5().c().i());
					lg.a(A_0.c5().c().k());
					this.f.Add(lg);
					i++;
				}
			}
			for (int j = 0; j < this.f.Count; j++)
			{
				num = this.f[j].i();
				i = this.f[j].l();
				for (int k = j + 1; k < this.f.Count; k++)
				{
					if (i + this.f[j].n() == this.f[k].l() && this.f[k].i() == num)
					{
						if (x5.d(this.f[j].a(), this.f[k].a()))
						{
							lg lg6 = this.f[j];
							lg6.f(x5.e(lg6.f(), x5.f(this.f[j].c(), this.f[j].c())));
						}
						else if (x5.c(this.f[j].a(), this.f[k].a()))
						{
							lg lg7 = this.f[k];
							lg7.f(x5.e(lg7.f(), x5.f(this.f[k].b(), this.f[k].b())));
						}
						else if (this.f[j].s())
						{
							lg lg8 = this.f[j];
							lg8.f(x5.e(lg8.f(), x5.f(this.f[j].c(), this.f[j].c())));
						}
						else
						{
							lg lg9 = this.f[k];
							lg9.f(x5.e(lg9.f(), x5.f(this.f[k].b(), this.f[k].b())));
						}
					}
				}
			}
			this.c();
		}

		// Token: 0x06001218 RID: 4632 RVA: 0x000CE858 File Offset: 0x000CD858
		private void d()
		{
			for (int i = 0; i < this.e.Count; i++)
			{
				for (int j = i + 1; j < this.e.Count; j++)
				{
					if (this.e[i].i() + this.e[i].m() + this.e[i].r() == this.e[j].i() && this.e[i].l() == this.e[j].l())
					{
						if (x5.h(this.e[i].a(), this.e[j].a()) && this.e[i].o() != null && this.e[i].o().Equals(this.e[j].o()) && this.e[i].p().Equals(this.e[j].p()))
						{
							lg lg = this.e[i];
							lg.h(x5.f(lg.h(), this.e[j].h()));
							this.e[i].g(this.e[i].r() + this.e[j].m() - 1);
							this.e[i].e(this.e[i].m() + this.e[j].m());
							this.e.RemoveAt(j);
							j--;
						}
					}
				}
			}
		}

		// Token: 0x06001219 RID: 4633 RVA: 0x000CEA7C File Offset: 0x000CDA7C
		private void c()
		{
			for (int i = 0; i < this.f.Count; i++)
			{
				bool flag = false;
				for (int j = i + 1; j < this.f.Count; j++)
				{
					if (this.f[i].l() + this.f[i].n() == this.f[j].l() && this.f[i].i() == this.f[j].i())
					{
						if (x5.h(this.f[i].a(), this.f[j].a()) && this.f[i].o() != null && this.f[i].o().Equals(this.f[j].o()) && this.f[i].p().Equals(this.f[j].p()))
						{
							lg lg = this.f[i];
							lg.f(x5.f(lg.f(), this.f[j].f()));
							this.f[i].g(this.f[i].n() + this.f[j].n() - 1);
							lg lg2 = this.f[i];
							lg2.f(lg2.n() + this.f[j].n());
							flag = true;
							this.f.RemoveAt(j);
							j--;
						}
					}
				}
				if (!flag)
				{
					this.f[i].g(this.f[i].n() - 1);
				}
			}
		}

		// Token: 0x0600121A RID: 4634 RVA: 0x000CECB0 File Offset: 0x000CDCB0
		private void d(lg A_0, nt A_1, int A_2, int A_3)
		{
			A_0.a(A_3);
			A_0.e(0);
			if (A_2 > 1)
			{
				for (int i = A_3; i < A_2 + A_1.d1(); i++)
				{
					if (this.i.ContainsKey(i))
					{
						A_0.h(x5.f(A_0.h(), this.i[i]));
						A_0.e(A_0.m() + 1);
					}
				}
			}
			else
			{
				if (this.i.ContainsKey(A_3))
				{
					A_0.h(x5.f(A_0.h(), this.i[A_3]));
				}
				A_0.e(A_0.m() + 1);
			}
			A_0.a(x5.a(x5.b(A_1.c5().c().ae()) * 2f));
			A_0.a(A_1.c5().c().ad());
			A_0.a(A_1.c5().c().af());
		}

		// Token: 0x0600121B RID: 4635 RVA: 0x000CEDD8 File Offset: 0x000CDDD8
		private void c(lg A_0, nt A_1, int A_2, int A_3)
		{
			A_0.a(A_3);
			A_0.e(0);
			if (A_2 > 1)
			{
				for (int i = A_3; i < A_2 + A_1.d1(); i++)
				{
					if (this.i.ContainsKey(i))
					{
						A_0.h(x5.f(A_0.h(), this.i[i]));
						A_0.e(A_0.m() + 1);
					}
				}
			}
			else
			{
				if (this.i.ContainsKey(A_3))
				{
					A_0.h(x5.f(A_0.h(), this.i[A_3]));
				}
				A_0.e(A_0.m() + 1);
			}
			A_0.a(x5.a(x5.b(A_1.c5().c().ab()) * 2f));
			A_0.a(A_1.c5().c().aa());
			A_0.a(A_1.c5().c().ac());
		}

		// Token: 0x0600121C RID: 4636 RVA: 0x000CEF00 File Offset: 0x000CDF00
		private void b(lg A_0, nt A_1, int A_2, int A_3)
		{
			A_0.d(A_3);
			A_0.f(0);
			if (A_2 > 1)
			{
				for (int i = A_3; i < A_2 + A_3; i++)
				{
					if (this.a[i] != null)
					{
						A_0.f(x5.f(A_0.f(), (x5)this.a[i]));
					}
					A_0.f(A_0.n() + 1);
				}
			}
			else
			{
				if (this.a[A_3] != null)
				{
					A_0.f((x5)this.a[A_3]);
				}
				A_0.f(A_0.n() + 1);
			}
			A_0.a(x5.a(x5.b(A_1.c5().c().y()) * 2f));
			A_0.a(A_1.c5().c().x());
			A_0.a(A_1.c5().c().z());
		}

		// Token: 0x0600121D RID: 4637 RVA: 0x000CF034 File Offset: 0x000CE034
		private void a(lg A_0, nt A_1, int A_2, int A_3)
		{
			A_0.d(A_3);
			A_0.f(0);
			if (A_2 > 1)
			{
				for (int i = A_3; i < A_2 + A_1.h(); i++)
				{
					if (i < this.a.Count)
					{
						A_0.f(x5.f(A_0.f(), (x5)this.a[i]));
					}
					A_0.f(A_0.n() + 1);
				}
			}
			else
			{
				A_0.f(A_1.aq());
				A_0.f(A_0.n() + 1);
			}
			A_0.a(x5.a(x5.b(A_1.c5().c().v()) * 2f));
			A_0.a(A_1.c5().c().u());
			A_0.a(A_1.c5().c().w());
		}

		// Token: 0x0600121E RID: 4638 RVA: 0x000CF140 File Offset: 0x000CE140
		private void a(nt A_0, nt A_1, lg A_2, int A_3)
		{
			int num = ((n5)A_0.db()).z();
			int num2 = ((n5)A_1.db()).z();
			if (num == 1 && num2 == 1)
			{
				if (x5.c(A_0.c5().c().y(), A_1.c5().c().y()))
				{
					A_2.h(x5.f(A_2.h(), A_0.c5().c().y()));
					A_2.e(A_0.c5().c().y());
				}
				else
				{
					A_2.h(x5.f(A_2.h(), A_1.c5().c().y()));
					A_2.e(A_1.c5().c().y());
				}
				if (x5.c(A_0.c5().c().v(), A_1.c5().c().v()))
				{
					A_2.h(x5.f(A_2.h(), A_0.c5().c().v()));
					A_2.d(A_0.c5().c().v());
				}
				else
				{
					A_2.h(x5.f(A_2.h(), A_1.c5().c().v()));
					A_2.d(A_1.c5().c().v());
				}
			}
			else if (num == 1 && num2 > 1)
			{
				A_2.h(x5.f(A_2.h(), A_0.c5().c().y()));
				A_2.e(A_0.c5().c().y());
				if (A_0.h() + 1 == A_1.h())
				{
					if (x5.c(A_0.c5().c().v(), A_1.c5().c().v()))
					{
						A_2.h(x5.f(A_2.h(), A_0.c5().c().v()));
						A_2.d(A_0.c5().c().v());
					}
					else
					{
						A_2.h(x5.f(A_2.h(), A_1.c5().c().v()));
						A_2.d(A_1.c5().c().v());
					}
				}
				else
				{
					A_2.h(x5.f(A_2.h(), A_0.c5().c().v()));
					A_2.d(A_0.c5().c().v());
				}
			}
			else if (num > 1 && num2 == 1)
			{
				A_2.h(x5.f(A_0.ar(), A_1.c5().c().y()));
				A_2.e(A_1.c5().c().y());
				if (A_0.h() + 1 == A_1.h())
				{
					if (x5.c(A_0.c5().c().v(), A_1.c5().c().v()))
					{
						A_2.h(x5.f(A_2.h(), A_0.c5().c().v()));
						A_2.d(A_0.c5().c().v());
					}
					else
					{
						A_2.h(x5.f(A_2.h(), A_1.c5().c().v()));
						A_2.d(A_1.c5().c().v());
					}
				}
				else
				{
					A_2.h(x5.f(A_2.h(), A_1.c5().c().v()));
					A_2.d(A_1.c5().c().v());
				}
			}
			else
			{
				if (num + A_0.d1() - 1 < num2 + A_1.d1() - 1)
				{
					A_2.h(x5.f(A_2.h(), A_0.c5().c().y()));
					A_2.e(A_0.c5().c().y());
				}
				else
				{
					A_2.h(x5.f(A_2.h(), A_1.c5().c().y()));
					A_2.e(A_1.c5().c().y());
				}
				if (A_0.d1() == A_1.d1())
				{
					if (x5.c(A_0.c5().c().v(), A_1.c5().c().v()))
					{
						A_2.h(x5.f(A_2.h(), A_0.c5().c().v()));
						A_2.d(A_0.c5().c().v());
					}
					else
					{
						A_2.h(x5.f(A_2.h(), A_1.c5().c().v()));
						A_2.d(A_1.c5().c().v());
					}
				}
				else if (A_0.d1() == A_3)
				{
					A_2.h(x5.f(A_2.h(), A_0.c5().c().v()));
					A_2.d(A_0.c5().c().v());
				}
				else
				{
					A_2.h(x5.f(A_2.h(), A_1.c5().c().v()));
					A_2.d(A_1.c5().c().v());
				}
			}
		}

		// Token: 0x0600121F RID: 4639 RVA: 0x000CF760 File Offset: 0x000CE760
		private x5 a(int A_0, List<lg> A_1)
		{
			x5 result = x5.c();
			for (int i = 0; i < A_1.Count; i++)
			{
				if (A_1[i].i() == A_0)
				{
					result = A_1[i].h();
				}
			}
			return result;
		}

		// Token: 0x06001220 RID: 4640 RVA: 0x000CF7B4 File Offset: 0x000CE7B4
		private x5 a(int A_0)
		{
			x5 x = x5.c();
			return this.i[A_0];
		}

		// Token: 0x06001221 RID: 4641 RVA: 0x000CF7DC File Offset: 0x000CE7DC
		private void a(lg A_0, nt A_1, nt A_2, int A_3, bool A_4)
		{
			if (A_3 == 0)
			{
				if (x5.c(A_1.c5().c().ab(), A_2.c5().c().ab()))
				{
					A_0.f(x5.f(A_0.f(), A_1.c5().c().ab()));
					A_0.b(A_1.c5().c().ab());
				}
				else
				{
					A_0.f(x5.f(A_0.f(), A_2.c5().c().ab()));
					A_0.b(A_2.c5().c().ab());
				}
				if (x5.c(x5.f(A_1.c5().c().ab(), A_1.c5().c().ab()), A_1.c5().c().n()))
				{
					if (x5.c(x5.f(A_2.c5().c().ab(), A_2.c5().c().ab()), A_2.c5().c().n()))
					{
						A_0.a(false);
						if (A_4)
						{
							A_0.f(x5.e(A_0.f(), x5.f(A_1.c5().c().ab(), A_1.c5().c().ab())));
						}
						else
						{
							A_0.f(x5.e(A_0.f(), x5.f(A_2.c5().c().ab(), A_2.c5().c().ab())));
						}
					}
				}
				if (A_1.h() + ((n5)A_1.db()).y() == A_2.h() + ((n5)A_2.db()).y())
				{
					if (x5.h(A_1.c5().c().ae(), x5.c()) && x5.d(A_0.f(), (x5)this.a[A_0.l()]))
					{
						A_0.f((x5)this.a[A_0.l()]);
					}
					else if (x5.c(A_1.c5().c().ae(), A_2.c5().c().ae()))
					{
						A_0.f(x5.f(A_0.f(), A_1.c5().c().ae()));
						A_0.c(A_1.c5().c().ae());
					}
					else
					{
						A_0.f(x5.f(A_0.f(), A_2.c5().c().ae()));
						A_0.c(A_2.c5().c().ae());
					}
				}
				else if (A_1.h() + ((n5)A_1.db()).y() < A_2.h() + ((n5)A_2.db()).y())
				{
					A_0.f(x5.f(A_0.f(), A_1.c5().c().ae()));
					A_0.c(A_1.c5().c().ae());
				}
				else
				{
					A_0.f(x5.f(A_0.f(), A_2.c5().c().ae()));
					A_0.c(A_2.c5().c().ae());
				}
			}
			else if (A_3 + ((n5)A_1.db()).y() >= this.b)
			{
				if (A_1.h() == A_3 && A_2.h() == A_3)
				{
					if (x5.c(A_1.c5().c().ab(), A_2.c5().c().ab()))
					{
						A_0.f(x5.f(A_0.f(), A_1.c5().c().ab()));
						A_0.b(A_1.c5().c().ab());
					}
					else
					{
						A_0.f(x5.f(A_0.f(), A_2.c5().c().ab()));
						A_0.b(A_2.c5().c().ab());
					}
				}
				else if (A_1.h() == A_3)
				{
					A_0.f(x5.f(A_0.f(), A_1.c5().c().ab()));
					A_0.b(A_1.c5().c().ab());
				}
				else
				{
					A_0.f(x5.f(A_0.f(), A_2.c5().c().ab()));
					A_0.b(A_2.c5().c().ab());
				}
				if (A_1.h() + ((n5)A_1.db()).y() - 1 == A_3 && A_2.h() + ((n5)A_2.db()).y() - 1 == A_3)
				{
					if (x5.c(A_1.c5().c().ae(), A_2.c5().c().ab()))
					{
						A_0.f(x5.f(A_0.f(), A_1.c5().c().ae()));
						A_0.c(A_1.c5().c().ae());
					}
					else
					{
						A_0.f(x5.f(A_0.f(), A_2.c5().c().ae()));
						A_0.c(A_2.c5().c().ae());
					}
					if (x5.c(x5.f(A_1.c5().c().ae(), A_1.c5().c().ae()), A_1.c5().c().r()))
					{
						if (x5.c(x5.f(A_2.c5().c().ae(), A_2.c5().c().ae()), A_2.c5().c().r()))
						{
							A_0.a(false);
							if (A_4)
							{
								A_0.f(x5.e(A_0.f(), x5.f(A_1.c5().c().ae(), A_1.c5().c().ae())));
								A_0.c(A_1.c5().c().ae());
							}
							else
							{
								A_0.f(x5.e(A_0.f(), x5.f(A_2.c5().c().ae(), A_2.c5().c().ae())));
								A_0.c(A_2.c5().c().ae());
							}
						}
					}
				}
				else if (A_1.h() + ((n5)A_1.db()).y() - 1 == A_3)
				{
					A_0.f(x5.f(A_0.f(), A_1.c5().c().ae()));
					A_0.c(A_1.c5().c().ae());
				}
				else
				{
					A_0.f(x5.f(A_0.f(), A_2.c5().c().ae()));
					A_0.c(A_2.c5().c().ae());
				}
			}
			else
			{
				if (A_1.h() == A_3 && A_2.h() == A_3)
				{
					if (x5.c(A_1.c5().c().ab(), A_2.c5().c().ab()))
					{
						A_0.f(x5.f(A_0.f(), A_1.c5().c().ab()));
						A_0.b(A_1.c5().c().ab());
					}
					else
					{
						A_0.f(x5.f(A_0.f(), A_2.c5().c().ab()));
						A_0.b(A_2.c5().c().ab());
					}
				}
				else if (A_1.h() > A_2.h())
				{
					A_0.f(x5.f(A_0.f(), A_1.c5().c().ab()));
					A_0.b(A_1.c5().c().ab());
				}
				else
				{
					A_0.f(x5.f(A_0.f(), A_2.c5().c().ab()));
					A_0.b(A_2.c5().c().ab());
				}
				if (A_1.h() + ((n5)A_1.db()).y() - 1 == A_2.h() + ((n5)A_2.db()).y() - 1)
				{
					if (x5.c(A_1.c5().c().ae(), A_2.c5().c().ae()))
					{
						A_0.f(x5.f(A_0.f(), A_1.c5().c().ae()));
						A_0.c(A_1.c5().c().ae());
					}
					else
					{
						A_0.f(x5.f(A_0.f(), A_2.c5().c().ae()));
						A_0.c(A_2.c5().c().ae());
					}
				}
				else if (A_1.h() + ((n5)A_1.db()).y() - 1 == A_3)
				{
					A_0.f(x5.f(A_0.f(), A_1.c5().c().ae()));
					A_0.c(A_1.c5().c().ae());
				}
				else
				{
					A_0.f(x5.f(A_0.f(), A_2.c5().c().ae()));
					A_0.c(A_2.c5().c().ae());
				}
			}
		}

		// Token: 0x06001222 RID: 4642 RVA: 0x000D02F0 File Offset: 0x000CF2F0
		private void b(lg A_0, nt A_1, int A_2)
		{
			if (A_2 == 0)
			{
				if (x5.h(A_1.c5().c().n(), x5.f(A_1.c5().c().ab(), A_1.c5().c().ab())) && A_1.c5().c().m() == A_1.c5().c().aa() && A_1.c5().c().o() == A_1.c5().c().ac())
				{
					A_0.f(x5.f(A_0.f(), A_1.c5().c().ab()));
					A_0.b(A_1.c5().c().ab());
				}
				else
				{
					A_0.a(false);
					A_0.f(x5.e(A_0.f(), A_1.c5().c().ab()));
				}
				A_0.f(x5.f(A_0.f(), A_1.c5().c().ae()));
				A_0.c(A_1.c5().c().ae());
			}
			else if (A_2 == this.b - 1)
			{
				A_0.f(x5.f(A_0.f(), A_1.c5().c().ab()));
				A_0.b(A_1.c5().c().ab());
				if (x5.h(A_1.c5().c().r(), x5.f(A_1.c5().c().ae(), A_1.c5().c().ae())) && A_1.c5().c().q() == A_1.c5().c().ad() && A_1.c5().c().s() == A_1.c5().c().af())
				{
					A_0.f(x5.f(A_0.f(), A_1.c5().c().ae()));
					A_0.c(A_1.c5().c().ae());
				}
				else
				{
					A_0.a(false);
					A_0.f(x5.e(A_0.f(), A_1.c5().c().ae()));
				}
			}
			else
			{
				A_0.f(x5.f(A_0.f(), A_1.c5().c().ab()));
				A_0.b(A_1.c5().c().ab());
				A_0.f(x5.f(A_0.f(), A_1.c5().c().ae()));
				A_0.c(A_1.c5().c().ae());
			}
		}

		// Token: 0x06001223 RID: 4643 RVA: 0x000D05FC File Offset: 0x000CF5FC
		private void a(lg A_0, nt A_1, int A_2)
		{
			if (A_2 == 0)
			{
				if (x5.h(A_1.c5().c().n(), x5.f(A_1.c5().c().ab(), A_1.c5().c().ab())) && A_1.c5().c().m() == A_1.c5().c().aa() && A_1.c5().c().o() == A_1.c5().c().ac())
				{
					A_0.f(x5.f(A_0.f(), A_1.c5().c().ab()));
					A_0.b(A_1.c5().c().ab());
				}
				else
				{
					A_0.f(x5.e(A_0.f(), A_1.c5().c().ab()));
				}
				A_0.f(x5.f(A_0.f(), A_1.c5().c().ae()));
				A_0.c(A_1.c5().c().ae());
			}
			else if (A_2 == this.b - 1)
			{
				A_0.f(x5.f(A_0.f(), A_1.c5().c().ab()));
				A_0.b(A_1.c5().c().ab());
				if (x5.h(A_1.c5().c().r(), x5.f(A_1.c5().c().ae(), A_1.c5().c().ae())) && A_1.c5().c().q() == A_1.c5().c().ad() && A_1.c5().c().s() == A_1.c5().c().af())
				{
					A_0.f(x5.f(A_0.f(), A_1.c5().c().ae()));
					A_0.c(A_1.c5().c().ae());
				}
				else
				{
					A_0.f(x5.e(A_0.f(), A_1.c5().c().ae()));
				}
			}
			else
			{
				A_0.f(x5.f(A_0.f(), A_1.c5().c().ab()));
				A_0.b(A_1.c5().c().ab());
				A_0.f(x5.f(A_0.f(), A_1.c5().c().ae()));
				A_0.c(A_1.c5().c().ae());
			}
		}

		// Token: 0x06001224 RID: 4644 RVA: 0x000D08F4 File Offset: 0x000CF8F4
		private void b()
		{
			for (int i = 0; i < this.c.Count; i++)
			{
				int num = this.c[i].i();
				int num2 = this.c[i].l();
				for (int j = i + 1; j < this.c.Count; j++)
				{
					if (this.c[j].i() > num)
					{
						if ((num + this.c[i].m() == this.c[j].i() || (num <= this.c[j].i() && num + this.c[i].m() > this.c[j].i())) && this.c[j].l() == num2)
						{
							if (x5.d(this.c[i].a(), this.c[j].a()))
							{
								lg lg = this.c[i];
								lg.h(x5.e(lg.h(), x5.f(this.c[i].e(), this.c[i].e())));
								if (x5.d(this.c[i].e(), this.c[j].d()))
								{
									lg lg2 = this.c[i];
									lg2.h(x5.e(lg2.h(), x5.e(this.c[j].d(), this.c[i].e())));
								}
							}
							else if (x5.c(this.c[i].a(), this.c[j].a()))
							{
								lg lg3 = this.c[j];
								lg3.h(x5.e(lg3.h(), x5.f(this.c[j].d(), this.c[j].d())));
							}
							else if (x5.d(this.c[i].e(), this.c[j].d()))
							{
								lg lg4 = this.c[i];
								lg4.h(x5.e(lg4.h(), x5.f(this.c[i].e(), this.c[i].e())));
								lg lg5 = this.c[i];
								lg5.h(x5.e(lg5.h(), x5.e(this.c[j].d(), this.c[i].e())));
							}
							else if (x5.c(this.c[i].e(), this.c[j].d()))
							{
								lg lg6 = this.c[j];
								lg6.h(x5.e(lg6.h(), x5.f(this.c[j].d(), this.c[j].d())));
								lg lg7 = this.c[j];
								lg7.h(x5.e(lg7.h(), x5.a(x5.b(x5.e(this.c[i].e(), this.c[j].d())) / 2f)));
							}
							else
							{
								lg lg8 = this.c[i];
								lg8.h(x5.e(lg8.h(), x5.f(this.c[i].e(), this.c[i].e())));
							}
						}
					}
				}
			}
		}

		// Token: 0x06001225 RID: 4645 RVA: 0x000D0D60 File Offset: 0x000CFD60
		private void a()
		{
			for (int i = 0; i < this.d.Count; i++)
			{
				int num = this.d[i].i();
				int num2 = this.d[i].l();
				for (int j = i + 1; j < this.d.Count; j++)
				{
					if (num2 + this.d[i].n() == this.d[j].l() && this.d[j].i() == num)
					{
						if (x5.d(this.d[i].a(), this.d[j].a()))
						{
							lg lg = this.d[i];
							lg.f(x5.e(lg.f(), x5.f(this.d[i].c(), this.d[i].c())));
						}
						else if (x5.c(this.d[i].a(), this.d[j].a()))
						{
							lg lg2 = this.d[j];
							lg2.f(x5.e(lg2.f(), x5.f(this.d[j].b(), this.d[j].b())));
						}
						else if (x5.d(this.d[i].c(), this.d[j].b()))
						{
							lg lg3 = this.d[i];
							lg3.f(x5.e(lg3.f(), x5.f(this.d[i].c(), this.d[i].c())));
						}
						else
						{
							lg lg4 = this.d[j];
							lg4.f(x5.e(lg4.f(), x5.f(this.d[j].b(), this.d[j].b())));
						}
					}
				}
			}
		}

		// Token: 0x06001226 RID: 4646 RVA: 0x000D0FD8 File Offset: 0x000CFFD8
		private x5 a(int A_0, int A_1)
		{
			x5 result = x5.c();
			for (int i = 0; i < this.l().Count; i++)
			{
				if (this.l()[i].i() == A_0 && this.l()[i].l() == A_1)
				{
					result = this.l()[i].a();
				}
			}
			return result;
		}

		// Token: 0x0400088E RID: 2190
		private Hashtable a;

		// Token: 0x0400088F RID: 2191
		private int b;

		// Token: 0x04000890 RID: 2192
		private List<lg> c;

		// Token: 0x04000891 RID: 2193
		private List<lg> d;

		// Token: 0x04000892 RID: 2194
		private List<lg> e;

		// Token: 0x04000893 RID: 2195
		private List<lg> f;

		// Token: 0x04000894 RID: 2196
		private List<lg> g = new List<lg>();

		// Token: 0x04000895 RID: 2197
		private kz[][] h;

		// Token: 0x04000896 RID: 2198
		private Dictionary<int, x5> i;

		// Token: 0x04000897 RID: 2199
		private int j = 0;

		// Token: 0x04000898 RID: 2200
		private int k = 0;

		// Token: 0x04000899 RID: 2201
		private kz[] l = null;
	}
}
