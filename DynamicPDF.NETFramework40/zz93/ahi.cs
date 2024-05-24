using System;

namespace zz93
{
	// Token: 0x020004FD RID: 1277
	internal class ahi
	{
		// Token: 0x0600340E RID: 13326 RVA: 0x001CDEE0 File Offset: 0x001CCEE0
		internal ahi(agv A_0)
		{
			this.a = A_0;
			A_0.li();
		}

		// Token: 0x0600340F RID: 13327 RVA: 0x001CDF04 File Offset: 0x001CCF04
		internal void a(abt A_0)
		{
			this.b(A_0);
			while (this.a.lk())
			{
				this.b(A_0);
			}
		}

		// Token: 0x06003410 RID: 13328 RVA: 0x001CDF38 File Offset: 0x001CCF38
		internal void b(abt A_0)
		{
			int num = this.a.ln();
			int num2 = this.a.ln();
			int num3 = num + num2;
			A_0.a((long)num3);
			this.a.lo();
			long num4 = 0L;
			for (int i = num; i <= num3; i++)
			{
				bool flag = false;
				if (i == num3)
				{
					flag = true;
				}
				if (A_0.b((long)i) == null)
				{
					long num5 = this.a.lg(flag);
					if (num5 > 7L)
					{
						ab9 a_ = new ab9(this.a.lp(), i, num5);
						A_0.a(a_, (long)i);
						if (num4 == num5 && i - 1 > num)
						{
							((ab9)A_0.b((long)(i - 1))).b(0L);
						}
						num4 = num5;
					}
				}
				else if (!flag)
				{
					this.a.lh();
				}
			}
			if (this.b > num)
			{
				this.b = num;
			}
		}

		// Token: 0x06003411 RID: 13329 RVA: 0x001CE070 File Offset: 0x001CD070
		internal int a()
		{
			return this.b;
		}

		// Token: 0x0400192B RID: 6443
		private agv a;

		// Token: 0x0400192C RID: 6444
		private int b = int.MaxValue;
	}
}
