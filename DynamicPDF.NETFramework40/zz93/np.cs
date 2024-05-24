using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200020F RID: 527
	internal class np : k0
	{
		// Token: 0x06001823 RID: 6179 RVA: 0x00101054 File Offset: 0x00100054
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001824 RID: 6180 RVA: 0x0010106C File Offset: 0x0010006C
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001825 RID: 6181 RVA: 0x0010107C File Offset: 0x0010007C
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x06001826 RID: 6182 RVA: 0x00101094 File Offset: 0x00100094
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001827 RID: 6183 RVA: 0x001010A0 File Offset: 0x001000A0
		internal override int dg()
		{
			return 627435190;
		}

		// Token: 0x06001828 RID: 6184 RVA: 0x001010B8 File Offset: 0x001000B8
		internal override k0 dd()
		{
			np np = new np();
			np.ab(base.ci());
			np.aa(base.ch());
			return np;
		}

		// Token: 0x06001829 RID: 6185 RVA: 0x001010EC File Offset: 0x001000EC
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x0600182A RID: 6186 RVA: 0x0010110B File Offset: 0x0010010B
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x0600182B RID: 6187 RVA: 0x00101118 File Offset: 0x00100118
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x0600182C RID: 6188 RVA: 0x00101132 File Offset: 0x00100132
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x0600182D RID: 6189 RVA: 0x00101140 File Offset: 0x00100140
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x0600182E RID: 6190 RVA: 0x00101158 File Offset: 0x00100158
		internal override kz dm()
		{
			np np = new np();
			np.j(this.dr());
			np.dc(this.db().du());
			np.a((lk)base.c5().du());
			np.df(this.b);
			if (base.n() != null)
			{
				np.c(base.n().p());
			}
			return np;
		}

		// Token: 0x04000ADD RID: 2781
		private new n5 a = new n5();

		// Token: 0x04000ADE RID: 2782
		private new bool b = false;
	}
}
