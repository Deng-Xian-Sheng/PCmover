using System;

namespace zz93
{
	// Token: 0x0200037D RID: 893
	internal abstract class xg : xf
	{
		// Token: 0x06002600 RID: 9728 RVA: 0x00162B14 File Offset: 0x00161B14
		internal xg(x5 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002601 RID: 9729 RVA: 0x00162B28 File Offset: 0x00161B28
		internal x5 d()
		{
			return this.a;
		}

		// Token: 0x06002602 RID: 9730 RVA: 0x00162B40 File Offset: 0x00161B40
		internal void a(x5 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002603 RID: 9731 RVA: 0x00162B4C File Offset: 0x00161B4C
		internal xg e()
		{
			return this.b;
		}

		// Token: 0x06002604 RID: 9732 RVA: 0x00162B64 File Offset: 0x00161B64
		internal void a(xg A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06002605 RID: 9733
		internal abstract int gc();

		// Token: 0x06002606 RID: 9734
		internal abstract void gd(int A_0);

		// Token: 0x06002607 RID: 9735 RVA: 0x00162B70 File Offset: 0x00161B70
		internal virtual bool gh()
		{
			return false;
		}

		// Token: 0x06002608 RID: 9736 RVA: 0x00162B84 File Offset: 0x00161B84
		internal xh f()
		{
			xx xx = base.h();
			xh xh = new xh(this.d());
			while (xx != null)
			{
				xh.b(xx.c());
				xx = xx.b();
			}
			xh.gd(this.gc());
			return xh;
		}

		// Token: 0x06002609 RID: 9737 RVA: 0x00162BDC File Offset: 0x00161BDC
		internal x5 g()
		{
			xx xx = base.h();
			x5 x = x5.a();
			while (xx != null)
			{
				if (!xx.a().fe() && x5.c(xx.a().b8(), this.a) && !xx.a().gf() && x5.d(x, xx.a().b8()))
				{
					if (xx.a().cb() == 239 && !xx.a().gg())
					{
						x = xx.a().b8();
					}
				}
				xx = xx.b();
			}
			x5 result;
			if (x5.d(this.a, x))
			{
				result = x;
			}
			else
			{
				result = this.a;
			}
			return result;
		}

		// Token: 0x040010A1 RID: 4257
		private new x5 a;

		// Token: 0x040010A2 RID: 4258
		private new xg b;
	}
}
