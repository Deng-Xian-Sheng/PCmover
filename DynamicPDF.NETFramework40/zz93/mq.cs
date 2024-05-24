using System;

namespace zz93
{
	// Token: 0x020001EC RID: 492
	internal class mq
	{
		// Token: 0x06001549 RID: 5449 RVA: 0x000EB5A8 File Offset: 0x000EA5A8
		internal mq()
		{
		}

		// Token: 0x0600154A RID: 5450 RVA: 0x000EB5BA File Offset: 0x000EA5BA
		internal mq(kz A_0)
		{
			this.a = new mr(A_0);
			this.c++;
			this.b = this.a;
		}

		// Token: 0x0600154B RID: 5451 RVA: 0x000EB5F4 File Offset: 0x000EA5F4
		internal void a(kz A_0)
		{
			mr mr = new mr(A_0);
			this.c++;
			this.b.a(mr);
			mr.b(this.b);
			this.b = mr;
		}

		// Token: 0x0600154C RID: 5452 RVA: 0x000EB638 File Offset: 0x000EA638
		internal mr a()
		{
			return this.a;
		}

		// Token: 0x0600154D RID: 5453 RVA: 0x000EB650 File Offset: 0x000EA650
		internal void a(mr A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600154E RID: 5454 RVA: 0x000EB65C File Offset: 0x000EA65C
		internal mr b()
		{
			return this.b;
		}

		// Token: 0x0600154F RID: 5455 RVA: 0x000EB674 File Offset: 0x000EA674
		internal int c()
		{
			return this.c;
		}

		// Token: 0x06001550 RID: 5456 RVA: 0x000EB68C File Offset: 0x000EA68C
		internal void a(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001551 RID: 5457 RVA: 0x000EB698 File Offset: 0x000EA698
		internal mq d()
		{
			mq mq = new mq();
			mr mr = this.a;
			if (mr != null && mr.b() != null)
			{
				mr mr2 = new mr(mr.b().dm());
				mr mr3 = mr2;
				for (mr = mr.c(); mr != null; mr = mr.c())
				{
					mr mr4 = new mr(mr.b().dm());
					mr3.a(mr4);
					mr4.b(mr3);
					mr3 = mr4;
				}
				mq.a(mr2);
			}
			return mq;
		}

		// Token: 0x040009F4 RID: 2548
		private mr a;

		// Token: 0x040009F5 RID: 2549
		private mr b;

		// Token: 0x040009F6 RID: 2550
		private int c = 0;
	}
}
