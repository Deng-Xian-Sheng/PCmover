using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001F3 RID: 499
	internal class mx : k0
	{
		// Token: 0x06001648 RID: 5704 RVA: 0x000F5B1C File Offset: 0x000F4B1C
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001649 RID: 5705 RVA: 0x000F5B34 File Offset: 0x000F4B34
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x0600164A RID: 5706 RVA: 0x000F5B44 File Offset: 0x000F4B44
		internal override int dg()
		{
			return 1000;
		}

		// Token: 0x0600164B RID: 5707 RVA: 0x000F5B5C File Offset: 0x000F4B5C
		internal m1 a()
		{
			return this.b;
		}

		// Token: 0x0600164C RID: 5708 RVA: 0x000F5B74 File Offset: 0x000F4B74
		internal void a(m1 A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600164D RID: 5709 RVA: 0x000F5B80 File Offset: 0x000F4B80
		internal int b()
		{
			return this.c;
		}

		// Token: 0x0600164E RID: 5710 RVA: 0x000F5B98 File Offset: 0x000F4B98
		internal void a(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600164F RID: 5711 RVA: 0x000F5BA4 File Offset: 0x000F4BA4
		internal override bool de()
		{
			return this.d;
		}

		// Token: 0x06001650 RID: 5712 RVA: 0x000F5BBC File Offset: 0x000F4BBC
		internal override void df(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001651 RID: 5713 RVA: 0x000F5BC8 File Offset: 0x000F4BC8
		internal override k0 dd()
		{
			mx mx = new mx();
			mx.a(this.c);
			mx.a(this.b);
			mx.ab(base.ci());
			mx.aa(base.ch());
			return mx;
		}

		// Token: 0x06001652 RID: 5714 RVA: 0x000F5C18 File Offset: 0x000F4C18
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001653 RID: 5715 RVA: 0x000F5C37 File Offset: 0x000F4C37
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001654 RID: 5716 RVA: 0x000F5C44 File Offset: 0x000F4C44
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

		// Token: 0x06001655 RID: 5717 RVA: 0x000F5C84 File Offset: 0x000F4C84
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.d(A_0, A_1, A_2);
		}

		// Token: 0x06001656 RID: 5718 RVA: 0x000F5C94 File Offset: 0x000F4C94
		internal override kz dm()
		{
			mx mx = new mx();
			mx.j(this.dr());
			mx.dc(this.db().du());
			mx.a((lk)base.c5().du());
			mx.df(this.d);
			mx.a(this.c);
			if (this.b != null)
			{
				mx.a((m1)this.b.dm());
			}
			mx.c(base.n().p());
			return mx;
		}

		// Token: 0x04000A4B RID: 2635
		private new n5 a = new n5();

		// Token: 0x04000A4C RID: 2636
		private new m1 b = null;

		// Token: 0x04000A4D RID: 2637
		private new int c = int.MinValue;

		// Token: 0x04000A4E RID: 2638
		private new bool d = true;
	}
}
