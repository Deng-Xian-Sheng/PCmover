using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001B7 RID: 439
	internal class lb : k0
	{
		// Token: 0x060010FA RID: 4346 RVA: 0x000C264C File Offset: 0x000C164C
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060010FB RID: 4347 RVA: 0x000C2664 File Offset: 0x000C1664
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060010FC RID: 4348 RVA: 0x000C2674 File Offset: 0x000C1674
		internal override bool de()
		{
			return this.c;
		}

		// Token: 0x060010FD RID: 4349 RVA: 0x000C268C File Offset: 0x000C168C
		internal override void df(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060010FE RID: 4350 RVA: 0x000C2698 File Offset: 0x000C1698
		internal override bool @do()
		{
			return this.b;
		}

		// Token: 0x060010FF RID: 4351 RVA: 0x000C26B0 File Offset: 0x000C16B0
		internal override void dp(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001100 RID: 4352 RVA: 0x000C26BC File Offset: 0x000C16BC
		internal override k0 dd()
		{
			lb lb = new lb();
			lb.ab(base.ci());
			lb.aa(base.ch());
			return lb;
		}

		// Token: 0x06001101 RID: 4353 RVA: 0x000C26F0 File Offset: 0x000C16F0
		internal override int dg()
		{
			return 46574465;
		}

		// Token: 0x06001102 RID: 4354 RVA: 0x000C2708 File Offset: 0x000C1708
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001103 RID: 4355 RVA: 0x000C2727 File Offset: 0x000C1727
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001104 RID: 4356 RVA: 0x000C2734 File Offset: 0x000C1734
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

		// Token: 0x06001105 RID: 4357 RVA: 0x000C2774 File Offset: 0x000C1774
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

		// Token: 0x06001106 RID: 4358 RVA: 0x000C27B4 File Offset: 0x000C17B4
		internal override kz dm()
		{
			lb lb = new lb();
			lb.j(this.dr());
			lb.dc(this.db().du());
			lb.a((lk)base.c5().du());
			lb.df(this.c);
			if (base.n() != null)
			{
				lb.c(base.n().p());
			}
			return lb;
		}

		// Token: 0x04000828 RID: 2088
		private new n5 a = new n5();

		// Token: 0x04000829 RID: 2089
		private new bool b = false;

		// Token: 0x0400082A RID: 2090
		private new bool c = true;
	}
}
