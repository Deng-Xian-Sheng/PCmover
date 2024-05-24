using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001FB RID: 507
	internal class m5 : k0
	{
		// Token: 0x060016DF RID: 5855 RVA: 0x000F8800 File Offset: 0x000F7800
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060016E0 RID: 5856 RVA: 0x000F8818 File Offset: 0x000F7818
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060016E1 RID: 5857 RVA: 0x000F8828 File Offset: 0x000F7828
		internal ow b()
		{
			return this.d;
		}

		// Token: 0x060016E2 RID: 5858 RVA: 0x000F8840 File Offset: 0x000F7840
		internal void a(ow A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060016E3 RID: 5859 RVA: 0x000F884C File Offset: 0x000F784C
		internal override bool de()
		{
			return this.c;
		}

		// Token: 0x060016E4 RID: 5860 RVA: 0x000F8864 File Offset: 0x000F7864
		internal override void df(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060016E5 RID: 5861 RVA: 0x000F8870 File Offset: 0x000F7870
		internal x5 c()
		{
			return this.e;
		}

		// Token: 0x060016E6 RID: 5862 RVA: 0x000F8888 File Offset: 0x000F7888
		internal void a(x5 A_0)
		{
			this.e = A_0;
		}

		// Token: 0x060016E7 RID: 5863 RVA: 0x000F8894 File Offset: 0x000F7894
		internal override int dg()
		{
			return 86163053;
		}

		// Token: 0x060016E8 RID: 5864 RVA: 0x000F88AC File Offset: 0x000F78AC
		internal mf d()
		{
			return this.b;
		}

		// Token: 0x060016E9 RID: 5865 RVA: 0x000F88C4 File Offset: 0x000F78C4
		internal void a(mf A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060016EA RID: 5866 RVA: 0x000F88D0 File Offset: 0x000F78D0
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x060016EB RID: 5867 RVA: 0x000F88EF File Offset: 0x000F78EF
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x060016EC RID: 5868 RVA: 0x000F88F9 File Offset: 0x000F78F9
		private void a()
		{
		}

		// Token: 0x060016ED RID: 5869 RVA: 0x000F88FC File Offset: 0x000F78FC
		internal override k0 dd()
		{
			return new m5();
		}

		// Token: 0x060016EE RID: 5870 RVA: 0x000F8914 File Offset: 0x000F7914
		internal override kz dj(x5 A_0, x5 A_1)
		{
			if (base.n() != null)
			{
				mu mu = base.n().c();
				if (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					if (ms.l() != null)
					{
						mr mr = ms.l().a();
						if (mr != null)
						{
							mr.b().c5().i(base.c5().v());
						}
						mr.b().c5().j(base.c5().am());
						mr.b().c5().d(base.c5().ap());
						mr.b().c5().a(base.c5().ah());
					}
				}
			}
			return base.c(A_0, A_1);
		}

		// Token: 0x060016EF RID: 5871 RVA: 0x000F8A0C File Offset: 0x000F7A0C
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
			if (this.d != ow.d)
			{
				A_0.SetLineWidth(0.4f);
				A_0.SetLineStyle(LineStyle.Solid);
				A_0.SetStrokeColor(RgbColor.DarkGreen);
				float num = (base.c5().v() != null) ? x5.b(base.c5().v().Value) : 0f;
				float num2 = x5.b(x5.f(A_2, this.e));
				num2 -= num + x5.b(base.c5().a2());
				A_0.Write_re(x5.b(A_1) + x5.b(base.c5().c().n()), num2, (base.c5().am() != null) ? x5.b(base.c5().am().Value) : 0f, num);
				A_0.Write_s_();
			}
		}

		// Token: 0x060016F0 RID: 5872 RVA: 0x000F8B20 File Offset: 0x000F7B20
		internal override kz dm()
		{
			m5 m = new m5();
			m.j(this.dr());
			m.dc(this.db().du());
			m.a((lk)base.c5().du());
			m.df(this.c);
			m.a(this.d);
			m.a(this.b);
			m.a(this.e);
			if (base.n() != null)
			{
				m.c(base.n().p());
			}
			return m;
		}

		// Token: 0x04000A7F RID: 2687
		private new n5 a = new n5();

		// Token: 0x04000A80 RID: 2688
		private new mf b = null;

		// Token: 0x04000A81 RID: 2689
		private new bool c = false;

		// Token: 0x04000A82 RID: 2690
		private new ow d = ow.e;

		// Token: 0x04000A83 RID: 2691
		private new x5 e = x5.c();
	}
}
