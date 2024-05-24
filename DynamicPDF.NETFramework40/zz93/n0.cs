using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200021A RID: 538
	internal class n0 : k0
	{
		// Token: 0x060018FB RID: 6395 RVA: 0x001079E0 File Offset: 0x001069E0
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060018FC RID: 6396 RVA: 0x001079F8 File Offset: 0x001069F8
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060018FD RID: 6397 RVA: 0x00107A08 File Offset: 0x00106A08
		internal override nw dv()
		{
			return this.b;
		}

		// Token: 0x060018FE RID: 6398 RVA: 0x00107A20 File Offset: 0x00106A20
		internal override void dw(nw A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060018FF RID: 6399 RVA: 0x00107A2C File Offset: 0x00106A2C
		internal override int dg()
		{
			return 718642778;
		}

		// Token: 0x06001900 RID: 6400 RVA: 0x00107A44 File Offset: 0x00106A44
		internal int a()
		{
			return this.d;
		}

		// Token: 0x06001901 RID: 6401 RVA: 0x00107A5C File Offset: 0x00106A5C
		internal void a(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001902 RID: 6402 RVA: 0x00107A68 File Offset: 0x00106A68
		internal override bool de()
		{
			return true;
		}

		// Token: 0x06001903 RID: 6403 RVA: 0x00107A7C File Offset: 0x00106A7C
		internal override k0 dd()
		{
			n0 n = new n0();
			n.a(true);
			n.ab(base.ci());
			n.aa(base.ch());
			n.dw(this.dv());
			n.a8(this.dp());
			n.a7(this.dn());
			return n;
		}

		// Token: 0x06001904 RID: 6404 RVA: 0x00107AE0 File Offset: 0x00106AE0
		internal bool b()
		{
			return this.c;
		}

		// Token: 0x06001905 RID: 6405 RVA: 0x00107AF8 File Offset: 0x00106AF8
		internal void a(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001906 RID: 6406 RVA: 0x00107B04 File Offset: 0x00106B04
		private x5 a(x5 A_0)
		{
			x5 x = base.ar();
			if (base.n() != null)
			{
				int num = 0;
				mu mu = base.n().c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					if (ms.l() != null && ((k0)ms.l().a().b()).n() != null)
					{
						num += ((k0)ms.l().a().b()).n().f();
					}
					else
					{
						num++;
					}
					mu = mu.b();
				}
				x = x5.f(x, x5.a((float)(num - 1) * x5.b(A_0)));
			}
			return x;
		}

		// Token: 0x06001907 RID: 6407 RVA: 0x00107BE0 File Offset: 0x00106BE0
		private void a(PageWriter A_0, x5 A_1, x5 A_2, x5 A_3)
		{
			x5 x = base.aq();
			x5 x2 = this.a(A_3);
			if (this.b.h() == il.b)
			{
				if (base.c5().c().o() != ft.a)
				{
					x = x5.e(x, base.c5().c().n());
				}
				if (base.c5().c().s() != ft.a)
				{
					x = x5.e(x, base.c5().c().r());
				}
				if (base.c5().c().g() != ft.a)
				{
					x2 = x5.e(x2, base.c5().c().f());
				}
				if (base.c5().c().k() != ft.a)
				{
					x2 = x5.e(x2, base.c5().c().j());
				}
			}
			else if (this.b.e() != null)
			{
				A_1 = x5.f(A_1, this.b.e().Value);
			}
			if (base.w() != null)
			{
				base.w().a(base.c5(), A_0, A_1, A_2, x, x2);
			}
		}

		// Token: 0x06001908 RID: 6408 RVA: 0x00107D34 File Offset: 0x00106D34
		internal override kz dj(x5 A_0, x5 A_1)
		{
			base.ah(A_0);
			if (this.c && base.n() != null)
			{
				base.n().o();
			}
			return base.f(A_0, A_1);
		}

		// Token: 0x06001909 RID: 6409 RVA: 0x00107D7C File Offset: 0x00106D7C
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			x5 a_ = x5.c();
			if (this.b.f() != null)
			{
				a_ = this.b.f().Value;
			}
			this.a(A_0, A_1, A_2, a_);
			if (base.n() != null)
			{
				mu mu = base.n().c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					int num = 0;
					if (ms.l() != null && ((k0)ms.l().a().b()).n() != null)
					{
						num = ((k0)ms.l().a().b()).n().f();
						ms.l().a().b().l(base.aq());
					}
					else
					{
						num++;
					}
					ms.a(A_0, A_1, A_2);
					mu = mu.b();
				}
			}
			base.o(A_1);
			base.p(A_2);
		}

		// Token: 0x0600190A RID: 6410 RVA: 0x00107EB0 File Offset: 0x00106EB0
		internal x5[] a(int A_0, x5 A_1)
		{
			if (base.n() != null)
			{
				mu mu = base.n().c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					mr mr = ms.l().a();
					while (mr != null && mr.b() != null)
					{
						if (mr.b().dg() == 1946)
						{
							return ((nx)mr.b()).a(A_0, A_1);
						}
						mr = mr.c();
					}
					mu = mu.b();
				}
			}
			return null;
		}

		// Token: 0x0600190B RID: 6411 RVA: 0x00107F78 File Offset: 0x00106F78
		internal override x5 dh()
		{
			x5 a_ = x5.f(x5.f(x5.f(base.c5().e().d(), base.c5().e().b()), base.c5().f().d()), base.c5().f().b());
			x5 x = x5.c();
			x5 x2 = x5.c();
			if (base.n() != null)
			{
				mu mu = base.n().c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					mr mr = ms.l().a();
					while (mr != null && mr.b() != null)
					{
						mr.b().dw(this.dv());
						x2 = mr.b().dh();
						if (x5.d(x, x2))
						{
							x = x2;
						}
						mr = mr.c();
					}
					mu = mu.b();
				}
			}
			if (base.c5().am() != null && x5.c(base.c5().am().Value, x))
			{
				this.a8(x5.f(base.c5().am().Value, a_));
			}
			else
			{
				this.a8(x5.f(x, a_));
			}
			return this.dp();
		}

		// Token: 0x0600190C RID: 6412 RVA: 0x0010811C File Offset: 0x0010711C
		internal override void di()
		{
			x5 a_ = x5.c();
			x5 x = x5.c();
			x5 a_2 = base.al();
			if (base.n() != null)
			{
				mu mu = base.n().c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					mr mr = ms.l().a();
					while (mr != null && mr.b() != null)
					{
						mr.b().dw(this.dv());
						mr.b().di();
						x = mr.b().dn();
						if (x5.d(a_, x))
						{
							a_ = x;
						}
						mr = mr.c();
					}
					mu = mu.b();
				}
			}
			this.a7(x5.f(a_, a_2));
		}

		// Token: 0x0600190D RID: 6413 RVA: 0x00108218 File Offset: 0x00107218
		internal override kz dm()
		{
			n0 n = new n0();
			n.j(this.dr());
			n.dc(this.db().du());
			n.a((lk)base.c5().du());
			n.dw((nw)this.dv().du());
			n.a(this.d);
			if (base.n() != null)
			{
				n.c(base.n().p());
			}
			return n;
		}

		// Token: 0x04000B71 RID: 2929
		private new n5 a = new n5();

		// Token: 0x04000B72 RID: 2930
		private new nw b;

		// Token: 0x04000B73 RID: 2931
		private new bool c = false;

		// Token: 0x04000B74 RID: 2932
		private new int d = 0;
	}
}
