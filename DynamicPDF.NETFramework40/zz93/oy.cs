using System;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x0200023C RID: 572
	internal class oy : dy
	{
		// Token: 0x06001A78 RID: 6776 RVA: 0x00113AB4 File Offset: 0x00112AB4
		internal oy(o0 A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new oz(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001A79 RID: 6777 RVA: 0x00113B1C File Offset: 0x00112B1C
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001A7A RID: 6778 RVA: 0x00113B34 File Offset: 0x00112B34
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001A7B RID: 6779 RVA: 0x00113B4C File Offset: 0x00112B4C
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001A7C RID: 6780 RVA: 0x00113B64 File Offset: 0x00112B64
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001A7D RID: 6781 RVA: 0x00113B70 File Offset: 0x00112B70
		internal bool a()
		{
			return this.d;
		}

		// Token: 0x06001A7E RID: 6782 RVA: 0x00113B88 File Offset: 0x00112B88
		internal void a(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001A7F RID: 6783 RVA: 0x00113B94 File Offset: 0x00112B94
		internal int b()
		{
			return this.e;
		}

		// Token: 0x06001A80 RID: 6784 RVA: 0x00113BAC File Offset: 0x00112BAC
		internal void a(int A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06001A81 RID: 6785 RVA: 0x00113BB8 File Offset: 0x00112BB8
		internal x5? c()
		{
			return this.f;
		}

		// Token: 0x06001A82 RID: 6786 RVA: 0x00113BD0 File Offset: 0x00112BD0
		internal void a(x5? A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06001A83 RID: 6787 RVA: 0x00113BDC File Offset: 0x00112BDC
		private void a(m7 A_0, ij A_1)
		{
			float num = 0f;
			switch (this.d)
			{
			case false:
				if (this.e > 1)
				{
					mt a_ = this.a(A_0, A_1, ref num);
					this.b(A_0, A_1, a_, x5.a(num));
				}
				else
				{
					this.a(A_0, A_1, ref num);
					this.a(A_0, A_1, x5.a(num));
				}
				break;
			case true:
			{
				mt a_ = this.a(A_0, A_1, ref num);
				this.a(A_0, A_1, a_, x5.a(num));
				break;
			}
			}
		}

		// Token: 0x06001A84 RID: 6788 RVA: 0x00113C78 File Offset: 0x00112C78
		private void a(m7 A_0, ij A_1, x5 A_2)
		{
			mt a_ = null;
			ms ms = null;
			int num = 0;
			ms ms2 = null;
			if (this.cg() != null && this.cg().h() > 0)
			{
				for (int i = 0; i < this.cg().h(); i++)
				{
					m6 m = (m6)this.cg().b(i).cm(A_1, A_0);
					if (num < this.e)
					{
						ms ms3 = new ms(m);
						ms3.e(true);
						a_ = new mt(ms3);
					}
					if (m != null)
					{
						if (m.a())
						{
							ms = new ms(m);
						}
						if (!m.b() && ms2 == null)
						{
							ms2 = new ms(m);
						}
						x5 a_2 = x5.a(15f);
						if (x5.d(A_2, x5.f(m.c5().am().Value, a_2)))
						{
							A_2 = x5.f(m.c5().am().Value, a_2);
						}
					}
					num++;
				}
			}
			if (ms != null)
			{
				ms.o(true);
				a_ = new mt(ms);
			}
			else if (ms2 != null)
			{
				a_ = new mt(ms2);
			}
			A_0.c(a_);
			A_0.c5().j(new x5?(A_2));
		}

		// Token: 0x06001A85 RID: 6789 RVA: 0x00113E20 File Offset: 0x00112E20
		private void b(m7 A_0, ij A_1, mt A_2, x5 A_3)
		{
			bool a_ = false;
			if (A_2 != null)
			{
				a_ = true;
			}
			if (this.cg() != null && this.cg().h() > 0)
			{
				((o1)this.cg().b(0)).a(this.e);
				m6 m = (m6)this.cg().b(0).cm(A_1, A_0);
				if (m != null)
				{
					if (m.a())
					{
						A_0.a(true);
					}
					ms a_2 = this.a(m, a_, ref A_3);
					if (A_2 == null)
					{
						A_2 = new mt(a_2);
					}
					else
					{
						A_2.c(a_2);
					}
				}
				for (int i = 1; i < this.cg().h(); i++)
				{
					((o1)this.cg().b(i)).a(this.e);
					m = (m6)this.cg().b(i).cm(A_1, A_0);
					if (m != null)
					{
						if (m.a())
						{
							A_0.a(true);
						}
						ms a_2 = this.a(m, a_, ref A_3);
						A_2.c(a_2);
					}
				}
			}
			A_0.c(A_2);
			A_0.c5().j(new x5?(A_3));
		}

		// Token: 0x06001A86 RID: 6790 RVA: 0x00113F94 File Offset: 0x00112F94
		private ms a(kz A_0, bool A_1, ref x5 A_2)
		{
			if (A_1)
			{
				A_0.c5().f().d(x5.a(15f));
				A_0.c5().f().b(x5.c());
				A_0.c5().f().a(x5.c());
				A_0.c5().f().c(x5.c());
			}
			if (x5.d(A_2, x5.f(A_0.c5().am().Value, A_0.c5().f().d())))
			{
				A_2 = x5.f(A_0.c5().am().Value, A_0.c5().f().d());
			}
			ms ms = new ms(A_0);
			ms.e(true);
			return ms;
		}

		// Token: 0x06001A87 RID: 6791 RVA: 0x00114088 File Offset: 0x00113088
		private void a(m7 A_0, ij A_1, mt A_2, x5 A_3)
		{
			int num = 1;
			if (this.cg() != null && this.cg().h() > 0)
			{
				for (int i = 0; i < this.cg().h(); i++)
				{
					((o1)this.cg().b(i)).a(this.e);
					kz kz = this.cg().b(i).cm(A_1, A_0);
					kz.c5().f().d(x5.a(15f));
					kz.c5().f().b(x5.c());
					kz.c5().f().a(x5.c());
					kz.c5().f().c(x5.c());
					if (num < this.e)
					{
						ms ms = new ms(kz);
						ms.e(true);
						if (A_2 != null)
						{
							A_2.c(ms);
						}
						else
						{
							A_2 = new mt(ms);
						}
					}
					if (x5.d(A_3, x5.f(kz.c5().am().Value, kz.c5().f().d())))
					{
						A_3 = x5.f(kz.c5().am().Value, kz.c5().f().d());
					}
					num++;
				}
			}
			A_0.c(A_2);
			A_0.c5().j(new x5?(A_3));
		}

		// Token: 0x06001A88 RID: 6792 RVA: 0x0011423C File Offset: 0x0011323C
		private mt a(m7 A_0, ij A_1, ref float A_2)
		{
			x5? x = ((n5)A_0.db()).p();
			mt result = null;
			int num = 0;
			n3 n;
			if (this.a.b() != null && this.a.b().Length > 0)
			{
				qd qd = new qd(this.a.b().ToCharArray(), 0, this.a.b().Length, this.b.k().b());
				n = (n3)qd.cm(A_1, A_0);
			}
			else
			{
				pl pl = new pl();
				n = (n3)pl.cm(A_1, A_0);
			}
			ms ms = new ms(n);
			l4 l = ((n5)A_0.db()).a();
			if (l.b())
			{
				l.a("arial");
			}
			if (l.d())
			{
				l.a(x5.a(11f));
			}
			if (l.e())
			{
				l.a(f4.b);
			}
			if (l.c())
			{
				l.a(f7.k);
			}
			n.dc(A_0.db());
			A_2 = this.a(n);
			num++;
			if (x != null)
			{
				ms.k(x.Value);
			}
			if (num - 1 < this.e)
			{
				result = new mt(ms);
			}
			return result;
		}

		// Token: 0x06001A89 RID: 6793 RVA: 0x001143E4 File Offset: 0x001133E4
		private float a(n3 A_0)
		{
			Font font = A_0.j().e();
			float a_ = x5.b(((n5)A_0.db()).a().i());
			return font.a(A_0.d(), A_0.h(), A_0.ba(), a_);
		}

		// Token: 0x06001A8A RID: 6794 RVA: 0x0011443C File Offset: 0x0011343C
		private void a(m7 A_0)
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
			bool flag = A_0.c5().g();
			if (flag)
			{
				A_0.c5().f().d(x5.c());
				A_0.c5().f().b(x5.c());
				A_0.c5().f().a(x5.c());
				A_0.c5().f().c(x5.c());
			}
			A_0.c5().i(null);
			A_0.c5().a(i2.a);
			A_0.c5().a(g3.c);
		}

		// Token: 0x06001A8B RID: 6795 RVA: 0x001145D8 File Offset: 0x001135D8
		internal override kz cm(ij A_0, kz A_1)
		{
			m7 m = new m7();
			A_0.c(this.ch());
			A_0.a(m);
			n5 n = (n5)m.db();
			if (((ng)A_1).b())
			{
				((n5)m.db()).a(Color.d("#A0A0A0"));
				m.c5().c().i(n.j());
			}
			else
			{
				m.c5().c().i(n.j());
			}
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
				this.a(m);
				this.a(m, A_0);
				m.b(this.a.a());
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

		// Token: 0x04000C10 RID: 3088
		private new o0 a = null;

		// Token: 0x04000C11 RID: 3089
		private oz b = null;

		// Token: 0x04000C12 RID: 3090
		private bool c = true;

		// Token: 0x04000C13 RID: 3091
		private new bool d = false;

		// Token: 0x04000C14 RID: 3092
		private new int e = 1;

		// Token: 0x04000C15 RID: 3093
		private new x5? f = null;
	}
}
