using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000220 RID: 544
	internal class n6 : k0
	{
		// Token: 0x060019B6 RID: 6582 RVA: 0x0010D658 File Offset: 0x0010C658
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060019B7 RID: 6583 RVA: 0x0010D670 File Offset: 0x0010C670
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060019B8 RID: 6584 RVA: 0x0010D680 File Offset: 0x0010C680
		internal override nw dv()
		{
			return this.b;
		}

		// Token: 0x060019B9 RID: 6585 RVA: 0x0010D698 File Offset: 0x0010C698
		internal override void dw(nw A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060019BA RID: 6586 RVA: 0x0010D6A4 File Offset: 0x0010C6A4
		internal override int dg()
		{
			return 442866842;
		}

		// Token: 0x060019BB RID: 6587 RVA: 0x0010D6BC File Offset: 0x0010C6BC
		internal bool a()
		{
			return this.c;
		}

		// Token: 0x060019BC RID: 6588 RVA: 0x0010D6D4 File Offset: 0x0010C6D4
		internal void a(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060019BD RID: 6589 RVA: 0x0010D6E0 File Offset: 0x0010C6E0
		internal int b()
		{
			return this.d;
		}

		// Token: 0x060019BE RID: 6590 RVA: 0x0010D6F8 File Offset: 0x0010C6F8
		internal void a(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060019BF RID: 6591 RVA: 0x0010D704 File Offset: 0x0010C704
		internal override bool de()
		{
			return true;
		}

		// Token: 0x060019C0 RID: 6592 RVA: 0x0010D718 File Offset: 0x0010C718
		internal override k0 dd()
		{
			n6 n = new n6();
			n.a(true);
			n.ab(base.ci());
			n.aa(base.ch());
			n.dw(this.dv());
			n.a8(this.dp());
			n.a7(this.dn());
			return n;
		}

		// Token: 0x060019C1 RID: 6593 RVA: 0x0010D77C File Offset: 0x0010C77C
		private void a(PageWriter A_0, x5 A_1, x5 A_2)
		{
			x5 x = base.aq();
			x5 x2 = base.ar();
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

		// Token: 0x060019C2 RID: 6594 RVA: 0x0010D8D0 File Offset: 0x0010C8D0
		internal override kz dj(x5 A_0, x5 A_1)
		{
			base.ah(A_0);
			if (this.c && base.n() != null)
			{
				base.n().o();
			}
			return base.f(A_0, A_1);
		}

		// Token: 0x060019C3 RID: 6595 RVA: 0x0010D918 File Offset: 0x0010C918
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			if (this.b.f() != null)
			{
				float num = x5.b(this.b.f().Value);
			}
			this.a(A_0, A_1, A_2);
			if (base.n() != null)
			{
				mu mu = base.n().c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					ms.a(A_0, A_1, A_2);
					mu = mu.b();
				}
			}
			base.o(A_1);
			base.p(A_2);
		}

		// Token: 0x060019C4 RID: 6596 RVA: 0x0010D9D0 File Offset: 0x0010C9D0
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

		// Token: 0x060019C5 RID: 6597 RVA: 0x0010DA98 File Offset: 0x0010CA98
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

		// Token: 0x060019C6 RID: 6598 RVA: 0x0010DC3C File Offset: 0x0010CC3C
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

		// Token: 0x060019C7 RID: 6599 RVA: 0x0010DD38 File Offset: 0x0010CD38
		internal override kz dm()
		{
			n6 n = new n6();
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

		// Token: 0x04000BB4 RID: 2996
		private new n5 a = new n5();

		// Token: 0x04000BB5 RID: 2997
		private new nw b;

		// Token: 0x04000BB6 RID: 2998
		private new bool c = false;

		// Token: 0x04000BB7 RID: 2999
		private new int d = 0;
	}
}
