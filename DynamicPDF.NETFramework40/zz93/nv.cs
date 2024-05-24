using System;
using System.Collections.Generic;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000215 RID: 533
	internal class nv : k0
	{
		// Token: 0x06001882 RID: 6274 RVA: 0x00103598 File Offset: 0x00102598
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001883 RID: 6275 RVA: 0x001035B0 File Offset: 0x001025B0
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001884 RID: 6276 RVA: 0x001035C0 File Offset: 0x001025C0
		internal override nw dv()
		{
			return this.b;
		}

		// Token: 0x06001885 RID: 6277 RVA: 0x001035D8 File Offset: 0x001025D8
		internal override void dw(nw A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001886 RID: 6278 RVA: 0x001035E4 File Offset: 0x001025E4
		internal n7 c()
		{
			return this.c;
		}

		// Token: 0x06001887 RID: 6279 RVA: 0x001035FC File Offset: 0x001025FC
		internal void a(n7 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001888 RID: 6280 RVA: 0x00103608 File Offset: 0x00102608
		internal override bool de()
		{
			return this.l;
		}

		// Token: 0x06001889 RID: 6281 RVA: 0x00103620 File Offset: 0x00102620
		internal override void df(bool A_0)
		{
			this.l = A_0;
		}

		// Token: 0x0600188A RID: 6282 RVA: 0x0010362C File Offset: 0x0010262C
		internal bool d()
		{
			return this.k;
		}

		// Token: 0x0600188B RID: 6283 RVA: 0x00103644 File Offset: 0x00102644
		internal void a(bool A_0)
		{
			this.k = A_0;
		}

		// Token: 0x0600188C RID: 6284 RVA: 0x00103650 File Offset: 0x00102650
		internal override k0 dd()
		{
			nv nv = new nv();
			nv.b = this.b;
			nv.a(this.c());
			nv.a(true);
			nv.ab(base.ci());
			nv.aa(base.ch());
			nv.a8(this.dp());
			nv.a7(this.dn());
			return nv;
		}

		// Token: 0x0600188D RID: 6285 RVA: 0x001036C0 File Offset: 0x001026C0
		internal n6 e()
		{
			return this.d;
		}

		// Token: 0x0600188E RID: 6286 RVA: 0x001036D8 File Offset: 0x001026D8
		internal void a(n6 A_0)
		{
			this.d = A_0;
		}

		// Token: 0x0600188F RID: 6287 RVA: 0x001036E4 File Offset: 0x001026E4
		internal x5 f()
		{
			return this.e;
		}

		// Token: 0x06001890 RID: 6288 RVA: 0x001036FC File Offset: 0x001026FC
		internal List<kz> g()
		{
			return this.f;
		}

		// Token: 0x06001891 RID: 6289 RVA: 0x00103714 File Offset: 0x00102714
		internal void a(List<kz> A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06001892 RID: 6290 RVA: 0x00103720 File Offset: 0x00102720
		internal Dictionary<int, x5> h()
		{
			return this.g;
		}

		// Token: 0x06001893 RID: 6291 RVA: 0x00103738 File Offset: 0x00102738
		internal int i()
		{
			return this.h;
		}

		// Token: 0x06001894 RID: 6292 RVA: 0x00103750 File Offset: 0x00102750
		internal bool j()
		{
			return this.j;
		}

		// Token: 0x06001895 RID: 6293 RVA: 0x00103768 File Offset: 0x00102768
		internal void b(bool A_0)
		{
			this.j = A_0;
		}

		// Token: 0x06001896 RID: 6294 RVA: 0x00103774 File Offset: 0x00102774
		internal override int dg()
		{
			return 144937050;
		}

		// Token: 0x06001897 RID: 6295 RVA: 0x0010378C File Offset: 0x0010278C
		private Dictionary<int, x5> b(mt A_0)
		{
			Dictionary<int, x5> dictionary = new Dictionary<int, x5>();
			int num = 0;
			if (A_0 != null)
			{
				mu mu = A_0.c();
				while (mu != null && mu.a() != null)
				{
					if (mu.a().l() != null)
					{
						ms ms = mu.a();
						int num2 = ms.l().a().b().dg();
						if (num2 <= 442866842)
						{
							if (num2 != 1946)
							{
								if (num2 == 442866842)
								{
									goto IL_94;
								}
							}
							else if (ms.l().a().b().c0())
							{
								int key = ms.l().a().b().d1();
								if (!dictionary.ContainsKey(key))
								{
									dictionary.Add(key, ms.l().a().b().ar());
									num++;
								}
							}
						}
						else if (num2 == 718642778 || num2 == 889490394)
						{
							goto IL_94;
						}
						goto IL_177;
						IL_94:
						Dictionary<int, x5> dictionary2 = this.b(((k0)ms.l().a().b()).n());
						foreach (int key2 in dictionary2.Keys)
						{
							dictionary.Add(key2, dictionary2[key2]);
							num++;
						}
					}
					IL_177:
					mu = mu.b();
				}
			}
			return dictionary;
		}

		// Token: 0x06001898 RID: 6296 RVA: 0x0010394C File Offset: 0x0010294C
		private x5 a(mt A_0, ref int A_1)
		{
			x5 x = x5.c();
			if (A_0 != null)
			{
				mu mu = A_0.c();
				while (mu != null && mu.a() != null)
				{
					if (mu.a().l() != null && mu.a().l().a().b() != null)
					{
						ms ms = mu.a();
						int num = ms.l().a().b().dg();
						if (num <= 442866842)
						{
							if (num != 1946)
							{
								if (num == 442866842)
								{
									goto IL_AA;
								}
							}
							else
							{
								A_1++;
								k0 k = (k0)ms.l().a().b();
								if (k.c0())
								{
									if (k.n() != null && k.n().c().a() != null)
									{
										if (((k0)ms.l().a().b()).n().c().a().l() != null || (mu.b() != null && mu.b().a() != null))
										{
											x = x5.f(x, ms.n());
										}
									}
								}
							}
						}
						else if (num == 718642778 || num == 889490394)
						{
							goto IL_AA;
						}
						goto IL_192;
						IL_AA:
						x = x5.f(x, this.a(((k0)ms.l().a().b()).n(), ref A_1));
					}
					IL_192:
					mu = mu.b();
				}
			}
			return x;
		}

		// Token: 0x06001899 RID: 6297 RVA: 0x00103B18 File Offset: 0x00102B18
		private x5 a(int A_0, x5 A_1, float A_2)
		{
			A_1 = x5.f(A_1, x5.a((float)A_0 * A_2));
			A_1 = x5.f(A_1, x5.a(A_2));
			return A_1;
		}

		// Token: 0x0600189A RID: 6298 RVA: 0x00103B4C File Offset: 0x00102B4C
		private int a(mt A_0)
		{
			bool flag = false;
			if (A_0 != null)
			{
				mu mu = A_0.c();
				while (mu != null && mu.a() != null)
				{
					if (mu.a().l() != null)
					{
						ms ms = mu.a();
						int num = ms.l().a().b().dg();
						if (num <= 442866842)
						{
							if (num != 1946)
							{
								if (num == 442866842)
								{
									goto IL_B2;
								}
							}
							else
							{
								this.h = ms.l().a().b().d1();
								flag = true;
							}
						}
						else
						{
							if (num == 718642778)
							{
								goto IL_B2;
							}
							if (num == 889490394)
							{
								this.h = this.a(((k0)ms.l().a().b()).n());
								flag = true;
							}
						}
						goto IL_FE;
						IL_B2:
						this.h = this.a(((k0)ms.l().a().b()).n());
						flag = true;
					}
					IL_FE:
					if (flag)
					{
						break;
					}
					mu = mu.b();
				}
			}
			return this.h;
		}

		// Token: 0x0600189B RID: 6299 RVA: 0x00103C94 File Offset: 0x00102C94
		private x5 c(x5 A_0)
		{
			x5 a_ = this.e;
			a_ = x5.e(a_, x5.f(base.c5().c().n(), base.c5().c().r()));
			a_ = x5.e(a_, x5.f(base.c5().e().d(), base.c5().e().b()));
			if (base.c5().g())
			{
				a_ = x5.e(a_, x5.f(base.c5().f().d(), base.c5().f().b()));
			}
			return x5.e(a_, x5.a(x5.b(A_0) * 2f));
		}

		// Token: 0x0600189C RID: 6300 RVA: 0x00103D60 File Offset: 0x00102D60
		private x5 b(x5 A_0)
		{
			if (base.c5().g())
			{
				A_0 = x5.f(A_0, base.c5().f().d());
			}
			if (!this.b.d())
			{
				if (base.c5().c().o() != ft.a)
				{
					A_0 = x5.f(A_0, base.c5().c().n());
				}
			}
			else
			{
				A_0 = x5.f(A_0, base.c5().c().ab());
			}
			return A_0;
		}

		// Token: 0x0600189D RID: 6301 RVA: 0x00103DFC File Offset: 0x00102DFC
		private void b(PageWriter A_0, x5 A_1, x5 A_2, x5[] A_3, x5 A_4)
		{
			if (base.c5().az() != g9.b)
			{
				A_2 = x5.f(A_2, base.c5().e().a());
				if (this.b.h() != il.b)
				{
					this.a(A_0, A_1, A_2, A_3, A_4);
				}
				else
				{
					this.g = this.b(base.n());
					this.h = this.a(base.n());
					if (base.ad() != null)
					{
						lh a_ = new lh(this, base.ad());
						if (base.c5().g())
						{
							A_1 = x5.f(A_1, base.c5().f().d());
							A_2 = x5.f(A_2, base.c5().f().a());
						}
						this.a(A_0, a_, A_1, A_2, A_3);
					}
				}
			}
		}

		// Token: 0x0600189E RID: 6302 RVA: 0x00103EF4 File Offset: 0x00102EF4
		private void a(PageWriter A_0, x5 A_1, x5 A_2, x5[] A_3, x5 A_4)
		{
			A_2 = x5.f(A_2, A_3[0]);
			A_4 = x5.e(x5.e(x5.e(x5.e(base.ar(), A_3[0]), A_3[1]), base.c5().e().a()), base.c5().e().c());
			base.c5().c().a(A_0, A_1, A_2, this.e, A_4);
		}

		// Token: 0x0600189F RID: 6303 RVA: 0x00103F8C File Offset: 0x00102F8C
		private void a(PageWriter A_0, lh A_1, x5 A_2, x5 A_3, x5[] A_4)
		{
			A_0.SetGraphicsMode();
			A_3 = x5.f(A_3, A_4[0]);
			x5 x = x5.e(x5.e(base.ar(), base.c5().e().a()), base.c5().e().c());
			x = x5.e(x, x5.e(A_4[0], A_4[1]));
			int a_ = base.ad().d();
			int count = this.g.Count;
			if (this.g != null && this.g.Count > 0)
			{
				x5 x2 = x5.c();
				foreach (int key in this.g.Keys)
				{
					x2 = x5.f(x2, this.g[key]);
				}
				if (x5.c(x2, x5.c()))
				{
					x = x2;
				}
			}
			lt lt = new lt(A_1, base.b6(), a_, count, this.h);
			lt.a(A_0, A_2, A_3, this.e, x);
		}

		// Token: 0x060018A0 RID: 6304 RVA: 0x001040F4 File Offset: 0x001030F4
		private void a(PageWriter A_0, x5 A_1, x5 A_2, x5[] A_3)
		{
			x5 x = A_1;
			x5 x2 = A_2;
			x5 x3 = this.e;
			x5 x4 = x5.e(x5.e(base.ar(), base.c5().e().c()), base.c5().e().a());
			if (this.b.h() != il.b)
			{
				if (base.c5().c().o() != ft.a)
				{
					x = x5.f(x, base.c5().c().n());
					x3 = x5.e(x3, base.c5().c().n());
				}
				if (base.c5().c().g() != ft.a)
				{
					x2 = x5.f(x2, base.c5().c().f());
					x4 = x5.e(x4, base.c5().c().f());
				}
				if (base.c5().c().s() != ft.a)
				{
					x3 = x5.e(x3, base.c5().c().r());
				}
				if (base.c5().c().k() != ft.a)
				{
					x4 = x5.e(x4, base.c5().c().j());
				}
			}
			else
			{
				x = x5.f(x, base.c5().c().ab());
				x3 = x5.e(x3, base.c5().c().ab());
				x2 = x5.f(x2, base.c5().c().v());
				x4 = x5.e(x4, base.c5().c().v());
				x3 = x5.e(x3, base.c5().c().ae());
				x4 = x5.e(x4, base.c5().c().y());
			}
			x2 = x5.f(x2, A_3[0]);
			x4 = x5.e(x5.e(x4, A_3[0]), A_3[1]);
			base.c5().ay().a(A_0, x, x2, x3, x4);
			if (base.w() != null)
			{
				if (x5.h(this.e, x5.a(1.5)))
				{
					if (base.c5().am() != null)
					{
						x3 = base.c5().am().Value;
					}
					else
					{
						x3 = base.aq();
					}
				}
				base.w().a(this.de());
				base.w().a(base.c5(), A_0, x, x2, x3, x4);
			}
		}

		// Token: 0x060018A1 RID: 6305 RVA: 0x001043C8 File Offset: 0x001033C8
		private void b()
		{
			this.i = this.a();
			this.a(base.n(), this.i);
			for (int i = 0; i < this.i.Count; i++)
			{
				base.b6()[this.i[i]] = x5.a(-1.5);
			}
		}

		// Token: 0x060018A2 RID: 6306 RVA: 0x00104444 File Offset: 0x00103444
		private List<int> a()
		{
			List<int> list = new List<int>();
			if (this.f != null)
			{
				for (int i = 0; i < this.f.Count; i++)
				{
					object obj = this.f[i];
					nu nu = (nu)obj;
					if (nu.c5().az() == g9.c)
					{
						n5 n = (n5)nu.db();
						int num = n.y();
						int num2 = nu.b();
						for (int j = 0; j < num; j++)
						{
							list.Add(num2 + j);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x060018A3 RID: 6307 RVA: 0x00104504 File Offset: 0x00103504
		private void a(mt A_0, List<int> A_1)
		{
			if (A_0 != null)
			{
				mu mu = A_0.c();
				while (mu != null && mu.a() != null)
				{
					if (mu.a().l() != null)
					{
						ms ms = mu.a();
						int num = ms.l().a().b().dg();
						if (num <= 442866842)
						{
							if (num != 1946)
							{
								if (num == 442866842)
								{
									goto IL_85;
								}
							}
							else if (ms.l().a().b().c5().az() == g9.c)
							{
								ms.a(null);
							}
							else
							{
								k0 k = (k0)ms.l().a().b();
								if (k.n() != null)
								{
									this.a(k.n().c(), A_1);
								}
							}
						}
						else if (num == 718642778 || num == 889490394)
						{
							goto IL_85;
						}
						goto IL_148;
						IL_85:
						if (ms.l().a().b().c5().az() == g9.c)
						{
							ms.a(null);
						}
						else
						{
							this.a(((k0)ms.l().a().b()).n(), A_1);
						}
					}
					IL_148:
					mu = mu.b();
				}
			}
		}

		// Token: 0x060018A4 RID: 6308 RVA: 0x0010467C File Offset: 0x0010367C
		private void a(mu A_0, List<int> A_1)
		{
			if (A_0 != null)
			{
				ms ms = A_0.a();
				if (ms != null && ms.l() != null)
				{
					mr mr = ms.l().a();
					while (mr != null && mr.b() != null)
					{
						if (A_1.Contains(((nt)mr.b()).h()))
						{
							ms.c(mr);
						}
						else if (((nt)mr.b()).c5().az() == g9.c)
						{
							ms.c(mr);
						}
						if (mr != null)
						{
							mr = mr.c();
						}
					}
				}
			}
		}

		// Token: 0x060018A5 RID: 6309 RVA: 0x00104744 File Offset: 0x00103744
		private x5 a(x5 A_0)
		{
			gn gn = ((n5)this.dr().db()).r();
			if (this.dr().dg() == 141185593 && gn == gn.c)
			{
				this.a.a(gn.c);
			}
			return x5.f(A_0, base.cc());
		}

		// Token: 0x060018A6 RID: 6310 RVA: 0x001047A8 File Offset: 0x001037A8
		private void a(PageWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			if (base.n() != null)
			{
				mu mu = base.n().c();
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				x5 a_ = this.c(A_3);
				while (mu != null && mu.a() != null)
				{
					if (mu.a().l() != null)
					{
						ms ms = mu.a();
						int num4 = ms.l().a().b().dg();
						if (num4 <= 258605815)
						{
							if (num4 == 1946)
							{
								goto IL_AE;
							}
							if (num4 == 258605815)
							{
								if (num2 != 0)
								{
									if (num3 == 0)
									{
										A_2 = x5.f(A_2, A_4);
										if (base.c5().g())
										{
											A_2 = x5.f(A_2, base.c5().f().c());
										}
										if (!this.b.d())
										{
											A_2 = x5.f(A_2, base.c5().c().j());
										}
									}
									num3++;
								}
								ms.a(A_0, A_1, A_2);
							}
						}
						else if (num4 == 442866842 || num4 == 718642778 || num4 == 889490394)
						{
							goto IL_AE;
						}
						goto IL_18D;
						IL_AE:
						num2++;
						if (num == 0)
						{
							A_1 = this.b(A_1);
							num++;
						}
						ms.v(A_3);
						ms.l().a().b().l(a_);
						ms.a(A_0, A_1, A_2);
					}
					IL_18D:
					mu = mu.b();
				}
			}
		}

		// Token: 0x060018A7 RID: 6311 RVA: 0x00104968 File Offset: 0x00103968
		private void a(PageWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4, x5[] A_5)
		{
			if (this.f != null)
			{
				int num = 0;
				x5 x = x5.f(A_1, A_3);
				x5 x2 = x5.f(x5.f(A_2, A_4), A_5[0]);
				x5 a_ = x5.e(x5.e(x5.e(base.ar(), x5.b(A_4, 2)), A_5[0]), A_5[1]);
				if (this.b.h() != il.b)
				{
					if (base.c5().c().o() != ft.a)
					{
						x = x5.f(x, base.c5().c().n());
					}
					if (base.c5().c().g() != ft.a)
					{
						x2 = x5.f(x2, base.c5().c().f());
						a_ = x5.e(a_, base.c5().c().f());
					}
					if (base.c5().c().k() != ft.a)
					{
						a_ = x5.e(a_, base.c5().c().j());
					}
				}
				bool flag = false;
				foreach (kz kz in this.f)
				{
					nu nu = (nu)kz;
					nu.dw(this.b);
					nu.a(a_);
					int num2 = ((n5)nu.db()).y();
					for (int i = 0; i < num2; i++)
					{
						nu.b((x5)base.b6()[num]);
						nu.dk(A_0, x, x2);
						x = x5.f(x, x5.f((x5)base.b6()[num], A_3));
						num++;
						if (num >= base.b6().Count)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
			}
		}

		// Token: 0x060018A8 RID: 6312 RVA: 0x00104BC0 File Offset: 0x00103BC0
		internal x5[] k()
		{
			x5[] array = new x5[2];
			x5 x = x5.c();
			x5 x2 = x5.c();
			int num = 0;
			if (base.n() != null)
			{
				mu mu = base.n().c();
				while (mu != null && mu.a() != null)
				{
					if (mu.a().l() != null && mu.a().l().a().b() != null)
					{
						ms ms = mu.a();
						int num2 = ms.l().a().b().dg();
						if (num2 <= 258605815)
						{
							if (num2 == 1946)
							{
								goto IL_CC;
							}
							if (num2 == 258605815)
							{
								if (num == 0)
								{
									x = x5.f(x, ms.n());
								}
								else
								{
									x2 = x5.f(x2, ms.n());
								}
							}
						}
						else if (num2 == 442866842 || num2 == 718642778 || num2 == 889490394)
						{
							goto IL_CC;
						}
						goto IL_100;
						IL_CC:
						num++;
					}
					IL_100:
					mu = mu.b();
				}
			}
			array[0] = x;
			array[1] = x2;
			return array;
		}

		// Token: 0x060018A9 RID: 6313 RVA: 0x00104D18 File Offset: 0x00103D18
		internal f9[] a(ref x5[] A_0, int A_1, x5 A_2)
		{
			f9[] result;
			if (this.dv().i() == "fixed")
			{
				A_0 = this.a(base.n(), A_1, A_2);
				result = null;
			}
			else
			{
				result = base.b(ref A_0, A_1, A_2);
			}
			return result;
		}

		// Token: 0x060018AA RID: 6314 RVA: 0x00104D64 File Offset: 0x00103D64
		internal x5[] a(mt A_0, int A_1, x5 A_2)
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
							if (num == 1946)
							{
								return ((nx)mr.b()).a(A_1, A_2);
							}
							if (num == 442866842)
							{
								goto IL_89;
							}
						}
						else if (num == 718642778 || num == 889490394)
						{
							goto IL_89;
						}
						mr = mr.c();
						continue;
						IL_89:
						return this.a(((k0)mr.b()).n(), A_1, A_2);
					}
					mu = mu.b();
				}
			}
			return null;
		}

		// Token: 0x060018AB RID: 6315 RVA: 0x00104E64 File Offset: 0x00103E64
		internal override x5 dh()
		{
			x5 a_ = base.al();
			x5 x = x5.c();
			x5 x2 = x5.c();
			if (x5.h(this.dp(), x5.c()))
			{
				if (this.b.i() == "fixed" && base.c5().am() != null)
				{
					this.a8(base.c5().am().Value);
				}
				else
				{
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
								x2 = mr.b().dh();
								if (x5.d(x, x2))
								{
									x = x2;
								}
								mr = mr.c();
							}
							mu = mu.b();
						}
					}
					if (base.c5().am() != null && base.c5().ap() != i2.b && x5.c(base.c5().am().Value, x))
					{
						this.a8(x5.f(base.c5().am().Value, a_));
					}
					else
					{
						this.a8(x5.f(x, a_));
					}
				}
			}
			return this.dp();
		}

		// Token: 0x060018AC RID: 6316 RVA: 0x00105044 File Offset: 0x00104044
		internal override void di()
		{
			x5 a_ = x5.c();
			x5 x = x5.c();
			x5 a_2 = base.al();
			if (x5.h(this.dn(), x5.c()))
			{
				if (this.b.i() == "fixed" && base.c5().am() != null)
				{
					this.a7(base.c5().am().Value);
				}
				else
				{
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
								x = mr.b().dn();
								if (x5.d(a_, x))
								{
									a_ = x;
								}
								mr = mr.c();
							}
							mu = mu.b();
						}
					}
					this.a7(x5.f(a_, a_2));
				}
			}
		}

		// Token: 0x060018AD RID: 6317 RVA: 0x001051B8 File Offset: 0x001041B8
		internal void d(x5 A_0)
		{
			this.m = true;
			if (base.ad().f() == null)
			{
				int num = base.ad().k();
				x5[] a_ = new x5[num];
				base.ad().a(this.a(ref a_, num, A_0));
				base.ad().a(a_);
				base.ad().b(A_0);
				this.b();
				if (this.b.h() == il.b)
				{
					base.ad().h().l();
				}
			}
			this.e = x5.c();
			x5 x = x5.c();
			if (this.b.e() != null)
			{
				x = this.b.e().Value;
			}
			this.e = x5.f(this.e, x);
			if (base.ch() && !base.ci())
			{
				for (int i = 0; i < base.b6().Count; i++)
				{
					if (!this.i.Contains(i))
					{
						if (x5.c(x5.f(this.e, (x5)base.b6()[i]), A_0))
						{
							base.b6()[i] = x5.e(x5.e(A_0, this.e), x5.b(x, 2));
							this.e = x5.f(this.e, x5.f((x5)base.b6()[i], x));
							base.o(i + 1);
							base.ad(true);
							break;
						}
						this.e = x5.f(this.e, x5.f((x5)base.b6()[i], x));
					}
				}
			}
			else
			{
				for (int i = 0; i < base.b6().Count; i++)
				{
					if (!this.i.Contains(i))
					{
						this.e = x5.f(this.e, x5.f((x5)base.b6()[i], x));
					}
				}
			}
			if (this.b.h() == il.b)
			{
				this.e = x5.f(this.e, base.c5().c().ab());
				this.e = x5.f(this.e, base.c5().c().ae());
			}
			else
			{
				if (base.c5().c().o() != ft.a)
				{
					this.e = x5.f(this.e, base.c5().c().n());
				}
				if (base.c5().c().s() != ft.a)
				{
					this.e = x5.f(this.e, base.c5().c().r());
				}
			}
			if (base.c5().g())
			{
				this.e = x5.f(this.e, x5.f(base.c5().f().d(), base.c5().f().b()));
			}
			if (x5.c(this.e, base.bi()))
			{
				base.ah(this.e);
			}
			base.ah(base.bi());
			if (base.c5().am() == null)
			{
				base.l(this.e);
			}
			this.a7(this.e);
		}

		// Token: 0x060018AE RID: 6318 RVA: 0x001055BC File Offset: 0x001045BC
		internal override kz dj(x5 A_0, x5 A_1)
		{
			if (!this.m && base.ad() != null)
			{
				this.d(A_0);
			}
			A_0 = base.aq();
			if (this.k && base.n() != null)
			{
				base.n().o();
			}
			return base.f(A_0, A_1);
		}

		// Token: 0x060018AF RID: 6319 RVA: 0x00105628 File Offset: 0x00104628
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			if (!this.c3())
			{
				A_1 = this.a(A_1);
			}
			base.c5().c().g(base.s());
			base.c5().c().h(base.t());
			x5 a_ = x5.c();
			x5 x = x5.c();
			if (this.b.e() != null)
			{
				a_ = this.b.e().Value;
			}
			if (this.b.f() != null)
			{
				x = this.b.f().Value;
			}
			A_1 = x5.f(A_1, this.dc());
			x5[] array = this.k();
			x5 x2 = x5.e(x5.e(base.ar(), base.c5().e().a()), base.c5().e().c());
			this.a(A_0, A_1, A_2, array);
			this.a(A_0, A_1, A_2, a_, x, array);
			if (this.b.h() != il.b)
			{
				int a_2 = 0;
				x2 = this.a(base.n(), ref a_2);
				x2 = this.a(a_2, x2, x5.b(x));
			}
			this.a(A_0, A_1, A_2, a_, x);
			this.b(A_0, A_1, A_2, array, x2);
		}

		// Token: 0x060018B0 RID: 6320 RVA: 0x00105798 File Offset: 0x00104798
		internal override kz dm()
		{
			nv nv = new nv();
			nv.j(this.dr());
			nv.dc(this.db().du());
			nv.a((lk)base.c5().du());
			nv.dw((nw)this.dv().du());
			nv.a(this.c);
			nv.a(this.d);
			nv.a(this.f);
			nv.b(this.j);
			nv.df(this.l);
			nv.a(base.ad().a(nv));
			if (base.n() != null)
			{
				nv.c(base.n().p());
			}
			return nv;
		}

		// Token: 0x04000AF2 RID: 2802
		private new n5 a = new n5();

		// Token: 0x04000AF3 RID: 2803
		private new nw b = new nw();

		// Token: 0x04000AF4 RID: 2804
		private new n7 c;

		// Token: 0x04000AF5 RID: 2805
		private new n6 d;

		// Token: 0x04000AF6 RID: 2806
		private new x5 e;

		// Token: 0x04000AF7 RID: 2807
		private new List<kz> f = null;

		// Token: 0x04000AF8 RID: 2808
		private Dictionary<int, x5> g = null;

		// Token: 0x04000AF9 RID: 2809
		private int h = 0;

		// Token: 0x04000AFA RID: 2810
		private List<int> i = new List<int>();

		// Token: 0x04000AFB RID: 2811
		private bool j = false;

		// Token: 0x04000AFC RID: 2812
		private new bool k = false;

		// Token: 0x04000AFD RID: 2813
		private bool l = true;

		// Token: 0x04000AFE RID: 2814
		private bool m = false;
	}
}
