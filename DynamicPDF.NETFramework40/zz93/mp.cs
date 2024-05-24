using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001EB RID: 491
	internal class mp : k0
	{
		// Token: 0x0600153D RID: 5437 RVA: 0x000EB440 File Offset: 0x000EA440
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x0600153E RID: 5438 RVA: 0x000EB458 File Offset: 0x000EA458
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x0600153F RID: 5439 RVA: 0x000EB468 File Offset: 0x000EA468
		internal override int dg()
		{
			return 673419368;
		}

		// Token: 0x06001540 RID: 5440 RVA: 0x000EB480 File Offset: 0x000EA480
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x06001541 RID: 5441 RVA: 0x000EB498 File Offset: 0x000EA498
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001542 RID: 5442 RVA: 0x000EB4A4 File Offset: 0x000EA4A4
		internal override k0 dd()
		{
			return new mp();
		}

		// Token: 0x06001543 RID: 5443 RVA: 0x000EB4BC File Offset: 0x000EA4BC
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001544 RID: 5444 RVA: 0x000EB4DB File Offset: 0x000EA4DB
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001545 RID: 5445 RVA: 0x000EB4E8 File Offset: 0x000EA4E8
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x06001546 RID: 5446 RVA: 0x000EB502 File Offset: 0x000EA502
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x06001547 RID: 5447 RVA: 0x000EB510 File Offset: 0x000EA510
		internal override kz dm()
		{
			mp mp = new mp();
			mp.j(this.dr());
			mp.dc(this.db().du());
			mp.a((lk)base.c5().du());
			mp.df(this.b);
			if (base.n() != null)
			{
				mp.c(base.n().p());
			}
			return mp;
		}

		// Token: 0x040009F2 RID: 2546
		private new n5 a = new n5();

		// Token: 0x040009F3 RID: 2547
		private new bool b = false;
	}
}
