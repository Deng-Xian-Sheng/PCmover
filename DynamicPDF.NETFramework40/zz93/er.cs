using System;

namespace zz93
{
	// Token: 0x020000CB RID: 203
	internal abstract class er : dy
	{
		// Token: 0x0600094D RID: 2381 RVA: 0x0007C7C0 File Offset: 0x0007B7C0
		internal er()
		{
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x0007C810 File Offset: 0x0007B810
		internal er(p1 A_0)
		{
			base.a(A_0);
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x0007C868 File Offset: 0x0007B868
		internal bool d()
		{
			return this.c;
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x0007C880 File Offset: 0x0007B880
		internal void b(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x0007C88C File Offset: 0x0007B88C
		internal int e()
		{
			return this.d;
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x0007C8A4 File Offset: 0x0007B8A4
		internal void c(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x0007C8B0 File Offset: 0x0007B8B0
		internal int f()
		{
			return this.e;
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x0007C8C8 File Offset: 0x0007B8C8
		internal void d(int A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x0007C8D4 File Offset: 0x0007B8D4
		internal int g()
		{
			return this.h;
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x0007C8EC File Offset: 0x0007B8EC
		internal void e(int A_0)
		{
			this.h = A_0;
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x0007C8F8 File Offset: 0x0007B8F8
		internal int h()
		{
			return this.f;
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x0007C910 File Offset: 0x0007B910
		internal void f(int A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x0007C91C File Offset: 0x0007B91C
		internal int i()
		{
			return this.g;
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0007C934 File Offset: 0x0007B934
		internal void g(int A_0)
		{
			this.g = A_0;
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x0007C940 File Offset: 0x0007B940
		internal nw j()
		{
			return this.i;
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x0007C958 File Offset: 0x0007B958
		internal void a(nw A_0)
		{
			this.i = A_0;
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x0007C964 File Offset: 0x0007B964
		internal fg k()
		{
			return this.a;
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x0007C97C File Offset: 0x0007B97C
		internal void a(fg A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x0007C988 File Offset: 0x0007B988
		internal hx l()
		{
			return this.b;
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x0007C9A0 File Offset: 0x0007B9A0
		internal void a(hx A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x0007C9AC File Offset: 0x0007B9AC
		internal int e(mt A_0)
		{
			int num = A_0.f();
			ev[][] a_ = new ev[num][];
			return this.a(A_0, a_);
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x0007C9D4 File Offset: 0x0007B9D4
		private int a(mt A_0, ev[][] A_1)
		{
			mu mu = A_0.c();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			while (mu != null && mu.a() != null)
			{
				ms ms = mu.a();
				mr mr = ms.l().a();
				while (mr != null && mr.b() != null)
				{
					k0 k = (k0)mr.b();
					int num5 = k.dg();
					if (num5 <= 442866842)
					{
						if (num5 != 1946)
						{
							if (num5 == 442866842)
							{
								num3 = ((n6)k).b();
							}
						}
						else if (k.n() != null)
						{
							int num6 = this.a(k.n().c().a());
							int a_ = 0;
							if (A_1[num4] == null)
							{
								A_1[num4] = new ev[num6];
							}
							else
							{
								a_ = A_1[num4].Length;
							}
							this.a(k.n(), A_1, num4, a_);
							num4++;
						}
					}
					else if (num5 != 718642778)
					{
						if (num5 == 889490394)
						{
							num = ((n7)k).b();
						}
					}
					else
					{
						num2 = ((n0)k).a();
					}
					mr = mr.c();
				}
				mu = mu.b();
			}
			int num7 = num;
			if (num7 < num2)
			{
				num7 = num2;
			}
			if (num7 < num3)
			{
				num7 = num3;
			}
			int result;
			if (num4 > 0)
			{
				result = this.a(A_1, num7);
			}
			else
			{
				result = num7;
			}
			return result;
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x0007CB94 File Offset: 0x0007BB94
		private void a(mt A_0, ev[][] A_1, int A_2, int A_3)
		{
			mu mu = A_0.c();
			int i = A_3;
			while (mu != null && mu.a() != null)
			{
				ms ms = mu.a();
				mr mr = ms.l().a();
				while (mr != null && mr.b() != null)
				{
					k0 k = (k0)mr.b();
					int num = k.dg();
					if (num == 3034 || num == 3418)
					{
						int num2 = ((n5)k.db()).z();
						int num3 = ((n5)k.db()).y();
						ev ev = new ev();
						ev.a(true);
						if (A_1[A_2].Length <= i)
						{
							A_1[A_2] = this.a(A_1[A_2]);
						}
						A_1[A_2][i] = ev;
						if (num2 > 1)
						{
							int num4 = A_2 + 1;
							while (num4 < A_2 + num2 && num4 < A_1.Length)
							{
								ev = new ev();
								ev.a(true);
								ev.b(true);
								if (A_1[num4] == null)
								{
									A_1[num4] = new ev[1];
								}
								while (A_1[num4].Length <= i)
								{
									A_1[num4] = this.a(A_1[num4]);
								}
								A_1[num4][i] = ev;
								num4++;
							}
						}
						i++;
						if (num3 > 1)
						{
							int num5 = i + num3 - 1;
							while (i < num5)
							{
								ev = new ev();
								ev.a(true);
								if (A_1[A_2].Length == i)
								{
									A_1[A_2] = this.a(A_1[A_2]);
								}
								A_1[A_2][i] = ev;
								ev.c(true);
								i++;
							}
						}
					}
					mr = mr.c();
				}
				mu = mu.b();
			}
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x0007CDA0 File Offset: 0x0007BDA0
		private int a(ms A_0)
		{
			int num = 0;
			if (A_0 != null)
			{
				mr mr = A_0.l().a();
				while (mr != null && mr.b() != null)
				{
					int num2 = ((n5)mr.b().db()).y();
					num += num2;
					mr = mr.c();
				}
			}
			return num;
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x0007CE10 File Offset: 0x0007BE10
		private int a(ev[][] A_0, int A_1)
		{
			for (int i = 0; i < A_0.Length; i++)
			{
				int num = 0;
				if (A_0[i] != null)
				{
					for (int j = 0; j < A_0[i].Length; j++)
					{
						if (A_0[i][j] != null)
						{
							num++;
						}
					}
					if (A_1 < num)
					{
						A_1 = num;
					}
				}
			}
			return A_1;
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x0007CE84 File Offset: 0x0007BE84
		private ev[] a(ev[] A_0)
		{
			ev[] array = new ev[A_0.Length + 1];
			Array.Copy(A_0, 0, array, 0, A_0.Length);
			A_0 = array;
			return A_0;
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x0007CEB4 File Offset: 0x0007BEB4
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

		// Token: 0x06000968 RID: 2408 RVA: 0x0007CF54 File Offset: 0x0007BF54
		internal void f(mt A_0)
		{
			if (A_0 != null)
			{
				mu mu = A_0.c();
				int num = A_0.f();
				int num2 = num;
				while (mu != null && mu.a() != null)
				{
					mr mr = mu.a().l().a();
					while (mr != null && mr.b() != null)
					{
						k0 k = (k0)mr.b();
						int num3 = k.dg();
						if (num3 <= 442866842)
						{
							if (num3 != 1946)
							{
								if (num3 == 442866842)
								{
									goto IL_82;
								}
							}
							else
							{
								this.a(num2, k.n());
								num2--;
							}
						}
						else if (num3 == 718642778 || num3 == 889490394)
						{
							goto IL_82;
						}
						IL_A7:
						mr = mr.c();
						continue;
						IL_82:
						this.f(k.n());
						goto IL_A7;
					}
					mu = mu.b();
				}
			}
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x0007D054 File Offset: 0x0007C054
		internal void a(kz A_0, kz A_1, bool A_2, bool A_3)
		{
			this.h(A_0, A_1);
			this.g(A_0, A_1);
			if (A_2)
			{
				this.f(A_0, A_1);
			}
			if (A_3)
			{
				this.e(A_0, A_1);
			}
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x0007D097 File Offset: 0x0007C097
		internal void i(kz A_0, kz A_1)
		{
			this.h(A_0, A_1);
			this.g(A_0, A_1);
			this.f(A_0, A_1);
			this.e(A_0, A_1);
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x0007D0C0 File Offset: 0x0007C0C0
		internal void a(k0 A_0, int A_1)
		{
			if (A_0.n() != null)
			{
				mu mu = A_0.n().c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					mr mr = ms.l().a();
					int num = 0;
					while (mr != null && mr.b() != null)
					{
						nt nt = (nt)mr.b();
						if (nt.h() == 0)
						{
							this.h(nt, A_0);
						}
						this.f(nt, A_0);
						if (nt.h() == A_1 - 1 || nt.h() + ((n5)nt.db()).y() - 1 == A_1 - 1)
						{
							this.g(nt, A_0);
						}
						if (nt.d1() == nt.d1() + ((n5)nt.db()).z() - 1)
						{
							this.e(nt, A_0);
						}
						mr = mr.c();
						num++;
					}
					mu = mu.b();
				}
			}
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x0007D210 File Offset: 0x0007C210
		private void h(kz A_0, kz A_1)
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
					this.d(A_0, A_1);
				}
				else if (x5.h(A_0.c5().c().n(), A_1.c5().c().n()) && A_0.c5().c().o() < A_1.c5().c().o())
				{
					this.d(A_0, A_1);
				}
			}
			else if (A_1.c5().c().o() != ft.a)
			{
				this.d(A_0, A_1);
			}
			else
			{
				A_0.c5().c().c(x5.c());
			}
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x0007D358 File Offset: 0x0007C358
		private void g(kz A_0, kz A_1)
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
					this.c(A_0, A_1);
				}
				else if (x5.h(A_0.c5().c().r(), A_1.c5().c().r()) && A_0.c5().c().s() < A_1.c5().c().s())
				{
					this.c(A_0, A_1);
				}
			}
			else if (A_1.c5().c().s() != ft.a)
			{
				this.c(A_0, A_1);
			}
			else
			{
				A_0.c5().c().d(x5.c());
			}
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x0007D4A0 File Offset: 0x0007C4A0
		private void f(kz A_0, kz A_1)
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
					this.b(A_0, A_1);
				}
				else if (x5.h(A_0.c5().c().f(), A_1.c5().c().f()) && A_0.c5().c().g() < A_1.c5().c().g())
				{
					this.b(A_0, A_1);
				}
			}
			else if (A_1.c5().c().g() != ft.a)
			{
				this.b(A_0, A_1);
			}
			else
			{
				A_0.c5().c().a(x5.c());
			}
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x0007D5E8 File Offset: 0x0007C5E8
		private void e(kz A_0, kz A_1)
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
					this.a(A_0, A_1);
				}
				else if (x5.h(A_0.c5().c().j(), A_1.c5().c().j()) && A_0.c5().c().k() < A_1.c5().c().k())
				{
					this.a(A_0, A_1);
				}
			}
			else if (A_1.c5().c().k() != ft.a)
			{
				this.a(A_0, A_1);
			}
			else
			{
				A_0.c5().c().b(x5.c());
			}
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x0007D730 File Offset: 0x0007C730
		private void d(kz A_0, kz A_1)
		{
			A_0.c5().c().c(A_1.c5().c().n());
			A_0.c5().c().c(A_1.c5().c().o());
			A_0.c5().c().c(A_1.c5().c().m());
			A_0.c5().c().b(A_1.c5().c().ap() + 1);
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x0007D7C4 File Offset: 0x0007C7C4
		private void c(kz A_0, kz A_1)
		{
			A_0.c5().c().d(A_1.c5().c().r());
			A_0.c5().c().d(A_1.c5().c().s());
			A_0.c5().c().d(A_1.c5().c().q());
			A_0.c5().c().a(A_1.c5().c().ao() + 1);
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x0007D858 File Offset: 0x0007C858
		private void b(kz A_0, kz A_1)
		{
			A_0.c5().c().a(A_1.c5().c().f());
			A_0.c5().c().a(A_1.c5().c().g());
			A_0.c5().c().a(A_1.c5().c().e());
			A_0.c5().c().c(A_1.c5().c().aq() + 1);
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x0007D8EC File Offset: 0x0007C8EC
		private void a(kz A_0, kz A_1)
		{
			A_0.c5().c().b(A_1.c5().c().j());
			A_0.c5().c().b(A_1.c5().c().k());
			A_0.c5().c().b(A_1.c5().c().i());
			A_0.c5().c().d(A_1.c5().c().ar() + 1);
		}

		// Token: 0x040004C5 RID: 1221
		private new fg a = null;

		// Token: 0x040004C6 RID: 1222
		private hx b = null;

		// Token: 0x040004C7 RID: 1223
		private bool c = false;

		// Token: 0x040004C8 RID: 1224
		private new int d = 0;

		// Token: 0x040004C9 RID: 1225
		private new int e = 0;

		// Token: 0x040004CA RID: 1226
		private new int f = 0;

		// Token: 0x040004CB RID: 1227
		private new int g = 0;

		// Token: 0x040004CC RID: 1228
		private new int h = 0;

		// Token: 0x040004CD RID: 1229
		private nw i;
	}
}
