using System;

namespace zz93
{
	// Token: 0x020003E8 RID: 1000
	internal class z7
	{
		// Token: 0x060029EB RID: 10731 RVA: 0x001868B4 File Offset: 0x001858B4
		internal z7(int A_0)
		{
			this.a = new z6[A_0];
		}

		// Token: 0x060029EC RID: 10732 RVA: 0x00186908 File Offset: 0x00185908
		internal void a(zz A_0)
		{
			this.a[this.g++] = new z6(A_0);
		}

		// Token: 0x060029ED RID: 10733 RVA: 0x00186934 File Offset: 0x00185934
		internal z6 b()
		{
			return this.a[0];
		}

		// Token: 0x060029EE RID: 10734 RVA: 0x00186950 File Offset: 0x00185950
		internal int c()
		{
			return this.b;
		}

		// Token: 0x060029EF RID: 10735 RVA: 0x00186968 File Offset: 0x00185968
		internal void b(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060029F0 RID: 10736 RVA: 0x00186974 File Offset: 0x00185974
		internal int d()
		{
			return this.c;
		}

		// Token: 0x060029F1 RID: 10737 RVA: 0x0018698C File Offset: 0x0018598C
		internal void c(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060029F2 RID: 10738 RVA: 0x00186998 File Offset: 0x00185998
		internal void e()
		{
			this.a[0].a();
			int minValue = int.MinValue;
			for (int i = 1; i < this.a.Length; i++)
			{
				this.a[i].a(minValue++);
			}
		}

		// Token: 0x060029F3 RID: 10739 RVA: 0x001869E6 File Offset: 0x001859E6
		internal void d(int A_0)
		{
			this.a();
			this.a(A_0);
		}

		// Token: 0x060029F4 RID: 10740 RVA: 0x001869F8 File Offset: 0x001859F8
		private void a(int A_0)
		{
			int a_ = A_0;
			for (int i = this.a.Length - 1; i >= 0; i--)
			{
				this.a[i].c(a_);
				a_ = this.a[i].b().c();
				if (this.a[i].c() < this.e)
				{
					this.e = this.a[i].c();
				}
				if (this.a[i].c() > this.f)
				{
					this.f = this.a[i].c();
				}
			}
		}

		// Token: 0x060029F5 RID: 10741 RVA: 0x00186AAC File Offset: 0x00185AAC
		internal void a(zy A_0, aaa A_1)
		{
			int num = A_0.a(this.b, this.c);
			int num2 = A_0.a(this.e, this.f);
			int num3 = A_0.d(this.d);
			int num4 = A_0.d(A_1.a());
			A_0.a(this.b);
			A_0.a(this.a[0].b().c());
			A_0.b(num);
			A_0.a(this.e);
			A_0.b(num2);
			A_0.c(10);
			A_0.b(num2);
			A_0.b(num3);
			A_0.b(num4);
			A_0.b(2);
			A_0.b(1);
			for (int i = 0; i < this.a.Length; i++)
			{
				A_0.b(this.a[i].d() - this.b, num);
			}
			A_0.e();
			for (int i = 0; i < this.a.Length; i++)
			{
				A_0.b(this.a[i].c() - this.e, num2);
			}
			A_0.e();
			for (int i = 0; i < this.a.Length; i++)
			{
				A_0.b(this.a[i].e(), num3);
			}
			A_0.e();
			for (int i = 1; i < this.a.Length; i++)
			{
				this.a[i].a(A_0, num4, A_1);
			}
			A_0.e();
			for (int i = 1; i < this.a.Length; i++)
			{
				this.a[i].a(A_0);
			}
			A_0.e();
			for (int i = 0; i < this.a.Length; i++)
			{
				A_0.b(this.a[i].c() - this.e, num2);
			}
			A_0.e();
		}

		// Token: 0x060029F6 RID: 10742 RVA: 0x00186CD8 File Offset: 0x00185CD8
		private void a()
		{
			this.a[0].g();
			if (this.a[0].d() < this.b)
			{
				this.b = this.a[0].d();
			}
			if (this.a[0].d() > this.c)
			{
				this.c = this.a[0].d();
			}
			for (int i = 1; i < this.a.Length; i++)
			{
				this.a[i].f();
				if (this.a[i].d() < this.b)
				{
					this.b = this.a[i].d();
				}
				if (this.a[i].d() > this.c)
				{
					this.c = this.a[i].d();
				}
				if (this.a[i].e() > this.d)
				{
					this.d = this.a[i].e();
				}
			}
		}

		// Token: 0x04001328 RID: 4904
		private z6[] a;

		// Token: 0x04001329 RID: 4905
		private int b = int.MaxValue;

		// Token: 0x0400132A RID: 4906
		private int c = 0;

		// Token: 0x0400132B RID: 4907
		private int d = 0;

		// Token: 0x0400132C RID: 4908
		private int e = int.MaxValue;

		// Token: 0x0400132D RID: 4909
		private int f = 0;

		// Token: 0x0400132E RID: 4910
		private int g = 0;
	}
}
