using System;

namespace zz93
{
	// Token: 0x02000187 RID: 391
	internal class jz : dy
	{
		// Token: 0x06000DBB RID: 3515 RVA: 0x0009B480 File Offset: 0x0009A480
		internal jz(j0 A_0)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x06000DBC RID: 3516 RVA: 0x0009B4D0 File Offset: 0x0009A4D0
		internal jz(j0 A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06000DBD RID: 3517 RVA: 0x0009B528 File Offset: 0x0009A528
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000DBE RID: 3518 RVA: 0x0009B540 File Offset: 0x0009A540
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000DBF RID: 3519 RVA: 0x0009B558 File Offset: 0x0009A558
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06000DC0 RID: 3520 RVA: 0x0009B570 File Offset: 0x0009A570
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000DC1 RID: 3521 RVA: 0x0009B57C File Offset: 0x0009A57C
		internal override bool cp()
		{
			return true;
		}

		// Token: 0x06000DC2 RID: 3522 RVA: 0x0009B590 File Offset: 0x0009A590
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x06000DC3 RID: 3523 RVA: 0x0009B5A8 File Offset: 0x0009A5A8
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06000DC4 RID: 3524 RVA: 0x0009B5B4 File Offset: 0x0009A5B4
		private void a(ij A_0)
		{
			int num = 0;
			iv iv = null;
			hd hd = null;
			if (this.a.a() != null)
			{
				num++;
				iv = new iv();
				iv.a(new go(this.a.a()));
			}
			if (this.a.c() != -2147483648)
			{
				hd = new hd();
				fb<f5>[] array = new fb<f5>[6];
				x5 a_ = x5.a(12f);
				switch (this.a.d())
				{
				case 0:
					a_ = this.c(this.a.c());
					break;
				case 1:
					a_ = this.b(this.a.c());
					break;
				case 2:
					a_ = this.a(this.a.c());
					break;
				}
				af0 af = new af0(a_);
				af.a(i2.d);
				int num2 = 0;
				array[num2++] = new fb<f5>(2163680, af);
				if (this.a.b() != null && this.a.b().Length > 0)
				{
					array[num2] = new fb<f5>(675106854, new afy(this.a.b()[0]));
				}
				else
				{
					array[num2] = new fb<f5>(675106854, new afy("Arial"));
					array[num2].b().d(true);
				}
				array[num2] = new fb<f5>(144877216, new af1(f4.a));
				array[num2].b().d(true);
				num2++;
				array[num2] = new fb<f5>(791474706, new af3(f7.h));
				array[num2].b().d(true);
				hd.cu(false);
				hd.a(array);
				num++;
			}
			else if (this.a.b() != null && this.a.b().Length > 0)
			{
				int num2 = 0;
				num++;
				hd = new hd();
				fb<f5>[] array = new fb<f5>[6];
				array[num2] = new fb<f5>(675106854, new afy(this.a.b()[0]));
				num2++;
				array[num2] = new fb<f5>(144877216, new af1(f4.a));
				array[num2].b().d(true);
				num2++;
				array[num2] = new fb<f5>(791474706, new af3(f7.h));
				array[num2].b().d(true);
				hd.cu(false);
				hd.a(array);
			}
			if (num > 0)
			{
				fc[] array2 = new fc[num];
				num = 0;
				if (iv != null)
				{
					array2[num] = new fc(510035525, iv);
					num++;
				}
				if (hd != null)
				{
					array2[num] = new fc(6968946, hd);
					num++;
				}
				ig a_2 = new ig(array2);
				A_0.a(this.ch().cn(), a_2);
				A_0.a(true);
			}
		}

		// Token: 0x06000DC5 RID: 3525 RVA: 0x0009B958 File Offset: 0x0009A958
		private x5 c(int A_0)
		{
			x5 x = x5.a(12f);
			switch (A_0)
			{
			case 0:
			case 1:
				return x5.a(hd.k);
			case 2:
				return x5.a(hd.j);
			case 3:
				return x5.a(hd.r);
			case 4:
				return x5.a(hd.n);
			case 5:
				return x5.a(hd.o);
			case 6:
				return x5.a(hd.p);
			}
			return x5.a(36f);
		}

		// Token: 0x06000DC6 RID: 3526 RVA: 0x0009BA04 File Offset: 0x0009AA04
		private x5 b(int A_0)
		{
			x5 x = x5.a(12f);
			switch (A_0)
			{
			case 0:
				return x5.a(hd.r);
			case 1:
				return x5.a(hd.n);
			case 2:
				return x5.a(hd.o);
			case 3:
				return x5.a(hd.p);
			}
			return x5.a(36f);
		}

		// Token: 0x06000DC7 RID: 3527 RVA: 0x0009BA94 File Offset: 0x0009AA94
		private x5 a(int A_0)
		{
			x5 x = x5.a(12f);
			switch (A_0)
			{
			case 0:
				return x5.a(12f);
			case 1:
				return x5.a(10f);
			}
			return x5.a(hd.k);
		}

		// Token: 0x06000DC8 RID: 3528 RVA: 0x0009BB04 File Offset: 0x0009AB04
		internal override kz cm(ij A_0, kz A_1)
		{
			l3 l = new l3();
			this.a(A_0);
			A_0.c(this.ch());
			A_0.a(l);
			n5 n = (n5)l.db();
			l.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(l);
			}
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = l.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					l = null;
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
				l.j(A_1);
				i3.a(l);
				i3.a(l, A_0);
				m4.a(n, l.c5(), a_);
				if (l.c5().ay().e() != null)
				{
					l.b(mg.a(A_0, l.c5().ay().e(), A_0.e()));
				}
				base.e(l, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return l;
		}

		// Token: 0x040006E8 RID: 1768
		private new j0 a = null;

		// Token: 0x040006E9 RID: 1769
		private kl b = null;

		// Token: 0x040006EA RID: 1770
		private bool c = false;

		// Token: 0x040006EB RID: 1771
		private new bool d = true;
	}
}
