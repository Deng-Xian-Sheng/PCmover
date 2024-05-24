using System;
using System.Collections;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x020005A5 RID: 1445
	internal class al0
	{
		// Token: 0x0600395C RID: 14684 RVA: 0x001ECD4C File Offset: 0x001EBD4C
		internal al0(x5 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600395D RID: 14685 RVA: 0x001ECD6C File Offset: 0x001EBD6C
		internal void a(am6 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600395E RID: 14686 RVA: 0x001ECD78 File Offset: 0x001EBD78
		internal amk a()
		{
			return this.b;
		}

		// Token: 0x0600395F RID: 14687 RVA: 0x001ECD90 File Offset: 0x001EBD90
		internal void a(amk A_0, amk A_1, amk A_2, bool A_3, x5 A_4, bool A_5)
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
				alx alx;
				ArrayList arrayList;
				for (;;)
				{
					num++;
					alx = new alx();
					arrayList = new ArrayList();
					al0.a(alx, A_4, A_0);
					this.a(alx, A_4, A_3, A_1, arrayList, A_5);
					if ((alx.a == null && !flag) || flag2)
					{
						break;
					}
					x = A_0.k().a(alx, A_4, flag);
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
				al0.a(alx, A_4, arrayList, A_0, A_1, A_2, A_3, A_5);
			}
			else
			{
				alx alx = new alx();
				ArrayList arrayList = new ArrayList();
				al0.a(alx, A_4, A_0);
				this.a(alx, A_4, A_3, A_1, arrayList, A_5);
				al0.a(alx, A_4, arrayList, A_0, A_1, A_2, A_3, A_5);
			}
		}

		// Token: 0x06003960 RID: 14688 RVA: 0x001ECF74 File Offset: 0x001EBF74
		internal static void a(alx A_0, x5 A_1, amk A_2)
		{
			for (am6 am = A_2.h(); am != null; am = am.b())
			{
				if (x5.d(am.a().b7(), A_1))
				{
					A_0.a(am, am.a().b7());
					if (x5.d(am.a().b8(), A_1))
					{
						A_0.a(am, am.a().b8());
					}
				}
				if (am.a().gf())
				{
					am.a().nq(A_2);
				}
			}
			if (A_2.k() != null && A_2.k().a() > 0)
			{
				A_2.k().a(A_2);
			}
		}

		// Token: 0x06003961 RID: 14689 RVA: 0x001ED050 File Offset: 0x001EC050
		internal void a(alx A_0, x5 A_1, bool A_2, amk A_3, ArrayList A_4, bool A_5)
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
				for (alu alu = A_0.a; alu != null; alu = alu.c)
				{
					if (alu.b.a().gf())
					{
						if (!((amw)alu.b.a()).a(A_0))
						{
							if (x5.h(a_2, x5.a()) || x5.c(a_2, alu.b.a().b7()))
							{
								a_2 = alu.b.a().b7();
							}
							A_0.a(alu);
							if (alu.c != null && alu.b == alu.c.b)
							{
								alu = alu.c;
								A_0.a(alu);
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

		// Token: 0x06003962 RID: 14690 RVA: 0x001ED20C File Offset: 0x001EC20C
		internal static void a(alx A_0, x5 A_1, ArrayList A_2, amk A_3, amk A_4, amk A_5, bool A_6, bool A_7)
		{
			am6 am = A_3.h();
			A_0.a();
			alu alu = A_0.b();
			x5 x = x5.b();
			x5 x2 = x5.b();
			while (am != null)
			{
				am6 am2 = am.b();
				am.a(null);
				if (alu != null && alu.b == am)
				{
					alu = A_0.b();
					if (x5.g(alu.a, am.a().b8()))
					{
						x5 a_ = am.a().b8();
						PageElement pageElement;
						if (x5.h(alu.a, al1.e))
						{
							pageElement = am.a().fb(x5.e(A_1, am.a().b7()));
							if (pageElement != null)
							{
								alu.a = x5.e(x5.e(a_, am.a().b7()), x5.e(pageElement.b8(), pageElement.b7()));
							}
							else
							{
								alu.a = x5.c();
							}
						}
						else
						{
							pageElement = am.a().fb(alu.a);
						}
						if (pageElement != null)
						{
							A_5.a(pageElement);
							if (x5.c(a_, A_1) && !pageElement.gf() && x5.c(x, x5.f(alu.a, am.a().b7())))
							{
								x = x5.f(alu.a, am.a().b7());
							}
						}
					}
					A_4.b(am);
					alu = A_0.b();
				}
				else
				{
					if (x5.c(x2, am.a().b7()))
					{
						if (!al0.a(A_2, am))
						{
							x2 = am.a().b7();
						}
					}
					A_5.b(am);
				}
				am = am2;
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
				aly a_3 = new aly(x5.a(), x5.a());
				if (A_2.Count > 0)
				{
					a_3 = al0.a(A_2);
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
						A_5.k().b(al0.a(a_3, x, A_5.k().b()));
					}
					for (am = A_5.h(); am != null; am = am.b())
					{
						x5 x3 = al0.a(a_3, x, am.a().b7());
						if (x5.d(am.a().b7(), a_2))
						{
							am.a().ca(x5.a(x5.b(am.a().b7()) * -1f));
						}
						else if (x5.g(am.a().b7(), a_2))
						{
							if (x5.a(am.a().b7(), x3))
							{
								am.a().ca(x3);
							}
							else
							{
								am.a().ca(am.a().b7());
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
						A_5.k().b(al0.a(a_3, x2, A_5.k().b()));
					}
					for (am = A_5.h(); am != null; am = am.b())
					{
						x5 x3 = al0.a(a_3, x2, am.a().b7());
						if (x5.a(am.a().b7(), x3))
						{
							am.a().ca(x3);
						}
						else
						{
							am.a().ca(am.a().b7());
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
					am = A_5.h();
					am6 am3 = null;
					while (am != null)
					{
						if (am.a().gf() && x5.h(am.a().b7(), x5.c()))
						{
							if (!((amw)am.a()).a(A_5))
							{
								if (am == A_5.h())
								{
									A_5.a(am.b());
								}
								else
								{
									am3.a(am.b());
								}
							}
						}
						am3 = am;
						am = am.b();
					}
				}
			}
		}

		// Token: 0x06003963 RID: 14691 RVA: 0x001ED958 File Offset: 0x001EC958
		private static x5 a(aly A_0, x5 A_1, x5 A_2)
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

		// Token: 0x06003964 RID: 14692 RVA: 0x001ED9A0 File Offset: 0x001EC9A0
		private static aly a(ArrayList A_0)
		{
			aly result = new aly(((am6)A_0[0]).a().b7(), ((am6)A_0[0]).a().b8());
			for (int i = 1; i < A_0.Count; i++)
			{
				if (x5.c(result.a, ((am6)A_0[i]).a().b7()))
				{
					result.a = ((am6)A_0[i]).a().b7();
				}
				if (x5.c(result.b, ((am6)A_0[i]).a().b8()))
				{
					result.b = ((am6)A_0[i]).a().b8();
				}
			}
			return result;
		}

		// Token: 0x06003965 RID: 14693 RVA: 0x001EDA90 File Offset: 0x001ECA90
		private static bool a(ArrayList A_0, am6 A_1)
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

		// Token: 0x06003966 RID: 14694 RVA: 0x001EDB04 File Offset: 0x001ECB04
		private x5 a(alx A_0, x5 A_1, bool A_2, amk A_3, ArrayList A_4)
		{
			x5 x = x5.a();
			A_0.a();
			alu alu;
			while ((alu = A_0.b()) != null)
			{
				if (alu.c != null && alu.b == alu.c.b)
				{
					A_0.b();
				}
				else
				{
					am6 am = alu.b;
					x5 x2 = am.a().fa(x5.e(A_1, am.a().b7()));
					if (x5.h(x2, al1.a))
					{
						throw new GeneratorException("Splitting operation is not implemented for this element");
					}
					if (x5.h(x2, al1.c) || x5.h(x2, al1.d))
					{
						if (A_2)
						{
							if (am.a().cb() == 239)
							{
								am1 am2 = (am1)am.a();
								if (am2.c() != null && am2.d() > 0)
								{
									A_0.b(am, al1.e);
									A_0.b();
									continue;
								}
							}
							x5 a_ = x5.e(am.a().b8(), am.a().b7());
							if (x5.c(a_, this.c) && ((this.a == null && x5.h(am.a().b7(), x5.c())) || (this.a != null && x5.h(this.a.a().b7(), am.a().b7()))))
							{
								A_0.b(am, am.a().b8());
								A_0.b();
							}
							else
							{
								if (x5.c(a_, this.c) && (this.a == null || (this.a != null && x5.c(this.a.a().b7(), am.a().b7()))))
								{
									this.b = A_3;
									this.a = am;
								}
								if (x5.h(x, x5.a()) || x5.c(x, am.a().b7()))
								{
									x = am.a().b7();
								}
							}
						}
						else if (x5.h(x2, al1.d))
						{
							A_4.Add(am);
						}
						else if (x5.h(x, x5.a()) || x5.c(x, am.a().b7()))
						{
							x = am.a().b7();
						}
					}
					else
					{
						if (x5.h(x2, al1.b))
						{
							x2 = x5.e(A_1, am.a().b7());
						}
						A_0.b(am, x2);
						A_0.b();
					}
				}
			}
			return x;
		}

		// Token: 0x04001B52 RID: 6994
		private am6 a = null;

		// Token: 0x04001B53 RID: 6995
		private amk b = null;

		// Token: 0x04001B54 RID: 6996
		private x5 c;
	}
}
