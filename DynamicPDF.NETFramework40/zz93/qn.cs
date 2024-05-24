using System;

namespace zz93
{
	// Token: 0x02000279 RID: 633
	internal class qn : er
	{
		// Token: 0x06001C4F RID: 7247 RVA: 0x001239E7 File Offset: 0x001229E7
		internal qn(qp A_0) : base(null)
		{
			this.a = A_0;
			this.b = new qo();
		}

		// Token: 0x06001C50 RID: 7248 RVA: 0x00123A1C File Offset: 0x00122A1C
		internal qn(qp A_0, kg A_1, d3 A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new qo(A_1, A_2, A_3);
			this.b.cq();
		}

		// Token: 0x06001C51 RID: 7249 RVA: 0x00123A6C File Offset: 0x00122A6C
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001C52 RID: 7250 RVA: 0x00123A84 File Offset: 0x00122A84
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001C53 RID: 7251 RVA: 0x00123A9C File Offset: 0x00122A9C
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001C54 RID: 7252 RVA: 0x00123AB4 File Offset: 0x00122AB4
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001C55 RID: 7253 RVA: 0x00123AC0 File Offset: 0x00122AC0
		internal override fa cr()
		{
			return fa.g;
		}

		// Token: 0x06001C56 RID: 7254 RVA: 0x00123AD4 File Offset: 0x00122AD4
		private void a(nx A_0, ij A_1)
		{
			int num = 0;
			int num2 = base.f();
			A_0.d2(num2);
			base.d(A_0);
			if (this.cg() != null && this.cg().h() > 0)
			{
				((er)this.cg().b(0)).a(base.k());
				((er)this.cg().b(0)).a(base.l());
				((er)this.cg().b(0)).c(base.e());
				((er)this.cg().b(0)).d(num2);
				((er)this.cg().b(0)).e(num);
				((er)this.cg().b(0)).a(base.j());
				bool[] array = new bool[this.cg().h()];
				int num3 = 0;
				ms ms = null;
				kz kz = this.cg().b(0).cm(A_1, A_0);
				if (kz != null)
				{
					if (kz.dg() == 3034 || kz.dg() == 3418)
					{
						((nt)kz).a(num);
					}
					kz.j(A_0);
					num += ((n5)kz.db()).y();
					ms = new ms(kz);
					array[num3] = true;
				}
				else
				{
					array[num3] = false;
				}
				num3++;
				for (int i = 1; i < this.cg().h(); i++)
				{
					((er)this.cg().b(i)).a(base.k());
					((er)this.cg().b(i)).a(base.l());
					((er)this.cg().b(i)).c(base.e());
					((er)this.cg().b(i)).d(num2);
					((er)this.cg().b(i)).e(num);
					((er)this.cg().b(i)).a(base.j());
					kz = this.cg().b(i).cm(A_1, A_0);
					if (kz != null)
					{
						if (kz.dg() == 3034 || kz.dg() == 3418)
						{
							((nt)kz).a(num);
						}
						kz.j(A_0);
						num += ((n5)kz.db()).y();
						if (ms != null)
						{
							ms.l().a(kz);
						}
						else
						{
							ms = new ms(kz);
						}
						array[num3] = true;
					}
					else
					{
						array[num3] = false;
					}
					num3++;
				}
				A_0.c(new mt(ms));
				this.a(array);
			}
			base.f(num2 + 1);
		}

		// Token: 0x06001C57 RID: 7255 RVA: 0x00123E0C File Offset: 0x00122E0C
		private void a(bool[] A_0)
		{
			qo qo = new qo();
			for (int i = 0; i < this.cg().h(); i++)
			{
				if (A_0[i])
				{
					qo.a(this.cg().b(i));
				}
			}
			this.b = qo;
		}

		// Token: 0x06001C58 RID: 7256 RVA: 0x00123E60 File Offset: 0x00122E60
		private void a(ij A_0)
		{
			int num = 0;
			it it = null;
			i5 i = null;
			fe fe = null;
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
			if (this.a.a() != null)
			{
				fb<fs>[] a_ = new fb<fs>[]
				{
					new fb<fs>(510035525, new afu(this.a.a())),
					new fb<fs>(137106767, new afv(null)),
					new fb<fs>(19010090, new afx(gl.a)),
					new fb<fs>(808234079, new aft(fq.c)),
					new fb<fs>(440052479, new afw(fr.a, x5.c(), i2.d, x5.c(), i2.d))
				};
				fe = new fe();
				fe.a(a_);
				num++;
			}
			if (num > 0)
			{
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
				if (fe != null)
				{
					array[num2] = new fc(1617181893, fe);
					num2++;
				}
				ig a_2 = new ig(array);
				A_0.a(this.ch().cn(), a_2);
				A_0.a(true);
			}
		}

		// Token: 0x06001C59 RID: 7257 RVA: 0x0012406C File Offset: 0x0012306C
		internal override kz cm(ij A_0, kz A_1)
		{
			nx nx = new nx();
			this.a(A_0);
			A_0.c(this.ch());
			A_0.a(nx);
			n5 n = (n5)nx.db();
			nx.c5().c().i(n.j());
			A_0.b(nx);
			bool flag = true;
			bool a_ = false;
			g2? g = nx.c5().t();
			g2 valueOrDefault = g.GetValueOrDefault();
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					nx = null;
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
				nx.c5().e().u();
				nx.j(A_1);
				i3.a(nx);
				i3.a(nx, A_0);
				m4.a(n, nx.c5(), a_);
				if (nx.c5().ay().d() && nx.c5().ay().e() != null)
				{
					nx.b(mg.a(A_0, nx.c5().ay().e(), A_0.e()));
				}
				g = nx.c5().t();
				if (g == g2.c)
				{
					this.c = false;
				}
				nx.aa(A_1.ch());
				if (nx.ch())
				{
					nx.ab(A_1.ci());
					nx.az(A_1.cl());
					nx.ay(A_1.ck());
				}
				this.a(nx, A_0);
				if (nx.c5().d())
				{
					base.a(nx, base.i());
				}
				if (nx.c5().v() != null)
				{
					base.d(nx);
				}
				nx.dw(base.j());
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return nx;
		}

		// Token: 0x04000CBD RID: 3261
		private new qp a = null;

		// Token: 0x04000CBE RID: 3262
		private qo b = null;

		// Token: 0x04000CBF RID: 3263
		private bool c = true;
	}
}
