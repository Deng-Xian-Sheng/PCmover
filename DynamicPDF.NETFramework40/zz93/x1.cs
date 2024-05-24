using System;

namespace zz93
{
	// Token: 0x02000396 RID: 918
	internal class x1
	{
		// Token: 0x0600273B RID: 10043 RVA: 0x00169B65 File Offset: 0x00168B65
		internal x1()
		{
		}

		// Token: 0x0600273C RID: 10044 RVA: 0x00169B8C File Offset: 0x00168B8C
		internal void a(x5 A_0, x5 A_1, wv A_2)
		{
			if (this.a.Length == this.b)
			{
				x0[] array = new x0[this.b * 2];
				this.a.CopyTo(array, 0);
				this.a = array;
			}
			this.a[this.b++] = new x0(A_0, A_1, A_2);
		}

		// Token: 0x0600273D RID: 10045 RVA: 0x00169BF8 File Offset: 0x00168BF8
		internal int a()
		{
			return this.b;
		}

		// Token: 0x0600273E RID: 10046 RVA: 0x00169C10 File Offset: 0x00168C10
		internal x5 b()
		{
			return (this.c < this.b) ? this.a[this.c].b() : x5.c();
		}

		// Token: 0x0600273F RID: 10047 RVA: 0x00169C4C File Offset: 0x00168C4C
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

		// Token: 0x06002740 RID: 10048 RVA: 0x00169C9C File Offset: 0x00168C9C
		internal void a(xg A_0)
		{
			for (int i = 0; i < this.b; i++)
			{
				this.a[i].a(A_0);
			}
		}

		// Token: 0x06002741 RID: 10049 RVA: 0x00169CD0 File Offset: 0x00168CD0
		internal void b(x5 A_0)
		{
			for (int i = this.c; i < this.b; i++)
			{
				this.a[i].d(A_0);
			}
		}

		// Token: 0x06002742 RID: 10050 RVA: 0x00169D0C File Offset: 0x00168D0C
		internal void a(acm A_0)
		{
			x5 a_ = x5.c();
			for (int i = 0; i < this.b; i++)
			{
				a_ = this.a[i].c();
				x0 x = this.a[i];
				x.a(x5.f(x.b(), A_0.a().a(this.a[i].b())));
				x0 x2 = this.a[i];
				x2.b(x5.f(x2.c(), A_0.a().a(a_)));
			}
		}

		// Token: 0x06002743 RID: 10051 RVA: 0x00169D9B File Offset: 0x00168D9B
		internal void c()
		{
			this.a(0, this.b - 1);
		}

		// Token: 0x06002744 RID: 10052 RVA: 0x00169DB0 File Offset: 0x00168DB0
		private void a(int A_0, int A_1)
		{
			if (A_1 > A_0)
			{
				int i = A_0;
				int num = A_1;
				int num2 = (A_0 + A_1) / 2;
				x0 x = this.a[num2];
				while (i <= num)
				{
					while (x5.d(this.a[i].b(), x.b()) && i < A_1)
					{
						i++;
					}
					while (x5.d(x.b(), this.a[num].b()) && num > A_0)
					{
						num--;
					}
					if (i <= num)
					{
						x0 x2 = this.a[i];
						this.a[i] = this.a[num];
						this.a[num] = x2;
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

		// Token: 0x06002745 RID: 10053 RVA: 0x00169EB8 File Offset: 0x00168EB8
		internal x5 a(w3 A_0, x5 A_1, bool A_2)
		{
			int num = 0;
			bool flag = true;
			int num2 = -1;
			int num3 = 0;
			wy wy = null;
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
					wy e = this.a[i].d().a;
					if ((!x5.b(this.a[i].b(), x5.c()) || !x5.b(this.a[i].c(), x5.c())) && !x5.c(this.a[i].b(), A_1))
					{
						while (e != null)
						{
							num = 1;
							if (e.b != null && (!flag2 || !x5.c(e.b.a().b7(), A_1)))
							{
								wy = e;
								num3 = i;
								if (num2 == -1)
								{
									num2 = i;
								}
								ww ww = A_0.a;
								bool flag3 = false;
								while (ww != null)
								{
									if (ww.b.a().fd() == e.a)
									{
										flag3 = true;
										if (x5.h(ww.a, w0.e) || (ww.c.b == ww.b && x5.h(ww.c.a, w0.e)))
										{
											ww = ww.c.c;
											if (e.d == wx.c)
											{
												flag2 = true;
											}
											if (e.d == wx.b)
											{
												flag = false;
											}
											break;
										}
										if (e.d == wx.c)
										{
											if (x5.g(ww.c.a, ww.b.a().b8()))
											{
												flag = false;
												break;
											}
										}
										else if (e.d == wx.a)
										{
											if (x5.g(ww.a, ww.b.a().b7()))
											{
												flag = false;
												break;
											}
										}
										else if (e.d == wx.b)
										{
											if (x5.g(ww.a, ww.b.a().b7()) || x5.g(ww.c.a, ww.b.a().b8()))
											{
												flag = false;
												break;
											}
										}
									}
									if (ww.c != null)
									{
										ww = ww.c.c;
									}
									else
									{
										ww = null;
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
						if (wy != null && wy.d == wx.a && !wy.b.a().fe())
						{
							x = wy.b.a().b8();
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

		// Token: 0x04001104 RID: 4356
		private x0[] a = new x0[2];

		// Token: 0x04001105 RID: 4357
		private int b = 0;

		// Token: 0x04001106 RID: 4358
		private int c = 0;
	}
}
