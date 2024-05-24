using System;
using System.Collections;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x020002A1 RID: 673
	internal class rp
	{
		// Token: 0x06001E03 RID: 7683 RVA: 0x0012FB08 File Offset: 0x0012EB08
		internal rp(x5 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001E04 RID: 7684 RVA: 0x0012FB28 File Offset: 0x0012EB28
		internal void a(xx A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06001E05 RID: 7685 RVA: 0x0012FB34 File Offset: 0x0012EB34
		internal xg a()
		{
			return this.b;
		}

		// Token: 0x06001E06 RID: 7686 RVA: 0x0012FB4C File Offset: 0x0012EB4C
		internal void a(xg A_0, xg A_1, xg A_2, bool A_3, x5 A_4, bool A_5)
		{
			if (A_0.k() != null && A_0.k().a() > 0)
			{
				A_1.a(A_0.k());
				A_2.a(A_0.k());
				x5 x = x5.a();
				x5 a_ = A_4;
				int num = 0;
				bool flag = false;
				bool flag2 = false;
				w3 w;
				ArrayList arrayList;
				for (;;)
				{
					num++;
					w = new w3();
					arrayList = new ArrayList();
					rp.a(w, A_4, A_0);
					this.a(w, A_4, A_3, A_1, arrayList, A_5);
					if ((w.a == null && !flag) || flag2)
					{
						break;
					}
					x = A_0.k().a(w, A_4, flag);
					if (!x5.g(x, A_4))
					{
						break;
					}
					if (x5.c(x, a_) && x5.d(A_0.d(), this.c))
					{
						A_4 = x5.c();
						A_1.a(A_4);
						A_2.a(x5.e(A_0.d(), A_4));
						flag2 = true;
					}
					else if (num > 4)
					{
						A_4 = A_0.d();
						flag = true;
						A_1.a(A_4);
						A_2.a(x5.e(A_0.d(), A_4));
					}
					else
					{
						A_4 = x;
						flag = true;
						A_1.a(A_4);
						A_2.a(x5.e(A_0.d(), A_4));
					}
				}
				rp.a(w, A_4, arrayList, A_0, A_1, A_2, A_3, A_5);
			}
			else
			{
				w3 w = new w3();
				ArrayList arrayList = new ArrayList();
				rp.a(w, A_4, A_0);
				this.a(w, A_4, A_3, A_1, arrayList, A_5);
				rp.a(w, A_4, arrayList, A_0, A_1, A_2, A_3, A_5);
			}
		}

		// Token: 0x06001E07 RID: 7687 RVA: 0x0012FD30 File Offset: 0x0012ED30
		internal static void a(w3 A_0, x5 A_1, xg A_2)
		{
			for (xx xx = A_2.h(); xx != null; xx = xx.b())
			{
				if (x5.d(xx.a().b7(), A_1))
				{
					A_0.a(xx, xx.a().b7());
					if (x5.d(xx.a().b8(), A_1))
					{
						A_0.a(xx, xx.a().b8());
					}
				}
				if (xx.a().gf())
				{
					xx.a().ge(A_2);
				}
			}
			if (A_2.k() != null && A_2.k().a() > 0)
			{
				A_2.k().a(A_2);
			}
		}

		// Token: 0x06001E08 RID: 7688 RVA: 0x0012FE0C File Offset: 0x0012EE0C
		internal void a(w3 A_0, x5 A_1, bool A_2, xg A_3, ArrayList A_4, bool A_5)
		{
			x5 a_ = this.a(A_0, A_1, A_2, A_3, A_4);
			if (x5.c(a_, x5.a()))
			{
				A_0.a(a_);
			}
			if (A_4.Count > 0)
			{
				if (A_4.Count == 1)
				{
					A_0.a(A_4[0]);
				}
				else
				{
					for (int i = 0; i < A_4.Count; i++)
					{
						A_0.a(A_4[i]);
					}
				}
			}
			x5 a_2 = x5.a();
			if (A_5)
			{
				for (ww ww = A_0.a; ww != null; ww = ww.c)
				{
					if (ww.b.a().gf())
					{
						if (!((xn)ww.b.a()).a(A_0))
						{
							if (x5.h(a_2, x5.a()) || x5.c(a_2, ww.b.a().b7()))
							{
								a_2 = ww.b.a().b7();
							}
							A_0.a(ww);
							if (ww.c != null && ww.b == ww.c.b)
							{
								ww = ww.c;
								A_0.a(ww);
							}
						}
					}
				}
			}
			if (x5.c(a_2, x5.a()))
			{
				A_0.a(a_2);
			}
		}

		// Token: 0x06001E09 RID: 7689 RVA: 0x0012FFC8 File Offset: 0x0012EFC8
		internal static void a(w3 A_0, x5 A_1, ArrayList A_2, xg A_3, xg A_4, xg A_5, bool A_6, bool A_7)
		{
			xx xx = A_3.h();
			A_0.a();
			ww ww = A_0.b();
			x5 x = x5.b();
			x5 x2 = x5.b();
			while (xx != null)
			{
				xx xx2 = xx.b();
				xx.a(null);
				if (ww != null && ww.b == xx)
				{
					ww = A_0.b();
					if (x5.g(ww.a, xx.a().b8()))
					{
						x5 a_ = xx.a().b8();
						PageElement pageElement;
						if (x5.h(ww.a, w0.e))
						{
							pageElement = xx.a().fb(x5.e(A_1, xx.a().b7()));
							if (pageElement != null)
							{
								ww.a = x5.e(x5.e(a_, xx.a().b7()), x5.e(pageElement.b8(), pageElement.b7()));
							}
							else
							{
								ww.a = x5.c();
							}
						}
						else
						{
							pageElement = xx.a().fb(ww.a);
						}
						if (pageElement != null)
						{
							A_5.a(pageElement);
							if (x5.c(a_, A_1) && !pageElement.gf() && x5.c(x, x5.f(ww.a, xx.a().b7())))
							{
								x = x5.f(ww.a, xx.a().b7());
							}
						}
					}
					A_4.b(xx);
					ww = A_0.b();
				}
				else
				{
					if (x5.c(x2, xx.a().b7()))
					{
						if (!rp.a(A_2, xx))
						{
							x2 = xx.a().b7();
						}
					}
					A_5.b(xx);
				}
				xx = xx2;
			}
			if (A_4.h() == null)
			{
				A_5.a(A_3.d());
			}
			else if (A_5.k() != null)
			{
				A_5.k().a(A_4.d());
			}
			if (A_4.h() != null || (A_6 && A_0.a == null))
			{
				x5 a_2 = x5.c();
				wz a_3 = new wz(x5.a(), x5.a());
				if (A_2.Count > 0)
				{
					a_3 = rp.a(A_2);
				}
				if (A_5.h() != null && x5.g(x, x5.b()) && x5.c(x, a_2) && x5.d(x, x2))
				{
					if (A_5.i() != null)
					{
						A_5.i().d(x);
					}
					if (A_5.j() != null)
					{
						A_5.j().d(x);
					}
					if (A_5.k() != null)
					{
						A_5.k().b(rp.a(a_3, x, A_5.k().b()));
					}
					for (xx = A_5.h(); xx != null; xx = xx.b())
					{
						x5 x3 = rp.a(a_3, x, xx.a().b7());
						if (x5.d(xx.a().b7(), a_2))
						{
							xx.a().ca(x5.a(x5.b(xx.a().b7()) * -1f));
						}
						else if (x5.g(xx.a().b7(), a_2))
						{
							if (x5.a(xx.a().b7(), x3))
							{
								xx.a().ca(x3);
							}
							else
							{
								xx.a().ca(xx.a().b7());
							}
						}
					}
					if (x5.c(a_3.a, x5.a()))
					{
						if (x5.c(a_3.a, x))
						{
							A_5.a(x5.f(x5.e(A_3.d(), x), x5.e(a_3.a, x)));
						}
						else
						{
							A_5.a(x5.f(x5.e(A_3.d(), x), x5.e(x, a_3.a)));
						}
					}
					else if (x5.c(x5.f(A_5.d(), x5.e(A_1, x)), a_2))
					{
						A_5.a(x5.f(A_5.d(), x5.e(A_1, x)));
					}
				}
				else
				{
					if (A_5.i() != null)
					{
						A_5.i().d(x2);
					}
					if (A_5.j() != null)
					{
						A_5.j().d(x2);
					}
					if (A_5.k() != null)
					{
						A_5.k().b(rp.a(a_3, x2, A_5.k().b()));
					}
					for (xx = A_5.h(); xx != null; xx = xx.b())
					{
						x5 x3 = rp.a(a_3, x2, xx.a().b7());
						if (x5.a(xx.a().b7(), x3))
						{
							xx.a().ca(x3);
						}
						else
						{
							xx.a().ca(xx.a().b7());
						}
					}
					if (x5.c(a_3.a, x5.a()))
					{
						if (x5.c(a_3.a, x2))
						{
							A_5.a(x5.f(x5.e(A_3.d(), x2), x5.e(a_3.a, x2)));
						}
						else
						{
							A_5.a(x5.f(x5.e(A_3.d(), x2), x5.e(x2, a_3.a)));
						}
					}
					else
					{
						A_5.a(x5.e(A_3.d(), x2));
					}
				}
				if (A_7)
				{
					xx = A_5.h();
					xx xx3 = null;
					while (xx != null)
					{
						if (xx.a().gf() && x5.h(xx.a().b7(), x5.c()))
						{
							if (!((xn)xx.a()).a(A_5))
							{
								if (xx == A_5.h())
								{
									A_5.a(xx.b());
								}
								else
								{
									xx3.a(xx.b());
								}
							}
						}
						xx3 = xx;
						xx = xx.b();
					}
				}
			}
		}

		// Token: 0x06001E0A RID: 7690 RVA: 0x00130714 File Offset: 0x0012F714
		private static x5 a(wz A_0, x5 A_1, x5 A_2)
		{
			x5 result;
			if (x5.h(A_0.a, x5.a()))
			{
				result = A_1;
			}
			else
			{
				result = (x5.a(A_2, A_0.b) ? A_0.a : A_1);
			}
			return result;
		}

		// Token: 0x06001E0B RID: 7691 RVA: 0x0013075C File Offset: 0x0012F75C
		private static wz a(ArrayList A_0)
		{
			wz result = new wz(((xx)A_0[0]).a().b7(), ((xx)A_0[0]).a().b8());
			for (int i = 1; i < A_0.Count; i++)
			{
				if (x5.c(result.a, ((xx)A_0[i]).a().b7()))
				{
					result.a = ((xx)A_0[i]).a().b7();
				}
				if (x5.c(result.b, ((xx)A_0[i]).a().b8()))
				{
					result.b = ((xx)A_0[i]).a().b8();
				}
			}
			return result;
		}

		// Token: 0x06001E0C RID: 7692 RVA: 0x0013084C File Offset: 0x0012F84C
		private static bool a(ArrayList A_0, xx A_1)
		{
			bool result;
			if (A_0.Count == 0)
			{
				result = false;
			}
			else if (A_0.Count == 1)
			{
				result = (A_1 == A_0[0]);
			}
			else
			{
				for (int i = 0; i < A_0.Count; i++)
				{
					if (A_0[i] == A_1)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06001E0D RID: 7693 RVA: 0x001308C0 File Offset: 0x0012F8C0
		private x5 a(w3 A_0, x5 A_1, bool A_2, xg A_3, ArrayList A_4)
		{
			x5 x = x5.a();
			A_0.a();
			ww ww;
			while ((ww = A_0.b()) != null)
			{
				if (ww.c != null && ww.b == ww.c.b)
				{
					A_0.b();
				}
				else
				{
					xx xx = ww.b;
					x5 x2 = xx.a().fa(x5.e(A_1, xx.a().b7()));
					if (x5.h(x2, w0.a))
					{
						throw new GeneratorException("Splitting operation is not implemented for this element");
					}
					if (x5.h(x2, w0.c) || x5.h(x2, w0.d))
					{
						if (A_2)
						{
							if (xx.a().cb() == 239)
							{
								xs xs = (xs)xx.a();
								if (xs.c() != null && xs.d() > 0)
								{
									A_0.b(xx, w0.e);
									A_0.b();
									continue;
								}
							}
							x5 a_ = x5.e(xx.a().b8(), xx.a().b7());
							if (x5.c(a_, this.c) && ((this.a == null && x5.h(xx.a().b7(), x5.c())) || (this.a != null && x5.h(this.a.a().b7(), xx.a().b7()))))
							{
								A_0.b(xx, xx.a().b8());
								A_0.b();
							}
							else
							{
								if (x5.c(a_, this.c) && (this.a == null || (this.a != null && x5.c(this.a.a().b7(), xx.a().b7()))))
								{
									this.b = A_3;
									this.a = xx;
								}
								if (x5.h(x, x5.a()) || x5.c(x, xx.a().b7()))
								{
									x = xx.a().b7();
								}
							}
						}
						else if (x5.h(x2, w0.d))
						{
							A_4.Add(xx);
						}
						else if (x5.h(x, x5.a()) || x5.c(x, xx.a().b7()))
						{
							x = xx.a().b7();
						}
					}
					else
					{
						if (x5.h(x2, w0.b))
						{
							x2 = x5.e(A_1, xx.a().b7());
						}
						A_0.b(xx, x2);
						A_0.b();
					}
				}
			}
			return x;
		}

		// Token: 0x04000D49 RID: 3401
		private xx a = null;

		// Token: 0x04000D4A RID: 3402
		private xg b = null;

		// Token: 0x04000D4B RID: 3403
		private x5 c;
	}
}
