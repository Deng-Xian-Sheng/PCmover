using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001E9 RID: 489
	internal class mn : k0
	{
		// Token: 0x06001523 RID: 5411 RVA: 0x000EB128 File Offset: 0x000EA128
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001524 RID: 5412 RVA: 0x000EB140 File Offset: 0x000EA140
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001525 RID: 5413 RVA: 0x000EB150 File Offset: 0x000EA150
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x06001526 RID: 5414 RVA: 0x000EB168 File Offset: 0x000EA168
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001527 RID: 5415 RVA: 0x000EB174 File Offset: 0x000EA174
		internal override int dg()
		{
			return 15;
		}

		// Token: 0x06001528 RID: 5416 RVA: 0x000EB188 File Offset: 0x000EA188
		internal override k0 dd()
		{
			return new mn();
		}

		// Token: 0x06001529 RID: 5417 RVA: 0x000EB1A0 File Offset: 0x000EA1A0
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x0600152A RID: 5418 RVA: 0x000EB1BF File Offset: 0x000EA1BF
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x0600152B RID: 5419 RVA: 0x000EB1CC File Offset: 0x000EA1CC
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x0600152C RID: 5420 RVA: 0x000EB1E8 File Offset: 0x000EA1E8
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			if (base.n() != null)
			{
				base.c(A_0, A_1, A_2);
			}
		}

		// Token: 0x0600152D RID: 5421 RVA: 0x000EB210 File Offset: 0x000EA210
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x0600152E RID: 5422 RVA: 0x000EB228 File Offset: 0x000EA228
		internal override kz dm()
		{
			mn mn = new mn();
			mn.j(this.dr());
			mn.dc(this.db().du());
			mn.a((lk)base.c5().du());
			mn.df(this.b);
			if (base.n() != null)
			{
				mn.c(base.n().p());
			}
			return mn;
		}

		// Token: 0x040009EE RID: 2542
		private new n5 a = new n5();

		// Token: 0x040009EF RID: 2543
		private new bool b = false;
	}
}
