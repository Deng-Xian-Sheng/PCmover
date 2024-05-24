using System;

namespace zz93
{
	// Token: 0x02000175 RID: 373
	internal class jh : dy
	{
		// Token: 0x06000D6E RID: 3438 RVA: 0x00098DF4 File Offset: 0x00097DF4
		internal jh(ji A_0) : base(null)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x06000D6F RID: 3439 RVA: 0x00098E44 File Offset: 0x00097E44
		internal jh(ji A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06000D70 RID: 3440 RVA: 0x00098E9C File Offset: 0x00097E9C
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000D71 RID: 3441 RVA: 0x00098EB4 File Offset: 0x00097EB4
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000D72 RID: 3442 RVA: 0x00098ECC File Offset: 0x00097ECC
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06000D73 RID: 3443 RVA: 0x00098EE4 File Offset: 0x00097EE4
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000D74 RID: 3444 RVA: 0x00098EF0 File Offset: 0x00097EF0
		internal override kz cm(ij A_0, kz A_1)
		{
			lv lv = new lv();
			A_0.c(this.ch());
			A_0.a(lv);
			n5 n = (n5)lv.db();
			lv.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(lv);
			}
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = lv.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					lv = null;
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
				lv.j(A_1);
				i3.a(lv);
				i3.a(lv, A_0);
				m4.a(n, lv.c5(), a_);
				if (lv.c5().ay().e() != null)
				{
					lv.b(mg.a(A_0, lv.c5().ay().e(), A_0.e()));
				}
				int num = 0;
				switch (n.m()[num])
				{
				case gx.a:
					if (n.w())
					{
						n.m()[num] = gx.d;
					}
					break;
				case gx.b:
				case gx.c:
					if (!n.w())
					{
						if (n.m().Length >= 1)
						{
							gx[] array = new gx[n.m().Length + 1];
							Array.Copy(n.m(), num, array, num, n.m().Length);
							num = n.m().Length;
							array[num] = gx.d;
							n.a(array);
						}
					}
					break;
				default:
					n.m()[num] = gx.d;
					break;
				}
				base.e(lv, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return lv;
		}

		// Token: 0x040006D4 RID: 1748
		private new ji a = null;

		// Token: 0x040006D5 RID: 1749
		private kl b = null;

		// Token: 0x040006D6 RID: 1750
		private bool c = false;

		// Token: 0x040006D7 RID: 1751
		private new bool d = true;
	}
}
