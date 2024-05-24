using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001E7 RID: 487
	internal class ml : k0
	{
		// Token: 0x06001504 RID: 5380 RVA: 0x000EA82C File Offset: 0x000E982C
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001505 RID: 5381 RVA: 0x000EA844 File Offset: 0x000E9844
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001506 RID: 5382 RVA: 0x000EA854 File Offset: 0x000E9854
		internal override int dg()
		{
			return 445520207;
		}

		// Token: 0x06001507 RID: 5383 RVA: 0x000EA86C File Offset: 0x000E986C
		internal override bool de()
		{
			return this.e;
		}

		// Token: 0x06001508 RID: 5384 RVA: 0x000EA884 File Offset: 0x000E9884
		internal override void df(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06001509 RID: 5385 RVA: 0x000EA890 File Offset: 0x000E9890
		internal override k0 dd()
		{
			return new ml();
		}

		// Token: 0x0600150A RID: 5386 RVA: 0x000EA8A8 File Offset: 0x000E98A8
		internal override ko dz()
		{
			return this.d;
		}

		// Token: 0x0600150B RID: 5387 RVA: 0x000EA8C0 File Offset: 0x000E98C0
		internal override void d0(ko A_0)
		{
			this.d = A_0;
		}

		// Token: 0x0600150C RID: 5388 RVA: 0x000EA8CC File Offset: 0x000E98CC
		internal int a()
		{
			return this.c;
		}

		// Token: 0x0600150D RID: 5389 RVA: 0x000EA8E4 File Offset: 0x000E98E4
		internal void a(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600150E RID: 5390 RVA: 0x000EA8F0 File Offset: 0x000E98F0
		internal l2 b()
		{
			return this.b;
		}

		// Token: 0x0600150F RID: 5391 RVA: 0x000EA908 File Offset: 0x000E9908
		internal void a(l2 A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001510 RID: 5392 RVA: 0x000EA914 File Offset: 0x000E9914
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001511 RID: 5393 RVA: 0x000EA933 File Offset: 0x000E9933
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001512 RID: 5394 RVA: 0x000EA940 File Offset: 0x000E9940
		internal override kz dj(x5 A_0, x5 A_1)
		{
			kz result;
			if (base.c5().v() != null && x5.c(x5.f(x5.f(base.c5().v().Value, base.c5().a2()), base.c5().a3()), A_1))
			{
				this.am(false);
				this.dr().am(false);
				base.an(false);
				result = this;
			}
			else
			{
				result = base.f(A_0, A_1);
			}
			return result;
		}

		// Token: 0x06001513 RID: 5395 RVA: 0x000EA9D8 File Offset: 0x000E99D8
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c5().c().e(base.r());
			base.c5().c().f(base.q());
			base.c5().c().g(base.s());
			base.c5().c().h(base.t());
			A_1 = x5.f(A_1, x5.f(base.cc(), this.dc()));
			if (this.c3())
			{
				A_1 = x5.f(A_1, base.an());
			}
			if (!base.q())
			{
				A_1 = x5.f(A_1, base.c5().e().d());
			}
			if (!base.s())
			{
				A_2 = x5.f(A_2, base.c5().e().a());
			}
			switch (base.c5().q())
			{
			case g6.b:
			{
				if (base.c5().b() != null)
				{
					A_1 = x5.f(A_1, base.c5().b().Value);
				}
				bool flag;
				if (base.c5().s() != null)
				{
					x5? x = base.c5().s();
					x5 a_ = x5.c();
					flag = (x != null && !x5.g(x.GetValueOrDefault(), a_));
				}
				else
				{
					flag = true;
				}
				if (!flag)
				{
					A_1 = x5.e(base.aq(), base.c5().s().Value);
				}
				if (base.c5().a() != null)
				{
					A_2 = x5.f(A_2, base.c5().a().Value);
				}
				bool flag2;
				if (base.c5().h() != null)
				{
					x5? x = base.c5().h();
					x5 a_ = x5.c();
					flag2 = (x != null && !x5.g(x.GetValueOrDefault(), a_));
				}
				else
				{
					flag2 = true;
				}
				if (!flag2)
				{
					A_2 = x5.e(A_2, base.c5().h().Value);
				}
				break;
			}
			case g6.c:
			{
				if (base.c5().aa())
				{
					A_1 = x5.f(A_1, (base.c5().b() != null) ? base.c5().b().Value : x5.c());
				}
				else
				{
					bool flag3;
					if (base.c5().b() != null)
					{
						x5? x = base.c5().b();
						x5 a_ = x5.c();
						flag3 = (x == null || !x5.a(x.GetValueOrDefault(), a_));
					}
					else
					{
						flag3 = true;
					}
					if (!flag3)
					{
						A_1 = x5.f(A_1, base.c5().b().Value);
					}
				}
				bool flag4;
				if (base.c5().s() != null)
				{
					x5? x = base.c5().s();
					x5 a_ = x5.c();
					flag4 = (x != null && !x5.g(x.GetValueOrDefault(), a_));
				}
				else
				{
					flag4 = true;
				}
				if (!flag4)
				{
					A_1 = x5.e(base.bi(), base.c5().s().Value);
				}
				if (base.c5().a() != null)
				{
					A_2 = base.c5().a().Value;
				}
				bool flag5;
				if (base.c5().h() != null)
				{
					x5? x = base.c5().h();
					x5 a_ = x5.c();
					flag5 = (x != null && !x5.g(x.GetValueOrDefault(), a_));
				}
				else
				{
					flag5 = true;
				}
				if (!flag5)
				{
					A_2 = x5.e(base.bl(), base.c5().h().Value);
				}
				break;
			}
			}
			if (base.ai())
			{
				A_2 = x5.f(A_2, base.cb());
				A_2 = x5.e(A_2, base.a1());
				A_2 = x5.f(A_2, x5.a(x5.f(base.a1(), base.a2()), 2));
				A_2 = x5.e(A_2, x5.a(base.ar(), 2));
			}
			if (base.n() != null)
			{
				mc mc = new mc(this, A_0);
				mc.e();
				mc.w();
				A_0.Write_q_();
				A_0.Write_cm(1f, 0f, 0f, 1f, A_0.Dimensions.aw(x5.b(A_1)), A_0.Dimensions.ax(x5.b(x5.f(A_2, base.ar()))));
				A_0.Write_Do(mc);
				A_0.Write_Q();
			}
		}

		// Token: 0x06001514 RID: 5396 RVA: 0x000EAED0 File Offset: 0x000E9ED0
		internal override kz dm()
		{
			ml ml = new ml();
			ml.j(this.dr());
			ml.dc(this.db().du());
			ml.a((lk)base.c5().du());
			ml.df(this.e);
			ml.a(this.b);
			ml.a(this.c);
			ml.d0(this.d);
			if (base.n() != null)
			{
				ml.c(base.n().p());
			}
			return ml;
		}

		// Token: 0x040009E7 RID: 2535
		private new n5 a = new n5();

		// Token: 0x040009E8 RID: 2536
		private new l2 b = null;

		// Token: 0x040009E9 RID: 2537
		private new int c = 20;

		// Token: 0x040009EA RID: 2538
		private new ko d = ko.k;

		// Token: 0x040009EB RID: 2539
		private new bool e = false;
	}
}
