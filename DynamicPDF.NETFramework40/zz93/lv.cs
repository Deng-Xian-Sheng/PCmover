using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001CB RID: 459
	internal class lv : k0
	{
		// Token: 0x06001371 RID: 4977 RVA: 0x000DD438 File Offset: 0x000DC438
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001372 RID: 4978 RVA: 0x000DD450 File Offset: 0x000DC450
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001373 RID: 4979 RVA: 0x000DD460 File Offset: 0x000DC460
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x06001374 RID: 4980 RVA: 0x000DD478 File Offset: 0x000DC478
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001375 RID: 4981 RVA: 0x000DD484 File Offset: 0x000DC484
		internal override int dg()
		{
			return 164405;
		}

		// Token: 0x06001376 RID: 4982 RVA: 0x000DD49C File Offset: 0x000DC49C
		internal override k0 dd()
		{
			return new lv();
		}

		// Token: 0x06001377 RID: 4983 RVA: 0x000DD4B4 File Offset: 0x000DC4B4
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001378 RID: 4984 RVA: 0x000DD4D3 File Offset: 0x000DC4D3
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001379 RID: 4985 RVA: 0x000DD4E0 File Offset: 0x000DC4E0
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x0600137A RID: 4986 RVA: 0x000DD4FA File Offset: 0x000DC4FA
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x0600137B RID: 4987 RVA: 0x000DD508 File Offset: 0x000DC508
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x0600137C RID: 4988 RVA: 0x000DD520 File Offset: 0x000DC520
		internal override kz dm()
		{
			lv lv = new lv();
			lv.j(this.dr());
			lv.dc(this.db().du());
			lv.a((lk)base.c5().du());
			lv.df(this.b);
			if (base.n() != null)
			{
				lv.c(base.n().p());
			}
			return lv;
		}

		// Token: 0x04000942 RID: 2370
		private new n5 a = new n5();

		// Token: 0x04000943 RID: 2371
		private new bool b = false;
	}
}
