using System;

namespace zz93
{
	// Token: 0x020000BC RID: 188
	internal class ec : dy
	{
		// Token: 0x060008F7 RID: 2295 RVA: 0x0007A3C0 File Offset: 0x000793C0
		internal ec(ed A_0) : base(null)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x0007A410 File Offset: 0x00079410
		internal ec(ed A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x0007A468 File Offset: 0x00079468
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x0007A480 File Offset: 0x00079480
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x0007A498 File Offset: 0x00079498
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x0007A4B0 File Offset: 0x000794B0
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x0007A4BC File Offset: 0x000794BC
		internal override bool cp()
		{
			return true;
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x0007A4D0 File Offset: 0x000794D0
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x0007A4E8 File Offset: 0x000794E8
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x0007A4F4 File Offset: 0x000794F4
		internal override kz cm(ij A_0, kz A_1)
		{
			k9 k = new k9();
			A_0.c(this.ch());
			A_0.a(k);
			n5 n = (n5)k.db();
			k.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(k);
			}
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = k.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					k = null;
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
				k.j(A_1);
				A_0.a(true);
				hd a_2 = i3.b(k);
				ig a_3 = new ig(new fc[]
				{
					new fc(6968946, a_2)
				});
				A_0.a(this.ch().cn(), a_3);
				i3.a(k);
				i3.a(k, A_0);
				m4.a(n, k.c5(), a_);
				if (k.c5().ay().e() != null)
				{
					k.b(mg.a(A_0, k.c5().ay().e(), A_0.e()));
				}
				base.e(k, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return k;
		}

		// Token: 0x040004AB RID: 1195
		private new ed a = null;

		// Token: 0x040004AC RID: 1196
		private kl b = null;

		// Token: 0x040004AD RID: 1197
		private bool c = false;

		// Token: 0x040004AE RID: 1198
		private new bool d = true;
	}
}
