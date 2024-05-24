using System;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x0200023F RID: 575
	internal class o1 : dy
	{
		// Token: 0x06001A95 RID: 6805 RVA: 0x00114B94 File Offset: 0x00113B94
		internal o1(o4 A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new o2(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001A96 RID: 6806 RVA: 0x00114BF0 File Offset: 0x00113BF0
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001A97 RID: 6807 RVA: 0x00114C08 File Offset: 0x00113C08
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001A98 RID: 6808 RVA: 0x00114C20 File Offset: 0x00113C20
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001A99 RID: 6809 RVA: 0x00114C38 File Offset: 0x00113C38
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001A9A RID: 6810 RVA: 0x00114C44 File Offset: 0x00113C44
		internal bool b()
		{
			return this.d;
		}

		// Token: 0x06001A9B RID: 6811 RVA: 0x00114C5C File Offset: 0x00113C5C
		internal void a(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001A9C RID: 6812 RVA: 0x00114C68 File Offset: 0x00113C68
		internal int c()
		{
			return this.e;
		}

		// Token: 0x06001A9D RID: 6813 RVA: 0x00114C80 File Offset: 0x00113C80
		internal void a(int A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06001A9E RID: 6814 RVA: 0x00114C8C File Offset: 0x00113C8C
		private void a(k0 A_0, ij A_1)
		{
			A_0.c5().j(new x5?(x5.c()));
			ms ms = null;
			mt a_ = null;
			n5 n = (n5)A_0.db();
			x5? x = n.p();
			float num = 0f;
			l2 l = A_1.c().a(n, A_1);
			float a_2 = x5.b(n.a().i());
			if (this.a.d() != null && this.a.d() != string.Empty)
			{
				qd value = new qd(this.a.d().ToCharArray(), 0, this.a.d().Length, this.b.k().b());
				this.b.i()[0] = value;
			}
			if (this.cg() != null && this.cg().h() > 0)
			{
				kz kz = this.cg().b(0).cm(A_1, A_0);
				if (kz != null)
				{
					ms = new ms(kz);
					if (x != null)
					{
						ms.k(x.Value);
					}
					ms.e(true);
					if (kz.dg() != 1977)
					{
						num = this.a((n3)kz, A_0, l.e(), a_2);
					}
				}
				for (int i = 1; i < this.cg().h(); i++)
				{
					kz = this.cg().b(i).cm(A_1, A_0);
					if (kz != null)
					{
						ms.l().a(kz);
						num += this.a(kz, A_0, l.e(), a_2);
					}
				}
				a_ = new mt(ms);
			}
			A_0.c(a_);
		}

		// Token: 0x06001A9F RID: 6815 RVA: 0x00114E90 File Offset: 0x00113E90
		private void b(m6 A_0)
		{
			if (A_0.c5().d())
			{
				lf lf = A_0.c5().c();
				lf.c(x5.c());
				lf.d(x5.c());
				lf.a(x5.c());
				lf.b(x5.c());
			}
			A_0.c5().e().a(x5.c());
			A_0.c5().e().a(i2.d);
			A_0.c5().e().d(x5.c());
			A_0.c5().e().d(i2.d);
			A_0.c5().e().b(x5.c());
			A_0.c5().e().b(i2.d);
			A_0.c5().e().c(x5.c());
			A_0.c5().e().c(i2.d);
			switch (A_0.c5().g())
			{
			case false:
			{
				m8 m = new m8();
				m.a(this.a().a());
				A_0.c5().a(m);
				A_0.c5().b(true);
				break;
			}
			case true:
				A_0.c5().f().d(x5.a(2.25));
				A_0.c5().f().b(x5.a(3.75));
				A_0.c5().f().a(x5.c());
				A_0.c5().f().c(x5.c());
				break;
			}
			if (this.a.c() && (this.d || this.e > 1))
			{
				this.a(A_0);
			}
			A_0.c5().a(g3.c);
		}

		// Token: 0x06001AA0 RID: 6816 RVA: 0x00115094 File Offset: 0x00114094
		private void a(m6 A_0)
		{
			bool flag = true;
			int num = A_0.dr().dg();
			if (num != 86147604)
			{
				if (num == 506042859)
				{
					if (((m7)A_0.dr()).b())
					{
						flag = false;
					}
				}
			}
			else if (((ng)A_0.dr()).b())
			{
				flag = false;
			}
			if (flag)
			{
				string a_ = "#3399FF";
				if (A_0.c5().ay() != null)
				{
					if (!A_0.c5().ay().b())
					{
						A_0.c5().ay().a(Color.d(a_));
						A_0.c5().ay().b(true);
					}
				}
				else
				{
					fe fe = new fe();
					fb<fs>[] array = new fb<fs>[5];
					array[0] = new fb<fs>(510035525, new afu(a_));
					fe.a(array);
					k8 k = new k8();
					k.a(array);
					A_0.c5().a(k);
					A_0.c5().ay().b(true);
				}
			}
		}

		// Token: 0x06001AA1 RID: 6817 RVA: 0x001151D0 File Offset: 0x001141D0
		private hx a()
		{
			hx hx = new hx();
			ge ge = new ge(x5.a(2.25));
			ge ge2 = new ge(x5.a(3.75));
			ge.a(i2.d);
			ge2.a(i2.d);
			hx.a()[2] = new fb<ge>(7021096, ge);
			hx.a()[3] = new fb<ge>(448574430, ge2);
			return hx;
		}

		// Token: 0x06001AA2 RID: 6818 RVA: 0x0011525C File Offset: 0x0011425C
		private float a(kz A_0, k0 A_1, Font A_2, float A_3)
		{
			float num;
			if (A_0.dg() == 100)
			{
				n3 n = (n3)A_0;
				num = A_2.a(n.d(), n.h(), A_0.ba(), A_3);
			}
			else
			{
				num = A_2.a(" ".ToCharArray(), 0, A_0.ba(), A_3);
			}
			float defaultLeading = A_2.GetDefaultLeading(A_3);
			lk lk = A_1.c5();
			x5? x = lk.am();
			x5 a_ = x5.a(num);
			lk.j((x != null) ? new x5?(x5.f(x.GetValueOrDefault(), a_)) : null);
			A_1.c5().d(i2.d);
			if (defaultLeading != 0f)
			{
				A_1.c5().i(new x5?(x5.a(defaultLeading)));
				A_1.c5().a(i2.d);
			}
			return num;
		}

		// Token: 0x06001AA3 RID: 6819 RVA: 0x0011535C File Offset: 0x0011435C
		internal override kz cm(ij A_0, kz A_1)
		{
			m6 m = new m6();
			A_0.c(this.ch());
			A_0.a(m);
			n5 n = (n5)m.db();
			m.c5().c().i(n.j());
			A_0.b(m);
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = m.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					m = null;
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
				m.j(A_1);
				i3.a(m);
				i3.a(m, A_0);
				m4.a(n, m.c5(), a_);
				if (m.c5().ay().d() && m.c5().ay().e() != null)
				{
					m.b(mg.a(A_0, m.c5().ay().e(), A_0.e()));
				}
				this.b(m);
				i3.b(m);
				this.a(m, A_0);
				m.a(this.a.c());
				m.b(this.a.a());
				int num = A_1.dg();
				if (num != 86147604)
				{
					if (num == 506042859)
					{
						if (((m7)A_1).b())
						{
							n.a(Color.d("#A0A0A0"));
							m.c5().c().i(n.j());
						}
						else if (((ng)A_1.dr()).b())
						{
							n.a(Color.d("#A0A0A0"));
							m.c5().c().i(n.j());
						}
					}
				}
				else if (((ng)A_1).b())
				{
					n.a(Color.d("#A0A0A0"));
					m.c5().c().i(n.j());
				}
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return m;
		}

		// Token: 0x04000C1A RID: 3098
		private new o4 a = null;

		// Token: 0x04000C1B RID: 3099
		private o2 b = null;

		// Token: 0x04000C1C RID: 3100
		private bool c = true;

		// Token: 0x04000C1D RID: 3101
		private new bool d = false;

		// Token: 0x04000C1E RID: 3102
		private new int e = 1;
	}
}
