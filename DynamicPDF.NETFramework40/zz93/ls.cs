using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001C8 RID: 456
	internal class ls : k0
	{
		// Token: 0x06001330 RID: 4912 RVA: 0x000DA8B0 File Offset: 0x000D98B0
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001331 RID: 4913 RVA: 0x000DA8C8 File Offset: 0x000D98C8
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001332 RID: 4914 RVA: 0x000DA8D8 File Offset: 0x000D98D8
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x06001333 RID: 4915 RVA: 0x000DA8F0 File Offset: 0x000D98F0
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001334 RID: 4916 RVA: 0x000DA8FC File Offset: 0x000D98FC
		internal override int dg()
		{
			return 2315845;
		}

		// Token: 0x06001335 RID: 4917 RVA: 0x000DA914 File Offset: 0x000D9914
		internal override k0 dd()
		{
			return new ls();
		}

		// Token: 0x06001336 RID: 4918 RVA: 0x000DA92C File Offset: 0x000D992C
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001337 RID: 4919 RVA: 0x000DA94B File Offset: 0x000D994B
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001338 RID: 4920 RVA: 0x000DA958 File Offset: 0x000D9958
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x06001339 RID: 4921 RVA: 0x000DA972 File Offset: 0x000D9972
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x0600133A RID: 4922 RVA: 0x000DA980 File Offset: 0x000D9980
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x0600133B RID: 4923 RVA: 0x000DA998 File Offset: 0x000D9998
		internal override kz dm()
		{
			ls ls = new ls();
			ls.j(this.dr());
			ls.dc(this.db().du());
			ls.a((lk)base.c5().du());
			ls.df(this.b);
			if (base.n() != null)
			{
				ls.c(base.n().p());
			}
			return ls;
		}

		// Token: 0x04000939 RID: 2361
		private new n5 a = new n5();

		// Token: 0x0400093A RID: 2362
		private new bool b = false;
	}
}
