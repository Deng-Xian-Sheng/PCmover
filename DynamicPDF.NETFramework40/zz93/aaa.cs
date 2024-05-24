using System;

namespace zz93
{
	// Token: 0x020003EB RID: 1003
	internal class aaa
	{
		// Token: 0x060029FF RID: 10751 RVA: 0x00186EE8 File Offset: 0x00185EE8
		internal aaa(z4 A_0, z7 A_1)
		{
			this.a = A_0;
			this.d = A_0.a(A_0.i()).b();
			this.e = A_0.n() - A_0.i();
			if (this.e != A_1.b().d())
			{
				A_1.b().b(this.e);
				if (A_1.d() < this.e)
				{
					A_1.c(this.e);
				}
				if (A_1.c() > this.e)
				{
					A_1.b(this.e);
				}
			}
			this.f = A_0.a(A_0.k()).b();
			this.g = A_0.l();
			int num = A_0.i();
			for (int i = 0; i < this.e; i++)
			{
				if (this.b > A_0.a(num).a())
				{
					this.b = A_0.a(num).a();
				}
				if (this.c < A_0.a(num).a())
				{
					this.c = A_0.a(num).a();
				}
				num++;
			}
			num = A_0.k();
			for (int i = 0; i < this.g; i++)
			{
				if (this.b > A_0.a(num).a())
				{
					this.b = A_0.a(num).a();
				}
				if (this.c < A_0.a(num).a())
				{
					this.c = A_0.a(num).a();
				}
				num++;
			}
		}

		// Token: 0x06002A00 RID: 10752 RVA: 0x001870CC File Offset: 0x001860CC
		internal int a()
		{
			return this.a.j() + this.a.l();
		}

		// Token: 0x06002A01 RID: 10753 RVA: 0x001870F8 File Offset: 0x001860F8
		internal int a(int A_0)
		{
			int result;
			if (A_0 >= this.d)
			{
				result = A_0 - this.d;
			}
			else
			{
				result = A_0 - this.f + this.e;
			}
			return result;
		}

		// Token: 0x06002A02 RID: 10754 RVA: 0x00187134 File Offset: 0x00186134
		internal void a(zy A_0)
		{
			int num = A_0.a(this.b, this.c);
			A_0.a(this.a.a(this.a.k()).b());
			A_0.a(this.a.a(this.a.k()).c());
			A_0.a(this.e);
			A_0.a(this.a.l() + this.e);
			A_0.c(2);
			if (this.a.l() > 0)
			{
				A_0.a(this.b);
			}
			else
			{
				A_0.a(0);
			}
			A_0.b(num);
			int num2 = this.a.i();
			for (int i = 0; i < this.e; i++)
			{
				A_0.b(this.a.a(num2++).a() - this.b, num);
			}
			num2 = this.a.k();
			for (int i = 0; i < this.g; i++)
			{
				A_0.b(this.a.a(num2++).a() - this.b, num);
			}
			A_0.e();
			A_0.c((this.g + this.e) / 8);
			A_0.e();
			A_0.c((this.g + this.e) / 8);
			A_0.e();
		}

		// Token: 0x04001334 RID: 4916
		private z4 a;

		// Token: 0x04001335 RID: 4917
		private int b = int.MaxValue;

		// Token: 0x04001336 RID: 4918
		private int c = 0;

		// Token: 0x04001337 RID: 4919
		private int d;

		// Token: 0x04001338 RID: 4920
		private int e;

		// Token: 0x04001339 RID: 4921
		private int f;

		// Token: 0x0400133A RID: 4922
		private int g;
	}
}
