using System;

namespace zz93
{
	// Token: 0x0200027D RID: 637
	internal class qr : dy
	{
		// Token: 0x06001C68 RID: 7272 RVA: 0x00124830 File Offset: 0x00123830
		internal qr(qs A_0) : base(null)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x06001C69 RID: 7273 RVA: 0x00124880 File Offset: 0x00123880
		internal qr(qs A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001C6A RID: 7274 RVA: 0x001248D8 File Offset: 0x001238D8
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001C6B RID: 7275 RVA: 0x001248F0 File Offset: 0x001238F0
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001C6C RID: 7276 RVA: 0x00124908 File Offset: 0x00123908
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001C6D RID: 7277 RVA: 0x00124920 File Offset: 0x00123920
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001C6E RID: 7278 RVA: 0x0012492C File Offset: 0x0012392C
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x06001C6F RID: 7279 RVA: 0x00124944 File Offset: 0x00123944
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001C70 RID: 7280 RVA: 0x00124950 File Offset: 0x00123950
		internal override kz cm(ij A_0, kz A_1)
		{
			n8 n = new n8();
			A_0.c(this.ch());
			A_0.a(n);
			n5 n2 = (n5)n.db();
			n.c5().c().i(n2.j());
			if (this.d)
			{
				A_0.b(n);
			}
			bool flag = true;
			bool a_ = false;
			lk lk = n.c5();
			g2 valueOrDefault = lk.t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					n = null;
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
				n.j(A_1);
				if (lk.ay().e() != null)
				{
					n.b(mg.a(A_0, lk.ay().e(), A_0.e()));
				}
				if (n2.w())
				{
					A_0.a(true);
					iw iw = new iw();
					iw.a(new ix[]
					{
						new ix(gx.b)
					});
					ig a_2 = new ig(new fc[]
					{
						new fc(633671921, iw)
					});
					A_0.a(this.ch().cn(), a_2);
				}
				i3.a(n);
				i3.a(n, A_0);
				m4.a(n2, lk, a_);
				switch (n2.m()[0])
				{
				case gx.a:
					if (n2.w())
					{
						n2.m()[0] = gx.b;
					}
					goto IL_1C3;
				case gx.c:
				case gx.d:
					goto IL_1C3;
				}
				n2.m()[0] = gx.b;
				IL_1C3:
				base.e(n, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return n;
		}

		// Token: 0x04000CC3 RID: 3267
		private new qs a = null;

		// Token: 0x04000CC4 RID: 3268
		private kl b = null;

		// Token: 0x04000CC5 RID: 3269
		private bool c = false;

		// Token: 0x04000CC6 RID: 3270
		private new bool d = true;
	}
}
