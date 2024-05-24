using System;

namespace zz93
{
	// Token: 0x0200056F RID: 1391
	internal class akm
	{
		// Token: 0x0600375A RID: 14170 RVA: 0x001DF14B File Offset: 0x001DE14B
		internal akm()
		{
		}

		// Token: 0x0600375B RID: 14171 RVA: 0x001DF16C File Offset: 0x001DE16C
		internal void a(ahs A_0)
		{
			if (this.b == null)
			{
				this.a = (this.b = new akm.a(A_0));
			}
			else
			{
				this.b = (this.b.b = new akm.a(A_0));
			}
			this.c += this.b.a.b();
		}

		// Token: 0x0600375C RID: 14172 RVA: 0x001DF1DC File Offset: 0x001DE1DC
		internal int a()
		{
			return this.c;
		}

		// Token: 0x0600375D RID: 14173 RVA: 0x001DF1F4 File Offset: 0x001DE1F4
		internal akm.a b()
		{
			return this.a;
		}

		// Token: 0x04001A2E RID: 6702
		private akm.a a = null;

		// Token: 0x04001A2F RID: 6703
		private akm.a b = null;

		// Token: 0x04001A30 RID: 6704
		private int c = 0;

		// Token: 0x02000570 RID: 1392
		internal class a
		{
			// Token: 0x0600375E RID: 14174 RVA: 0x001DF20C File Offset: 0x001DE20C
			internal a(ahs A_0)
			{
				this.a = A_0;
				this.b = null;
			}

			// Token: 0x04001A31 RID: 6705
			internal ahs a;

			// Token: 0x04001A32 RID: 6706
			internal akm.a b;
		}
	}
}
