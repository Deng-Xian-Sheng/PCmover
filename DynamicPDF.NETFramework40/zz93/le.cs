using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001BA RID: 442
	internal class le : k0
	{
		// Token: 0x0600113A RID: 4410 RVA: 0x000C5D9C File Offset: 0x000C4D9C
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x0600113B RID: 4411 RVA: 0x000C5DB4 File Offset: 0x000C4DB4
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x0600113C RID: 4412 RVA: 0x000C5DC4 File Offset: 0x000C4DC4
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x0600113D RID: 4413 RVA: 0x000C5DDC File Offset: 0x000C4DDC
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600113E RID: 4414 RVA: 0x000C5DE8 File Offset: 0x000C4DE8
		internal override int dg()
		{
			return 57;
		}

		// Token: 0x0600113F RID: 4415 RVA: 0x000C5DFC File Offset: 0x000C4DFC
		internal override k0 dd()
		{
			return new le();
		}

		// Token: 0x06001140 RID: 4416 RVA: 0x000C5E14 File Offset: 0x000C4E14
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001141 RID: 4417 RVA: 0x000C5E33 File Offset: 0x000C4E33
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001142 RID: 4418 RVA: 0x000C5E40 File Offset: 0x000C4E40
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x06001143 RID: 4419 RVA: 0x000C5E5A File Offset: 0x000C4E5A
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x06001144 RID: 4420 RVA: 0x000C5E68 File Offset: 0x000C4E68
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x06001145 RID: 4421 RVA: 0x000C5E80 File Offset: 0x000C4E80
		internal override kz dm()
		{
			le le = new le();
			le.j(this.dr());
			le.dc(this.db().du());
			le.a((lk)base.c5().du());
			le.df(this.b);
			if (base.n() != null)
			{
				le.c(base.n().p());
			}
			return le;
		}

		// Token: 0x0400083A RID: 2106
		private new n5 a = new n5();

		// Token: 0x0400083B RID: 2107
		private new bool b = false;
	}
}
