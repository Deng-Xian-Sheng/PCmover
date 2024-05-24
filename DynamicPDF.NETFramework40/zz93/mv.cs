using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001F1 RID: 497
	internal class mv : k0
	{
		// Token: 0x0600163C RID: 5692 RVA: 0x000F595C File Offset: 0x000F495C
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x0600163D RID: 5693 RVA: 0x000F5974 File Offset: 0x000F4974
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x0600163E RID: 5694 RVA: 0x000F5984 File Offset: 0x000F4984
		internal override int dg()
		{
			return 622899778;
		}

		// Token: 0x0600163F RID: 5695 RVA: 0x000F599C File Offset: 0x000F499C
		internal override k0 dd()
		{
			return new mv();
		}

		// Token: 0x06001640 RID: 5696 RVA: 0x000F59B4 File Offset: 0x000F49B4
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x06001641 RID: 5697 RVA: 0x000F59CC File Offset: 0x000F49CC
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001642 RID: 5698 RVA: 0x000F59D8 File Offset: 0x000F49D8
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001643 RID: 5699 RVA: 0x000F59F7 File Offset: 0x000F49F7
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001644 RID: 5700 RVA: 0x000F5A04 File Offset: 0x000F4A04
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

		// Token: 0x06001645 RID: 5701 RVA: 0x000F5A44 File Offset: 0x000F4A44
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

		// Token: 0x06001646 RID: 5702 RVA: 0x000F5A84 File Offset: 0x000F4A84
		internal override kz dm()
		{
			mv mv = new mv();
			mv.j(this.dr());
			mv.dc(this.db().du());
			mv.a((lk)base.c5().du());
			mv.df(this.b);
			if (base.n() != null)
			{
				mv.c(base.n().p());
			}
			return mv;
		}

		// Token: 0x04000A43 RID: 2627
		private new n5 a = new n5();

		// Token: 0x04000A44 RID: 2628
		private new bool b = true;
	}
}
