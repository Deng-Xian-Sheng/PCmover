using System;

namespace zz93
{
	// Token: 0x020000C4 RID: 196
	internal class ek : dy
	{
		// Token: 0x06000925 RID: 2341 RVA: 0x0007B53C File Offset: 0x0007A53C
		internal ek(en A_0) : base(null)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x0007B58C File Offset: 0x0007A58C
		internal ek(en A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x0007B5E4 File Offset: 0x0007A5E4
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x0007B5FC File Offset: 0x0007A5FC
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x0007B614 File Offset: 0x0007A614
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x0007B62C File Offset: 0x0007A62C
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x0007B638 File Offset: 0x0007A638
		internal override bool cp()
		{
			return true;
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x0007B64C File Offset: 0x0007A64C
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x0007B664 File Offset: 0x0007A664
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x0007B670 File Offset: 0x0007A670
		internal override kz cm(ij A_0, kz A_1)
		{
			le le = new le();
			A_0.c(this.ch());
			A_0.a(le);
			n5 n = (n5)le.db();
			le.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(le);
			}
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = le.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					le = null;
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
				le.j(A_1);
				hd a_2 = i3.b(le);
				ig a_3 = new ig(new fc[]
				{
					new fc(6968946, a_2)
				});
				A_0.a(this.ch().cn(), a_3);
				i3.a(le);
				i3.a(le, A_0);
				m4.a(n, le.c5(), a_);
				if (le.c5().ay().e() != null)
				{
					le.b(mg.a(A_0, le.c5().ay().e(), A_0.e()));
				}
				base.e(le, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return le;
		}

		// Token: 0x040004B9 RID: 1209
		private new en a = null;

		// Token: 0x040004BA RID: 1210
		private kl b = null;

		// Token: 0x040004BB RID: 1211
		private bool c = false;

		// Token: 0x040004BC RID: 1212
		private new bool d = true;
	}
}
