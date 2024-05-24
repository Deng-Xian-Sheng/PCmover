using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001DA RID: 474
	internal class l8 : k0
	{
		// Token: 0x06001429 RID: 5161 RVA: 0x000E08F2 File Offset: 0x000DF8F2
		internal l8(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x0600142A RID: 5162 RVA: 0x000E0920 File Offset: 0x000DF920
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x0600142B RID: 5163 RVA: 0x000E0938 File Offset: 0x000DF938
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x0600142C RID: 5164 RVA: 0x000E0948 File Offset: 0x000DF948
		internal override bool de()
		{
			return this.c;
		}

		// Token: 0x0600142D RID: 5165 RVA: 0x000E0960 File Offset: 0x000DF960
		internal override void df(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600142E RID: 5166 RVA: 0x000E096C File Offset: 0x000DF96C
		internal override bool @do()
		{
			return this.b;
		}

		// Token: 0x0600142F RID: 5167 RVA: 0x000E0984 File Offset: 0x000DF984
		internal override void dp(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001430 RID: 5168 RVA: 0x000E0990 File Offset: 0x000DF990
		internal override int dg()
		{
			return this.d;
		}

		// Token: 0x06001431 RID: 5169 RVA: 0x000E09A8 File Offset: 0x000DF9A8
		internal override k0 dd()
		{
			l8 l = new l8(this.d);
			l.ab(base.ci());
			l.aa(base.ch());
			return l;
		}

		// Token: 0x06001432 RID: 5170 RVA: 0x000E09E4 File Offset: 0x000DF9E4
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001433 RID: 5171 RVA: 0x000E0A03 File Offset: 0x000DFA03
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001434 RID: 5172 RVA: 0x000E0A10 File Offset: 0x000DFA10
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

		// Token: 0x06001435 RID: 5173 RVA: 0x000E0A50 File Offset: 0x000DFA50
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

		// Token: 0x06001436 RID: 5174 RVA: 0x000E0A90 File Offset: 0x000DFA90
		internal override kz dm()
		{
			l8 l = new l8(this.dg());
			l.j(this.dr());
			l.dc(this.db().du());
			l.a((lk)base.c5().du());
			l.df(this.c);
			if (base.n() != null)
			{
				l.c(base.n().p());
			}
			return l;
		}

		// Token: 0x0400098C RID: 2444
		private new n5 a = new n5();

		// Token: 0x0400098D RID: 2445
		private new bool b = false;

		// Token: 0x0400098E RID: 2446
		private new bool c = true;

		// Token: 0x0400098F RID: 2447
		private new int d;
	}
}
