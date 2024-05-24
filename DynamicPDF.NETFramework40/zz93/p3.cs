using System;

namespace zz93
{
	// Token: 0x02000265 RID: 613
	internal class p3 : er
	{
		// Token: 0x06001BBC RID: 7100 RVA: 0x0011DEB1 File Offset: 0x0011CEB1
		internal p3(p5 A_0, kg A_1, d3 A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new p4(A_1, A_2, A_3);
			this.b.cq();
		}

		// Token: 0x06001BBD RID: 7101 RVA: 0x0011DEF0 File Offset: 0x0011CEF0
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001BBE RID: 7102 RVA: 0x0011DF08 File Offset: 0x0011CF08
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001BBF RID: 7103 RVA: 0x0011DF20 File Offset: 0x0011CF20
		internal override bool ci()
		{
			return true;
		}

		// Token: 0x06001BC0 RID: 7104 RVA: 0x0011DF34 File Offset: 0x0011CF34
		internal override fa cr()
		{
			return fa.l;
		}

		// Token: 0x06001BC1 RID: 7105 RVA: 0x0011DF48 File Offset: 0x0011CF48
		private void a(n0 A_0, ij A_1)
		{
			mt mt = null;
			int a_ = base.f();
			int num = 0;
			base.d(A_0);
			if (this.cg() != null && this.cg().h() > 0)
			{
				for (int i = 0; i < this.cg().h(); i++)
				{
					er er = (er)this.cg().b(i);
					er.a(base.k());
					er.a(base.l());
					er.c(base.e());
					er.d(a_);
					er.a(base.j());
					k0 k = (k0)this.cg().b(i).cm(A_1, A_0);
					if (k == null)
					{
						this.cg().c(i);
						i--;
					}
					else
					{
						a_ = er.h();
						if (k.dg() == 1946)
						{
							k.d4(num);
							num++;
						}
						k.j(A_0);
						ms a_2 = new ms(k);
						if (mt != null)
						{
							mt.c(a_2);
						}
						else
						{
							mt = new mt(a_2);
						}
					}
				}
				if (mt != null)
				{
					A_0.c(mt);
					base.f(mt);
					A_0.a(base.e(mt));
					if (A_0.c5().d())
					{
						this.a(mt, A_0, num);
					}
				}
			}
			base.f(a_);
		}

		// Token: 0x06001BC2 RID: 7106 RVA: 0x0011E108 File Offset: 0x0011D108
		private void a(ij A_0)
		{
			int num = 0;
			it it = null;
			if (this.a.i() != gn.e)
			{
				it = new it();
				it.a(new iu(this.a.i()));
				num++;
			}
			i5 i;
			if (this.a.j() != gs.a)
			{
				i = new i5();
				i.a(new i6(this.a.j(), x5.c()));
				num++;
			}
			else
			{
				i = new i5();
				i.a(new i6(gs.g, x5.c()));
				num++;
			}
			fc[] array = new fc[num];
			if (it != null && i != null)
			{
				array[0] = new fc(1982903832, it);
				array[1] = new fc(202920309, i);
			}
			else
			{
				if (it != null)
				{
					array[0] = new fc(1982903832, it);
				}
				if (i != null)
				{
					array[0] = new fc(202920309, i);
				}
			}
			ig a_ = new ig(array);
			A_0.a(this.ch().cn(), a_);
			A_0.a(true);
		}

		// Token: 0x06001BC3 RID: 7107 RVA: 0x0011E240 File Offset: 0x0011D240
		private void a(mt A_0, n0 A_1, int A_2)
		{
			if (base.j() != null && base.j().h() == il.b)
			{
				bool a_ = false;
				k0 a_2 = (k0)A_0.c().a().l().a().b();
				bool a_3 = true;
				if (A_2 == 1)
				{
					a_ = true;
				}
				base.a(a_2, A_1, a_3, a_);
				base.a(a_2, A_1.a());
				if (A_2 > 1)
				{
					ms ms = A_0.b(A_2 - 1);
					a_2 = (k0)ms.l().a().b();
					base.a(a_2, A_1.a());
				}
			}
		}

		// Token: 0x06001BC4 RID: 7108 RVA: 0x0011E308 File Offset: 0x0011D308
		internal override kz cm(ij A_0, kz A_1)
		{
			n0 n = new n0();
			this.a(A_0);
			A_0.c(this.ch());
			A_0.a(n);
			n5 n2 = (n5)n.db();
			n.c5().c().i(n2.j());
			A_0.b(n);
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = n.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					n = null;
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
				n.j(A_1);
				this.g(A_1.ch());
				i3.a(n);
				i3.a(n, A_0);
				m4.a(n2, n.c5(), a_);
				if (n.c5().ay().d() && n.c5().ay().e() != null)
				{
					n.b(mg.a(A_0, n.c5().ay().e(), A_0.e()));
				}
				n.aa(A_1.ch());
				if (n.ch())
				{
					n.ab(A_1.ci());
					n.az(A_1.cl());
					n.ay(A_1.ck());
				}
				this.a(n, A_0);
				n.dw(base.j());
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return n;
		}

		// Token: 0x04000C8A RID: 3210
		private new p5 a = null;

		// Token: 0x04000C8B RID: 3211
		private p4 b = null;
	}
}
