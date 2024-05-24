using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001CA RID: 458
	internal class lu : k0
	{
		// Token: 0x06001365 RID: 4965 RVA: 0x000DD25C File Offset: 0x000DC25C
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001366 RID: 4966 RVA: 0x000DD274 File Offset: 0x000DC274
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001367 RID: 4967 RVA: 0x000DD284 File Offset: 0x000DC284
		internal override int dg()
		{
			return 3445;
		}

		// Token: 0x06001368 RID: 4968 RVA: 0x000DD29C File Offset: 0x000DC29C
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x06001369 RID: 4969 RVA: 0x000DD2B4 File Offset: 0x000DC2B4
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600136A RID: 4970 RVA: 0x000DD2C0 File Offset: 0x000DC2C0
		internal override k0 dd()
		{
			lu lu = new lu();
			lu.ab(base.ci());
			lu.aa(base.ch());
			return lu;
		}

		// Token: 0x0600136B RID: 4971 RVA: 0x000DD2F4 File Offset: 0x000DC2F4
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x0600136C RID: 4972 RVA: 0x000DD313 File Offset: 0x000DC313
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x0600136D RID: 4973 RVA: 0x000DD320 File Offset: 0x000DC320
		internal override kz dj(x5 A_0, x5 A_1)
		{
			kz result;
			switch (this.de())
			{
			case false:
				result = base.c(A_0, A_1);
				break;
			case true:
				result = base.f(A_0, A_1);
				break;
			default:
				result = null;
				break;
			}
			return result;
		}

		// Token: 0x0600136E RID: 4974 RVA: 0x000DD360 File Offset: 0x000DC360
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			switch (this.de())
			{
			case false:
				base.c(A_0, A_1, A_2);
				break;
			case true:
				base.d(A_0, A_1, A_2);
				break;
			}
		}

		// Token: 0x0600136F RID: 4975 RVA: 0x000DD3A0 File Offset: 0x000DC3A0
		internal override kz dm()
		{
			lu lu = new lu();
			lu.j(this.dr());
			lu.dc(this.db().du());
			lu.a((lk)base.c5().du());
			lu.df(this.b);
			if (base.n() != null)
			{
				lu.c(base.n().p());
			}
			return lu;
		}

		// Token: 0x04000940 RID: 2368
		private new n5 a = new n5();

		// Token: 0x04000941 RID: 2369
		private new bool b = true;
	}
}
