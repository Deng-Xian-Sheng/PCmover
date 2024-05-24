using System;

namespace zz93
{
	// Token: 0x02000395 RID: 917
	internal class x0
	{
		// Token: 0x06002731 RID: 10033 RVA: 0x00169953 File Offset: 0x00168953
		internal x0(x5 A_0, x5 A_1, wv A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x06002732 RID: 10034 RVA: 0x00169974 File Offset: 0x00168974
		internal x5 a()
		{
			x5 x = x5.b();
			for (wy e = this.c.a; e != null; e = e.e)
			{
				if (e.b != null && x5.c(x, e.b.a().b7()))
				{
					x = e.b.a().b7();
				}
			}
			return x;
		}

		// Token: 0x06002733 RID: 10035 RVA: 0x001699EC File Offset: 0x001689EC
		internal x5 b()
		{
			return this.a;
		}

		// Token: 0x06002734 RID: 10036 RVA: 0x00169A04 File Offset: 0x00168A04
		internal void a(x5 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002735 RID: 10037 RVA: 0x00169A10 File Offset: 0x00168A10
		internal x5 c()
		{
			return this.b;
		}

		// Token: 0x06002736 RID: 10038 RVA: 0x00169A28 File Offset: 0x00168A28
		internal void b(x5 A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06002737 RID: 10039 RVA: 0x00169A34 File Offset: 0x00168A34
		internal wv d()
		{
			return this.c;
		}

		// Token: 0x06002738 RID: 10040 RVA: 0x00169A4C File Offset: 0x00168A4C
		internal void a(xg A_0)
		{
			xx xx = A_0.h();
			wy e = this.c.a;
			while (xx != null || e != null)
			{
				if (xx == null && e != null)
				{
					e.b = null;
					e = e.e;
					xx = A_0.h();
				}
				if (e == null)
				{
					break;
				}
				if (xx.a().fd() == e.a)
				{
					e.b = xx;
					e = e.e;
				}
				xx = xx.b();
			}
		}

		// Token: 0x06002739 RID: 10041 RVA: 0x00169AE8 File Offset: 0x00168AE8
		internal void c(x5 A_0)
		{
			this.a = x5.f(this.a, A_0);
			this.b = x5.f(this.b, A_0);
		}

		// Token: 0x0600273A RID: 10042 RVA: 0x00169B10 File Offset: 0x00168B10
		internal void d(x5 A_0)
		{
			if (x5.d(this.a, A_0))
			{
				A_0 = x5.e(A_0, this.a);
			}
			this.a = x5.e(this.a, A_0);
			this.b = x5.e(this.b, A_0);
		}

		// Token: 0x04001101 RID: 4353
		private x5 a;

		// Token: 0x04001102 RID: 4354
		private x5 b;

		// Token: 0x04001103 RID: 4355
		private wv c;
	}
}
