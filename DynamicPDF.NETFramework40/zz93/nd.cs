using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000203 RID: 515
	internal class nd : k0
	{
		// Token: 0x06001772 RID: 6002 RVA: 0x000FA9BC File Offset: 0x000F99BC
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001773 RID: 6003 RVA: 0x000FA9D4 File Offset: 0x000F99D4
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001774 RID: 6004 RVA: 0x000FA9E4 File Offset: 0x000F99E4
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x06001775 RID: 6005 RVA: 0x000FA9FC File Offset: 0x000F99FC
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001776 RID: 6006 RVA: 0x000FAA08 File Offset: 0x000F9A08
		internal override int dg()
		{
			return 28;
		}

		// Token: 0x06001777 RID: 6007 RVA: 0x000FAA1C File Offset: 0x000F9A1C
		internal override k0 dd()
		{
			return new nd();
		}

		// Token: 0x06001778 RID: 6008 RVA: 0x000FAA34 File Offset: 0x000F9A34
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001779 RID: 6009 RVA: 0x000FAA53 File Offset: 0x000F9A53
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x0600177A RID: 6010 RVA: 0x000FAA60 File Offset: 0x000F9A60
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x0600177B RID: 6011 RVA: 0x000FAA7A File Offset: 0x000F9A7A
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x0600177C RID: 6012 RVA: 0x000FAA88 File Offset: 0x000F9A88
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x0600177D RID: 6013 RVA: 0x000FAAA0 File Offset: 0x000F9AA0
		internal override kz dm()
		{
			nd nd = new nd();
			nd.j(this.dr());
			nd.dc(this.db().du());
			nd.a((lk)base.c5().du());
			nd.df(this.b);
			if (base.n() != null)
			{
				nd.c(base.n().p());
			}
			return nd;
		}

		// Token: 0x04000AB0 RID: 2736
		private new n5 a = new n5();

		// Token: 0x04000AB1 RID: 2737
		private new bool b = false;
	}
}
