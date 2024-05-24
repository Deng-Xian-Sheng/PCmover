using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001D6 RID: 470
	internal class l6 : k0
	{
		// Token: 0x06001411 RID: 5137 RVA: 0x000E0230 File Offset: 0x000DF230
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001412 RID: 5138 RVA: 0x000E0248 File Offset: 0x000DF248
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001413 RID: 5139 RVA: 0x000E0258 File Offset: 0x000DF258
		internal override int dg()
		{
			return 5629554;
		}

		// Token: 0x06001414 RID: 5140 RVA: 0x000E0270 File Offset: 0x000DF270
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x06001415 RID: 5141 RVA: 0x000E0288 File Offset: 0x000DF288
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001416 RID: 5142 RVA: 0x000E0294 File Offset: 0x000DF294
		internal override k0 dd()
		{
			return new l6();
		}

		// Token: 0x06001417 RID: 5143 RVA: 0x000E02AC File Offset: 0x000DF2AC
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001418 RID: 5144 RVA: 0x000E02CB File Offset: 0x000DF2CB
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001419 RID: 5145 RVA: 0x000E02D8 File Offset: 0x000DF2D8
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

		// Token: 0x0600141A RID: 5146 RVA: 0x000E0318 File Offset: 0x000DF318
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

		// Token: 0x0600141B RID: 5147 RVA: 0x000E0358 File Offset: 0x000DF358
		internal override kz dm()
		{
			l6 l = new l6();
			l.j(this.dr());
			l.dc(this.db().du());
			l.a((lk)base.c5().du());
			l.df(this.b);
			if (base.n() != null)
			{
				l.c(base.n().p());
			}
			return l;
		}

		// Token: 0x04000976 RID: 2422
		private new n5 a = new n5();

		// Token: 0x04000977 RID: 2423
		private new bool b = true;
	}
}
