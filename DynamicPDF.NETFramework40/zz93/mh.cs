using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001E3 RID: 483
	internal class mh : k0
	{
		// Token: 0x060014C6 RID: 5318 RVA: 0x000E8B78 File Offset: 0x000E7B78
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060014C7 RID: 5319 RVA: 0x000E8B90 File Offset: 0x000E7B90
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060014C8 RID: 5320 RVA: 0x000E8BA0 File Offset: 0x000E7BA0
		internal override int dg()
		{
			return 445520207;
		}

		// Token: 0x060014C9 RID: 5321 RVA: 0x000E8BB8 File Offset: 0x000E7BB8
		internal override bool de()
		{
			return this.c;
		}

		// Token: 0x060014CA RID: 5322 RVA: 0x000E8BD0 File Offset: 0x000E7BD0
		internal override void df(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060014CB RID: 5323 RVA: 0x000E8BDC File Offset: 0x000E7BDC
		internal override k0 dd()
		{
			return new mh();
		}

		// Token: 0x060014CC RID: 5324 RVA: 0x000E8BF4 File Offset: 0x000E7BF4
		internal l2 a()
		{
			return this.b;
		}

		// Token: 0x060014CD RID: 5325 RVA: 0x000E8C0C File Offset: 0x000E7C0C
		internal void a(l2 A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060014CE RID: 5326 RVA: 0x000E8C18 File Offset: 0x000E7C18
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x060014CF RID: 5327 RVA: 0x000E8C37 File Offset: 0x000E7C37
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x060014D0 RID: 5328 RVA: 0x000E8C44 File Offset: 0x000E7C44
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

		// Token: 0x060014D1 RID: 5329 RVA: 0x000E8CDC File Offset: 0x000E7CDC
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
			if (base.n() != null)
			{
				if (base.ai())
				{
					mu mu = base.n().c();
					if (mu != null && mu.a() != null)
					{
						ms ms = mu.a();
						A_2 = x5.f(x5.f(A_2, base.ca()), ms.ah());
						A_2 = x5.e(x5.e(A_2, base.a1()), base.c5().f().a());
						if (base.c5().d() && base.c5().c().g() != ft.a)
						{
							A_2 = x5.e(A_2, base.c5().c().f());
						}
					}
				}
				mc mc = new mc(this, A_0);
				mc.e();
				mc.w();
				A_0.Write_q_();
				A_0.Write_cm(1f, 0f, 0f, 1f, A_0.Dimensions.aw(x5.b(A_1)), A_0.Dimensions.ax(x5.b(x5.f(A_2, base.ar()))));
				A_0.Write_Do(mc);
				A_0.Write_Q();
			}
		}

		// Token: 0x060014D2 RID: 5330 RVA: 0x000E8F04 File Offset: 0x000E7F04
		internal override kz dm()
		{
			mh mh = new mh();
			mh.j(this.dr());
			mh.dc(this.db().du());
			mh.a((lk)base.c5().du());
			mh.df(this.c);
			mh.a(this.b);
			if (base.n() != null)
			{
				mh.c(base.n().p());
			}
			return mh;
		}

		// Token: 0x040009D8 RID: 2520
		private new n5 a = new n5();

		// Token: 0x040009D9 RID: 2521
		private new l2 b = null;

		// Token: 0x040009DA RID: 2522
		private new bool c = false;
	}
}
