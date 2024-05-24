using System;
using System.Collections;

namespace zz93
{
	// Token: 0x02000218 RID: 536
	internal class ny
	{
		// Token: 0x060018E4 RID: 6372 RVA: 0x00106B9C File Offset: 0x00105B9C
		internal ny(nv A_0, int A_1)
		{
			this.e = A_0;
			this.d = A_1;
			this.a = new kz[A_1][];
		}

		// Token: 0x060018E5 RID: 6373 RVA: 0x00106C04 File Offset: 0x00105C04
		internal int d()
		{
			return this.d;
		}

		// Token: 0x060018E6 RID: 6374 RVA: 0x00106C1C File Offset: 0x00105C1C
		internal kz[][] e()
		{
			return this.a;
		}

		// Token: 0x060018E7 RID: 6375 RVA: 0x00106C34 File Offset: 0x00105C34
		internal x5[] f()
		{
			return this.f;
		}

		// Token: 0x060018E8 RID: 6376 RVA: 0x00106C4C File Offset: 0x00105C4C
		internal void a(x5[] A_0)
		{
			this.f = A_0;
		}

		// Token: 0x060018E9 RID: 6377 RVA: 0x00106C58 File Offset: 0x00105C58
		internal f9[] g()
		{
			return this.g;
		}

		// Token: 0x060018EA RID: 6378 RVA: 0x00106C70 File Offset: 0x00105C70
		internal void a(f9[] A_0)
		{
			this.g = A_0;
		}

		// Token: 0x060018EB RID: 6379 RVA: 0x00106C7C File Offset: 0x00105C7C
		internal nh h()
		{
			return this.h;
		}

		// Token: 0x060018EC RID: 6380 RVA: 0x00106C94 File Offset: 0x00105C94
		internal void a(nh A_0)
		{
			this.h = A_0;
		}

		// Token: 0x060018ED RID: 6381 RVA: 0x00106CA0 File Offset: 0x00105CA0
		private x5? a(x5 A_0)
		{
			x5? x = null;
			x5? result;
			if (this.e.c5().am() != null)
			{
				if (this.e.c5().ap() != i2.b)
				{
					x = new x5?(this.e.c5().am().Value);
				}
				else
				{
					x = new x5?(x5.a(x5.b(A_0) * (x5.b(this.e.c5().am().Value) / 100f)));
				}
				x5 x2 = this.e.dp();
				x5? x3 = x;
				if (x3 != null && x5.c(x2, x3.GetValueOrDefault()))
				{
					x = new x5?(this.e.dp());
				}
				x3 = x;
				x2 = this.c();
				x = ((x3 != null) ? new x5?(x5.e(x3.GetValueOrDefault(), x2)) : null);
				result = x;
			}
			else
			{
				result = this.a(this.e, A_0);
			}
			return result;
		}

		// Token: 0x060018EE RID: 6382 RVA: 0x00106DDC File Offset: 0x00105DDC
		private x5? a(k0 A_0, x5 A_1)
		{
			x5? x = null;
			mt mt = A_0.n();
			if (mt != null)
			{
				mu mu = mt.c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					mr mr = ms.l().a();
					while (mr != null && mr.b() != null)
					{
						int num = mr.b().dg();
						if (num <= 3034)
						{
							if (num == 1946 || num == 3034)
							{
								goto IL_9C;
							}
						}
						else if (num == 3418 || num == 144937050 || num == 718642778)
						{
							goto IL_9C;
						}
						mr = mr.c();
						continue;
						IL_9C:
						A_0 = (k0)mr.b();
						if (A_0.c5().am() != null)
						{
							if (A_0.c5().ap() != i2.b)
							{
								x = new x5?(A_0.c5().am().Value);
							}
							else
							{
								x = new x5?(x5.a(x5.b(A_1) * (x5.b(A_0.c5().am().Value) / 100f)));
							}
							x5 x2 = A_0.dp();
							x5? x3 = x;
							if (x3 != null && x5.c(x2, x3.GetValueOrDefault()))
							{
								x = new x5?(A_0.dp());
							}
							x3 = x;
							x2 = this.c();
							return (x3 != null) ? new x5?(x5.e(x3.GetValueOrDefault(), x2)) : null;
						}
						return this.a(A_0, A_1);
					}
					mu = mu.b();
				}
			}
			return x;
		}

