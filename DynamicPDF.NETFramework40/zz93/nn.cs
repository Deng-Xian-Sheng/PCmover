using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200020D RID: 525
	internal class nn : kz
	{
		// Token: 0x060017FD RID: 6141 RVA: 0x000FFB78 File Offset: 0x000FEB78
		internal nn(n3 A_0, bool A_1, int A_2, int A_3)
		{
			this.b = new n3();
			this.b.j(A_0.dr());
			this.b.a(A_0.q());
			this.b.a(A_0.j());
			this.f = A_0.j();
			this.i = A_3;
			this.h = A_2;
			this.j = A_1;
			this.b.a(new afr(A_0.u().b()[A_2], A_0.u().c()[A_2]));
			this.b.u().e()[0] = A_3;
			this.b.u().f()[0] = A_0.u().b()[A_2].a() - A_3;
			for (int i = A_2 + 1; i < A_0.u().b().Length; i++)
			{
				agd agd = A_0.u().b()[i];
				if (agd != null)
				{
					l2 a_ = A_0.u().c()[i];
					this.b.u().a(agd, a_);
					A_0.u().a(i);
				}
			}
			this.b.a(A_0.r());
			this.b.a(A_0.q());
			this.b.b(A_0.g());
			if (A_1)
			{
				this.a = A_0.h() + A_0.ba();
				this.d = A_0.s() + A_0.ba();
			}
			else
			{
				this.a = A_0.h();
			}
			base.h(A_0.g() - this.a);
			base.af(A_0.bd());
			base.ag(A_0.be());
			this.j(A_0.dr());
			this.dc(A_0.db());
		}

		// Token: 0x060017FE RID: 6142 RVA: 0x000FFDBC File Offset: 0x000FEDBC
		internal nn(nn A_0, int A_1, int A_2)
		{
			this.i = A_2;
			this.h = A_1;
			this.b = new n3();
			this.b.j(A_0.dr());
			this.b.a(A_0.a().j());
			this.f = A_0.f;
			this.b.a(A_0.a().r());
			this.b.a(new afr(A_0.a().u().b()[A_1], A_0.a().u().c()[A_1]));
			this.b.u().e()[0] = A_2;
			this.b.u().f()[0] = A_0.a().u().b()[A_1].a() - A_2;
			for (int i = A_1 + 1; i < A_0.a().u().b().Length; i++)
			{
				agd agd = A_0.a().u().b()[i];
				if (agd != null)
				{
					l2 a_ = A_0.a().u().c()[i];
					this.b.u().a(agd, a_);
					A_0.a().u().a(i);
				}
			}
			this.b.a(A_0.a().q());
			this.b.b(A_0.a().g());
			this.a = A_0.a + A_0.ba();
			this.d = A_0.d + A_0.ba();
			base.h(A_0.a().g() - this.a);
			base.af(A_0.bd());
			base.ag(A_0.be());
			this.j(A_0.dr());
			this.dc(A_0.db());
		}

		// Token: 0x060017FF RID: 6143 RVA: 0x00100005 File Offset: 0x000FF005
		internal override void di()
		{
			this.b.c(false);
			this.b.di();
			base.i(this.b.bb());
			this.a7(this.b.dn());
		}

		// Token: 0x06001800 RID: 6144 RVA: 0x00100048 File Offset: 0x000FF048
		internal override x5 dh()
		{
			this.b.c(this.a);
			this.b.d(this.d);
			this.b.h(base.ba());
			this.b.af(base.bd());
			this.b.ag(base.be());
			this.b.c(false);
			agd agd = this.b.u().b()[0];
			int num = this.b.u().e()[0];
			int num2 = agd.a();
			if (!this.b.c() && num < num2)
			{
				char c = agd.b(agd.a(num).a());
				if (num < agd.a() && c == ' ' && this.dr().by() == 1 && base.by() == 1)
				{
					this.a(num + 1);
					base.h(agd.a() - 1 - num);
					this.b.u().e()[0] = num + 1;
					this.b.u().f()[0] = agd.a() - 1 - num;
					this.a7(x5.c());
					this.b.a8(x5.c());
				}
			}
			this.b.dh();
			base.k(this.b.bo());
			base.aq(this.b.b2());
			base.ar(this.b.b3());
			base.s(this.b.b1());
			this.a7(this.b.dn());
			this.q(this.b.dk());
			this.a8(this.b.dp());
			base.i(this.b.bb());
			return this.dp();
		}

		// Token: 0x06001801 RID: 6145 RVA: 0x00100274 File Offset: 0x000FF274
		internal override lj db()
		{
			return this.b.db();
		}

		// Token: 0x06001802 RID: 6146 RVA: 0x00100291 File Offset: 0x000FF291
		internal override void dc(lj A_0)
		{
			this.b.dc(A_0);
		}

		// Token: 0x06001803 RID: 6147 RVA: 0x001002A4 File Offset: 0x000FF2A4
		internal n3 a()
		{
			return this.b;
		}

		// Token: 0x06001804 RID: 6148 RVA: 0x001002BC File Offset: 0x000FF2BC
		internal int b()
		{
			return this.a;
		}

		// Token: 0x06001805 RID: 6149 RVA: 0x001002D4 File Offset: 0x000FF2D4
		internal void a(int A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06001806 RID: 6150 RVA: 0x001002E0 File Offset: 0x000FF2E0
		internal int c()
		{
			return this.d;
		}

		// Token: 0x06001807 RID: 6151 RVA: 0x001002F8 File Offset: 0x000FF2F8
		internal void b(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001808 RID: 6152 RVA: 0x00100304 File Offset: 0x000FF304
		internal int d()
		{
			return this.e;
		}

		// Token: 0x06001809 RID: 6153 RVA: 0x0010031C File Offset: 0x000FF31C
		internal void c(int A_0)
		{
			this.e = A_0;
		}

		// Token: 0x0600180A RID: 6154 RVA: 0x00100328 File Offset: 0x000FF328
		internal override int dg()
		{
			return 101;
		}

		// Token: 0x0600180B RID: 6155 RVA: 0x0010033C File Offset: 0x000FF33C
		internal x5 e()
		{
			return this.b.i();
		}

		// Token: 0x0600180C RID: 6156 RVA: 0x00100359 File Offset: 0x000FF359
		internal void a(x5 A_0)
		{
			this.b.a(A_0);
		}

		// Token: 0x0600180D RID: 6157 RVA: 0x0010036C File Offset: 0x000FF36C
		internal l2 f()
		{
			return this.f;
		}

		// Token: 0x0600180E RID: 6158 RVA: 0x00100384 File Offset: 0x000FF384
		internal void a(l2 A_0)
		{
			this.f = A_0;
		}

		// Token: 0x0600180F RID: 6159 RVA: 0x0010038E File Offset: 0x000FF38E
		internal void b(x5 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001810 RID: 6160 RVA: 0x00100398 File Offset: 0x000FF398
		internal bool g()
		{
			return this.g;
		}

		// Token: 0x06001811 RID: 6161 RVA: 0x001003B0 File Offset: 0x000FF3B0
		internal void a(bool A_0)
		{
			this.g = A_0;
		}

		// Token: 0x06001812 RID: 6162 RVA: 0x001003BC File Offset: 0x000FF3BC
		internal override kz dj(x5 A_0, x5 A_1)
		{
			float num = x5.b(((n5)this.b.db()).k().Value);
			float num2 = x5.b(((n5)this.b.db()).f().Value);
			float num3 = x5.b(this.b.l());
			mw mw = ((n5)this.db()).n().c();
			x5? x = ((n5)this.b.db()).n().a();
			base.ac(x5.a(this.f.e().GetDefaultLeading(num3)));
			base.ad(base.ar());
			base.ae(this.b.l());
			base.w(x5.a(this.f.e().GetAscender(num3)));
			base.x(x5.d(x5.a(this.f.e().GetDescender(num3))));
			base.y(base.a1());
			base.z(base.a2());
			base.aa(x5.a(this.f.e().GetLineGap(x5.b(this.b.l()))));
			bool a_ = false;
			agd agd = this.b.u().b()[0];
			int num4 = this.b.u().e()[0];
			int num5 = agd.a();
			if (!this.b.c() && num4 < num5)
			{
				if (num4 < agd.a())
				{
					char c = agd.b(agd.a(num4).a());
					if (c == ' ' && (this.dr().by() == 1 || this.dr().dg() == 11228793 || this.dr().dg() == 3418) && base.by() == 1)
					{
						this.a(num4 + 1);
						base.h(agd.a() - 1 - num4);
						this.b.u().e()[0] = num4 + 1;
						this.b.u().f()[0] = agd.a() - 1 - num4;
						this.a7(x5.c());
						this.b.a8(x5.c());
					}
				}
			}
			if (x == null && num3 < 11f && !this.b.g(this.dr().dg()))
			{
				base.ac(x5.a(this.f.e().GetDefaultLeading(num3)));
				this.a(x5.a(this.f.e().GetBaseLine(num3, x5.b(base.a7()))));
				base.m(n4.a(this.f.e(), num3, this.ds(), mw));
			}
			else
			{
				this.a(x5.a(this.f.e().GetBaseLine(num3, this.f.e().GetDefaultLeading(num3))));
				base.m(n4.a(this.f.e(), num3, this.ds(), mw));
			}
			if (x5.h(this.dn(), x5.c()))
			{
				this.di();
			}
			x5 a_2 = this.dn();
			kz result;
			if (this.b.o())
			{
				result = this.b.a(A_0, A_1, x);
			}
			else
			{
				base.ad(base.ar());
				if (base.bt())
				{
					this.dr().ao(x5.a((float)this.f.e().jn() * num3 / 1000f));
					this.dr().ap(x5.a((float)this.f.e().jn() * x5.b(this.dr().dr().a9()) / 1000f));
				}
				else if (base.bu())
				{
					this.dr().an(x5.a((float)this.f.e().jm() * x5.b(this.dr().dr().a9()) / 1000f));
				}
				if (this.ds() != null)
				{
					if (mw != mw.d)
					{
						((n5)this.db()).n().b(x);
					}
					else
					{
						((n5)this.db()).n().b(new x5?(x5.a(x5.b(this.b.l()) * x5.b(x.Value))));
					}
				}
				else
				{
					((n5)this.db()).n().b(new x5?(x5.f(x5.f(base.a3(), base.a4()), base.a5())));
				}
				x5 x2 = x5.c();
				x5 a_3 = x5.c();
				if (x5.c(a_2, x5.f(A_0, x5.a(0.001))) && x5.b(base.ar(), A_1))
				{
					for (int i = 0; i < this.b.u().b().Length; i++)
					{
						agd = this.b.u().b()[i];
						if (agd != null)
						{
							l2 l = this.b.u().c()[i];
							x2 = x5.a(this.b.u().d()[i]);
							if (x5.c(x2, x5.f(A_0, x5.a(0.001))) && x5.b(base.ar(), A_1))
							{
								kz kz = n4.a(null, this, A_0, this.b.c(), ref a_, i);
								if (kz != null)
								{
									base.an(a_);
									return kz;
								}
								base.an(a_);
								this.e = this.b.r().Length;
								return null;
							}
						}
						a_3 = x5.f(a_3, x2);
						A_0 = x5.e(A_0, x2);
					}
					base.l(a_3);
				}
				else
				{
					if (this.g)
					{
						for (int i = 0; i < this.b.u().b().Length; i++)
						{
							agd = this.b.u().b()[i];
							if (agd != null)
							{
								l2 l = this.b.u().c()[i];
								x2 = x5.a(this.b.u().d()[i]);
								if (i == this.b.u().d().Length - 1)
								{
									kz kz = n4.a(null, this, A_0, this.b.c(), ref a_, i);
									if (kz != null)
									{
										base.an(a_);
										return kz;
									}
									base.an(a_);
									this.e = this.b.r().Length;
									return null;
								}
							}
						}
					}
					if (x5.c(base.ar(), A_1))
					{
						this.am(false);
						this.dr().am(false);
						base.an(a_);
						base.x(true);
						this.dr().x(true);
						return this;
					}
					base.l(a_2);
					this.e = this.b.r().Length;
					base.an(a_);
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06001813 RID: 6163 RVA: 0x00100C68 File Offset: 0x000FFC68
		internal override kz dl()
		{
			x5 x = x5.c();
			for (int i = 0; i < this.b.u().b().Length; i++)
			{
				agd agd = this.b.u().b()[i];
				if (agd != null)
				{
					l2 l = this.b.u().c()[i];
					x = x5.a(this.b.u().d()[i]);
					int num = this.b.u().e()[i];
					int num2 = this.b.u().f()[i];
					kz result;
					if (num2 > 1)
					{
						this.b.u().f()[i] = num2 - this.b.x();
						base.l(x5.e(base.aq(), base.b3()));
						nn nn = new nn(this, i, num + num2 - this.b.x());
						base.an(true);
						result = nn;
					}
					else
					{
						base.an(false);
						result = this;
					}
					return result;
				}
			}
			return null;
		}

		// Token: 0x06001814 RID: 6164 RVA: 0x00100DB0 File Offset: 0x000FFDB0
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			this.b.i(base.an());
			this.b.au(base.cc());
			this.b.a5(this.dc());
			this.b.af(base.bd());
			this.b.ag(base.be());
			this.b.c(this.b());
			this.b.h(base.ba());
			this.b.l(base.aq());
			this.b.a(this.f);
			this.b.b(this.c);
			this.b.dk(A_0, A_1, A_2);
			base.au(x5.c());
		}

		// Token: 0x06001815 RID: 6165 RVA: 0x00100E90 File Offset: 0x000FFE90
		internal override kz dm()
		{
			int num = this.h;
			if (num > 0)
			{
				num--;
			}
			return new nn(this.b, this.j, num, this.i);
		}

		// Token: 0x04000AD1 RID: 2769
		private int a;

		// Token: 0x04000AD2 RID: 2770
		private n3 b;

		// Token: 0x04000AD3 RID: 2771
		private x5 c = x5.c();

		// Token: 0x04000AD4 RID: 2772
		private int d = 0;

		// Token: 0x04000AD5 RID: 2773
		private int e = 0;

		// Token: 0x04000AD6 RID: 2774
		private l2 f = null;

		// Token: 0x04000AD7 RID: 2775
		private bool g = false;

		// Token: 0x04000AD8 RID: 2776
		private int h = 0;

		// Token: 0x04000AD9 RID: 2777
		private int i = 0;

		// Token: 0x04000ADA RID: 2778
		private bool j = false;
	}
}
