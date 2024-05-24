using System;

namespace zz93
{
	// Token: 0x0200027F RID: 639
	internal class qt : dy
	{
		// Token: 0x06001C74 RID: 7284 RVA: 0x00124CA0 File Offset: 0x00123CA0
		internal qt(qu A_0) : base(null)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x06001C75 RID: 7285 RVA: 0x00124CF0 File Offset: 0x00123CF0
		internal qt(qu A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001C76 RID: 7286 RVA: 0x00124D48 File Offset: 0x00123D48
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001C77 RID: 7287 RVA: 0x00124D60 File Offset: 0x00123D60
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001C78 RID: 7288 RVA: 0x00124D78 File Offset: 0x00123D78
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001C79 RID: 7289 RVA: 0x00124D90 File Offset: 0x00123D90
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001C7A RID: 7290 RVA: 0x00124D9C File Offset: 0x00123D9C
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x06001C7B RID: 7291 RVA: 0x00124DB4 File Offset: 0x00123DB4
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001C7C RID: 7292 RVA: 0x00124DC0 File Offset: 0x00123DC0
		internal override kz cm(ij A_0, kz A_1)
		{
			oa oa = new oa();
			A_0.c(this.ch());
			A_0.a(oa);
			n5 n = (n5)oa.db();
			oa.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(oa);
			}
			bool flag = true;
			bool a_ = false;
			lk lk = oa.c5();
			g2 valueOrDefault = lk.t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					oa = null;
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
				A_0.a(true);
				oa.j(A_1);
				if (lk.ay().e() != null)
				{
					oa.b(mg.a(A_0, lk.ay().e(), A_0.e()));
				}
				hd a_2 = i3.b(oa);
				ig a_3 = new ig(new fc[]
				{
					new fc(6968946, a_2)
				});
				A_0.a(this.ch().cn(), a_3);
				n.a().a(f4.b);
				i3.a(oa);
				i3.a(oa, A_0);
				m4.a(n, lk, a_);
				base.e(oa, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return oa;
		}

		// Token: 0x04000CC7 RID: 3271
		private new qu a = null;

		// Token: 0x04000CC8 RID: 3272
		private kl b = null;

		// Token: 0x04000CC9 RID: 3273
		private bool c = false;

		// Token: 0x04000CCA RID: 3274
		private new bool d = true;
	}
}