		// Token: 0x060018EF RID: 6383 RVA: 0x00106FF8 File Offset: 0x00105FF8
		private x5 c()
		{
			x5 x = x5.c();
			x5 value = this.e.dv().e().Value;
			if (this.e.c5().g())
			{
				x = x5.f(x, x5.f(this.e.c5().f().d(), this.e.c5().f().b()));
			}
			if (x5.g(value, x5.c()))
			{
				for (int i = 0; i <= this.c; i++)
				{
					x = x5.f(x, value);
				}
			}
			if (this.e.dv().h() != il.b)
			{
				bool flag;
				if (this.e.c5().c().o() != ft.a)
				{
					this.e.c5().c().n();
					flag = (1 == 0);
				}
				else
				{
					flag = true;
				}
				if (!flag)
				{
					x = x5.f(x, this.e.c5().c().n());
				}
				bool flag2;
				if (this.e.c5().c().s() != ft.a)
				{
					this.e.c5().c().r();
					flag2 = (1 == 0);
				}
				else
				{
					flag2 = true;
				}
				if (!flag2)
				{
					x = x5.f(x, this.e.c5().c().r());
				}
			}
			else
			{
				this.b();
				this.a();
				if (this.a[0][0] != null)
				{
					this.e.c5().c().g(this.a[0][0].c5().c().ab());
				}
				if (this.a[0][this.c - 1] != null)
				{
					this.e.c5().c().h(this.a[0][this.c - 1].c5().c().ae());
				}
				x = x5.f(x, this.e.c5().c().ab());
				x = x5.f(x, this.e.c5().c().ae());
			}
			return x;
		}

		// Token: 0x060018F0 RID: 6384 RVA: 0x00107264 File Offset: 0x00106264
		private x5 b()
		{
			x5 x = x5.c();
			for (int i = 0; i < this.c; i++)
			{
				if (this.a[0][i] != null)
				{
					if (x5.d(x, this.a[0][i].c5().c().v()))
					{
						x = this.a[0][i].c5().c().v();
					}
				}
			}
			this.e.c5().c().e(x);
			return x;
		}

		// Token: 0x060018F1 RID: 6385 RVA: 0x00107300 File Offset: 0x00106300
		private x5 a()
		{
			x5 x = x5.c();
			for (int i = 0; i < this.c; i++)
			{
				if (this.a[this.d - 1][i] != null)
				{
					if (x5.d(x, this.a[this.d - 1][i].c5().c().y()))
					{
						x = this.a[this.d - 1][i].c5().c().y();
					}
				}
			}
			this.e.c5().c().f(x);
			return x;
		}

		// Token: 0x060018F2 RID: 6386 RVA: 0x001073B0 File Offset: 0x001063B0
		internal void a(nx A_0, int A_1, int A_2)
		{
			if (this.a[A_1] == null)
			{
				this.a[A_1] = new kz[A_2];
			}
			int num = 0;
			if (A_0.n() != null && A_0.n().c() != null)
			{
				mu mu = A_0.n().c();
				if (mu.a() != null)
				{
					for (mr mr = mu.a().l().a(); mr != null; mr = mr.c())
					{
						nt nt = (nt)mr.b();
						while (num < A_2 && this.a[A_1][num] != null)
						{
							num++;
						}
						if (num < A_2 && nt != null)
						{
							int num2 = nt.dg();
							if (num2 == 3034 || num2 == 3418)
							{
								this.a[A_1][num] = nt;
								if (num != nt.h())
								{
									nt.a(num);
								}
								int num3 = ((n5)this.a[A_1][num].db()).y();
								num++;
								if (num3 != 1)
								{
									this.i = true;
									for (int i = 1; i < num3; i++)
									{
										if (num >= A_2)
										{
											break;
										}
										this.a[A_1][num] = nt;
										num++;
									}
								}
							}
						}
					}
				}
			}
			this.a(A_1, A_2);
		}

