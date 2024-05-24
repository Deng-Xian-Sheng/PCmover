using System;

namespace zz93
{
	// Token: 0x0200024B RID: 587
	internal class pd : dy
	{
		// Token: 0x06001AD8 RID: 6872 RVA: 0x00116E74 File Offset: 0x00115E74
		internal pd(pc A_0)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x06001AD9 RID: 6873 RVA: 0x00116EC4 File Offset: 0x00115EC4
		internal pd(pc A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001ADA RID: 6874 RVA: 0x00116F1C File Offset: 0x00115F1C
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001ADB RID: 6875 RVA: 0x00116F34 File Offset: 0x00115F34
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001ADC RID: 6876 RVA: 0x00116F4C File Offset: 0x00115F4C
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001ADD RID: 6877 RVA: 0x00116F64 File Offset: 0x00115F64
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001ADE RID: 6878 RVA: 0x00116F70 File Offset: 0x00115F70
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x06001ADF RID: 6879 RVA: 0x00116F88 File Offset: 0x00115F88
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001AE0 RID: 6880 RVA: 0x00116F94 File Offset: 0x00115F94
		internal override kz cm(ij A_0, kz A_1)
		{
			nd nd = new nd();
			A_0.c(this.ch());
			A_0.a(nd);
			n5 n = (n5)nd.db();
			nd.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(nd);
			}
			bool flag = true;
			bool a_ = false;
			lk lk = nd.c5();
			g2 valueOrDefault = lk.t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					nd = null;
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
				nd.j(A_1);
				i3.a(nd);
				i3.a(nd, A_0);
				m4.a(n, lk, a_);
				if (lk.ay().e() != null)
				{
					nd.b(mg.a(A_0, lk.ay().e(), A_0.e()));
				}
				base.e(nd, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return nd;
		}

		// Token: 0x04000C32 RID: 3122
		private new pc a = null;

		// Token: 0x04000C33 RID: 3123
		private kl b = null;

		// Token: 0x04000C34 RID: 3124
		private bool c = false;

		// Token: 0x04000C35 RID: 3125
		private new bool d = true;
	}
}
