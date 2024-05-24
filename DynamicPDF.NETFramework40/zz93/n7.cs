using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000221 RID: 545
	internal class n7 : k0
	{
		// Token: 0x060019C9 RID: 6601 RVA: 0x0010DDF0 File Offset: 0x0010CDF0
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060019CA RID: 6602 RVA: 0x0010DE08 File Offset: 0x0010CE08
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060019CB RID: 6603 RVA: 0x0010DE18 File Offset: 0x0010CE18
		internal override nw dv()
		{
			return this.b;
		}

		// Token: 0x060019CC RID: 6604 RVA: 0x0010DE30 File Offset: 0x0010CE30
		internal override void dw(nw A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060019CD RID: 6605 RVA: 0x0010DE3C File Offset: 0x0010CE3C
		internal override int dg()
		{
			return 889490394;
		}

		// Token: 0x060019CE RID: 6606 RVA: 0x0010DE54 File Offset: 0x0010CE54
		internal bool a()
		{
			return this.c;
		}

		// Token: 0x060019CF RID: 6607 RVA: 0x0010DE6C File Offset: 0x0010CE6C
		internal void a(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060019D0 RID: 6608 RVA: 0x0010DE78 File Offset: 0x0010CE78
		internal int b()
		{
			return this.d;
		}

		// Token: 0x060019D1 RID: 6609 RVA: 0x0010DE90 File Offset: 0x0010CE90
		internal void a(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060019D2 RID: 6610 RVA: 0x0010DE9C File Offset: 0x0010CE9C
		internal override bool de()
		{
			return true;
		}

		// Token: 0x060019D3 RID: 6611 RVA: 0x0010DEB0 File Offset: 0x0010CEB0
		internal override k0 dd()
		{
			n7 n = new n7();
			n.a(true);
			n.ab(base.ci());
			n.aa(base.ch());
			n.dw(this.dv());
			n.a8(this.dp());
			n.a7(this.dn());
			return n;
		}

		// Token: 0x060019D4 RID: 6612 RVA: 0x0010DF14 File Offset: 0x0010CF14
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

		// Token: 0x060019D5 RID: 6613 RVA: 0x0010E068 File Offset: 0x0010D068
		internal override kz dj(x5 A_0, x5 A_1)
		{
			base.ah(A_0);
			if (this.c && base.n() != null)
			{
				base.n().o();
			}
			return base.f(A_0, A_1);
		}

		// Token: 0x060019D6 RID: 6614 RVA: 0x0010E0B0 File Offset: 0x0010D0B0
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
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

		// Token: 0x060019D7 RID: 6615 RVA: 0x0010E128 File Offset: 0x0010D128
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

		// Token: 0x060019D8 RID: 6616 RVA: 0x0010E1F0 File Offset: 0x0010D1F0
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

		// Token: 0x060019D9 RID: 6617 RVA: 0x0010E394 File Offset: 0x0010D394
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

		// Token: 0x060019DA RID: 6618 RVA: 0x0010E490 File Offset: 0x0010D490
		internal override kz dm()
		{
			n7 n = new n7();
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

		// Token: 0x04000BB8 RID: 3000
		private new n5 a = new n5();

		// Token: 0x04000BB9 RID: 3001
		private new nw b;

		// Token: 0x04000BBA RID: 3002
		private new bool c = false;

		// Token: 0x04000BBB RID: 3003
		private new int d = 0;
	}
}
