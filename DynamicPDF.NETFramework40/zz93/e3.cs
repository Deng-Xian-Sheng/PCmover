using System;

namespace zz93
{
	// Token: 0x020000D7 RID: 215
	internal class e3 : er
	{
		// Token: 0x060009AE RID: 2478 RVA: 0x0007EE2C File Offset: 0x0007DE2C
		internal e3(e9 A_0, kg A_1, d3 A_2, ij A_3)
		{
			this.a = A_0;
			this.b = new e4(A_1, A_2, A_3);
			this.b.cq();
			base.b(true);
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x0007EE88 File Offset: 0x0007DE88
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x0007EEA0 File Offset: 0x0007DEA0
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x0007EEB8 File Offset: 0x0007DEB8
		internal override bool ci()
		{
			return false;
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x0007EECC File Offset: 0x0007DECC
		internal int a()
		{
			return this.c;
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x0007EEE4 File Offset: 0x0007DEE4
		internal void a(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x0007EEF0 File Offset: 0x0007DEF0
		internal int b()
		{
			return this.d;
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x0007EF08 File Offset: 0x0007DF08
		internal void b(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x0007EF14 File Offset: 0x0007DF14
		internal override fa cr()
		{
			return fa.c;
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x0007EF28 File Offset: 0x0007DF28
		private fp a(ij A_0)
		{
			int num = 0;
			it it = null;
			i5 i = null;
			ja ja = null;
			fp fp = new fp();
			fp.a(1);
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
			if (this.a.b().a().a() != 0f)
			{
				f9 a_ = new f9(m4.a(this.a.b()));
				ja = new ja();
				ja.a(a_);
				num++;
			}
			if (this.a.a() != -2147483648)
			{
				fp.a(this.a.a());
			}
			num++;
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
			if (ja != null)
			{
				array[num2] = new fc(795562982, ja);
				num2++;
			}
			array[num2] = new fc(9705568, fp);
			ig a_2 = new ig(array);
			A_0.a(this.ch().cn(), a_2, this.b(), this.a(), 1);
			return fp;
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x0007F0FC File Offset: 0x0007E0FC
		internal override kz cm(ij A_0, kz A_1)
		{
			nu nu = new nu();
			nu.j(A_1);
			nu.a(base.e());
			nu.b(this.c);
			fp fp = this.a(A_0);
			A_0.a(this.ch(), this.b(), this.a(), 1);
			A_0.b(nu);
			A_0.a(nu);
			i3.a(nu);
			i3.a(nu, A_0);
			n5 n = (n5)nu.db();
			m4.a(n, nu.c5(), false);
			if (nu.c5().ay().d() && nu.c5().ay().e() != null)
			{
				nu.b(mg.a(A_0, nu.c5().ay().e(), A_0.e()));
			}
			n.a(fp.a());
			return nu;
		}

		// Token: 0x040004DF RID: 1247
		private new e9 a = null;

		// Token: 0x040004E0 RID: 1248
		private e4 b = null;

		// Token: 0x040004E1 RID: 1249
		private int c = 0;

		// Token: 0x040004E2 RID: 1250
		private new int d = -1;
	}
}
