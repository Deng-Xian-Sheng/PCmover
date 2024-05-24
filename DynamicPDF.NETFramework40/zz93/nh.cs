using System;
using System.Collections.Generic;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x02000207 RID: 519
	internal class nh
	{
		// Token: 0x060017A6 RID: 6054 RVA: 0x000FB574 File Offset: 0x000FA574
		internal nh(kz[][] A_0, int A_1, nv A_2)
		{
			this.a = A_0;
			this.b = A_2;
			this.c = A_1;
		}

		// Token: 0x060017A7 RID: 6055 RVA: 0x000FB5AC File Offset: 0x000FA5AC
		private void j()
		{
			for (int i = 0; i < this.a.Length; i++)
			{
				for (int j = 0; j < this.a[i].Length - 1; j++)
				{
					if (this.a[i][j] != null)
					{
						if (((n5)this.a[i][j].db()).y() > 1)
						{
							j += ((n5)this.a[i][j].db()).y() - 1;
						}
						if (j < this.a[i].Length - 1)
						{
							kz kz = this.a[i][j];
							kz kz2 = this.a[i][j + 1];
							if (kz != null)
							{
								if (kz2 != null)
								{
									if (((n5)kz.db()).z() == 1 && ((n5)kz2.db()).z() == 1)
									{
										if (kz.c5().c().s() == ft.j || kz2.c5().c().o() == ft.j)
										{
											kz.c5().c().d(x5.c());
											kz.c5().c().h(x5.c());
											kz2.c5().c().c(x5.c());
											kz2.c5().c().g(x5.c());
											kz2.c5().c().c(ft.j);
											kz.c5().c().d(ft.j);
										}
										else if (kz.c5().c().s() != ft.a)
										{
											if (x5.c(kz.c5().c().r(), kz2.c5().c().n()))
											{
												this.c(kz, kz2);
											}
											else if (x5.d(kz.c5().c().r(), kz2.c5().c().n()))
											{
												this.d(kz, kz2);
											}
											else if (kz.c5().c().s() == kz2.c5().c().o())
											{
												if (kz.c5().c().ao() <= kz2.c5().c().ap())
												{
													this.c(kz, kz2);
												}
												else
												{
													this.d(kz, kz2);
												}
											}
											else if (kz.c5().c().s() > kz2.c5().c().o())
											{
												this.c(kz, kz2);
											}
											else
											{
												this.d(kz, kz2);
											}
										}
										else if (kz2.c5().c().o() != ft.a)
										{
											this.d(kz, kz2);
										}
										else
										{
											kz.c5().c().d(x5.c());
											kz2.c5().c().c(x5.c());
											kz2.c5().c().g(x5.c());
											kz.c5().c().h(x5.c());
										}
									}
								}
								else
								{
									kz.c5().c().h(x5.a(x5.b(kz.c5().c().r()) / 2f));
									kz.c5().c().h(kz.c5().c().s());
									kz.c5().c().h(kz.c5().c().q());
								}
							}
							else if (kz2 != null)
							{
								kz2.c5().c().g(x5.a(x5.b(kz2.c5().c().n()) / 2f));
								kz2.c5().c().g(kz2.c5().c().o());
								kz2.c5().c().g(kz2.c5().c().m());
							}
						}
					}
				}
			}
		}

		// Token: 0x060017A8 RID: 6056 RVA: 0x000FBA68 File Offset: 0x000FAA68
		private void i()
		{
			for (int i = 0; i < this.c; i++)
			{
				for (int j = 0; j < this.a.Length - 1; j++)
				{
					if (this.a[j][i] != null)
					{
						if (((n5)this.a[j][i].db()).z() > 1)
						{
							j += ((n5)this.a[j][i].db()).z() - 1;
						}
						if (j < this.a.Length - 1)
						{
							kz kz = this.a[j][i];
							kz kz2 = this.a[j + 1][i];
							if (kz != null)
							{
								if (kz2 != null)
								{
									if (((n5)kz.db()).y() == 1 && ((n5)kz2.db()).y() == 1)
									{
										if (kz.c5().c().k() == ft.j || kz2.c5().c().g() == ft.j)
										{
											kz2.c5().c().a(x5.c());
											kz.c5().c().b(x5.c());
											kz2.c5().c().a(ft.j);
											kz2.c5().c().e(x5.c());
											kz.c5().c().f(x5.c());
											kz2.c5().c().e(ft.j);
											kz.c5().c().f(ft.j);
											kz.c5().c().b(ft.j);
										}
										else if (kz.c5().c().k() != ft.a)
										{
											if (x5.c(kz.c5().c().j(), kz2.c5().c().f()))
											{
												this.a(kz, kz2);
											}
											else if (x5.d(kz.c5().c().j(), kz2.c5().c().f()))
											{
												this.b(kz, kz2);
											}
											else if (kz.c5().c().k() == kz2.c5().c().g())
											{
												if (kz.c5().c().ar() <= kz2.c5().c().aq())
												{
													this.a(kz, kz2);
												}
												else
												{
													this.b(kz, kz2);
												}
											}
											else if (kz.c5().c().k() > kz2.c5().c().g())
											{
												this.a(kz, kz2);
											}
											else
											{
												this.b(kz, kz2);
											}
										}
										else if (kz2.c5().c().g() != ft.a)
										{
											this.b(kz, kz2);
										}
										else
										{
											kz.c5().c().b(x5.c());
											kz2.c5().c().a(x5.c());
											kz2.c5().c().e(x5.c());
											kz.c5().c().f(x5.c());
										}
									}
								}
								else
								{
									kz.c5().c().f(x5.a(x5.b(kz.c5().c().j()) / 2f));
									kz.c5().c().f(kz.c5().c().k());
									kz.c5().c().f(kz.c5().c().i());
								}
							}
							else if (kz2 != null)
							{
								kz2.c5().c().e(x5.a(x5.b(kz2.c5().c().f()) / 2f));
								kz2.c5().c().e(kz2.c5().c().g());
								kz2.c5().c().e(kz2.c5().c().e());
							}
						}
					}
				}
			}
		}

		// Token: 0x060017A9 RID: 6057 RVA: 0x000FBF42 File Offset: 0x000FAF42
		private void h()
		{
			this.g();
			this.f();
			this.e();
			this.d();
		}

		// Token: 0x060017AA RID: 6058 RVA: 0x000FBF64 File Offset: 0x000FAF64
		private void g()
		{
			int num = 0;
			ft ft = this.b.c5().c().o();
			if (ft == ft.j)
			{
				for (int i = 0; i < this.a.Length; i++)
				{
					kz kz = this.a[i][num];
					this.b.c5().c().c(x5.c());
					kz.c5().c().c(x5.c());
					kz.c5().c().c(ft.j);
				}
			}
			else if (ft != ft.a)
			{
				for (int i = 0; i < this.a.Length; i++)
				{
					kz kz = this.a[i][num];
					if (kz != null)
					{
						if (kz.c5().c().o() == ft.j)
						{
							kz.c5().c().g(x5.c());
						}
						else if (x5.c(this.b.c5().c().n(), kz.c5().c().n()))
						{
							this.d(kz, this.b, true);
						}
						else if (x5.d(this.b.c5().c().n(), kz.c5().c().n()) || ft <= kz.c5().c().o())
						{
							x5 a_ = x5.a(x5.b(kz.c5().c().n()) / 2f);
							kz.c5().c().g(a_);
							kz.c5().c().g(kz.c5().c().o());
							kz.c5().c().g(kz.c5().c().m());
						}
						else if (ft > kz.c5().c().o())
						{
							this.d(kz, this.b, true);
						}
					}
				}
			}
			else
			{
				for (int i = 0; i < this.a.Length; i++)
				{
					kz kz = this.a[i][num];
					if (kz != null)
					{
						x5 a_ = x5.c();
						if (kz.c5().c().o() != ft.a)
						{
							a_ = x5.a(x5.b(kz.c5().c().n()) / 2f);
						}
						else
						{
							this.b.c5().c().c(x5.c());
						}
						kz.c5().c().g(a_);
						kz.c5().c().g(kz.c5().c().o());
						kz.c5().c().g(kz.c5().c().m());
					}
				}
			}
			if (this.a.Length > 0 && this.a[0][0] != null)
			{
				this.b.c5().c().g(this.a[0][0].c5().c().ab());
				this.b.c5().c().g(this.a[0][0].c5().c().ac());
				this.b.c5().c().g(this.a[0][0].c5().c().aa());
			}
		}

		// Token: 0x060017AB RID: 6059 RVA: 0x000FC378 File Offset: 0x000FB378
		private void f()
		{
			int num = this.c - 1;
			ft ft = this.b.c5().c().s();
			if (ft == ft.j)
			{
				for (int i = 0; i < this.a.Length; i++)
				{
					kz kz = this.a[i][num];
					this.b.c5().c().d(x5.c());
					kz.c5().c().h(x5.c());
					kz.c5().c().h(ft.j);
				}
			}
			else
			{
				x5 a_ = x5.c();
				if (ft != ft.a)
				{
					for (int i = 0; i < this.a.Length; i++)
					{
						kz kz = this.a[i][num];
						if (kz != null)
						{
							if (kz.c5().c().s() == ft.j)
							{
								kz.c5().c().h(x5.c());
							}
							else if (x5.c(this.b.c5().c().r(), kz.c5().c().r()))
							{
								this.c(kz, this.b, true);
							}
							else if (x5.d(this.b.c5().c().r(), kz.c5().c().r()) || ft <= kz.c5().c().s())
							{
								a_ = x5.a(x5.b(kz.c5().c().r()) / 2f);
								kz.c5().c().h(a_);
								kz.c5().c().h(kz.c5().c().s());
								kz.c5().c().h(kz.c5().c().q());
							}
							else if (ft > kz.c5().c().s())
							{
								this.c(kz, this.b, true);
							}
						}
					}
				}
				else
				{
					for (int i = 0; i < this.a.Length; i++)
					{
						kz kz = this.a[i][num];
						if (kz != null)
						{
							if (kz.c5().c().s() != ft.a)
							{
								a_ = x5.a(x5.b(kz.c5().c().r()) / 2f);
							}
							else
							{
								this.b.c5().c().d(x5.c());
							}
							kz.c5().c().h(a_);
							kz.c5().c().h(kz.c5().c().s());
							kz.c5().c().h(kz.c5().c().q());
						}
					}
				}
			}
			if (this.a.Length > 0 && this.a[0][num] != null)
			{
				this.b.c5().c().h(this.a[0][0].c5().c().ae());
				this.b.c5().c().h(this.a[0][0].c5().c().af());
				this.b.c5().c().h(this.a[0][0].c5().c().ad());
			}
		}

		// Token: 0x060017AC RID: 6060 RVA: 0x000FC794 File Offset: 0x000FB794
		private void e()
		{
			int num = 0;
			ft ft = this.b.c5().c().g();
			x5 a_ = x5.c();
			if (ft == ft.j)
			{
				this.b.c5().c().a(x5.c());
				for (int i = 0; i < this.c; i++)
				{
					kz kz = this.a[num][i];
					kz.c5().c().a(x5.c());
					kz.c5().c().a(ft);
					kz.c5().c().e(a_);
					kz.c5().c().e(kz.c5().c().g());
				}
			}
			else if (ft != ft.a)
			{
				for (int i = 0; i < this.c; i++)
				{
					a_ = x5.c();
					kz kz = this.a[num][i];
					if (kz != null)
					{
						if (kz.c5().c().g() == ft.j)
						{
							kz.c5().c().e(x5.c());
						}
						else if (x5.c(this.b.c5().c().f(), kz.c5().c().f()))
						{
							this.b(kz, this.b, true);
						}
						else if (x5.d(this.b.c5().c().f(), kz.c5().c().f()) || this.b.c5().c().g() <= kz.c5().c().g())
						{
							a_ = x5.a(x5.b(kz.c5().c().f()) / 2f);
							kz.c5().c().e(a_);
							kz.c5().c().e(kz.c5().c().g());
							kz.c5().c().e(kz.c5().c().e());
						}
						else if (this.b.c5().c().g() > kz.c5().c().g())
						{
							this.b(kz, this.b, true);
						}
					}
				}
			}
			else
			{
				for (int i = 0; i < this.c; i++)
				{
					a_ = x5.c();
					kz kz = this.a[num][i];
					if (kz != null)
					{
						if (kz.c5().c().g() != ft.a)
						{
							a_ = x5.a(x5.b(kz.c5().c().f()) / 2f);
							kz.c5().c().e(a_);
							kz.c5().c().e(kz.c5().c().g());
							kz.c5().c().e(kz.c5().c().e());
						}
						else
						{
							this.b.c5().c().a(x5.c());
							kz.c5().c().a(x5.c());
							kz.c5().c().e(a_);
						}
					}
				}
			}
			if (this.a.Length > 0 && this.a[num][this.c - 1] != null)
			{
				this.b.c5().c().e(this.a[0][this.c - 1].c5().c().v());
				this.b.c5().c().e(this.a[0][this.c - 1].c5().c().w());
				this.b.c5().c().e(this.a[0][this.c - 1].c5().c().u());
			}
		}

		// Token: 0x060017AD RID: 6061 RVA: 0x000FCC5C File Offset: 0x000FBC5C
		private void d()
		{
			int num = this.a.Length - 1;
			ft ft = this.b.c5().c().k();
			kz kz = null;
			x5 a_ = x5.c();
			if (ft == ft.j)
			{
				this.b.c5().c().b(x5.c());
				for (int i = 0; i < this.c; i++)
				{
					if (kz != null)
					{
						kz = this.a[num][i];
						kz.c5().c().b(x5.c());
						kz.c5().c().b(ft);
						kz.c5().c().f(x5.c());
						kz.c5().c().f(ft);
					}
				}
			}
			else if (ft != ft.a)
			{
				for (int i = 0; i < this.c; i++)
				{
					kz = this.a[num][i];
					if (kz != null)
					{
						if (kz.c5().c().k() == ft.j)
						{
							kz.c5().c().f(x5.c());
						}
						else if (x5.c(this.b.c5().c().j(), kz.c5().c().j()))
						{
							this.a(kz, this.b, true);
						}
						else if (x5.d(this.b.c5().c().j(), kz.c5().c().j()) || this.b.c5().c().k() <= kz.c5().c().k())
						{
							a_ = x5.a(x5.b(kz.c5().c().j()) / 2f);
							kz.c5().c().f(a_);
							kz.c5().c().f(kz.c5().c().i());
							kz.c5().c().f(kz.c5().c().k());
						}
						else if (this.b.c5().c().k() > kz.c5().c().k())
						{
							this.a(kz, this.b, true);
						}
					}
				}
			}
			else
			{
				for (int i = 0; i < this.c; i++)
				{
					kz = this.a[num][i];
					a_ = x5.c();
					if (kz != null)
					{
						if (kz.c5().c().k() != ft.a)
						{
							a_ = x5.a(x5.b(kz.c5().c().j()) / 2f);
							kz.c5().c().f(kz.c5().c().k());
							kz.c5().c().f(kz.c5().c().i());
						}
						else
						{
							this.b.c5().c().b(x5.c());
							kz.c5().c().b(x5.c());
						}
						kz.c5().c().f(a_);
					}
				}
			}
			if (this.a.Length > 0 && this.a[num][this.c - 1] != null)
			{
				this.b.c5().c().f(this.a[num][this.c - 1].c5().c().y());
				this.b.c5().c().f(this.a[num][this.c - 1].c5().c().z());
				this.b.c5().c().f(this.a[num][this.c - 1].c5().c().x());
			}
		}

		// Token: 0x060017AE RID: 6062 RVA: 0x000FD114 File Offset: 0x000FC114
		private void d(kz A_0, kz A_1)
		{
			x5 a_ = x5.a(x5.b(A_1.c5().c().n()) / 2f);
			ft a_2 = A_1.c5().c().o();
			Color a_3 = A_1.c5().c().m();
			A_1.c5().c().g(a_);
			A_1.c5().c().g(a_2);
			A_1.c5().c().g(a_3);
			A_0.c5().c().h(a_);
			A_0.c5().c().h(a_2);
			A_0.c5().c().h(a_3);
		}

		// Token: 0x060017AF RID: 6063 RVA: 0x000FD1D4 File Offset: 0x000FC1D4
		private void c(kz A_0, kz A_1)
		{
			x5 a_ = x5.a(x5.b(A_0.c5().c().r()) / 2f);
			ft a_2 = A_0.c5().c().s();
			Color a_3 = A_0.c5().c().q();
			A_1.c5().c().g(a_);
			A_1.c5().c().g(a_2);
			A_1.c5().c().g(a_3);
			A_0.c5().c().h(a_);
			A_0.c5().c().h(a_2);
			A_0.c5().c().h(a_3);
		}

		// Token: 0x060017B0 RID: 6064 RVA: 0x000FD294 File Offset: 0x000FC294
		private void b(kz A_0, kz A_1)
		{
			x5 a_ = x5.a(x5.b(A_1.c5().c().f()) / 2f);
			ft a_2 = A_1.c5().c().g();
			Color a_3 = A_1.c5().c().e();
			A_1.c5().c().a(a_);
			A_1.c5().c().e(a_);
			A_1.c5().c().e(a_2);
			A_1.c5().c().e(a_3);
			A_0.c5().c().f(a_);
			A_0.c5().c().f(a_2);
			A_0.c5().c().f(a_3);
		}

		// Token: 0x060017B1 RID: 6065 RVA: 0x000FD368 File Offset: 0x000FC368
		private void a(kz A_0, kz A_1)
		{
			x5 a_ = x5.a(x5.b(A_0.c5().c().j()) / 2f);
			ft a_2 = A_0.c5().c().k();
			Color a_3 = A_0.c5().c().i();
			A_0.c5().c().b(a_);
			A_1.c5().c().e(a_);
			A_1.c5().c().e(a_2);
			A_1.c5().c().e(a_3);
			A_0.c5().c().f(a_);
			A_0.c5().c().f(a_2);
			A_0.c5().c().f(a_3);
		}

		// Token: 0x060017B2 RID: 6066 RVA: 0x000FD43C File Offset: 0x000FC43C
		private void c()
		{
			for (int i = 0; i < this.a.Length; i++)
			{
				for (int j = 0; j < this.a[i].Length - 1; j++)
				{
					nt nt = (nt)this.a[i][j];
					nt nt2 = (nt)this.a[i][j + 1];
					x5 x = x5.c();
					if (nt != null && nt2 != null)
					{
						if (!nt.c5().c().ah() || !nt2.c5().c().ag())
						{
							if ((((n5)nt.db()).z() > 1 && ((n5)nt2.db()).z() == 1) || (((n5)nt.db()).z() > 1 && ((n5)nt2.db()).z() > 1 && i == ((n5)nt2.db()).z() + nt2.d1() - 1))
							{
								if (((n5)nt2.db()).z() > 1 && i == ((n5)nt2.db()).z() + nt2.d1() - 1)
								{
									nt2.c5().c().b(true);
								}
								x = this.d(nt, nt2, false);
							}
							else if ((((n5)nt.db()).z() == 1 && ((n5)nt2.db()).z() > 1) || (((n5)nt.db()).z() > 1 && ((n5)nt2.db()).z() > 1 && i == ((n5)nt.db()).z() + nt.d1() - 1))
							{
								if (((n5)nt.db()).z() > 1 && i == ((n5)nt.db()).z() + nt.d1() - 1)
								{
									nt.c5().c().a(true);
								}
								x = this.c(nt, nt2, false);
							}
							else if (((n5)nt.db()).z() > 1 && ((n5)nt2.db()).z() > 1)
							{
								if (nt.d1() + ((n5)nt.db()).z() < nt2.d1() + ((n5)nt2.db()).z())
								{
									x = this.c(nt, nt2, true);
								}
								else
								{
									x = this.d(nt, nt2, true);
								}
							}
							if (x5.d(nt2.c5().c().ab(), x))
							{
								nt2.c5().c().g(x);
							}
							if (x5.d(nt.c5().c().ae(), x))
							{
								nt.c5().c().h(x);
							}
						}
					}
				}
			}
		}

		// Token: 0x060017B3 RID: 6067 RVA: 0x000FD7A0 File Offset: 0x000FC7A0
		private x5 d(nt A_0, nt A_1, bool A_2)
		{
			x5 x = x5.c();
			ft a_ = A_0.c5().c().s();
			Color a_2 = A_0.c5().c().q();
			if (A_0.c5().c().s() == ft.j || A_1.c5().c().o() == ft.j)
			{
				A_1.c5().c().c(x);
				A_1.c5().c().c(ft.j);
			}
			else
			{
				if (A_0.c5().c().s() != ft.a)
				{
					if (x5.c(A_0.c5().c().r(), A_1.c5().c().n()))
					{
						x = x5.a(x5.b(A_0.c5().c().r()) / 2f);
					}
					else if (x5.d(A_0.c5().c().r(), A_1.c5().c().n()) || A_0.c5().c().s() < A_1.c5().c().o())
					{
						x = x5.a(x5.b(A_1.c5().c().n()) / 2f);
						a_ = A_1.c5().c().o();
						a_2 = A_1.c5().c().m();
					}
					else if (A_0.c5().c().s() >= A_1.c5().c().o())
					{
						x = x5.a(x5.b(A_0.c5().c().r()) / 2f);
					}
				}
				else if (A_1.c5().c().o() != ft.a)
				{
					x = x5.a(x5.b(A_1.c5().c().n()) / 2f);
					a_ = A_1.c5().c().o();
					a_2 = A_1.c5().c().m();
				}
				A_1.c5().c().g(x);
				A_1.c5().c().g(a_);
				A_1.c5().c().g(a_2);
			}
			if (A_2)
			{
				A_1.c5().c().b(true);
			}
			return x;
		}

		// Token: 0x060017B4 RID: 6068 RVA: 0x000FDA54 File Offset: 0x000FCA54
		private x5 c(nt A_0, nt A_1, bool A_2)
		{
			x5 x = x5.c();
			ft a_ = A_0.c5().c().s();
			Color a_2 = A_0.c5().c().q();
			if (A_0.c5().c().s() == ft.j || A_1.c5().c().o() == ft.j)
			{
				A_0.c5().c().d(x5.c());
				A_0.c5().c().h(x5.c());
			}
			else
			{
				if (A_0.c5().c().s() != ft.a)
				{
					if (x5.c(A_0.c5().c().r(), A_1.c5().c().n()))
					{
						x = x5.a(x5.b(A_0.c5().c().r()) / 2f);
					}
					else if (x5.d(A_0.c5().c().r(), A_1.c5().c().n()) || A_0.c5().c().s() < A_1.c5().c().o())
					{
						x = x5.a(x5.b(A_1.c5().c().n()) / 2f);
						a_ = A_1.c5().c().o();
						a_2 = A_1.c5().c().m();
					}
					else if (A_0.c5().c().s() >= A_1.c5().c().o())
					{
						x = x5.a(x5.b(A_0.c5().c().r()) / 2f);
					}
				}
				else if (A_1.c5().c().o() != ft.a)
				{
					x = x5.a(x5.b(A_1.c5().c().n()) / 2f);
					a_ = A_1.c5().c().o();
					a_2 = A_1.c5().c().m();
				}
				A_0.c5().c().h(x);
				A_0.c5().c().h(a_);
				A_0.c5().c().h(a_2);
			}
			if (A_2)
			{
				A_0.c5().c().a(true);
			}
			return x;
		}

		// Token: 0x060017B5 RID: 6069 RVA: 0x000FDD10 File Offset: 0x000FCD10
		private void b()
		{
			for (int i = 0; i < this.c; i++)
			{
				for (int j = 0; j < this.a.Length - 1; j++)
				{
					nt nt = (nt)this.a[j][i];
					nt nt2 = (nt)this.a[j + 1][i];
					bool flag = false;
					if (nt != null && nt2 != null)
					{
						x5 x = x5.c();
						if (!nt.c5().c().aj() || !nt2.c5().c().ai())
						{
							if ((((n5)nt.db()).y() > 1 && ((n5)nt2.db()).y() == 1) || (((n5)nt.db()).y() > 1 && ((n5)nt2.db()).y() > 1 && (i == ((n5)nt2.db()).y() + nt2.h() - 1 || nt.h() + ((n5)nt.db()).y() > nt2.h() + ((n5)nt2.db()).y())))
							{
								if (((n5)nt2.db()).y() > 1 && (i == ((n5)nt2.db()).y() + nt2.h() - 1 || nt.h() + ((n5)nt.db()).y() > nt2.h() + ((n5)nt2.db()).y()))
								{
									nt2.c5().c().c(true);
								}
								x = this.b(nt, nt2, true);
								flag = true;
							}
							else if ((((n5)nt.db()).y() == 1 && ((n5)nt2.db()).y() > 1) || (((n5)nt.db()).y() > 1 && ((n5)nt2.db()).y() > 1 && (i == ((n5)nt.db()).y() + nt.h() - 1 || nt.h() + ((n5)nt.db()).y() < nt2.h() + ((n5)nt2.db()).y())))
							{
								if (((n5)nt.db()).y() > 1 && (i == ((n5)nt.db()).y() + nt.h() - 1 || nt.h() + ((n5)nt.db()).y() < nt2.h() + ((n5)nt2.db()).y()))
								{
									nt.c5().c().d(true);
								}
								x = this.a(nt, nt2, true);
								flag = true;
							}
							else if (((n5)nt.db()).y() > 1 && ((n5)nt2.db()).y() > 1)
							{
								if (nt.h() + ((n5)nt.db()).y() < nt2.h() + ((n5)nt2.db()).y())
								{
									x = this.a(nt, nt2, true);
								}
								else
								{
									x = this.b(nt, nt2, true);
								}
								flag = true;
							}
							if (flag)
							{
								if (x5.c(nt2.c5().c().ak(), x))
								{
									nt2.c5().c().i(x);
								}
								if (x5.d(nt2.c5().c().al(), x))
								{
									nt2.c5().c().j(x);
								}
								if (x5.c(nt.c5().c().ak(), x))
								{
									nt.c5().c().i(x);
								}
								if (x5.d(nt.c5().c().al(), x))
								{
									nt.c5().c().j(x);
								}
								if (x5.d(nt2.c5().c().v(), x))
								{
									nt2.c5().c().e(x);
								}
								if (x5.d(nt.c5().c().y(), x))
								{
									nt.c5().c().f(x);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060017B6 RID: 6070 RVA: 0x000FE230 File Offset: 0x000FD230
		private x5 b(nt A_0, nt A_1, bool A_2)
		{
			x5 x = x5.c();
			ft a_ = A_0.c5().c().k();
			Color a_2 = A_0.c5().c().i();
			if (A_0.c5().c().k() == ft.j || A_1.c5().c().g() == ft.j)
			{
				A_1.c5().c().a(ft.j);
				A_1.c5().c().e(ft.j);
			}
			else
			{
				if (A_0.c5().c().k() != ft.a)
				{
					if (x5.c(A_0.c5().c().j(), A_1.c5().c().f()))
					{
						x = x5.a(x5.b(A_0.c5().c().j()) / 2f);
					}
					else if (x5.d(A_0.c5().c().j(), A_1.c5().c().f()) || A_0.c5().c().k() < A_1.c5().c().g())
					{
						x = x5.a(x5.b(A_1.c5().c().f()) / 2f);
						a_ = A_1.c5().c().g();
						a_2 = A_1.c5().c().e();
					}
					else if (A_0.c5().c().k() >= A_1.c5().c().g())
					{
						x = x5.a(x5.b(A_0.c5().c().j()) / 2f);
					}
				}
				else if (A_1.c5().c().g() != ft.a)
				{
					x = x5.a(x5.b(A_1.c5().c().f()) / 2f);
					a_ = A_1.c5().c().g();
					a_2 = A_1.c5().c().e();
				}
				A_1.c5().c().e(x);
				A_1.c5().c().e(a_);
				A_1.c5().c().e(a_2);
				A_0.c5().c().f(a_);
			}
			if (A_2)
			{
				A_1.c5().c().c(true);
			}
			return x;
		}

		// Token: 0x060017B7 RID: 6071 RVA: 0x000FE4F4 File Offset: 0x000FD4F4
		private x5 a(nt A_0, nt A_1, bool A_2)
		{
			x5 x = x5.c();
			ft a_ = A_0.c5().c().k();
			Color a_2 = A_0.c5().c().i();
			if (A_0.c5().c().k() == ft.j || A_1.c5().c().g() == ft.j)
			{
				A_0.c5().c().b(x);
				A_0.c5().c().f(ft.j);
			}
			else
			{
				if (A_0.c5().c().k() != ft.a)
				{
					if (x5.c(A_0.c5().c().j(), A_1.c5().c().f()))
					{
						x = x5.a(x5.b(A_0.c5().c().j()) / 2f);
					}
					else if (x5.d(A_0.c5().c().j(), A_1.c5().c().f()) || A_0.c5().c().k() < A_1.c5().c().g())
					{
						x = x5.a(x5.b(A_1.c5().c().f()) / 2f);
						a_ = A_1.c5().c().g();
						a_2 = A_1.c5().c().e();
					}
					else if (A_0.c5().c().k() >= A_1.c5().c().g())
					{
						x = x5.a(x5.b(A_0.c5().c().j()) / 2f);
					}
				}
				else if (A_1.c5().c().g() != ft.a)
				{
					x = x5.a(x5.b(A_1.c5().c().f()) / 2f);
					a_ = A_1.c5().c().g();
					a_2 = A_1.c5().c().e();
				}
				A_0.c5().c().f(a_2);
				A_0.c5().c().f(a_);
				A_0.c5().c().f(x);
				A_1.c5().c().e(a_);
			}
			if (A_2)
			{
				A_0.c5().c().d(true);
			}
			return x;
		}

		// Token: 0x060017B8 RID: 6072 RVA: 0x000FE7B8 File Offset: 0x000FD7B8
		private void a()
		{
			List<kz> list = this.b.g();
			if (list != null)
			{
				bool a_ = false;
				for (int i = 0; i < list.Count; i++)
				{
					nu nu = (nu)list[i];
					int num = nu.b();
					for (int j = 0; j < this.a.Length; j++)
					{
						nt nt = (nt)this.a[j][num];
						if (nt.h() == num)
						{
							this.h(nt, nu, a_);
						}
						if (nt.h() + ((n5)nt.db()).y() - 1 == num)
						{
							this.g(nt, nu, a_);
						}
						if (j == 0)
						{
							this.f(nt, nu, a_);
						}
						if (j == this.a.Length - 1)
						{
							this.e(nt, nu, a_);
						}
					}
				}
			}
		}

		// Token: 0x060017B9 RID: 6073 RVA: 0x000FE8E0 File Offset: 0x000FD8E0
		private void h(kz A_0, kz A_1, bool A_2)
		{
			if (A_1.c5().c().o() == ft.j)
			{
				A_0.c5().c().c(x5.c());
				A_0.c5().c().c(ft.j);
			}
			else if (A_0.c5().c().o() != ft.a)
			{
				if (x5.d(A_0.c5().c().n(), A_1.c5().c().n()))
				{
					this.d(A_0, A_1, A_2);
				}
				else if (x5.h(A_0.c5().c().n(), A_1.c5().c().n()) && A_0.c5().c().o() < A_1.c5().c().o())
				{
					this.d(A_0, A_1, A_2);
				}
			}
			else if (A_1.c5().c().o() != ft.a)
			{
				this.d(A_0, A_1, A_2);
			}
			else
			{
				A_0.c5().c().c(x5.c());
			}
		}

		// Token: 0x060017BA RID: 6074 RVA: 0x000FEA28 File Offset: 0x000FDA28
		private void g(kz A_0, kz A_1, bool A_2)
		{
			if (A_1.c5().c().s() == ft.j)
			{
				A_0.c5().c().d(x5.c());
				A_0.c5().c().d(ft.j);
			}
			else if (A_0.c5().c().s() != ft.a)
			{
				if (x5.d(A_0.c5().c().r(), A_1.c5().c().r()))
				{
					this.c(A_0, A_1, A_2);
				}
				else if (x5.h(A_0.c5().c().r(), A_1.c5().c().r()) && A_0.c5().c().s() < A_1.c5().c().s())
				{
					this.c(A_0, A_1, A_2);
				}
			}
			else if (A_1.c5().c().s() != ft.a)
			{
				this.c(A_0, A_1, A_2);
			}
			else
			{
				A_0.c5().c().d(x5.c());
			}
		}

		// Token: 0x060017BB RID: 6075 RVA: 0x000FEB70 File Offset: 0x000FDB70
		private void f(kz A_0, kz A_1, bool A_2)
		{
			if (A_1.c5().c().g() == ft.j)
			{
				A_0.c5().c().a(x5.c());
				A_0.c5().c().a(ft.j);
			}
			else if (A_0.c5().c().g() != ft.a)
			{
				if (x5.d(A_0.c5().c().f(), A_1.c5().c().f()))
				{
					this.b(A_0, A_1, A_2);
				}
				else if (x5.h(A_0.c5().c().f(), A_1.c5().c().f()) && A_0.c5().c().g() < A_1.c5().c().g())
				{
					this.b(A_0, A_1, A_2);
				}
			}
			else if (A_1.c5().c().g() != ft.a)
			{
				this.b(A_0, A_1, A_2);
			}
			else
			{
				A_0.c5().c().a(x5.c());
			}
		}

		// Token: 0x060017BC RID: 6076 RVA: 0x000FECB8 File Offset: 0x000FDCB8
		private void e(kz A_0, kz A_1, bool A_2)
		{
			if (A_1.c5().c().k() == ft.j)
			{
				A_0.c5().c().b(x5.c());
				A_0.c5().c().b(ft.j);
			}
			else if (A_0.c5().c().k() != ft.a)
			{
				if (x5.d(A_0.c5().c().j(), A_1.c5().c().j()))
				{
					this.a(A_0, A_1, A_2);
				}
				else if (x5.h(A_0.c5().c().j(), A_1.c5().c().j()) && A_0.c5().c().k() < A_1.c5().c().k())
				{
					this.a(A_0, A_1, A_2);
				}
			}
			else if (A_1.c5().c().k() != ft.a)
			{
				this.a(A_0, A_1, A_2);
			}
			else
			{
				A_0.c5().c().b(x5.c());
			}
		}

		// Token: 0x060017BD RID: 6077 RVA: 0x000FEE00 File Offset: 0x000FDE00
		private void d(kz A_0, kz A_1, bool A_2)
		{
			if (A_2)
			{
				x5 a_ = x5.a(x5.b(A_1.c5().c().n()) / 2f);
				A_0.c5().c().g(a_);
				A_0.c5().c().g(A_1.c5().c().o());
				A_0.c5().c().g(A_1.c5().c().m());
			}
			else
			{
				A_0.c5().c().c(A_1.c5().c().n());
				A_0.c5().c().c(A_1.c5().c().o());
				A_0.c5().c().c(A_1.c5().c().m());
				A_0.c5().c().b(A_1.c5().c().ap() + 1);
			}
		}

		// Token: 0x060017BE RID: 6078 RVA: 0x000FEF1C File Offset: 0x000FDF1C
		private void c(kz A_0, kz A_1, bool A_2)
		{
			if (A_2)
			{
				x5 a_ = x5.a(x5.b(A_1.c5().c().r()) / 2f);
				A_0.c5().c().h(A_1.c5().c().s());
				A_0.c5().c().h(A_1.c5().c().q());
				A_0.c5().c().h(a_);
			}
			else
			{
				A_0.c5().c().d(A_1.c5().c().r());
				A_0.c5().c().d(A_1.c5().c().s());
				A_0.c5().c().d(A_1.c5().c().q());
				A_0.c5().c().a(A_1.c5().c().ao() + 1);
			}
		}

		// Token: 0x060017BF RID: 6079 RVA: 0x000FF038 File Offset: 0x000FE038
		private void b(kz A_0, kz A_1, bool A_2)
		{
			if (A_2)
			{
				x5 a_ = x5.a(x5.b(A_1.c5().c().f()) / 2f);
				A_0.c5().c().e(A_1.c5().c().g());
				A_0.c5().c().e(A_1.c5().c().e());
				A_0.c5().c().e(a_);
			}
			else
			{
				A_0.c5().c().a(A_1.c5().c().f());
				A_0.c5().c().a(A_1.c5().c().g());
				A_0.c5().c().a(A_1.c5().c().e());
				A_0.c5().c().c(A_1.c5().c().aq() + 1);
			}
		}

		// Token: 0x060017C0 RID: 6080 RVA: 0x000FF154 File Offset: 0x000FE154
		private void a(kz A_0, kz A_1, bool A_2)
		{
			if (A_2)
			{
				x5 a_ = x5.a(x5.b(A_1.c5().c().j()) / 2f);
				A_0.c5().c().f(A_1.c5().c().k());
				A_0.c5().c().f(A_1.c5().c().i());
				A_0.c5().c().f(a_);
			}
			else
			{
				A_0.c5().c().b(A_1.c5().c().j());
				A_0.c5().c().b(A_1.c5().c().k());
				A_0.c5().c().b(A_1.c5().c().i());
				A_0.c5().c().d(A_1.c5().c().ar() + 1);
			}
		}

		// Token: 0x060017C1 RID: 6081 RVA: 0x000FF270 File Offset: 0x000FE270
		internal void k()
		{
			this.a();
			this.j();
			this.i();
			this.c();
			this.b();
			this.h();
		}

		// Token: 0x060017C2 RID: 6082 RVA: 0x000FF2A0 File Offset: 0x000FE2A0
		internal void l()
		{
			for (int i = 0; i < this.a.Length; i++)
			{
				int j = 0;
				while (j < this.a[i].Length)
				{
					if (this.a[i][j] != null && !this.a[i][j].b5())
					{
						x5 a_ = (x5)this.b.b6()[j];
						int num = ((n5)this.a[i][j].db()).y();
						if (num > 1)
						{
							for (int k = j + 1; k < j + num; k++)
							{
								if (k < this.b.b6().Count)
								{
									a_ = x5.f(a_, (x5)this.b.b6()[k]);
								}
							}
						}
						((nt)this.a[i][j]).a(a_);
						j += num;
					}
					else
					{
						j++;
					}
				}
			}
		}

		// Token: 0x060017C3 RID: 6083 RVA: 0x000FF3DC File Offset: 0x000FE3DC
		internal nh a(nv A_0)
		{
			return new nh(this.a, this.c, A_0);
		}

		// Token: 0x04000ABD RID: 2749
		private kz[][] a = null;

		// Token: 0x04000ABE RID: 2750
		private nv b = null;

		// Token: 0x04000ABF RID: 2751
		private int c = 0;
	}
}
