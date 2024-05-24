using System;

namespace zz93
{
	// Token: 0x02000251 RID: 593
	internal class pj : dy
	{
		// Token: 0x06001B16 RID: 6934 RVA: 0x001193B0 File Offset: 0x001183B0
		internal pj(pk A_0)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x06001B17 RID: 6935 RVA: 0x00119400 File Offset: 0x00118400
		internal pj(pk A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001B18 RID: 6936 RVA: 0x00119458 File Offset: 0x00118458
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001B19 RID: 6937 RVA: 0x00119470 File Offset: 0x00118470
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001B1A RID: 6938 RVA: 0x00119488 File Offset: 0x00118488
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001B1B RID: 6939 RVA: 0x001194A0 File Offset: 0x001184A0
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001B1C RID: 6940 RVA: 0x001194AC File Offset: 0x001184AC
		internal override bool cp()
		{
			return true;
		}

		// Token: 0x06001B1D RID: 6941 RVA: 0x001194C0 File Offset: 0x001184C0
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x06001B1E RID: 6942 RVA: 0x001194D8 File Offset: 0x001184D8
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001B1F RID: 6943 RVA: 0x001194E4 File Offset: 0x001184E4
		internal override kz cm(ij A_0, kz A_1)
		{
			nj nj = new nj();
			A_0.c(this.ch());
			A_0.a(nj);
			n5 n = (n5)nj.db();
			nj.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(nj);
			}
			bool flag = true;
			bool a_ = false;
			lk lk = nj.c5();
			g2 valueOrDefault = lk.t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				if (valueOrDefault == g2.a)
				{
					nj = null;
					flag = false;
					A_0.a(false);
				}
			}
			if (flag)
			{
				A_0.a(true);
				nj.j(A_1);
				if (lk.ay().e() != null)
				{
					nj.b(mg.a(A_0, lk.ay().e(), A_0.e()));
				}
				hd a_2 = i3.b(nj);
				ig a_3 = new ig(new fc[]
				{
					new fc(6968946, a_2)
				});
				A_0.a(this.ch().cn(), a_3);
				i3.a(nj);
				i3.a(nj, A_0);
				m4.a(n, lk, a_);
				base.e(nj, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return nj;
		}

		// Token: 0x04000C42 RID: 3138
		private new pk a = null;

		// Token: 0x04000C43 RID: 3139
		private kl b = null;

		// Token: 0x04000C44 RID: 3140
		private bool c = false;

		// Token: 0x04000C45 RID: 3141
		private new bool d = true;
	}
}
