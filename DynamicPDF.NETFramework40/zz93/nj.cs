using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000209 RID: 521
	internal class nj : k0
	{
		// Token: 0x060017CC RID: 6092 RVA: 0x000FF494 File Offset: 0x000FE494
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060017CD RID: 6093 RVA: 0x000FF4AC File Offset: 0x000FE4AC
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060017CE RID: 6094 RVA: 0x000FF4BC File Offset: 0x000FE4BC
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x060017CF RID: 6095 RVA: 0x000FF4D4 File Offset: 0x000FE4D4
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060017D0 RID: 6096 RVA: 0x000FF4E0 File Offset: 0x000FE4E0
		internal override int dg()
		{
			return 681579872;
		}

		// Token: 0x060017D1 RID: 6097 RVA: 0x000FF4F8 File Offset: 0x000FE4F8
		internal override k0 dd()
		{
			return new nj();
		}

		// Token: 0x060017D2 RID: 6098 RVA: 0x000FF510 File Offset: 0x000FE510
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x060017D3 RID: 6099 RVA: 0x000FF52F File Offset: 0x000FE52F
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x060017D4 RID: 6100 RVA: 0x000FF53C File Offset: 0x000FE53C
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x060017D5 RID: 6101 RVA: 0x000FF556 File Offset: 0x000FE556
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x060017D6 RID: 6102 RVA: 0x000FF564 File Offset: 0x000FE564
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x060017D7 RID: 6103 RVA: 0x000FF57C File Offset: 0x000FE57C
		internal override kz dm()
		{
			nj nj = new nj();
			nj.j(this.dr());
			nj.dc(this.db().du());
			nj.a((lk)base.c5().du());
			nj.df(this.b);
			if (base.n() != null)
			{
				nj.c(base.n().p());
			}
			return nj;
		}

		// Token: 0x04000AC3 RID: 2755
		private new n5 a = new n5();

		// Token: 0x04000AC4 RID: 2756
		private new bool b = false;
	}
}
