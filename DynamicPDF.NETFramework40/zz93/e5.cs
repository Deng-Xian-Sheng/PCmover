using System;
using System.Collections.Generic;

namespace zz93
{
	// Token: 0x020000D9 RID: 217
	internal class e5 : er
	{
		// Token: 0x060009BD RID: 2493 RVA: 0x0007F3D8 File Offset: 0x0007E3D8
		internal e5(e7 A_0, kg A_1, d3 A_2, ij A_3)
		{
			this.a = A_0;
			this.b = new e6(A_1, A_2, A_3);
			this.b.cq();
			base.b(true);
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x0007F448 File Offset: 0x0007E448
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x0007F460 File Offset: 0x0007E460
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x0007F478 File Offset: 0x0007E478
		internal override bool ci()
		{
			return false;
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x0007F48C File Offset: 0x0007E48C
		internal int a()
		{
			return this.c;
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x0007F4A4 File Offset: 0x0007E4A4
		internal void a(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x0007F4B0 File Offset: 0x0007E4B0
		internal List<kz> b()
		{
			return this.f;
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x0007F4C8 File Offset: 0x0007E4C8
		internal override fa cr()
		{
			return fa.d;
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x0007F4DC File Offset: 0x0007E4DC
		internal int c()
		{
			return this.e;
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x0007F4F4 File Offset: 0x0007E4F4
		internal void b(int A_0)
		{
			this.e = A_0;
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x0007F500 File Offset: 0x0007E500
		private fp a(ij A_0)
		{
			int num = 0;
			it it = null;
			i5 i = null;
			ja ja = null;
			fp fp = new fp();
			fp.a(1);
			if (this.a.a() != gn.e)
			{
				it = new it();
				it.a(new iu(this.a.a()));
				num++;
			}
			if (this.a.c() != gs.a)
			{
				i = new i5();
				i.a(new i6(this.a.c(), x5.c()));
				num++;
			}
			if (this.a.d().a().a() != 0f)
			{
				f9 f = new f9(m4.a(this.a.d()));
				if (this.a.d().a().b() == i2.b)
				{
					f.a(true);
				}
				ja = new ja();
				ja.a(f);
				num++;
			}
			if (this.a.b() != -2147483648)
			{
				fp.a(this.a.b());
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
			ig a_ = new ig(array);
			A_0.a(this.ch().cn(), a_, this.c, this.d, 0);
			return fp;
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x0007F704 File Offset: 0x0007E704
		internal override kz cm(ij A_0, kz A_1)
		{
			nu nu = new nu();
			nu.j(A_1);
			nu.a(base.e());
			nu.b(this.d);
			fp fp = this.a(A_0);
			A_0.a(this.ch(), this.c, this.d, 0);
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
			int num = this.d;
			this.e = num;
			if (this.cg() != null && this.cg().h() > 0)
			{
				for (int i = 0; i < this.cg().h(); i++)
				{
					((e3)this.cg().b(i)).b(this.c);
					((e3)this.cg().b(i)).a(num);
					kz kz = this.cg().b(i).cm(A_0, nu);
					base.i(kz, nu);
					this.f.Add(kz);
					num += ((n5)kz.db()).y();
				}
				this.e = num;
			}
			else
			{
				this.e += fp.a();
			}
			return nu;
		}

		// Token: 0x040004E4 RID: 1252
		private new e7 a = null;

		// Token: 0x040004E5 RID: 1253
		private e6 b = null;

		// Token: 0x040004E6 RID: 1254
		private int c = 0;

		// Token: 0x040004E7 RID: 1255
		private new int d = 0;

		// Token: 0x040004E8 RID: 1256
		private new int e = 0;

		// Token: 0x040004E9 RID: 1257
		private new List<kz> f = new List<kz>();
	}
}
