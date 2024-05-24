using System;

namespace zz93
{
	// Token: 0x02000270 RID: 624
	internal class qe : er
	{
		// Token: 0x06001C14 RID: 7188 RVA: 0x00121225 File Offset: 0x00120225
		internal qe(qg A_0, kg A_1, d3 A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new qf(A_1, A_2, A_3);
			this.b.cq();
		}

		// Token: 0x06001C15 RID: 7189 RVA: 0x00121264 File Offset: 0x00120264
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001C16 RID: 7190 RVA: 0x0012127C File Offset: 0x0012027C
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001C17 RID: 7191 RVA: 0x00121294 File Offset: 0x00120294
		internal override bool ci()
		{
			return true;
		}

		// Token: 0x06001C18 RID: 7192 RVA: 0x001212A8 File Offset: 0x001202A8
		internal override fa cr()
		{
			return fa.i;
		}

		// Token: 0x06001C19 RID: 7193 RVA: 0x001212BC File Offset: 0x001202BC
		private void a(n6 A_0, ij A_1)
		{
			mt mt = null;
			ms ms = null;
			int a_ = base.f();
			int num = 0;
			if (this.cg() != null && this.cg().h() > 0)
			{
				for (int i = 0; i < this.cg().h(); i++)
				{
					if (ms == null)
					{
						((er)this.cg().b(i)).a(base.k());
						((er)this.cg().b(i)).a(base.l());
						((er)this.cg().b(i)).c(base.e());
						((er)this.cg().b(i)).d(a_);
						((er)this.cg().b(i)).a(base.j());
						k0 k = (k0)this.cg().b(i).cm(A_1, A_0);
						if (k == null)
						{
							this.cg().c(i);
							i--;
						}
						else
						{
							a_ = ((er)this.cg().b(i)).h();
							if (k.dg() == 1946)
							{
								k.d4(num);
								num++;
							}
							k.j(A_0);
							ms = new ms(k);
							if (mt != null)
							{
								mt.c(ms);
							}
							else
							{
								mt = new mt(ms);
							}
							ms = null;
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

		// Token: 0x06001C1A RID: 7194 RVA: 0x001214C0 File Offset: 0x001204C0
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
			bool flag = false;
			if (num == 2)
			{
				if (it != null)
				{
					array[0] = new fc(1982903832, it);
				}
				if (i != null)
				{
					array[1] = new fc(202920309, i);
				}
				flag = true;
			}
			else if (num == 1)
			{
				if (it != null)
				{
					array[0] = new fc(1982903832, it);
				}
				if (i != null)
				{
					array[0] = new fc(202920309, i);
				}
				flag = true;
			}
			if (flag)
			{
				ig a_ = new ig(array);
				A_0.a(this.ch().cn(), a_);
				A_0.a(true);
			}
		}

		// Token: 0x06001C1B RID: 7195 RVA: 0x00121608 File Offset: 0x00120608
		private void a(mt A_0, n6 A_1, int A_2)
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

		// Token: 0x06001C1C RID: 7196 RVA: 0x001216D0 File Offset: 0x001206D0
		internal override kz cm(ij A_0, kz A_1)
		{
			n6 n = new n6();
			this.a(A_0);
			A_0.c(this.ch());
			A_0.a(n);
			n5 n2 = (n5)n.db();
			n.c5().c().i(n2.j());
			A_0.b(n);
			bool flag = true;
			bool a_ = false;
			lk lk = n.c5();
			g2 valueOrDefault = lk.t().GetValueOrDefault();
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
				m4.a(n2, lk, a_);
				if (lk.ay().d() && lk.ay().e() != null)
				{
					n.b(mg.a(A_0, lk.ay().e(), A_0.e()));
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

		// Token: 0x04000CAA RID: 3242
		private new qg a = null;

		// Token: 0x04000CAB RID: 3243
		private qf b = null;
	}
}
