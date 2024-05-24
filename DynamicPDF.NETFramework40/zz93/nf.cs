using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000205 RID: 517
	internal class nf : k0
	{
		// Token: 0x06001788 RID: 6024 RVA: 0x000FACB8 File Offset: 0x000F9CB8
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001789 RID: 6025 RVA: 0x000FACD0 File Offset: 0x000F9CD0
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x0600178A RID: 6026 RVA: 0x000FACE0 File Offset: 0x000F9CE0
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x0600178B RID: 6027 RVA: 0x000FACF8 File Offset: 0x000F9CF8
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600178C RID: 6028 RVA: 0x000FAD04 File Offset: 0x000F9D04
		internal override int dg()
		{
			return 8736864;
		}

		// Token: 0x0600178D RID: 6029 RVA: 0x000FAD1C File Offset: 0x000F9D1C
		internal override k0 dd()
		{
			return new nf();
		}

		// Token: 0x0600178E RID: 6030 RVA: 0x000FAD34 File Offset: 0x000F9D34
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x0600178F RID: 6031 RVA: 0x000FAD53 File Offset: 0x000F9D53
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001790 RID: 6032 RVA: 0x000FAD60 File Offset: 0x000F9D60
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x06001791 RID: 6033 RVA: 0x000FAD7A File Offset: 0x000F9D7A
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x06001792 RID: 6034 RVA: 0x000FAD88 File Offset: 0x000F9D88
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x06001793 RID: 6035 RVA: 0x000FADA0 File Offset: 0x000F9DA0
		internal override kz dm()
		{
			nf nf = new nf();
			nf.j(this.dr());
			nf.dc(this.db().du());
			nf.a((lk)base.c5().du());
			nf.df(this.b);
			if (base.n() != null)
			{
				nf.c(base.n().p());
			}
			return nf;
		}

		// Token: 0x04000AB7 RID: 2743
		private new n5 a = new n5();

		// Token: 0x04000AB8 RID: 2744
		private new bool b = false;
	}
}
