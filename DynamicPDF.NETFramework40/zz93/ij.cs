using System;
using System.Collections.Generic;

namespace zz93
{
	// Token: 0x02000153 RID: 339
	internal class ij
	{
		// Token: 0x06000C7C RID: 3196 RVA: 0x0009194C File Offset: 0x0009094C
		internal ij()
		{
			this.g = new gi();
			this.t = new List<int>();
			this.u = new List<int>();
		}

		// Token: 0x06000C7D RID: 3197 RVA: 0x000919D8 File Offset: 0x000909D8
		internal ij(char[] A_0, int A_1, int A_2)
		{
			this.a(new gi(A_0, A_1, A_2));
		}

		// Token: 0x06000C7E RID: 3198 RVA: 0x00091A54 File Offset: 0x00090A54
		~ij()
		{
			mg.a(this);
			l5.a(this);
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x00091A8C File Offset: 0x00090A8C
		internal List<ik> a()
		{
			return this.l;
		}

		// Token: 0x06000C80 RID: 3200 RVA: 0x00091AA4 File Offset: 0x00090AA4
		internal void a(List<ik> A_0)
		{
			this.l = A_0;
		}

		// Token: 0x06000C81 RID: 3201 RVA: 0x00091AB0 File Offset: 0x00090AB0
		internal g8 b()
		{
			return this.i;
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x00091AC8 File Offset: 0x00090AC8
		internal l5 c()
		{
			return ij.n;
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x00091AE0 File Offset: 0x00090AE0
		internal Uri d()
		{
			return this.k;
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x00091AF8 File Offset: 0x00090AF8
		internal void a(Uri A_0)
		{
			this.k = A_0;
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x00091B04 File Offset: 0x00090B04
		internal string e()
		{
			string result;
			if (this.k != null)
			{
				if (this.k.IsFile)
				{
					result = this.k.AbsolutePath;
				}
				else
				{
					result = this.k.AbsoluteUri;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000C86 RID: 3206 RVA: 0x00091B5C File Offset: 0x00090B5C
		internal bool f()
		{
			return this.m;
		}

		// Token: 0x06000C87 RID: 3207 RVA: 0x00091B74 File Offset: 0x00090B74
		internal void a(bool A_0)
		{
			this.m = A_0;
		}

		// Token: 0x06000C88 RID: 3208 RVA: 0x00091B80 File Offset: 0x00090B80
		internal gi g()
		{
			return this.g;
		}

		// Token: 0x06000C89 RID: 3209 RVA: 0x00091B98 File Offset: 0x00090B98
		internal void b(gi A_0)
		{
			this.g = A_0;
		}

		// Token: 0x06000C8A RID: 3210 RVA: 0x00091BA4 File Offset: 0x00090BA4
		internal ia h()
		{
			return this.j;
		}

		// Token: 0x06000C8B RID: 3211 RVA: 0x00091BBC File Offset: 0x00090BBC
		internal ik i()
		{
			return this.h;
		}

		// Token: 0x06000C8C RID: 3212 RVA: 0x00091BD4 File Offset: 0x00090BD4
		internal hi j()
		{
			return this.d;
		}

		// Token: 0x06000C8D RID: 3213 RVA: 0x00091BEC File Offset: 0x00090BEC
		internal void a(hi A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06000C8E RID: 3214 RVA: 0x00091BF8 File Offset: 0x00090BF8
		internal bool k()
		{
			return this.s;
		}

		// Token: 0x06000C8F RID: 3215 RVA: 0x00091C10 File Offset: 0x00090C10
		internal void b(bool A_0)
		{
			this.s = A_0;
		}

		// Token: 0x06000C90 RID: 3216 RVA: 0x00091C1C File Offset: 0x00090C1C
		internal List<h9> l()
		{
			return this.f;
		}

		// Token: 0x06000C91 RID: 3217 RVA: 0x00091C34 File Offset: 0x00090C34
		internal void a(List<h9> A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06000C92 RID: 3218 RVA: 0x00091C40 File Offset: 0x00090C40
		internal bool m()
		{
			return this.o;
		}

		// Token: 0x06000C93 RID: 3219 RVA: 0x00091C58 File Offset: 0x00090C58
		internal bool n()
		{
			return this.p;
		}

		// Token: 0x06000C94 RID: 3220 RVA: 0x00091C70 File Offset: 0x00090C70
		internal bool o()
		{
			return this.q;
		}

		// Token: 0x06000C95 RID: 3221 RVA: 0x00091C88 File Offset: 0x00090C88
		internal bool p()
		{
			return this.r;
		}

		// Token: 0x06000C96 RID: 3222 RVA: 0x00091CA0 File Offset: 0x00090CA0
		internal List<int> q()
		{
			return this.t;
		}

		// Token: 0x06000C97 RID: 3223 RVA: 0x00091CB8 File Offset: 0x00090CB8
		internal void a(List<int> A_0)
		{
			this.t = A_0;
		}

		// Token: 0x06000C98 RID: 3224 RVA: 0x00091CC4 File Offset: 0x00090CC4
		internal List<int> r()
		{
			return this.u;
		}

		// Token: 0x06000C99 RID: 3225 RVA: 0x00091CDC File Offset: 0x00090CDC
		internal void b(List<int> A_0)
		{
			this.u = A_0;
		}

		// Token: 0x06000C9A RID: 3226 RVA: 0x00091CE8 File Offset: 0x00090CE8
		private void a(gi A_0)
		{
			this.g = A_0;
			while (A_0.m())
			{
				bool flag;
				h7[] array = A_0.a(out flag);
				if (array != null)
				{
					if (flag)
					{
						List<h7> list = new List<h7>();
						int a_ = -1;
						int count = this.f.Count;
						for (int i = 0; i < array.Length; i++)
						{
							if (array[i].c7() == @if.b)
							{
								if (((h8)array[i]).a() == ie.d)
								{
									this.a(a_, i - 1, array);
									a_ = i;
								}
							}
							else if (array[i].c7() == @if.a)
							{
								list.Add(array[i]);
								this.a(a_, i - 1, array);
								a_ = -1;
							}
						}
						this.a(a_, array.Length - 1, array);
						ig[] array2 = null;
						if (list.Count > 0)
						{
							array2 = this.a(list.ToArray());
						}
						int num = this.f.Count - count;
						ig[] array3 = new ig[num + ((array2 != null) ? array2.Length : 0)];
						for (int i = count; i < this.f.Count; i++)
						{
							array3[i - count] = this.f[i].b();
						}
						if (array2 != null)
						{
							Array.Copy(array2, 0, array3, num, array2.Length);
						}
						gk.a(A_0, array3);
					}
					else
					{
						ig[] a_2 = this.a(array);
						gk.a(A_0, a_2);
					}
				}
			}
			if (!this.q)
			{
				this.q = A_0.t();
			}
			if (!this.p)
			{
				this.p = A_0.s();
			}
			if (!this.o)
			{
				this.o = A_0.r();
			}
			if (!this.r)
			{
				this.r = A_0.u();
			}
		}

		// Token: 0x06000C9B RID: 3227 RVA: 0x00091F20 File Offset: 0x00090F20
		private void a(int A_0, int A_1, h7[] A_2)
		{
			if (A_0 >= 0)
			{
				h9 h = new h9();
				uint num = 0U;
				for (int i = A_0; i <= A_1; i++)
				{
					h.a((h8)A_2[i]);
					num += A_2[i].c();
				}
				h.a(new ig(this.c++, num));
				this.f.Add(h);
			}
		}

		// Token: 0x06000C9C RID: 3228 RVA: 0x00091F9C File Offset: 0x00090F9C
		private ig[] a(h7[] A_0)
		{
			ig[] array = new ig[A_0.Length];
			for (int i = 0; i < A_0.Length; i++)
			{
				array[i] = this.a(A_0[i]);
			}
			return array;
		}

		// Token: 0x06000C9D RID: 3229 RVA: 0x00091FD8 File Offset: 0x00090FD8
		private ig a(h7 A_0)
		{
			ig result;
			if (A_0 != null)
			{
				List<ig> list;
				if (this.d == null)
				{
					list = null;
					this.d = new hj();
				}
				else
				{
					list = this.d.c3(A_0.b());
				}
				ig ig = new ig(this.c++, A_0.c());
				if (list != null)
				{
					list.Add(ig);
					result = ig;
				}
				else
				{
					this.d.c1(A_0.b(), ig);
					result = ig;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000C9E RID: 3230 RVA: 0x0009207C File Offset: 0x0009107C
		private ih b(d0 A_0)
		{
			ih result;
			if (this.d != null)
			{
				ih ih = this.e.a(A_0);
				result = ih;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000C9F RID: 3231 RVA: 0x000920B0 File Offset: 0x000910B0
		private List<ig> a(d0 A_0)
		{
			List<ig> result;
			if (this.f.Count > 0)
			{
				List<int> list = this.e.b(A_0);
				List<h9> list2 = new List<h9>();
				for (int i = 0; i < list.Count; i++)
				{
					for (int j = 0; j < this.f.Count; j++)
					{
						if (list[i] == this.f[j].a() || this.f[j].a() == 62)
						{
							list2.Add(this.f[j]);
						}
					}
				}
				List<ig> list3 = new List<ig>();
				for (int i = 0; i < list2.Count; i++)
				{
					ig ig = list2[i].a(this.i, this.j, this.e);
					if (ig != null)
					{
						this.e.c(ig);
						if (ig.b() != null)
						{
							list3.Add(ig);
						}
					}
				}
				result = list3;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000CA0 RID: 3232 RVA: 0x000921FB File Offset: 0x000911FB
		internal void c(gi A_0)
		{
			this.a(A_0);
		}

		// Token: 0x06000CA1 RID: 3233 RVA: 0x00092208 File Offset: 0x00091208
		internal fc[] a(char[] A_0, int A_1, int A_2)
		{
			if (this.g == null)
			{
				this.g = new gi(A_0, A_1, A_2);
			}
			else
			{
				this.g.a(A_0, A_1, A_2);
			}
			return this.g.a7();
		}

		// Token: 0x06000CA2 RID: 3234 RVA: 0x00092254 File Offset: 0x00091254
		internal void c(d0 A_0)
		{
			if (A_0.cn() != 10573487)
			{
				if (!this.m)
				{
					ik ik = this.h;
					ik.j(ik.b() + 1);
					this.m = true;
				}
			}
			ih ih = this.b(A_0);
			this.i.a(A_0, this.h.b());
			List<ig> list;
			if (this.i.a().c() != null)
			{
				list = this.a(A_0);
			}
			else
			{
				list = null;
			}
			List<ig> list2;
			List<int> list3;
			if (ih != null)
			{
				list2 = ih.b();
				list3 = ih.a();
			}
			else
			{
				list2 = new List<ig>();
				list3 = new List<int>();
			}
			if (list != null)
			{
				foreach (ig item in list)
				{
					list2.Add(item);
					list3.Add(2147483642);
				}
			}
			this.a(list2, list3);
			for (int i = 0; i < list2.Count; i++)
			{
				this.h.a(list3[i], list2[i]);
			}
			this.h.a(A_0.cn(), A_0.m());
		}

		// Token: 0x06000CA3 RID: 3235 RVA: 0x000923D4 File Offset: 0x000913D4
		internal bool a(int A_0)
		{
			id id = this.j.a();
			bool result;
			if (A_0 < 2)
			{
				result = false;
			}
			else if (id == null)
			{
				result = true;
			}
			else
			{
				while (id != null)
				{
					if (id.b() == A_0)
					{
						return false;
					}
					if (id.b() < A_0)
					{
						return true;
					}
					id = id.c();
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000CA4 RID: 3236 RVA: 0x00092454 File Offset: 0x00091454
		private void a(List<ig> A_0, List<int> A_1)
		{
			if (A_0 != null && A_0.Count > 1)
			{
				for (int i = 0; i < A_0.Count; i++)
				{
					for (int j = i + 1; j < A_0.Count; j++)
					{
						if (A_0[i].d() > A_0[j].d() || (A_0[i].d() == A_0[j].d() && A_0[i].c() > A_0[j].c()))
						{
							ig value = A_0[i];
							int value2 = A_1[i];
							A_0[i] = A_0[j];
							A_1[i] = A_1[j];
							A_0[j] = value;
							A_1[j] = value2;
						}
					}
				}
			}
		}

		// Token: 0x06000CA5 RID: 3237 RVA: 0x00092564 File Offset: 0x00091564
		internal void a(int A_0, ig A_1)
		{
			if (A_0 != 11228793)
			{
				if (!this.m)
				{
					ik ik = this.h;
					ik.j(ik.b() + 1);
				}
			}
			this.h.a(A_0, A_1);
		}

		// Token: 0x06000CA6 RID: 3238 RVA: 0x000925AC File Offset: 0x000915AC
		internal void a(d0 A_0, int A_1, int A_2, int A_3)
		{
			if (this.d != null)
			{
				ih ih = this.e.a(A_0);
				for (int i = ih.a().Count; i > 0; i--)
				{
					if (ih.b()[i - 1] != null)
					{
						this.l[this.l.Count - 1].j(A_3);
						this.l[this.l.Count - 1].a(ih.a()[i - 1], ih.b()[i - 1], A_1, A_2);
					}
				}
			}
			this.l[this.l.Count - 1].j(A_3);
			this.l[this.l.Count - 1].a(A_0.cn(), A_0.m(), A_1, A_2);
		}

		// Token: 0x06000CA7 RID: 3239 RVA: 0x000926B8 File Offset: 0x000916B8
		internal void a(int A_0, ig A_1, int A_2, int A_3, int A_4)
		{
			this.l[this.l.Count - 1].j(A_4);
			this.l[this.l.Count - 1].a(A_0, A_1, A_2, A_3);
		}

		// Token: 0x06000CA8 RID: 3240 RVA: 0x0009270C File Offset: 0x0009170C
		internal void a(kz A_0)
		{
			int[] array = A_0.db().ds();
			this.h.a(A_0);
			this.h.c(1652275116, A_0);
			this.h.c(6968946, A_0);
			for (int i = 0; i < array.Length; i++)
			{
				fc fc = this.h.d(array[i], A_0);
				if (fc != null)
				{
					A_0.db().dt(fc.a(), fc.b());
				}
			}
		}

		// Token: 0x06000CA9 RID: 3241 RVA: 0x000927A0 File Offset: 0x000917A0
		internal void b(kz A_0)
		{
			int[] array = A_0.c5().ds();
			int num = A_0.dg();
			if (num > 3418)
			{
				if (num != 165445)
				{
					if (num == 144937050)
					{
						for (int i = 0; i < array.Length; i++)
						{
							fc fc = this.h.d(array[i], A_0);
							if (fc != null)
							{
								A_0.c5().dt(fc.a(), fc.b());
							}
						}
						this.h.a(false);
						return;
					}
					if (num != 506116087)
					{
						goto IL_257;
					}
				}
				int index = ((nu)A_0).a();
				this.h.a(this.l[index]);
				for (int i = 0; i < array.Length; i++)
				{
					fc fc;
					if (this.h.d() != null)
					{
						num = array[i];
						if (num != 148235845 && num != 1617181893 && num != 1844443081)
						{
							fc = this.h.d(array[i], A_0);
						}
						else
						{
							fc = this.h.l(array[i], ((nu)A_0).b());
						}
					}
					else
					{
						fc = this.h.d(array[i], A_0);
					}
					if (fc != null)
					{
						A_0.c5().dt(fc.a(), fc.b());
					}
				}
				return;
			}
			if (num == 3034 || num == 3418)
			{
				int index = ((nt)A_0).i();
				this.h.a(this.l[index]);
				int a_ = ((nt)A_0).h();
				for (int i = 0; i < array.Length; i++)
				{
					fc fc = this.h.d(array[i], A_0);
					if (fc != null)
					{
						A_0.c5().dt(fc.a(), fc.b());
					}
				}
				if (this.h.d() != null)
				{
					ja ja = this.h.k(795562982, a_);
					if (ja != null)
					{
						((nt)A_0).a(ja);
					}
				}
				return;
			}
			IL_257:
			for (int i = 0; i < array.Length; i++)
			{
				fc fc = this.h.d(array[i], A_0);
				if (fc != null)
				{
					A_0.c5().dt(fc.a(), fc.b());
				}
			}
		}

		// Token: 0x06000CAA RID: 3242 RVA: 0x00092A50 File Offset: 0x00091A50
		internal void c(kz A_0)
		{
			int[] array = A_0.dv().ds();
			for (int i = 0; i < array.Length; i++)
			{
				fc fc = this.h.d(array[i], A_0);
				if (fc != null)
				{
					A_0.dv().dt(fc.a(), fc.b());
				}
			}
		}

		// Token: 0x06000CAB RID: 3243 RVA: 0x00092AB0 File Offset: 0x00091AB0
		internal void s()
		{
			this.e = new hl(this, this.g);
			List<ig> list = this.e.b(62);
			this.i = new g8();
			this.j = new ia();
			if (list == null)
			{
				this.h = new ik(null);
			}
			else
			{
				List<fc> list2 = new List<fc>();
				foreach (ig ig in list)
				{
					list2.AddRange(ig.b());
				}
				this.h = new ik(list2.ToArray());
			}
		}

		// Token: 0x06000CAC RID: 3244 RVA: 0x00092B78 File Offset: 0x00091B78
		internal void a(il A_0)
		{
			this.l.Add(new ik(null));
			this.l[this.l.Count - 1].a(A_0);
		}

		// Token: 0x04000672 RID: 1650
		internal const int a = 62;

		// Token: 0x04000673 RID: 1651
		internal const int b = 1210592242;

		// Token: 0x04000674 RID: 1652
		private uint c = 1U;

		// Token: 0x04000675 RID: 1653
		private hi d;

		// Token: 0x04000676 RID: 1654
		private hl e;

		// Token: 0x04000677 RID: 1655
		private List<h9> f = new List<h9>();

		// Token: 0x04000678 RID: 1656
		private gi g;

		// Token: 0x04000679 RID: 1657
		private ik h;

		// Token: 0x0400067A RID: 1658
		private g8 i;

		// Token: 0x0400067B RID: 1659
		private ia j;

		// Token: 0x0400067C RID: 1660
		private Uri k;

		// Token: 0x0400067D RID: 1661
		private List<ik> l = new List<ik>();

		// Token: 0x0400067E RID: 1662
		private bool m = false;

		// Token: 0x0400067F RID: 1663
		private static l5 n = new l5();

		// Token: 0x04000680 RID: 1664
		private bool o = false;

		// Token: 0x04000681 RID: 1665
		private bool p = false;

		// Token: 0x04000682 RID: 1666
		private bool q = false;

		// Token: 0x04000683 RID: 1667
		private bool r = false;

		// Token: 0x04000684 RID: 1668
		private bool s = false;

		// Token: 0x04000685 RID: 1669
		private List<int> t = null;

		// Token: 0x04000686 RID: 1670
		private List<int> u = null;
	}
}
