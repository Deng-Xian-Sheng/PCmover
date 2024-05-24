using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200020B RID: 523
	internal class nl : k0
	{
		// Token: 0x060017EA RID: 6122 RVA: 0x000FF94C File Offset: 0x000FE94C
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060017EB RID: 6123 RVA: 0x000FF964 File Offset: 0x000FE964
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060017EC RID: 6124 RVA: 0x000FF974 File Offset: 0x000FE974
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x060017ED RID: 6125 RVA: 0x000FF98C File Offset: 0x000FE98C
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060017EE RID: 6126 RVA: 0x000FF998 File Offset: 0x000FE998
		internal override int dg()
		{
			return 9705568;
		}

		// Token: 0x060017EF RID: 6127 RVA: 0x000FF9B0 File Offset: 0x000FE9B0
		internal override k0 dd()
		{
			return new nl();
		}

		// Token: 0x060017F0 RID: 6128 RVA: 0x000FF9C8 File Offset: 0x000FE9C8
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x060017F1 RID: 6129 RVA: 0x000FF9E7 File Offset: 0x000FE9E7
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x060017F2 RID: 6130 RVA: 0x000FF9F4 File Offset: 0x000FE9F4
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x060017F3 RID: 6131 RVA: 0x000FFA10 File Offset: 0x000FEA10
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x060017F4 RID: 6132 RVA: 0x000FFA28 File Offset: 0x000FEA28
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x060017F5 RID: 6133 RVA: 0x000FFA38 File Offset: 0x000FEA38
		internal override kz dm()
		{
			nl nl = new nl();
			nl.j(this.dr());
			nl.dc(this.db().du());
			nl.a((lk)base.c5().du());
			nl.df(this.b);
			if (base.n() != null)
			{
				nl.c(base.n().p());
			}
			return nl;
		}

		// Token: 0x04000ACA RID: 2762
		private new n5 a = new n5();

		// Token: 0x04000ACB RID: 2763
		private new bool b = false;
	}
}
