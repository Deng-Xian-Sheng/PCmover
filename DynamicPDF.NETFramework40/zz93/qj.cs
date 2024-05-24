using System;

namespace zz93
{
	// Token: 0x02000275 RID: 629
	internal class qj : er
	{
		// Token: 0x06001C33 RID: 7219 RVA: 0x00122A0C File Offset: 0x00121A0C
		internal qj(ql A_0, kg A_1, d3 A_2, ij A_3)
		{
			this.a = A_0;
			this.b = new qk(A_1, A_2, A_3);
			this.b.cq();
		}

		// Token: 0x06001C34 RID: 7220 RVA: 0x00122A48 File Offset: 0x00121A48
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001C35 RID: 7221 RVA: 0x00122A60 File Offset: 0x00121A60
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001C36 RID: 7222 RVA: 0x00122A78 File Offset: 0x00121A78
		internal override bool ci()
		{
			return true;
		}

		// Token: 0x06001C37 RID: 7223 RVA: 0x00122A8C File Offset: 0x00121A8C
		private void a(n7 A_0, ij A_1)
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
				A_0.c(mt);
				base.f(mt);
				A_0.a(base.e(mt));
				if (A_0.c5().d())
				{
					this.a(mt, A_0, num);
				}
			}
			base.f(a_);
		}

		// Token: 0x06001C38 RID: 7224 RVA: 0x00122C40 File Offset: 0x00121C40
		private void a(ij A_0)
		{
			int num = 0;
			it it = null;
			i5 i = null;
			if (this.a.i() != gn.e)
			{
				it = new it();
				it.a(new iu(this.a.i()));
				num++;
			}
			if (this.a.j() != gs.a)
			{
				i = new i5();
				i.a(new i6(this.a.j(), x5.c()));
				num++;
			}
			fc[] array = new fc[num];
			int num2 = 0;
			if (it != null)
			{
				array[num2] = new fc(1982903832, it);
				num2++;
			}
			if (i != null)
			{
				array[num2] = new fc(202920309, i);
				num2++;
			}
			ig a_ = new ig(array);
			A_0.a(this.ch().cn(), a_);
			A_0.a(true);
		}

		// Token: 0x06001C39 RID: 7225 RVA: 0x00122D38 File Offset: 0x00121D38
		private void a(mt A_0, n7 A_1, int A_2)
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
				base.a(a_2, A_1.b());
				if (A_2 > 1)
				{
					ms ms = A_0.b(A_2 - 1);
					a_2 = (k0)ms.l().a().b();
					base.a(a_2, A_1.b());
				}
			}
		}

		// Token: 0x06001C3A RID: 7226 RVA: 0x00122E00 File Offset: 0x00121E00
		internal override kz cm(ij A_0, kz A_1)
		{
			n7 n = new n7();
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
				n.aa(A_1.ch());
				if (n.ch())
				{
					n.ab(A_1.ci());
					n.az(A_1.cl());
					n.ay(A_1.ck());
				}
				i3.a(n);
				i3.a(n, A_0);
				m4.a(n2, n.c5(), a_);
				if (n.c5().ay().d() && n.c5().ay().e() != null)
				{
					n.b(mg.a(A_0, n.c5().ay().e(), A_0.e()));
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

		// Token: 0x04000CB2 RID: 3250
		private new ql a = null;

		// Token: 0x04000CB3 RID: 3251
		private qk b = null;
	}
}
