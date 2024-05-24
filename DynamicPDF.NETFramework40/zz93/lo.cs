using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001C4 RID: 452
	internal class lo : k0
	{
		// Token: 0x06001304 RID: 4868 RVA: 0x000DA14C File Offset: 0x000D914C
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001305 RID: 4869 RVA: 0x000DA164 File Offset: 0x000D9164
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001306 RID: 4870 RVA: 0x000DA174 File Offset: 0x000D9174
		internal override nw dv()
		{
			return this.b;
		}

		// Token: 0x06001307 RID: 4871 RVA: 0x000DA18C File Offset: 0x000D918C
		internal override void dw(nw A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001308 RID: 4872 RVA: 0x000DA198 File Offset: 0x000D9198
		internal override int dg()
		{
			return 258605815;
		}

		// Token: 0x06001309 RID: 4873 RVA: 0x000DA1B0 File Offset: 0x000D91B0
		internal override bool de()
		{
			return this.c;
		}

		// Token: 0x0600130A RID: 4874 RVA: 0x000DA1C8 File Offset: 0x000D91C8
		internal override void df(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600130B RID: 4875 RVA: 0x000DA1D4 File Offset: 0x000D91D4
		internal override k0 dd()
		{
			lo lo = new lo();
			lo.ab(base.ci());
			lo.aa(base.ch());
			return lo;
		}

		// Token: 0x0600130C RID: 4876 RVA: 0x000DA208 File Offset: 0x000D9208
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x0600130D RID: 4877 RVA: 0x000DA227 File Offset: 0x000D9227
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x0600130E RID: 4878 RVA: 0x000DA234 File Offset: 0x000D9234
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

		// Token: 0x0600130F RID: 4879 RVA: 0x000DA274 File Offset: 0x000D9274
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			switch (this.de())
			{
			case false:
				base.c(A_0, A_1, A_2);
				break;
			case true:
			{
				kz kz = this.dr();
				x5 a_ = x5.c();
				int num = kz.dg();
				if (num == 144937050)
				{
					if (kz.dv().h() == il.b)
					{
						a_ = kz.c5().a5();
					}
					else
					{
						a_ = kz.c5().a2();
					}
					if (kz.dv().f() != null)
					{
						a_ = x5.f(a_, kz.dv().f().Value);
					}
					a_ = x5.e(a_, kz.c5().e().a());
				}
				base.d(A_0, A_1, A_2);
				break;
			}
			}
		}

		// Token: 0x06001310 RID: 4880 RVA: 0x000DA350 File Offset: 0x000D9350
		internal override kz dm()
		{
			lo lo = new lo();
			lo.j(this.dr());
			lo.dc(this.db().du());
			lo.a((lk)base.c5().du());
			lo.df(this.c);
			lo.dw(this.b);
			if (base.n() != null)
			{
				lo.c(base.n().p());
			}
			return lo;
		}

		// Token: 0x0400092E RID: 2350
		private new n5 a = new n5();

		// Token: 0x0400092F RID: 2351
		private new nw b = new nw();

		// Token: 0x04000930 RID: 2352
		private new bool c = true;
	}
}
