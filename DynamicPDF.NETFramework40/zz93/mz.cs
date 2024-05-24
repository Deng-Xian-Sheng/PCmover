using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001F5 RID: 501
	internal class mz : k0
	{
		// Token: 0x06001663 RID: 5731 RVA: 0x000F5F24 File Offset: 0x000F4F24
		internal mz(int A_0)
		{
			this.g = A_0;
		}

		// Token: 0x06001664 RID: 5732 RVA: 0x000F5F64 File Offset: 0x000F4F64
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001665 RID: 5733 RVA: 0x000F5F7C File Offset: 0x000F4F7C
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001666 RID: 5734 RVA: 0x000F5F8C File Offset: 0x000F4F8C
		internal override int dg()
		{
			return this.g;
		}

		// Token: 0x06001667 RID: 5735 RVA: 0x000F5FA4 File Offset: 0x000F4FA4
		internal override bool de()
		{
			return this.f;
		}

		// Token: 0x06001668 RID: 5736 RVA: 0x000F5FBC File Offset: 0x000F4FBC
		internal override void df(bool A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06001669 RID: 5737 RVA: 0x000F5FC8 File Offset: 0x000F4FC8
		internal ol a()
		{
			return this.b;
		}

		// Token: 0x0600166A RID: 5738 RVA: 0x000F5FE0 File Offset: 0x000F4FE0
		internal void a(ol A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600166B RID: 5739 RVA: 0x000F5FEC File Offset: 0x000F4FEC
		internal ok b()
		{
			return this.c;
		}

		// Token: 0x0600166C RID: 5740 RVA: 0x000F6004 File Offset: 0x000F5004
		internal void a(ok A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600166D RID: 5741 RVA: 0x000F6010 File Offset: 0x000F5010
		internal int c()
		{
			return this.d;
		}

		// Token: 0x0600166E RID: 5742 RVA: 0x000F6028 File Offset: 0x000F5028
		internal void a(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x0600166F RID: 5743 RVA: 0x000F6034 File Offset: 0x000F5034
		internal override k0 dd()
		{
			mz mz = new mz(this.g);
			mz.ab(base.ci());
			mz.aa(base.ch());
			return mz;
		}

		// Token: 0x06001670 RID: 5744 RVA: 0x000F6070 File Offset: 0x000F5070
		internal override bool @do()
		{
			return this.e;
		}

		// Token: 0x06001671 RID: 5745 RVA: 0x000F6088 File Offset: 0x000F5088
		internal override void dp(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06001672 RID: 5746 RVA: 0x000F6094 File Offset: 0x000F5094
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001673 RID: 5747 RVA: 0x000F60B3 File Offset: 0x000F50B3
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001674 RID: 5748 RVA: 0x000F60C0 File Offset: 0x000F50C0
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

		// Token: 0x06001675 RID: 5749 RVA: 0x000F6100 File Offset: 0x000F5100
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

		// Token: 0x06001676 RID: 5750 RVA: 0x000F6140 File Offset: 0x000F5140
		internal override kz dm()
		{
			mz mz = new mz(this.g);
			mz.j(this.dr());
			mz.dc(this.db().du());
			mz.a((lk)base.c5().du());
			mz.df(this.f);
			mz.a(this.c);
			mz.a(this.b);
			mz.dp(this.e);
			if (base.n() != null)
			{
				mz.c(base.n().p());
			}
			return mz;
		}

		// Token: 0x04000A53 RID: 2643
		private new n5 a = new n5();

		// Token: 0x04000A54 RID: 2644
		private new ol b = ol.d;

		// Token: 0x04000A55 RID: 2645
		private new ok c = ok.i;

		// Token: 0x04000A56 RID: 2646
		private new int d = 1;

		// Token: 0x04000A57 RID: 2647
		private new bool e = false;

		// Token: 0x04000A58 RID: 2648
		private new bool f = true;

		// Token: 0x04000A59 RID: 2649
		private int g;
	}
}
