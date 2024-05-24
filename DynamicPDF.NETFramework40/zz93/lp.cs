using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001C5 RID: 453
	internal class lp : k0
	{
		// Token: 0x06001312 RID: 4882 RVA: 0x000DA400 File Offset: 0x000D9400
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001313 RID: 4883 RVA: 0x000DA418 File Offset: 0x000D9418
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001314 RID: 4884 RVA: 0x000DA428 File Offset: 0x000D9428
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x06001315 RID: 4885 RVA: 0x000DA440 File Offset: 0x000D9440
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001316 RID: 4886 RVA: 0x000DA44C File Offset: 0x000D944C
		internal override k0 dd()
		{
			lp lp = new lp();
			lp.ab(base.ci());
			lp.aa(base.ch());
			return lp;
		}

		// Token: 0x06001317 RID: 4887 RVA: 0x000DA480 File Offset: 0x000D9480
		internal override int dg()
		{
			return 141185593;
		}

		// Token: 0x06001318 RID: 4888 RVA: 0x000DA498 File Offset: 0x000D9498
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001319 RID: 4889 RVA: 0x000DA4B7 File Offset: 0x000D94B7
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x0600131A RID: 4890 RVA: 0x000DA4C4 File Offset: 0x000D94C4
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

		// Token: 0x0600131B RID: 4891 RVA: 0x000DA504 File Offset: 0x000D9504
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

		// Token: 0x0600131C RID: 4892 RVA: 0x000DA544 File Offset: 0x000D9544
		internal override kz dm()
		{
			lp lp = new lp();
			lp.j(this.dr());
			lp.dc(this.db().du());
			lp.a((lk)base.c5().du());
			lp.df(this.b);
			if (base.n() != null)
			{
				lp.c(base.n().p());
			}
			return lp;
		}

		// Token: 0x04000931 RID: 2353
		private new n5 a = new n5();

		// Token: 0x04000932 RID: 2354
		private new bool b = true;
	}
}