		// Token: 0x060018F3 RID: 6387 RVA: 0x0010755C File Offset: 0x0010655C
		internal void a(int A_0, int A_1)
		{
			for (int i = 0; i < this.a[A_0].Length; i++)
			{
				if (this.a[A_0][i] != null && !this.a[A_0][i].b5())
				{
					if (((n5)this.a[A_0][i].db()).z() != 1)
					{
						int num = A_0 + 1;
						for (int j = 1; j < ((n5)this.a[A_0][i].db()).z(); j++)
						{
							if (num < this.d)
							{
								if (this.a[num] == null)
								{
									this.a[num] = new kz[A_1];
								}
								nt nt = new nt();
								nt.u(true);
								nt.a(i);
								this.a[num][i] = nt;
							}
							num++;
						}
					}
				}
			}
		}

		// Token: 0x060018F4 RID: 6388 RVA: 0x0010766C File Offset: 0x0010666C
		internal void i()
		{
			for (int i = 0; i < this.a.Length; i++)
			{
				if (this.a[i] != null)
				{
					for (int j = 0; j < this.a[i].Length; j++)
					{
						if (this.a[i][j] != null && this.a[i][j].b5())
						{
							int num = i - 1;
							this.a[i][j].a(this.a[num][j].c5());
							this.a[i][j].u(true);
						}
					}
				}
			}
		}

		// Token: 0x060018F5 RID: 6389 RVA: 0x00107724 File Offset: 0x00106724
		internal void j()
		{
			for (int i = 0; i < this.a.Length; i++)
			{
				for (int j = 0; j < this.a[i].Length; j++)
				{
					if (this.a[i][j] == null)
					{
						this.a[i][j] = new nt();
						((k0)this.a[i][j]).c(null);
						this.a[i][j].a(new lk());
					}
				}
			}
		}

		// Token: 0x060018F6 RID: 6390 RVA: 0x001077B8 File Offset: 0x001067B8
		internal int k()
		{
			if (this.c == 0)
			{
				for (int i = 0; i < this.a.Length; i++)
				{
					if (this.a[i] != null && this.c < this.a[i].Length)
					{
						this.c = this.a[i].Length;
					}
				}
			}
			return this.c;
		}

		// Token: 0x060018F7 RID: 6391 RVA: 0x00107834 File Offset: 0x00106834
		internal void b(x5 A_0)
		{
			x5? a_ = this.a(A_0);
			k6 k;
			if (this.e.dv().i().Equals("fixed") && this.e.c5().am() != null)
			{
				k = new l1();
			}
			else
			{
				k = new k7(this.a, this.i);
			}
			k.e(this.c());
			k.a(a_);
			k.d(this.c);
			k.d(this.f);
			k.a(this.g);
			k.f(A_0);
			this.b = k.dn();
			this.e.a(new Hashtable());
			for (int i = 0; i < this.b.Length; i++)
			{
				this.e.b6().Add(i, this.b[i]);
			}
		}

		// Token: 0x060018F8 RID: 6392 RVA: 0x00107954 File Offset: 0x00106954
		internal void l()
		{
			this.c = this.k();
			this.h = new nh(this.a, this.c, this.e);
			this.h.k();
		}

		// Token: 0x060018F9 RID: 6393 RVA: 0x0010798C File Offset: 0x0010698C
		internal ny a(nv A_0)
		{
			ny ny = new ny(A_0, this.d);
			ny.a = this.a;
			if (this.h != null)
			{
				ny.a(this.h.a(A_0));
			}
			return ny;
		}

		// Token: 0x04000B0F RID: 2831
		private kz[][] a = null;

		// Token: 0x04000B10 RID: 2832
		private x5[] b = null;

		// Token: 0x04000B11 RID: 2833
		private int c = 0;

		// Token: 0x04000B12 RID: 2834
		private int d = 0;

		// Token: 0x04000B13 RID: 2835
		private nv e = null;

		// Token: 0x04000B14 RID: 2836
		private x5[] f = null;

		// Token: 0x04000B15 RID: 2837
		private f9[] g = null;

		// Token: 0x04000B16 RID: 2838
		private nh h;

		// Token: 0x04000B17 RID: 2839
		private bool i = false;
	}
}
