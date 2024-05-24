using System;
using System.Collections;
using System.Collections.Generic;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001C9 RID: 457
	internal class lt
	{
		// Token: 0x0600133D RID: 4925 RVA: 0x000DAA30 File Offset: 0x000D9A30
		internal lt(lh A_0, Hashtable A_1, int A_2, int A_3, int A_4)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_3;
			this.d = A_2;
			this.e = A_4;
		}

		// Token: 0x0600133E RID: 4926 RVA: 0x000DAA60 File Offset: 0x000D9A60
		private void c(PageWriter A_0, x5 A_1, x5 A_2)
		{
			List<lg> list = this.a.k();
			x5 a_ = this.a(0, 0);
			x5 x = x5.f(A_1, x5.a(x5.b(a_) / 2f));
			int num = -1;
			x5 a_2 = A_2;
			x5[] array = this.a();
			for (int i = 0; i < list.Count; i++)
			{
				if (num > list[i].l())
				{
					A_1 = x;
				}
				A_1 = x;
				A_2 = this.a(a_2, list[i].i(), list[i].l());
				A_1 = x5.f(x, this.a(list[i].l() + 1));
				A_2 = x5.f(A_2, array[list[i].l()]);
				if (x5.g(list[i].a(), x5.c()) && list[i].o() != null)
				{
					switch (list[i].p())
					{
					case ft.b:
					case ft.e:
						this.b(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), x5.b(list[i].h()), list[i].o(), true);
						break;
					case ft.c:
					case ft.d:
						this.b(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), x5.b(list[i].h()), list[i].o(), false);
						break;
					case ft.f:
						this.d(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), x5.b(list[i].h()), list[i].o());
						break;
					case ft.g:
						this.b(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), x5.b(list[i].h()), list[i].o());
						break;
					case ft.h:
						this.h(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), x5.b(list[i].h()), list[i].o());
						break;
					case ft.i:
						this.f(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), x5.b(list[i].h()), list[i].o());
						break;
					}
				}
				num = list[i].l() + list[i].n() - 1;
			}
		}

		// Token: 0x0600133F RID: 4927 RVA: 0x000DADB8 File Offset: 0x000D9DB8
		private void b(PageWriter A_0, x5 A_1, x5 A_2)
		{
			List<lg> list = this.a.l();
			x5 x = A_1;
			int num = -1;
			int num2 = -1;
			x5 a_ = this.b();
			A_2 = x5.f(A_2, a_);
			x5 x2 = x5.a(x5.b(this.a(0, 0)) / 2f);
			x5 x3 = A_2;
			x5 x4 = x5.c();
			Hashtable hashtable = new Hashtable();
			x5[] array = new x5[this.d + 1];
			for (int i = 0; i < list.Count; i++)
			{
				float a_2 = x5.b(list[i].f());
				if (num > list[i].l())
				{
					A_1 = x;
				}
				x4 = list[i].b();
				if (num2 != list[i].i())
				{
					if (list[i].l() == 0)
					{
						hashtable.Add(i, x4);
					}
					A_2 = x3;
					A_2 = this.a(x3, list[i], list);
					if (list[i].l() == 0)
					{
						if (list[i].q())
						{
							A_1 = x5.e(x5.f(x, x2), x4);
						}
						else
						{
							A_1 = x5.f(x5.f(x, x2), x2);
							array[list[i].i()] = x5.a(x5.b(x2) * 2f);
						}
					}
					else if (list[i].q())
					{
						A_1 = x5.f(x5.f(x, x2), x4);
					}
					else
					{
						A_1 = x5.f(x5.f(x, x2), array[list[i].i()]);
					}
				}
				else
				{
					A_1 = x;
					if (list[i].q())
					{
						if (list[i].l() == 0)
						{
							A_1 = x5.e(x5.f(x, x2), x4);
						}
						else
						{
							A_1 = x5.f(x5.f(x, x2), array[list[i].i()]);
							A_1 = x5.e(A_1, this.a(list[i].i(), hashtable));
						}
					}
					else if (list[i].l() == 0)
					{
						A_1 = x5.f(x5.f(x, x2), x2);
						array[list[i].i()] = x5.a(x5.b(x2) * 2f);
					}
					else
					{
						A_1 = x5.f(x, array[list[i].i()]);
					}
				}
				if (list[i].l() > 0)
				{
					A_1 = x5.f(A_1, this.a(list[i].l()));
				}
				if (x5.g(list[i].a(), x5.c()) && list[i].o() != null)
				{
					switch (list[i].p())
					{
					case ft.b:
					case ft.e:
						this.a(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), a_2, list[i].o(), true);
						break;
					case ft.c:
					case ft.d:
						this.a(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), a_2, list[i].o(), false);
						break;
					case ft.f:
						this.c(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), a_2, list[i].o());
						break;
					case ft.g:
						this.a(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), a_2, list[i].o());
						break;
					case ft.h:
						this.g(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), a_2, list[i].o());
						break;
					case ft.i:
						this.e(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), a_2, list[i].o());
						break;
					}
				}
				num = list[i].l() + list[i].n() - 1;
				num2 = list[i].i();
			}
		}

		// Token: 0x06001340 RID: 4928 RVA: 0x000DB320 File Offset: 0x000DA320
		private void a(PageWriter A_0, x5 A_1, x5 A_2)
		{
			List<lg> list = this.a.m();
			int num = 0;
			x5 a_ = x5.a(x5.b(this.a(0, 0)) / 2f);
			A_1 = x5.f(A_1, a_);
			x5 x = A_1;
			x5 x2 = A_2;
			x5 a_2 = this.b();
			for (int i = 0; i < list.Count; i++)
			{
				if (num >= list[i].i())
				{
					A_2 = x2;
				}
				if (list[i].i() == -1)
				{
					A_2 = this.a(x2, list[i].j(), list, list[i].l());
				}
				else
				{
					A_2 = this.a(x2, list[i].i(), list, list[i].l());
				}
				int a_3 = list[i].l();
				if (list[i].l() == 1 && this.b.Count == 1)
				{
					a_3 = 0;
				}
				x5 a_4 = this.b(a_3);
				A_2 = x5.f(A_2, x5.e(a_2, a_4));
				if (list[i].t())
				{
					A_1 = x;
					A_1 = x5.f(A_1, this.d());
				}
				if (x5.g(list[i].a(), x5.c()) && list[i].o() != null)
				{
					switch (list[i].p())
					{
					case ft.b:
					case ft.e:
						this.b(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), x5.b(list[i].h()), list[i].o(), true);
						break;
					case ft.c:
					case ft.d:
						this.b(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), x5.b(list[i].h()), list[i].o(), false);
						break;
					case ft.f:
						this.d(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), x5.b(list[i].h()), list[i].o());
						break;
					case ft.g:
						this.b(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), x5.b(list[i].h()), list[i].o());
						break;
					case ft.h:
						this.h(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), x5.b(list[i].h()), list[i].o());
						break;
					case ft.i:
						this.f(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), x5.b(list[i].h()), list[i].o());
						break;
					}
				}
				if (num < list[i].i())
				{
					num = list[i].i() + list[i].m() - 1;
				}
			}
		}

		// Token: 0x06001341 RID: 4929 RVA: 0x000DB710 File Offset: 0x000DA710
		private void a(PageWriter A_0, x5 A_1, x5 A_2, x5 A_3)
		{
			List<lg> list = this.a.n();
			int num = int.MinValue;
			x5 a_ = A_1;
			x5 a_2 = A_2;
			x5 a_3 = this.b();
			A_2 = x5.f(A_2, a_3);
			x5 x = x5.a(x5.b(this.a(0, 0)) / 2f);
			x5 a_4 = x5.c();
			x5 a_5 = x5.c();
			for (int i = 0; i < list.Count; i++)
			{
				if ((this.e == 0 && (list[i].i() == 0 || list[i].i() == -1)) || (list[i].i() > 0 && list[i].i() + this.e >= this.d - 1))
				{
					float a_6 = x5.b(list[i].f());
					if (list[i].l() == 0)
					{
						a_5 = x5.a(x5.b(list[i].a()) / 2f);
					}
					A_1 = x5.f(a_, this.a(i, list));
					if (num == list[i].i())
					{
						if (list[i].i() == this.c)
						{
							A_1 = x5.f(A_1, x5.e(x, a_5));
						}
					}
					else if (num < list[i].i() && list[i].i() != -1)
					{
						A_2 = x5.f(a_2, A_3);
						a_4 = x5.a(x5.b(list[i].a()) / 2f);
						A_1 = x5.e(x5.f(a_, x), a_4);
					}
					if (x5.g(list[i].a(), x5.c()) && list[i].o() != null)
					{
						switch (list[i].p())
						{
						case ft.b:
						case ft.e:
							this.a(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), a_6, list[i].o(), true);
							break;
						case ft.c:
						case ft.d:
							this.a(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), a_6, list[i].o(), false);
							break;
						case ft.f:
							this.c(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), a_6, list[i].o());
							break;
						case ft.g:
							this.a(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), a_6, list[i].o());
							break;
						case ft.h:
							this.g(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), a_6, list[i].o());
							break;
						case ft.i:
							this.e(A_0, x5.b(A_1), x5.b(A_2), x5.b(list[i].a()), a_6, list[i].o());
							break;
						}
					}
					if (num < list[i].i())
					{
						num = list[i].i();
					}
				}
			}
		}

		// Token: 0x06001342 RID: 4930 RVA: 0x000DBB1C File Offset: 0x000DAB1C
		private x5 a(int A_0, Hashtable A_1)
		{
			x5 result;
			if (A_1.ContainsKey(A_0))
			{
				result = (x5)A_1[A_0];
			}
			else if (A_1.Count > 0)
			{
				if (A_0 > A_1.Count - 1)
				{
					result = (x5)A_1[A_1.Count - 1];
				}
				else if (A_0 > 0)
				{
					result = (x5)A_1[A_0 - 1];
				}
				else
				{
					for (int i = A_0 + 1; i < this.c; i++)
					{
						if (A_1.ContainsKey(i))
						{
							return (x5)A_1[i];
						}
					}
					result = x5.c();
				}
			}
			else
			{
				result = x5.c();
			}
			return result;
		}

		// Token: 0x06001343 RID: 4931 RVA: 0x000DBC08 File Offset: 0x000DAC08
		private x5 a(x5 A_0, int A_1, List<lg> A_2, int A_3)
		{
			x5 x = x5.c();
			int i = 0;
			while (i < A_1)
			{
				x = x5.c();
				int num = 0;
				x = this.b(i, A_3, A_2, ref num);
				if (x5.h(x, x5.c()))
				{
					x = this.b(i, A_2[A_2.Count - 1].l(), A_2, ref num);
				}
				i += num;
				if (num == 0)
				{
					i++;
				}
				A_0 = x5.f(A_0, x);
			}
			return A_0;
		}

		// Token: 0x06001344 RID: 4932 RVA: 0x000DBC98 File Offset: 0x000DAC98
		private x5 b(int A_0, int A_1, List<lg> A_2, ref int A_3)
		{
			int i = 0;
			while (i < A_2.Count)
			{
				x5 result;
				if (A_2[i].i() == A_0 && A_2[i].l() == A_1)
				{
					A_3 = A_2[i].m() + A_2[i].r();
					result = A_2[i].h();
				}
				else
				{
					if (A_2[i].i() != -1 || A_2[i].j() != A_0 || A_2[i].l() != A_1)
					{
						i++;
						continue;
					}
					A_3 = A_2[i].m() + A_2[i].r();
					result = A_2[i].h();
				}
				return result;
			}
			return x5.c();
		}

		// Token: 0x06001345 RID: 4933 RVA: 0x000DBD88 File Offset: 0x000DAD88
		private x5 a(x5 A_0, int A_1, int A_2)
		{
			x5? x = null;
			List<lg> a_ = this.a.k();
			if (A_1 == 2147483647)
			{
				A_1 = this.c + 1;
			}
			int num = 0;
			bool flag = false;
			for (int i = this.e; i < A_1; i += num + 1)
			{
				x = this.a(i, A_2, a_, ref num);
				if (x == null)
				{
					A_0 = x5.f(A_0, this.b(i, A_2));
					if (A_1 == 1)
					{
						x5 x2 = this.a(i, A_2, a_);
						if (x5.h(x2, x5.c()))
						{
							x2 = x5.f(this.a.p()[i][A_2].c5().c().v(), this.a.p()[i][A_2].c5().c().v());
						}
						A_0 = x5.f(A_0, x2);
					}
					if (flag)
					{
						A_0 = x5.f(A_0, this.a(i, A_2, a_));
					}
					flag = true;
				}
				else
				{
					A_0 = x5.f(A_0, x.Value);
					flag = false;
				}
			}
			return A_0;
		}

		// Token: 0x06001346 RID: 4934 RVA: 0x000DBED8 File Offset: 0x000DAED8
		private x5 a(x5 A_0, lg A_1, List<lg> A_2)
		{
			int num = A_1.i();
			int num2 = A_1.l();
			List<int> list = new List<int>();
			for (int i = 0; i < A_2.Count; i++)
			{
				if (A_2[i].i() <= num && (num2 == A_2[i].l() || (num2 > A_2[i].l() && num2 + A_1.r() <= A_2[i].l() + A_2[i].r())))
				{
					A_0 = x5.f(A_0, A_2[i].h());
					list.Add(A_2[i].i());
				}
			}
			if (list.Count < num + 1)
			{
				for (int j = 0; j < num + 1; j++)
				{
					if (!list.Contains(j))
					{
						for (int i = 0; i < A_2.Count; i++)
						{
							if (A_2[i].i() < j && num2 + 1 > A_2[i].l())
							{
								A_0 = x5.f(A_0, A_2[i].h());
								break;
							}
						}
					}
				}
			}
			return A_0;
		}

		// Token: 0x06001347 RID: 4935 RVA: 0x000DC050 File Offset: 0x000DB050
		private x5? a(int A_0, int A_1, List<lg> A_2, ref int A_3)
		{
			for (int i = 0; i < A_2.Count; i++)
			{
				if (A_2[i].i() == A_0 && A_1 == A_2[i].l())
				{
					A_3 = A_2[i].r();
					return new x5?(A_2[i].h());
				}
			}
			return null;
		}

		// Token: 0x06001348 RID: 4936 RVA: 0x000DC0D0 File Offset: 0x000DB0D0
		private x5 b(int A_0, int A_1)
		{
			List<lg> list = this.a.o();
			for (int i = 0; i < list.Count; i++)
			{
				lg lg = list[i];
				if (lg.i() == A_0 && lg.l() == A_1)
				{
					return lg.h();
				}
			}
			return x5.c();
		}

		// Token: 0x06001349 RID: 4937 RVA: 0x000DC140 File Offset: 0x000DB140
		private x5 a(int A_0, int A_1, List<lg> A_2)
		{
			for (int i = A_2.Count - 1; i >= 0; i--)
			{
				if (A_2[i].i() == A_0 && A_1 > A_2[i].l())
				{
					return x5.f(A_2[i].d(), A_2[i].d());
				}
			}
			if (A_1 == 0)
			{
				for (int i = A_2.Count - 1; i >= 0; i--)
				{
					if (A_2[i].i() == A_0)
					{
						return x5.f(A_2[i].d(), A_2[i].d());
					}
				}
			}
			return x5.c();
		}

		// Token: 0x0600134A RID: 4938 RVA: 0x000DC220 File Offset: 0x000DB220
		private x5 d()
		{
			x5 x = x5.c();
			for (int i = 0; i < this.b.Count; i++)
			{
				x = x5.f(x, (x5)this.b[i]);
			}
			return x;
		}

		// Token: 0x0600134B RID: 4939 RVA: 0x000DC274 File Offset: 0x000DB274
		private x5 c()
		{
			x5 x = x5.c();
			int num = -1;
			if (this.a.m() != null)
			{
				for (int i = 0; i < this.a.m().Count; i++)
				{
					lg lg = this.a.m()[i];
					if (num != lg.i() && num < lg.i())
					{
						x = x5.f(x, lg.h());
					}
					if (num >= lg.i())
					{
						break;
					}
					num = lg.i();
				}
			}
			return x;
		}

		// Token: 0x0600134C RID: 4940 RVA: 0x000DC32C File Offset: 0x000DB32C
		private x5 a(int A_0, int A_1)
		{
			if (this.a.m() != null)
			{
				for (int i = 0; i < this.a.m().Count; i++)
				{
					int num = this.a.m()[i].i();
					int num2 = this.a.m()[i].m();
					if (this.a.m()[i].l() == A_1 && (num == A_0 || (num < A_0 && num + num2 - 1 >= A_0)))
					{
						return this.a.m()[i].a();
					}
				}
			}
			return x5.c();
		}

		// Token: 0x0600134D RID: 4941 RVA: 0x000DC408 File Offset: 0x000DB408
		private x5 b(int A_0)
		{
			if (this.a.n() != null)
			{
				for (int i = 0; i < this.a.n().Count; i++)
				{
					int num = this.a.n()[i].i();
					int num2 = this.a.n()[i].r();
					if (num == -1 && (this.a.n()[i].l() == A_0 || (this.a.n()[i].l() < A_0 && this.a.n()[i].l() + num2 >= A_0)))
					{
						return x5.a(x5.b(this.a.n()[i].a()) / 2f);
					}
				}
			}
			return x5.c();
		}

		// Token: 0x0600134E RID: 4942 RVA: 0x000DC520 File Offset: 0x000DB520
		private x5 b()
		{
			x5 x = x5.c();
			x5 result;
			if (this.a.n() != null)
			{
				for (int i = 0; i < this.a.n().Count; i++)
				{
					if (this.a.n()[i].i() == -1 && x5.d(x, this.a.n()[i].a()))
					{
						x = this.a.n()[i].a();
					}
				}
				result = x5.a(x5.b(x) / 2f);
			}
			else
			{
				result = x;
			}
			return result;
		}

		// Token: 0x0600134F RID: 4943 RVA: 0x000DC5E0 File Offset: 0x000DB5E0
		private x5 a(int A_0)
		{
			x5 x = x5.c();
			for (int i = 0; i < A_0; i++)
			{
				x = x5.f(x, (x5)this.b[i]);
			}
			return x;
		}

		// Token: 0x06001350 RID: 4944 RVA: 0x000DC628 File Offset: 0x000DB628
		private x5 a(int A_0, List<lg> A_1)
		{
			x5 x = x5.c();
			int num = A_1[A_0].l();
			int num2 = A_1[A_0].i();
			x5 x2 = x5.c();
			for (int i = 0; i < num; i++)
			{
				x2 = x5.c();
				x2 = this.a(num2, ref i, A_1);
				if (x5.h(x2, x5.c()))
				{
					int num3 = num2 - 1;
					int num4 = i;
					while (x5.h(x2, x5.c()) && num3 >= 0)
					{
						x2 = this.a(num3, ref i, A_1);
						num3--;
					}
					if (x5.h(x2, x5.c()) && num3 < 0)
					{
						i = num4;
						int num5 = num2 + 1;
						while (x5.h(x2, x5.c()))
						{
							x2 = (x5)this.b[i];
							num5++;
						}
					}
				}
				else
				{
					num2++;
				}
				x = x5.f(x, x2);
			}
			return x;
		}

		// Token: 0x06001351 RID: 4945 RVA: 0x000DC758 File Offset: 0x000DB758
		private x5 a(int A_0, ref int A_1, List<lg> A_2)
		{
			for (int i = 0; i < A_2.Count; i++)
			{
				if (A_2[i].i() == A_0 && A_2[i].k() == A_1)
				{
					A_1 += A_2[i].r();
					return A_2[i].f();
				}
			}
			return x5.c();
		}

		// Token: 0x06001352 RID: 4946 RVA: 0x000DC7D4 File Offset: 0x000DB7D4
		private x5[] a()
		{
			List<lg> list = this.a.k();
			x5 a_ = x5.a(x5.b(this.b()) * 2f);
			x5[] array = new x5[this.b.Count];
			int num = 0;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].i() == 0)
				{
					if (list[i].l() > num)
					{
						array[num] = x5.c();
						num++;
						i--;
					}
					else
					{
						for (int j = num; j < list[i].k() + list[i].n(); j++)
						{
							array[num] = x5.e(a_, x5.a(x5.b(list[i].d()) * 2f));
							num++;
						}
					}
				}
			}
			return array;
		}

		// Token: 0x06001353 RID: 4947 RVA: 0x000DC904 File Offset: 0x000DB904
		private void b(List<lg> A_0)
		{
			List<lg> list = new List<lg>();
			int num = 0;
			int i = 0;
			do
			{
				while (i < A_0.Count)
				{
					if (A_0[i].l() == num)
					{
						list.Add(A_0[i]);
					}
					i++;
				}
				num++;
				if (num < this.b.Count)
				{
					i = 0;
				}
			}
			while (i == 0);
			A_0 = list;
		}

		// Token: 0x06001354 RID: 4948 RVA: 0x000DC980 File Offset: 0x000DB980
		private void a(List<lg> A_0)
		{
			List<lg> list = new List<lg>();
			int num = 0;
			int i = 0;
			do
			{
				while (i < A_0.Count)
				{
					if (A_0[i].i() == num)
					{
						list.Add(A_0[i]);
					}
					i++;
				}
				num++;
				if (num < this.c)
				{
					i = 0;
				}
			}
			while (i == 0);
			A_0 = list;
		}

		// Token: 0x06001355 RID: 4949 RVA: 0x000DC9F4 File Offset: 0x000DB9F4
		private void h(PageWriter A_0, float A_1, float A_2, float A_3, float A_4, Color A_5)
		{
			A_0.SetLineStyle(LineStyle.Solid);
			A_0.SetLineWidth(A_3);
			A_0.Write_m_(A_1, A_2);
			A_0.Write_l_(A_1, A_2 + A_4);
			A_0.SetStrokeColor(A_5);
			A_0.Write_S();
		}

		// Token: 0x06001356 RID: 4950 RVA: 0x000DCA31 File Offset: 0x000DBA31
		private void g(PageWriter A_0, float A_1, float A_2, float A_3, float A_4, Color A_5)
		{
			A_0.SetLineStyle(LineStyle.Solid);
			A_0.SetLineWidth(A_3);
			A_0.Write_m_(A_1, A_2);
			A_0.Write_l_(A_1 + A_4, A_2);
			A_0.SetStrokeColor(A_5);
			A_0.Write_S();
		}

		// Token: 0x06001357 RID: 4951 RVA: 0x000DCA70 File Offset: 0x000DBA70
		private void f(PageWriter A_0, float A_1, float A_2, float A_3, float A_4, Color A_5)
		{
			A_1 -= A_3 / 2f;
			float num = A_3 / 3f;
			A_1 += num / 2f;
			A_0.SetLineStyle(LineStyle.Solid);
			A_0.SetLineWidth(num);
			A_0.Write_m_(A_1, A_2);
			A_0.Write_l_(A_1, A_2 + A_4);
			A_0.SetStrokeColor(A_5);
			A_0.Write_m_(A_1 + num * 2f, A_2);
			A_0.Write_l_(A_1 + num * 2f, A_2 + A_4);
			A_0.Write_S();
		}

		// Token: 0x06001358 RID: 4952 RVA: 0x000DCAFC File Offset: 0x000DBAFC
		private void e(PageWriter A_0, float A_1, float A_2, float A_3, float A_4, Color A_5)
		{
			A_2 -= A_3 / 2f;
			float num = A_3 / 3f;
			A_2 += num / 2f;
			A_0.SetLineStyle(LineStyle.Solid);
			A_0.SetLineWidth(num);
			A_0.Write_m_(A_1, A_2);
			A_0.Write_l_(A_1 + A_4, A_2);
			A_0.SetStrokeColor(A_5);
			A_0.Write_m_(A_1, A_2 + num * 2f);
			A_0.Write_l_(A_1 + A_4, A_2 + num * 2f);
			A_0.Write_S();
		}

		// Token: 0x06001359 RID: 4953 RVA: 0x000DCB88 File Offset: 0x000DBB88
		private void d(PageWriter A_0, float A_1, float A_2, float A_3, float A_4, Color A_5)
		{
			A_1 -= A_3 / 2f;
			A_2 += A_3;
			A_4 -= A_3;
			char[] text = new char[]
			{
				'l'
			};
			float num = this.b(A_0, A_3, A_5);
			float num2 = 0f;
			A_0.Write_Tc(num2);
			for (float num3 = A_2; num3 < A_2 + A_4; num3 += num2 + num)
			{
				A_0.Write_Tm(A_1, num3);
				A_0.Write_Tj_(text, false);
			}
		}

		// Token: 0x0600135A RID: 4954 RVA: 0x000DCC08 File Offset: 0x000DBC08
		private void c(PageWriter A_0, float A_1, float A_2, float A_3, float A_4, Color A_5)
		{
			A_2 += A_3 / 2f;
			float a_ = this.b(A_0, A_3, A_5);
			float characterSpacing = 0f;
			int num = this.a(A_4, a_, ref characterSpacing);
			char[] array = new char[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = 'l';
			}
			A_0.Write_Tc(characterSpacing);
			A_0.Write_Tm(A_1, A_2);
			A_0.Write_Tj_(array, 0, array.Length, false);
		}

		// Token: 0x0600135B RID: 4955 RVA: 0x000DCC84 File Offset: 0x000DBC84
		private float b(PageWriter A_0, float A_1, Color A_2)
		{
			Font zapfDingbats = Font.ZapfDingbats;
			A_0.SetFont(zapfDingbats, A_1);
			A_0.SetTextMode();
			A_0.SetStrokeColor(A_2);
			A_0.SetFillColor(A_2);
			char[] text = new char[]
			{
				'l'
			};
			return zapfDingbats.GetTextWidth(text, A_1);
		}

		// Token: 0x0600135C RID: 4956 RVA: 0x000DCCDC File Offset: 0x000DBCDC
		private int a(float A_0, float A_1, ref float A_2)
		{
			float num = A_0 / A_1;
			int num2 = (int)Math.Round((double)(num / 2f));
			float num3 = A_0 - (float)num2 * A_1;
			A_2 = num3 / (float)num2;
			return num2;
		}

		// Token: 0x0600135D RID: 4957 RVA: 0x000DCD0F File Offset: 0x000DBD0F
		private void b(PageWriter A_0, float A_1, float A_2, float A_3, float A_4, Color A_5)
		{
			this.a(A_0, A_3, A_5);
			A_0.Write_m_(A_1, A_2);
			A_0.Write_l_(A_1, A_2 + A_4);
			A_0.Write_S();
		}

		// Token: 0x0600135E RID: 4958 RVA: 0x000DCD3A File Offset: 0x000DBD3A
		private void a(PageWriter A_0, float A_1, float A_2, float A_3, float A_4, Color A_5)
		{
			this.a(A_0, A_3, A_5);
			A_0.Write_m_(A_1, A_2);
			A_0.Write_l_(A_1 + A_4, A_2);
			A_0.Write_S();
		}

		// Token: 0x0600135F RID: 4959 RVA: 0x000DCD68 File Offset: 0x000DBD68
		private void a(PageWriter A_0, float A_1, Color A_2)
		{
			A_0.SetLineStyle(new LineStyle(new float[]
			{
				A_1 * 2f,
				A_1 * 2f
			}));
			A_0.SetLineWidth(A_1);
			A_0.SetStrokeColor(A_2);
		}

		// Token: 0x06001360 RID: 4960 RVA: 0x000DCDB0 File Offset: 0x000DBDB0
		private void b(PageWriter A_0, float A_1, float A_2, float A_3, float A_4, Color A_5, bool A_6)
		{
			A_3 /= 2f;
			A_0.SetLineStyle(LineStyle.Solid);
			A_0.SetLineWidth(A_3);
			A_0.Write_m_(A_1 - A_3 / 2f, A_2);
			A_0.Write_l_(A_1 - A_3 / 2f, A_2 + A_4);
			if (A_6)
			{
				A_0.SetStrokeColor(A_5);
			}
			else
			{
				this.a(A_0, A_5);
			}
			A_0.Write_S();
			A_0.Write_m_(A_1 + A_3 / 2f, A_2);
			A_0.Write_l_(A_1 + A_3 / 2f, A_2 + A_4);
			if (A_6)
			{
				this.a(A_0, A_5);
			}
			else
			{
				A_0.SetStrokeColor(A_5);
			}
			A_0.Write_S();
		}

		// Token: 0x06001361 RID: 4961 RVA: 0x000DCE78 File Offset: 0x000DBE78
		private void a(PageWriter A_0, float A_1, float A_2, float A_3, float A_4, Color A_5, bool A_6)
		{
			A_3 /= 2f;
			A_0.SetLineStyle(LineStyle.Solid);
			A_0.SetLineWidth(A_3);
			A_0.Write_m_(A_1, A_2 - A_3 / 2f);
			A_0.Write_l_(A_1 + A_4, A_2 - A_3 / 2f);
			if (A_6)
			{
				A_0.SetStrokeColor(A_5);
			}
			else
			{
				this.a(A_0, A_5);
			}
			A_0.Write_S();
			A_0.Write_f();
			A_0.Write_m_(A_1, A_2 + A_3 / 2f);
			A_0.Write_l_(A_1 + A_4, A_2 + A_3 / 2f);
			if (A_6)
			{
				this.a(A_0, A_5);
			}
			else
			{
				A_0.SetStrokeColor(A_5);
			}
			A_0.Write_S();
			A_0.Write_f();
		}

		// Token: 0x06001362 RID: 4962 RVA: 0x000DCF50 File Offset: 0x000DBF50
		private void a(PageWriter A_0, Color A_1)
		{
			if (A_1 is RgbColor)
			{
				RgbColor rgbColor = (RgbColor)A_1;
				float num = rgbColor.R;
				float num2 = rgbColor.G;
				float num3 = rgbColor.B;
				if (num - num2 == 0f && num2 - num3 == 0f && num2 - num == 0f && (double)num < 0.33)
				{
					num = 0f;
					num2 = 0f;
					num3 = 0f;
					rgbColor = new RgbColor(num, num2, num3);
					A_0.SetStrokeColor(rgbColor);
					A_0.Write_rg_(rgbColor);
				}
				else if (num - num2 >= 0f || num2 - num3 >= 0f || num2 - num >= 0f)
				{
					float num4 = this.a(num, num2, num3);
					if ((double)num4 > 0.33)
					{
						float num5 = num4 - 0.333f;
						num = rgbColor.R / num4 * num5;
						num2 = rgbColor.G / num4 * num5;
						num3 = rgbColor.B / num4 * num5;
						if (num <= 1f && num2 <= 1f && num3 <= 1f)
						{
							rgbColor = new RgbColor(num, num2, num3);
							A_0.SetStrokeColor(rgbColor);
							A_0.Write_rg_(rgbColor);
						}
						else
						{
							A_0.SetStrokeColor(new RgbColor(num, num2, num3));
							A_0.e(num, num2, num3);
						}
					}
					else
					{
						num = 0f;
						num2 = 0f;
						num3 = 0f;
						rgbColor = new RgbColor(num, num2, num3);
						A_0.SetStrokeColor(rgbColor);
						A_0.Write_rg_(rgbColor);
					}
				}
			}
		}

		// Token: 0x06001363 RID: 4963 RVA: 0x000DD10C File Offset: 0x000DC10C
		private float a(float A_0, float A_1, float A_2)
		{
			float result;
			if (A_0 >= A_1 && A_0 >= A_2)
			{
				result = A_0;
			}
			else if (A_1 >= A_0 && A_1 >= A_2)
			{
				result = A_1;
			}
			else
			{
				result = A_2;
			}
			return result;
		}

		// Token: 0x06001364 RID: 4964 RVA: 0x000DD148 File Offset: 0x000DC148
		internal void a(PageWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			if (this.a.l() != null && this.a.l().Count > 0)
			{
				this.b(this.a.l());
			}
			if (this.a.k() != null && this.a.k().Count > 0)
			{
				this.a(this.a.k());
			}
			if (this.a.k() != null)
			{
				this.c(A_0, A_1, A_2);
			}
			if (this.a.l() != null && this.a.l().Count > 0)
			{
				this.b(A_0, A_1, A_2);
			}
			if (this.a.l() != null)
			{
				this.a(A_0, A_1, A_2, A_4);
			}
			if (this.a.k() != null)
			{
				this.a(A_0, A_1, A_2);
			}
		}

		// Token: 0x0400093B RID: 2363
		private readonly lh a;

		// Token: 0x0400093C RID: 2364
		private readonly Hashtable b;

		// Token: 0x0400093D RID: 2365
		private readonly int c;

		// Token: 0x0400093E RID: 2366
		private readonly int d;

		// Token: 0x0400093F RID: 2367
		private int e;
	}
}
