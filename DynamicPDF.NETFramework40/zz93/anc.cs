using System;

namespace zz93
{
	// Token: 0x020005D6 RID: 1494
	internal class anc
	{
		// Token: 0x06003B31 RID: 15153 RVA: 0x001FB1E9 File Offset: 0x001FA1E9
		internal anc()
		{
		}

		// Token: 0x06003B32 RID: 15154 RVA: 0x001FB210 File Offset: 0x001FA210
		internal void a(x5 A_0, x5 A_1, alt A_2)
		{
			if (this.a.Length == this.b)
			{
				anb[] array = new anb[this.b * 2];
				this.a.CopyTo(array, 0);
				this.a = array;
			}
			this.a[this.b++] = new anb(A_0, A_1, A_2);
		}

		// Token: 0x06003B33 RID: 15155 RVA: 0x001FB27C File Offset: 0x001FA27C
		internal int a()
		{
			return this.b;
		}

		// Token: 0x06003B34 RID: 15156 RVA: 0x001FB294 File Offset: 0x001FA294
		internal x5 b()
		{
			return (this.c < this.b) ? this.a[this.c].b() : x5.c();
		}

		// Token: 0x06003B35 RID: 15157 RVA: 0x001FB2D0 File Offset: 0x001FA2D0
		internal void a(x5 A_0)
		{
			for (int i = this.c; i < this.b; i++)
			{
				if (x5.a(this.a[i].b(), A_0))
				{
					this.c = i;
					break;
				}
			}
		}

		// Token: 0x06003B36 RID: 15158 RVA: 0x001FB320 File Offset: 0x001FA320
		internal void a(amk A_0)
		{
			for (int i = 0; i < this.b; i++)
			{
				this.a[i].a(A_0);
			}
		}

		// Token: 0x06003B37 RID: 15159 RVA: 0x001FB354 File Offset: 0x001FA354
		internal void b(x5 A_0)
		{
			for (int i = this.c; i < this.b; i++)
			{
				this.a[i].d(A_0);
			}
		}

		// Token: 0x06003B38 RID: 15160 RVA: 0x001FB390 File Offset: 0x001FA390
		internal void a(acm A_0)
		{
			x5 a_ = x5.c();
			for (int i = 0; i < this.b; i++)
			{
				a_ = this.a[i].c();
				anb anb = this.a[i];
				anb.a(x5.f(anb.b(), A_0.a().a(this.a[i].b())));
				anb anb2 = this.a[i];
				anb2.b(x5.f(anb2.c(), A_0.a().a(a_)));
			}
		}

		// Token: 0x06003B39 RID: 15161 RVA: 0x001FB41F File Offset: 0x001FA41F
		internal void c()
		{
			this.a(0, this.b - 1);
		}

		// Token: 0x06003B3A RID: 15162 RVA: 0x001FB434 File Offset: 0x001FA434
		private void a(int A_0, int A_1)
		{
			if (A_1 > A_0)
			{
				int i = A_0;
				int num = A_1;
				int num2 = (A_0 + A_1) / 2;
				anb anb = this.a[num2];
				while (i <= num)
				{
					while (x5.d(this.a[i].b(), anb.b()) && i < A_1)
					{
						i++;
					}
					while (x5.d(anb.b(), this.a[num].b()) && num > A_0)
					{
						num--;
					}
					if (i <= num)
					{
						anb anb2 = this.a[i];
						this.a[i] = this.a[num];
						this.a[num] = anb2;
						i++;
						num--;
					}
				}
				if (A_0 < num)
				{
					this.a(A_0, num);
				}
				if (i < A_1)
				{
					this.a(i, A_1);
				}
			}
		}

		// Token: 0x06003B3B RID: 15163 RVA: 0x001FB53C File Offset: 0x001FA53C
		internal x5 a(alx A_0, x5 A_1, bool A_2)
		{
			int num = 0;
			bool flag = true;
			int num2 = -1;
			int num3 = 0;
			alw alw = null;
			x5 a_ = (this.b > 0) ? this.a[this.c].a() : x5.a();
			bool flag2 = false;
			x5 result;
			if (x5.a(a_, A_1))
			{
				result = A_1;
			}
			else
			{
				for (int i = this.c; i < this.b; i++)
				{
					alw e = this.a[i].d().a;
					if ((!x5.b(this.a[i].b(), x5.c()) || !x5.b(this.a[i].c(), x5.c())) && !x5.c(this.a[i].b(), A_1))
					{
						while (e != null)
						{
							num = 1;
							if (e.b != null && (!flag2 || !x5.c(e.b.a().b7(), A_1)))
							{
								alw = e;
								num3 = i;
								if (num2 == -1)
								{
									num2 = i;
								}
								alu alu = A_0.a;
								bool flag3 = false;
								while (alu != null)
								{
									if (alu.b.a().fd() == e.a)
									{
										flag3 = true;
										if (x5.h(alu.a, al1.e) || (alu.c.b == alu.b && x5.h(alu.c.a, al1.e)))
										{
											alu = alu.c.c;
											if (e.d == alv.c)
											{
												flag2 = true;
											}
											if (e.d == alv.b)
											{
												flag = false;
											}
											break;
										}
										if (e.d == alv.c)
										{
											if (x5.g(alu.c.a, alu.b.a().b8()))
											{
												flag = false;
												break;
											}
										}
										else if (e.d == alv.a)
										{
											if (x5.g(alu.a, alu.b.a().b7()))
											{
												flag = false;
												break;
											}
										}
										else if (e.d == alv.b)
										{
											if (x5.g(alu.a, alu.b.a().b7()) || x5.g(alu.c.a, alu.b.a().b8()))
											{
												flag = false;
												break;
											}
										}
									}
									if (alu.c != null)
									{
										alu = alu.c.c;
									}
									else
									{
										alu = null;
									}
								}
								if (!flag3 || !flag)
								{
									flag = false;
									break;
								}
							}
							e = e.e;
						}
						if (!flag)
						{
							break;
						}
					}
				}
				if (num2 == -1 && flag && num > 0)
				{
					if (this.b > 0 && x5.a(this.a[0].b(), A_1) && x5.c(this.a[0].c(), x5.c()))
					{
						flag = false;
						num3 = this.b - 1;
					}
				}
				if (!flag)
				{
					if (A_2)
					{
						x5 x;
						if (alw != null && alw.d == alv.a && !alw.b.a().fe())
						{
							x = alw.b.a().b8();
						}
						else
						{
							x = this.a[num3].c();
						}
						result = (x5.h(x, x5.a()) ? A_1 : x);
					}
					else
					{
						x5 x = x5.e(this.a[num3].b(), x5.a(0.0001));
						result = (x5.h(x, x5.b()) ? A_1 : x);
					}
				}
				else
				{
					result = A_1;
				}
			}
			return result;
		}

		// Token: 0x04001BE3 RID: 7139
		private anb[] a = new anb[2];

		// Token: 0x04001BE4 RID: 7140
		private int b = 0;

		// Token: 0x04001BE5 RID: 7141
		private int c = 0;
	}
}
