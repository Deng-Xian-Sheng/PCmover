using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001C2 RID: 450
	internal class lm : k0
	{
		// Token: 0x060012E5 RID: 4837 RVA: 0x000D930C File Offset: 0x000D830C
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060012E6 RID: 4838 RVA: 0x000D9324 File Offset: 0x000D8324
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060012E7 RID: 4839 RVA: 0x000D9334 File Offset: 0x000D8334
		internal override int dg()
		{
			return 1977;
		}

		// Token: 0x060012E8 RID: 4840 RVA: 0x000D934C File Offset: 0x000D834C
		internal bool a()
		{
			return this.b;
		}

		// Token: 0x060012E9 RID: 4841 RVA: 0x000D9364 File Offset: 0x000D8364
		internal void a(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060012EA RID: 4842 RVA: 0x000D9370 File Offset: 0x000D8370
		internal bool b()
		{
			return this.c;
		}

		// Token: 0x060012EB RID: 4843 RVA: 0x000D9388 File Offset: 0x000D8388
		internal void b(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060012EC RID: 4844 RVA: 0x000D9394 File Offset: 0x000D8394
		internal bool c()
		{
			return this.d;
		}

		// Token: 0x060012ED RID: 4845 RVA: 0x000D93AC File Offset: 0x000D83AC
		internal void c(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060012EE RID: 4846 RVA: 0x000D93B8 File Offset: 0x000D83B8
		internal override bool de()
		{
			return this.e;
		}

		// Token: 0x060012EF RID: 4847 RVA: 0x000D93D0 File Offset: 0x000D83D0
		internal override void df(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x060012F0 RID: 4848 RVA: 0x000D93DC File Offset: 0x000D83DC
		internal override x5 dh()
		{
			this.a8(x5.c());
			base.s(true);
			base.r(true);
			return this.dp();
		}

		// Token: 0x060012F1 RID: 4849 RVA: 0x000D9410 File Offset: 0x000D8410
		internal override void di()
		{
			this.a7(x5.c());
			base.s(true);
			base.r(true);
		}

		// Token: 0x060012F2 RID: 4850 RVA: 0x000D9430 File Offset: 0x000D8430
		internal override kz dj(x5 A_0, x5 A_1)
		{
			if (this.d)
			{
				float num = 12f;
				if (x5.g(((n5)this.db()).a().i(), x5.c()))
				{
					num = x5.b(((n5)this.db()).a().i());
				}
				base.m(x5.a(Font.TimesRoman.GetDefaultLeading(num)));
				base.l(A_0);
				base.ac(base.ar());
				base.ad(base.ar());
				base.ae(x5.a(num));
				base.y(x5.a(Font.TimesRoman.GetAscender(num)));
				base.z(x5.d(x5.a(Font.TimesRoman.GetDescender(num))));
				base.aa(x5.a(Font.TimesRoman.GetLineGap(num)));
				if (x5.c(base.ar(), A_1))
				{
					this.am(false);
					this.dr().am(false);
					return this;
				}
			}
			return null;
		}

		// Token: 0x060012F3 RID: 4851 RVA: 0x000D9560 File Offset: 0x000D8560
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			if (base.n() != null)
			{
				x5 a_ = x5.e(x5.e(x5.f(base.c5().a1(), base.c5().a0()), base.c5().e().d()), base.c5().e().b());
				x5 a_2 = x5.f(x5.f(base.c5().f().a(), base.c5().f().c()), base.ar());
				A_1 = x5.f(A_1, base.c5().e().d());
				A_2 = x5.e(A_2, base.c5().f().a());
				base.c5().c().a(A_0, A_1, A_2, a_, a_2);
			}
		}

		// Token: 0x060012F4 RID: 4852 RVA: 0x000D9640 File Offset: 0x000D8640
		internal override kz dm()
		{
			lm lm = new lm();
			lm.j(this.dr());
			lm.dc(this.db().du());
			lm.a((lk)base.c5().du());
			lm.df(this.e);
			lm.a(this.b);
			lm.b(this.c);
			lm.c(this.d);
			lm.df(this.e);
			if (base.n() != null)
			{
				lm.c(base.n().p());
			}
			return lm;
		}

		// Token: 0x04000927 RID: 2343
		private new n5 a = new n5();

		// Token: 0x04000928 RID: 2344
		private new bool b = false;

		// Token: 0x04000929 RID: 2345
		private new bool c = false;

		// Token: 0x0400092A RID: 2346
		private new bool d = true;

		// Token: 0x0400092B RID: 2347
		private new bool e = true;
	}
}
