using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001CD RID: 461
	internal class lx : k0
	{
		// Token: 0x0600138B RID: 5003 RVA: 0x000DD738 File Offset: 0x000DC738
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x0600138C RID: 5004 RVA: 0x000DD750 File Offset: 0x000DC750
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x0600138D RID: 5005 RVA: 0x000DD760 File Offset: 0x000DC760
		internal override int dg()
		{
			return 95221;
		}

		// Token: 0x0600138E RID: 5006 RVA: 0x000DD778 File Offset: 0x000DC778
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x0600138F RID: 5007 RVA: 0x000DD790 File Offset: 0x000DC790
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001390 RID: 5008 RVA: 0x000DD79C File Offset: 0x000DC79C
		internal override k0 dd()
		{
			return new lx();
		}

		// Token: 0x06001391 RID: 5009 RVA: 0x000DD7B4 File Offset: 0x000DC7B4
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001392 RID: 5010 RVA: 0x000DD7D3 File Offset: 0x000DC7D3
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001393 RID: 5011 RVA: 0x000DD7E0 File Offset: 0x000DC7E0
		internal override kz dj(x5 A_0, x5 A_1)
		{
			kz result;
			if (this.b)
			{
				result = base.f(A_0, A_1);
			}
			else
			{
				result = base.c(A_0, A_1);
			}
			return result;
		}

		// Token: 0x06001394 RID: 5012 RVA: 0x000DD814 File Offset: 0x000DC814
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			if (this.b)
			{
				base.d(A_0, A_1, A_2);
			}
			else
			{
				base.c(A_0, A_1, A_2);
			}
		}

		// Token: 0x06001395 RID: 5013 RVA: 0x000DD848 File Offset: 0x000DC848
		internal override kz dm()
		{
			lx lx = new lx();
			lx.j(this.dr());
			lx.dc(this.db().du());
			lx.a((lk)base.c5().du());
			lx.df(this.b);
			lx.ap(this.c3());
			lx.a(base.d8());
			lx.ai(base.cu());
			lx.ah(base.ct());
			lx.a(this.bv());
			lx.a0(base.cs());
			lx.f(base.s());
			lx.dp(this.@do());
			if (base.n() != null)
			{
				lx.d(base.o());
				lx.c(base.n().p());
			}
			return lx;
		}

		// Token: 0x04000946 RID: 2374
		private new n5 a = new n5();

		// Token: 0x04000947 RID: 2375
		private new bool b = true;
	}
}
