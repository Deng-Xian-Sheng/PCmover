using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001E8 RID: 488
	internal class mm : k0
	{
		// Token: 0x06001516 RID: 5398 RVA: 0x000EAFA8 File Offset: 0x000E9FA8
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001517 RID: 5399 RVA: 0x000EAFC0 File Offset: 0x000E9FC0
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001518 RID: 5400 RVA: 0x000EAFD0 File Offset: 0x000E9FD0
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x06001519 RID: 5401 RVA: 0x000EAFE8 File Offset: 0x000E9FE8
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600151A RID: 5402 RVA: 0x000EAFF4 File Offset: 0x000E9FF4
		internal override int dg()
		{
			return 133455;
		}

		// Token: 0x0600151B RID: 5403 RVA: 0x000EB00C File Offset: 0x000EA00C
		internal override k0 dd()
		{
			return new mm();
		}

		// Token: 0x0600151C RID: 5404 RVA: 0x000EB024 File Offset: 0x000EA024
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x0600151D RID: 5405 RVA: 0x000EB043 File Offset: 0x000EA043
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x0600151E RID: 5406 RVA: 0x000EB050 File Offset: 0x000EA050
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x0600151F RID: 5407 RVA: 0x000EB06A File Offset: 0x000EA06A
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x06001520 RID: 5408 RVA: 0x000EB078 File Offset: 0x000EA078
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x06001521 RID: 5409 RVA: 0x000EB090 File Offset: 0x000EA090
		internal override kz dm()
		{
			mm mm = new mm();
			mm.j(this.dr());
			mm.dc(this.db().du());
			mm.a((lk)base.c5().du());
			mm.df(this.b);
			if (base.n() != null)
			{
				mm.c(base.n().p());
			}
			return mm;
		}

		// Token: 0x040009EC RID: 2540
		private new n5 a = new n5();

		// Token: 0x040009ED RID: 2541
		private new bool b = false;
	}
}
