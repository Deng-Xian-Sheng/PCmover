using System;

namespace zz93
{
	// Token: 0x02000254 RID: 596
	internal class pm : dy
	{
		// Token: 0x06001B32 RID: 6962 RVA: 0x0011997C File Offset: 0x0011897C
		internal pm()
		{
			this.b = new kl(9705568);
		}

		// Token: 0x06001B33 RID: 6963 RVA: 0x001199CC File Offset: 0x001189CC
		internal pm(pn A_0) : base(null)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x06001B34 RID: 6964 RVA: 0x00119A2C File Offset: 0x00118A2C
		internal pm(pn A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001B35 RID: 6965 RVA: 0x00119A90 File Offset: 0x00118A90
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001B36 RID: 6966 RVA: 0x00119AA8 File Offset: 0x00118AA8
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001B37 RID: 6967 RVA: 0x00119AC0 File Offset: 0x00118AC0
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001B38 RID: 6968 RVA: 0x00119AD8 File Offset: 0x00118AD8
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001B39 RID: 6969 RVA: 0x00119AE4 File Offset: 0x00118AE4
		internal override bool cp()
		{
			return true;
		}

		// Token: 0x06001B3A RID: 6970 RVA: 0x00119AF8 File Offset: 0x00118AF8
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x06001B3B RID: 6971 RVA: 0x00119B10 File Offset: 0x00118B10
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001B3C RID: 6972 RVA: 0x00119B1C File Offset: 0x00118B1C
		internal bool a()
		{
			return this.f;
		}

		// Token: 0x06001B3D RID: 6973 RVA: 0x00119B34 File Offset: 0x00118B34
		internal void a(bool A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06001B3E RID: 6974 RVA: 0x00119B40 File Offset: 0x00118B40
		internal bool b()
		{
			return this.e;
		}

		// Token: 0x06001B3F RID: 6975 RVA: 0x00119B58 File Offset: 0x00118B58
		internal void b(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06001B40 RID: 6976 RVA: 0x00119B64 File Offset: 0x00118B64
		internal override kz cm(ij A_0, kz A_1)
		{
			nl nl = new nl();
			if (this.ch() != null)
			{
				A_0.c(this.ch());
			}
			A_0.a(nl);
			n5 n = (n5)nl.db();
			nl.c5().c().i(n.j());
			if (this.d && !this.e)
			{
				A_0.b(nl);
			}
			bool flag = true;
			bool a_ = false;
			lk lk = nl.c5();
			g2 valueOrDefault = lk.t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					nl = null;
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
				nl.j(A_1);
				i3.a(nl);
				i3.a(nl, A_0);
				if (((n5)nl.db()).a().b())
				{
					if (this.f)
					{
						((n5)nl.db()).a().a("DejaVuSans");
					}
				}
				m4.a(n, lk, a_);
				if (lk.ay().e() != null)
				{
					nl.b(mg.a(A_0, lk.ay().e(), A_0.e()));
				}
				base.e(nl, A_0);
			}
			if (!this.e && A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return nl;
		}

		// Token: 0x04000C4C RID: 3148
		private new pn a = null;

		// Token: 0x04000C4D RID: 3149
		private kl b = null;

		// Token: 0x04000C4E RID: 3150
		private bool c = false;

		// Token: 0x04000C4F RID: 3151
		private new bool d = true;

		// Token: 0x04000C50 RID: 3152
		private new bool e = false;

		// Token: 0x04000C51 RID: 3153
		private new bool f = false;
	}
}
