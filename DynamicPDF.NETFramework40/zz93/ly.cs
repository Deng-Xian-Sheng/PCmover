using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001CE RID: 462
	internal class ly : k0
	{
		// Token: 0x06001397 RID: 5015 RVA: 0x000DD958 File Offset: 0x000DC958
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001398 RID: 5016 RVA: 0x000DD970 File Offset: 0x000DC970
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001399 RID: 5017 RVA: 0x000DD980 File Offset: 0x000DC980
		internal override int dg()
		{
			return 1717;
		}

		// Token: 0x0600139A RID: 5018 RVA: 0x000DD998 File Offset: 0x000DC998
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x0600139B RID: 5019 RVA: 0x000DD9B0 File Offset: 0x000DC9B0
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600139C RID: 5020 RVA: 0x000DD9BC File Offset: 0x000DC9BC
		internal override k0 dd()
		{
			return new ly();
		}

		// Token: 0x0600139D RID: 5021 RVA: 0x000DD9D4 File Offset: 0x000DC9D4
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x0600139E RID: 5022 RVA: 0x000DD9F3 File Offset: 0x000DC9F3
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x0600139F RID: 5023 RVA: 0x000DDA00 File Offset: 0x000DCA00
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

		// Token: 0x060013A0 RID: 5024 RVA: 0x000DDA40 File Offset: 0x000DCA40
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

		// Token: 0x060013A1 RID: 5025 RVA: 0x000DDA80 File Offset: 0x000DCA80
		internal override kz dm()
		{
			ly ly = new ly();
			ly.j(this.dr());
			ly.dc(this.db().du());
			ly.a((lk)base.c5().du());
			ly.df(this.b);
			if (base.n() != null)
			{
				ly.c(base.n().p());
			}
			return ly;
		}

		// Token: 0x04000948 RID: 2376
		private new n5 a = new n5();

		// Token: 0x04000949 RID: 2377
		private new bool b = true;
	}
}
