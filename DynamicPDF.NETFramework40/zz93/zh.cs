using System;

namespace zz93
{
	// Token: 0x020003CE RID: 974
	internal class zh
	{
		// Token: 0x06002906 RID: 10502 RVA: 0x0017E2D0 File Offset: 0x0017D2D0
		internal zh(int A_0, agk A_1)
		{
			this.i = A_1;
			this.c = A_0;
			this.d = (this.e = new br(512));
			this.h = 1024;
		}

		// Token: 0x06002907 RID: 10503 RVA: 0x0017E334 File Offset: 0x0017D334
		private agh a()
		{
			long num = this.i.b();
			br br = this.e;
			this.i.a(br.a(), this.g, br.b());
			if (br.c() != null)
			{
				br = this.e.c();
				do
				{
					this.i.a(br.a(), br.b());
					br = br.c();
				}
				while (br != null);
			}
			this.c();
			return new agh(this.i, num, (int)(this.i.b() - num));
		}

		// Token: 0x06002908 RID: 10504 RVA: 0x0017E3E0 File Offset: 0x0017D3E0
		internal bp b()
		{
			bp result;
			if (this.i != null)
			{
				result = this.a();
			}
			else
			{
				bq bq = new bq(this.e, this.g, this.f + this.d.b());
				this.e = this.d;
				this.g = this.d.b();
				this.f = -this.g;
				result = bq;
			}
			return result;
		}

		// Token: 0x06002909 RID: 10505 RVA: 0x0017E458 File Offset: 0x0017D458
		internal bv a(bp A_0)
		{
			bp a_ = this.b();
			return new bv(a_, A_0);
		}

		// Token: 0x0600290A RID: 10506 RVA: 0x0017E47A File Offset: 0x0017D47A
		internal void c()
		{
			this.d = this.e;
			this.d.a(this.g);
			this.f = -this.g;
		}

		// Token: 0x0600290B RID: 10507 RVA: 0x0017E4A8 File Offset: 0x0017D4A8
		internal bp a(zh A_0, yx A_1)
		{
			y0 y = new y0(this.c);
			A_1.k7();
			if (this.d == this.e)
			{
				y.b(this.e.a(), this.g, this.d.b() - this.g);
				A_1.k4(y);
			}
			else
			{
				int num = this.f + this.d.b();
				br br = this.e;
				int num2 = br.b() - this.g;
				y.b(br.a(), this.g, num2);
				A_1.k4(y);
				br = this.e.c();
				do
				{
					int num3 = num - num2;
					if (br.b() < num3)
					{
						num3 = br.b();
					}
					y.b(br.a(), 0, num3);
					A_1.k4(y);
					num2 += num3;
					br = br.c();
				}
				while (br != null && num2 < num);
			}
			return A_0.a(y, A_1);
		}

		// Token: 0x0600290C RID: 10508 RVA: 0x0017E5D4 File Offset: 0x0017D5D4
		internal bp a(yx A_0)
		{
			y0 a_ = new y0(this.c);
			A_0.k7();
			return this.a(a_, A_0);
		}

		// Token: 0x0600290D RID: 10509 RVA: 0x0017E604 File Offset: 0x0017D604
		internal bp a(y0 A_0, yx A_1)
		{
			bp result;
			if (this.d == this.e)
			{
				A_0.b(this.e.a(), this.g, this.e.b() - this.g);
				A_0.b();
				A_1.k5(A_0);
				this.c();
				result = A_1.k6();
			}
			else
			{
				int num = this.f + this.d.b();
				int num2 = this.e.b() - this.g;
				A_0.b(this.e.a(), this.g, num2);
				A_1.k4(A_0);
				br br = this.e.c();
				bool flag;
				do
				{
					int num3 = num - num2;
					flag = true;
					if (br.b() < num3)
					{
						flag = false;
						num3 = br.b();
					}
					A_0.b(br.a(), 0, num3);
					if (flag)
					{
						A_0.b();
						A_1.k5(A_0);
					}
					else
					{
						A_1.k4(A_0);
					}
					num2 += num3;
					br = br.c();
				}
				while (!flag);
				this.c();
				result = A_1.k6();
			}
			return result;
		}

		// Token: 0x0600290E RID: 10510 RVA: 0x0017E754 File Offset: 0x0017D754
		internal br b(int A_0)
		{
			this.a(A_0);
			return this.d;
		}

		// Token: 0x0600290F RID: 10511 RVA: 0x0017E774 File Offset: 0x0017D774
		private void a(int A_0)
		{
			if (this.d.b() + A_0 > this.d.a().Length)
			{
				if (this.d.b() == 0 && A_0 > this.h)
				{
					this.d.b(A_0);
				}
				else
				{
					if (this.d.c() == null)
					{
						if (A_0 > this.h)
						{
							this.d.a(new br(A_0));
						}
						else
						{
							this.d.a(new br(this.h));
							this.h += 512;
						}
					}
					else
					{
						if (A_0 > this.d.c().a().Length)
						{
							this.d.c().b(A_0);
						}
						this.d.c().a(0);
					}
					if (this.d == this.e && this.d.b() == this.g)
					{
						this.e = this.d.c();
						this.g = 0;
						this.f = 0;
					}
					else
					{
						this.f += this.d.b();
					}
					this.d = this.d.c();
				}
			}
		}

		// Token: 0x04001294 RID: 4756
		private const int a = 512;

		// Token: 0x04001295 RID: 4757
		private const int b = 512;

		// Token: 0x04001296 RID: 4758
		private int c;

		// Token: 0x04001297 RID: 4759
		private br d;

		// Token: 0x04001298 RID: 4760
		private br e;

		// Token: 0x04001299 RID: 4761
		private int f = 0;

		// Token: 0x0400129A RID: 4762
		private int g = 0;

		// Token: 0x0400129B RID: 4763
		private int h = 512;

		// Token: 0x0400129C RID: 4764
		private agk i;
	}
}
