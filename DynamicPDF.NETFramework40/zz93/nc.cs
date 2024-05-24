using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000202 RID: 514
	internal class nc : k0
	{
		// Token: 0x06001764 RID: 5988 RVA: 0x000FA798 File Offset: 0x000F9798
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001765 RID: 5989 RVA: 0x000FA7B0 File Offset: 0x000F97B0
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001766 RID: 5990 RVA: 0x000FA7C0 File Offset: 0x000F97C0
		internal override bool de()
		{
			return this.c;
		}

		// Token: 0x06001767 RID: 5991 RVA: 0x000FA7D8 File Offset: 0x000F97D8
		internal override void df(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001768 RID: 5992 RVA: 0x000FA7E4 File Offset: 0x000F97E4
		internal override bool @do()
		{
			return this.b;
		}

		// Token: 0x06001769 RID: 5993 RVA: 0x000FA7FC File Offset: 0x000F97FC
		internal override void dp(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600176A RID: 5994 RVA: 0x000FA808 File Offset: 0x000F9808
		internal override k0 dd()
		{
			nc nc = new nc();
			nc.ab(base.ci());
			nc.aa(base.ch());
			return nc;
		}

		// Token: 0x0600176B RID: 5995 RVA: 0x000FA83C File Offset: 0x000F983C
		internal override int dg()
		{
			return 34721;
		}

		// Token: 0x0600176C RID: 5996 RVA: 0x000FA854 File Offset: 0x000F9854
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x0600176D RID: 5997 RVA: 0x000FA873 File Offset: 0x000F9873
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x0600176E RID: 5998 RVA: 0x000FA880 File Offset: 0x000F9880
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

		// Token: 0x0600176F RID: 5999 RVA: 0x000FA8C0 File Offset: 0x000F98C0
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

		// Token: 0x06001770 RID: 6000 RVA: 0x000FA900 File Offset: 0x000F9900
		internal override kz dm()
		{
			nc nc = new nc();
			nc.j(this.dr());
			nc.dc(this.db().du());
			nc.a((lk)base.c5().du());
			nc.dp(this.b);
			nc.df(this.c);
			if (base.n() != null)
			{
				nc.ap(this.c3());
				nc.c(base.n().p());
			}
			return nc;
		}

		// Token: 0x04000AAD RID: 2733
		private new n5 a = new n5();

		// Token: 0x04000AAE RID: 2734
		private new bool b = false;

		// Token: 0x04000AAF RID: 2735
		private new bool c = true;
	}
}
