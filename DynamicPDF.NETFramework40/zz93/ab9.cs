using System;

namespace zz93
{
	// Token: 0x0200043B RID: 1083
	internal class ab9 : abg
	{
		// Token: 0x06002CC9 RID: 11465 RVA: 0x001984D8 File Offset: 0x001974D8
		internal ab9(aba A_0, int A_1, long A_2) : base(A_0, A_1)
		{
			this.a = A_2;
		}

		// Token: 0x06002CCA RID: 11466 RVA: 0x001984F4 File Offset: 0x001974F4
		internal override abd h0()
		{
			return base.m().ld(this);
		}

		// Token: 0x06002CCB RID: 11467 RVA: 0x00198514 File Offset: 0x00197514
		internal override afj ia()
		{
			afj afj = base.ia();
			afj result;
			if (afj == null)
			{
				abd abd = this.h0();
				result = (afj)abd;
			}
			else
			{
				result = afj;
			}
			return result;
		}

		// Token: 0x06002CCC RID: 11468 RVA: 0x0019854A File Offset: 0x0019754A
		internal void a(long A_0)
		{
			this.c = A_0 - this.a - 5L;
		}

		// Token: 0x06002CCD RID: 11469 RVA: 0x00198560 File Offset: 0x00197560
		internal long a()
		{
			return this.a;
		}

		// Token: 0x06002CCE RID: 11470 RVA: 0x00198578 File Offset: 0x00197578
		internal void b(long A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002CCF RID: 11471 RVA: 0x00198584 File Offset: 0x00197584
		internal long b()
		{
			return this.b;
		}

		// Token: 0x06002CD0 RID: 11472 RVA: 0x0019859C File Offset: 0x0019759C
		internal void c(long A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06002CD1 RID: 11473 RVA: 0x001985A8 File Offset: 0x001975A8
		internal long c()
		{
			return this.c;
		}

		// Token: 0x0400150C RID: 5388
		private new long a;

		// Token: 0x0400150D RID: 5389
		private new long b;

		// Token: 0x0400150E RID: 5390
		private long c = -1L;
	}
}
