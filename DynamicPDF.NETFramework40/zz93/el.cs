using System;

namespace zz93
{
	// Token: 0x020000C5 RID: 197
	internal class el : dy
	{
		// Token: 0x0600092F RID: 2351 RVA: 0x0007B83F File Offset: 0x0007A83F
		internal el() : base(null)
		{
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x0007B852 File Offset: 0x0007A852
		internal el(em A_0) : base(null)
		{
			this.a = A_0;
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x0007B86C File Offset: 0x0007A86C
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x0007B884 File Offset: 0x0007A884
		internal override kz cm(ij A_0, kz A_1)
		{
			lm lm = new lm();
			lm.j(A_1);
			A_0.c(this.ch());
			A_0.a(lm);
			A_0.b(lm);
			A_0.a(false);
			bool a_ = false;
			bool flag = true;
			lk lk = lm.c5();
			g2 valueOrDefault = lk.t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					lm = null;
					flag = false;
					A_0.a(false);
					break;
				case g2.c:
					a_ = true;
					break;
				}
			}
			if (flag)
			{
				n5 a_2 = (n5)lm.db();
				m4.a(a_2, lm.c5(), a_);
				lm.c(new mt(new ms(null)));
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return lm;
		}

		// Token: 0x040004BD RID: 1213
		private new em a = null;
	}
}
