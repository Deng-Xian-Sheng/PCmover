using System;
using System.Collections.Generic;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000217 RID: 535
	internal class nx : k0
	{
		// Token: 0x060018CC RID: 6348 RVA: 0x00105CAC File Offset: 0x00104CAC
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060018CD RID: 6349 RVA: 0x00105CC4 File Offset: 0x00104CC4
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060018CE RID: 6350 RVA: 0x00105CD4 File Offset: 0x00104CD4
		internal override nw dv()
		{
			return this.b;
		}

		// Token: 0x060018CF RID: 6351 RVA: 0x00105CEC File Offset: 0x00104CEC
		internal override void dw(nw A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060018D0 RID: 6352 RVA: 0x00105CF8 File Offset: 0x00104CF8
		internal override int dg()
		{
			return 1946;
		}

		// Token: 0x060018D1 RID: 6353 RVA: 0x00105D10 File Offset: 0x00104D10
		internal override bool de()
		{
			return true;
		}

		// Token: 0x060018D2 RID: 6354 RVA: 0x00105D24 File Offset: 0x00104D24
		internal override k0 dd()
		{
			nx nx = new nx();
			nx.dw(this.dv());
			nx.ab(base.ci());
			nx.aa(base.ch());
			nx.a8(this.dp());
			nx.a7(this.dn());
			return nx;
		}

		// Token: 0x060018D3 RID: 6355 RVA: 0x00105D80 File Offset: 0x00104D80
		internal override int d1()
		{
			return this.c;
		}

		// Token: 0x060018D4 RID: 6356 RVA: 0x00105D98 File Offset: 0x00104D98
		internal override void d2(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060018D5 RID: 6357 RVA: 0x00105DA4 File Offset: 0x00104DA4
		internal override int d3()
		{
			return this.d;
		}

		// Token: 0x060018D6 RID: 6358 RVA: 0x00105DBC File Offset: 0x00104DBC
		internal override void d4(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060018D7 RID: 6359 RVA: 0x00105DC8 File Offset: 0x00104DC8
		internal x5 b()
		{
			return this.e;
		}

		// Token: 0x060018D8 RID: 6360 RVA: 0x00105DE0 File Offset: 0x00104DE0
		internal void a(x5 A_0)
		{
			this.e = A_0;
		}

		// Token: 0x060018D9 RID: 6361 RVA: 0x00105DEC File Offset: 0x00104DEC
		internal void a(ref x5[] A_0, ref f9[] A_1)
		{
			if (base.n() != null)
			{
				mu mu = base.n().c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					mr mr = ms.l().a();
					int num = ms.l().c();
					int num2 = 0;
					while (mr != null && mr.b() != null)
					{
						if (((n5)mr.b().db()).y() == 1)
						{
							int num3 = ((nt)mr.b()).h();
							if (mr.b().c5().am() != null)
							{
								x5 x = mr.b().c5().am().Value;
								if (mr.b().c5().ap() == i2.b && x5.c(x, x5.c()))
								{
									if (num3 < A_1.Length)
									{
										if (A_1[num3] != null)
										{
											if (x5.d(A_1[num3].c(), x))
											{
												A_1[num3].a(x);
												A_1[num3].a(true);
											}
										}
										else
										{
											A_1[num3] = new f9(x);
											A_1[num3].a(true);
										}
									}
								}
								else if (A_0.Length > num3 && x5.d(A_0[num3], x))
								{
									A_0[num3] = x;
								}
							}
							else if (((nt)mr.b()).g() != null)
							{
								x5 x = ((nt)mr.b()).g().a().c();
								if (((nt)mr.b()).g().a().a())
								{
									if (A_1[num3] != null)
									{
										if (x5.d(A_1[num3].c(), x))
										{
											A_1[num3].a(x);
											A_1[num3].a(true);
										}
									}
									else
									{
										A_1[num3] = new f9(x);
										A_1[num3].a(true);
									}
								}
								else if (x5.d(A_0[num3], x))
								{
									A_0[num3] = x;
								}
							}
						}
						int num4 = ((n5)mr.b().db()).y();
						if (num2 + num4 <= num)
						{
							num2 += num4;
						}
						else
						{
							num2++;
						}
						mr = mr.c();
					}
					mu = mu.b();
				}
			}
		}

		// Token: 0x060018DA RID: 6362 RVA: 0x0010611C File Offset: 0x0010511C
		internal x5[] a(int A_0, x5 A_1)
		{
			x5[] array = new x5[A_0];
			if (base.n() != null)
			{
				mu mu = base.n().c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					mr mr = ms.l().a();
					int num = 0;
					while (mr != null && mr.b() != null)
					{
						if (mr.b().c5().am() != null)
						{
							if (mr.b().c5().ap() == i2.b)
							{
								array[num] = x5.a(x5.b(A_1) * x5.b(x5.a(mr.b().c5().am().Value, 100)));
							}
							else
							{
								array[num] = mr.b().c5().am().Value;
							}
							mr.b().c5().c().n();
							bool flag = 1 == 0;
							x5[] array2 = array;
							int num2 = num;
							array2[num2] = x5.f(array2[num2], mr.b().c5().c().n());
							mr.b().c5().c().r();
							flag = (1 == 0);
							x5[] array3 = array;
							int num3 = num;
							array3[num3] = x5.f(array3[num3], mr.b().c5().c().r());
							x5[] array4 = array;
							int num4 = num;
							array4[num4] = x5.f(array4[num4], mr.b().c5().f().d());
							x5[] array5 = array;
							int num5 = num;
							array5[num5] = x5.f(array5[num5], mr.b().c5().f().b());
						}
						int num6 = ((n5)mr.b().db()).y();
						num += num6;
						mr = mr.c();
					}
					mu = mu.b();
				}
			}
			return array;
		}

		// Token: 0x060018DB RID: 6363 RVA: 0x0010637C File Offset: 0x0010537C
		internal override x5 dh()
		{
			x5 x = x5.c();
			x5 a_ = x5.c();
			x = x5.f(x, this.b.e().Value);
			if (base.n() != null)
			{
				mu mu = base.n().c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					mr mr = ms.l().a();
					while (mr != null && mr.b() != null)
					{
						mr.b().dw(this.dv());
						a_ = mr.b().dh();
						x = x5.f(x, x5.f(a_, this.b.e().Value));
						mr = mr.c();
					}
					mu = mu.b();
				}
			}
			this.a8(x);
			return x;
		}

		// Token: 0x060018DC RID: 6364 RVA: 0x0010648C File Offset: 0x0010548C
		internal override void di()
		{
			x5 a_ = x5.c();
			x5 a_2 = x5.c();
			a_ = x5.f(a_, this.b.e().Value);
			if (base.n() != null)
			{
				mu mu = base.n().c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					mr mr = ms.l().a();
					while (mr != null && mr.b() != null)
					{
						mr.b().dw(this.dv());
						mr.b().di();
						a_2 = mr.b().dn();
						a_ = x5.f(a_, x5.f(a_2, this.b.e().Value));
						mr = mr.c();
					}
					mu = mu.b();
				}
			}
			this.a7(a_);
		}

		// Token: 0x060018DD RID: 6365 RVA: 0x001065A4 File Offset: 0x001055A4
		internal override kz dj(x5 A_0, x5 A_1)
		{
			if (base.co())
			{
				this.a();
			}
			return base.f(A_0, A_1);
		}

		// Token: 0x060018DE RID: 6366 RVA: 0x001065D4 File Offset: 0x001055D4
		private void a()
		{
			if (base.n() != null)
			{
				int num = 0;
				mu mu = base.n().c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					mr mr = ms.l().a();
					while (mr != null && mr.b() != null)
					{
						mr = mr.c();
						num++;
						if (num >= base.cm())
						{
							ms.c(mr);
						}
					}
					mu = mu.b();
				}
			}
		}

		// Token: 0x060018DF RID: 6367 RVA: 0x00106680 File Offset: 0x00105680
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			x5 x = x5.c();
			if (this.b.e() != null)
			{
				x = this.b.e().Value;
			}
			A_2 = x5.f(A_2, this.e);
			if (base.n() != null)
			{
				this.a(A_0, x5.f(A_1, x), A_2, base.n().c());
				mu mu = base.n().c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					ms.v(x);
					ms.a(A_0, A_1, A_2);
					mu = mu.b();
				}
			}
		}

		// Token: 0x060018E0 RID: 6368 RVA: 0x00106748 File Offset: 0x00105748
		private void a(PageWriter A_0, x5 A_1, x5 A_2, mu A_3)
		{
			x5 x = base.aq();
			x5 x2 = base.ar();
			if (A_3 != null && A_3.a() != null)
			{
				ms ms = A_3.a();
				if (ms.l() != null)
				{
					mr mr = ms.l().a();
					if (mr.b() != null)
					{
						if (mr.b().c5().c().o() != ft.a && mr.b().c5().c().o() != ft.j)
						{
							A_1 = x5.f(A_1, mr.b().c5().c().n());
							x = x5.e(x, mr.b().c5().c().n());
						}
						if (mr.b().c5().c().g() != ft.a && mr.b().c5().c().g() != ft.j)
						{
							A_2 = x5.f(A_2, mr.b().c5().c().f());
							x2 = x5.e(x2, mr.b().c5().c().f());
						}
						while (mr.c() != null)
						{
							mr = mr.c();
						}
						if (mr.b().c5().c().s() != ft.a && mr.b().c5().c().s() != ft.j)
						{
							x = x5.e(x, mr.b().c5().c().r());
						}
						if (mr.b().c5().c().k() != ft.a && mr.b().c5().c().k() != ft.j)
						{
							x2 = x5.e(x2, mr.b().c5().c().j());
						}
					}
				}
			}
			if (base.w() != null)
			{
				base.w().a(base.c5(), A_0, A_1, A_2, x, x2);
			}
		}

		// Token: 0x060018E1 RID: 6369 RVA: 0x00106998 File Offset: 0x00105998
		internal List<ne> c()
		{
			mt mt = base.n();
			List<ne> list = new List<ne>();
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
							k0 k = (k0)mr.b();
							int num = k.dg();
							if (num == 3034 || num == 3418)
							{
								int num2 = ((n5)k.db()).z();
								if (num2 > 1)
								{
									list.Add(new ne(k));
								}
							}
							mr = mr.c();
						}
					}
					mu = mu.b();
				}
			}
			if (list.Count > 1)
			{
				list.Sort();
			}
			return list;
		}

		// Token: 0x060018E2 RID: 6370 RVA: 0x00106ACC File Offset: 0x00105ACC
		internal override kz dm()
		{
			nx nx = new nx();
			nx.j(this.dr());
			nx.dc(this.db().du());
			nx.a((lk)base.c5().du());
			nx.dw((nw)this.dv().du());
			nx.d2(this.c);
			nx.d4(this.d);
			if (base.n() != null)
			{
				nx.c(base.n().p());
			}
			return nx;
		}

		// Token: 0x04000B0A RID: 2826
		private new n5 a = new n5();

		// Token: 0x04000B0B RID: 2827
		private new nw b;

		// Token: 0x04000B0C RID: 2828
		private new int c = 0;

		// Token: 0x04000B0D RID: 2829
		private new int d = 0;

		// Token: 0x04000B0E RID: 2830
		private new x5 e = x5.c();
	}
}
